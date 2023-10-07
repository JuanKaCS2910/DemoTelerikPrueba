var offsetMiliseconds = 0;


function updateOffset() {
    var of = new Date().getTimezoneOffset()+60;

    offsetMiliseconds = of * 60000;

}

(function () {
    updateOffset();

})();

function onRequestEndAutomatico(e) {
    //updateOffset();
    var expr = /Date\(/;
    if (e.response.Data && e.response.Data.length) {
        var procesos = e.response.Data;
        if (this.group().length) {
            for (var i = 0; i < procesos.length; i++) {
                var gr = procesos[i];
                if (typeof gr.Key !== "undefined") {
                    if (gr.Key.toString().match(expr)) {
                        gr.Key = gr.Key.replace(/[-0-9]+/,
                            function (n) { return parseInt(n) + (new Date(parseInt(n)).getTimezoneOffset() * 60000)  }
                        );
                    }
                    addOffset(gr.Items);
                }
            }
        } else {
            addOffset(procesos);
        }

    }
}

function addOffset(procesos) {
    var expr = /Date\(/;
    for (var i = 0; i < procesos.length; i++) {

        $.each(procesos[i], function (k, v) {
            if (v && v.toString().match(expr)) {
                //debugger;
                procesos[i][k] = procesos[i][k].replace(/[-0-9]+/,
                    function (n) {
                        return parseInt(n) + (new Date(parseInt(n)).getTimezoneOffset() * 60000) ;
                    }

                );
            }
        });
    }
}

function onDataBoundNewColumn(e) {
    try {
        var grid = this;
        //grid.dataSource.read();
        
        grid.table.find("tr").each(function () {
            var dataItem = grid.dataItem(this);
            var type = dataItem.IdRol == "0" ? 'success' : 'error';
            var text = dataItem.IdRol == "0" ? '+' : 'X';

            $(this).find('script').each(function () {
                eval($(this).html());
            });

            $(this).find(".badgeTemplate").kendoBadge({
                type: type,
                value: text,
                
            });
            kendo.bind($(this), dataItem);
        });
        //kendo.ui.progress(grid, false);
    } catch (e) {

    }
}

function onDataBoundFestivoColumnGrid(e) {
    try {
        var grid = this;
        //grid.dataSource.read();

        grid.table.find("tr").each(function () {
            var dataItem = grid.dataItem(this);
            var type = dataItem.Estilo;
            var text = " ";

            $(this).find('script').each(function () {
                eval($(this).html());
            });

            $(this).find(".badgeTemplate").kendoBadge({
                type: type,
                value: text,

            });

            kendo.bind($(this), dataItem);
        });
        //kendo.ui.progress(grid, false);
    } catch (e) {

    }
}

function onDataBoundNewColumnGrid(e) {
    try {
        var grid = this;

        grid.table.find("tr").each(function () {
            var dataItem = grid.dataItem(this);
            var type = dataItem.IdAcceso == "0" ? '' : 'success';
            var text = dataItem.IdAcceso == "0" ? '' : '+';

            if (text == "+") {
                $(this).find('script').each(function () {
                    eval($(this).html());
                });
                $(this).find(".badgeTemplate").kendoBadge({
                    type: type,
                    value: text,

                });
                kendo.bind($(this), dataItem);
            }
            else {
                $(this).find("td").find("button").remove();
            }

        });
    } catch (e) {

    }
}

function onViewAuditoria(e) {
    try {
        var auditoria = $("#auditoria").val();
        
        var grid = this;
        if (grid.dataSource == undefined)
            grid = e;

        var data = grid.dataSource.data();

        $.each(data, function (i, row) {
            var creacion = "";
            var fechaCreacion = "";
            var modificacion = "";
            var fechaModificacion = "";

            if (row.Creacion != null)
                creacion = row.Creacion;
            if (row.FechaCreacion != null)
                fechaCreacion = fechaAString(row.FechaCreacion);
            if (row.Modificacion != null)
                modificacion = row.Modificacion;
            if (row.FechaModificacion != null)
                fechaModificacion = fechaAString(row.FechaModificacion);

            var auditoriaShow = auditoria.format(creacion, fechaCreacion, modificacion, fechaModificacion);
            $('tr[data-uid="' + row.uid + '"] ').attr("Title", auditoriaShow);
        });
    } catch (e) {
        //alert(e);
    }
}

String.prototype.format = function () {
    a = this;
    for (k in arguments) {
        a = a.replace("{" + k + "}", arguments[k]);
    }
    return a;
}
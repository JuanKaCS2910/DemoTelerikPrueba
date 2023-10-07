/* creación de variables*/
let password = document.getElementById("password");

$("#faeye").click(function () {
    if (password.type === 'password') {
        password.setAttribute("type", "text");
        $("#faeye").hide();
        $("#faeyeslash").show();
    }
});

$("#faeyeslash").click(function () {
    password.setAttribute("type", "password");
    $("#faeyeslash").hide();
    $("#faeye").show();
});
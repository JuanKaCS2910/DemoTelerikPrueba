using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace DemoTelerik.Modules
{
    public class IdiomasSitio
    {
        public static List<Idioma> Idiomas = new List<Idioma>()
            {
                new Idioma() {Nombre = "Español", Valor = "es-ES", NombreKendo = "es-ES", Codigo = 1034,Imagen="flag-icon flag-icon-es"},
                new Idioma() {Nombre = "English", Valor = "en-US", NombreKendo = "en-US", Codigo = 1033,Imagen="flag-icon flag-icon-us"},
                new Idioma() {Nombre = "Português", Valor = "pt-PT", NombreKendo = "pt-PT", Codigo = 2070,Imagen="flag-icon flag-icon-pt"},

            };

        public static void SetIdioma(String valor, HttpContext httpContext)
        {

            var idioma = Idiomas.FirstOrDefault(o => o.Valor == valor);
            if (idioma != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(idioma.Codigo);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(idioma.Codigo);

                httpContext.Response.Cookies.Append("lang", valor);

                httpContext.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(valor)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(7) }
                );
            }
        }

    }

    public class Idioma
    {
        public String Valor { get; set; }
        public String Nombre { get; set; }
        public string NombreKendo { get; set; }
        public int Codigo { get; set; }
        public string Imagen { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace DemoTelerik.Controllers
{
	public class CasaController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

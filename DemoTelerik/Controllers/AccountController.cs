using DemoTelerik.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoTelerik.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return RedirectToAction("Login");
		}
		public async Task<ActionResult> Login(int? opcion, String ReturnUrl)
		{


			if (ReturnUrl != null)
			{
				TempData["ru"] = ReturnUrl;
			}


			return View(new LogOnViewModel() { Opcion = opcion });
		}
	}
}

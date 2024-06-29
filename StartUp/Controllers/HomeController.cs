using Microsoft.AspNetCore.Mvc;

namespace StartUp.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

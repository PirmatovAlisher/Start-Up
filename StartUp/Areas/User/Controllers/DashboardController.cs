using Microsoft.AspNetCore.Mvc;

namespace StartUp.Areas.User.Controllers
{
	[Area("User")]
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

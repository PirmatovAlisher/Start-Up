using CoreLayer.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Exceptions.WebApplication;

namespace StartUp.Controllers
{
	public class ErrorController : Controller
	{
		public IActionResult GeneralExceptions()
		{
			var exceptions = HttpContext.Features.Get<IExceptionHandlerFeature>()!.Error;

			if (exceptions is ClientSideExceptions)
			{
				return View(new ErrorVM(exceptions.Message, 401));
			}
			else if (exceptions is DbUpdateConcurrencyException)
			{
				return View(new ErrorVM("Your data has been changed, please try later.", 401));
			}
			else if (exceptions.InnerException is SqlException sqlException && sqlException.Number == 547)
			{
				return View(new ErrorVM("You have too delete all relevant data before move on.", 401));
			}

			return View(new ErrorVM("Server error, please contact with server", 500)); ;
		}
	}
}

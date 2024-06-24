using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NToastNotify;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Filter.WebApplication
{
	public class AddAboutPreventationFilter : IAsyncActionFilter
	{
		private readonly IAboutService _aboutService;
		private readonly IToastNotification _toasty;

		public AddAboutPreventationFilter(IAboutService aboutService, IToastNotification toasty)
		{
			_aboutService = aboutService;
			_toasty = toasty;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var aboutList = await _aboutService.GetAllListAsync();

			if (aboutList.Any())
			{
				_toasty.AddErrorToastMessage("You already have an about section, please delete it first then try again",
					new ToastrOptions { Title = "I'm sorry!"});
				context.Result = new RedirectToActionResult("GetAboutList", "About", new { Area = ("Admin") });
				return;
			}

				await next.Invoke();
				return;
		}
	}
}

using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StartUp.Areas.User.Components
{
	[Authorize]
	[Area("User")]
	public class LayoutViewComponent : ViewComponent
	{
		private readonly UserManager<AppUser> _userManager;

		public LayoutViewComponent(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync(string UserName)
		{

			if (UserName == null)
			{
				UserName = User.Identity!.Name!;
			}

			var user = await _userManager.FindByNameAsync(UserName);

			if (user!.FileName == null)
			{
				return View(new UserPictureVM { FileName = "Default" });
			}

			return View(new UserPictureVM { FileName = user.FileName });

		}
	}
}

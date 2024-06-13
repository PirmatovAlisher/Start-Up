using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StartUp.Areas.User.Controllers
{
	[Authorize]
	[Area("User")]
	public class AuthenticationUserController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;

		public AuthenticationUserController(UserManager<AppUser> userManager, IMapper mapper)
		{
			_userManager = userManager;
			_mapper = mapper;
		}


		[HttpGet]
		public async Task<IActionResult> UserEdit()
		{
			var user = await _userManager.FindByNameAsync(User.Identity!.Name!);

			var userEditVM = _mapper.Map<UserEditVM>(user);

			return View(userEditVM);

		}
	}
}

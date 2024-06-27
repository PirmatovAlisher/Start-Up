﻿using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ServiceLayer.Messages.Identity;
using System.Security.Claims;

namespace StartUp.Areas.Admin.Controllers
{
	[Authorize(Policy = "AdminObserver")]
	[Area("Admin")]
	public class AdminController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;
		private readonly IToastNotification _toasty;

		public AdminController(UserManager<AppUser> userManager, IMapper mapper, IToastNotification toasty)
		{
			_userManager = userManager;
			_mapper = mapper;
			_toasty = toasty;
		}

		public IActionResult Index()
		{
			return View();
		}


		public async Task<IActionResult> GetUserList()
		{
			var userList = await _userManager.Users.ToListAsync();
			var userListVM = _mapper.Map<List<UserVM>>(userList);

			for (int i = 0; i < userList.Count; i++)
			{
				var userRoles = await _userManager.GetRolesAsync(userList[i]);
				userListVM[i].UserRoles = userRoles;

				var userClaims = await _userManager.GetClaimsAsync(userList[i]);
				userListVM[i].UserClaims = userClaims;
			}

			return View(userListVM);
		}

		public async Task<IActionResult> ExtendClaim(string userName)
		{

			var user = await _userManager.FindByNameAsync(userName);
			var claims = await _userManager.GetClaimsAsync(user!);
			var existingClaim = claims.FirstOrDefault(x => x.Type.Contains("Observer"));

			var newExtendedClaim = new Claim("AdminObserverExpireDate", DateTime.Now.AddDays(5).ToString());

			var renewClaim = await _userManager.ReplaceClaimAsync(user!, existingClaim!, newExtendedClaim);
			if (!renewClaim.Succeeded)
			{
				_toasty.AddErrorToastMessage(NotificationMessagesIdentity.ExtendClaimFailed,
				new ToastrOptions { Title = NotificationMessagesIdentity.FailedTitle });
				return RedirectToAction("GetUserList", "Admin", new { Areas = "Admin" });
			}

			_toasty.AddSuccessToastMessage(NotificationMessagesIdentity.ExtendClaimSuccess,
				new ToastrOptions { Title = NotificationMessagesIdentity.SucceededTitle });
			return RedirectToAction("GetUserList", "Admin", new { Areas = "Admin" });
		}
	}
}

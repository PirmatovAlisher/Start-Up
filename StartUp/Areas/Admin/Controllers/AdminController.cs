using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ServiceLayer.Messages.Identity;
using ServiceLayer.Services.Identity.Abstract;
using System.Security.Claims;

namespace StartUp.Areas.Admin.Controllers
{
	[Authorize(Policy = "AdminObserver")]
	[Area("Admin")]
	public class AdminController : Controller
	{
		private readonly IAuthenticationAdminService _adminService;
		private readonly IToastNotification _toasty;

		public AdminController(IToastNotification toasty, IAuthenticationAdminService adminService)
		{
			_toasty = toasty;
			_adminService = adminService;
		}

		public IActionResult Index()
		{
			return View();
		}


		public async Task<IActionResult> GetUserList()
		{
			var userListVM = await _adminService.GetUserListAsync();
			return View(userListVM);
		}

		public async Task<IActionResult> ExtendClaim(string userName)
		{
			var renewClaim = await _adminService.ExtendClaimAsync(userName);
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

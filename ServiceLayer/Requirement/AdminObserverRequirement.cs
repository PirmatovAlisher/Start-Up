﻿using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ServiceLayer.Requirement
{
	public class AdminObserverRequirement : IAuthorizationRequirement
	{
	}

	public class AdminObserverRequirementHandler : AuthorizationHandler<AdminObserverRequirement>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public AdminObserverRequirementHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminObserverRequirement requirement)
		{
			var hasSuperAdminRole = context.User.IsInRole("SuperAdmin");
			if (hasSuperAdminRole)
			{
				context.Succeed(requirement);
				return;
			}

			var claim = context.User.FindFirst("AdminObserverExpireDate");
			if (claim == null)
			{
				context.Fail();
				return;
			}

			var cookieExpireDate = Convert.ToDateTime(claim.Value);
			if (DateTime.Now < cookieExpireDate)
			{
				context.Succeed(requirement);
				return;
			}

			var user = await _userManager.FindByNameAsync(context.User.Identity!.Name!);

			var claims = await _userManager.GetClaimsAsync(user!);

			var dbExpireDate = Convert.ToDateTime(claims.FirstOrDefault(x => x.Type.Contains("Observer"))!.Value);
			if (dbExpireDate > cookieExpireDate)
			{
				await _signInManager.SignOutAsync();
				await _signInManager.SignInAsync(user!, isPersistent: false);

				context.Succeed(requirement);
				return;
			}

			context.Fail();
			return;
		}
	}
}

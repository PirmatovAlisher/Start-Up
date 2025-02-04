﻿using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Customization.Identity.Validators
{
	public class CustomUserValidator : IUserValidator<AppUser>
	{
		public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
		{
			var errors = new List<IdentityError>();

			var isNumberic = int.TryParse(user.UserName![0].ToString(), out _);
			if (isNumberic)
			{
				errors.Add(new() { Code = "StartWithDigitError", Description = "User name can not start with digit" });
			}

			if (errors.Any())
			{
				return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
			}

			return Task.FromResult(IdentityResult.Success);
		}
	}
}

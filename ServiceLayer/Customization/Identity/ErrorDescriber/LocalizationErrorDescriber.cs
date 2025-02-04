﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Customization.Identity.ErrorDescriber
{
	public class LocalizationErrorDescriber : IdentityErrorDescriber
	{
		public override IdentityError PasswordRequiresDigit()
		{
			//return new() { Code = "NewDigitError", Description = "Please use digits" };
			return base.PasswordRequiresDigit();
		}

		public override IdentityError PasswordRequiresLower()
		{
			//return new() { Code = "NewLowerLettersError", Description = "Please user lowercase letters" };
			return base.PasswordRequiresLower();
		}

		public override IdentityError PasswordTooShort(int length)
		{
			//return new() { Code = "NewTooShortError", Description = "Your password is too short!" };
			return base.PasswordTooShort(length);
		}
	}
}

﻿using EntityLayer.Identity.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.Identity;
using ServiceLayer.Messages.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.Identity
{
	public class ForgotPasswordValidation : AbstractValidator<ForgotPasswordVM>
	{
		public ForgotPasswordValidation()
		{
			RuleFor(x => x.Email).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Email")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Email")).
				EmailAddress().WithMessage(IdentityMessages.CheckEmailAddress());
		}
	}
}

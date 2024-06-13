using EntityLayer.Identity.ViewModels;
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
	public class UserEditValidation : AbstractValidator<UserEditVM>
	{
		public UserEditValidation()
		{
			RuleFor(x => x.UserName).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("User Name")).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("User Name"));

			RuleFor(x => x.Email).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Email")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Email")).
				EmailAddress().WithMessage(IdentityMessages.CheckEmailAddress());

			RuleFor(x => x.Password).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Password")).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Password"));

			RuleFor(x => x.ConfirmNewPassword).
				Equal(c => c.NewPassword).WithMessage(IdentityMessages.ComparePassword());
		}
	}
}

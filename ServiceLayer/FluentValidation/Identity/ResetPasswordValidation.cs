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
	public class ResetPasswordValidation : AbstractValidator<ResetPasswordVM>
	{
		public ResetPasswordValidation()
		{
			RuleFor(x => x.Password).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Password")).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Password"));

			RuleFor(x => x.ConfirmPassword).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Confirm Password")).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Confirm Password")).
				Equal(c => c.Password).WithMessage(IdentityMessages.ComparePassword());
		}
	}
}

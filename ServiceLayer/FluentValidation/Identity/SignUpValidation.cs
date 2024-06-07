using EntityLayer.Identity.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.Identity;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.Identity
{
	public class SignUpValidation : AbstractValidator<SignUpVM>
	{

		public SignUpValidation()
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
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Password")).
				Equal(c => c.ConfirmPassword);

			RuleFor(x => x.ConfirmPassword).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Confirm Password")).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Confirm Password")).
				Equal(c => c.Password).WithMessage(IdentityMessages.ComparePassword());
		}
	}
}

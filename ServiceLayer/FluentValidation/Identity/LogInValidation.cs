using EntityLayer.Identity.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.Identity;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.Identity
{
	public class LogInValidation : AbstractValidator<LogInVM>
	{
		public LogInValidation()
		{
			RuleFor(x => x.Email).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Email")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Email")).
				EmailAddress().WithMessage(IdentityMessages.CheckEmailAddress());

			RuleFor(x => x.Password).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Password")).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Password"));
		}
	}
}

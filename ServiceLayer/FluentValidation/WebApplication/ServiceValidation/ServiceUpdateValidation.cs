using EntityLayer.WebApplication.ViewModels.ServiceVM;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.WebApplication.ServiceValidation
{
	public class ServiceUpdateValidation : AbstractValidator<ServiceUpdateVM>
	{
		public ServiceUpdateValidation()
		{
			RuleFor(x => x.Name).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Name")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Name")).
				MaximumLength(100).WithMessage(ValidationMessages.MaximumCharacterAllowance("Name", 100));

			RuleFor(x => x.Description).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Description")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Description")).
				MaximumLength(2000).WithMessage(ValidationMessages.MaximumCharacterAllowance("Description", 2000));

			RuleFor(x => x.Icon).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Icon")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Icon")).
				MaximumLength(100).WithMessage(ValidationMessages.MaximumCharacterAllowance("Icon", 100));
		}
	}
}

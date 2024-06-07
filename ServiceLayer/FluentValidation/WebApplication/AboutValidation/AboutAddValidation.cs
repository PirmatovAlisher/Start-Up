using EntityLayer.WebApplication.ViewModels.AboutVM;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.WebApplication.AboutValidation
{
	public class AboutAddValidation : AbstractValidator<AboutAddVM>
	{
		public AboutAddValidation()
		{
			RuleFor(p => p.Header).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Header")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Header")).
				MaximumLength(200).WithMessage(ValidationMessages.MaximumCharacterAllowance("Header", 200));

			RuleFor(p => p.Description).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Description")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Description")).
				MaximumLength(5000).WithMessage(ValidationMessages.MaximumCharacterAllowance("Description", 5000));

			RuleFor(p => p.Clients).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Clients")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Clients")).
				GreaterThan(0).WithMessage(ValidationMessages.GreaterThenMessage("Clients", 0)).
				LessThan(1000).WithMessage(ValidationMessages.LessThenMessage("Clients", 1000));

			RuleFor(p => p.Projects).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Projects")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Projects")).
				GreaterThan(0).WithMessage(ValidationMessages.GreaterThenMessage("Projects", 0)).
				LessThan(10000).WithMessage(ValidationMessages.LessThenMessage("Projects", 10000));

			RuleFor(p => p.HoursOfSupport).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Hours Of Support")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Hours Of Support")).
				GreaterThan(0).WithMessage(ValidationMessages.GreaterThenMessage("Hours Of Support", 0)).
				LessThan(100000).WithMessage(ValidationMessages.LessThenMessage("Hours Of Support", 100000));

			RuleFor(p => p.HardWorkers).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Hard Workers")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Hard Workers")).
				GreaterThan(0).WithMessage(ValidationMessages.GreaterThenMessage("Hard Workers", 0)).
				LessThan(99).WithMessage(ValidationMessages.LessThenMessage("Hard Workers", 99));

			RuleFor(p => p.Photo).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Photo")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Photo"));

		}

	}
}

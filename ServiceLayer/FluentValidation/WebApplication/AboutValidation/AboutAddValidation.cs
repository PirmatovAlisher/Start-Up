using EntityLayer.WebApplication.ViewModels.AboutVM;
using FluentValidation;

namespace ServiceLayer.FluentValidation.WebApplication.AboutValidation
{
	public class AboutAddValidation : AbstractValidator<AboutAddVM>
	{
		public AboutAddValidation()
		{
			RuleFor(p => p.Header).
				NotEmpty().
				NotNull().
				MaximumLength(200);

			RuleFor(p => p.Description).
				NotEmpty().
				NotNull().
				MaximumLength(5000);

			RuleFor(p => p.Clients).
				NotEmpty().
				NotNull().
				GreaterThan(0).
				LessThan(1000);

			RuleFor(p => p.Projects).
				NotEmpty().
				NotNull().
				GreaterThan(0).
				LessThan(10000);

			RuleFor(p => p.HoursOfSupport).
				NotEmpty().
				NotNull().
				GreaterThan(0).
				LessThan(100000);

			RuleFor(p => p.HardWorkers).
				NotEmpty().
				NotNull().
				GreaterThan(0).
				LessThan(99);

			RuleFor(p => p.Photo).
				NotEmpty().
				NotNull();

		}

	}
}

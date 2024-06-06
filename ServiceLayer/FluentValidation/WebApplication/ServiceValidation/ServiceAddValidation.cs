using EntityLayer.WebApplication.ViewModels.ServiceVM;
using FluentValidation;

namespace ServiceLayer.FluentValidation.WebApplication.ServiceValidation
{
	public class ServiceAddValidation : AbstractValidator<ServiceAddVM>
	{
		public ServiceAddValidation()
		{
			RuleFor(x => x.Name).
				NotNull().
				NotEmpty().
				MaximumLength(100);

			RuleFor(x => x.Description).
				NotNull().
				NotEmpty().
				MaximumLength(2000);

			RuleFor(x => x.Icon).
				NotNull().
				NotEmpty().
				MaximumLength(100);
		}
	}
}

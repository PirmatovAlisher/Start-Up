using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using FluentValidation;

namespace ServiceLayer.FluentValidation.WebApplication.PortfolioValidation
{
	public class PortfolioUpdateValidation : AbstractValidator<PortfolioUpdateVM>
	{
		public PortfolioUpdateValidation()
		{
			RuleFor(x => x.Title).
				NotNull().
				NotEmpty().
				MaximumLength(200);

			RuleFor(x => x.FileName).
				NotNull().
				NotEmpty();

			RuleFor(x => x.FileType).
				NotNull().
				NotEmpty();
		}
	}
}

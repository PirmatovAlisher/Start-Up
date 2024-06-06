using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using FluentValidation;

namespace ServiceLayer.FluentValidation.WebApplication.PortfolioValidation
{
	public class PortfolioAddValidation : AbstractValidator<PortfolioAddVM>
	{
		public PortfolioAddValidation()
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

			RuleFor(p => p.Photo).
				NotEmpty().
				NotNull();
		}
	}
}

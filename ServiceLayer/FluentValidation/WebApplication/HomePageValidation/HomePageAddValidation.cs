using EntityLayer.WebApplication.ViewModels.HomePageVM;
using FluentValidation;

namespace ServiceLayer.FluentValidation.WebApplication.HomePageValidation
{
	public class HomePageAddValidation : AbstractValidator<HomePageAddVM>
	{
		public HomePageAddValidation()
		{
			RuleFor(x => x.Header).
				NotNull().
				NotEmpty().
				MaximumLength(200);

			RuleFor(x => x.Description).
				NotNull().
				NotEmpty().
				MaximumLength(2000);

			RuleFor(x => x.VideoLink).
				NotNull().
				NotEmpty();
		}
	}
}

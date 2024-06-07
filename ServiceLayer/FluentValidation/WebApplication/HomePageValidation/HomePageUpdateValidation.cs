using EntityLayer.WebApplication.ViewModels.HomePageVM;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.WebApplication.HomePageValidation
{
	public class HomePageUpdateValidation : AbstractValidator<HomePageUpdateVM>
	{
		public HomePageUpdateValidation()
		{
			RuleFor(x => x.Header).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Header")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Header")).
				MaximumLength(200).WithMessage(ValidationMessages.MaximumCharacterAllowance("Header", 200));

			RuleFor(x => x.Description).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Description")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Description")).
				MaximumLength(2000).WithMessage(ValidationMessages.MaximumCharacterAllowance("Description", 2000));

			RuleFor(x => x.VideoLink).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Video Link")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Video Link"));
		}
	}
}

using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.WebApplication.PortfolioValidation
{
	public class PortfolioUpdateValidation : AbstractValidator<PortfolioUpdateVM>
	{
		public PortfolioUpdateValidation()
		{
			RuleFor(x => x.Title).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Title")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Title")).
				MaximumLength(200).WithMessage(ValidationMessages.MaximumCharacterAllowance("Title", 200));
		}
	}
}

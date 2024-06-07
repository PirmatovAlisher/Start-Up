using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.WebApplication.PortfolioValidation
{
	public class PortfolioAddValidation : AbstractValidator<PortfolioAddVM>
	{
		public PortfolioAddValidation()
		{
			RuleFor(x => x.Title).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Title")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Title")).
				MaximumLength(200).WithMessage(ValidationMessages.MaximumCharacterAllowance("Title", 200));

			RuleFor(x => x.FileName).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("File Name")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("File Name"));

			RuleFor(x => x.FileType).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("File Type")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("File Type"));

			RuleFor(p => p.Photo).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Photo")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Photo"));
		}
	}
}

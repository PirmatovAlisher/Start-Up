using EntityLayer.WebApplication.ViewModels.CategortVM;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.WebApplication.CategoryValidation
{
	public class CategoryUpdateValidation : AbstractValidator<CategoryUpdateVM>
	{
		public CategoryUpdateValidation()
		{
			RuleFor(x => x.Name).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Name")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Name")).
				MaximumLength(50).WithMessage(ValidationMessages.MaximumCharacterAllowance("Name", 50));
		}
	}
}

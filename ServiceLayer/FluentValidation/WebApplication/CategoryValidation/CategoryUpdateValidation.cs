using EntityLayer.WebApplication.ViewModels.CategortVM;
using FluentValidation;

namespace ServiceLayer.FluentValidation.WebApplication.CategoryValidation
{
	public class CategoryUpdateValidation : AbstractValidator<CategoryUpdateVM>
	{
		public CategoryUpdateValidation()
		{
			RuleFor(x => x.Name).
				NotEmpty().
				NotNull().
				MaximumLength(50);
		}
	}
}

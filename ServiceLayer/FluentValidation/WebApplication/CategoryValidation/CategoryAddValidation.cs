using EntityLayer.WebApplication.ViewModels.CategortVM;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.CategoryValidation
{
	public class CategoryAddValidation : AbstractValidator<CategoryAddVM>
	{
		public CategoryAddValidation()
		{
			RuleFor(x => x.Name).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Name")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Name")).
				MaximumLength(50).WithMessage(ValidationMessages.MaximumCharacterAllowance("Name", 50)); 
		}
	}
}

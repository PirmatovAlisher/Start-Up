using EntityLayer.WebApplication.ViewModels.TeamVM;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.TeamValidation
{
	public class TeamUpdateValidation : AbstractValidator<TeamUpdateVM>
	{
		public TeamUpdateValidation()
		{
			RuleFor(p => p.FullName).
				NotEmpty().
				NotNull().
				MaximumLength(100);

			RuleFor(p => p.Title).
				NotEmpty().
				NotNull().
				MaximumLength(100);

			RuleFor(p => p.FileName).
				NotEmpty().
				NotNull();

			RuleFor(p => p.FileType).
				NotEmpty().
				NotNull();
		}
	}
}

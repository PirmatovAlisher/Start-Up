using EntityLayer.WebApplication.ViewModels.TeamVM;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.TeamValidation
{
	public class TeamAddValidation : AbstractValidator<TeamAddVM>
	{
		public TeamAddValidation()
		{
			RuleFor(p => p.FullName).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Full Name")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Full Name")).
				MaximumLength(100).WithMessage(ValidationMessages.MaximumCharacterAllowance("Full Name", 100));

			RuleFor(p => p.Title).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Title")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Title")).
				MaximumLength(100).WithMessage(ValidationMessages.MaximumCharacterAllowance("Title", 100));

			RuleFor(p => p.FileName).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("File Name")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("File Name"));

			RuleFor(p => p.FileType).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("File Type")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("File Type"));

			RuleFor(p => p.Photo).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Photo")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Photo"));
		}
	}
}

using EntityLayer.WebApplication.ViewModels.ContactVM;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.ContactValidation
{
	public class ContactAddValidation : AbstractValidator<ContactAddVM>
	{
		public ContactAddValidation()
		{
			RuleFor(x => x.Location).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Location")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Location")).
				MaximumLength(200).WithMessage(ValidationMessages.MaximumCharacterAllowance("Location", 200));

			RuleFor(x => x.Map).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Map")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Map"));

			RuleFor(x => x.Email).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Email")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Email")).
				MaximumLength(100).WithMessage(ValidationMessages.MaximumCharacterAllowance("Email", 100));

			RuleFor(x => x.Call).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Call")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Call")).
				MaximumLength(17).WithMessage(ValidationMessages.MaximumCharacterAllowance("Call", 17));
		}

	}
}

using EntityLayer.WebApplication.ViewModels.ContactVM;
using FluentValidation;
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
				NotNull().
				NotEmpty().
				MaximumLength(200);

			RuleFor(x => x.Map).
				NotNull().
				NotEmpty();

			RuleFor(x => x.Email).
				NotNull().
				NotEmpty().
				MaximumLength(100);

			RuleFor(x => x.Call).
				NotNull().
				NotEmpty().
				MaximumLength(17);
		}

	}
}

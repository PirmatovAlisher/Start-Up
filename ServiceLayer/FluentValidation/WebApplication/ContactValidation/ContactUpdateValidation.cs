﻿using EntityLayer.WebApplication.ViewModels.ContactVM;
using FluentValidation;

namespace ServiceLayer.FluentValidation.WebApplication.ContactValidation
{
	public class ContactUpdateValidation : AbstractValidator<ContactUpdateVM>
	{
		public ContactUpdateValidation()
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

﻿using EntityLayer.WebApplication.ViewModels.ServiceVM;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.ServiceValidation
{
	public class ServiceUpdateValidation : AbstractValidator<ServiceUpdateVM>
	{
        public ServiceUpdateValidation()
        {
			RuleFor(x => x.Name).
				NotNull().
				NotEmpty().
				MaximumLength(100);

			RuleFor(x => x.Description).
				NotNull().
				NotEmpty().
				MaximumLength(2000);

			RuleFor(x => x.Icon).
				NotNull().
				NotEmpty().
				MaximumLength(100);
		}
    }
}

using EntityLayer.WebApplication.ViewModels.AboutVM;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.AboutValidation
{
	public class AboutUpdateValidation : AbstractValidator<AboutUpdateVM>
	{
		public AboutUpdateValidation()
		{
			RuleFor(p => p.Header).
				NotEmpty().
				NotNull().
				MaximumLength(200);

			RuleFor(p => p.Description).
				NotEmpty().
				NotNull().
				MaximumLength(5000);

			RuleFor(p => p.Clients).
				NotEmpty().
				NotNull().
				GreaterThan(0).
				LessThan(1000);

			RuleFor(p => p.Projects).
				NotEmpty().
				NotNull().
				GreaterThan(0).
				LessThan(10000);

			RuleFor(p => p.HoursOfSupport).
				NotEmpty().
				NotNull().
				GreaterThan(0).
				LessThan(100000);

			RuleFor(p => p.HardWorkers).
				NotEmpty().
				NotNull().
				GreaterThan(0).
				LessThan(99);

		}
	}
}

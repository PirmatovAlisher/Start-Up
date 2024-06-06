using EntityLayer.WebApplication.ViewModels.TestimonialVM;
using FluentValidation;

namespace ServiceLayer.FluentValidation.WebApplication.TestimonialValidation
{
	public class TestimonialUpdateValidation : AbstractValidator<TestimonialUpdateVM>
	{
		public TestimonialUpdateValidation()
		{
			RuleFor(p => p.Comment).
				NotEmpty().
				NotNull().
				MaximumLength(2000);

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

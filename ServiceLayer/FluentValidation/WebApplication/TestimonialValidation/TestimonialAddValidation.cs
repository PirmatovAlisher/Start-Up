using EntityLayer.WebApplication.ViewModels.TestimonialVM;
using FluentValidation;

namespace ServiceLayer.FluentValidation.WebApplication.TestimonialValidation
{
	public class TestimonialAddValidation : AbstractValidator<TestimonialAddVM>
	{
		public TestimonialAddValidation()
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

			RuleFor(p => p.Photo).
				NotEmpty().
				NotNull();
		}
	}
}

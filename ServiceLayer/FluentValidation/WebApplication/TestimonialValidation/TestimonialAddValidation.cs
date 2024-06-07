using EntityLayer.WebApplication.ViewModels.TestimonialVM;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;

namespace ServiceLayer.FluentValidation.WebApplication.TestimonialValidation
{
	public class TestimonialAddValidation : AbstractValidator<TestimonialAddVM>
	{
		public TestimonialAddValidation()
		{
			RuleFor(p => p.Comment).
				NotEmpty().WithMessage(ValidationMessages.NulEmptyMessage("Comment")).
				NotNull().WithMessage(ValidationMessages.NulEmptyMessage("Comment")).
				MaximumLength(2000).WithMessage(ValidationMessages.MaximumCharacterAllowance("Comment", 2000));

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

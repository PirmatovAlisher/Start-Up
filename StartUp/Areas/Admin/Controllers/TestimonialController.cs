using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.TestimonialVM;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Filter.WebApplication;
using ServiceLayer.Services.WebApplication.Abstract;

namespace StartUp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TestimonialController : Controller
	{
		private readonly ITestimonialService _testimonialService;
		private readonly IValidator<TestimonialAddVM> _addValidator;
		private readonly IValidator<TestimonialUpdateVM> _updateValidator;

		public TestimonialController(ITestimonialService testimonialService,
			IValidator<TestimonialAddVM> addValidator,
			IValidator<TestimonialUpdateVM> updateValidator)
		{
			_testimonialService = testimonialService;
			_addValidator = addValidator;
			_updateValidator = updateValidator;
		}

		public async Task<IActionResult> GetTestimonialList()
		{
			var testimonialList = await _testimonialService.GetAllListAsync();

			return View(testimonialList);
		}


		[HttpGet]
		public IActionResult AddTestimonial()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> AddTestimonial(TestimonialAddVM request)
		{
			var validator = await _addValidator.ValidateAsync(request);
			if (validator.IsValid)
			{
				await _testimonialService.AddTestimonialAsync(request);
				return RedirectToAction("GetTestimonialList", "Testimonial", new { Area = ("Admin") });
			}

			validator.AddToModelState(this.ModelState);
			return View(request);

		}

		[ServiceFilter(typeof(GenericNotFoundFilter<Testimonial>))]
		[HttpGet]
		public async Task<IActionResult> UpdateTestimonial(int id)
		{
			var testimonial = await _testimonialService.GetTestimonialById(id);

			return View(testimonial);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateTestimonial(TestimonialUpdateVM request)
		{
			var validator = await _updateValidator.ValidateAsync(request);
			if (validator.IsValid)
			{
				await _testimonialService.UpdateTestimonialAsync(request);
				return RedirectToAction("GetTestimonialList", "Testimonial", new { Area = ("Admin") });
			}

			validator.AddToModelState(this.ModelState);

			return View(request);

		}


		public async Task<IActionResult> DeleteTestimonial(int id)
		{
			await _testimonialService.DeleteTestimonialAsync(id);
			return RedirectToAction("GetTestimonialList", "Testimonial", new { Area = ("Admin") });
		}
	}
}

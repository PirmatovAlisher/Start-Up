using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace StartUp.Components
{
	public class TestimonialsViewComponent : ViewComponent
	{
		private readonly ITestimonialService _testimonialService;

		public TestimonialsViewComponent(ITestimonialService testimonialService)
		{
			_testimonialService = testimonialService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var testimonialList = await _testimonialService.GetAllListForUIAsync();
			return View(testimonialList);
		}
	}
}

using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Filter.WebApplication;
using ServiceLayer.Services.WebApplication.Abstract;

namespace StartUp.Areas.Admin.Controllers
{
	[Authorize(Policy = "AdminObserver")]
	[Area("Admin")]
	public class PortfolioController : Controller
	{
		private readonly IPortfolioService _portfolioService;
		private readonly ICategoryService _categoryService;
		private readonly IValidator<PortfolioAddVM> _addValidator;
		private readonly IValidator<PortfolioUpdateVM> _updateValidator;

		public PortfolioController(IPortfolioService portfolioService,
			IValidator<PortfolioAddVM> addValidator,
			IValidator<PortfolioUpdateVM> updateValidator,
			ICategoryService categoryService)
		{
			_portfolioService = portfolioService;
			_addValidator = addValidator;
			_updateValidator = updateValidator;
			_categoryService = categoryService;
		}

		public async Task<IActionResult> GetPortfolioList()
		{
			var portfolioList = await _portfolioService.GetAllListAsync();

			return View(portfolioList);
		}


		[HttpGet]
		public async Task<IActionResult> AddPortfolio()
		{
			var categories = await _categoryService.GetAllListAsync();
			return View(new PortfolioAddVM { CategoryList = categories });
		}


		[HttpPost]
		public async Task<IActionResult> AddPortfolio(PortfolioAddVM request)
		{
			var validator = await _addValidator.ValidateAsync(request);

			if (validator.IsValid)
			{
				await _portfolioService.AddPortfolioAsync(request);
				return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
			}

			validator.AddToModelState(this.ModelState);

			return View(request);


		}

		[ServiceFilter(typeof(GenericNotFoundFilter<Portfolio>))]
		[HttpGet]
		public async Task<IActionResult> UpdatePortfolio(int id)
		{
			var portfolio = await _portfolioService.GetPortfolioById(id);
			var categories = await _categoryService.GetAllListAsync();
			portfolio.CategoryList = categories;

			return View(portfolio);
		}

		[HttpPost]
		public async Task<IActionResult> UpdatePortfolio(PortfolioUpdateVM request)
		{
			var validator = await _updateValidator.ValidateAsync(request);

			if (validator.IsValid)
			{
				await _portfolioService.UpdatePortfolioAsync(request);
				return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
			}

			validator.AddToModelState(this.ModelState);

			return View(request);


		}

		[Authorize(Roles = "SuperAdmin")]
		public async Task<IActionResult> DeletePortfolio(int id)
		{
			await _portfolioService.DeletePortfolioAsync(id);
			return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
		}
	}
}

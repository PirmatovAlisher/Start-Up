using EntityLayer.WebApplication.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Abstract;
using ServiceLayer.Services.WebApplication.Abstract;

namespace StartUp.Components
{
	public class PortfolioViewComponent : ViewComponent
	{
		private readonly IPortfolioService _portfolioService;
		private readonly IGenericRepositories<Category> _repository;

		public PortfolioViewComponent(IPortfolioService portfolioService, IGenericRepositories<Category> repository)
		{
			_portfolioService = portfolioService;
			_repository = repository;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var portfolioListForUI = await _portfolioService.GetAllListForUIAsync();

			var categories = await _repository.GetAllEntityList().Select(x => x.Name).ToListAsync();

			ViewBag.Categories = categories;

			return View(portfolioListForUI);
		}
	}
}

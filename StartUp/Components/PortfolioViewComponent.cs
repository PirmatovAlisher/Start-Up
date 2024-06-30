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

		public PortfolioViewComponent(IPortfolioService portfolioService)
		{
			_portfolioService = portfolioService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var portfolioListForUI = await _portfolioService.GetAllListForUIAsync();

			return View(portfolioListForUI);
		}
	}
}

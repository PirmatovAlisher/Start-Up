﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace StartUp.Areas.Admin.Controllers
{
	[Authorize(Policy = "AdminObserver")]
	[Area("Admin")]
	public class DashboardController : Controller
	{
		private readonly IDashboardService _dashboardService;

		public DashboardController(IDashboardService dashboardService)
		{
			_dashboardService = dashboardService;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.Services = await _dashboardService.GetAllServicesCountAsync();
			ViewBag.Teams = await _dashboardService.GetAllTeamsCountAsync();
			ViewBag.Testimonials = await _dashboardService.GetAllTestimonialsCountAsync();
			ViewBag.Categories = await _dashboardService.GetAllCategoriesCountAsync();
			ViewBag.Portfolios = await _dashboardService.GetAllPortfoliosCountAsync();
			ViewBag.Users = await _dashboardService.GetAllUsersCountAsync();

			return View();
		}
	}
}

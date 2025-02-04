﻿using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace StartUp.Components
{
	public class HomePageViewComponent : ViewComponent
	{
		private readonly IHomePageService _homePageService;

		public HomePageViewComponent(IHomePageService homePageService)
		{
			_homePageService = homePageService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var homePageList = await _homePageService.GetAllListForUIAsync();
			return View(homePageList);
		}
	}
}

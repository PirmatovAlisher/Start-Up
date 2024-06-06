﻿using EntityLayer.WebApplication.ViewModels.HomePageVM;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace StartUp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomePageController : Controller
	{

		private readonly IHomePageService _homePageService;
		private readonly IValidator<HomePageAddVM> _addValidator;
		private readonly IValidator<HomePageUpdateVM> _updateValidator;

		public HomePageController(IHomePageService homePageService,
			IValidator<HomePageAddVM> addValidator, IValidator<HomePageUpdateVM> updateValidator)
		{
			_homePageService = homePageService;
			_addValidator = addValidator;
			_updateValidator = updateValidator;
		}


		public async Task<IActionResult> GetHomePageList()
		{
			var homePageList = await _homePageService.GetAllListAsync();

			return View(homePageList);
		}


		[HttpGet]
		public IActionResult AddHomePage()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> AddHomePage(HomePageAddVM request)
		{
			var validation = await _addValidator.ValidateAsync(request);
			if (validation.IsValid)
			{
				await _homePageService.AddHomePageAsync(request);
				return RedirectToAction("GetHomePageList", "HomePage", new { Area = ("Admin") });
			}

			validation.AddToModelState(this.ModelState);

			return View(request);

		}

		[HttpGet]
		public async Task<IActionResult> UpdateHomePage(int id)
		{
			var homePage = await _homePageService.GetHomePageById(id);

			return View(homePage);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateHomePage(HomePageUpdateVM request)
		{
			var validation = await _updateValidator.ValidateAsync(request);
			if (validation.IsValid)
			{
				await _homePageService.UpdateHomePageAsync(request);
				return RedirectToAction("GetHomePageList", "HomePage", new { Area = ("Admin") });
			}

			validation.AddToModelState(this.ModelState);
			return View(request);
		}


		public async Task<IActionResult> DeleteHomePage(int id)
		{
			await _homePageService.DeleteHomePageAsync(id);
			return RedirectToAction("GetHomePageList", "HomePage", new { Area = ("Admin") });
		}
	}
}

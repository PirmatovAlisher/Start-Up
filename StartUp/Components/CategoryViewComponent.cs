﻿using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace StartUp.Components
{
	public class CategoryViewComponent : ViewComponent
	{
		private readonly ICategoryService _categoryService;

		public CategoryViewComponent(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var clategoryList= await _categoryService.GetAllListForUIAsync();

			return View(clategoryList);
		}
	}
}

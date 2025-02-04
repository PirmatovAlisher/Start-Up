﻿using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ServiceVM;
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
	public class ServiceController : Controller
	{
		private readonly IServiceService _serviceService;
		private readonly IValidator<ServiceAddVM> _addValidator;
		private readonly IValidator<ServiceUpdateVM> _updateValidator;

		public ServiceController(IServiceService serviceService,
			IValidator<ServiceAddVM> addValidator, IValidator<ServiceUpdateVM> updateValidator)
		{
			_serviceService = serviceService;
			_addValidator = addValidator;
			_updateValidator = updateValidator;
		}

		public async Task<IActionResult> GetServiceList()
		{
			var serviceList = await _serviceService.GetAllListAsync();

			return View(serviceList);
		}


		[HttpGet]
		public IActionResult AddService()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> AddService(ServiceAddVM request)
		{
			var validator = await _addValidator.ValidateAsync(request);
			if (validator.IsValid)
			{
				await _serviceService.AddServiceAsync(request);
				return RedirectToAction("GetServiceList", "Service", new { Area = ("Admin") });
			}

			validator.AddToModelState(this.ModelState);

			return View(request);

		}

		[ServiceFilter(typeof(GenericNotFoundFilter<Service>))]
		[HttpGet]
		public async Task<IActionResult> UpdateService(int id)
		{
			var service = await _serviceService.GetServiceById(id);

			return View(service);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateService(ServiceUpdateVM request)
		{
			var validator = await _updateValidator.ValidateAsync(request);
			if (validator.IsValid)
			{
				await _serviceService.UpdateServiceAsync(request);
				return RedirectToAction("GetServiceList", "Service", new { Area = ("Admin") });
			}

			validator.AddToModelState(this.ModelState);

			return View(request);

		}

		[Authorize(Roles = "SuperAdmin")]
		public async Task<IActionResult> DeleteService(int id)
		{
			await _serviceService.DeleteServiceAsync(id);
			return RedirectToAction("GetServiceList", "Service", new { Area = ("Admin") });
		}
	}
}

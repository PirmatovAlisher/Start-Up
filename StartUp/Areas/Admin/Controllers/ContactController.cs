using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ContactVM;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Filter.WebApplication;
using ServiceLayer.Services.WebApplication.Abstract;

namespace StartUp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;
		private readonly IValidator<ContactAddVM> _addValidator;
		private readonly IValidator<ContactUpdateVM> _updateValidator;

		public ContactController(IContactService contactService,
			IValidator<ContactUpdateVM> updateValidator, IValidator<ContactAddVM> addValidator)
		{
			_contactService = contactService;
			_updateValidator = updateValidator;
			_addValidator = addValidator;
		}

		public async Task<IActionResult> GetContactList()
		{
			var contactList = await _contactService.GetAllListAsync();

			return View(contactList);
		}

		[ServiceFilter(typeof(GenericAddPreventationFilter<Contact>))]
		[HttpGet]
		public IActionResult AddContact()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> AddContact(ContactAddVM request)
		{
			var validation = await _addValidator.ValidateAsync(request);
			if (validation.IsValid)
			{
				await _contactService.AddContactAsync(request);
				return RedirectToAction("GetContactList", "Contact", new { Area = ("Admin") });
			}

			validation.AddToModelState(this.ModelState);

			return View(request);
		}

		[HttpGet]
		public async Task<IActionResult> UpdateContact(int id)
		{
			var contact = await _contactService.GetContactById(id);

			return View(contact);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateContact(ContactUpdateVM request)
		{
			var validation = await _updateValidator.ValidateAsync(request);
			if (validation.IsValid)
			{
				await _contactService.UpdateContactAsync(request);
				return RedirectToAction("GetContactList", "Contact", new { Area = ("Admin") });
			}

			validation.AddToModelState(this.ModelState);

			return View(request);

		}


		public async Task<IActionResult> DeleteContact(int id)
		{
			await _contactService.DeleteContactAsync(id);
			return RedirectToAction("GetContactList", "Contact", new { Area = ("Admin") });
		}
	}
}

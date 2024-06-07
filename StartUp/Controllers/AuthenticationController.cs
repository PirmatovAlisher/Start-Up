using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Helpers.Identity;

namespace StartUp.Controllers
{
	public class AuthenticationController : Controller
	{

		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;
		private readonly IValidator<SignUpVM> _signUpValidator;

		public AuthenticationController(UserManager<AppUser> userManager, IValidator<SignUpVM> signUpValidator, IMapper mapper)
		{
			_userManager = userManager;
			_signUpValidator = signUpValidator;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpVM request)
		{

			var validation = await _signUpValidator.ValidateAsync(request);

			if (!validation.IsValid)
			{
				validation.AddToModelState(this.ModelState);
				return View(request);
			}

			var user = _mapper.Map<AppUser>(request);

			var userCreateResult = await _userManager.CreateAsync(user, request.Password);
			if (!userCreateResult.Succeeded)
			{
				ModelState.AddModelErrorList(userCreateResult.Errors);
				return View(request);
			}

			return RedirectToAction("Login", "Authentication");
		}
	}
}

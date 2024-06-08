using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ServiceLayer.Helpers.Identity;

namespace StartUp.Controllers
{
	public class AuthenticationController : Controller
	{

		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IMapper _mapper;
		private readonly IValidator<SignUpVM> _signUpValidator;
		private readonly IValidator<LogInVM> _logInValidator;

		public AuthenticationController(UserManager<AppUser> userManager,
										IValidator<SignUpVM> signUpValidator,
										IMapper mapper,
										SignInManager<AppUser> signInManager,
										IValidator<LogInVM> logInValidator)
		{
			_userManager = userManager;
			_signUpValidator = signUpValidator;
			_mapper = mapper;
			_signInManager = signInManager;
			_logInValidator = logInValidator;
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
				ViewBag.Result = "Not Succeed";
				ModelState.AddModelErrorList(userCreateResult.Errors);
				return View(request);
			}

			return RedirectToAction("Login", "Authentication");
		}

		[HttpGet]
		public IActionResult LogIn()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> LogIn(LogInVM request, string? returnUrl = null)
		{
			returnUrl = returnUrl ?? Url.Action("Index", "Dashboard", new { Area = "Admin" });

			var validator = await _logInValidator.ValidateAsync(request);
			if (!validator.IsValid)
			{
				ViewBag.Result = "Failed";
				validator.AddToModelState(this.ModelState);
				return View(request);
			}

			var hasUser = await _userManager.FindByEmailAsync(request.Email);
			if (hasUser == null)
			{
				ViewBag.Result = "Failed";
				ModelState.AddModelErrorList(new List<string> { "Email or Password is incorrect" });
				return View(request);
			}

			var logInResult = await _signInManager.PasswordSignInAsync(hasUser, request.Password, request.RememberMe, true);

			if (logInResult.Succeeded)
			{
				return Redirect(returnUrl!);
			}

			if (logInResult.IsLockedOut)
			{
				ViewBag.Result = "Locked Out";
				ModelState.AddModelErrorList(new List<string> { "Your account is locked out for 60 seconds" });
			}

			ViewBag.Result = "Failed Attempt";
			ModelState.AddModelErrorList(new List<string> { $"Email or Password is wrong! Failed attempt " +
				$"{await _userManager.GetAccessFailedCountAsync(hasUser)}" });

			return View(request);
		}
	}
}

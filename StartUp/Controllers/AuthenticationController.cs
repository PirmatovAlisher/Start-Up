using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using ServiceLayer.Helpers.Identity.EmailHelper;
using ServiceLayer.Helpers.Identity.ModelStateHelper;
using ServiceLayer.Services.Identity.Abstract;

namespace StartUp.Controllers
{
	public class AuthenticationController : Controller
	{

		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IMapper _mapper;
		private readonly IValidator<SignUpVM> _signUpValidator;
		private readonly IValidator<LogInVM> _logInValidator;
		private readonly IValidator<ForgotPasswordVM> _forgotPasswordValidator;
		private readonly IValidator<ResetPasswordVM> _resetPasswordValidator;
		private readonly IEmailSendMethod _emailSendMethod;
		private readonly IAuthenticationCustomService _authenticationService;


		public AuthenticationController(UserManager<AppUser> userManager,
										IValidator<SignUpVM> signUpValidator,
										IMapper mapper,
										SignInManager<AppUser> signInManager,
										IValidator<LogInVM> logInValidator,
										IValidator<ForgotPasswordVM> forgotPasswordValidator,
										IEmailSendMethod emailSendMethod,
										IValidator<ResetPasswordVM> resetPasswordValidator,
										IAuthenticationCustomService authenticationService)
		{
			_userManager = userManager;
			_signUpValidator = signUpValidator;
			_mapper = mapper;
			_signInManager = signInManager;
			_logInValidator = logInValidator;
			_forgotPasswordValidator = forgotPasswordValidator;
			_emailSendMethod = emailSendMethod;
			_resetPasswordValidator = resetPasswordValidator;
			_authenticationService = authenticationService;
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

		[HttpGet]
		public IActionResult ForgotPassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ForgotPassword(ForgotPasswordVM request)
		{
			var validation = await _forgotPasswordValidator.ValidateAsync(request);
			if (!validation.IsValid)
			{
				validation.AddToModelState(this.ModelState);
				return View(request);
			}

			var hasUser = await _userManager.FindByEmailAsync(request.Email);
			if (hasUser == null)
			{
				ViewBag.Result = "Failed";
				ModelState.AddModelErrorList(new List<string> { "User does not exist" });
				return View(request);
			}

			await _authenticationService.CreateResetCredentialsAndSend(hasUser, HttpContext, Url, request);
			//string resetToken = await _userManager.GeneratePasswordResetTokenAsync(hasUser);
			//var passwordResetLink = Url.Action("ResetPassword", "Authentication",
			//						new { userId = hasUser.Id, Token = resetToken }, HttpContext.Request.Scheme);

			//await _emailSendMethod.SendResetPasswordLinkWithToken(request.Email, passwordResetLink!);

			return RedirectToAction("LogIn", "Authentication");
		}



		[HttpGet]
		public IActionResult ResetPassword(string userId, string token, List<string> errors)
		{
			TempData["UserId"] = userId;
			TempData["Token"] = token;

			if (errors.Any())
			{
				ViewBag.Result = "Error";
				ModelState.AddModelErrorList(errors);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordVM request)
		{
			var userId = TempData["UserId"];
			var token = TempData["Token"];

			if (userId == null || token == null)
			{
				return RedirectToAction("LogIn", "Authentication");
			}

			var validation = await _resetPasswordValidator.ValidateAsync(request);

			if (!validation.IsValid)
			{

				List<string> errors = validation.Errors.Select(x => x.ErrorMessage).ToList();
				return RedirectToAction("ResetPassword", "Authentication", new { userId, token, errors });
			}

			var hasUser = await _userManager.FindByIdAsync(userId.ToString()!);

			if (hasUser == null)
			{
				return RedirectToAction("LogIn", "Authentication");
			}

			var resetPasswordResult = await _userManager.ResetPasswordAsync(hasUser, token.ToString()!, request.Password);

			if (resetPasswordResult.Succeeded)
			{
				return RedirectToAction("LogIn", "Authentication");
			}
			else
			{
				List<string> errors = resetPasswordResult.Errors.Select(x => x.Description).ToList();
				return RedirectToAction("ResetPassword", "Authentication", new { userId, token, errors });
			}



		}

		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}

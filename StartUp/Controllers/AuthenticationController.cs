using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ServiceLayer.Helpers.Identity.EmailHelper;
using ServiceLayer.Helpers.Identity.ModelStateHelper;
using ServiceLayer.Messages.Identity;
using ServiceLayer.Services.Identity.Abstract;
using System.Security.Claims;

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
		private readonly IAuthenticationMainService _authenticationService;
		private readonly IToastNotification _toasty;


		public AuthenticationController(UserManager<AppUser> userManager,
										IValidator<SignUpVM> signUpValidator,
										IMapper mapper,
										SignInManager<AppUser> signInManager,
										IValidator<LogInVM> logInValidator,
										IValidator<ForgotPasswordVM> forgotPasswordValidator,
										IEmailSendMethod emailSendMethod,
										IValidator<ResetPasswordVM> resetPasswordValidator,
										IAuthenticationMainService authenticationService,
										IToastNotification toasty)
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
			_toasty = toasty;
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

			var assignRoleResult = await _userManager.AddToRoleAsync(user, "Member");
			if (!assignRoleResult.Succeeded)
			{
				await _userManager.DeleteAsync(user);
				ViewBag.Result = "Not Succeed";
				ModelState.AddModelErrorList(assignRoleResult.Errors);
				return View();
			}

			var defaultClaim = new Claim("AdminObserverExpireDate", DateTime.Now.AddDays(-6).ToString());
			var addClaimResult = await _userManager.AddClaimAsync(user, defaultClaim);
			if (!addClaimResult.Succeeded)
			{
				await _userManager.RemoveFromRoleAsync(user, "Member");
				await _userManager.DeleteAsync(user);
				ViewBag.Result = "Not Succeed";
				ModelState.AddModelErrorList(addClaimResult.Errors);
				return View();
			}

			_toasty.AddSuccessToastMessage(NotificationMessagesIdentity.SignUp(user.UserName!),
				new ToastrOptions { Title = NotificationMessagesIdentity.SucceededTitle });
			return RedirectToAction("Login", "Authentication");
		}

		[HttpGet]
		public IActionResult LogIn(string? errorMessage)
		{
			if (errorMessage != null)
			{
				ViewBag.Result = "Failed";
				ModelState.AddModelErrorList(new List<string> { errorMessage });
				return View();
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> LogIn(LogInVM request, string? returnUrl = null)
		{
			returnUrl = returnUrl ?? Url.Action("Index", "Dashboard", new { Area = "User" });

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
				_toasty.AddSuccessToastMessage(NotificationMessagesIdentity.LogInSuccess,
					new ToastrOptions { Title = NotificationMessagesIdentity.SucceededTitle });
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

			_toasty.AddSuccessToastMessage(NotificationMessagesIdentity.ResetPasswordSuccess,
				new ToastrOptions { Title = NotificationMessagesIdentity.SucceededTitle });
			await _authenticationService.CreateResetCredentialsAndSend(hasUser, HttpContext, Url, request);

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
				_toasty.AddErrorToastMessage(NotificationMessagesIdentity.TokenValidationError,
					new ToastrOptions { Title = NotificationMessagesIdentity.FailedTitle });
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
				_toasty.AddErrorToastMessage(NotificationMessagesIdentity.UserNotFound(hasUser.UserName!),
					new ToastrOptions { Title = "I am Sorry!" });
				return RedirectToAction("LogIn", "Authentication");
			}

			var resetPasswordResult = await _userManager.ResetPasswordAsync(hasUser, token.ToString()!, request.Password);

			if (resetPasswordResult.Succeeded)
			{
				_toasty.AddSuccessToastMessage(NotificationMessagesIdentity.PasswordChangeSuccess,
				new ToastrOptions { Title = NotificationMessagesIdentity.SucceededTitle });
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

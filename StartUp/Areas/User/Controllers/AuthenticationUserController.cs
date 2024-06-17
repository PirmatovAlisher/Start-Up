using AutoMapper;
using CoreLayer.Enumerators;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Helpers.Generic.Image;
using ServiceLayer.Helpers.Identity.ModelStateHelper;

namespace StartUp.Areas.User.Controllers
{
	[Authorize]
	[Area("User")]
	public class AuthenticationUserController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IMapper _mapper;
		private readonly IValidator<UserEditVM> _userEditValidator;
		private readonly IImageHelper _imageHelper;

		public AuthenticationUserController(UserManager<AppUser> userManager, IMapper mapper, IValidator<UserEditVM> userEditValidator, SignInManager<AppUser> signInManager, IImageHelper imageHelper)
		{
			_userManager = userManager;
			_mapper = mapper;
			_userEditValidator = userEditValidator;
			_signInManager = signInManager;
			_imageHelper = imageHelper;
		}


		[HttpGet]
		public async Task<IActionResult> UserEdit()
		{
			var user = await _userManager.FindByNameAsync(User.Identity!.Name!);

			var userEditVM = _mapper.Map<UserEditVM>(user);

			return View(userEditVM);
		}

		[HttpPost]
		public async Task<IActionResult> UserEdit(UserEditVM request)
		{
			var user = await _userManager.FindByNameAsync(User.Identity!.Name!);

			var validation = await _userEditValidator.ValidateAsync(request);

			if (!validation.IsValid)
			{
				validation.AddToModelState(this.ModelState);
				return View();
			}

			var passwordCheck = await _userManager.CheckPasswordAsync(user!, request.Password);
			if (!passwordCheck)
			{
				ViewBag.Result = "Failed Password";
				ModelState.AddModelErrorList(new List<string> { "Wrong Password" });
				return Redirect(nameof(UserEdit));
			}

			if (request.NewPassword != null)
			{
				var passwordChange = await _userManager.ChangePasswordAsync(user!, request.Password, request.NewPassword);
				if (!passwordChange.Succeeded)
				{
					ViewBag.Result = "New Password Failed";
					ModelState.AddModelErrorList(passwordChange.Errors.ToList());
					return Redirect(nameof(UserEdit));
				}
			}

			var oldFileName = user!.FileName;
			var oldFileType = user!.FileType;

			if (request.Photo != null)
			{
				var image = await _imageHelper.ImageUpload(request.Photo, ImageType.identity, null);
				if (image.Error != null)
				{
					if (request.NewPassword != null)
					{
						await _userManager.ChangePasswordAsync(user!, request.NewPassword, request.Password);
						await _userManager.UpdateSecurityStampAsync(user);
						await _signInManager.SignOutAsync();
						await _signInManager.SignInAsync(user, false);
					}

					return Redirect(nameof(UserEdit));
				}

				request.FileName = image.FileName;
				request.FileType = request.Photo.ContentType;
			}
			else
			{
				request.FileName = oldFileName;
				request.FileType = oldFileType;
			}

			var mappedUser = _mapper.Map(request, user);
			var userUpdate = await _userManager.UpdateAsync(mappedUser);

			if (userUpdate.Succeeded)
			{
				if (request.Photo != null)
				{
					if (oldFileName != null)
					{
						_imageHelper.DeleteImage(oldFileName);
					}
				}

				await _userManager.UpdateSecurityStampAsync(user);
				await _signInManager.SignOutAsync();
				await _signInManager.SignInAsync(user, false);
				return RedirectToAction("Index", "Dashboard", new { Area = "User" });
			}

			if (request.FileName != null)
			{
				_imageHelper.DeleteImage(request.FileName);
			}

			if (request.NewPassword != null)
			{
				await _userManager.ChangePasswordAsync(user!, request.NewPassword, request.Password);
				await _userManager.UpdateSecurityStampAsync(user);
				await _signInManager.SignOutAsync();
				await _signInManager.SignInAsync(user, false);
			}

			ViewBag.UserName = user.UserName;
			//ViewBag.Id = user.Id;

			return Redirect(nameof(UserEdit));
		}
	}
}

using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ServiceLayer.Services.Identity.Concrete
{
	public interface IAuthenticationUserService
	{
		Task<UserEditVM> FindUserAsync(HttpContext httpContext);
		Task<IdentityResult> UserEditAsync(UserEditVM request, AppUser user);
	}
}
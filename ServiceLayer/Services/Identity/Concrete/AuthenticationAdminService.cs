using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ServiceLayer.Messages.Identity;
using ServiceLayer.Services.Identity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Identity.Concrete
{
	public class AuthenticationAdminService : IAuthenticationAdminService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;

		public AuthenticationAdminService(UserManager<AppUser> userManager, IMapper mapper)
		{
			_userManager = userManager;
			_mapper = mapper;
		}

		public async Task<List<UserVM>> GetUserListAsync()
		{
			var userList = await _userManager.Users.ToListAsync();
			var userListVM = _mapper.Map<List<UserVM>>(userList);

			for (int i = 0; i < userList.Count; i++)
			{
				var userRoles = await _userManager.GetRolesAsync(userList[i]);
				userListVM[i].UserRoles = userRoles;

				var userClaims = await _userManager.GetClaimsAsync(userList[i]);
				userListVM[i].UserClaims = userClaims;
			}

			return userListVM;
		}

		public async Task<IdentityResult> ExtendClaimAsync(string userName)
		{
			var user = await _userManager.FindByNameAsync(userName);
			var claims = await _userManager.GetClaimsAsync(user!);
			var existingClaim = claims.FirstOrDefault(x => x.Type.Contains("Observer"));
			var newExtendedClaim = new Claim("AdminObserverExpireDate", DateTime.Now.AddDays(5).ToString());

			return await _userManager.ReplaceClaimAsync(user!, existingClaim!, newExtendedClaim);
		}

	}
}

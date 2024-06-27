using EntityLayer.Identity.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ServiceLayer.Services.Identity.Abstract
{
    public interface IAuthenticationAdminService
    {
        Task<IdentityResult> ExtendClaimAsync(string userName);
        Task<List<UserVM>> GetUserListAsync();
    }
}
using System.Security.Claims;
using Data.Entity;


namespace Shared.Interfaces.Services
{
    public interface IUserService 
    {
        ApplicationUser CreateNewInstance();

        string GetUserClaim(string claimType, ClaimsPrincipal user);

        string GetCurrentUserId(ClaimsPrincipal user);

        Task<ApplicationUser> GetTobiKareemUserAsync();
    }
}

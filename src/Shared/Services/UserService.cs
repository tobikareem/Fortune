using System.Security.Claims;
using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Shared.Interfaces.Repository;
using Shared.Interfaces.Services;

namespace Shared.Services
{
    public class UserService : IUserService
    {
        private readonly IStringIdStore<IdentityUser> userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(IStringIdStore<IdentityUser> userRepository, UserManager<ApplicationUser> userManager)
        {
            this.userRepository = userRepository;
            _userManager = userManager;
        }


        ApplicationUser IUserService.CreateNewInstance()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        public string GetUserClaim(string claimType, ClaimsPrincipal user)
        {
            // get user claims
            var userClaim = user.FindFirstValue(claimType);

            return userClaim ?? string.Empty;
        }

        public string GetCurrentUserId(ClaimsPrincipal user)
        {
            var userId = _userManager.GetUserId(user);
            return userId;
        }
    }
}

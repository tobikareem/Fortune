using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Shared.Interfaces.Repository;
using Shared.Interfaces.Services;

namespace Shared.Services
{
    public class UserService : IUserService
    {
        private readonly IStringIdStore<IdentityUser> userRepository;
        public UserService(IStringIdStore<IdentityUser> userRepository)
        {
            this.userRepository = userRepository;
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
    }
}

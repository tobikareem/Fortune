using Microsoft.AspNetCore.Authorization;
using Data.Entity;
using Microsoft.AspNetCore.Identity;

namespace Web.Customs.Authorization
{
    /// <summary>
    /// Resource based authorization
    /// </summary>
    public class IsPostOwnerRequirement : IAuthorizationRequirement
    {
    }

    public class IsPostOwnerRequirementHandler : AuthorizationHandler<IsPostOwnerRequirement, Post>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IsPostOwnerRequirementHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsPostOwnerRequirement requirement, Post resource)
        {

            var appUser = await _userManager.GetUserAsync(context.User);

            if(appUser is null)
            {
                return;
            }

            if(resource.CreatedBy == appUser.Id)
            {
                context.Succeed(requirement);

            }
        }
    }
}

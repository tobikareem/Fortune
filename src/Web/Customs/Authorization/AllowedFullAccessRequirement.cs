using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Core.Constants;

namespace Web.Customs.Authorization
{
    /// <summary>
    /// Role based authorization.
    /// </summary>
    public class AllowedFullAccessRequirement : IAuthorizationRequirement
    {
    }

    public class FullAccessHandler : AuthorizationHandler<AllowedFullAccessRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AllowedFullAccessRequirement requirement)
        {
            var userContext = context.User;
            var writeClaim = userContext.HasClaim(ClaimTypes.Role, ResourceAction.CanWritePost);
            var editClaim = userContext.HasClaim(ClaimTypes.Role, ResourceAction.CanEditPost);
            var tobClaim = userContext.HasClaim(ClaimTypes.Role, ResourceAction.FortuneAdmin);

            if (writeClaim || editClaim || tobClaim)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

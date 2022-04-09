using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;


namespace Shared.Interfaces.Services
{
    public interface IUserService 
    {
        ApplicationUser CreateNewInstance();

        string GetUserClaim(string claimType, ClaimsPrincipal user);


        string GetCurrentUserId(ClaimsPrincipal user);
    }
}

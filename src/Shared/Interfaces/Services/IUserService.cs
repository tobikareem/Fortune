using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;


namespace Shared.Interfaces.Services
{
    public interface IUserService 
    {
        ApplicationUser CreateNewInstance();
    }
}

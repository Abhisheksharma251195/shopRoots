using Microsoft.Extensions.Configuration;
using shopRootsAdmin.core.dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shopRootsAdmin.core.interfaces
{
   public interface ILogInService
    {
        public  Task<UserProfileDto> LogIn(LogInDto userModel, IConfiguration Configuration);
    }
}

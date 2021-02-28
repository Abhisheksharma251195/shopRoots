using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shopRootsAdmin.core.interfaces
{
   public interface IAuthentication
    {
        public Task<string> authenticateUser(string userName , IConfiguration Configuration);
    }
}

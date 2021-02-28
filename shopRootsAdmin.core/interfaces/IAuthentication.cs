using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using shopRootsAdmin.core.models;

namespace shopRootsAdmin.core.interfaces
{
   public interface IAuthentication
    {
        public Task<string> authenticateUser(string userName , IConfiguration Configuration);
        public JwtSecurityToken GenerateJSONWebToken(userModel User, IConfiguration Configuration);
        public Task createToken(AuthModel model);
    }
}

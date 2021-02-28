
using Microsoft.IdentityModel.Tokens;
using shopRootsAdmin.core.interfaces;
using shopRootsAdmin.core.models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Collections.Generic;

namespace shopRoots.infrastructure.services
{
    public class AuthenticationService : IAuthentication
    {

        private readonly IRepository<AuthModel> _authSvc;
        private readonly IRepository<userModel> _userSvc;

        public AuthenticationService(IRepository<AuthModel> authSvc, IRepository<userModel> userSvc) {
            _authSvc = authSvc;
            _userSvc = userSvc;
        }
        public async Task<string> authenticateUser(string userName , IConfiguration Configuration)
        {
            var user = _userSvc.GetOne(x => x.Phone.Equals(userName.Trim()) || x.Email.ToLower() == userName.ToLower().Trim());
            var token = "";
            if (user != null)
            {
                AuthModel authModel = new AuthModel();
                var newToken = GenerateJSONWebToken(user, Configuration);
                authModel.token = token = new JwtSecurityTokenHandler().WriteToken(newToken);
                authModel.ExpireOn = DateTime.Now.AddMinutes(Convert.ToInt32(Configuration["Jwt:expireTime"]));
                authModel.userId = user.UserId;
                await _authSvc.Create(authModel);
            }
            else {
                throw new Exception(userName + " User Not Found please check your user");
            }
            return token;
        }

        private JwtSecurityToken GenerateJSONWebToken(userModel User , IConfiguration Configuration)
        {
            var securityKeyString = Configuration["Jwt:key"];
            var issure = Configuration["Jwt:Issuer"];
            var expires = Convert.ToInt32(Configuration["Jwt:expireTime"]);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKeyString));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //var claims = new List<Claim>()
            //{
            //    new Claim {Type ="" , Value  = User.UserId}
            //}
            var token = new JwtSecurityToken(issure,
              issure,
              null,
              expires: DateTime.Now.AddMinutes(expires),
              signingCredentials: credentials
             );
            return token;
        }
    }

}

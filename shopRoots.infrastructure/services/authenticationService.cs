
using Microsoft.IdentityModel.Tokens;
using shopRootsAdmin.core.interfaces;
using shopRootsAdmin.core.models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
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
            var user = _userSvc.GetOne(x => (x.Phone.Equals(userName.Trim()) || x.Email.ToLower() == userName.ToLower().Trim()));

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
        public JwtSecurityToken GenerateJSONWebToken(userModel User, IConfiguration Configuration)
        {
            var securityKeyString = Configuration["Jwt:key"];
            var issure = Configuration["Jwt:Issuer"];
            var expires = Convert.ToInt32(Configuration["Jwt:expireTime"]);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKeyString));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new Claim("ActorId" , User.UserId),
                new Claim("Email" , User.Email),
                new Claim("userName" , User.Name),
                new Claim("phoneNo" , User.Phone),
            };

            var token = new JwtSecurityToken(issure,
              issure,
              claims,
              expires: DateTime.Now.AddMinutes(expires),
              signingCredentials: credentials
             );
            return token;
        }
        public async Task createToken(AuthModel model) {
           await _authSvc.Create(model);
        }
    }
}


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
using shopRootsAdmin.core.dtos;

namespace shopRoots.infrastructure.services
{
    public class LogInService : ILogInService
    {

        private readonly IRepository<userModel> _userSvc;
        private readonly IAuthentication _AuthSvc;
        private readonly Ilogger _loggerSvc;

        public LogInService(IAuthentication authSvc, IRepository<userModel> userSvc , Ilogger logger) {
            _AuthSvc = authSvc;
            _userSvc = userSvc;
            _loggerSvc = logger;
        }
        public async Task<UserProfileDto> LogIn(LogInDto userModel, IConfiguration Configuration)
        {

            UserProfileDto userProfile = new UserProfileDto();
            var user = _userSvc.GetOne(x => (x.Phone.Equals(userModel.UserName.Trim())
            || x.Email.ToLower() == userModel.UserName.ToLower().Trim()) && userModel.password == Encoding.Default.GetString(x.UserPassword));
            if (user != null)
            {
                AuthModel authModel = new AuthModel();
                var newToken = _AuthSvc.GenerateJSONWebToken(user , Configuration);
                userProfile.token= authModel.token = new JwtSecurityTokenHandler().WriteToken(newToken);
                userProfile.userId=authModel.userId = user.UserId;
                userProfile.userName = user.Name;
                userProfile.userEmail = user.Email;
                authModel.ExpireOn = DateTime.Now.AddMinutes(Convert.ToInt32(Configuration["Jwt:expireTime"]));
                await _AuthSvc.createToken(authModel);
            }
            else {
                throw new Exception(" UserName or Password is incorrect please try again");
            }
            return userProfile;
        }
    }

}

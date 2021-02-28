using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopRootsAdmin.core.dtos;
using shopRootsAdmin.core.interfaces;
using Microsoft.Extensions.Configuration;

namespace shopRootsAdmin.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly ILogInService _LogInSvc;
        private readonly IConfiguration _configuration;
        private readonly Ilogger _loggerSvc;
        public LogInController(ILogInService LogInSvc , IConfiguration configuration, Ilogger logger) {
            _LogInSvc = LogInSvc;
            _configuration = configuration;
            _loggerSvc = logger;
        }
        [HttpPost("LogIn")]
        public async Task<UserProfileDto> Login(LogInDto User)
        {
            var result = new UserProfileDto();
            try
            { 
                result = await _LogInSvc.LogIn(User , _configuration);
                await _loggerSvc.Log(result.userEmail + ":- user Logged In SuccessFully");
            }
            catch (Exception ex)
            {
                await _loggerSvc.Log(ex.Message);
                throw ex;
            }
            return result;
        }
    }
}

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
using System.Net;

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
        [ProducesResponseType(typeof(UserProfileDto) , (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Login(LogInDto User)
        {
            var result = new UserProfileDto();
            try
            { 
                result = await _LogInSvc.LogIn(User , _configuration);
                await Task.Run (() => _loggerSvc.Log("user Logged In SuccessFully : - " + result.userEmail));
                return Ok(result);   
            }
            catch (Exception ex)
            {
               await Task.Run(() => _loggerSvc.Log(ex.Message));
               return BadRequest(ex.Message);
            }
        }
    }
}

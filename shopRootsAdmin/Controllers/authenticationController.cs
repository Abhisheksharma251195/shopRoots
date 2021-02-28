using Microsoft.AspNetCore.Mvc;
using shopRootsAdmin.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shopRootsAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class authenticationController : ControllerBase
    {
        private readonly IAuthentication _authSvc;
        private readonly IConfiguration _configuration;
        private readonly Ilogger _loggerSvc;
        public authenticationController(IAuthentication authSvc , IConfiguration configuration , Ilogger logger)
        {
            _authSvc = authSvc;
            _configuration = configuration;
            _loggerSvc = logger;
        }
        // GET: api/<authenticationController>
        [HttpGet("authticateUser")]
        public async Task<string> Get(string userId)
        {
            try
            {
                await _loggerSvc.Log("Creating Auth Token ");
                var result = await _authSvc.authenticateUser(userId, _configuration);
                await _loggerSvc.Log("Auth Token created SuccessFully"); 
                return  await _authSvc.authenticateUser(userId , _configuration);
            }
            catch (Exception ex)
            {
                await _loggerSvc.Log("Trying To create genrate Auth token : " + ex.Message);
                throw ex;
            }
        }
    }
}

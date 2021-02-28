using Microsoft.AspNetCore.Mvc;
using shopRootsAdmin.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shopRootsAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authenticationController : ControllerBase
    {
        private readonly IAuthentication _authSvc;
        private readonly IConfiguration _configuration;

        public authenticationController(IAuthentication authSvc , IConfiguration configuration)
        {
            _authSvc = authSvc;
            _configuration = configuration;
        }
        // GET: api/<authenticationController>
        [HttpGet("authticateUser")]
        public async Task<string> Get(string userId)
        {
            try
            {
                return  await _authSvc.authenticateUser(userId , _configuration);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

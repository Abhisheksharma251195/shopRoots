using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shopRootsAdmin.core.interfaces;
using shopRootsAdmin.core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopRootsAdmin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUserService _userSvc;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserService userSvc)
        {
            _logger = logger;
            _userSvc = userSvc;
        }

        [HttpGet]
        public async Task<List<userModel>> GetAsync()
        {
            var res = new List<userModel>();
            try
            {
                res = (List<userModel>)await _userSvc.getAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }

        //[HttpGet]
        //public List<userModel> GetAllUser()
        //{

        //    var res = new List<userModel>();
        //    try
        //    {
        //       res = (List<userModel>)_userSvc.getAll();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    return res;
        //}
    }
}

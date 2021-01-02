using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shopRootsAdmin.core.dtos;
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
        private readonly IMapper _mapper;
        private readonly IRepository<userModel> _repo;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserService userSvc , IMapper mapper , IRepository<userModel> repo)
        {
            _logger = logger;
            _userSvc = userSvc;
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("getAllUsers")]
        public async Task<List<userDto>> getAll()
        {
            var res = new List<userDto>();
            try
            {
                var result = await _repo.GetAll( x=> x.Id==0);
                res = _mapper.Map<List<userDto>>(result);
            }
                 catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }
        [HttpPost("CreateUser")]
        public async Task<userDto> CreateUser(userDto User)
        {
            var res = new userDto();
            try
            {
              var model = _mapper.Map<userModel>(User);
              var result = await _repo.Create(model);
              res =  _mapper.Map<userDto>(result);  
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        [HttpPost("UpdateUser")]
        public async Task<userDto> UpdateUser(userModel User)
        {
            var res = new userDto();
            try
            {
                var model = _mapper.Map<userModel>(User);
                var result = await _repo.Update(model);
                res = _mapper.Map<userDto>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        [HttpPost("DeleteUser")]
        public async Task<bool> DeleteUser(int id)
        {
            var res = false; 
            try
            {
                res = await _repo.Delete(id);
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

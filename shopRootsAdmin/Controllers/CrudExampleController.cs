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
    public class LoginController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;
        private readonly IUserService _userSvc;
        private readonly IMapper _mapper;
        private readonly IRepository<userModel> _userRepo;
        private readonly IRepository<AddressModel> _Addressrepo;

        public LoginController(ILogger<LoginController> logger, IUserService userSvc , IMapper mapper , IRepository<userModel> repo , IRepository<AddressModel> addressRepo)
        {
            _logger = logger;
            _userSvc = userSvc;
            _mapper = mapper;
            _userRepo = repo;
            _Addressrepo = addressRepo;
        }

        [HttpGet("getAllUsers")]
        public async Task<List<userDto>> getAll()
        {
            var res = new List<userDto>();
            try
            {
                var result = await _userRepo.GetAll(x => x.Deleted == 0);
                res = _mapper.Map<List<userDto>>(result);
            }
                 catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }


        [HttpGet("getUserById")]
        public async Task<userDto> getUserById(int id)
        {
            var res = new userDto();
            try
            {
                var result = await _userRepo.GetOne(x => x.Id == id);
                res = _mapper.Map<userDto>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }


        [HttpGet("getAllAddress")]
        public async Task<List<AddressDto>> getAllAddresses()
        {
            var res = new List<AddressDto>();
            try
            {
                var result = await _Addressrepo.GetAll(x => x.Deleted == 0);
                res = _mapper.Map<List<AddressDto>>(result);
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
              var result = await _userRepo.Create(model);
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
                var result = await _userRepo.Update(model);
                res = _mapper.Map<userDto>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        [HttpDelete("DeleteUser")]
        public async Task<bool> DeleteUser(int id)
        {
            var res = false; 
            try
            {
                res = await _userRepo.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

    }
}

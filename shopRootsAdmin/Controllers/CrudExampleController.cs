using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/[controller]")]
    [Authorize]
    public class CrudController : ControllerBase
    {

        private readonly ILogger<CrudController> _logger;
        private readonly IUserService _userSvc;
        private readonly IMapper _mapper;
        private readonly IRepository<userModel> _userRepo;
        private readonly IRepository<AddressModel> _Addressrepo;

        public CrudController(ILogger<CrudController> logger, IUserService userSvc , IMapper mapper , IRepository<userModel> repo , IRepository<AddressModel> addressRepo)
        {
            _logger = logger;
            _userSvc = userSvc;
            _mapper = mapper;
            _userRepo = repo;
            _Addressrepo = addressRepo;
        }

        [HttpGet("getAllUsers")]
        public  List<userDto> getAll()
        {
            var res = new List<userDto>();
            try
            {
                var result =  _userRepo.GetAll().OrderBy(x=> x.CreatedOn) ;
                result = from s in result orderby s.CreatedOn descending select s; 
                res = _mapper.Map<List<userDto>>(result);
            }
            catch (Exception )
            {

                throw ;
            }
            return res;
        }


        [HttpGet("getUserById")]
        public  userDto getUserById(int id)
        {
            var res = new userDto();
            try
            {
                var result =  _userRepo.GetOne(x => x.Id == id);
                res = _mapper.Map<userDto>(result);
            }
            catch (Exception )
            {
                throw;
            }
            return res;
        }


        [HttpGet("getAllAddress")]
        public List<AddressDto> getAllAddresses()
        {
            var res = new List<AddressDto>();
            try
            {
                var result =  _Addressrepo.GetAll(x => x.Deleted == 0);
                res = _mapper.Map<List<AddressDto>>(result);
            }
            catch (Exception )
            {

                throw ;
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
            catch (Exception )
            {
                throw ;
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
            catch (Exception )
            {
                throw ;
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
            catch (Exception)
            {
                throw ;
            }
            return res;
        }

    }
}

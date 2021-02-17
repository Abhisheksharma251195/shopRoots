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
    public class UserController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;
        private readonly IUserService _userSvc;
        private readonly IMapper _mapper;
        private readonly IRepository<userModel> _userRepo;
        private readonly IRepository<AddressModel> _Addressrepo;

        public UserController(ILogger<LoginController> logger, IUserService userSvc , IMapper mapper , IRepository<userModel> repo , IRepository<AddressModel> addressRepo)
        {
            _logger = logger;
            _userSvc = userSvc;
            _mapper = mapper;
            _userRepo = repo;
            _Addressrepo = addressRepo;
        }

        [HttpPost("CreateUser")]
        public async Task<userDto> CreateUser(createUserDto User)
        {
            var res = new userDto();
            try
            {
                var result = await _userSvc.createUser(User);
                res = _mapper.Map<userDto>(result);
            }
            catch (Exception )
            {
                throw ;
            }
            return res;
        }

    }
}

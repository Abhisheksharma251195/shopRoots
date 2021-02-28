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
using System.Security.Claims;
using System.Threading.Tasks;

namespace shopRootsAdmin.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userSvc;
        private readonly IMapper _mapper;
        public UserController(ILogger<LoginController> logger, IUserService userSvc , IMapper mapper , IRepository<userModel> repo , IRepository<AddressModel> addressRepo)
        {
            _userSvc = userSvc;
            _mapper = mapper;
        }

        [HttpPost("CreateUser")]
        public async Task<userDto> CreateUser(createUserDto User)
        {
            var res = new userDto();
            var identity = HttpContext.User.Identity as ClaimsIdentity;
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

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using shopRoots.infrastructure.helpers;
using shopRootsAdmin.core.dtos;
using shopRootsAdmin.core.interfaces;
using shopRootsAdmin.core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopRoots.infrastructure.services
{
    public class userService : IUserService
    {

        private readonly dbHelper _dbContext;
        private readonly IRepository<userModel> _userService;
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;



        public userService(dbHelper context , IRepository<userModel> userService , IAddressService addressService , IMapper mapper) {
            _dbContext = context;
            _userService = userService;
            _addressService = addressService;
            _mapper = mapper;
        }

        public async Task<userModel> createUser(createUserDto userModel)
        {
            userModel User = _mapper.Map<userModel>(userModel);
            Guid guid = Guid.NewGuid();
            User.UserId = guid.ToString();
            //User.UserId = Guid.NewGuid();
            var newUser = await _userService.Create(User);
            return newUser;
        }

        public async Task<userModel> Login()
        {
            throw new NotImplementedException();
        }

        public Task<userModel> UpdateUser(userDto userModel)
        {
            throw new NotImplementedException();
        }

        async Task<IList<userModel>> IUserService.getAll()
        {
               



            //var res = await _dbContext.Users.ToListAsync();
            var result = _dbContext.Users.Where(x => x.Deleted == 0).ToList();

            //_mappper.map<useDto>(result);
            return result;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using shopRoots.infrastructure.helpers;
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

        public userService(dbHelper context) {
            _dbContext = context; 
        }

        public userModel Login()
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

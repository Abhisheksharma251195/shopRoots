using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using shopRootsAdmin.core.dtos;
using shopRootsAdmin.core.models;

namespace shopRootsAdmin.core.interfaces
{
    public interface  IUserService
    {
        public Task <IList<userModel>> getAll();
        public userModel Login();

    }
}

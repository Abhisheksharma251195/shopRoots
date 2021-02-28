using shopRootsAdmin.core.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shopRootsAdmin.core.interfaces
{
    public interface Ilogger
    {
        public  Task<logModel> Log(string message);

    }
}

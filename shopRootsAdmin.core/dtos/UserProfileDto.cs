using System;
using System.Collections.Generic;
using System.Text;

namespace shopRootsAdmin.core.dtos
{
    public class UserProfileDto
    {
        public string token { get; set; }
        public string userId { get; set; }
        public string userName{ get; set; }
        public string userEmail{ get; set; }
        public string mobileNo { get; set; }
    }
}

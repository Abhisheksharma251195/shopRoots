using System;
using System.Collections.Generic;
using System.Text;

namespace shopRootsAdmin.core.dtos
{
   public class userDto :dtoBase
    {
        public userDto() { }
        public  string Name { get; set; }
        public  DateTime DOB { get; set; }
        public  string Email { get; set; }
        public  string Phone { get; set; }
        public List<AddressDto> Addresses { get; set; }
        public virtual int UserType { get; set; }
        public string UserId { get; set; }

    }
}

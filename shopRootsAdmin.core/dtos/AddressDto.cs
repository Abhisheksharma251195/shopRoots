using System;
using System.Collections.Generic;
using System.Text;

namespace shopRootsAdmin.core.dtos
{
   public class AddressDto :dtoBase
    {
        public AddressDto() { }
        public  int AddressId { get; set; }
        public  string AddressLine1 { get; set; }
        public  string City { get; set; }
        public  string District { get; set; }
        public  string State { get; set; }
        public  int PinCode { get; set; }
        public  int UserId { get; set; }
        public  userDto User { get; set; }
    }
}

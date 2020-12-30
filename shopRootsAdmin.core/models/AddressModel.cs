using System;
using System.Collections.Generic;
using System.Text;

namespace shopRootsAdmin.core.models
{
   public class AddressModel : modelBase
    {
        public AddressModel()
        {
                
        }

        public virtual string? AddressLine1 { get; set; }
        public virtual string? City { get; set; }
        public virtual string? District { get; set; }
        public virtual string? State { get; set; }
        public virtual int? PinCode { get; set; }
        public virtual int? UserId { get; set; }
        
    }
}

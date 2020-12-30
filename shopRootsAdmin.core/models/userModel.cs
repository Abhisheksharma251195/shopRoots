using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace shopRootsAdmin.core.models
{
   public class userModel : modelBase
    {
        public userModel() { }
         public virtual string Name { get; set; }
         public virtual DateTime? DOB { get; set; }
         public virtual string Email { get; set; }
         public virtual string Phone { get; set; }
         public virtual byte? UserPassword { get; set; }
         public virtual string? UserId { get; set; }
         //public virtual AddressModel Address { get; set; }
    }
}


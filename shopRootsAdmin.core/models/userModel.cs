using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using shopRootsAdmin.core.enums;
namespace shopRootsAdmin.core.models
{
   public partial class userModel : modelBase
    {
        public userModel() {
           
        }

         public virtual string Name { get; set; }
         public virtual DateTime? DOB { get; set; }
         public virtual string Email { get; set; }
         public virtual string Phone { get; set; }
         public virtual byte[]? UserPassword { get; set; }
         public virtual List<AddressModel> Addresses { get; set; }
         public virtual userRoles UserType { get; set; }
         public virtual string UserId { get; set; }

    }
}


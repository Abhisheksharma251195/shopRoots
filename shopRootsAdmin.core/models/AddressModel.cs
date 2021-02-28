using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace shopRootsAdmin.core.models
{

    [Table("Address")]
    public partial class AddressModel : modelBase
    {
        public AddressModel()
        {
        }

        public virtual string AddressLine1 { get; set; }
        public virtual string City { get; set; }
        public virtual string District { get; set; }
        public virtual string State { get; set; }
        public virtual string addressType { get; set; }
        public virtual int? PinCode { get; set; }
        public virtual int UserId { get; set; }
        public virtual userModel User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace shopRootsAdmin.core.models
{


    [Table("authentication")]
    public partial class AuthModel : modelBase
    {
        public AuthModel()
        {
        }
        public string token { get; set; }
        public string userId { get; set; }
        public DateTime? ExpireOn {get; set;}
    }
}

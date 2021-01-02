using System;
using System.Collections.Generic;
using System.Text;

namespace shopRootsAdmin.core.models
{
   public class userCreateModel
    {
        public virtual string Name { get; set; }
        public virtual DateTime? DOB { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
    }
}

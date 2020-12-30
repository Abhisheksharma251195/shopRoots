using System;
using System.Collections.Generic;
using System.Text;

namespace shopRootsAdmin.core.models
{
   public class modelBase
    {
      public modelBase() { 
       }
        public virtual int ID { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime UpdatedOn { get; set; }
        public virtual int Deleted { get; set; }
        public virtual string CreatedBy { get; set; }
    }
}

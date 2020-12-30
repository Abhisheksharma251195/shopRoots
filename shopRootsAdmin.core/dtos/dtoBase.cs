using System;
using System.Collections.Generic;
using System.Text;

namespace shopRootsAdmin.core.dtos
{
   public class dtoBase
    {
        public dtoBase() { 
        }
        public int ID { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int Deleted { get; set; }
        public string CreatedBy { get; set; }
    }
}

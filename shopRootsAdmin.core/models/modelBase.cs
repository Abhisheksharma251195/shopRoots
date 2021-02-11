using System;
using System.Collections.Generic;
using System.Text;

namespace shopRootsAdmin.core.models
{
   public class modelBase
    {
       public modelBase() {
            //UpdatedOn = DateTime.UtcNow()
        }
        private DateTime DateTimeNow = new DateTime();
        public virtual int? Id { get; set; }
        //public virtual DateTime CreatedOn { get { return this.DateTimeNow}; set { 
            
        //    }; }
        public virtual DateTime UpdatedOn { get; set; }
        public virtual int Deleted { get; set; }
        public virtual string CreatedBy { get; set; }

        private string strTempleImage;
        public virtual DateTime CreatedOn
        {
            get { return this.DateTimeNow;}
            set
            {
                if (value == null)
                {
                    DateTimeNow = DateTime.UtcNow();
                }
            }
        }
    }
}

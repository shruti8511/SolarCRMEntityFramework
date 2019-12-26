using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
   public class ProductFaultDetailsEntity
    {
        public int ProductFaultDetailsID { get; set; }
        public int ProductFaultCategoryID { get; set; }
        public string ProductFaultCategory { get; set; }
        public string ProductFaultDetails { get; set; }
        public Boolean Active { get; set; }       
    }
}

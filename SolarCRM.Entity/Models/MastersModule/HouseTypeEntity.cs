using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
   public class HouseTypeEntity
    {
       public int HouseTypeID { get; set; }
       public string HouseType { get; set; }
       public decimal Variation { get; set; }
       public string HouseTypeABB { get; set; }
        public Boolean Active { get; set; }
        public int Seq { get; set; }
    }
}

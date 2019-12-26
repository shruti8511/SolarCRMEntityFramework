using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
   public class RoofAngleEntity
    {
        public int RoofAngleID { get; set; }
        public string RoofAngle { get; set; }
        public decimal Variation { get; set; }     
        public Boolean Active { get; set; }
        public int Seq { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
   public class ElecRetailerEntity
    {
        public int ElecRetailerID { get; set; }
        public string ElecRetailer { get; set; }       
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Boolean Active { get; set; }       
    }
}

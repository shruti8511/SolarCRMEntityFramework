using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
    public class ElecDistributorEntity
    {
        public int ElecDistributorID { get; set; }
        public string ElecDistributor { get; set; }
        public string ElecDistABB { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public Boolean Active { get; set; }
        public Boolean ElecDistAppReq { get; set; }
    }
}

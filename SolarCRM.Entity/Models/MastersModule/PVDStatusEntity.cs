using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
    public class PVDStatusEntity
    {
        public int PVDStatusID { get; set; }
        public int Seq { get; set; }
        public string PVDStatus { get; set; }
        public Boolean Active { get; set; }
    }
}

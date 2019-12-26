using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
    public class RexStatus
    {
        public int RexStatusID { get; set; }
        public string RexStatusName { get; set; }
        public string RexStatusABB { get; set; }
        public int Seq { get; set; }
        public Boolean Active { get; set; }
    }
}

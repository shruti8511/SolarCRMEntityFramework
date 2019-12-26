using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
    public class LeadGenEntity
    {
        public int LeadGenID { get; set; }
        public int ProjectMgrID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Name { get; set; }
        public string ContactNum { get; set; }
        public Boolean Active { get; set; }
        public int Seq { get; set; }
    }
}

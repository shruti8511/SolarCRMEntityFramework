using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
   public class ProjectCancelEntity
    {
        public int ProjectCancelID { get; set; }
        public string ProjectCancel { get; set; }
        public Boolean Active { get; set; }
        public int Seq { get; set; }
    }
}

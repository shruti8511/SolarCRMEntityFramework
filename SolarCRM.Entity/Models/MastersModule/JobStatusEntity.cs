using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
    public class JobStatusEntity
    {
        public int JobStatusID { get; set; }
        public string JobStatus { get; set; }
        public int Seq { get; set; }
        public Boolean Active { get; set; }
    }
}

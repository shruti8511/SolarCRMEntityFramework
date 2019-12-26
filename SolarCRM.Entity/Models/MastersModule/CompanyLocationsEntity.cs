using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
    public class CompanyLocationsEntity
    {
        public int CompanyLocationID { get; set; }
        public string CompanyLocation { get; set; }
        public string State { get; set; }
        public bool Active { get; set; }
        public int Seq { get; set; }
    }
}

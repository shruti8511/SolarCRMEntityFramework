using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
    public class CompanySourceEntity
    {
        public int CompanySourceID { get; set; }
        public string CompanySource { get; set; }
        public Boolean Active { get; set; }
        public int Seq { get; set; }
        public Boolean LeadSelect { get; set; }
    }
}

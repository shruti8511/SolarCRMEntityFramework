using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
   public class CompanyTypeEntity
    {
       public int CompanyTypeID { get; set; }
        public string CompanyType { get; set; }
        public Boolean Active { get; set; }
        public int Seq { get; set; }

    }
}

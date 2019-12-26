using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
   public class InsuranceTypeEntity
    {
        public int InsuranceTypeID { get; set; }
        public string InsuranceType { get; set; }
        public Boolean Active { get; set; }       
    }
}

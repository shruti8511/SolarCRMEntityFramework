using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
   public class InsuranceClaimStatusEntity
    {
        public int InsuranceClaimStatusID { get; set; }
        public string InsuranceClaimStatus { get; set; }
        public Boolean Active { get; set; }
    }
}

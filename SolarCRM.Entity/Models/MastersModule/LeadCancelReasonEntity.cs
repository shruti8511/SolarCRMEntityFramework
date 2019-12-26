using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
   public class LeadCancelReasonEntity
    {
       public int ContLeadCancelReasonID { get; set; }
       public string ContLeadCancelReason { get; set; }
        public Boolean Active { get; set; }
        public int Seq { get; set; }      
    }
}

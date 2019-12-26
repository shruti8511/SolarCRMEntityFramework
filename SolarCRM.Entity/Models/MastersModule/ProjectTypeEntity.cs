using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
   public class ProjectTypeEntity
    {
       public int ProjectTypeID { get; set; }
       public string ProjectType { get; set; }
       public Boolean Active { get; set; }
       public int Seq { get; set; }

    }


   public class ProjectCount
   {
       public long Planned { get; set; }
       public long Active { get; set; }
       public long OnHold { get; set; }
       public long Complete { get; set; }
       public long Cancelled { get; set; }

       public long wPlanned { get; set; }
       public long wActive { get; set; }
       public long wOnHold { get; set; }
       public long wComplete { get; set; }
       public long wCancelled { get; set; }

       public long mPlanned { get; set; }
       public long mActive { get; set; }
       public long mOnHold { get; set; }
       public long mComplete { get; set; }
       public long mCancelled { get; set; }

       public long Total { get; set; }
   }
   public class LeadCount
   {
       public long NewLead { get; set; }
       public long Potential { get; set; }
       public long Lead { get; set; }
   }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
   public class FinanceWithSubEntity
    {
        public int FinanceWithSubID { get; set; }
        public int FinanceWithID { get; set; }
        public string FinanceWith { get; set; }
        public string FinanceWithSub { get; set; }
        public Boolean Active { get; set; }
        public int Seq { get; set; }

    }
}

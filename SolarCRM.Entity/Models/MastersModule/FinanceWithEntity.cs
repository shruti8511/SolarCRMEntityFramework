using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
   public class FinanceWithEntity
    {
        public int FinanceWithID { get; set; }
        public string FinanceWith { get; set; }
        public Boolean Active { get; set; }
        public int Seq { get; set; }
    }
}

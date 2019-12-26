using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
   public class StockCategoryEntity
    {
        public int StockCategoryID { get; set; }
        public string StockCategory { get; set; }
        public Boolean Active { get; set; }
    }
}

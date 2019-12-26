using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.StockModule
{
    public class StockEntity
    {
        public int StockItemID { get; set; }
        public string StockItem { get; set; }
        public string StockManufacturer { get; set; }
        public string StockModel { get; set; }
        public string StockSize { get; set; }
        public string InverterCert { get; set; }
    }
}

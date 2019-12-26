using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.ProjectModule;
using SolarCRM.Entity.Models.StockModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.StockModule
{
    public class StockManagement
    {
        public static List<StockEntity> tblStockItems_SelectPanel()
        {
            return (new SolarCRM.DAL.Implementations.StockModule.StockSQL().tblStockItems_SelectPanel());
        }


        public static StockEntity tblStockItems_SelectByStockItemID(int StockItemID)
        {
            return (new SolarCRM.DAL.Implementations.StockModule.StockSQL().tblStockItems_SelectByStockItemID(StockItemID));
        }

        public static List<StockEntity> tblStockItems_SelectInverter()
        {
            return (new SolarCRM.DAL.Implementations.StockModule.StockSQL().tblStockItems_SelectInverter());
        }


    }
}

using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.StockModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.StockModule
{
   public class StockItemManagement
    {

       public static void tblStockItems_Insert(StockItemEntity ObjEntity)
       {
           new SolarCRM.DAL.Implementations.StockModule.StockItemSQL().tblStockItems_Insert(ObjEntity);
       }

       public static List<StockItemEntity> tblStockItems_Select(PagingEntity CommonEntity, out int Count)
       {
           return (new SolarCRM.DAL.Implementations.StockModule.StockItemSQL().tblStockItems_Select(CommonEntity, out Count));
       }
    }
}

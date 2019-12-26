using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class StockCategoryManagement
    {
        public static void tblStockCategory_Insert(StockCategoryEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.StockCategorySQL().tblStockCategory_Insert(ObjEntity);
        }

        public static int tblStockCategory_Exists(string StockCategory)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.StockCategorySQL().tblStockCategory_Exists(StockCategory));
        }

        public static List<StockCategoryEntity> tblStockCategory_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.StockCategorySQL().tblStockCategory_Select(CommonEntity, out Count));
        }

        public static List<StockCategoryEntity> tblStockCategory_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.StockCategorySQL().tblStockCategory_SelectActive());
        }

        public static StockCategoryEntity tblStockCategory_ForEdit(int StockCategoryID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.StockCategorySQL().tblStockCategory_ForEdit(StockCategoryID));
        }

        public static StockCategoryEntity tblStockCategory_SelectForUpdate(string StockCategory, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.StockCategorySQL().tblStockCategory_SelectForUpdate(StockCategory, Active));
        }

        public static void tblStockCategory_Update(StockCategoryEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.StockCategorySQL().tblStockCategory_Update(ObjEntity);
        }

        public static void tblStockCategory_Delete(int StockCategoryID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.StockCategorySQL().tblStockCategory_Delete(StockCategoryID);
        }




        public static List<StockCategoryEntity> tblStockCategory_SelectForDropdown()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.StockCategorySQL().tblStockCategory_SelectForDropdown());
        }



    }
}

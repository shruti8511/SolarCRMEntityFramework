using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class ProductFaultCategoryManagement
    {
        public static void tblProductFaultCategory_Insert(ProductFaultCategoryEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProductFaultCategorySQL().tblProductFaultCategory_Insert(ObjEntity);
        }

        public static int tblProductFaultCategory_Exists(string ProductFaultCategory)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProductFaultCategorySQL().tblProductFaultCategory_Exists(ProductFaultCategory));
        }

        public static List<ProductFaultCategoryEntity> tblProductFaultCategory_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProductFaultCategorySQL().tblProductFaultCategory_Select(CommonEntity, out Count));
        }

        public static List<ProductFaultCategoryEntity> tblProductFaultCategory_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProductFaultCategorySQL().tblProductFaultCategory_SelectActive());
        }

        public static ProductFaultCategoryEntity tblProductFaultCategory_ForEdit(int ProductFaultCategoryID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProductFaultCategorySQL().tblProductFaultCategory_ForEdit(ProductFaultCategoryID));
        }

        public static ProductFaultCategoryEntity tblProductFaultCategory_SelectForUpdate(string ProductFaultCategory, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProductFaultCategorySQL().tblProductFaultCategory_SelectForUpdate(ProductFaultCategory, Active));
        }

        public static void tblProductFaultCategory_Update(ProductFaultCategoryEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProductFaultCategorySQL().tblProductFaultCategory_Update(ObjEntity);
        }

        public static void tblProductFaultCategory_Delete(int ProductFaultCategoryID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProductFaultCategorySQL().tblProductFaultCategory_Delete(ProductFaultCategoryID);
        }

    }
}

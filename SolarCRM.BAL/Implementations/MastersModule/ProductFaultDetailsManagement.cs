using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class ProductFaultDetailsManagement
    {
       public static List<ProductFaultDetailsEntity> tblProductFaultCategory_SelectForDropdown()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProductFaultDetailsSQL().tblProductFaultCategory_SelectForDropdown());
        }

        public static void tblProductFaultDetails_Insert(ProductFaultDetailsEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProductFaultDetailsSQL().tblProductFaultDetails_Insert(ObjEntity);
        }

        public static int tblProductFaultDetails_Exists(string ProductFaultDetails)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProductFaultDetailsSQL().tblProductFaultDetails_Exists(ProductFaultDetails));
        }

        public static List<ProductFaultDetailsEntity> tblProductFaultDetails_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProductFaultDetailsSQL().tblProductFaultDetails_Select(CommonEntity, out Count));
        }

        public static ProductFaultDetailsEntity tblProductFaultDetails_ForEdit(int ProductFaultDetailsID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProductFaultDetailsSQL().tblProductFaultDetails_ForEdit(ProductFaultDetailsID));
        }

        public static ProductFaultDetailsEntity tblProductFaultDetails_SelectForUpdate(string ProductFaultDetails, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProductFaultDetailsSQL().tblProductFaultDetails_SelectForUpdate(ProductFaultDetails, Active));
        }

        public static void tblProductFaultDetails_Update(ProductFaultDetailsEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProductFaultDetailsSQL().tblProductFaultDetails_Update(ObjEntity);
        }

        public static void tblProductFaultDetails_Delete(int ProductFaultDetailsID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProductFaultDetailsSQL().tblProductFaultDetails_Delete(ProductFaultDetailsID);
        }

        public static List<ProductFaultDetailsEntity> tblCustSourceSub_SelectByCSID(int CompanySourceID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProductFaultDetailsSQL().tblCustSourceSub_SelectByCSID(CompanySourceID));
        }
    }
}

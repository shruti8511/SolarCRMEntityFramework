using SolarCRM.Entity.Models.MastersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class CompanySourceSubManagement
    {
       public static List<CompanySourceSubEntity> tblCompanySource_SelectForDropdown()
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSubSQL().tblCompanySource_SelectForDropdown());
       }

       public static void tblCompanySourceSub_Insert(CompanySourceSubEntity ObjEntity)
       {
           new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSubSQL().tblCompanySourceSub_Insert(ObjEntity);
       }

       public static int tblCompanySourceSub_Exists(string CompanySourceSub)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSubSQL().tblCompanySourceSub_Exists(CompanySourceSub));
       }

       public static List<CompanySourceSubEntity> tblCompanySourceSub_Select(PagingEntity CommonEntity, out int Count)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSubSQL().tblCompanySourceSub_Select(CommonEntity, out Count));
       }

       public static CompanySourceSubEntity tblCompanySourceSub_ForEdit(int CompanySourceSubID)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSubSQL().tblCompanySourceSub_ForEdit(CompanySourceSubID));
       }

       public static CompanySourceSubEntity tblCompanySourceSub_SelectForUpdate(string CompanySourceSub, Boolean Active)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSubSQL().tblCompanySourceSub_SelectForUpdate(CompanySourceSub, Active));
       }

       public static void tblCompanySourceSub_Update(CompanySourceSubEntity ObjEntity)
       {
           new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSubSQL().tblCompanySourceSub_Update(ObjEntity);
       }

       public static void tblCompanySourceSub_Delete(int CompanySourceSubID)
       {
           new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSubSQL().tblCompanySourceSub_Delete(CompanySourceSubID);
       }

       public static List<CompanySourceSubEntity> tblCustSourceSub_SelectByCSID(int CompanySourceID)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSubSQL().tblCustSourceSub_SelectByCSID(CompanySourceID));
       }
    }
}

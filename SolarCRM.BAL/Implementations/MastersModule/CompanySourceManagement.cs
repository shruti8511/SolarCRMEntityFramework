using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
  public class CompanySourceManagement
    {
        public static void tblCompanySource_Insert(CompanySourceEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSQL().tblCompanySource_Insert(ObjEntity);
        }

        public static int tblCompanySource_Exists(string CompanySource)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSQL().tblCompanySource_Exists(CompanySource));
        }

        public static List<CompanySourceEntity> tblCompanySource_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSQL().tblCompanySource_Select(CommonEntity, out Count));
        }

        public static List<CompanySourceEntity> tblCompanySource_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSQL().tblCompanySource_SelectActive());
        }

        public static CompanySourceEntity tblCompanySource_ForEdit(int CompanySourceID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSQL().tblCompanySource_ForEdit(CompanySourceID));
        }

        public static CompanySourceEntity tblCompanySource_SelectForUpdate(string CompanySource, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSQL().tblCompanySource_SelectForUpdate(CompanySource, Active));
        }

        public static void tblCompanySource_Update(CompanySourceEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSQL().tblCompanySource_Update(ObjEntity);
        }

        public static void tblCompanySource_Delete(int CompanySourceID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.CompanySourceSQL().tblCompanySource_Delete(CompanySourceID);
        }

    }
}

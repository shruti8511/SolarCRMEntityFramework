using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
    public class CompanyTypeManagement
    {
        public static void tblCompanyType_Insert(CompanyTypeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.CompanyTypeSQL().tblCompanyType_Insert(ObjEntity);
        }

        public static int tblCompanyType_Exists(string CompanyType)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.CompanyTypeSQL().tblCompanyType_Exists(CompanyType));
        }

        public static List<CompanyTypeEntity> tblCompanyType_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.CompanyTypeSQL().tblCompanyType_Select(CommonEntity, out Count));
        }

        public static List<CompanyTypeEntity> tblCompanyType_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.CompanyTypeSQL().tblCompanyType_SelectActive());
        }

        public static CompanyTypeEntity tblCompanyType_ForEdit(int CompanyTypeID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.CompanyTypeSQL().tblCompanyType_ForEdit(CompanyTypeID));
        }

        public static CompanyTypeEntity tblCompanyType_SelectForUpdate(string CompanyType, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.CompanyTypeSQL().tblCompanyType_SelectForUpdate(CompanyType, Active));
        }

        public static void tblCompanyType_Update(CompanyTypeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.CompanyTypeSQL().tblCompanyType_Update(ObjEntity);
        }

        public static void tblCompanyType_Delete(int CompanyTypeID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.CompanyTypeSQL().tblCompanyType_Delete(CompanyTypeID);
        }

    }
}

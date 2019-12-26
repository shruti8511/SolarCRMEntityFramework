using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class InsuranceCompanyManagement
    {
        public static void tblInsuranceCompany_Insert(InsuranceCompanyEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InsuranceCompanySQL().tblInsuranceCompany_Insert(ObjEntity);
        }

        public static int tblInsuranceCompany_Exists(string InsuranceCompany)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InsuranceCompanySQL().tblInsuranceCompany_Exists(InsuranceCompany));
        }

        public static List<InsuranceCompanyEntity> tblInsuranceCompany_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InsuranceCompanySQL().tblInsuranceCompany_Select(CommonEntity, out Count));
        }

        public static List<InsuranceCompanyEntity> tblInsuranceCompany_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InsuranceCompanySQL().tblInsuranceCompany_SelectActive());
        }

        public static InsuranceCompanyEntity tblInsuranceCompany_ForEdit(int InsuranceCompanyID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InsuranceCompanySQL().tblInsuranceCompany_ForEdit(InsuranceCompanyID));
        }

        public static InsuranceCompanyEntity tblInsuranceCompany_SelectForUpdate(string InsuranceCompany, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InsuranceCompanySQL().tblInsuranceCompany_SelectForUpdate(InsuranceCompany, Active));
        }

        public static void tblInsuranceCompany_Update(InsuranceCompanyEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InsuranceCompanySQL().tblInsuranceCompany_Update(ObjEntity);
        }

        public static void tblInsuranceCompany_Delete(int InsuranceCompanyID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InsuranceCompanySQL().tblInsuranceCompany_Delete(InsuranceCompanyID);
        }

    }
}

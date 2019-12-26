using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class InsuranceClaimStatusManagement
    {
        public static void tblInsuranceClaimStatus_Insert(InsuranceClaimStatusEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InsuranceClaimStatusSQL().tblInsuranceClaimStatus_Insert(ObjEntity);
        }

        public static int tblInsuranceClaimStatus_Exists(string InsuranceClaimStatus)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InsuranceClaimStatusSQL().tblInsuranceClaimStatus_Exists(InsuranceClaimStatus));
        }

        public static List<InsuranceClaimStatusEntity> tblInsuranceClaimStatus_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InsuranceClaimStatusSQL().tblInsuranceClaimStatus_Select(CommonEntity, out Count));
        }

        public static List<InsuranceClaimStatusEntity> tblInsuranceClaimStatus_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InsuranceClaimStatusSQL().tblInsuranceClaimStatus_SelectActive());
        }

        public static InsuranceClaimStatusEntity tblInsuranceClaimStatus_ForEdit(int InsuranceClaimStatusID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InsuranceClaimStatusSQL().tblInsuranceClaimStatus_ForEdit(InsuranceClaimStatusID));
        }

        public static InsuranceClaimStatusEntity tblInsuranceClaimStatus_SelectForUpdate(string InsuranceClaimStatus, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InsuranceClaimStatusSQL().tblInsuranceClaimStatus_SelectForUpdate(InsuranceClaimStatus, Active));
        }

        public static void tblInsuranceClaimStatus_Update(InsuranceClaimStatusEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InsuranceClaimStatusSQL().tblInsuranceClaimStatus_Update(ObjEntity);
        }

        public static void tblInsuranceClaimStatus_Delete(int InsuranceClaimStatusID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InsuranceClaimStatusSQL().tblInsuranceClaimStatus_Delete(InsuranceClaimStatusID);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class InsuranceTypeManagement
    {
        public static void tblInsuranceType_Insert(InsuranceTypeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InsuranceTypeSQL().tblInsuranceType_Insert(ObjEntity);
        }

        public static int tblInsuranceType_Exists(string InsuranceType)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InsuranceTypeSQL().tblInsuranceType_Exists(InsuranceType));
        }

        public static List<InsuranceTypeEntity> tblInsuranceType_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InsuranceTypeSQL().tblInsuranceType_Select(CommonEntity, out Count));
        }

        public static List<InsuranceTypeEntity> tblInsuranceType_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InsuranceTypeSQL().tblInsuranceType_SelectActive());
        }

        public static InsuranceTypeEntity tblInsuranceType_ForEdit(int InsuranceTypeID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InsuranceTypeSQL().tblInsuranceType_ForEdit(InsuranceTypeID));
        }

        public static InsuranceTypeEntity tblInsuranceType_SelectForUpdate(string InsuranceType, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InsuranceTypeSQL().tblInsuranceType_SelectForUpdate(InsuranceType, Active));
        }

        public static void tblInsuranceType_Update(InsuranceTypeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InsuranceTypeSQL().tblInsuranceType_Update(ObjEntity);
        }

        public static void tblInsuranceType_Delete(int InsuranceTypeID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InsuranceTypeSQL().tblInsuranceType_Delete(InsuranceTypeID);
        }

    }
}

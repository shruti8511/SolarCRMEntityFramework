using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class MtceCompanyTypeManagement
    {
        public static void tblMtceCompanyType_Insert(MtceCompanyTypeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.MtceCompanyTypeSQL().tblMtceCompanyType_Insert(ObjEntity);
        }

        public static int tblMtceCompanyType_Exists(string MtceCompanyType)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.MtceCompanyTypeSQL().tblMtceCompanyType_Exists(MtceCompanyType));
        }

        public static List<MtceCompanyTypeEntity> tblMtceCompanyType_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.MtceCompanyTypeSQL().tblMtceCompanyType_Select(CommonEntity, out Count));
        }

        public static List<MtceCompanyTypeEntity> tblMtceCompanyType_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.MtceCompanyTypeSQL().tblMtceCompanyType_SelectActive());
        }

        public static MtceCompanyTypeEntity tblMtceCompanyType_ForEdit(int MtceCompanyTypeID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.MtceCompanyTypeSQL().tblMtceCompanyType_ForEdit(MtceCompanyTypeID));
        }

        public static MtceCompanyTypeEntity tblMtceCompanyType_SelectForUpdate(string MtceCompanyType, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.MtceCompanyTypeSQL().tblMtceCompanyType_SelectForUpdate(MtceCompanyType, Active));
        }

        public static void tblMtceCompanyType_Update(MtceCompanyTypeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.MtceCompanyTypeSQL().tblMtceCompanyType_Update(ObjEntity);
        }

        public static void tblMtceCompanyType_Delete(int MtceCompanyTypeID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.MtceCompanyTypeSQL().tblMtceCompanyType_Delete(MtceCompanyTypeID);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class SpecialPurposeManagement
    {
        public static void tblSpecialPurpose_Insert(SpecialPurposeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.SpecialPurposeSQL().tblSpecialPurpose_Insert(ObjEntity);
        }

        public static int tblSpecialPurpose_Exists(string SpecialPurpose)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.SpecialPurposeSQL().tblSpecialPurpose_Exists(SpecialPurpose));
        }

        public static List<SpecialPurposeEntity> tblSpecialPurpose_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.SpecialPurposeSQL().tblSpecialPurpose_Select(CommonEntity, out Count));
        }

        public static List<SpecialPurposeEntity> tblSpecialPurpose_SelectActive(int isactive, string SpecialPurposeID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.SpecialPurposeSQL().tblSpecialPurpose_SelectActive(isactive,SpecialPurposeID));
        }
        public static SpecialPurposeEntity  tblSpecialPurpose_SelectBySpecialPurposeID(long SpecialPurposeID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.SpecialPurposeSQL().tblSpecialPurpose_SelectBySpecialPurposeID(SpecialPurposeID));
        }

        public static SpecialPurposeEntity tblSpecialPurpose_ForEdit(int SpecialPurposeID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.SpecialPurposeSQL().tblSpecialPurpose_ForEdit(SpecialPurposeID));
        }

        public static SpecialPurposeEntity tblSpecialPurpose_SelectForUpdate(string SpecialPurpose, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.SpecialPurposeSQL().tblSpecialPurpose_SelectForUpdate(SpecialPurpose, Active));
        }

        public static void tblSpecialPurpose_Update(SpecialPurposeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.SpecialPurposeSQL().tblSpecialPurpose_Update(ObjEntity);
        }

        public static void tblSpecialPurpose_Delete(int SpecialPurposeID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.SpecialPurposeSQL().tblSpecialPurpose_Delete(SpecialPurposeID);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class RoofTypeManagement
    {
        public static void tblRoofType_Insert(RoofTypeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.RoofTypeSQL().tblRoofType_Insert(ObjEntity);
        }

        public static int tblRoofType_Exists(string RoofType)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.RoofTypeSQL().tblRoofType_Exists(RoofType));
        }

        public static List<RoofTypeEntity> tblRoofType_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.RoofTypeSQL().tblRoofType_Select(CommonEntity, out Count));
        }

        public static List<RoofTypeEntity> tblRoofType_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.RoofTypeSQL().tblRoofType_SelectActive());
        }

        public static RoofTypeEntity tblRoofType_ForEdit(int RoofTypeID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.RoofTypeSQL().tblRoofType_ForEdit(RoofTypeID));
        }

        public static RoofTypeEntity tblRoofType_SelectForUpdate(string RoofType, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.RoofTypeSQL().tblRoofType_SelectForUpdate(RoofType, Active));
        }

        public static void tblRoofType_Update(RoofTypeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.RoofTypeSQL().tblRoofType_Update(ObjEntity);
        }

        public static void tblRoofType_Delete(int RoofTypeID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.RoofTypeSQL().tblRoofType_Delete(RoofTypeID);
        }

        public static List<RoofTypeEntity> tblRoofType_SelectASC()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.RoofTypeSQL().tblRoofType_SelectASC());
        }

    }
}

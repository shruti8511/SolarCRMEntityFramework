using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class RoofAngleManagement
    {
        public static void tblRoofAngle_Insert(RoofAngleEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.RoofAngleSQL().tblRoofAngle_Insert(ObjEntity);
        }

        public static int tblRoofAngle_Exists(string RoofAngle)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.RoofAngleSQL().tblRoofAngle_Exists(RoofAngle));
        }

        public static List<RoofAngleEntity> tblRoofAngle_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.RoofAngleSQL().tblRoofAngle_Select(CommonEntity, out Count));
        }

        public static List<RoofAngleEntity> tblRoofAngle_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.RoofAngleSQL().tblRoofAngle_SelectActive());
        }

        public static RoofAngleEntity tblRoofAngle_ForEdit(int RoofAngleID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.RoofAngleSQL().tblRoofAngle_ForEdit(RoofAngleID));
        }

        public static RoofAngleEntity tblRoofAngle_SelectForUpdate(string RoofAngle, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.RoofAngleSQL().tblRoofAngle_SelectForUpdate(RoofAngle, Active));
        }

        public static void tblRoofAngle_Update(RoofAngleEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.RoofAngleSQL().tblRoofAngle_Update(ObjEntity);
        }

        public static void tblRoofAngle_Delete(int RoofAngleID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.RoofAngleSQL().tblRoofAngle_Delete(RoofAngleID);
        }

        public static List<RoofAngleEntity> tblRoofAngle_SelectASC()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.RoofAngleSQL().tblRoofAngle_SelectASC());
        }

    }
}

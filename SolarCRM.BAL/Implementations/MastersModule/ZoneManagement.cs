using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class ZoneManagement
    {
        public static void tblZone_Insert(ZoneEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ZoneSQL().tblZone_Insert(ObjEntity);
        }

        public static int tblZone_Exists(string Zone)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ZoneSQL().tblZone_Exists(Zone));
        }

        public static List<ZoneEntity> tblZone_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ZoneSQL().tblZone_Select(CommonEntity, out Count));
        }

        public static List<ZoneEntity> tblZone_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ZoneSQL().tblZone_SelectActive());
        }

        public static ZoneEntity tblZone_ForEdit(int ZoneID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ZoneSQL().tblZone_ForEdit(ZoneID));
        }

        public static ZoneEntity tblZone_SelectForUpdate(string Zone, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ZoneSQL().tblZone_SelectForUpdate(Zone, Active));
        }

        public static void tblZone_Update(ZoneEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ZoneSQL().tblZone_Update(ObjEntity);
        }

        public static void tblZone_Delete(int ZoneID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ZoneSQL().tblZone_Delete(ZoneID);
        }
    }
}

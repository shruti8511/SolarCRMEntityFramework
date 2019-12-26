using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class HouseTypeManagement
    {
        public static void tblHouseType_Insert(HouseTypeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.HouseTypeSQL().tblHouseType_Insert(ObjEntity);
        }

        public static int tblHouseType_Exists(string HouseType)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.HouseTypeSQL().tblHouseType_Exists(HouseType));
        }

        public static List<HouseTypeEntity> tblHouseType_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.HouseTypeSQL().tblHouseType_Select(CommonEntity, out Count));
        }

        public static List<HouseTypeEntity> tblHouseType_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.HouseTypeSQL().tblHouseType_SelectActive());
        }

        public static HouseTypeEntity tblHouseType_ForEdit(int HouseTypeID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.HouseTypeSQL().tblHouseType_ForEdit(HouseTypeID));
        }

        public static HouseTypeEntity tblHouseType_SelectForUpdate(string HouseType, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.HouseTypeSQL().tblHouseType_SelectForUpdate(HouseType, Active));
        }

        public static void tblHouseType_Update(HouseTypeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.HouseTypeSQL().tblHouseType_Update(ObjEntity);
        }

        public static void tblHouseType_Delete(int HouseTypeID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.HouseTypeSQL().tblHouseType_Delete(HouseTypeID);
        }

        public static List<HouseTypeEntity> tblHouseType_SelectASC()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.HouseTypeSQL().tblHouseType_SelectASC());
        }
    }
}

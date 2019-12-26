using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class PromotionTypeManagement
    {
        public static void tblPromotionType_Insert(PromotionTypeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.PromotionTypeSQL().tblPromotionType_Insert(ObjEntity);
        }

        public static int tblPromotionType_Exists(string PromotionType)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PromotionTypeSQL().tblPromotionType_Exists(PromotionType));
        }

        public static List<PromotionTypeEntity> tblPromotionType_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PromotionTypeSQL().tblPromotionType_Select(CommonEntity, out Count));
        }

        public static List<PromotionTypeEntity> tblPromotionType_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PromotionTypeSQL().tblPromotionType_SelectActive());
        }

        public static PromotionTypeEntity tblPromotionType_ForEdit(int PromotionTypeID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PromotionTypeSQL().tblPromotionType_ForEdit(PromotionTypeID));
        }

        public static PromotionTypeEntity tblPromotionType_SelectForUpdate(string PromotionType, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PromotionTypeSQL().tblPromotionType_SelectForUpdate(PromotionType, Active));
        }

        public static void tblPromotionType_Update(PromotionTypeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.PromotionTypeSQL().tblPromotionType_Update(ObjEntity);
        }

        public static void tblPromotionType_Delete(int PromotionTypeID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.PromotionTypeSQL().tblPromotionType_Delete(PromotionTypeID);
        }

    }
}

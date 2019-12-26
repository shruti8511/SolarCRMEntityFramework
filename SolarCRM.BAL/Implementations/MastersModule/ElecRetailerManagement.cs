using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class ElecRetailerManagement
    {
        public static void tblElecRetailer_Insert(ElecRetailerEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ElecRetailerSQL().tblElecRetailer_Insert(ObjEntity);
        }

        public static int tblElecRetailer_Exists(string ElecRetailer)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ElecRetailerSQL().tblElecRetailer_Exists(ElecRetailer));
        }

        public static List<ElecRetailerEntity> tblElecRetailer_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ElecRetailerSQL().tblElecRetailer_Select(CommonEntity, out Count));
        }

        //public static List<ElecRetailerEntity> tblElecRetailer_SelectActive()
        //{
        //    return (new SolarCRM.DAL.Implementations.MastersModule.ElecRetailerSQL().tblElecRetailer_SelectActive());
        //}

        public static ElecRetailerEntity tblElecRetailer_ForEdit(int ElecRetailerID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ElecRetailerSQL().tblElecRetailer_ForEdit(ElecRetailerID));
        }

        public static ElecRetailerEntity tblElecRetailer_SelectForUpdate(string ElecRetailer, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ElecRetailerSQL().tblElecRetailer_SelectForUpdate(ElecRetailer, Active));
        }

        public static void tblElecRetailer_Update(ElecRetailerEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ElecRetailerSQL().tblElecRetailer_Update(ObjEntity);
        }

        public static void tblElecRetailer_Delete(int ElecRetailerID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ElecRetailerSQL().tblElecRetailer_Delete(ElecRetailerID);
        }

        public static List<ElecRetailerEntity> tblElecRetailer_SelectASC()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ElecRetailerSQL().tblElecRetailer_SelectASC());
        }
    }
}

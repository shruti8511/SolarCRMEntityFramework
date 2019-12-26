using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class OrderingFromManagement
    {
        public static void tblOrderingFrom_Insert(OrderingFromEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.OrderingFromSQL().tblOrderingFrom_Insert(ObjEntity);
        }

        public static int tblOrderingFrom_Exists(string OrderingFrom)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.OrderingFromSQL().tblOrderingFrom_Exists(OrderingFrom));
        }

        public static List<OrderingFromEntity> tblOrderingFrom_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.OrderingFromSQL().tblOrderingFrom_Select(CommonEntity, out Count));
        }

        public static List<OrderingFromEntity> tblOrderingFrom_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.OrderingFromSQL().tblOrderingFrom_SelectActive());
        }

        public static OrderingFromEntity tblOrderingFrom_ForEdit(int OrderingFromID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.OrderingFromSQL().tblOrderingFrom_ForEdit(OrderingFromID));
        }

        public static OrderingFromEntity tblOrderingFrom_SelectForUpdate(string OrderingFrom, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.OrderingFromSQL().tblOrderingFrom_SelectForUpdate(OrderingFrom, Active));
        }

        public static void tblOrderingFrom_Update(OrderingFromEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.OrderingFromSQL().tblOrderingFrom_Update(ObjEntity);
        }

        public static void tblOrderingFrom_Delete(int OrderingFromID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.OrderingFromSQL().tblOrderingFrom_Delete(OrderingFromID);
        }
    }
}

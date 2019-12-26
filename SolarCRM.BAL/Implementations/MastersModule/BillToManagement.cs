using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class BillToManagement
    {
        public static void tblBillTo_Insert(BillToEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.BillToSQL().tblBillTo_Insert(ObjEntity);
        }

        public static int tblBillTo_Exists(string BillTo)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.BillToSQL().tblBillTo_Exists(BillTo));
        }

        public static List<BillToEntity> tblBillTo_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.BillToSQL().tblBillTo_Select(CommonEntity, out Count));
        }

        public static List<BillToEntity> tblBillTo_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.BillToSQL().tblBillTo_SelectActive());
        }

        public static BillToEntity tblBillTo_ForEdit(int BillToID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.BillToSQL().tblBillTo_ForEdit(BillToID));
        }

        public static BillToEntity tblBillTo_SelectForUpdate(string BillTo, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.BillToSQL().tblBillTo_SelectForUpdate(BillTo, Active));
        }

        public static void tblBillTo_Update(BillToEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.BillToSQL().tblBillTo_Update(ObjEntity);
        }

        public static void tblBillTo_Delete(int BillToID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.BillToSQL().tblBillTo_Delete(BillToID);
        }
    }
}

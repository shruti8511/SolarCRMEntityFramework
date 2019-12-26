using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class FinanceWithManagement
    {
        public static void tblFinanceWith_Insert(FinanceWithEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSQL().tblFinanceWith_Insert(ObjEntity);
        }

        public static int tblFinanceWith_Exists(string FinanceWith)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSQL().tblFinanceWith_Exists(FinanceWith));
        }

        public static List<FinanceWithEntity> tblFinanceWith_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSQL().tblFinanceWith_Select(CommonEntity, out Count));
        }

        public static List<FinanceWithEntity> tblFinanceWith_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSQL().tblFinanceWith_SelectActive());
        }

        public static FinanceWithEntity tblFinanceWith_ForEdit(int FinanceWithID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSQL().tblFinanceWith_ForEdit(FinanceWithID));
        }

        public static FinanceWithEntity tblFinanceWith_SelectForUpdate(string FinanceWith, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSQL().tblFinanceWith_SelectForUpdate(FinanceWith, Active));
        }

        public static void tblFinanceWith_Update(FinanceWithEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSQL().tblFinanceWith_Update(ObjEntity);
        }

        public static void tblFinanceWith_Delete(int FinanceWithID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSQL().tblFinanceWith_Delete(FinanceWithID);
        }
    }
}

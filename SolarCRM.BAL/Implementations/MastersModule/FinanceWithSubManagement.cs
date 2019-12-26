using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class FinanceWithSubManagement
    {
       public static List<FinanceWithSubEntity> tblFinanceWith_SelectForDropdown()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSubSQL().tblFinanceWith_SelectForDropdown());
        }

        public static void tblFinanceWithSub_Insert(FinanceWithSubEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSubSQL().tblFinanceWithSub_Insert(ObjEntity);
        }

        public static int tblFinanceWithSub_Exists(string FinanceWithSub)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSubSQL().tblFinanceWithSub_Exists(FinanceWithSub));
        }

        public static List<FinanceWithSubEntity> tblFinanceWithSub_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSubSQL().tblFinanceWithSub_Select(CommonEntity, out Count));
        }

        public static FinanceWithSubEntity tblFinanceWithSub_ForEdit(int FinanceWithSubID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSubSQL().tblFinanceWithSub_ForEdit(FinanceWithSubID));
        }

        public static FinanceWithSubEntity tblFinanceWithSub_SelectForUpdate(string FinanceWithSub, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSubSQL().tblFinanceWithSub_SelectForUpdate(FinanceWithSub, Active));
        }

        public static void tblFinanceWithSub_Update(FinanceWithSubEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSubSQL().tblFinanceWithSub_Update(ObjEntity);
        }

        public static void tblFinanceWithSub_Delete(int FinanceWithSubID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSubSQL().tblFinanceWithSub_Delete(FinanceWithSubID);
        }

        public static List<FinanceWithSubEntity> tblCustSourceSub_SelectByCSID(int CompanySourceID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.FinanceWithSubSQL().tblCustSourceSub_SelectByCSID(CompanySourceID));
        }

    }
}

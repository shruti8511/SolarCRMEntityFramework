using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class EmployeesCommissionManagement
    {
        //public static List<EmployeesCommissionEntity> tblCompanySource_SelectForDropdown()
        //{
        //    return (new SolarCRM.DAL.Implementations.MastersModule.EmployeesCommissionSQL().tblCompanySource_SelectForDropdown());
        //}

        public static void tblEmployeesCommission_Insert(EmployeesCommissionEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.EmployeesCommissionSQL().tblEmployeesCommission_Insert(ObjEntity);
        }

        //public static int tblEmployeesCommission_Exists(string EmployeesCommission)
        //{
        //    return (new SolarCRM.DAL.Implementations.MastersModule.EmployeesCommissionSQL().tblEmployeesCommission_Exists(EmployeesCommission));
        //}

        public static List<EmployeesCommissionEntity> tblEmployeesCommission_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.EmployeesCommissionSQL().tblEmployeesCommission_Select(CommonEntity, out Count));
        }

        public static EmployeesCommissionEntity tblEmployeesCommission_ForEdit(int EmployeesCommissionID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.EmployeesCommissionSQL().tblEmployeesCommission_ForEdit(EmployeesCommissionID));
        }

        //public static EmployeesCommissionEntity tblEmployeesCommission_SelectForUpdate(string EmployeesCommission, Boolean Active)
        //{
        //    return (new SolarCRM.DAL.Implementations.MastersModule.EmployeesCommissionSQL().tblEmployeesCommission_SelectForUpdate(EmployeesCommission, Active));
        //}

        public static void tblEmployeesCommission_Update(EmployeesCommissionEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.EmployeesCommissionSQL().tblEmployeesCommission_Update(ObjEntity);
        }

        public static void tblEmployeesCommission_Delete(int EmployeesCommissionID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.EmployeesCommissionSQL().tblEmployeesCommission_Delete(EmployeesCommissionID);
        }

        //public static List<EmployeesCommissionEntity> tblCustSourceSub_SelectByCSID(int CompanySourceID)
        //{
        //    return (new SolarCRM.DAL.Implementations.MastersModule.EmployeesCommissionSQL().tblCustSourceSub_SelectByCSID(CompanySourceID));
        //}


    }
}

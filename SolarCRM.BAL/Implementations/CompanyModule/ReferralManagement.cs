using SolarCRM.Entity.Models.CompanyModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.CompanyModule
{
    public class ReferralManagement
    {
        public static void tblReferral_InsertByCompany(long CustomerID, long ContactID, long EmployeeID, DateTime ReferralDate, string ReferredByProjectNo, string ReferredByCustomerName, string ReferredByProjectStatus, string ReferralNotes, string ReferredByBalOwing)
        {
            new SolarCRM.DAL.Implementations.CompanyModule.ReferralSQL().tblReferral_InsertByCompany(CustomerID, ContactID, EmployeeID, ReferralDate, ReferredByProjectNo, ReferredByCustomerName, ReferredByProjectStatus, ReferralNotes, ReferredByBalOwing);
        }

        public static ReferralEntity tblReferral_SelectByReferralID(long CustomerID, string id, string ProjectID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.ReferralSQL().tblReferral_SelectByReferralID(CustomerID, id, ProjectID));
        }

        public static void tblReferral_UpdateByCompany(ReferralEntity obj)
        {
            new SolarCRM.DAL.Implementations.CompanyModule.ReferralSQL().tblReferral_UpdateByCompany(obj);
        }
    }
}

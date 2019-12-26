using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
    public class EmployeeEntity
    {
        public int EmployeeID { get; set; }
        public int ContactID { get; set; }
        public int EmployeeTypeID { get; set; }
        public string EmployeeType { get; set; }
        public Boolean Active { get; set; }
        public int EmployeeStatusID { get; set; }
        public string EmployeeStatus { get; set; }
        public int CompanyLocationID { get; set; }
        public string CompanyLocation { get; set; }
        public int SalesTeamID { get; set; }
        public string SalesTeam { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public string userid { get; set; }
        public string username { get; set; }
        public string fullname { get; set; }
        public string JobTitle { get; set; }
        public string employeestatusname { get; set; }

        public string EmpMr { get; set; }
        public string EmpFirst { get; set; }
        public string EmpLast { get; set; }
        public string EmpTitle { get; set; }
        public string EmpEmail { get; set; }
        public string EmpPersEmail { get; set; }
        
        public string EmpMobile { get; set; }
        public string EmpNicName { get; set; }
        public Boolean LTeamOutDoor { get; set; }
        public Boolean LTeamCloser { get; set; }
        public string EmpInitials { get; set; }
        public DateTime HireDate { get; set; }
        public string UserPassword { get; set; }
        // public int CompanyLocationID { get; set; }
        public string TaxFileNumber { get; set; }

        public string SuperFund { get; set; }
        public string SuperFundAccount { get; set; }
        public string EmpBSB { get; set; }
        public string EmpBankAcct { get; set; }
        public decimal InitialSalesQuota { get; set; }
        public string EmpAddress { get; set; }
        public string EmpCity { get; set; }
        public string EmpState { get; set; }
        public string EmpPostCode { get; set; }

        public string EmpABN { get; set; }
        public string EmpAccountName { get; set; }
        public Boolean ActiveEmp { get; set; }


        public string StartTime { get; set; }

       // public DateTime StartTime { get; set; }


        public Boolean Include { get; set; }
        public string EndTime { get; set; }
        public Boolean OnRoster { get; set; }
        public string BreakTime { get; set; }
        public Boolean PaysOwnSuper { get; set; }
        public Boolean GSTPayment { get; set; }
        public string EmpInfo { get; set; }

        public Boolean SalesRep { get; set; }
        public Boolean AdminStaff { get; set; }
        public Boolean ExecAccess { get; set; }
        public Boolean AdminAccess { get; set; }
        public Boolean DeleteAccess { get; set; }
        public Boolean ProjDispAccess { get; set; }
        public Boolean ManagerAccess { get; set; }
        public Boolean AdminPL { get; set; }
        public Boolean BillsOwingPL { get; set; }
        public Boolean BillsPaidPL { get; set; }
        public Boolean BookingsPL { get; set; }
        public Boolean CompaniesPL { get; set; }
        public Boolean ContactsPL { get; set; }
        public Boolean FollowUpPL { get; set; }
        public Boolean InvIssuedPL { get; set; }
        public Boolean InvPaidPL { get; set; }
        public Boolean MeetingsPL { get; set; }
        public Boolean ProjectsPL { get; set; }
        public Boolean StatisticsPL { get; set; }
        public Boolean StockItemsPL { get; set; }
        public Boolean StockOrdersPL { get; set; }
        public Boolean SuperTaxPL { get; set; }
        public Boolean WagesPL { get; set; }
        public Boolean WholesalePL { get; set; }

        public Boolean IsInstaller { get; set; }
        public Boolean IsDesigner { get; set; }
        public Boolean IsElectrician { get; set; }
        public string SalesQuotaPeriodID { get; set; }
        public string DateOfBirth { get; set; }
        public int EmpType { get; set; }
        public string FullName { get; set; }

    }
}

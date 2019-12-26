using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.CompanyModule
{
    public class ReferralEntity
    {
        public long ReferralID { get; set; }
        public long ContactID { get; set; }
        public long CustomerID { get; set; }
        public long EmployeeID { get; set; }
        public DateTime ReferralDate { get; set; }
        public DateTime? ReferralPaidDate { get; set; }
        public decimal ReferralAmount { get; set; }
        public int PayMethodID { get; set; }
        public string PayReference { get; set; }
        public long ReferredProjectNo { get; set; }
        public int ReferredProjectStatus { get; set; }
        public string ReferredCustomerName { get; set; }
        public decimal ReferredSystemSize { get; set; }
        public decimal ReferredBalOS { get; set; }
        public string ReferredByProjectNo { get; set; }
        public string ReferredByCustomerName { get; set; }
        public int ReferredByProjectStatus { get; set; }
        public decimal ReferredByBalOS { get; set; }
        public string ReferralNotes { get; set; }
        public bool IsRefPaid { get; set; }

        public int id { get; set; }

    }
}

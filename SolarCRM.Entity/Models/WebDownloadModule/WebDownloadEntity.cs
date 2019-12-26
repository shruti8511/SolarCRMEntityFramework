using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.WebDownloadModule
{
   public class WebDownloadEntity
    {
        public int WebDownloadID { get; set; }
        public string Customer { get; set; }
        public string ContFirst { get; set; }
        public string ContLast { get; set; }
        public string ContEmail { get; set; }
        public string CustPhone { get; set; }
        public string ContMobile { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostCode { get; set; }
        public string Source { get; set; }
        public string System { get; set; }
        public string Roof { get; set; }
        public string Angle { get; set; }
        public string Story { get; set; }
        public string HouseAge { get; set; }
        public string Notes { get; set; }
        public DateTime EntryDate { get; set; }
        public string PreferredTime { get; set; }
        public Boolean Uploaded { get; set; }
        public Boolean Duplicate { get; set; }
        public Boolean NotDuplicate { get; set; }
        public int SalesTeamID { get; set; }
        public int EmployeeID { get; set; }
        public int LinkID { get; set; }
        public Boolean FormatFixed { get; set; }
        public string upsize_ts { get; set; }
        public string SubSource { get; set; }
        public string PowerCompany { get; set; }
        public decimal LastPowerBill { get; set; }
    }
}

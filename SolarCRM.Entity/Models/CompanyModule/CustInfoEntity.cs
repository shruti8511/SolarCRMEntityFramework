using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.CompanyModule
{
    public class CustInfoEntity
    {
        public long CustInfoID { get; set; }
        public long CustomerID { get; set; }
        public long ContactID { get; set; }
        public string ContactName { get; set; }
        public string Description { get; set; }
        public DateTime FollowupDate { get; set; }
        public DateTime NextFollowupDate { get; set; }
        public long CustInfoEnteredBy { get; set; }
        public bool IsRead { get; set; }
        public bool IsClose { get; set; }
        public int FollowupType { get; set; } 

    }
}

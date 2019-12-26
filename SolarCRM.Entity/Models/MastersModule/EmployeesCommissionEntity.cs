using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
    public class EmployeesCommissionEntity
    {
        public int EmployeesCommissionID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeesCommission { get; set; }
        public string EmployeesComment { get; set; }
        public Boolean Active { get; set; }

    }
}

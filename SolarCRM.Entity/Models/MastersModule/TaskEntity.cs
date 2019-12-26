using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
    public class TaskEntity
    {
        public int TaskID { get; set; }
        public string Task { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public Boolean Active { get; set; }

        public int ProjectTeamID { get; set; }
        public int ProjectID { get; set; }    
        public int EmployeeID { get; set; }
        public DateTime CreatedOn { get; set; }
        public string EmployeeName { get; set; }
    }
}

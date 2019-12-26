using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SolarCRM.Entity.Models.EmployeeModule
{
    public class AspnetUserEntity
    {
        public string ApplicationId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string LoweredUserName { get; set; }
        public string MobileAlias { get; set; }
        public string IsAnonymous { get; set; }
        public string LastActivityDate { get; set; }
    }
}

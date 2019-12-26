using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.LoginModule
{
    public class LogInTrackEntity
    {
        public string ID { get; set; }
        public string UserId { get; set; }
        public DateTime LogInTime { get; set; }
        public DateTime LogOutTime { get; set; }
        public string IPAddress { get; set; }
        public bool IsSession { get; set; }
        public string UserName { get; set; }
        public string LoginDate { get; set; }    
    }
}

using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.LoginModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.LoginModule
{
    public class LoginManagement
    {
        public static LoginEntity SpUtilitiesGetDataStructById(string id)
        {
           return (new SolarCRM.DAL.Implementations.LoginModule.LoginSQL().SpUtilitiesGetDataStructById(id));
        }

        public static void tblLogInTrack_Insert(string UserId, string LogInTime, string IPAddress, string LogOutTime, string IsSession)
        {
            new SolarCRM.DAL.Implementations.LoginModule.LoginSQL().tblLogInTrack_Insert(UserId, LogInTime, IPAddress, LogOutTime, IsSession);
        }

        public static LogInTrackEntity tblLogInTrack_Select(string UserId, string IPAddress)
        {
            return (new SolarCRM.DAL.Implementations.LoginModule.LoginSQL().tblLogInTrack_Select(UserId, IPAddress));
        }

        public static bool tblLogInTrack_Update(string ID, string LogOutTime, string IsSession)
        {
            return (new SolarCRM.DAL.Implementations.LoginModule.LoginSQL().tblLogInTrack_Update(ID, LogOutTime, IsSession));
        }
        public static List<LogInTrackEntity> tblLogInTrack_SelectAll(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.LoginModule.LoginSQL().tblLogInTrack_SelectAll(CommonEntity, out Count));
        }
    }
}

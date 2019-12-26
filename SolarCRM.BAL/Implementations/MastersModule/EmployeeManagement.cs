using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.EmployeeModule;
using SolarCRM.Entity.Models.MastersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class EmployeeManagement
    {
       public static List<EmployeeEntity> tblEmployeeType_SelectForDropdown()
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployeeType_SelectForDropdown());
       }

       public static List<EmployeeEntity> tblEmployeeStatus_SelectForDropdown()
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployeeStatus_SelectForDropdown());
       }

       public static List<EmployeeEntity> tblCompanyLocations_ForDropdown()
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblCompanyLocations_ForDropdown());
       }

       public static List<EmployeeEntity> tblSalesTeam_ForDropdown()
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblSalesTeam_ForDropdown());
       }

       public static int aspnet_Users_Exists(string UserName)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().aspnet_Users_Exists(UserName));
       }

       public static List<EmployeeEntity> SpRolesGetDataByAsc()
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().SpRolesGetDataByAsc());
       }


       public static long tblEmployees_Insert(EmployeeEntity ObjEntity)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_Insert(ObjEntity));
       }

       public static void tblEmployees_Update_Userid(long EmployeeID, string userid)
       {
           new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_Update_Userid(EmployeeID, userid);
       }

       public static void tblEmployees_Update_Team(long EmployeeID, string SalesTeamID, string EmpType, Boolean LTeamOutDoor, Boolean LTeamCloser)
       {
           new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_Update_Team(EmployeeID, SalesTeamID, EmpType, LTeamOutDoor, LTeamCloser);
       }

       public static List<EmployeeEntity> tblEmployeesGetDataBySearch(PagingEntity CommonEntity, out int Count)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployeesGetDataBySearch(CommonEntity, out Count));
       }


       public static EmployeeEntity tblEmployees_SelectByyEmployeeID(int EmployeeID)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_SelectByyEmployeeID(EmployeeID));
       }

       public static void tblEmployees_Update(EmployeeEntity ObjEntity)
       {
           new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_Update(ObjEntity);
       }

       public static void tblEmployees_UpdatePermissions(EmployeeEntity ObjEntity)
       {
           new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_UpdatePermissions(ObjEntity);
       }

       public static void tblEmployees_UpdateReferences(EmployeeEntity ObjEntity)
       {
           new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_UpdateReferences(ObjEntity);
       }


       public static bool tblEmployees_UpdatePassword(string UserId, string Password)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_UpdatePassword(UserId, Password));
       }


        #region // Manoj Code

       public static EmployeeEntity tblEmployees_SelectByUserId(string userid)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_SelectByUserId(userid));
       }

       public static EmployeeEntity tblEmployees_SelectEmployeeID(string userid)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_SelectEmployeeID(userid));
       }

       public static EmployeeEntity tblEmployees_SelectBYEmployeeID(long EmployeeID)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_SelectBYEmployeeID(EmployeeID));
       }

       public static AspnetUserEntity aspnet_Users_SelectByUserId(string userid)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().aspnet_Users_SelectByUserId(userid));
       }

       public static bool aspnetUsers_Update_LastActivityDate(string userid)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().aspnetUsers_Update_LastActivityDate(userid));
       }

        #endregion


       public static EmployeeEntity tblEmployees_SelectActiveByEmployeeID(long EmployeeID)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_SelectActiveByEmployeeID(EmployeeID));
       }






       public static List<EmployeeEntity> tblEmployees_SelectASC(long EmployeeID, int ActiveEmp)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_SelectASC(EmployeeID, ActiveEmp));
       }

       public static EmployeeEntity tblEmployees_ManagerSelect(long EmployeeID)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_ManagerSelect(EmployeeID));
       }

       public static List<EmployeeEntity> tblEmployees_SelectInstaller()
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_SelectInstaller());
       }
       public static List<EmployeeEntity> tblEmployees_SelectInstallerDesigner()
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_SelectInstallerDesigner());
       }
       public static List<EmployeeEntity> tblEmployees_SelectInstallerElectrician()
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_SelectInstallerElectrician());
       }
       public static List<EmployeeEntity> tblEmployees_CheckInstDesigner(string userid)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_CheckInstDesigner(userid));
       }

       public static List<EmployeeEntity> tblEmployees_CheckInstElectrician(string userid)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_CheckInstElectrician(userid));
       }
       public static List<EmployeeEntity> aspnet_UsersInRoles_Select(string RoleId)
       {
           return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().aspnet_UsersInRoles_Select(RoleId));
       }
       public static ProjectCount tblEmployees_Count()
       {
            return (new SolarCRM.DAL.Implementations.MastersModule.EmployeeSQL().tblEmployees_Count());
       }
     
    }
}

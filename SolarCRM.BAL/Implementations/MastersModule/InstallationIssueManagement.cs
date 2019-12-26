using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class InstallationIssueManagement
    {

        public static void tblInstallationIssue_Insert(InstallationIssueEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InstallationIssueSQL().tblInstallationIssue_Insert(ObjEntity);
        }

        public static int tblInstallationIssue_Exists(string InstallationIssue)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InstallationIssueSQL().tblInstallationIssue_Exists(InstallationIssue));
        }

        public static List<InstallationIssueEntity> tblInstallationIssue_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InstallationIssueSQL().tblInstallationIssue_Select(CommonEntity, out Count));
        }

       

        public static InstallationIssueEntity tblInstallationIssue_ForEdit(int InstallationIssueID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InstallationIssueSQL().tblInstallationIssue_ForEdit(InstallationIssueID));
        }

        public static InstallationIssueEntity tblInstallationIssue_SelectForUpdate(string InstallationIssue, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InstallationIssueSQL().tblInstallationIssue_SelectForUpdate(InstallationIssue, Active));
        }

        public static void tblInstallationIssue_Update(InstallationIssueEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InstallationIssueSQL().tblInstallationIssue_Update(ObjEntity);
        }

        public static void tblInstallationIssue_Delete(int InstallationIssueID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InstallationIssueSQL().tblInstallationIssue_Delete(InstallationIssueID);
        }

        public static List<InstallationIssueEntity> tblInstallationIssue_SelectActive(int isactive, long InstallationIssueID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InstallationIssueSQL().tblInstallationIssue_SelectActive(InstallationIssueID, isactive));
        }

    }
}

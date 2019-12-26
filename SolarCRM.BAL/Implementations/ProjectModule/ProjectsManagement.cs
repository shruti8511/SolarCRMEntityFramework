using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.ProjectModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.ProjectModule
{
    public class ProjectsManagement
    {
        public static long tblProjects_Insert(ProjectsEntity ProEntity)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_Insert(ProEntity));
        }

        public static void tblTrackProjStatus_Insert(int ProjectStatusID,long success,long EmpID,int NumberPanels)
        {
            new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblTrackProjStatus_Insert(ProjectStatusID,success,EmpID,NumberPanels);
        }

        public static List<ProjectsEntity> tblProjects_SelectByCustomerID(PagingEntity CommonEntity,long CustomerID, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_SelectByCustomerID(CommonEntity,CustomerID, out Count));
        }

        public static ProjectsEntity tblProjects_SelectReferral(long ProjectNumber)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_SelectReferral(ProjectNumber));
        }

        public static void tblProjects_UpdateFormsSolar(long ProjectID)
        {
            new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_UpdateFormsSolar(ProjectID);
        }

        public static void tblProjects_UpdateFormsSolarUG(long ProjectID)
        {
            new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_UpdateFormsSolarUG(ProjectID);
        }


        public static ProjectsEntity tblProjects_SelectByProjectID(long ProjectID)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_SelectByProjectID(ProjectID));
        }



        public static void tblProjectsSalesInput_Insert(ProjectsEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectsSalesInput_Insert(ObjEntity);
        }

        public static int tblProjectsSalesInput_ProjectIDExists(long ProjectID)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectsSalesInput_ProjectIDExists(ProjectID));
        }


        public static List<ProjectsEntity> tblProjects_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_Select(CommonEntity, out Count));
        }

        public static List<ProjectsEntity> tblProjects_SelectSearch(PagingEntity CommonEntity, string Searchkeyword, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_SelectSearch(CommonEntity, Searchkeyword, out Count));
        }




        public static long tblProjectQuotes_Insert(long ProjectID,long ProjectNumber,long EmployeeID, decimal BasicSystemCost ,decimal TotalQuotePrice)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectQuotes_Insert(ProjectID, ProjectNumber, EmployeeID, BasicSystemCost, TotalQuotePrice));
        }
        public static long tblProjectsInstallationDocuments_Insert(long ProjectID, long ProjectNumber, string DocumentType)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, DocumentType ));
        }


        public static long tblProjectQuotes_UpdateProjectQuoteDoc(long ProjectQuoteID, string QuoteDoc)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectQuotes_UpdateProjectQuoteDoc(ProjectQuoteID, QuoteDoc));
        }

        public static long tblProjectsInstallationDocuments_Update(long ProjectInstallationLetterID, string QuoteDoc)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectsInstallationDocuments_Update(ProjectInstallationLetterID, QuoteDoc));
        }


        public static List<ProjectsEntity> tblProjectQuotes_SelectByProjectID(long ProjectID)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectQuotes_SelectByProjectID(ProjectID));
        }



        public static ProjectsEntity tblProjectsSalesInput_SelectByProjectID(long ProjectID)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectsSalesInput_SelectByProjectID(ProjectID));
        }

        public static void tblProjectsSalesInput_Update(ProjectsEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectsSalesInput_Update(ObjEntity);
        }
        public static ProjectsEntity tblProjectsSalesInputByProjectID(long ProjectID)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectsSalesInputByProjectID(ProjectID));
        }




        public static ProjectsEntity tblProjectQuotes_SelectByProjectQuoteID(int ProjectQuoteID)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectQuotes_SelectByProjectQuoteID(ProjectQuoteID));
        }


        public static bool tblProjects_UpdateInvoiceDoc(long ProjectID, long ProjectNumber)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_UpdateInvoiceDoc(ProjectID, ProjectNumber));
        }

        public static ProjectsEntity GetRoleIDByUserID(string userid)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().GetRoleIDByUserID(userid));
        }
        public static void tblProjectsInstallation_Insert(ProjectsEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectsInstallation_Insert(ObjEntity);
        }
        public static void tblProjectsInstallation_Update(ProjectsEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectsInstallation_Update(ObjEntity);
        }
        public static int tblProjectsInstallation_ProjectIDExists(long ProjectID)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectsInstallation_ProjectIDExists(ProjectID));
        }
        public static int tblProjectsNewInstallation_ProjectIDExists(long ProjectID)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectsNewInstallation_ProjectIDExists(ProjectID));
        }

        public static void tblProjectsNewInstallation_Insert(ProjectsEntityInstallation ObjEntity)
        {
            new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectsNewInstallation_Insert(ObjEntity);
        }
        public static void tblProjectsNewInstallation_Update(ProjectsEntityInstallation ObjEntity)
        {
            new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectsNewInstallation_Update(ObjEntity);
        }

        public static ProjectsEntity tblProjectsInstallationByProjectID(long ProjectID)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectsInstallationByProjectID(ProjectID));
        }
        public static ProjectsEntityInstallation tblProjectsNewInstallationByProjectID(long ProjectID)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjectsNewInstallationByProjectID(ProjectID));
        }

        public static List<ProjectsEntity> tblProjects_SelectInstallerProjects(PagingEntity CommonEntity, out int Count, string UserID)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_SelectInstallerProjects(CommonEntity, out Count, UserID));
        }
        public static List<ProjectsEntity> tblProjects_SelectSearchInstallerProjects(PagingEntity CommonEntity, string Searchkeyword, string Userid, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_SelectSearchInstallerProjects(CommonEntity, Searchkeyword, Userid, out Count));
        }
        public static List<ProjectsEntity> tblProjects_SelectAll(string userid)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_SelectAll(userid));
        }
        public static List<ProjectsEntity> tblProjects_SelectByProjectStatus(string UserID, string ProjectStatus)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_SelectByProjectStatus(UserID, ProjectStatus));
        }
        public static List<ProjectsEntity> tblProjects_SelectSearchByProjectStatus(string UserID, string ProjectStatus,string SearchKeyword,  PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_SelectSearchByProjectStatus(UserID, ProjectStatus,SearchKeyword, CommonEntity, out Count));
        }
        public static List<ProjectsEntity> tblProjects_SelectByProjectStatusForDropdown(string ProjectStatus, string userid)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_SelectByProjectStatusForDropdown(ProjectStatus, userid));
        }
        public static List<ProjectsEntity> tblProjects_SelectByProjectIDForQuote(long ProjectID)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_SelectByProjectIDForQuote(ProjectID));
        }
        public static ProjectsEntity tblProjects_SelectCustLogin(long ProjectNumber)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_SelectCustLogin(ProjectNumber));
        }
        public static ProjectsEntity tblProjects_SelectByProjectNumberCust(long ProjectNumber)
        {
            return (new SolarCRM.DAL.Implementations.ProjectModule.ProjectsSQL().tblProjects_SelectByProjectNumberCust(ProjectNumber));
        }

    }
}

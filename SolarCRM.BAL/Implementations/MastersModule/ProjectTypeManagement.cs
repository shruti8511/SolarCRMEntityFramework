using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
    public class ProjectTypeManagement
    {
        public static void tblProjectType_Insert(ProjectTypeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProjectTypeSQL().tblProjectType_Insert(ObjEntity);
        }

        public static int tblProjectType_Exists(string ProjectType)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectTypeSQL().tblProjectType_Exists(ProjectType));
        }

        public static List<ProjectTypeEntity> tblProjectType_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectTypeSQL().tblProjectType_Select(CommonEntity, out Count));
        }

        public static List<ProjectTypeEntity> tblProjectType_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectTypeSQL().tblProjectType_SelectActive());
        }

        public static ProjectTypeEntity tblProjectType_ForEdit(int ProjectTypeID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectTypeSQL().tblProjectType_ForEdit(ProjectTypeID));
        }

        public static ProjectTypeEntity tblProjectType_SelectForUpdate(string ProjectType, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectTypeSQL().tblProjectType_SelectForUpdate(ProjectType, Active));
        }

        public static void tblProjectType_Update(ProjectTypeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProjectTypeSQL().tblProjectType_Update(ObjEntity);
        }

        public static void tblProjectType_Delete(int ProjectTypeID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProjectTypeSQL().tblProjectType_Delete(ProjectTypeID);
        }



        public static ProjectCount tblProjectsStatusCount()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectTypeSQL().tblProjectsStatusCount());
        }

        public static LeadCount tblLeadCount()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectTypeSQL().tblLeadCount());
        }
         public static ProjectCount tblProjectsStatusCountForInstaller(string userid)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectTypeSQL().tblProjectsStatusCountForInstaller(userid));
        }

    }
}

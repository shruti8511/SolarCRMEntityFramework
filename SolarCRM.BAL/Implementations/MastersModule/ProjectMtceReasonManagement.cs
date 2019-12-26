using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class ProjectMtceReasonManagement
    {
        public static void tblProjectMtceReason_Insert(ProjectMtceReasonEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProjectMtceReasonSQL().tblProjectMtceReason_Insert(ObjEntity);
        }

        public static int tblProjectMtceReason_Exists(string ProjectMtceReason)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectMtceReasonSQL().tblProjectMtceReason_Exists(ProjectMtceReason));
        }

        public static List<ProjectMtceReasonEntity> tblProjectMtceReason_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectMtceReasonSQL().tblProjectMtceReason_Select(CommonEntity, out Count));
        }

        public static List<ProjectMtceReasonEntity> tblProjectMtceReason_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectMtceReasonSQL().tblProjectMtceReason_SelectActive());
        }

        public static ProjectMtceReasonEntity tblProjectMtceReason_ForEdit(int ProjectMtceReasonID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectMtceReasonSQL().tblProjectMtceReason_ForEdit(ProjectMtceReasonID));
        }

        public static ProjectMtceReasonEntity tblProjectMtceReason_SelectForUpdate(string ProjectMtceReason, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectMtceReasonSQL().tblProjectMtceReason_SelectForUpdate(ProjectMtceReason, Active));
        }

        public static void tblProjectMtceReason_Update(ProjectMtceReasonEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProjectMtceReasonSQL().tblProjectMtceReason_Update(ObjEntity);
        }

        public static void tblProjectMtceReason_Delete(int ProjectMtceReasonID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProjectMtceReasonSQL().tblProjectMtceReason_Delete(ProjectMtceReasonID);
        }

    }
}

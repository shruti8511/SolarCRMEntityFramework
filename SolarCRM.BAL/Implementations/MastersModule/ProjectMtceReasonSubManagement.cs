using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class ProjectMtceReasonSubManagement
    {
        public static void tblProjectMtceReasonSub_Insert(ProjectMtceReasonSubEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProjectMtceReasonSubSQL().tblProjectMtceReasonSub_Insert(ObjEntity);
        }

        public static int tblProjectMtceReasonSub_Exists(string ProjectMtceReasonSub)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectMtceReasonSubSQL().tblProjectMtceReasonSub_Exists(ProjectMtceReasonSub));
        }

        public static List<ProjectMtceReasonSubEntity> tblProjectMtceReasonSub_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectMtceReasonSubSQL().tblProjectMtceReasonSub_Select(CommonEntity, out Count));
        }

        public static List<ProjectMtceReasonSubEntity> tblProjectMtceReasonSub_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectMtceReasonSubSQL().tblProjectMtceReasonSub_SelectActive());
        }

        public static ProjectMtceReasonSubEntity tblProjectMtceReasonSub_ForEdit(int ProjectMtceReasonSubID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectMtceReasonSubSQL().tblProjectMtceReasonSub_ForEdit(ProjectMtceReasonSubID));
        }

        public static ProjectMtceReasonSubEntity tblProjectMtceReasonSub_SelectForUpdate(string ProjectMtceReasonSub, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectMtceReasonSubSQL().tblProjectMtceReasonSub_SelectForUpdate(ProjectMtceReasonSub, Active));
        }

        public static void tblProjectMtceReasonSub_Update(ProjectMtceReasonSubEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProjectMtceReasonSubSQL().tblProjectMtceReasonSub_Update(ObjEntity);
        }

        public static void tblProjectMtceReasonSub_Delete(int ProjectMtceReasonSubID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProjectMtceReasonSubSQL().tblProjectMtceReasonSub_Delete(ProjectMtceReasonSubID);
        }


    }
}

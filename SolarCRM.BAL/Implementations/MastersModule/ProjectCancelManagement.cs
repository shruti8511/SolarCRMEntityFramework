using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class ProjectCancelManagement
    {
        public static void tblProjectCancel_Insert(ProjectCancelEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProjectCancelSQL().tblProjectCancel_Insert(ObjEntity);
        }

        public static int tblProjectCancel_Exists(string ProjectCancel)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectCancelSQL().tblProjectCancel_Exists(ProjectCancel));
        }

        public static List<ProjectCancelEntity> tblProjectCancel_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectCancelSQL().tblProjectCancel_Select(CommonEntity, out Count));
        }

        //public static List<ProjectCancelEntity> tblProjectCancel_SelectActive()
        //{
        //    return (new SolarCRM.DAL.Implementations.MastersModule.ProjectCancelSQL().tblProjectCancel_SelectActive());
        //}

        public static ProjectCancelEntity tblProjectCancel_ForEdit(int ProjectCancelID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectCancelSQL().tblProjectCancel_ForEdit(ProjectCancelID));
        }

        public static ProjectCancelEntity tblProjectCancel_SelectForUpdate(string ProjectCancel, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectCancelSQL().tblProjectCancel_SelectForUpdate(ProjectCancel, Active));
        }

        public static void tblProjectCancel_Update(ProjectCancelEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProjectCancelSQL().tblProjectCancel_Update(ObjEntity);
        }

        public static void tblProjectCancel_Delete(int ProjectCancelID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProjectCancelSQL().tblProjectCancel_Delete(ProjectCancelID);
        }

    }
}

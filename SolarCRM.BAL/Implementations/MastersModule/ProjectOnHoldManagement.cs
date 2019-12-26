using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class ProjectOnHoldManagement
    {
        public static void tblProjectOnHold_Insert(ProjectOnHoldEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProjectOnHoldSQL().tblProjectOnHold_Insert(ObjEntity);
        }

        public static int tblProjectOnHold_Exists(string ProjectOnHold)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectOnHoldSQL().tblProjectOnHold_Exists(ProjectOnHold));
        }

        public static List<ProjectOnHoldEntity> tblProjectOnHold_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectOnHoldSQL().tblProjectOnHold_Select(CommonEntity, out Count));
        }

        //public static List<ProjectOnHoldEntity> tblProjectOnHold_SelectActive()
        //{
        //    return (new SolarCRM.DAL.Implementations.MastersModule.ProjectOnHoldSQL().tblProjectOnHold_SelectActive());
        //}

        public static ProjectOnHoldEntity tblProjectOnHold_ForEdit(int ProjectOnHoldID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectOnHoldSQL().tblProjectOnHold_ForEdit(ProjectOnHoldID));
        }

        public static ProjectOnHoldEntity tblProjectOnHold_SelectForUpdate(string ProjectOnHold, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProjectOnHoldSQL().tblProjectOnHold_SelectForUpdate(ProjectOnHold, Active));
        }

        public static void tblProjectOnHold_Update(ProjectOnHoldEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProjectOnHoldSQL().tblProjectOnHold_Update(ObjEntity);
        }

        public static void tblProjectOnHold_Delete(int ProjectOnHoldID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProjectOnHoldSQL().tblProjectOnHold_Delete(ProjectOnHoldID);
        }

    }
}

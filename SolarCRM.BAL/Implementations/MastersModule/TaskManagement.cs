using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class TaskManagement
    {
        public static void tblTask_Insert(TaskEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblTask_Insert(ObjEntity);
        }

        public static int tblTask_Exists(string Task)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblTask_Exists(Task));
        }

        public static List<TaskEntity> tblTask_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblTask_Select(CommonEntity, out Count));
        }

        public static List<TaskEntity> tblTask_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblTask_SelectActive());
        }

        public static TaskEntity tblTask_ForEdit(int TaskID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblTask_ForEdit(TaskID));
        }

        public static TaskEntity tblTask_SelectForUpdate(string Task, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblTask_SelectForUpdate(Task, Active));
        }

        public static void tblTask_Update(TaskEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblTask_Update(ObjEntity);
        }

        public static void tblTask_Delete(int TaskID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblTask_Delete(TaskID);
        }




        public static List<TaskEntity> tblTask_SelectList()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblTask_SelectList());
        }



        public static void tblProjectTeam_Insert(TaskEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblProjectTeam_Insert(ObjEntity);
        }

        public static List<TaskEntity> tblProjectTeam_Select(long ProjectID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblProjectTeam_Select(ProjectID));
        }
        public static List<TaskEntity> tblTask_SelectAll()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblTask_SelectAll());
        }
        public static TaskEntity tblTask_SelectByTaskID(int TaskID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblTask_SelectByTaskID(TaskID));
        }


        public static int tblProjectTeam_ProjectIDExists(long ProjectID, int TaskID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblProjectTeam_ProjectIDExists(ProjectID, TaskID));
        }




        public static TaskEntity tblProjectTeam_SelectByProjectID(long ProjectID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblProjectTeam_SelectByProjectID(ProjectID));
        }


        public static void tblProjectTeam_Update(TaskEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblProjectTeam_Update(ObjEntity);
        }

        public static TaskEntity tblProjectTeam_SelectByTaskID(long ProjectID, int TaskID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.TaskSQL().tblProjectTeam_SelectByTaskID(ProjectID, TaskID));
        }
       

    }
}

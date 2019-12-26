
namespace SolarCRM.DAL.Implementations.MastersModule
{
    using SolarCRM.Entity.Models.Common;
    using SolarCRM.Entity.Models.MastersModule;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TaskSQL : BaseSqlManager
    {
        public virtual void tblTask_Insert(TaskEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblTask_Insert";
            cmdAdd.Parameters.AddWithValue("@Task", ObjEntity.Task);
            cmdAdd.Parameters.AddWithValue("@RoleId", ObjEntity.RoleId);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblTask_Exists(string Task)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblTask_Exists";
            cmdGet.Parameters.AddWithValue("@Task", Task);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "Task");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<TaskEntity> tblTask_Select(PagingEntity CommonEntity, out int Count)
        {
            List<TaskEntity> lstLocation = new List<TaskEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblTask_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                TaskEntity objEntity = new TaskEntity();
                objEntity.TaskID = GetInt32(dr, "TaskID");
                objEntity.Task = GetTextValue(dr, "Task");
                objEntity.RoleName = GetTextValue(dr, "RoleName");                
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<TaskEntity> tblTask_SelectActive()
        {
            List<TaskEntity> lstLocation = new List<TaskEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblTask_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                TaskEntity objEntity = new TaskEntity();
                objEntity.TaskID = GetInt32(dr, "TaskID");
                objEntity.Task = GetTextValue(dr, "Task");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual TaskEntity tblTask_ForEdit(int TaskID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblTask_ForEdit";
            cmdGet.Parameters.AddWithValue("@TaskID", TaskID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            TaskEntity objEntity = new TaskEntity();
            while (dr.Read())
            {
                objEntity.TaskID = GetInt32(dr, "TaskID");
                objEntity.Task = GetTextValue(dr, "Task");
                objEntity.RoleId = GetTextValue(dr, "RoleId");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual TaskEntity tblTask_SelectForUpdate(string Task, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblTask_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@Task", Task);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            TaskEntity objEntity = new TaskEntity();
            while (dr.Read())
            {
                objEntity.Task = GetTextValue(dr, "Task");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblTask_Update(TaskEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblTask_Update";
            cmdAdd.Parameters.AddWithValue("@TaskID", ObjEntity.TaskID);
            cmdAdd.Parameters.AddWithValue("@Task", ObjEntity.Task);
            cmdAdd.Parameters.AddWithValue("@RoleId", ObjEntity.RoleId);           
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblTask_Delete(int TaskID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblTask_Delete";
            cmdDel.Parameters.AddWithValue("@TaskID", TaskID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }



        public virtual List<TaskEntity> tblTask_SelectList()
        {
            List<TaskEntity> lstLocation = new List<TaskEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblTask_SelectList";
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                TaskEntity objEntity = new TaskEntity();
                objEntity.TaskID = GetInt32(dr, "TaskID");
                objEntity.Task = GetTextValue(dr, "Task");
                objEntity.RoleId = GetTextValue(dr, "RoleId");             
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }


        public virtual void tblProjectTeam_Insert(TaskEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectTeam_Insert";
            cmdAdd.Parameters.AddWithValue("@RoleId", ObjEntity.RoleId);
            cmdAdd.Parameters.AddWithValue("@ProjectID", ObjEntity.ProjectID);
            cmdAdd.Parameters.AddWithValue("@TaskID", ObjEntity.TaskID);
            cmdAdd.Parameters.AddWithValue("@EmployeeID", ObjEntity.EmployeeID);
            cmdAdd.Parameters.AddWithValue("@CreatedOn", ObjEntity.CreatedOn);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }





        public virtual List<TaskEntity> tblProjectTeam_Select(long ProjectID)
        {
            List<TaskEntity> lstLocation = new List<TaskEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectTeam_Select";
            cmdGet.Parameters.AddWithValue("@ProjectID", ProjectID);        
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                TaskEntity objEntity = new TaskEntity();
                objEntity.ProjectTeamID = GetInt32(dr, "ProjectTeamID");
                objEntity.TaskID = GetInt32(dr, "TaskID");
                objEntity.Task = GetTextValue(dr, "Task");
                objEntity.ProjectID = GetInt32(dr, "ProjectID");
                objEntity.EmployeeID = GetInt32(dr, "EmployeeID");
                objEntity.EmployeeName = GetTextValue(dr, "EmployeeName");  
                objEntity.CreatedOn = GetDateTime(dr, "CreatedOn");
                lstLocation.Add(objEntity);
            }
            dr.Close();         
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<TaskEntity> tblTask_SelectAll()
        {
            List<TaskEntity> lstLocation = new List<TaskEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblTask_SelectAll";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                TaskEntity objEntity = new TaskEntity();

                objEntity.TaskID = GetInt32(dr, "TaskID");
                objEntity.Task = GetTextValue(dr, "Task");
                objEntity.RoleId = GetTextValue(dr, "RoleId");
                objEntity.Active = GetBoolean(dr, "Active");
                objEntity.EmployeeName = GetTextValue(dr, "EmployeeName");
             
              

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
        public virtual TaskEntity tblTask_SelectByTaskID(int TaskID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblTask_SelectByTaskID";
            cmdGet.Parameters.AddWithValue("@TaskID", TaskID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            TaskEntity details = new TaskEntity();
            while (dr.Read())
            {
                details.TaskID = GetInt32(dr, "TaskID");
                details.RoleId = GetTextValue(dr, "RoleId");
            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }



        public virtual int tblProjectTeam_ProjectIDExists(long ProjectID, int TaskID)
        {
            int ProjectTeamID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectTeam_ProjectIDExists";
            cmdGet.Parameters.AddWithValue("@ProjectID", ProjectID);
            cmdGet.Parameters.AddWithValue("@TaskID", TaskID);
            //  cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectTeamID = GetInt32(dr, "ProjectTeamID");
            }
            dr.Close();
            ForceCloseConnection();
            return ProjectTeamID;

        }





        public virtual TaskEntity tblProjectTeam_SelectByProjectID(long ProjectID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectTeam_SelectByProjectID";
            cmdGet.Parameters.AddWithValue("@ProjectID", ProjectID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            TaskEntity details = new TaskEntity();
            while (dr.Read())
            {
                details.ProjectTeamID = GetInt32(dr, "ProjectTeamID");
                details.TaskID = GetInt32(dr, "TaskID");
                details.ProjectID = GetInt32(dr, "ProjectID");
                details.RoleId = GetTextValue(dr, "RoleId");
                details.EmployeeID = GetInt32(dr, "EmployeeID");
            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }


        public virtual void tblProjectTeam_Update(TaskEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectTeam_Update";
            cmdAdd.Parameters.AddWithValue("@ProjectTeamID", ObjEntity.ProjectTeamID);
            cmdAdd.Parameters.AddWithValue("@RoleId", ObjEntity.RoleId);
            cmdAdd.Parameters.AddWithValue("@TaskID", ObjEntity.TaskID);
            cmdAdd.Parameters.AddWithValue("@EmployeeID", ObjEntity.EmployeeID);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual TaskEntity tblProjectTeam_SelectByTaskID(long ProjectID, int TaskID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectTeam_SelectByTaskID";
            cmdGet.Parameters.AddWithValue("@ProjectID", ProjectID);
            cmdGet.Parameters.AddWithValue("@TaskID", TaskID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            TaskEntity details = new TaskEntity();
            while (dr.Read())
            {
                details.ProjectTeamID = GetInt32(dr, "ProjectTeamID");
                details.TaskID = GetInt32(dr, "TaskID");
                details.ProjectID = GetInt32(dr, "ProjectID");
                details.RoleId = GetTextValue(dr, "RoleId");
                details.EmployeeID = GetInt32(dr, "EmployeeID");
            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }



    }
}


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

    public class ProjectMtceReasonSQL : BaseSqlManager
    {
        public virtual void tblProjectMtceReason_Insert(ProjectMtceReasonEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectMtceReason_Insert";
            cmdAdd.Parameters.AddWithValue("@ProjectMtceReason", ObjEntity.ProjectMtceReason);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblProjectMtceReason_Exists(string ProjectMtceReason)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectMtceReason_Exists";
            cmdGet.Parameters.AddWithValue("@ProjectMtceReason", ProjectMtceReason);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "ProjectMtceReason");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<ProjectMtceReasonEntity> tblProjectMtceReason_Select(PagingEntity CommonEntity, out int Count)
        {
            List<ProjectMtceReasonEntity> lstLocation = new List<ProjectMtceReasonEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectMtceReason_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectMtceReasonEntity objEntity = new ProjectMtceReasonEntity();
                objEntity.ProjectMtceReasonID = GetInt32(dr, "ProjectMtceReasonID");
                objEntity.ProjectMtceReason = GetTextValue(dr, "ProjectMtceReason");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<ProjectMtceReasonEntity> tblProjectMtceReason_SelectActive()
        {
            List<ProjectMtceReasonEntity> lstLocation = new List<ProjectMtceReasonEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectMtceReason_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectMtceReasonEntity objEntity = new ProjectMtceReasonEntity();
                objEntity.ProjectMtceReasonID = GetInt32(dr, "ProjectMtceReasonID");
                objEntity.ProjectMtceReason = GetTextValue(dr, "ProjectMtceReason");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual ProjectMtceReasonEntity tblProjectMtceReason_ForEdit(int ProjectMtceReasonID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectMtceReason_ForEdit";
            cmdGet.Parameters.AddWithValue("@ProjectMtceReasonID", ProjectMtceReasonID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectMtceReasonEntity objEntity = new ProjectMtceReasonEntity();
            while (dr.Read())
            {
                objEntity.ProjectMtceReasonID = GetInt32(dr, "ProjectMtceReasonID");
                objEntity.ProjectMtceReason = GetTextValue(dr, "ProjectMtceReason");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual ProjectMtceReasonEntity tblProjectMtceReason_SelectForUpdate(string ProjectMtceReason, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectMtceReason_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@ProjectMtceReason", ProjectMtceReason);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectMtceReasonEntity objEntity = new ProjectMtceReasonEntity();
            while (dr.Read())
            {
                objEntity.ProjectMtceReason = GetTextValue(dr, "ProjectMtceReason");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblProjectMtceReason_Update(ProjectMtceReasonEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectMtceReason_Update";
            cmdAdd.Parameters.AddWithValue("@ProjectMtceReasonID", ObjEntity.ProjectMtceReasonID);
            cmdAdd.Parameters.AddWithValue("@ProjectMtceReason", ObjEntity.ProjectMtceReason);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblProjectMtceReason_Delete(int ProjectMtceReasonID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblProjectMtceReason_Delete";
            cmdDel.Parameters.AddWithValue("@ProjectMtceReasonID", ProjectMtceReasonID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

    }
}

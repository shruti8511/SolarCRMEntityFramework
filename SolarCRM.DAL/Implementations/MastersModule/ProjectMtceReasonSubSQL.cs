
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

    public class ProjectMtceReasonSubSQL : BaseSqlManager
    {
        public virtual void tblProjectMtceReasonSub_Insert(ProjectMtceReasonSubEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectMtceReasonSub_Insert";
            cmdAdd.Parameters.AddWithValue("@ProjectMtceReasonSub", ObjEntity.ProjectMtceReasonSub);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblProjectMtceReasonSub_Exists(string ProjectMtceReasonSub)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectMtceReasonSub_Exists";
            cmdGet.Parameters.AddWithValue("@ProjectMtceReasonSub", ProjectMtceReasonSub);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "ProjectMtceReasonSub");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<ProjectMtceReasonSubEntity> tblProjectMtceReasonSub_Select(PagingEntity CommonEntity, out int Count)
        {
            List<ProjectMtceReasonSubEntity> lstLocation = new List<ProjectMtceReasonSubEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectMtceReasonSub_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectMtceReasonSubEntity objEntity = new ProjectMtceReasonSubEntity();
                objEntity.ProjectMtceReasonSubID = GetInt32(dr, "ProjectMtceReasonSubID");
                objEntity.ProjectMtceReasonSub = GetTextValue(dr, "ProjectMtceReasonSub");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<ProjectMtceReasonSubEntity> tblProjectMtceReasonSub_SelectActive()
        {
            List<ProjectMtceReasonSubEntity> lstLocation = new List<ProjectMtceReasonSubEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectMtceReasonSub_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectMtceReasonSubEntity objEntity = new ProjectMtceReasonSubEntity();
                objEntity.ProjectMtceReasonSubID = GetInt32(dr, "ProjectMtceReasonSubID");
                objEntity.ProjectMtceReasonSub = GetTextValue(dr, "ProjectMtceReasonSub");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual ProjectMtceReasonSubEntity tblProjectMtceReasonSub_ForEdit(int ProjectMtceReasonSubID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectMtceReasonSub_ForEdit";
            cmdGet.Parameters.AddWithValue("@ProjectMtceReasonSubID", ProjectMtceReasonSubID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectMtceReasonSubEntity objEntity = new ProjectMtceReasonSubEntity();
            while (dr.Read())
            {
                objEntity.ProjectMtceReasonSubID = GetInt32(dr, "ProjectMtceReasonSubID");
                objEntity.ProjectMtceReasonSub = GetTextValue(dr, "ProjectMtceReasonSub");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual ProjectMtceReasonSubEntity tblProjectMtceReasonSub_SelectForUpdate(string ProjectMtceReasonSub, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectMtceReasonSub_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@ProjectMtceReasonSub", ProjectMtceReasonSub);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectMtceReasonSubEntity objEntity = new ProjectMtceReasonSubEntity();
            while (dr.Read())
            {
                objEntity.ProjectMtceReasonSub = GetTextValue(dr, "ProjectMtceReasonSub");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblProjectMtceReasonSub_Update(ProjectMtceReasonSubEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectMtceReasonSub_Update";
            cmdAdd.Parameters.AddWithValue("@ProjectMtceReasonSubID", ObjEntity.ProjectMtceReasonSubID);
            cmdAdd.Parameters.AddWithValue("@ProjectMtceReasonSub", ObjEntity.ProjectMtceReasonSub);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblProjectMtceReasonSub_Delete(int ProjectMtceReasonSubID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblProjectMtceReasonSub_Delete";
            cmdDel.Parameters.AddWithValue("@ProjectMtceReasonSubID", ProjectMtceReasonSubID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

    }
}

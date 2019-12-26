

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

    public class ProjectTypeSQL : BaseSqlManager
    {
        public virtual void tblProjectType_Insert(ProjectTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectType_Insert";
            cmdAdd.Parameters.AddWithValue("@ProjectType", ObjEntity.ProjectType);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblProjectType_Exists(string ProjectType)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectType_Exists";
            cmdGet.Parameters.AddWithValue("@ProjectType", ProjectType);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "ProjectType");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<ProjectTypeEntity> tblProjectType_Select(PagingEntity CommonEntity, out int Count)
        {
            List<ProjectTypeEntity> lstLocation = new List<ProjectTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectType_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectTypeEntity objEntity = new ProjectTypeEntity();
                objEntity.ProjectTypeID = GetInt32(dr, "ProjectTypeID");
                objEntity.ProjectType = GetTextValue(dr, "ProjectType");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<ProjectTypeEntity> tblProjectType_SelectActive()
        {
            List<ProjectTypeEntity> lstLocation = new List<ProjectTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectType_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectTypeEntity objEntity = new ProjectTypeEntity();
                objEntity.ProjectTypeID = GetInt32(dr, "ProjectTypeID");
                objEntity.ProjectType = GetTextValue(dr, "ProjectType");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual ProjectTypeEntity tblProjectType_ForEdit(int ProjectTypeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectType_ForEdit";
            cmdGet.Parameters.AddWithValue("@ProjectTypeID", ProjectTypeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectTypeEntity objEntity = new ProjectTypeEntity();
            while (dr.Read())
            {
                objEntity.ProjectTypeID = GetInt32(dr, "ProjectTypeID");
                objEntity.ProjectType = GetTextValue(dr, "ProjectType");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual ProjectTypeEntity tblProjectType_SelectForUpdate(string ProjectType, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectType_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@ProjectType", ProjectType);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectTypeEntity objEntity = new ProjectTypeEntity();
            while (dr.Read())
            {
                objEntity.ProjectType = GetTextValue(dr, "ProjectType");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblProjectType_Update(ProjectTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectType_Update";
            cmdAdd.Parameters.AddWithValue("@ProjectTypeID", ObjEntity.ProjectTypeID);
            cmdAdd.Parameters.AddWithValue("@ProjectType", ObjEntity.ProjectType);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblProjectType_Delete(int ProjectTypeID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblProjectType_Delete";
            cmdDel.Parameters.AddWithValue("@ProjectTypeID", ProjectTypeID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }





        public virtual ProjectCount tblProjectsStatusCount()
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectsStatusCount";
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectCount objEntity = new ProjectCount();
            while (dr.Read())
            {
                objEntity.Planned = GetInt32(dr, "Planned");
                objEntity.Active = GetInt32(dr, "Active");
                objEntity.OnHold = GetInt32(dr, "OnHold");
                objEntity.Complete = GetInt32(dr, "Complete");
                objEntity.Cancelled = GetInt32(dr, "Cancelled");

                objEntity.wPlanned = GetInt32(dr, "wPlanned");
                objEntity.wActive = GetInt32(dr, "wActive");
                objEntity.wOnHold = GetInt32(dr, "wOnHold");
                objEntity.wComplete = GetInt32(dr, "wComplete");
                objEntity.wCancelled = GetInt32(dr, "wCancelled");

                objEntity.mPlanned = GetInt32(dr, "mPlanned");
                objEntity.mActive = GetInt32(dr, "mActive");
                objEntity.mOnHold = GetInt32(dr, "mOnHold");
                objEntity.mComplete = GetInt32(dr, "mComplete");
                objEntity.mCancelled = GetInt32(dr, "mCancelled");



            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }
        public virtual LeadCount tblLeadCount()
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblLeadCount";
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            LeadCount objEntity = new LeadCount();
            while (dr.Read())
            {
                objEntity.Lead = GetInt32(dr, "Lead");
                objEntity.Potential = GetInt32(dr, "Potential");

            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }
        public virtual ProjectCount tblProjectsStatusCountForInstaller(string userid)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectsStatusCountForInstaller";
            cmdGet.Parameters.AddWithValue("@userid", userid);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectCount objEntity = new ProjectCount();
            while (dr.Read())
            {
                objEntity.OnHold = GetInt32(dr, "Pending");
                objEntity.Complete = GetInt32(dr, "Completed");
                objEntity.Total = GetInt32(dr, "Total");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }



    }
}

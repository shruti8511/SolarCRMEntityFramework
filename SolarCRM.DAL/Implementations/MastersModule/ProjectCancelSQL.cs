
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

    public class ProjectCancelSQL : BaseSqlManager
    {
        public virtual void tblProjectCancel_Insert(ProjectCancelEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectCancel_Insert";
            cmdAdd.Parameters.AddWithValue("@ProjectCancel", ObjEntity.ProjectCancel);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblProjectCancel_Exists(string ProjectCancel)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectCancel_Exists";
            cmdGet.Parameters.AddWithValue("@ProjectCancel", ProjectCancel);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "ProjectCancel");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<ProjectCancelEntity> tblProjectCancel_Select(PagingEntity CommonEntity, out int Count)
        {
            List<ProjectCancelEntity> lstLocation = new List<ProjectCancelEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectCancel_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectCancelEntity objEntity = new ProjectCancelEntity();
                objEntity.ProjectCancelID = GetInt32(dr, "ProjectCancelID");
                objEntity.ProjectCancel = GetTextValue(dr, "ProjectCancel");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        //public virtual List<ProjectCancelEntity> tblProjectCancel_SelectActive()
        //{
        //    List<ProjectCancelEntity> lstLocation = new List<ProjectCancelEntity>();
        //    SqlCommand cmdGet = new SqlCommand();
        //    cmdGet.CommandType = CommandType.StoredProcedure;
        //    cmdGet.CommandText = "tblProjectCancel_SelectActive";

        //    SqlDataReader dr = ExecuteDataReader(cmdGet);
        //    while (dr.Read())
        //    {
        //        ProjectCancelEntity objEntity = new ProjectCancelEntity();
        //        objEntity.ProjectCancelID = GetInt32(dr, "ProjectCancelID");
        //        objEntity.ProjectCancel = GetTextValue(dr, "ProjectCancel");

        //        lstLocation.Add(objEntity);
        //    }
        //    dr.Close();
        //    ForceCloseConnection();
        //    return lstLocation;
        //}

        public virtual ProjectCancelEntity tblProjectCancel_ForEdit(int ProjectCancelID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectCancel_ForEdit";
            cmdGet.Parameters.AddWithValue("@ProjectCancelID", ProjectCancelID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectCancelEntity objEntity = new ProjectCancelEntity();
            while (dr.Read())
            {
                objEntity.ProjectCancelID = GetInt32(dr, "ProjectCancelID");
                objEntity.ProjectCancel = GetTextValue(dr, "ProjectCancel");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual ProjectCancelEntity tblProjectCancel_SelectForUpdate(string ProjectCancel, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectCancel_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@ProjectCancel", ProjectCancel);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectCancelEntity objEntity = new ProjectCancelEntity();
            while (dr.Read())
            {
                objEntity.ProjectCancel = GetTextValue(dr, "ProjectCancel");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblProjectCancel_Update(ProjectCancelEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectCancel_Update";
            cmdAdd.Parameters.AddWithValue("@ProjectCancelID", ObjEntity.ProjectCancelID);
            cmdAdd.Parameters.AddWithValue("@ProjectCancel", ObjEntity.ProjectCancel);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblProjectCancel_Delete(int ProjectCancelID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblProjectCancel_Delete";
            cmdDel.Parameters.AddWithValue("@ProjectCancelID", ProjectCancelID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

    }
}

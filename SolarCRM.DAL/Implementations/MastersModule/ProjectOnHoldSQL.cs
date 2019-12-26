
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

    public class ProjectOnHoldSQL : BaseSqlManager
    {
        public virtual void tblProjectOnHold_Insert(ProjectOnHoldEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectOnHold_Insert";
            cmdAdd.Parameters.AddWithValue("@ProjectOnHold", ObjEntity.ProjectOnHold);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblProjectOnHold_Exists(string ProjectOnHold)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectOnHold_Exists";
            cmdGet.Parameters.AddWithValue("@ProjectOnHold", ProjectOnHold);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "ProjectOnHold");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<ProjectOnHoldEntity> tblProjectOnHold_Select(PagingEntity CommonEntity, out int Count)
        {
            List<ProjectOnHoldEntity> lstLocation = new List<ProjectOnHoldEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectOnHold_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectOnHoldEntity objEntity = new ProjectOnHoldEntity();
                objEntity.ProjectOnHoldID = GetInt32(dr, "ProjectOnHoldID");
                objEntity.ProjectOnHold = GetTextValue(dr, "ProjectOnHold");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        //public virtual List<ProjectOnHoldEntity> tblProjectOnHold_SelectActive()
        //{
        //    List<ProjectOnHoldEntity> lstLocation = new List<ProjectOnHoldEntity>();
        //    SqlCommand cmdGet = new SqlCommand();
        //    cmdGet.CommandType = CommandType.StoredProcedure;
        //    cmdGet.CommandText = "tblProjectOnHold_SelectActive";

        //    SqlDataReader dr = ExecuteDataReader(cmdGet);
        //    while (dr.Read())
        //    {
        //        ProjectOnHoldEntity objEntity = new ProjectOnHoldEntity();
        //        objEntity.ProjectOnHoldID = GetInt32(dr, "ProjectOnHoldID");
        //        objEntity.ProjectOnHold = GetTextValue(dr, "ProjectOnHold");

        //        lstLocation.Add(objEntity);
        //    }
        //    dr.Close();
        //    ForceCloseConnection();
        //    return lstLocation;
        //}

        public virtual ProjectOnHoldEntity tblProjectOnHold_ForEdit(int ProjectOnHoldID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectOnHold_ForEdit";
            cmdGet.Parameters.AddWithValue("@ProjectOnHoldID", ProjectOnHoldID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectOnHoldEntity objEntity = new ProjectOnHoldEntity();
            while (dr.Read())
            {
                objEntity.ProjectOnHoldID = GetInt32(dr, "ProjectOnHoldID");
                objEntity.ProjectOnHold = GetTextValue(dr, "ProjectOnHold");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual ProjectOnHoldEntity tblProjectOnHold_SelectForUpdate(string ProjectOnHold, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectOnHold_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@ProjectOnHold", ProjectOnHold);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectOnHoldEntity objEntity = new ProjectOnHoldEntity();
            while (dr.Read())
            {
                objEntity.ProjectOnHold = GetTextValue(dr, "ProjectOnHold");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblProjectOnHold_Update(ProjectOnHoldEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectOnHold_Update";
            cmdAdd.Parameters.AddWithValue("@ProjectOnHoldID", ObjEntity.ProjectOnHoldID);
            cmdAdd.Parameters.AddWithValue("@ProjectOnHold", ObjEntity.ProjectOnHold);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblProjectOnHold_Delete(int ProjectOnHoldID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblProjectOnHold_Delete";
            cmdDel.Parameters.AddWithValue("@ProjectOnHoldID", ProjectOnHoldID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

    }
}

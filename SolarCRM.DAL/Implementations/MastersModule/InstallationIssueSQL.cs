
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

    public class InstallationIssueSQL : BaseSqlManager
    {
        public virtual void tblInstallationIssue_Insert(InstallationIssueEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblInstallationIssue_Insert";
            cmdAdd.Parameters.AddWithValue("@InstallationIssue", ObjEntity.InstallationIssue);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblInstallationIssue_Exists(string InstallationIssue)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInstallationIssue_Exists";
            cmdGet.Parameters.AddWithValue("@InstallationIssue", InstallationIssue);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "InstallationIssue");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<InstallationIssueEntity> tblInstallationIssue_Select(PagingEntity CommonEntity, out int Count)
        {
            List<InstallationIssueEntity> lstLocation = new List<InstallationIssueEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInstallationIssue_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                InstallationIssueEntity objEntity = new InstallationIssueEntity();
                objEntity.InstallationIssueID = GetInt32(dr, "InstallationIssueID");
                objEntity.InstallationIssue = GetTextValue(dr, "InstallationIssue");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        //public virtual List<InstallationIssueEntity> tblInstallationIssue_SelectActive()
        //{
        //    List<InstallationIssueEntity> lstLocation = new List<InstallationIssueEntity>();
        //    SqlCommand cmdGet = new SqlCommand();
        //    cmdGet.CommandType = CommandType.StoredProcedure;
        //    cmdGet.CommandText = "tblInstallationIssue_SelectActive";

        //    SqlDataReader dr = ExecuteDataReader(cmdGet);
        //    while (dr.Read())
        //    {
        //        InstallationIssueEntity objEntity = new InstallationIssueEntity();
        //        objEntity.InstallationIssueID = GetInt32(dr, "InstallationIssueID");
        //        objEntity.InstallationIssue = GetTextValue(dr, "InstallationIssue");

        //        lstLocation.Add(objEntity);
        //    }
        //    dr.Close();
        //    ForceCloseConnection();
        //    return lstLocation;
        //}

        public virtual InstallationIssueEntity tblInstallationIssue_ForEdit(int InstallationIssueID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInstallationIssue_ForEdit";
            cmdGet.Parameters.AddWithValue("@InstallationIssueID", InstallationIssueID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            InstallationIssueEntity objEntity = new InstallationIssueEntity();
            while (dr.Read())
            {
                objEntity.InstallationIssueID = GetInt32(dr, "InstallationIssueID");
                objEntity.InstallationIssue = GetTextValue(dr, "InstallationIssue");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual InstallationIssueEntity tblInstallationIssue_SelectForUpdate(string InstallationIssue, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInstallationIssue_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@InstallationIssue", InstallationIssue);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            InstallationIssueEntity objEntity = new InstallationIssueEntity();
            while (dr.Read())
            {
                objEntity.InstallationIssue = GetTextValue(dr, "InstallationIssue");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblInstallationIssue_Update(InstallationIssueEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblInstallationIssue_Update";
            cmdAdd.Parameters.AddWithValue("@InstallationIssueID", ObjEntity.InstallationIssueID);
            cmdAdd.Parameters.AddWithValue("@InstallationIssue", ObjEntity.InstallationIssue);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblInstallationIssue_Delete(int InstallationIssueID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblInstallationIssue_Delete";
            cmdDel.Parameters.AddWithValue("@InstallationIssueID", InstallationIssueID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }
        public virtual List<InstallationIssueEntity> tblInstallationIssue_SelectActive(long InstallationIssueID, int isactive)
        {
            List<InstallationIssueEntity> lstLocation = new List<InstallationIssueEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.Parameters.AddWithValue("@isactive", isactive);
            cmdGet.Parameters.AddWithValue("@InstallationIssueID", InstallationIssueID);

            cmdGet.CommandText = "tblInstallationIssue_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                InstallationIssueEntity objEntity = new InstallationIssueEntity();
                objEntity.InstallationIssueID = GetInt32(dr, "InstallationIssueID");
                objEntity.InstallationIssue = GetTextValue(dr, "InstallationIssue");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
    }
}


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

    public class SalesTeamSQL : BaseSqlManager
    {
        public virtual void tblSalesTeam_Insert(SalesTeamEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblSalesTeam_Insert";
            cmdAdd.Parameters.AddWithValue("@SalesTeam", ObjEntity.SalesTeam);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);           
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblSalesTeam_Exists(string SalesTeam)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblSalesTeam_Exists";
            cmdGet.Parameters.AddWithValue("@SalesTeam", SalesTeam);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "SalesTeam");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<SalesTeamEntity> tblSalesTeam_Select(PagingEntity CommonEntity, out int Count)
        {
            List<SalesTeamEntity> lstLocation = new List<SalesTeamEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblSalesTeam_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                SalesTeamEntity objEntity = new SalesTeamEntity();
                objEntity.SalesTeamID = GetInt32(dr, "SalesTeamID");
                objEntity.SalesTeam = GetTextValue(dr, "SalesTeam");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<SalesTeamEntity> tblSalesTeam_SelectActive()
        {
            List<SalesTeamEntity> lstLocation = new List<SalesTeamEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblSalesTeam_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                SalesTeamEntity objEntity = new SalesTeamEntity();
                objEntity.SalesTeamID = GetInt32(dr, "SalesTeamID");
                objEntity.SalesTeam = GetTextValue(dr, "SalesTeam");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual SalesTeamEntity tblSalesTeam_ForEdit(int SalesTeamID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblSalesTeam_ForEdit";
            cmdGet.Parameters.AddWithValue("@SalesTeamID", SalesTeamID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            SalesTeamEntity objEntity = new SalesTeamEntity();
            while (dr.Read())
            {
                objEntity.SalesTeamID = GetInt32(dr, "SalesTeamID");
                objEntity.SalesTeam = GetTextValue(dr, "SalesTeam");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual SalesTeamEntity tblSalesTeam_SelectForUpdate(string SalesTeam, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblSalesTeam_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@SalesTeam", SalesTeam);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            SalesTeamEntity objEntity = new SalesTeamEntity();
            while (dr.Read())
            {
                objEntity.SalesTeam = GetTextValue(dr, "SalesTeam");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblSalesTeam_Update(SalesTeamEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblSalesTeam_Update";
            cmdAdd.Parameters.AddWithValue("@SalesTeamID", ObjEntity.SalesTeamID);
            cmdAdd.Parameters.AddWithValue("@SalesTeam", ObjEntity.SalesTeam);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblSalesTeam_Delete(int SalesTeamID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblSalesTeam_Delete";
            cmdDel.Parameters.AddWithValue("@SalesTeamID", SalesTeamID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

    }
}

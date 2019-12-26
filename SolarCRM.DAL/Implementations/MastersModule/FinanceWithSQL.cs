
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

    public class FinanceWithSQL : BaseSqlManager
    {
        public virtual void tblFinanceWith_Insert(FinanceWithEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblFinanceWith_Insert";
            cmdAdd.Parameters.AddWithValue("@FinanceWith", ObjEntity.FinanceWith);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblFinanceWith_Exists(string FinanceWith)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblFinanceWith_Exists";
            cmdGet.Parameters.AddWithValue("@FinanceWith", FinanceWith);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "FinanceWith");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<FinanceWithEntity> tblFinanceWith_Select(PagingEntity CommonEntity, out int Count)
        {
            List<FinanceWithEntity> lstLocation = new List<FinanceWithEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblFinanceWith_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                FinanceWithEntity objEntity = new FinanceWithEntity();
                objEntity.FinanceWithID = GetInt32(dr, "FinanceWithID");
                objEntity.FinanceWith = GetTextValue(dr, "FinanceWith");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<FinanceWithEntity> tblFinanceWith_SelectActive()
        {
            List<FinanceWithEntity> lstLocation = new List<FinanceWithEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblFinanceWith_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                FinanceWithEntity objEntity = new FinanceWithEntity();
                objEntity.FinanceWithID = GetInt32(dr, "FinanceWithID");
                objEntity.FinanceWith = GetTextValue(dr, "FinanceWith");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual FinanceWithEntity tblFinanceWith_ForEdit(int FinanceWithID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblFinanceWith_ForEdit";
            cmdGet.Parameters.AddWithValue("@FinanceWithID", FinanceWithID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            FinanceWithEntity objEntity = new FinanceWithEntity();
            while (dr.Read())
            {
                objEntity.FinanceWithID = GetInt32(dr, "FinanceWithID");
                objEntity.FinanceWith = GetTextValue(dr, "FinanceWith");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual FinanceWithEntity tblFinanceWith_SelectForUpdate(string FinanceWith, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblFinanceWith_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@FinanceWith", FinanceWith);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            FinanceWithEntity objEntity = new FinanceWithEntity();
            while (dr.Read())
            {
                objEntity.FinanceWith = GetTextValue(dr, "FinanceWith");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblFinanceWith_Update(FinanceWithEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblFinanceWith_Update";
            cmdAdd.Parameters.AddWithValue("@FinanceWithID", ObjEntity.FinanceWithID);
            cmdAdd.Parameters.AddWithValue("@FinanceWith", ObjEntity.FinanceWith);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblFinanceWith_Delete(int FinanceWithID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblFinanceWith_Delete";
            cmdDel.Parameters.AddWithValue("@FinanceWithID", FinanceWithID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

    }
}

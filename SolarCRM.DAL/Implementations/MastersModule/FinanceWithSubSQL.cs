
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

    public class FinanceWithSubSQL : BaseSqlManager
    {
        public virtual List<FinanceWithSubEntity> tblFinanceWith_SelectForDropdown()
        {
            List<FinanceWithSubEntity> lstLocation = new List<FinanceWithSubEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblFinanceWith_SelectForDropdown";
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                FinanceWithSubEntity objEntity = new FinanceWithSubEntity();
                objEntity.FinanceWithID = GetInt32(dr, "FinanceWithID");
                objEntity.FinanceWith = GetTextValue(dr, "FinanceWith");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }


        public virtual void tblFinanceWithSub_Insert(FinanceWithSubEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblFinanceWithSub_Insert";
            cmdAdd.Parameters.AddWithValue("@FinanceWithID", ObjEntity.FinanceWithID);
            cmdAdd.Parameters.AddWithValue("@FinanceWithSub", ObjEntity.FinanceWithSub);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblFinanceWithSub_Exists(string FinanceWithSub)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblFinanceWithSub_Exists";
            cmdGet.Parameters.AddWithValue("@FinanceWithSub", FinanceWithSub);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "FinanceWithSub");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<FinanceWithSubEntity> tblFinanceWithSub_Select(PagingEntity CommonEntity, out int Count)
        {
            List<FinanceWithSubEntity> lstLocation = new List<FinanceWithSubEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblFinanceWithSub_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                FinanceWithSubEntity objEntity = new FinanceWithSubEntity();
                objEntity.FinanceWithSubID = GetInt32(dr, "FinanceWithSubID");
                objEntity.FinanceWithID = GetInt32(dr, "FinanceWithID");
                objEntity.FinanceWith = GetTextValue(dr, "FinanceWith");
                objEntity.FinanceWithSub = GetTextValue(dr, "FinanceWithSub");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual FinanceWithSubEntity tblFinanceWithSub_ForEdit(int FinanceWithSubID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblFinanceWithSub_ForEdit";
            cmdGet.Parameters.AddWithValue("@FinanceWithSubID", FinanceWithSubID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            FinanceWithSubEntity objEntity = new FinanceWithSubEntity();
            while (dr.Read())
            {
                objEntity.FinanceWithSubID = GetInt32(dr, "FinanceWithSubID");
                objEntity.FinanceWithID = GetInt32(dr, "FinanceWithID");
                objEntity.FinanceWithSub = GetTextValue(dr, "FinanceWithSub");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual FinanceWithSubEntity tblFinanceWithSub_SelectForUpdate(string FinanceWithSub, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblFinanceWithSub_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@FinanceWithSub", FinanceWithSub);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            FinanceWithSubEntity objEntity = new FinanceWithSubEntity();
            while (dr.Read())
            {
                objEntity.FinanceWithSub = GetTextValue(dr, "FinanceWithSub");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblFinanceWithSub_Update(FinanceWithSubEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblFinanceWithSub_Update";
            cmdAdd.Parameters.AddWithValue("@FinanceWithSubID", ObjEntity.FinanceWithSubID);
            cmdAdd.Parameters.AddWithValue("@FinanceWithID", ObjEntity.FinanceWithID);
            cmdAdd.Parameters.AddWithValue("@FinanceWithSub", ObjEntity.FinanceWithSub);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblFinanceWithSub_Delete(int FinanceWithSubID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblFinanceWithSub_Delete";
            cmdDel.Parameters.AddWithValue("@FinanceWithSubID", FinanceWithSubID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }


        public virtual List<FinanceWithSubEntity> tblCustSourceSub_SelectByCSID(int CompanySourceID)
        {
            List<FinanceWithSubEntity> lstLocation = new List<FinanceWithSubEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustSourceSub_SelectByCSID";
            cmdGet.Parameters.AddWithValue("@CompanySourceID", CompanySourceID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                FinanceWithSubEntity objEntity = new FinanceWithSubEntity();
                objEntity.FinanceWithSubID = GetInt32(dr, "FinanceWithSubID");
                objEntity.FinanceWithSub = GetTextValue(dr, "FinanceWithSub");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

    }
}

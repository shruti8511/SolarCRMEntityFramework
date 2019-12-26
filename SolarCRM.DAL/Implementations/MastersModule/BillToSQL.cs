
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

    public class BillToSQL : BaseSqlManager
    {
        public virtual void tblBillTo_Insert(BillToEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblBillTo_Insert";
            cmdAdd.Parameters.AddWithValue("@BillTo", ObjEntity.BillTo);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
          
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblBillTo_Exists(string BillTo)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblBillTo_Exists";
            cmdGet.Parameters.AddWithValue("@BillTo", BillTo);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "BillTo");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<BillToEntity> tblBillTo_Select(PagingEntity CommonEntity, out int Count)
        {
            List<BillToEntity> lstLocation = new List<BillToEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblBillTo_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                BillToEntity objEntity = new BillToEntity();
                objEntity.BillToID = GetInt32(dr, "BillToID");
                objEntity.BillTo = GetTextValue(dr, "BillTo");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<BillToEntity> tblBillTo_SelectActive()
        {
            List<BillToEntity> lstLocation = new List<BillToEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblBillTo_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                BillToEntity objEntity = new BillToEntity();
                objEntity.BillToID = GetInt32(dr, "BillToID");
                objEntity.BillTo = GetTextValue(dr, "BillTo");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual BillToEntity tblBillTo_ForEdit(int BillToID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblBillTo_ForEdit";
            cmdGet.Parameters.AddWithValue("@BillToID", BillToID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            BillToEntity objEntity = new BillToEntity();
            while (dr.Read())
            {
                objEntity.BillToID = GetInt32(dr, "BillToID");
                objEntity.BillTo = GetTextValue(dr, "BillTo");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual BillToEntity tblBillTo_SelectForUpdate(string BillTo, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblBillTo_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@BillTo", BillTo);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            BillToEntity objEntity = new BillToEntity();
            while (dr.Read())
            {
                objEntity.BillTo = GetTextValue(dr, "BillTo");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblBillTo_Update(BillToEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblBillTo_Update";
            cmdAdd.Parameters.AddWithValue("@BillToID", ObjEntity.BillToID);
            cmdAdd.Parameters.AddWithValue("@BillTo", ObjEntity.BillTo);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblBillTo_Delete(int BillToID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblBillTo_Delete";
            cmdDel.Parameters.AddWithValue("@BillToID", BillToID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }
    }
}

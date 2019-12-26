
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

    public class OrderingFromSQL : BaseSqlManager
    {
        public virtual void tblOrderingFrom_Insert(OrderingFromEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblOrderingFrom_Insert";
            cmdAdd.Parameters.AddWithValue("@OrderingFrom", ObjEntity.OrderingFrom);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);

            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblOrderingFrom_Exists(string OrderingFrom)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblOrderingFrom_Exists";
            cmdGet.Parameters.AddWithValue("@OrderingFrom", OrderingFrom);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "OrderingFrom");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<OrderingFromEntity> tblOrderingFrom_Select(PagingEntity CommonEntity, out int Count)
        {
            List<OrderingFromEntity> lstLocation = new List<OrderingFromEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblOrderingFrom_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                OrderingFromEntity objEntity = new OrderingFromEntity();
                objEntity.OrderingFromID = GetInt32(dr, "OrderingFromID");
                objEntity.OrderingFrom = GetTextValue(dr, "OrderingFrom");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<OrderingFromEntity> tblOrderingFrom_SelectActive()
        {
            List<OrderingFromEntity> lstLocation = new List<OrderingFromEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblOrderingFrom_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                OrderingFromEntity objEntity = new OrderingFromEntity();
                objEntity.OrderingFromID = GetInt32(dr, "OrderingFromID");
                objEntity.OrderingFrom = GetTextValue(dr, "OrderingFrom");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual OrderingFromEntity tblOrderingFrom_ForEdit(int OrderingFromID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblOrderingFrom_ForEdit";
            cmdGet.Parameters.AddWithValue("@OrderingFromID", OrderingFromID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            OrderingFromEntity objEntity = new OrderingFromEntity();
            while (dr.Read())
            {
                objEntity.OrderingFromID = GetInt32(dr, "OrderingFromID");
                objEntity.OrderingFrom = GetTextValue(dr, "OrderingFrom");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual OrderingFromEntity tblOrderingFrom_SelectForUpdate(string OrderingFrom, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblOrderingFrom_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@OrderingFrom", OrderingFrom);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            OrderingFromEntity objEntity = new OrderingFromEntity();
            while (dr.Read())
            {
                objEntity.OrderingFrom = GetTextValue(dr, "OrderingFrom");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblOrderingFrom_Update(OrderingFromEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblOrderingFrom_Update";
            cmdAdd.Parameters.AddWithValue("@OrderingFromID", ObjEntity.OrderingFromID);
            cmdAdd.Parameters.AddWithValue("@OrderingFrom", ObjEntity.OrderingFrom);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblOrderingFrom_Delete(int OrderingFromID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblOrderingFrom_Delete";
            cmdDel.Parameters.AddWithValue("@OrderingFromID", OrderingFromID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }
    }
}

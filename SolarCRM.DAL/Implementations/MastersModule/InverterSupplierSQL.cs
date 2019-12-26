
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

    public class InverterSupplierSQL : BaseSqlManager
    {
        public virtual void tblInverterSupplier_Insert(InverterSupplierEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblInverterSupplier_Insert";
            cmdAdd.Parameters.AddWithValue("@InverterSupplier", ObjEntity.InverterSupplier);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblInverterSupplier_Exists(string InverterSupplier)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInverterSupplier_Exists";
            cmdGet.Parameters.AddWithValue("@InverterSupplier", InverterSupplier);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "InverterSupplier");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<InverterSupplierEntity> tblInverterSupplier_Select(PagingEntity CommonEntity, out int Count)
        {
            List<InverterSupplierEntity> lstLocation = new List<InverterSupplierEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInverterSupplier_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                InverterSupplierEntity objEntity = new InverterSupplierEntity();
                objEntity.InverterSupplierID = GetInt32(dr, "InverterSupplierID");
                objEntity.InverterSupplier = GetTextValue(dr, "InverterSupplier");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<InverterSupplierEntity> tblInverterSupplier_SelectActive()
        {
            List<InverterSupplierEntity> lstLocation = new List<InverterSupplierEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInverterSupplier_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                InverterSupplierEntity objEntity = new InverterSupplierEntity();
                objEntity.InverterSupplierID = GetInt32(dr, "InverterSupplierID");
                objEntity.InverterSupplier = GetTextValue(dr, "InverterSupplier");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual InverterSupplierEntity tblInverterSupplier_ForEdit(int InverterSupplierID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInverterSupplier_ForEdit";
            cmdGet.Parameters.AddWithValue("@InverterSupplierID", InverterSupplierID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            InverterSupplierEntity objEntity = new InverterSupplierEntity();
            while (dr.Read())
            {
                objEntity.InverterSupplierID = GetInt32(dr, "InverterSupplierID");
                objEntity.InverterSupplier = GetTextValue(dr, "InverterSupplier");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual InverterSupplierEntity tblInverterSupplier_SelectForUpdate(string InverterSupplier, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInverterSupplier_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@InverterSupplier", InverterSupplier);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            InverterSupplierEntity objEntity = new InverterSupplierEntity();
            while (dr.Read())
            {
                objEntity.InverterSupplier = GetTextValue(dr, "InverterSupplier");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblInverterSupplier_Update(InverterSupplierEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblInverterSupplier_Update";
            cmdAdd.Parameters.AddWithValue("@InverterSupplierID", ObjEntity.InverterSupplierID);
            cmdAdd.Parameters.AddWithValue("@InverterSupplier", ObjEntity.InverterSupplier);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblInverterSupplier_Delete(int InverterSupplierID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblInverterSupplier_Delete";
            cmdDel.Parameters.AddWithValue("@InverterSupplierID", InverterSupplierID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }
    }
}

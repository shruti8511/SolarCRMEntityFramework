
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

    public class InvoicePaymentStatusSQL : BaseSqlManager
    {
        public virtual void tblInvoicePaymentStatus_Insert(InvoicePaymentStatusEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblInvoicePaymentStatus_Insert";
            cmdAdd.Parameters.AddWithValue("@InvoicePaymentStatus", ObjEntity.InvoicePaymentStatus);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblInvoicePaymentStatus_Exists(string InvoicePaymentStatus)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInvoicePaymentStatus_Exists";
            cmdGet.Parameters.AddWithValue("@InvoicePaymentStatus", InvoicePaymentStatus);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "InvoicePaymentStatus");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<InvoicePaymentStatusEntity> tblInvoicePaymentStatus_Select(PagingEntity CommonEntity, out int Count)
        {
            List<InvoicePaymentStatusEntity> lstLocation = new List<InvoicePaymentStatusEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInvoicePaymentStatus_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                InvoicePaymentStatusEntity objEntity = new InvoicePaymentStatusEntity();
                objEntity.InvoicePaymentStatusID = GetInt32(dr, "InvoicePaymentStatusID");
                objEntity.InvoicePaymentStatus = GetTextValue(dr, "InvoicePaymentStatus");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<InvoicePaymentStatusEntity> tblInvoicePaymentStatus_SelectActive()
        {
            List<InvoicePaymentStatusEntity> lstLocation = new List<InvoicePaymentStatusEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInvoicePaymentStatus_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                InvoicePaymentStatusEntity objEntity = new InvoicePaymentStatusEntity();
                objEntity.InvoicePaymentStatusID = GetInt32(dr, "InvoicePaymentStatusID");
                objEntity.InvoicePaymentStatus = GetTextValue(dr, "InvoicePaymentStatus");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual InvoicePaymentStatusEntity tblInvoicePaymentStatus_ForEdit(int InvoicePaymentStatusID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInvoicePaymentStatus_ForEdit";
            cmdGet.Parameters.AddWithValue("@InvoicePaymentStatusID", InvoicePaymentStatusID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            InvoicePaymentStatusEntity objEntity = new InvoicePaymentStatusEntity();
            while (dr.Read())
            {
                objEntity.InvoicePaymentStatusID = GetInt32(dr, "InvoicePaymentStatusID");
                objEntity.InvoicePaymentStatus = GetTextValue(dr, "InvoicePaymentStatus");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual InvoicePaymentStatusEntity tblInvoicePaymentStatus_SelectForUpdate(string InvoicePaymentStatus, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInvoicePaymentStatus_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@InvoicePaymentStatus", InvoicePaymentStatus);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            InvoicePaymentStatusEntity objEntity = new InvoicePaymentStatusEntity();
            while (dr.Read())
            {
                objEntity.InvoicePaymentStatus = GetTextValue(dr, "InvoicePaymentStatus");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblInvoicePaymentStatus_Update(InvoicePaymentStatusEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblInvoicePaymentStatus_Update";
            cmdAdd.Parameters.AddWithValue("@InvoicePaymentStatusID", ObjEntity.InvoicePaymentStatusID);
            cmdAdd.Parameters.AddWithValue("@InvoicePaymentStatus", ObjEntity.InvoicePaymentStatus);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblInvoicePaymentStatus_Delete(int InvoicePaymentStatusID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblInvoicePaymentStatus_Delete";
            cmdDel.Parameters.AddWithValue("@InvoicePaymentStatusID", InvoicePaymentStatusID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

    }
}

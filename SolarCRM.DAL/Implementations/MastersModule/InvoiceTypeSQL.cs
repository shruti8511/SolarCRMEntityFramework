
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

    public class InvoiceTypeSQL : BaseSqlManager
    {
        public virtual void tblInvoiceType_Insert(InvoiceTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblInvoiceType_Insert";
            cmdAdd.Parameters.AddWithValue("@InvoiceType", ObjEntity.InvoiceType);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblInvoiceType_Exists(string InvoiceType)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInvoiceType_Exists";
            cmdGet.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "InvoiceType");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<InvoiceTypeEntity> tblInvoiceType_Select(PagingEntity CommonEntity, out int Count)
        {
            List<InvoiceTypeEntity> lstLocation = new List<InvoiceTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInvoiceType_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                InvoiceTypeEntity objEntity = new InvoiceTypeEntity();
                objEntity.InvoiceTypeID = GetInt32(dr, "InvoiceTypeID");
                objEntity.InvoiceType = GetTextValue(dr, "InvoiceType");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<InvoiceTypeEntity> tblInvoiceType_SelectActive()
        {
            List<InvoiceTypeEntity> lstLocation = new List<InvoiceTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInvoiceType_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                InvoiceTypeEntity objEntity = new InvoiceTypeEntity();
                objEntity.InvoiceTypeID = GetInt32(dr, "InvoiceTypeID");
                objEntity.InvoiceType = GetTextValue(dr, "InvoiceType");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual InvoiceTypeEntity tblInvoiceType_ForEdit(int InvoiceTypeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInvoiceType_ForEdit";
            cmdGet.Parameters.AddWithValue("@InvoiceTypeID", InvoiceTypeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            InvoiceTypeEntity objEntity = new InvoiceTypeEntity();
            while (dr.Read())
            {
                objEntity.InvoiceTypeID = GetInt32(dr, "InvoiceTypeID");
                objEntity.InvoiceType = GetTextValue(dr, "InvoiceType");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual InvoiceTypeEntity tblInvoiceType_SelectForUpdate(string InvoiceType, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInvoiceType_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            InvoiceTypeEntity objEntity = new InvoiceTypeEntity();
            while (dr.Read())
            {
                objEntity.InvoiceType = GetTextValue(dr, "InvoiceType");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblInvoiceType_Update(InvoiceTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblInvoiceType_Update";
            cmdAdd.Parameters.AddWithValue("@InvoiceTypeID", ObjEntity.InvoiceTypeID);
            cmdAdd.Parameters.AddWithValue("@InvoiceType", ObjEntity.InvoiceType);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblInvoiceType_Delete(int InvoiceTypeID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblInvoiceType_Delete";
            cmdDel.Parameters.AddWithValue("@InvoiceTypeID", InvoiceTypeID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }
    }
}

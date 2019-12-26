

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

    public class CustomerTypeSQL : BaseSqlManager
    {
        public virtual void tblCustomerType_Insert(CustomerTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCustomerType_Insert";
            cmdAdd.Parameters.AddWithValue("@CustType", ObjEntity.CustType);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);            
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblCustType_Exists(string CustType)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustType_Exists";
            cmdGet.Parameters.AddWithValue("@CustType", CustType);          
            SqlDataReader dr = ExecuteDataReader(cmdGet);
          //  CustomerTypeEntity details = new CustomerTypeEntity();
            while (dr.Read())
            {
                ID = GetInt32(dr, "CustType");
                //details.CustType = GetTextValue(dr, "CustType");
               
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<CustomerTypeEntity> tblCustType_Select(PagingEntity CommonEntity, out int Count)
        {
            List<CustomerTypeEntity> lstLocation = new List<CustomerTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustType_Select";

            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);


            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CustomerTypeEntity objEntity = new CustomerTypeEntity();
                objEntity.CustTypeID = GetInt32(dr, "CustTypeID");
                objEntity.CustType = GetTextValue(dr, "CustType");
                objEntity.Active = GetBoolean(dr, "Active");
               // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();

            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());


            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<CustomerTypeEntity> tblCustType_SelectActive()
        {
            List<CustomerTypeEntity> lstLocation = new List<CustomerTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustType_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CustomerTypeEntity objEntity = new CustomerTypeEntity();
                objEntity.CustTypeID = GetInt32(dr, "CustTypeID");
                objEntity.CustType = GetTextValue(dr, "CustType");
                           
                lstLocation.Add(objEntity);
            }
            dr.Close();

            ForceCloseConnection();
            return lstLocation;
        }

        public virtual CustomerTypeEntity tblCustType_ForEdit(int CustTypeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustType_ForEdit";
            cmdGet.Parameters.AddWithValue("@CustTypeID", CustTypeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            CustomerTypeEntity objEntity = new CustomerTypeEntity();
            while (dr.Read())
            {
                objEntity.CustTypeID = GetInt32(dr, "CustTypeID");
                objEntity.CustType = GetTextValue(dr, "CustType");
                objEntity.Active = GetBoolean(dr, "Active");               
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual CustomerTypeEntity tblCustType_SelectForUpdate(string CustType, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustType_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@CustType", CustType);          
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            CustomerTypeEntity objEntity = new CustomerTypeEntity();
            while (dr.Read())
            {
                objEntity.CustType = GetTextValue(dr, "CustType");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblCustType_Update(CustomerTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCustType_Update";
            cmdAdd.Parameters.AddWithValue("@CustTypeID", ObjEntity.CustTypeID);
            cmdAdd.Parameters.AddWithValue("@CustType", ObjEntity.CustType);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);          
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblCustType_Delete(int CustTypeID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblCustType_Delete";
            cmdDel.Parameters.AddWithValue("@CustTypeID", CustTypeID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }


    }
}

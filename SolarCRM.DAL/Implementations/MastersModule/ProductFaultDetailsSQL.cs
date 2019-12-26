
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

    public class ProductFaultDetailsSQL : BaseSqlManager
    {
        public virtual List<ProductFaultDetailsEntity> tblProductFaultCategory_SelectForDropdown()
        {
            List<ProductFaultDetailsEntity> lstLocation = new List<ProductFaultDetailsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProductFaultCategory_SelectForDropdown";
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProductFaultDetailsEntity objEntity = new ProductFaultDetailsEntity();
                objEntity.ProductFaultCategoryID = GetInt32(dr, "ProductFaultCategoryID");
                objEntity.ProductFaultCategory = GetTextValue(dr, "ProductFaultCategory");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }


        public virtual void tblProductFaultDetails_Insert(ProductFaultDetailsEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProductFaultDetails_Insert";
            cmdAdd.Parameters.AddWithValue("@ProductFaultCategoryID", ObjEntity.ProductFaultCategoryID);
            cmdAdd.Parameters.AddWithValue("@ProductFaultDetails", ObjEntity.ProductFaultDetails);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);           
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblProductFaultDetails_Exists(string ProductFaultDetails)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProductFaultDetails_Exists";
            cmdGet.Parameters.AddWithValue("@ProductFaultDetails", ProductFaultDetails);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "ProductFaultDetails");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<ProductFaultDetailsEntity> tblProductFaultDetails_Select(PagingEntity CommonEntity, out int Count)
        {
            List<ProductFaultDetailsEntity> lstLocation = new List<ProductFaultDetailsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProductFaultDetails_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProductFaultDetailsEntity objEntity = new ProductFaultDetailsEntity();
                objEntity.ProductFaultDetailsID = GetInt32(dr, "ProductFaultDetailsID");
                objEntity.ProductFaultCategoryID = GetInt32(dr, "ProductFaultCategoryID");
                objEntity.ProductFaultCategory = GetTextValue(dr, "ProductFaultCategory");
                objEntity.ProductFaultDetails = GetTextValue(dr, "ProductFaultDetails");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual ProductFaultDetailsEntity tblProductFaultDetails_ForEdit(int ProductFaultDetailsID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProductFaultDetails_ForEdit";
            cmdGet.Parameters.AddWithValue("@ProductFaultDetailsID", ProductFaultDetailsID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProductFaultDetailsEntity objEntity = new ProductFaultDetailsEntity();
            while (dr.Read())
            {
                objEntity.ProductFaultDetailsID = GetInt32(dr, "ProductFaultDetailsID");
                objEntity.ProductFaultCategoryID = GetInt32(dr, "ProductFaultCategoryID");
                objEntity.ProductFaultDetails = GetTextValue(dr, "ProductFaultDetails");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual ProductFaultDetailsEntity tblProductFaultDetails_SelectForUpdate(string ProductFaultDetails, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProductFaultDetails_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@ProductFaultDetails", ProductFaultDetails);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProductFaultDetailsEntity objEntity = new ProductFaultDetailsEntity();
            while (dr.Read())
            {
                objEntity.ProductFaultDetails = GetTextValue(dr, "ProductFaultDetails");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblProductFaultDetails_Update(ProductFaultDetailsEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProductFaultDetails_Update";
            cmdAdd.Parameters.AddWithValue("@ProductFaultDetailsID", ObjEntity.ProductFaultDetailsID);
            cmdAdd.Parameters.AddWithValue("@ProductFaultCategoryID", ObjEntity.ProductFaultCategoryID);
            cmdAdd.Parameters.AddWithValue("@ProductFaultDetails", ObjEntity.ProductFaultDetails);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblProductFaultDetails_Delete(int ProductFaultDetailsID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblProductFaultDetails_Delete";
            cmdDel.Parameters.AddWithValue("@ProductFaultDetailsID", ProductFaultDetailsID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }


        public virtual List<ProductFaultDetailsEntity> tblCustSourceSub_SelectByCSID(int ProductFaultCategoryID)
        {
            List<ProductFaultDetailsEntity> lstLocation = new List<ProductFaultDetailsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustSourceSub_SelectByCSID";
            cmdGet.Parameters.AddWithValue("@ProductFaultCategoryID", ProductFaultCategoryID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProductFaultDetailsEntity objEntity = new ProductFaultDetailsEntity();
                objEntity.ProductFaultDetailsID = GetInt32(dr, "ProductFaultDetailsID");
                objEntity.ProductFaultDetails = GetTextValue(dr, "ProductFaultDetails");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

    }
}

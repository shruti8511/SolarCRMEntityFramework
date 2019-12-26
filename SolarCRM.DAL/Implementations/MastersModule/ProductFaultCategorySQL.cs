
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

    public class ProductFaultCategorySQL : BaseSqlManager
    {

        public virtual void tblProductFaultCategory_Insert(ProductFaultCategoryEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProductFaultCategory_Insert";
            cmdAdd.Parameters.AddWithValue("@ProductFaultCategory", ObjEntity.ProductFaultCategory);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
          
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblProductFaultCategory_Exists(string ProductFaultCategory)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProductFaultCategory_Exists";
            cmdGet.Parameters.AddWithValue("@ProductFaultCategory", ProductFaultCategory);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "ProductFaultCategory");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<ProductFaultCategoryEntity> tblProductFaultCategory_Select(PagingEntity CommonEntity, out int Count)
        {
            List<ProductFaultCategoryEntity> lstLocation = new List<ProductFaultCategoryEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProductFaultCategory_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProductFaultCategoryEntity objEntity = new ProductFaultCategoryEntity();
                objEntity.ProductFaultCategoryID = GetInt32(dr, "ProductFaultCategoryID");
                objEntity.ProductFaultCategory = GetTextValue(dr, "ProductFaultCategory");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<ProductFaultCategoryEntity> tblProductFaultCategory_SelectActive()
        {
            List<ProductFaultCategoryEntity> lstLocation = new List<ProductFaultCategoryEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProductFaultCategory_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProductFaultCategoryEntity objEntity = new ProductFaultCategoryEntity();
                objEntity.ProductFaultCategoryID = GetInt32(dr, "ProductFaultCategoryID");
                objEntity.ProductFaultCategory = GetTextValue(dr, "ProductFaultCategory");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual ProductFaultCategoryEntity tblProductFaultCategory_ForEdit(int ProductFaultCategoryID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProductFaultCategory_ForEdit";
            cmdGet.Parameters.AddWithValue("@ProductFaultCategoryID", ProductFaultCategoryID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProductFaultCategoryEntity objEntity = new ProductFaultCategoryEntity();
            while (dr.Read())
            {
                objEntity.ProductFaultCategoryID = GetInt32(dr, "ProductFaultCategoryID");
                objEntity.ProductFaultCategory = GetTextValue(dr, "ProductFaultCategory");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual ProductFaultCategoryEntity tblProductFaultCategory_SelectForUpdate(string ProductFaultCategory, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProductFaultCategory_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@ProductFaultCategory", ProductFaultCategory);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProductFaultCategoryEntity objEntity = new ProductFaultCategoryEntity();
            while (dr.Read())
            {
                objEntity.ProductFaultCategory = GetTextValue(dr, "ProductFaultCategory");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblProductFaultCategory_Update(ProductFaultCategoryEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProductFaultCategory_Update";
            cmdAdd.Parameters.AddWithValue("@ProductFaultCategoryID", ObjEntity.ProductFaultCategoryID);
            cmdAdd.Parameters.AddWithValue("@ProductFaultCategory", ObjEntity.ProductFaultCategory);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblProductFaultCategory_Delete(int ProductFaultCategoryID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblProductFaultCategory_Delete";
            cmdDel.Parameters.AddWithValue("@ProductFaultCategoryID", ProductFaultCategoryID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

    }
}


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

    public class StockCategorySQL : BaseSqlManager
    {
        public virtual void tblStockCategory_Insert(StockCategoryEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblStockCategory_Insert";
            cmdAdd.Parameters.AddWithValue("@StockCategory", ObjEntity.StockCategory);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblStockCategory_Exists(string StockCategory)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblStockCategory_Exists";
            cmdGet.Parameters.AddWithValue("@StockCategory", StockCategory);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "StockCategory");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<StockCategoryEntity> tblStockCategory_Select(PagingEntity CommonEntity, out int Count)
        {
            List<StockCategoryEntity> lstLocation = new List<StockCategoryEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblStockCategory_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                StockCategoryEntity objEntity = new StockCategoryEntity();
                objEntity.StockCategoryID = GetInt32(dr, "StockCategoryID");
                objEntity.StockCategory = GetTextValue(dr, "StockCategory");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<StockCategoryEntity> tblStockCategory_SelectActive()
        {
            List<StockCategoryEntity> lstLocation = new List<StockCategoryEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblStockCategory_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                StockCategoryEntity objEntity = new StockCategoryEntity();
                objEntity.StockCategoryID = GetInt32(dr, "StockCategoryID");
                objEntity.StockCategory = GetTextValue(dr, "StockCategory");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual StockCategoryEntity tblStockCategory_ForEdit(int StockCategoryID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblStockCategory_ForEdit";
            cmdGet.Parameters.AddWithValue("@StockCategoryID", StockCategoryID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            StockCategoryEntity objEntity = new StockCategoryEntity();
            while (dr.Read())
            {
                objEntity.StockCategoryID = GetInt32(dr, "StockCategoryID");
                objEntity.StockCategory = GetTextValue(dr, "StockCategory");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual StockCategoryEntity tblStockCategory_SelectForUpdate(string StockCategory, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblStockCategory_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@StockCategory", StockCategory);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            StockCategoryEntity objEntity = new StockCategoryEntity();
            while (dr.Read())
            {
                objEntity.StockCategory = GetTextValue(dr, "StockCategory");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblStockCategory_Update(StockCategoryEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblStockCategory_Update";
            cmdAdd.Parameters.AddWithValue("@StockCategoryID", ObjEntity.StockCategoryID);
            cmdAdd.Parameters.AddWithValue("@StockCategory", ObjEntity.StockCategory);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblStockCategory_Delete(int StockCategoryID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblStockCategory_Delete";
            cmdDel.Parameters.AddWithValue("@StockCategoryID", StockCategoryID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }




        public virtual List<StockCategoryEntity> tblStockCategory_SelectForDropdown()
        {
            List<StockCategoryEntity> lstLocation = new List<StockCategoryEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblStockCategory_SelectForDropdown";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                StockCategoryEntity objEntity = new StockCategoryEntity();
                objEntity.StockCategoryID = GetInt32(dr, "StockCategoryID");
                objEntity.StockCategory = GetTextValue(dr, "StockCategory");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }





    }
}

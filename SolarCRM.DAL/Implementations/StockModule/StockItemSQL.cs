using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.StockModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.DAL.Implementations.StockModule
{
    public class StockItemSQL : BaseSqlManager
    {
        public virtual void tblStockItems_Insert(StockItemEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblStockItems_Insert";
            cmdAdd.Parameters.AddWithValue("@StockCategoryID", ObjEntity.StockCategoryID);
            cmdAdd.Parameters.AddWithValue("@StockItem", ObjEntity.StockItem);
            cmdAdd.Parameters.AddWithValue("@StockModel", ObjEntity.StockModel);
            cmdAdd.Parameters.AddWithValue("@StockSize", ObjEntity.StockSize);
            cmdAdd.Parameters.AddWithValue("@InverterPhase", ObjEntity.InverterPhase);
            cmdAdd.Parameters.AddWithValue("@InverterCert", ObjEntity.InverterCert);
            cmdAdd.Parameters.AddWithValue("@StockManufacturer", ObjEntity.StockManufacturer);
            cmdAdd.Parameters.AddWithValue("@StockSeries", ObjEntity.StockSeries);
            cmdAdd.Parameters.AddWithValue("@CostPrice", ObjEntity.CostPrice);
            cmdAdd.Parameters.AddWithValue("@MPPT", ObjEntity.MPPT);
            cmdAdd.Parameters.AddWithValue("@StockDescription", ObjEntity.StockDescription);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
        }




        public virtual List<StockItemEntity> tblStockItems_Select(PagingEntity CommonEntity, out int Count)
        {
            List<StockItemEntity> lstLocation = new List<StockItemEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblStockItems_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                StockItemEntity objEntity = new StockItemEntity();
                objEntity.StockItemID = GetInt32(dr, "StockItemID");
                objEntity.StockCategory = GetTextValue(dr, "StockCategory");
                objEntity.StockManufacturer = GetTextValue(dr, "StockManufacturer");
                objEntity.StockItem = GetTextValue(dr, "StockItem");
                objEntity.StockSeries = GetTextValue(dr, "StockSeries");
                objEntity.StockModel = GetTextValue(dr, "StockModel");
               // objEntity.CostPrice = GetDecimal(dr, "CostPrice");
                objEntity.StockSize = GetTextValue(dr, "StockSize");
              //  objEntity.StockDescription = GetTextValue(dr, "StockDescription");
               // objEntity.Active = GetBoolean(dr, "Active");                       
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }





    }
}

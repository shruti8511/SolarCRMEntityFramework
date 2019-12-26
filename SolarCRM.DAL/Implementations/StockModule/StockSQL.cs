using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.StockModule;
using System.Data.SqlClient;
using System.Data;

namespace SolarCRM.DAL.Implementations.StockModule
{
    public class StockSQL : BaseSqlManager
    {
        public virtual List<StockEntity> tblStockItems_SelectPanel()
        {
            List<StockEntity> lstLocation = new List<StockEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblStockItems_SelectPanel";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                StockEntity objEntity = new StockEntity();
                objEntity.StockItemID = GetInt32(dr, "StockItemID");
                objEntity.StockItem = GetTextValue(dr, "StockItem");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }


        public virtual List<StockEntity> tblStockItems_SelectInverter()
        {
            List<StockEntity> lstLocation = new List<StockEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblStockItems_SelectInverter";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                StockEntity objEntity = new StockEntity();
                objEntity.StockItemID = GetInt32(dr, "StockItemID");
                objEntity.StockItem = GetTextValue(dr, "StockItem");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }



        public virtual StockEntity tblStockItems_SelectByStockItemID(int StockItemID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblStockItems_SelectByStockItemID";
            cmdGet.Parameters.AddWithValue("@StockItemID", StockItemID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            StockEntity details = new StockEntity();
            while (dr.Read())
            {
                details.StockItemID = GetInt32(dr, "StockItemID");
                details.StockManufacturer = GetTextValue(dr, "StockManufacturer");
                details.StockModel = GetTextValue(dr, "StockModel");
                details.StockSize = GetTextValue(dr, "StockSize");
                details.InverterCert = GetTextValue(dr, "InverterCert");

            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }


    }
}

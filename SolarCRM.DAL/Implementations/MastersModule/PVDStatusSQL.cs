
 namespace SolarCRM.DAL.Implementations.MastersModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SolarCRM.Entity.Models.Common;
    using SolarCRM.Entity.Models.MastersModule;
    using System.Data;
    using System.Data.SqlClient;

    public class PVDStatusSQL : BaseSqlManager
    {
        public virtual PVDStatusEntity tblPVDStatus_SelectByPVDStatusID(long PVDStatusID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPVDStatus_SelectByPVDStatusID";
            cmdGet.Parameters.AddWithValue("@PVDStatusID", PVDStatusID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            PVDStatusEntity details = new PVDStatusEntity();
            while (dr.Read())
            {
                details.PVDStatusID = GetInt32(dr, "PVDStatusID");
                details.Active = GetBoolean(dr, "Active");

            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }
        public virtual List<PVDStatusEntity> tblPVDStatus_SelectActive(long PVDStatusID, int isactive)
        {
            List<PVDStatusEntity> lstLocation = new List<PVDStatusEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.Parameters.AddWithValue("@isactive", isactive);
            cmdGet.Parameters.AddWithValue("@PVDStatusID", PVDStatusID);

            cmdGet.CommandText = "tblPVDStatus_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                PVDStatusEntity objEntity = new PVDStatusEntity();
                objEntity.PVDStatusID = GetInt32(dr, "PVDStatusID");
                objEntity.PVDStatus = GetTextValue(dr, "PVDStatus");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
    }
}


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


    public class RexStatusSQL : BaseSqlManager
    {
        public virtual List<RexStatus> tblREXStatus_SelectASC()
        {
            List<RexStatus> lstLocation = new List<RexStatus>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblREXStatus_SelectASC";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                RexStatus objEntity = new RexStatus();
                objEntity.RexStatusID = GetInt32(dr, "RexStatusID");
                objEntity.RexStatusABB = GetTextValue(dr, "RexStatusABB");
         //       objEntity.RexStatusName = GetTextValue(dr, "RexStatus");
                  lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
    }
}

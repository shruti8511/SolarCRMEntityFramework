
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
    using System.Threading.Tasks;
    public class JobStatusSQL :BaseSqlManager
    {
        public virtual JobStatusEntity tblJobStatus_SelectByJobStatusID(long JobStatusID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblJobStatus_SelectByJobStatusID";
            cmdGet.Parameters.AddWithValue("@JobStatusID", @JobStatusID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            JobStatusEntity details = new JobStatusEntity();
            while (dr.Read())
            {
                  details.JobStatusID = GetInt32(dr, "JobStatusID");
                details.JobStatus = GetTextValue(dr, "JobStatus");

            }
            dr.Close();
            ForceCloseConnection();
            return details;
    
         
        }
        public virtual List<JobStatusEntity> tblJobStatus_SelectActive(long JobStatusID, int isactive)
        {
            List<JobStatusEntity> lstLocation = new List<JobStatusEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.Parameters.AddWithValue("@isactive", isactive);
            cmdGet.Parameters.AddWithValue("@JobStatusID", JobStatusID);

            cmdGet.CommandText = "tblJobStatus_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                JobStatusEntity objEntity = new JobStatusEntity();
                objEntity.JobStatusID = GetInt32(dr, "JobStatusID");
                objEntity.JobStatus = GetTextValue(dr, "JobStatus");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
    }
}

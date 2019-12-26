using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;
namespace SolarCRM.BAL.Implementations.MastersModule
{

    public class JobStatusManagement
    {
        public static JobStatusEntity tblJobStatus_SelectByJobStatusID(long JobStatusID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.JobStatusSQL().tblJobStatus_SelectByJobStatusID(JobStatusID));
        }
        public static List<JobStatusEntity> tblJobStatus_SelectActive(int isactive, long JobStatusID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.JobStatusSQL().tblJobStatus_SelectActive(JobStatusID, isactive));
        }
    }
}

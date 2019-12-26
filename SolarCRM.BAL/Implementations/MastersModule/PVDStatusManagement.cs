using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
    public class PVDStatusManagement
    {
        public static PVDStatusEntity tblPVDStatus_SelectByPVDStatusID(long PVDStatusID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PVDStatusSQL().tblPVDStatus_SelectByPVDStatusID(PVDStatusID));
        }
        public static List<PVDStatusEntity> tblPVDStatus_SelectActive(int isactive, long PVDStatusID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PVDStatusSQL().tblPVDStatus_SelectActive(PVDStatusID, isactive));
        }
    }
}

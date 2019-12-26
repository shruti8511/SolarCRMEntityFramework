using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;
namespace SolarCRM.BAL.Implementations.MastersModule
{
     public class RexStatusManagement
    {
         public static List<RexStatus> tblREXStatus_SelectASC()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.RexStatusSQL().tblREXStatus_SelectASC());
        }
    }
}

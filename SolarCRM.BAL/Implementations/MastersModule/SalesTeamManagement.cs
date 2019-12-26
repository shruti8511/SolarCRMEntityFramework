using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class SalesTeamManagement
    {
        public static void tblSalesTeam_Insert(SalesTeamEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.SalesTeamSQL().tblSalesTeam_Insert(ObjEntity);
        }

        public static int tblSalesTeam_Exists(string SalesTeam)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.SalesTeamSQL().tblSalesTeam_Exists(SalesTeam));
        }

        public static List<SalesTeamEntity> tblSalesTeam_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.SalesTeamSQL().tblSalesTeam_Select(CommonEntity, out Count));
        }

        public static List<SalesTeamEntity> tblSalesTeam_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.SalesTeamSQL().tblSalesTeam_SelectActive());
        }

        public static SalesTeamEntity tblSalesTeam_ForEdit(int SalesTeamID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.SalesTeamSQL().tblSalesTeam_ForEdit(SalesTeamID));
        }

        public static SalesTeamEntity tblSalesTeam_SelectForUpdate(string SalesTeam, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.SalesTeamSQL().tblSalesTeam_SelectForUpdate(SalesTeam, Active));
        }

        public static void tblSalesTeam_Update(SalesTeamEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.SalesTeamSQL().tblSalesTeam_Update(ObjEntity);
        }

        public static void tblSalesTeam_Delete(int SalesTeamID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.SalesTeamSQL().tblSalesTeam_Delete(SalesTeamID);
        }

    }
}

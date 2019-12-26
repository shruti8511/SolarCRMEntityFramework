using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;


namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class LeadCancelReasonManagement
    {
        public static void tblContLeadCancelReason_Insert(LeadCancelReasonEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.LeadCancelReasonSQL().tblContLeadCancelReason_Insert(ObjEntity);
        }

        public static int tblContLeadCancelReason_Exists(string LeadCancelReason)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.LeadCancelReasonSQL().tblContLeadCancelReason_Exists(LeadCancelReason));
        }

        public static List<LeadCancelReasonEntity> tblContLeadCancelReason_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.LeadCancelReasonSQL().tblContLeadCancelReason_Select(CommonEntity, out Count));
        }

        //public static List<LeadCancelReasonEntity> tblContLeadCancelReason_SelectActive()
        //{
        //    return (new SolarCRM.DAL.Implementations.MastersModule.LeadCancelReasonSQL().tblContLeadCancelReason_SelectActive());
        //}

        public static LeadCancelReasonEntity tblContLeadCancelReason_ForEdit(int LeadCancelReasonID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.LeadCancelReasonSQL().tblContLeadCancelReason_ForEdit(LeadCancelReasonID));
        }

        public static LeadCancelReasonEntity tblContLeadCancelReason_SelectForUpdate(string LeadCancelReason, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.LeadCancelReasonSQL().tblContLeadCancelReason_SelectForUpdate(LeadCancelReason, Active));
        }

        public static void tblContLeadCancelReason_Update(LeadCancelReasonEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.LeadCancelReasonSQL().tblContLeadCancelReason_Update(ObjEntity);
        }

        public static void tblContLeadCancelReason_Delete(int LeadCancelReasonID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.LeadCancelReasonSQL().tblContLeadCancelReason_Delete(LeadCancelReasonID);
        }

    }
}

using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class LeadGenManagement
    {
        //public static List<LeadGenEntity> tblCompanySource_SelectForDropdown()
        //{
        //    return (new SolarCRM.DAL.Implementations.MastersModule.LeadGenSQL().tblCompanySource_SelectForDropdown());
        //}

        public static void tblLeadGen_Insert(LeadGenEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.LeadGenSQL().tblLeadGen_Insert(ObjEntity);
        }

        //public static int tblLeadGen_Exists(string LeadGen)
        //{
        //    return (new SolarCRM.DAL.Implementations.MastersModule.LeadGenSQL().tblLeadGen_Exists(LeadGen));
        //}

        public static List<LeadGenEntity> tblLeadGen_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.LeadGenSQL().tblLeadGen_Select(CommonEntity, out Count));
        }

        public static LeadGenEntity tblLeadGen_ForEdit(int LeadGenID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.LeadGenSQL().tblLeadGen_ForEdit(LeadGenID));
        }

        //public static LeadGenEntity tblLeadGen_SelectForUpdate(string LeadGen, Boolean Active)
        //{
        //    return (new SolarCRM.DAL.Implementations.MastersModule.LeadGenSQL().tblLeadGen_SelectForUpdate(LeadGen, Active));
        //}

        public static void tblLeadGen_Update(LeadGenEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.LeadGenSQL().tblLeadGen_Update(ObjEntity);
        }

        public static void tblLeadGen_Delete(int LeadGenID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.LeadGenSQL().tblLeadGen_Delete(LeadGenID);
        }

        //public static List<LeadGenEntity> tblCustSourceSub_SelectByCSID(int CompanySourceID)
        //{
        //    return (new SolarCRM.DAL.Implementations.MastersModule.LeadGenSQL().tblCustSourceSub_SelectByCSID(CompanySourceID));
        //}

    }
}

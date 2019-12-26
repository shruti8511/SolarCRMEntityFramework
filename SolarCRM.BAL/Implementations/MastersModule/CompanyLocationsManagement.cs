using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.MastersModule
{
    public class CompanyLocationsManagement
    {
        public static int tblCompanyLocations_Insert(CompanyLocationsEntity ObjEntity)
        {
           return new SolarCRM.DAL.Implementations.MastersModule.CompanyLocationsSQL().tblCompanyLocations_Insert(ObjEntity);
        }

        public static int tblCompanyLocations_Exists(string CompanyLocation)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.CompanyLocationsSQL().tblCompanyLocations_Exists(CompanyLocation));
        }

        public static List<CompanyLocationsEntity> tblCompanyLocations_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.CompanyLocationsSQL().tblCompanyLocations_Select(CommonEntity, out Count));
        }

        public static List<CompanyLocationsEntity> tblCompanyLocations_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.CompanyLocationsSQL().tblCompanyLocations_SelectActive());
        }

        public static CompanyLocationsEntity tblCompanyLocations_ForEdit(int CompanyLocationID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.CompanyLocationsSQL().tblCompanyLocations_ForEdit(CompanyLocationID));
        }

        public static CompanyLocationsEntity tblCompanyLocations_SelectForUpdate(string CompanyLocation, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.CompanyLocationsSQL().tblCompanyLocations_SelectForUpdate(CompanyLocation, Active));
        }

        public static void tblCompanyLocations_Update(CompanyLocationsEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.CompanyLocationsSQL().tblCompanyLocations_Update(ObjEntity);
        }

        public static void tblCompanyLocations_Delete(int CompanyLocationID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.CompanyLocationsSQL().tblCompanyLocations_Delete(CompanyLocationID);
        }

        public static List<StateEntity> tblState_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.CompanyLocationsSQL().tblState_SelectActive());
        }

    }
}

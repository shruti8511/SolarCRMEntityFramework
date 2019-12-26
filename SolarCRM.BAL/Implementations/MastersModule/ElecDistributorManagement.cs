using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class ElecDistributorManagement
    {
        public static void tblElecDistributor_Insert(ElecDistributorEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ElecDistributorSQL().tblElecDistributor_Insert(ObjEntity);
        }

        public static int tblElecDistributor_Exists(string ElecDistributor)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ElecDistributorSQL().tblElecDistributor_Exists(ElecDistributor));
        }

        public static List<ElecDistributorEntity> tblElecDistributor_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ElecDistributorSQL().tblElecDistributor_Select(CommonEntity, out Count));
        }

        public static List<ElecDistributorEntity> tblElecDistributor_SelectActiveByState(string InstallState)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ElecDistributorSQL().tblElecDistributor_SelectActiveByState(InstallState));
        }

        public static ElecDistributorEntity tblElecDistributor_ForEdit(int ElecDistributorID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ElecDistributorSQL().tblElecDistributor_ForEdit(ElecDistributorID));
        }

        public static ElecDistributorEntity tblElecDistributor_SelectForUpdate(string ElecDistributor, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ElecDistributorSQL().tblElecDistributor_SelectForUpdate(ElecDistributor, Active));
        }

        public static void tblElecDistributor_Update(ElecDistributorEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ElecDistributorSQL().tblElecDistributor_Update(ObjEntity);
        }

        public static void tblElecDistributor_Delete(int ElecDistributorID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ElecDistributorSQL().tblElecDistributor_Delete(ElecDistributorID);
        }

       


    }
}

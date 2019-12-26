using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class PanelSupplierManagement
    {
        public static void tblPanelSupplier_Insert(PanelSupplierEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.PanelSupplierSQL().tblPanelSupplier_Insert(ObjEntity);
        }

        public static int tblPanelSupplier_Exists(string PanelSupplier)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PanelSupplierSQL().tblPanelSupplier_Exists(PanelSupplier));
        }

        public static List<PanelSupplierEntity> tblPanelSupplier_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PanelSupplierSQL().tblPanelSupplier_Select(CommonEntity, out Count));
        }

        public static List<PanelSupplierEntity> tblPanelSupplier_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PanelSupplierSQL().tblPanelSupplier_SelectActive());
        }

        public static PanelSupplierEntity tblPanelSupplier_ForEdit(int PanelSupplierID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PanelSupplierSQL().tblPanelSupplier_ForEdit(PanelSupplierID));
        }

        public static PanelSupplierEntity tblPanelSupplier_SelectForUpdate(string PanelSupplier, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PanelSupplierSQL().tblPanelSupplier_SelectForUpdate(PanelSupplier, Active));
        }

        public static void tblPanelSupplier_Update(PanelSupplierEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.PanelSupplierSQL().tblPanelSupplier_Update(ObjEntity);
        }

        public static void tblPanelSupplier_Delete(int PanelSupplierID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.PanelSupplierSQL().tblPanelSupplier_Delete(PanelSupplierID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class InverterSupplierManagement
    {
        public static void tblInverterSupplier_Insert(InverterSupplierEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InverterSupplierSQL().tblInverterSupplier_Insert(ObjEntity);
        }

        public static int tblInverterSupplier_Exists(string InverterSupplier)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InverterSupplierSQL().tblInverterSupplier_Exists(InverterSupplier));
        }

        public static List<InverterSupplierEntity> tblInverterSupplier_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InverterSupplierSQL().tblInverterSupplier_Select(CommonEntity, out Count));
        }

        public static List<InverterSupplierEntity> tblInverterSupplier_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InverterSupplierSQL().tblInverterSupplier_SelectActive());
        }

        public static InverterSupplierEntity tblInverterSupplier_ForEdit(int InverterSupplierID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InverterSupplierSQL().tblInverterSupplier_ForEdit(InverterSupplierID));
        }

        public static InverterSupplierEntity tblInverterSupplier_SelectForUpdate(string InverterSupplier, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InverterSupplierSQL().tblInverterSupplier_SelectForUpdate(InverterSupplier, Active));
        }

        public static void tblInverterSupplier_Update(InverterSupplierEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InverterSupplierSQL().tblInverterSupplier_Update(ObjEntity);
        }

        public static void tblInverterSupplier_Delete(int InverterSupplierID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InverterSupplierSQL().tblInverterSupplier_Delete(InverterSupplierID);
        }


    }
}

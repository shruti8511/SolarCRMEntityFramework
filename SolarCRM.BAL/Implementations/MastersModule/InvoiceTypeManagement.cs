using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class InvoiceTypeManagement
    {
        public static void tblInvoiceType_Insert(InvoiceTypeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InvoiceTypeSQL().tblInvoiceType_Insert(ObjEntity);
        }

        public static int tblInvoiceType_Exists(string InvoiceType)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InvoiceTypeSQL().tblInvoiceType_Exists(InvoiceType));
        }

        public static List<InvoiceTypeEntity> tblInvoiceType_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InvoiceTypeSQL().tblInvoiceType_Select(CommonEntity, out Count));
        }

        public static List<InvoiceTypeEntity> tblInvoiceType_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InvoiceTypeSQL().tblInvoiceType_SelectActive());
        }

        public static InvoiceTypeEntity tblInvoiceType_ForEdit(int InvoiceTypeID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InvoiceTypeSQL().tblInvoiceType_ForEdit(InvoiceTypeID));
        }

        public static InvoiceTypeEntity tblInvoiceType_SelectForUpdate(string InvoiceType, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InvoiceTypeSQL().tblInvoiceType_SelectForUpdate(InvoiceType, Active));
        }

        public static void tblInvoiceType_Update(InvoiceTypeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InvoiceTypeSQL().tblInvoiceType_Update(ObjEntity);
        }

        public static void tblInvoiceType_Delete(int InvoiceTypeID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InvoiceTypeSQL().tblInvoiceType_Delete(InvoiceTypeID);
        }
    }
}

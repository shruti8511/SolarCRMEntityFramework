using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class InvoicePaymentStatusManagement
    {
        public static void tblInvoicePaymentStatus_Insert(InvoicePaymentStatusEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InvoicePaymentStatusSQL().tblInvoicePaymentStatus_Insert(ObjEntity);
        }

        public static int tblInvoicePaymentStatus_Exists(string InvoicePaymentStatus)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InvoicePaymentStatusSQL().tblInvoicePaymentStatus_Exists(InvoicePaymentStatus));
        }

        public static List<InvoicePaymentStatusEntity> tblInvoicePaymentStatus_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InvoicePaymentStatusSQL().tblInvoicePaymentStatus_Select(CommonEntity, out Count));
        }

        public static List<InvoicePaymentStatusEntity> tblInvoicePaymentStatus_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InvoicePaymentStatusSQL().tblInvoicePaymentStatus_SelectActive());
        }

        public static InvoicePaymentStatusEntity tblInvoicePaymentStatus_ForEdit(int InvoicePaymentStatusID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InvoicePaymentStatusSQL().tblInvoicePaymentStatus_ForEdit(InvoicePaymentStatusID));
        }

        public static InvoicePaymentStatusEntity tblInvoicePaymentStatus_SelectForUpdate(string InvoicePaymentStatus, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.InvoicePaymentStatusSQL().tblInvoicePaymentStatus_SelectForUpdate(InvoicePaymentStatus, Active));
        }

        public static void tblInvoicePaymentStatus_Update(InvoicePaymentStatusEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InvoicePaymentStatusSQL().tblInvoicePaymentStatus_Update(ObjEntity);
        }

        public static void tblInvoicePaymentStatus_Delete(int InvoicePaymentStatusID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.InvoicePaymentStatusSQL().tblInvoicePaymentStatus_Delete(InvoicePaymentStatusID);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
   public class InvoiceTypeEntity
    {
        public int InvoiceTypeID { get; set; }
        public string InvoiceType { get; set; }
        public Boolean Active { get; set; }
        public int Seq { get; set; }
    }
}

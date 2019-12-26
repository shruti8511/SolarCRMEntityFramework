using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
    public class CustomerTypeEntity
    {
        public int CustTypeID { get; set; }
        public string CustType { get; set; }
        public Boolean Active { get; set; }
        public int Seq { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
    public class ProspectCategoryEntity
    {
        public int ProspectCatID { get; set; }
        public string ProspectCat { get; set; }
        public string ProspectCatABB { get; set; }
        public Boolean Active { get; set; }
        public int Seq { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
    public class PostCodeEntity
    {
        public int PostCodeID { get; set; }
        public int PostCode { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string POBoxes { get; set; }
        public string Area { get; set; }
        public int AreaType { get; set; }
        public string AreaTypee { get; set; }
        public int CompanyLocationID { get; set; }
        public string CompanyLocation { get; set; }
        public bool Active { get; set; }
    }
}

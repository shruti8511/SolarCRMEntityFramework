using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
   public class PromoOfferEntity
    {
        public int PromoOfferID { get; set; }
        public string PromoOffer { get; set; }
        public Boolean Active { get; set; }
        public int Seq { get; set; }
    }
}

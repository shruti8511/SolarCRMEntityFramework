using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class PromoOfferManagement
    {
        public static void tblPromoOffer_Insert(PromoOfferEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.PromoOfferSQL().tblPromoOffer_Insert(ObjEntity);
        }

        public static int tblPromoOffer_Exists(string PromoOffer)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PromoOfferSQL().tblPromoOffer_Exists(PromoOffer));
        }

        public static List<PromoOfferEntity> tblPromoOffer_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PromoOfferSQL().tblPromoOffer_Select(CommonEntity, out Count));
        }

        public static List<PromoOfferEntity> tblPromoOffer_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PromoOfferSQL().tblPromoOffer_SelectActive());
        }

        public static PromoOfferEntity tblPromoOffer_ForEdit(int PromoOfferID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PromoOfferSQL().tblPromoOffer_ForEdit(PromoOfferID));
        }

        public static PromoOfferEntity tblPromoOffer_SelectForUpdate(string PromoOffer, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PromoOfferSQL().tblPromoOffer_SelectForUpdate(PromoOffer, Active));
        }

        public static void tblPromoOffer_Update(PromoOfferEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.PromoOfferSQL().tblPromoOffer_Update(ObjEntity);
        }

        public static void tblPromoOffer_Delete(int PromoOfferID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.PromoOfferSQL().tblPromoOffer_Delete(PromoOfferID);
        }
    }
}

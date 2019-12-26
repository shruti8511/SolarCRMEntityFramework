using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;

namespace SolarCRM.BAL.Implementations.MastersModule
{
   public class ProspectCategoryManagement
    {
       public static void tblProspectCats_Insert(ProspectCategoryEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProspectCategorySQL().tblProspectCats_Insert(ObjEntity);
        }

       public static int tblProspectCats_Exists(string ProspectCat)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProspectCategorySQL().tblProspectCats_Exists(ProspectCat));
        }

       public static List<ProspectCategoryEntity> tblProspectCategory_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProspectCategorySQL().tblProspectCategory_Select(CommonEntity, out Count));
        }

        //public static List<ProspectCategoryEntity> tblProspectCategory_SelectActive()
        //{
        //    return (new SolarCRM.DAL.Implementations.MastersModule.ProspectCategorySQL().tblProspectCategory_SelectActive());
        //}

       public static ProspectCategoryEntity tblProspectCats_ForEdit(int ProspectCatID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProspectCategorySQL().tblProspectCats_ForEdit(ProspectCatID));
        }

       public static ProspectCategoryEntity tblProspectCats_SelectForUpdate(string ProspectCat, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ProspectCategorySQL().tblProspectCats_SelectForUpdate(ProspectCat, Active));
        }

       public static void tblProspectCats_Update(ProspectCategoryEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProspectCategorySQL().tblProspectCats_Update(ObjEntity);
        }

       public static void tblProspectCats_Delete(int ProspectCatID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.ProspectCategorySQL().tblProspectCats_Delete(ProspectCatID);
        }

    }
}

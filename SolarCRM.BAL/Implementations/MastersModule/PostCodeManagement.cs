using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.MastersModule
{
    public class PostCodeManagement
    {
        public static int tblPostCode_Insert(PostCodeEntity ObjEntity)
        {
            return new SolarCRM.DAL.Implementations.MastersModule.PostCodeSQL().tblPostCode_Insert(ObjEntity);
        }

        public static int tblPostCode_Exists(int PostCode)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PostCodeSQL().tblPostCode_Exists(PostCode));
        }

        public static List<PostCodeEntity> tblPostCode_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PostCodeSQL().tblPostCode_Select(CommonEntity, out Count));
        }

        //public static List<PostCodeEntity> tblPostCode_SelectActive()
        //{
        //    return (new SolarCRM.DAL.Implementations.MastersModule.PostCodeSQL().tblPostCode_SelectActive());
        //}

        public static PostCodeEntity tblPostCode_ForEdit(int PostCodeID)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PostCodeSQL().tblPostCode_ForEdit(PostCodeID));
        }

        public static PostCodeEntity tblPostCode_SelectForUpdate(int PostCode, Boolean Active)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.PostCodeSQL().tblPostCode_SelectForUpdate(PostCode, Active));
        }

        public static void tblPostCode_Update(PostCodeEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.MastersModule.PostCodeSQL().tblPostCode_Update(ObjEntity);
        }

        public static void tblPostCode_Delete(int PostCodeID)
        {
            new SolarCRM.DAL.Implementations.MastersModule.PostCodeSQL().tblPostCode_Delete(PostCodeID);
        }

    }
}

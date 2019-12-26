using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.Common;

namespace SolarCRM.BAL.Implementations.MastersModule
{
  public  class CustomerTypeManagement
    {

      public void tblCustomerType_Insert(CustomerTypeEntity ObjEntity)
      {
          new SolarCRM.DAL.Implementations.MastersModule.CustomerTypeSQL().tblCustomerType_Insert(ObjEntity);
      }

      public int tblCustType_Exists(string CustType)
      {
          return (new SolarCRM.DAL.Implementations.MastersModule.CustomerTypeSQL().tblCustType_Exists(CustType));
      }

      public List<CustomerTypeEntity> tblCustType_Select(PagingEntity CommonEntity, out int Count)
      {
          return (new SolarCRM.DAL.Implementations.MastersModule.CustomerTypeSQL().tblCustType_Select(CommonEntity, out Count));
      }

      public static List<CustomerTypeEntity> tblCustType_SelectActive()
      {
          return (new SolarCRM.DAL.Implementations.MastersModule.CustomerTypeSQL().tblCustType_SelectActive());
      }

      public CustomerTypeEntity tblCustType_ForEdit(int CustTypeID)
      {
          return (new SolarCRM.DAL.Implementations.MastersModule.CustomerTypeSQL().tblCustType_ForEdit(CustTypeID));
      }

      public CustomerTypeEntity tblCustType_SelectForUpdate(string CustType, Boolean Active)
      {
          return (new SolarCRM.DAL.Implementations.MastersModule.CustomerTypeSQL().tblCustType_SelectForUpdate(CustType, Active));
      }

      public void tblCustType_Update(CustomerTypeEntity ObjEntity)
      {
          new SolarCRM.DAL.Implementations.MastersModule.CustomerTypeSQL().tblCustType_Update(ObjEntity);
      }
  
      public void tblCustType_Delete(int CustTypeID)
      {
          new SolarCRM.DAL.Implementations.MastersModule.CustomerTypeSQL().tblCustType_Delete(CustTypeID);
      }

    }
}

using SolarCRM.Entity.Models.CompanyModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.CompanyModule
{
    public class CustInfoManagement
    {
        public static long tblCustInfo_Insert(CustInfoEntity CustInfoEntity)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustInfoSQL().tblCustInfo_Insert(CustInfoEntity));
        }


        public static List<CustInfoEntity> tblCustInfo_SelectByCustomerID(long CustomerID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustInfoSQL().tblCustInfo_SelectByCustomerID(CustomerID));
        }

        public static CustInfoEntity tblCustInfo_SelectForEdit(long CustInfoID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustInfoSQL().tblCustInfo_SelectForEdit(CustInfoID));
        }

        public static long tblCustInfo_Update(CustInfoEntity CustInfoEntity)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustInfoSQL().tblCustInfo_Update(CustInfoEntity));
        }

     

    }
}

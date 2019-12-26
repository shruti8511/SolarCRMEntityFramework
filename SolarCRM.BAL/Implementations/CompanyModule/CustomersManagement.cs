using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.CompanyModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.CompanyModule
{
    public class CustomersManagement
    {

        #region  Company Insert Call Method

        public static long tblCustomers_Insert(CustomersEntity CustEntity)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomers_Insert(CustEntity));
        }

        public static long tblCustomers_InsertContacts(long CustomerID, string ContMr, string ContFirst, string ContLast, string ContMobile, string ContEmail, long EmployeeID, long ContactEnteredBy)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomers_InsertContacts(CustomerID, ContMr, ContFirst, ContLast, ContMobile, ContEmail, EmployeeID, ContactEnteredBy));
        }

        public static long tblCompanyNumber_Insert(long CustomerID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCompanyNumber_Insert(CustomerID));
        }

        public static long tblCompanyNumber_Select(long CustomerID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCompanyNumber_Select(CustomerID));
        }
        public static void tblCustomers_UpdateCompanyNumber(long CustomerID, long CompanyNumber)
        {
            new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomers_UpdateCompanyNumber(CustomerID, CompanyNumber);
        }

        public static long tblCustDup_Insert(long CustEnteredBy, DateTime CustEntered, string DupName, string DupMobile, string DupEmail, string Customer, string ContEmail, string ContMobile, long CustomerID, long CompanyNumber)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustDup_Insert(CustEnteredBy, CustEntered, DupName, DupMobile, DupEmail, Customer, ContEmail, ContMobile, CustomerID, CompanyNumber));
        }

        public static long tblCustLogReport_Insert(long CustomerID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustLogReport_Insert(CustomerID));
        }

        public static long tblContacts_ExistName(string Contact)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_ExistName(Contact));
        }

        public static long tblContacts_ExistMobile(string Mobile)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_ExistMobile(Mobile));
        }

        public static long tblContacts_ExistEmail(string Email)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_ExistEmail(Email));
        }

        public static long tblCustomers_ExistPhone(string Phone)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomers_ExistPhone(Phone));
        }

        public static void ap_form_element_execute(string LogReport)
        {
            new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().ap_form_element_execute(LogReport);
        }

        #endregion

        #region Duplicate Entry Select

        public static List<CustomerExistEntity> tblContacts_ExistSelect(string Contact)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_ExistSelect(Contact));
        }

        public static List<CustomerExistEntity> tblContacts_ExistSelectMobile(string Mobile)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_ExistSelectMobile(Mobile));
        }

        public static List<CustomerExistEntity> tblContacts_ExistSelectEmail(string Email)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_ExistSelectEmail(Email));
        }

        public static List<CustomerExistEntity> tblContacts_ExistSelectPhone(string Phone)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_ExistSelectPhone(Phone));
        }
        #endregion

        #region  Bind Customerlist & Details & Add & Update Contacts

        public static List<CustomersEntity> tblCustomers_SelectRoleWise(PagingEntity CommonEntity, out int Count)
        {
            
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomers_SelectRoleWise(CommonEntity, out Count));
        }

        public static CustomersEntity tblCustomers_SelectByCustomerID(long CustomerID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomers_SelectByCustomerID(CustomerID));
        }

        public static List<ContactsEntity> tblContacts_SelectByCustomerID(long CustomerID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_SelectByCustomerID(CustomerID));
        }

        public static ContactsEntity tblContacts_SelectByContactID(long ContactID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_SelectByContactID(ContactID));
        }

        public static List<ContactsEntity> tblContLeadStatus_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContLeadStatus_SelectActive());
        }
        public static List<ContactsEntity> tblContLeadCancelReason_SelectActive()
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContLeadCancelReason_SelectActive());
        }

        public static void tblContacts_UpdateDetail(ContactsEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_UpdateDetail(ObjEntity);
        }
        

        #endregion

        #region  ContactNotes Insert & Get for bind

        public static void tblContNotes_Insert(ContactNotesEntity CustEntity)
        {
            new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContNotes_Insert(CustEntity);
        }

        public static List<ContactNotesEntity> tblContNotes_SelectByContactID(long ContactID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContNotes_SelectByContactID(ContactID));
        }

        #endregion


        public static void tblCustomers_UpdateCustType(int CustTypeID , long CustomerID)
        {
            new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomers_UpdateCustType(CustTypeID, CustomerID);
        }

        public static void tblContacts_UpdateContLeadStatus(int ContLeadStatusID, long ContactID)
        {
            new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_UpdateContLeadStatus(ContLeadStatusID, ContactID);
        }

        public static long tblCustomers_SelectContactID(string CustomerName)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomers_SelectContactID(CustomerName));
        }

        public static void tblCustomers_UpdateReferral(long CustomerID, long ContactID)
        {
            new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomers_UpdateReferral(CustomerID, ContactID);
        }



        public static CustomersEntity tblCustomer_ForEdit(int CustomerID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomer_ForEdit(CustomerID));
        }


        public static void tblCustomers_Update(CustomersEntity ObjEntity)
        {
            new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomers_Update(ObjEntity);
        }




        public static List<ContactsEntity> tblContacts_SelectByCustId(long CustomerID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_SelectByCustId(CustomerID));
        }


        public static List<CustomersEntity> tblCustomers_SelectForLeadTracker(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomers_SelectForLeadTracker(CommonEntity, out Count));
        }




        public static List<CustomersEntity> tblCustomers_SelectForContact(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomers_SelectForContact(CommonEntity, out Count));
        }

      
       
        public static List<ContactsEntity> tblContacts_SelectInstallerByState(string InstallState)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_SelectInstallerByState(InstallState));
        }
        public static List<ContactsEntity> tblContacts_SelectMeterElectrician(int isactive, string ContactID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_SelectMeterElectrician(isactive, ContactID));
        }
        public static List<ContactsEntity> tblContacts_SelectDesigner(int isactive, string ContactID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_SelectDesigner(isactive, ContactID));
        }
        public static List<ContactsEntity> tblContacts_SelectElectrician(int isactive, string ContactID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_SelectElectrician(isactive, ContactID));
        }
        public static List<ContactsEntity> tblContacts_SelectAvailInstaller(string date1, string date2, string InstallState, int isactive, string ContactID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_SelectAvailInstaller(date1, date2, InstallState, isactive, ContactID));
        }
        public static List<ContactsEntity> tblContacts_SelectDesignerByContactID(long CustomerID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_SelectDesignerByContactID(CustomerID));
        }
        public static List<ContactsEntity> tblContacts_SelectElectricianByContactID(long CustomerID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblContacts_SelectElectricianByContactID(CustomerID));
        }
        public static ContactsEntity tblCustomers_SelectByCustType(int Custtype)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomers_SelectByCustType(Custtype));
        }



        public static void tblCustomers_UpdateCustTypeID(int CustomerID,int CustTypeID)
        {
            new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomers_UpdateCustTypeID(CustomerID, CustTypeID);
        }


        public static List<CustomersEntity> tblCustomer_SelectByCustomerTypeID(int CustomerID)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomer_SelectByCustomerTypeID(CustomerID));
        }
        public static List<CustomersEntity> tblCustomer_SelectForLeadDashboard(string CustType, string userid)
        {
            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomer_SelectForLeadDashboard(CustType, userid));
        }
        public static List<CustomersEntity> tblCustomer_SelectForReport(DateTime FromDate, DateTime ToDate, String UserId)
        {

            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomer_SelectForReport(FromDate, ToDate, UserId));
        }
        public static List<CustomersEntity> tblCustomer_SelectForReportAll(String UserId)
        {

            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomer_SelectForReportAll(UserId));
        }
        public static List<CustomersEntity> tblCustomer_SelectSearchForReport(DateTime FromDate, DateTime ToDate, String UserId, string SearchKeyword, PagingEntity CommonEntity, out int Count)
        {

            return (new SolarCRM.DAL.Implementations.CompanyModule.CustomersSQL().tblCustomer_SelectSearchForReport(FromDate, ToDate, UserId, SearchKeyword, CommonEntity, out Count));
        }

    }
}

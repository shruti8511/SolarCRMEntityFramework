using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.CompanyModule
{
    public class CustomersEntity
    {
        public long CustomerID { get; set; }
        public long ContactID { get; set; }
        public long CompanyNumber { get; set; }
        public long EmployeeID { get; set; }
        public int CustTypeID { get; set; }
        public string CustType { get; set; }
        public int CustSourceID { get; set; }
        public string CustSource { get; set; }

        public int CustSourceSubID { get; set; }
        public string CustSourceSub { get; set; }
        public int ProjectTypeID { get; set; }
        public int ZoneID { get; set; }
        public DateTime? CustEntered { get; set; }
        public long CustEnteredBy { get; set; }
        public int ReferredBy { get; set; }
        public string CustMr { get; set; }
        public string CustFirst { get; set; }
        public string CustLast { get; set; }
        public string FullName { get; set; }
        public string Customer { get; set; }
        public string BranchLocation { get; set; }
        public string StreetAddress { get; set; }
        public string StreetArea { get; set; }
        public string StreetCity { get; set; }
        public string StreetState { get; set; }
        public string StreetPostCode { get; set; }
        public string PostalAddress { get; set; }
        public string PostalArea { get; set; }
        public string PostalCity { get; set; }
        public string PostalState { get; set; }
        public string PostalPostCode { get; set; }
        public string Country { get; set; }
        public string CustEmail { get; set; }
        public string CustMobile { get; set; }
        public string CustPhone { get; set; }
        public string CustPhone2 { get; set; }
        public string CustPhone3 { get; set; }
        public string CustAltPhone { get; set; }
        public string CustFax { get; set; }
        public string CustNotes { get; set; }
        public string CustWebSite { get; set; }
        public int LinkID { get; set; }
        public string OldQuoteNumber { get; set; }
        public int Area { get; set; }
        public string AreaName { get; set; }
        public int AssignBy { get; set; }
        public DateTime AssignDate { get; set; }
        public bool AssignFlag { get; set; }
        public int D2DEmployee { get; set; }
        public string D2DEnteredBy { get; set; }
        public DateTime D2DEntered { get; set; }
        public int appointment_status { get; set; }
        public int customer_lead_status { get; set; }
        public int OLDCustomerID { get; set; }
        public string CustRating { get; set; }       
        public int CompanyType  { get; set; }      
        public string CompanyTypeName { get; set; }    

        public int CompanyLocationID { get; set; }

        public string ReferredByProjectNo { get; set; }
        public string ReferredByCustomerName { get; set; }
        public string ReferredByProjectStatus { get; set; }
        public string ReferralNotes { get; set; }
        public string ReferredByBalOwing { get; set; }    
               
        // for show customer list
        public string Location { get; set; }
        public string ProjectType { get; set; }
        public string AssignedTo { get; set; }

        public string CompanySource { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string ProjectStatus { get; set; }

         public DateTime QuoteSent { get; set; }
         public DateTime LeadFollowUp { get; set; }
         
    }

    public class CustomerExistEntity
    {
        public string Contacts { get; set; }
        public string Locations { get; set; }
        public string ContMobile { get; set; }
        public string ContEmail { get; set; }
        public string AssignedTo { get; set; }
    }
}

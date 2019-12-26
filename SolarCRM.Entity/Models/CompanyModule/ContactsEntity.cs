using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.CompanyModule
{
    public class ContactsEntity
    {
        public long ContactID { get; set; }
        public long CustomerID { get; set; }
        public long EmployeeID { get; set; }
        public int CustStatusID { get; set; }
        public int ContLeadStatusID { get; set; }
        public string ContLeadStatus { get; set; }
        public int ContLeadCancelReasonID { get; set; }
        public string ContLeadCancelReason { get; set; }
        public bool ContTag { get; set; }
        public bool ContTag1 { get; set; }
        public bool ContTag2 { get; set; }
        public bool ContTag3 { get; set; }
        public bool PromoTag { get; set; }
        public bool LeadPromo { get; set; }
        public bool Newsletter { get; set; }
        public bool UploadTag { get; set; }
        public bool ActiveTag { get; set; }
        public bool ReferrerTag { get; set; }
        public DateTime ContactEntered { get; set; }
        public long ContactEnteredBy { get; set; }
        public string ContMr { get; set; }
        public string ContFirst { get; set; }
        public string ContLast { get; set; }
        public string ContMobile { get; set; }
        public string ContPhone { get; set; }
        public string ContHomePhone { get; set; }
        public string ContFax { get; set; }
        public string ContEmail { get; set; }
        public string ContEmailLink { get; set; }
        public bool SendEmail { get; set; }
        public bool SendMail { get; set; }
        public bool SendSMS { get; set; }
        public string ContNotes { get; set; }
        public DateTime LeadFollowUp { get; set; }
        public string Accreditation { get; set; }
        public string ElecLicence { get; set; }
        public DateTime ElecLicenceExpires { get; set; }
        public bool Installer { get; set; }
        public bool Designer { get; set; }
        public bool Electrician { get; set; }
        public bool MeterElectrician { get; set; }
        public int LinkID { get; set; }
        public int OLDContactID { get; set; }


        public string FullName { get; set; }
        public string Customer { get; set; }
        public string StreetAddress { get; set; }
        public string StreetArea { get; set; }
        public string StreetCity { get; set; }
        public string StreetState { get; set; }
        public string StreetPostCode { get; set; }
        public string Contact { get; set; }
    }
}

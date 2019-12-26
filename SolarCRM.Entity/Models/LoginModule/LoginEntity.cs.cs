using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SolarCRM.Entity.Models.LoginModule
{
    public class LoginEntity
    {
        public int id { get; set; }
        public string sitename { get; set; }
        public string sitelogo { get; set; }
        public string siteurl { get; set; }
        public string MailServer { get; set; }
        public string from { get; set; }
        public string cc { get; set; }
        public string username { get; set; }
        public string Password { get; set; }
        public string OrderThanksMessage { get; set; }
        public string ContactUsThanksmessage { get; set; }
        public string OrderSubject { get; set; }
        public string Contactussubject { get; set; }
        public string Regards_Name { get; set; }
        public string emailbodybordercolor { get; set; }
        public string adminfooter { get; set; }
        public string PaypalAccountName { get; set; }
        public string PaypalMode { get; set; }
        public string PaypalCurrencySymbol { get; set; }
        public string emailtop { get; set; }
        public string emailbottom { get; set; }
        public string sitelogoupload { get; set; }
        public string Authenticate { get; set; }
        public string SSLPortno { get; set; }
        public string SSLValue { get; set; }
        public string Hours { get; set; }
        public string Minutes { get; set; }
    }
}

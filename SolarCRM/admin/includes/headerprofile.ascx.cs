using SolarCRM.BAL.Implementations.LoginModule;
using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.Entity.Models.EmployeeModule;
using SolarCRM.Entity.Models.LoginModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolarCRM.admin.includes
{
    public partial class headerprofile : System.Web.UI.UserControl
    {
        protected string SiteURL;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;

            if (Request.IsAuthenticated)
            {
                string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
                AspnetUserEntity objemp = EmployeeManagement.aspnet_Users_SelectByUserId(userid);
                if (Roles.IsUserInRole("Administrator"))
                {
                    lblusername.Text = "Administrator";
                    lblusername1.Text = "Administrator";
                }
                else
                {
                    lblusername.Text = objemp.UserName;
                    lblusername1.Text = "Administrator";
                }
            }
        }

        protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
        {
            string UserId = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
            string LogOutTime = DateTime.Now.AddHours(0).ToString();
            string IPAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();

            LogInTrackEntity Objlogin = LoginManagement.tblLogInTrack_Select(UserId, IPAddress);
            if (Objlogin != null)
            {
                string Id = Objlogin.ID;
                LoginManagement.tblLogInTrack_Update(Id, LogOutTime, "False");
            }
            //HttpCookie logincookie = new HttpCookie("logincookie");

            //Response.Cookies.Remove("logincookie");
            //DateTime dtExpiry = DateTime.Now.AddDays(-10);
            //Response.Cookies["logincookie"].Expires = dtExpiry;

            //Session["userid"] = "";
            //Session["mtce"] = "";
            //Session[UserId] = "";
            //Session["trackeraccess"] = null;
            //Session["reportaccess"] = null;
            //Session["stockaccess"] = null;
            //Session["AddCall_Cust"] = "0";
            Session.Abandon();
            Response.Redirect(SiteURL + "/login.aspx");
        }
    }
}
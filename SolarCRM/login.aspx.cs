using SolarCRM.BAL.Implementations.LoginModule;
using SolarCRM.Entity.Models.LoginModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolarCRM
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*! test */
                //LoginEntity st = Loginservice.SpUtilitiesGetDataStructById("1");
                if (Request.Cookies["myCookie"] != null)
                {
                    HttpCookie cookie = Request.Cookies.Get("myCookie");

                    string username = cookie.Values["Uname"].ToString();
                    string password = cookie.Values["Pass"].ToString();

                    TextBox uname = (TextBox)login1.FindControl("UserName");
                    uname.Attributes.Add("value", username);

                    TextBox pass = (TextBox)login1.FindControl("Password");
                    pass.TextMode = TextBoxMode.Password;
                    pass.Attributes.Add("value", password);
                    login1.RememberMeSet = true;
                }

                if (Request.QueryString["success"] == "false")
                {
                    PanError.Visible = true;
                }
                else
                {
                    PanError.Visible = false;
                }
            }
            TextBox txt = (TextBox)login1.FindControl("UserName");
            txt.Focus();
        }

        public void Login1_LoggedIn(object sender, EventArgs e)
        {

            Session["userid"] = Membership.GetUser(this.login1.UserName.ToString()).ProviderUserKey.ToString();
            string UserId = Membership.GetUser(this.login1.UserName.ToString()).ProviderUserKey.ToString();
            string LogTime = Convert.ToString(DateTime.Now.AddHours(0));
            string IPAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();

            SingleSessionPreparation.CreateAndStoreSessionToken(this.login1.UserName.ToString());

            LoginManagement.tblLogInTrack_Insert(UserId, LogTime, IPAddress, "", "True");

            CheckBox rm = (CheckBox)login1.FindControl("RememberMe");
            if (rm.Checked)
            {
                HttpCookie myCookie = new HttpCookie("myCookie");
                Response.Cookies.Remove("myCookie");
                Response.Cookies.Add(myCookie);

                myCookie.Values.Add("Uname", this.login1.UserName.ToString());
                myCookie.Values.Add("Pass", this.login1.Password.ToString());
                DateTime dtExpiry = DateTime.Now.AddDays(100);

                Response.Cookies["myCookie"].Expires = dtExpiry;
            }
            else
            {
                HttpCookie myCookie = new HttpCookie("myCookie");

                Response.Cookies.Remove("myCookie");
                DateTime dtExpiry = DateTime.Now.AddDays(-10);
                Response.Cookies["myCookie"].Expires = dtExpiry;
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('It will logged you out from other device.');", true);
        }

        internal static class SingleSessionPreparation
        {
            /// <summary>
            /// Called during LoggedIn event. Need to pass username
            /// as login process not fully completed
            /// </summary>
            internal static void CreateAndStoreSessionToken(string userName)
            {
                // Will be using the response object several times
                HttpResponse pageResponse = HttpContext.Current.Response;

                // 'session' token
                Guid sessionToken = System.Guid.NewGuid();

                // Get authentication cookie and ticket
                HttpCookie authenticationCookie =
                    pageResponse.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket authenticationTicket =
                    FormsAuthentication.Decrypt(authenticationCookie.Value);

                // Create a new ticket based on the existing one that includes the 'session' token in the userData
                FormsAuthenticationTicket newAuthenticationTicket =
                    new FormsAuthenticationTicket(
                    authenticationTicket.Version,
                    authenticationTicket.Name,
                    authenticationTicket.IssueDate,
                    authenticationTicket.Expiration,
                    authenticationTicket.IsPersistent,
                    sessionToken.ToString(),
                    authenticationTicket.CookiePath);

                // Store session token in Membership comment
                // You may want to store other information in the comment
                // field, if so, you may have to implement some dilimited
                // structure within it, perhaps xml
                MembershipUser currentUser = Membership.GetUser(userName);
                currentUser.Comment = sessionToken.ToString();
                Membership.UpdateUser(currentUser);

                // Replace the authentication cookie
                pageResponse.Cookies.Remove(FormsAuthentication.FormsCookieName);

                HttpCookie newAuthenticationCookie = new HttpCookie(
                    FormsAuthentication.FormsCookieName,
                    FormsAuthentication.Encrypt(newAuthenticationTicket));

                newAuthenticationCookie.HttpOnly = authenticationCookie.HttpOnly;
                newAuthenticationCookie.Path = authenticationCookie.Path;
                newAuthenticationCookie.Secure = authenticationCookie.Secure;
                newAuthenticationCookie.Domain = authenticationCookie.Domain;
                newAuthenticationCookie.Expires = authenticationCookie.Expires;

                pageResponse.Cookies.Add(newAuthenticationCookie);
            }
        }

     
    }
}
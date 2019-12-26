using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SolarCRM
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        //protected void Application_AuthenticateRequest(object sender, EventArgs e)
        //{

        //}

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (User == null || User.Identity == null || !User.Identity.IsAuthenticated)
                return;

            _UpdateActivityDate();
        }
        private static void _UpdateActivityDate()
        {
            //MembershipUser user = Membership.GetUser();
            //if (user == null)
            //    return;

            //string userid = user.ProviderUserKey.ToString();
            //ClstblEmployees.aspnetUsers_Update_LastActivityDate(userid);
        }
    }
}
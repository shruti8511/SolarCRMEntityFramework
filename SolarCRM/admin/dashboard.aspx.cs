using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.Entity.Models.MastersModule;
using System.Web.Script.Serialization;
using SolarCRM.Entity.Models.ProjectModule;
using SolarCRM.BAL.Implementations.ProjectModule;


namespace SolarCRM.admin
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected string SiteURL;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;
            if (!IsPostBack)
            {
                string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
                ProjectsEntity objrole = ProjectsManagement.GetRoleIDByUserID(userid);
                if (objrole.RoleName == "Installer")
                {
                    Response.Redirect("dashboardinstaller.aspx");
                }
                if (objrole.RoleName == "DSalesRep" || objrole.RoleName == "SalesRep")
                {
                    Response.Redirect("dashboard2.aspx");
                }
                LeadCount lst = new LeadCount();
                lst = ProjectTypeManagement.tblLeadCount();
                lblleads.Text = lst.Lead.ToString();
                lblprospects.Text = lst.Potential.ToString();
               
            }
         
        }
      
        [System.Web.Services.WebMethod(EnableSession = true)]
       public static ProjectCount GetPiechartTodaysData()
        {
            try
            {

                ProjectCount lst = new ProjectCount();
                lst = ProjectTypeManagement.tblProjectsStatusCount();
                return lst;

            }
            catch
            {
                return null;
            }

        }
       
   
    }
}
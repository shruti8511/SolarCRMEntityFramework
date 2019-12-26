using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.Entity.Models.ProjectModule;
using SolarCRM.BAL.Implementations.ProjectModule;
using SolarCRM.PagingUserControl;
using SolarCRM.Entity.Models.Common;
using System.Web.Security;
using System.Globalization;
using System.IO;

namespace SolarCRM
{
    public partial class TeamDashboard : System.Web.UI.Page
    {
        protected string SiteURL;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;
            if (!IsPostBack)
            {
                BindTaskList();
            }
        }

        public void BindTaskList()
        {

            string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
         
            List<ProjectsEntity> lstProject = new List<ProjectsEntity>();
            lstProject = ProjectsManagement.tblProjects_SelectAll(userid);
            rptTaskList.DataSource = lstProject;
            rptTaskList.DataBind();
        }

        protected void rptTaskList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
        }

        protected void rptTaskList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Assign")
            {
                try
                {
                      try
                    {
                        long ProjectID;
                        ProjectID = Convert.ToInt64(e.CommandArgument);
                        Response.Redirect(SiteURL + "/admin/project/projectlist.aspx?projectid=" + Encryption.Encrypt(e.CommandArgument.ToString()));
                    }
                    catch (Exception ex)
                    {
                        string ERR;
                        ERR = "Error : " + ex.Message;
                    }


                }
                catch (Exception ex)
                {
                   
                }
            }

        }
    }
}
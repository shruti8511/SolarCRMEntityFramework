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
using SolarCRM.Entity.Models.Common;
using SolarCRM.PagingUserControl;
using SolarCRM.Entity.Models.ProjectModule;
using SolarCRM.BAL.Implementations.ProjectModule;
using SolarCRM.PagingUserControl;


namespace SolarCRM.admin
{
    public partial class dashboardinstaller : System.Web.UI.Page
    {
        protected string SiteURL;
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;
            if (!IsPostBack)
            {
                Session["PageNo"] = 1;
                Session["PageSize"] = 10;
              
                //string UserId = Session["userid"] ;

                BindProjectList();

            }
         
        }
        public void BindProjectList()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
          
                int Count = 0;
                List<ProjectsEntity> lstEntity = new List<ProjectsEntity>();
                lstEntity = ProjectsManagement.tblProjects_SelectInstallerProjects(objCommon, out Count, userid);
                rptProjectlist.DataSource = lstEntity;
                rptProjectlist.DataBind();
                pageGrid.BindPageing(Count);

            }
            catch (Exception ex)
            {
                //divSuccess.Visible = false;
                //divAlert.Visible = true;
                //lblErrorMsg.Text = "Error : " + ex.Message;
            }


        }
        public void BindProjectListSearch()
        {
            try
            {
                Session["pager"] = 1;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
          
                int Count = 0;
                List<ProjectsEntity> lstEntity = new List<ProjectsEntity>();
                lstEntity = ProjectsManagement.tblProjects_SelectSearchInstallerProjects(objCommon, txtSearch.Text.Trim(),userid, out Count);
                rptProjectlist.DataSource = lstEntity;
                rptProjectlist.DataBind();
                pageGrid.BindPageing(Count);
            }
            catch (Exception ex)
            {
              
            }
        }
        protected void rptProjectlist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName.ToString() == "Detail")
            {
                try
                {

                    //if (Request.QueryString["projectid"] != null)
                    // {
                    try
                    {
                        divprojectdetails.Visible = true;
                        divprojectlist.Visible = false;
                    }
                    catch (Exception ex)
                    {
                       
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void rptProjectlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindProjectList();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Session["PageNo"] = 1;
            txtSearch.Text = "";
            BindProjectList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            Session["PageNo"] = 1;
            BindProjectListSearch();
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static ProjectCount GetPiechartData()
        {
            try
            {
                string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();

                ProjectCount lst = new ProjectCount();
                lst = ProjectTypeManagement.tblProjectsStatusCountForInstaller(userid);
                return lst;

            }
            catch
            {
                return null;
            }

        }
    }
}
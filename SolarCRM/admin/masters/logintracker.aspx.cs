using SolarCRM.BAL.Implementations.LoginModule;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.LoginModule;
using SolarCRM.PagingUserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolarCRM.admin.masters
{
    public partial class logintracker : System.Web.UI.Page
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
                BindLoginTrack();
            }

        }

        private void BindLoginTrack()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<LogInTrackEntity> lstEntity = new List<LogInTrackEntity>();
                lstEntity = LoginManagement.tblLogInTrack_SelectAll(objCommon, out Count);
                rptLoginTrack.DataSource = lstEntity;
                rptLoginTrack.DataBind();
                pageGrid.BindPageing(Count);
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindLoginTrack();


        }

    }
}
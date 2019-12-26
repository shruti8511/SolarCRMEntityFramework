using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using SolarCRM.BAL.Implementations.CompanyModule;
using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.BAL.Implementations.ProjectModule;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.CompanyModule;
using SolarCRM.Entity.Models.EmployeeModule;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.ProjectModule;
using SolarCRM.PagingUserControl;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Globalization;
namespace SolarCRM.admin.reports
{
    public partial class Reports : System.Web.UI.Page
    {
        protected string SiteURL;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;
            //cmpNextDate.ValueToCompare = DateTime.Now.ToShortDateString();
            if (!IsPostBack)
            {

                string todaysdate = DateTime.Now.Date.ToString("yyyy-MM-dd");
                DateTime FromDate = Convert.ToDateTime(todaysdate);
                DateTime ToDate = Convert.ToDateTime(todaysdate);
                Session["PageNo"] = 1;
                Session["PageSize"] = 5;
                Session["PageNo1"] = 1;
                Session["PageSize1"] = 5;
                BindCompanyList(FromDate, ToDate);
            }

        }

        public void BindCompanyList(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
               // objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
               // objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);

                DateTime Fdate = System.Convert.ToDateTime((FromDate).ToString("yyyy-MM-dd"));
                DateTime Tdate = System.Convert.ToDateTime((ToDate).ToString("yyyy-MM-dd"));
                int Count = 0;
                List<CustomersEntity> lstEntity = new List<CustomersEntity>();
                string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
                TimeSpan ts = new TimeSpan(0, 0, 0);
                FromDate = Fdate.Add(ts);

                TimeSpan ts1 = new TimeSpan(23, 59, 0);
                ToDate = Tdate.Add(ts1);

                lstEntity = CustomersManagement.tblCustomer_SelectForReport(FromDate, ToDate, userid);
                rptCompanylist.DataSource = lstEntity;
                rptCompanylist.DataBind();
             //   pageGrid.BindPageing(Count);




            }
            catch (Exception ex)
            {
                // divSuccess.Visible = false;
                //divAlert.Visible = true;
                //lblErrorMsg.Text = "Error : " + ex.Message;
            }


        }
        //  public void BindCompanyListSearch(DateTime FromDate, DateTime ToDate, string SearchKeyword)
        //{
        //    try
        //    {
        //        Session["pager"] = 0;
        //        PagingEntity objCommon = new PagingEntity();
        //        objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
        //        objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);

        //        DateTime Fdate = System.Convert.ToDateTime((FromDate).ToString("yyyy-MM-dd"));
        //        DateTime Tdate = System.Convert.ToDateTime((ToDate).ToString("yyyy-MM-dd"));
        //        int Count = 0;
        //        List<CustomersEntity> lstEntity = new List<CustomersEntity>();
        //        string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
        //        TimeSpan ts = new TimeSpan(0, 0, 0);
        //        FromDate = Fdate.Add(ts);

        //        TimeSpan ts1 = new TimeSpan(23, 59, 0);
        //        ToDate = Tdate.Add(ts1);

        //      //  lstEntity = CustomersManagement.tblCustomer_SelectForReport(FromDate, ToDate, userid, objCommon, out Count);
        //        lstEntity = CustomersManagement.tblCustomer_SelectSearchForReport(FromDate, ToDate, userid, SearchKeyword, objCommon, out Count);
        //        rptCompanylist.DataSource = lstEntity;
        //        rptCompanylist.DataBind();
        //        pageGrid.BindPageing(Count);




        //    }
        //    catch (Exception ex)
        //    {
        //        // divSuccess.Visible = false;
        //        //divAlert.Visible = true;
        //        //lblErrorMsg.Text = "Error : " + ex.Message;
        //    }


        //}
        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            string todaysdate = DateTime.Now.Date.ToString("MM/dd/yyyy");
            DateTime FromDate = Convert.ToDateTime(todaysdate);
            DateTime ToDate = Convert.ToDateTime(todaysdate);

            BindCompanyList(FromDate, ToDate);

        }

        protected void rptCompanylist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

       
        protected void lnkTodayLead_Click(object sender, EventArgs e)
        {
            divprojectlist.Visible = false;
            divcompanylist.Visible = true;
            string todaysdate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            DateTime FromDate = Convert.ToDateTime(todaysdate);
            DateTime ToDate = Convert.ToDateTime(todaysdate);
            BindCompanyList(FromDate, ToDate);
        }

        protected void lnkThisWeek_Click(object sender, EventArgs e)
        {
            divprojectlist.Visible = false;
            divcompanylist.Visible = true;
            DateTime startOfWeek = DateTime.Today.AddDays((int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - (int)DateTime.Today.DayOfWeek);

            string result = string.Join("," + Environment.NewLine, Enumerable.Range(0, 7).Select(i => startOfWeek.AddDays(i).ToString("yyyy-MM-dd")));
            String[] namesList = result.Split(',');


            DateTime FromDate = Convert.ToDateTime(namesList[0]);
            DateTime ToDate = Convert.ToDateTime(namesList[6]);
            BindCompanyList(FromDate, ToDate);
        }

        protected void lnkthismonth_Click(object sender, EventArgs e)
        {
            divprojectlist.Visible = false;
            divcompanylist.Visible = true;
            string todaysdate = DateTime.Now.Date.ToString("yyyy-MM-dd");

            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
           
            DateTime FromDate = Convert.ToDateTime(startDate);
            DateTime ToDate = Convert.ToDateTime(endDate);
          

            BindCompanyList(FromDate, ToDate);
        }

        protected void lnkAllLead_Click(object sender, EventArgs e)
        {
            try
            {
                divprojectlist.Visible = false;
                divcompanylist.Visible = true;
                string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();

                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<CustomersEntity> lstEntity = new List<CustomersEntity>();
                lstEntity = CustomersManagement.tblCustomer_SelectForReportAll(userid);
                rptCompanylist.DataSource = lstEntity;
                rptCompanylist.DataBind();
             //   pageGrid.BindPageing(Count);




            }
            catch (Exception ex)
            {
                // divSuccess.Visible = false;
                //divAlert.Visible = true;
                //lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void rptProjectlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        public void BindProjectList(string projectstatustype)
        {
            try
            {
                string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();

                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
              
                List<ProjectsEntity> lstEntity = new List<ProjectsEntity>();
              
                lstEntity = ProjectsManagement.tblProjects_SelectByProjectStatus(userid, projectstatustype);
                rptProjectlist.DataSource = lstEntity;
                rptProjectlist.DataBind();
               // pageGrid.BindPageing(Count);

            }
            catch (Exception ex)
            {
                //divSuccess.Visible = false;
                //divAlert.Visible = true;
                //lblErrorMsg.Text = "Error : " + ex.Message;
            }


        }

        //public void BindProjectListSearch(string projectstatustype, string SearchKeyword)
        //{
        //    try
        //    {
        //        string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();

        //        Session["pager"] = 0;
        //        PagingEntity objCommon = new PagingEntity();
        //        objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
        //        objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
        //        int Count = 0;

        //        List<ProjectsEntity> lstEntity = new List<ProjectsEntity>();

        //       // lstEntity = ProjectsManagement.tblProjects_SelectByProjectStatus(userid, projectstatustype, objCommon, out Count);
        //        lstEntity = ProjectsManagement.tblProjects_SelectSearchByProjectStatus(userid, projectstatustype, SearchKeyword, objCommon, out Count);
        //        rptProjectlist.DataSource = lstEntity;
        //        rptProjectlist.DataBind();
        //        pageGrid.BindPageing(Count);

        //    }
        //    catch (Exception ex)
        //    {
        //        //divSuccess.Visible = false;
        //        //divAlert.Visible = true;
        //        //lblErrorMsg.Text = "Error : " + ex.Message;
        //    }


        //}

        protected void lnkActiveProject_Click(object sender, EventArgs e)
        {
            divcompanylist.Visible = false;
            divprojectlist.Visible = true;
            BindProjectList("Active");
        }

        protected void lnkClosedProject_Click(object sender, EventArgs e)
        {
            divcompanylist.Visible = false;
            divprojectlist.Visible = true;
            BindProjectList("Closed");

        }

        protected void lnkCompletedProject_Click(object sender, EventArgs e)
        {
            divcompanylist.Visible = false;
            divprojectlist.Visible = true;
            BindProjectList("Complete");

        }

        protected void lnkCancelledProject_Click(object sender, EventArgs e)
        {
            divcompanylist.Visible = false;
            divprojectlist.Visible = true;
            BindProjectList("Cancelled");

        }

    

    }
}
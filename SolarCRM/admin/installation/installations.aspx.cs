using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolarCRM.admin.installation
{
    public partial class installations : System.Web.UI.Page
    {
        protected string SiteURL;
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;

            if (!IsPostBack)
            {
                int offset = DateTime.Now.AddHours(0).DayOfWeek - DayOfWeek.Monday;
                DateTime lastMonday = DateTime.Now.AddHours(0).AddDays(-offset);
                BindWeekDates(lastMonday);

                
                if (Roles.IsUserInRole("Installer"))
                {
                   // ddlInstaller.Visible = false;
                }
                else
                {
                   // ddlInstaller.Visible = true;
                }
               
            }
        }


        public void BindWeekDates(DateTime startdate)
        {
            ArrayList values = new ArrayList();
            for (int i = 0; i < 7; i++)
            {
                values.Add(new PositionData(startdate.AddDays(i).ToShortDateString(), CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(startdate.AddDays(i).DayOfWeek)));
            }

            RptDays.DataSource = values;
            RptDays.DataBind();

            RepeaterItem item0 = RptDays.Items[0];
            string hdnDate0 = ((HiddenField)item0.FindControl("hdnDate")).Value;
            RepeaterItem item6 = RptDays.Items[6];
            string hdnDate6 = ((HiddenField)item6.FindControl("hdnDate")).Value;

            ltdate.Text = string.Format("{0:MMM dd yyyy}", Convert.ToDateTime(hdnDate0)) + " - " + string.Format("{0:MMM dd yyyy}", Convert.ToDateTime(hdnDate6));
        }
        public class PositionData
        {
            private string CDate;
            private string CDay;
            public PositionData(string CDate, string CDay)
            {
                this.CDate = CDate;
                this.CDay = CDay;
            }
            public string CDATE
            {
                get
                {
                    return CDate;
                }
            }
            public string CDAY
            {
                get
                {
                    return CDay;
                }
            }
        }

        protected void btntoday_Click(object sender, EventArgs e)
        {
            BindWeekDates(DateTime.Now.AddHours(0));
        }

        protected void btnnextweek_Click(object sender, EventArgs e)
        {
            if (RptDays.Items.Count > 6)
            {
                RepeaterItem item = RptDays.Items[6];
                string enddate = ((HiddenField)item.FindControl("hdnDate")).Value;
                BindWeekDates(Convert.ToDateTime(enddate).AddDays(1));
            }
        }
        protected void btnpreviousweek_Click(object sender, EventArgs e)
        {
            if (RptDays.Items.Count > 6)
            {
                RepeaterItem item = RptDays.Items[0];
                string startdate = ((HiddenField)item.FindControl("hdnDate")).Value;
                BindWeekDates(Convert.ToDateTime(startdate).AddDays(-7));
            }
        }
        protected void btnpreviousday_Click(object sender, EventArgs e)
        {
            if (RptDays.Items.Count > 6)
            {
                RepeaterItem item = RptDays.Items[0];
                string startdate = ((HiddenField)item.FindControl("hdnDate")).Value;
                BindWeekDates(Convert.ToDateTime(startdate).AddDays(-1));
            }
        }
        protected void btnnextday_Click(object sender, EventArgs e)
        {
            if (RptDays.Items.Count > 6)
            {
                RepeaterItem item = RptDays.Items[0];
                string enddate = ((HiddenField)item.FindControl("hdnDate")).Value;
                BindWeekDates(Convert.ToDateTime(enddate).AddDays(1));
            }
        }

        protected void RptDays_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
          
        }
        
    }
}
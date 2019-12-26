using SolarCRM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolarCRM.PagingUserControl
{
    public partial class PagingUserControl : System.Web.UI.UserControl
    {
        public event EventHandler<PagerEventArgs> PagerChanged;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Company Pagging
        protected void rptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var args = new PagerEventArgs { };
            if (e.CommandName == "ChangePage")
            {
                Session["PageNo"] = e.CommandArgument;

            }
            this.PagerChanged(this, args);
        }
        protected void rptPaging_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            LinkButton lnkPageNo = (LinkButton)e.Item.FindControl("lnkPageNo");
            if (Convert.ToInt32(Session["PageNo"]) == Convert.ToInt32(lnkPageNo.Text))
            {
                lnkPageNo.Attributes.Add("style", "font-weight:bold;");
            }

        }
        protected void lnkPrevious_Click(object sender, EventArgs e)
        {
            var args = new PagerEventArgs { };
            Session["PageNo"] = Convert.ToInt32(Session["PageNo"]) - 1;

            this.PagerChanged(this, args);
        }
        protected void lnkNext_Click(object sender, EventArgs e)
        {
            var args = new PagerEventArgs { };
            Session["PageNo"] = Convert.ToInt32(Session["PageNo"]) + 1;

            this.PagerChanged(this, args);
        }
        public void BindPageing(long RowCount)
        {
            int PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(RowCount) / Convert.ToInt32(Session["PageSize"])));
            if (PageCount > 1)
            {
                if (PageCount < Convert.ToInt32(Session["PageNo"]))
                {
                    Session["PageNo"] = PageCount;
                    Session["NewPage"] = 1;
                }
                List<int> lstPage = Pagging.GetPaggingdata(RowCount, Convert.ToInt32(Session["PageNo"]), Convert.ToInt32(Session["PageSize"]));
                rptPaging.Visible = true;
                rptPaging.DataSource = lstPage;
                rptPaging.DataBind();
                if (Convert.ToInt32(Session["PageNo"]) == 1)
                    lnkPrevious.Visible = false;
                else
                    lnkPrevious.Visible = true;

                if (Convert.ToInt32(Session["PageNo"]) == PageCount)
                    lnkNext.Visible = false;
                else
                    lnkNext.Visible = true;
            }
            else
            {

                rptPaging.Visible = false;
                lnkNext.Visible = false;
                lnkPrevious.Visible = false;


            }
            if (PageCount == 1)
            {
                Session["PageNo"] = 1;
                Session["NewPage"] = 1;
                List<int> lstPage = Pagging.GetPaggingdata(RowCount, Convert.ToInt32(Session["PageNo"]), Convert.ToInt32(Session["PageSize"]));
                rptPaging.Visible = false;
                rptPaging.DataSource = lstPage;
                rptPaging.DataBind();
                if (Convert.ToInt32(Session["PageNo"]) == 1)
                    lnkPrevious.Visible = false;
                else
                    lnkPrevious.Visible = true;

                if (Convert.ToInt32(Session["PageNo"]) == PageCount)
                    lnkNext.Visible = false;
                else
                    lnkNext.Visible = true;
            }
        }
        #endregion

    }

    public class PagerEventArgs : EventArgs
    {

    }
}
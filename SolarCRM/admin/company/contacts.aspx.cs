using SolarCRM.BAL.Implementations.CompanyModule;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.CompanyModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolarCRM.admin.company
{
    public partial class contacts : System.Web.UI.Page
    {
        protected string SiteURL;
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;
            Session["PageNo"] = 1;
            Session["PageSize"] = 10;
            BindContactList();
        }


        public void BindContactList()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<CustomersEntity> lstEntity = new List<CustomersEntity>();
                lstEntity = CustomersManagement.tblCustomers_SelectForContact(objCommon, out Count);
                rptContacts.DataSource = lstEntity;
                rptContacts.DataBind();
                pageGrid.BindPageing(Count);

            }
            catch (Exception ex)
            {
                //divSuccess.Visible = false;
                //divAlert.Visible = true;
                //lblErrorMsg.Text = "Error : " + ex.Message;
            }


        }


    }
}
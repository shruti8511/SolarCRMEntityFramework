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
using SolarCRM.BAL.Implementations.CompanyModule;
using SolarCRM.Entity.Models.CompanyModule;
using SolarCRM.PagingUserControl;
using SolarCRM.Entity.Models.Common;
using System.Web.Security;
using System.Globalization;
using System.IO;
namespace SolarCRM.admin
{
    public partial class dashboard2 : System.Web.UI.Page
    {
        protected string SiteURL;
        long CustomerID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;
            if (!IsPostBack)
            {
                BindProjectList();
            }
        }
        public void BindProjectList()
        {

            string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();

            List<CustomersEntity> lstNew = new List<CustomersEntity>();
            lstNew = CustomersManagement.tblCustomer_SelectForLeadDashboard("New",userid);
            rptNewList.DataSource = lstNew;
            rptNewList.DataBind();

            List<CustomersEntity> lstCold = new List<CustomersEntity>();
            lstCold = CustomersManagement.tblCustomer_SelectForLeadDashboard("Cold",userid);
            rptColdList.DataSource = lstCold;
            rptColdList.DataBind();

            List<CustomersEntity> lstHot = new List<CustomersEntity>();
            lstHot = CustomersManagement.tblCustomer_SelectForLeadDashboard("Hot",userid);
            rptHotList.DataSource = lstHot;
            rptHotList.DataBind();

            List<CustomersEntity> lstPotential = new List<CustomersEntity>();
            lstPotential = CustomersManagement.tblCustomer_SelectForLeadDashboard("Potential",userid);
            rptPotentialList.DataSource = lstPotential;
            rptPotentialList.DataBind();

            List<CustomerTypeEntity> lstCustType = new List<CustomerTypeEntity>();
            lstCustType = CustomerTypeManagement.tblCustType_SelectActive();
            ddlCustTypeID.DataSource = lstCustType;
            ddlCustTypeID.DataMember = "CustType";
            ddlCustTypeID.DataTextField = "CustType";
            ddlCustTypeID.DataValueField = "CustTypeID";
            ddlCustTypeID.DataBind();
        }
        protected void rptNewList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    CustomerID = Convert.ToInt64(e.CommandArgument);
                    hdnCustomerID.Value = CustomerID.ToString();
                    divCustType.Attributes.Add("class", "modal fade modal-overflow in");
                    divCustType.Attributes.Add("Style", "display:block;");

                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void rptNewList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptColdList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    CustomerID = Convert.ToInt64(e.CommandArgument);
                    hdnCustomerID.Value = CustomerID.ToString();
                    divCustType.Attributes.Add("class", "modal fade modal-overflow in");
                    divCustType.Attributes.Add("Style", "display:block;");

                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void rptColdList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptHotList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    // hdnCustomerID.Value = Request.QueryString["customerid"].ToString();
                    CustomerID = Convert.ToInt64(e.CommandArgument);
                    hdnCustomerID.Value = CustomerID.ToString();
                    divCustType.Attributes.Add("class", "modal fade modal-overflow in");
                    divCustType.Attributes.Add("Style", "display:block;");

                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void rptHotList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptPotentialList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    // hdnCustomerID.Value = Request.QueryString["customerid"].ToString();
                    CustomerID = Convert.ToInt64(e.CommandArgument);
                    hdnCustomerID.Value = CustomerID.ToString();
                    divCustType.Attributes.Add("class", "modal fade modal-overflow in");
                    divCustType.Attributes.Add("Style", "display:block;");

                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void rptPotentialList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect(SiteURL + "/admin/company/addcompany.aspx?custtypeid=" + 9);
        }

        protected void btnEditPotential_Click(object sender, EventArgs e)
        {

        }

        protected void btnClosedivCustType_Click(object sender, EventArgs e)
        {
            divCustType.Attributes.Remove("class");
            divCustType.Attributes.Add("class", "modal fade");
            divCustType.Attributes.Remove("Style");

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ddlCustTypeID.SelectedValue != "")
            {
                CustomersManagement.tblCustomers_UpdateCustType(Convert.ToInt32(ddlCustTypeID.SelectedValue), Convert.ToInt32(hdnCustomerID.Value));
                divCustType.Attributes.Remove("class");
                divCustType.Attributes.Add("class", "modal fade");
                divCustType.Attributes.Remove("Style");
                ddlCustTypeID.Items.Clear();
                BindProjectList();
            }

        }
    }
}
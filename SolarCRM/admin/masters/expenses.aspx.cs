using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.PagingUserControl;
using SolarCRM.Entity.Models.Common;
using System.Web.Security;
using System.Globalization;

namespace SolarCRM.admin.masters
{
    public partial class expenses : System.Web.UI.Page
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
                BindExpense();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
          
                ExpensesEntity objEntity = new ExpensesEntity();
                objEntity.ExpenseName = txtExpName.Text.Trim();
                objEntity.IsActive = chkActive.Checked;
                objEntity.UserId = userid;
                objEntity.Symbol = "fa fa-fa fa-road";
                
                int Exists = ExpensesManagement.tblExpense_Exists(objEntity.ExpenseName);
                if (Exists == 0)
                {
                    long Success = ExpensesManagement.tblExpenses_Insert(objEntity);
                    
                   BindExpense();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Expense Added Successfully";
                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Expense Already Exist.";
                }

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void btnalert_Click(object sender, EventArgs e)
        {
            divAlert.Visible = false;
        }

        protected void btnSuccess_Click(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
        }

        protected void rptExpenses_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        private void BindExpense()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<ExpensesEntity> lstEntity = new List<ExpensesEntity>();
                lstEntity = ExpensesManagement.tblExpenses_Select(objCommon, out Count);
                rptExpenses.DataSource = lstEntity;
                rptExpenses.DataBind();
                //pageGrid.BindPageing(Count);

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }
        public void BindExpenseSearch()
        {
            try
            {
                Session["pager"] = 1;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<ExpensesEntity> lstEntity = new List<ExpensesEntity>();
                lstEntity = ExpensesManagement.tblExpenses_SelectSearch(objCommon, txtSearch.Text.Trim(), out Count);
                rptExpenses.DataSource = lstEntity;
                rptExpenses.DataBind();
                //pageGrid.BindPageing(Count);
            }
            catch (Exception ex)
            {

            }
        }
        private void Reset()
        {
            txtExpName.Text = string.Empty;
            chkActive.Checked = true;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindExpenseSearch();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            BindExpense();
            txtSearch.Text = "";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

    
    
    }
}
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

namespace SolarCRM.admin.masters
{
    public partial class financewithsub : System.Web.UI.Page
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
                CompanySourceDropDownList();
                BindFinanceWithSub();
            }
        }

        public void CompanySourceDropDownList()
        {
            List<FinanceWithSubEntity> lstEntity = new List<FinanceWithSubEntity>();
            lstEntity = FinanceWithSubManagement.tblFinanceWith_SelectForDropdown();
            ddlFinanceWith.DataSource = lstEntity;
            ddlFinanceWith.DataTextField = "FinanceWith";
            ddlFinanceWith.DataValueField = "FinanceWithID";
            ddlFinanceWith.DataBind();
            ddlFinanceWith.Items.Insert(0, new ListItem("Select", "0"));

        }

        private void BindFinanceWithSub()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<FinanceWithSubEntity> lstEntity = new List<FinanceWithSubEntity>();
                lstEntity = FinanceWithSubManagement.tblFinanceWithSub_Select(objCommon, out Count);
                rptFinanceWithSub.DataSource = lstEntity;
                rptFinanceWithSub.DataBind();
                pageGrid.BindPageing(Count);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.InnerException + " or  Check your data.');", true);

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FinanceWithSubEntity objEntity = new FinanceWithSubEntity();

                int Exist = FinanceWithSubManagement.tblFinanceWithSub_Exists(txtFinanceWithSub.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.FinanceWithID = Convert.ToInt32(ddlFinanceWith.SelectedValue);
                    objEntity.FinanceWithSub = txtFinanceWithSub.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    FinanceWithSubManagement.tblFinanceWithSub_Insert(objEntity);
                    BindFinanceWithSub();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Finance Sub Type Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Finance Sub Type Already Exist.";
                    // txtFinanceWithSub.Text = "";
                    // txtFinanceWithSub.Focus();
                    //BindFinanceWithSub();
                    //Reset();
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

        protected void rptFinanceWithSub_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    var lstEntity = FinanceWithSubManagement.tblFinanceWithSub_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnFinanceWithSubID.Value = lstEntity.FinanceWithSubID.ToString();
                    ddlFinanceWith.SelectedValue = lstEntity.FinanceWithID.ToString();
                    txtFinanceWithSub.Text = lstEntity.FinanceWithSub;
                    chkActive.Checked = lstEntity.Active;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                }
                catch (Exception ex)
                {
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "Error : " + ex.Message;
                }


            }
            else if (e.CommandName.ToString() == "Delete")
            {
                try
                {
                    FinanceWithSubManagement.tblFinanceWithSub_Delete(Convert.ToInt32(e.CommandArgument));
                    BindFinanceWithSub();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Finance Sub Type Deleted Successfully";
                }
                catch (Exception ex)
                {
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "Error : " + ex.Message;

                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var lstEntity = FinanceWithSubManagement.tblFinanceWithSub_SelectForUpdate(txtFinanceWithSub.Text.Trim(), chkActive.Checked);
                if (lstEntity.FinanceWithSub != null)
                {
                    if (txtFinanceWithSub.Text.Trim() == lstEntity.FinanceWithSub && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Finance Sub Type Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    FinanceWithSubEntity ObjEntity = new FinanceWithSubEntity();
                    ObjEntity.FinanceWithSubID = Convert.ToInt32(hdnFinanceWithSubID.Value);
                    ObjEntity.FinanceWithID = Convert.ToInt32(ddlFinanceWith.SelectedValue);
                    ObjEntity.FinanceWithSub = txtFinanceWithSub.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    FinanceWithSubManagement.tblFinanceWithSub_Update(ObjEntity);
                    BindFinanceWithSub();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Finance Sub Type Updated Successfully";
                    Reset();
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                }
            }
            catch (Exception ex)
            {
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;

            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            txtFinanceWithSub.Text = string.Empty;
            ddlFinanceWith.SelectedIndex = 0;
            chkActive.Checked = true;
            hdnFinanceWithSubID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindFinanceWithSub();

            //if (Convert.ToInt32(Session["pager"]) == 1)
            //{
            //    bindsearch();
            //}
            //else
            //{
            //    BindAmount();
            //}
        }

        protected void btnSuccess_Click(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
        }


    }
}
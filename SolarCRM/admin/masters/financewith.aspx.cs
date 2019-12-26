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
    public partial class financewith : System.Web.UI.Page
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
                BindFinanceWith();
            }
        }

        private void BindFinanceWith()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<FinanceWithEntity> lstEntity = new List<FinanceWithEntity>();
                lstEntity = FinanceWithManagement.tblFinanceWith_Select(objCommon, out Count);
                rptFinanceWith.DataSource = lstEntity;
                rptFinanceWith.DataBind();
                pageGrid.BindPageing(Count);

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FinanceWithEntity objEntity = new FinanceWithEntity();

                int Exist = FinanceWithManagement.tblFinanceWith_Exists(txtFinanceWith.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.FinanceWith = txtFinanceWith.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    FinanceWithManagement.tblFinanceWith_Insert(objEntity);
                    BindFinanceWith();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Finance Type Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Finance Type Already Exist.";
                    // txtFinanceWith.Text = "";
                    // txtFinanceWith.Focus();
                    //BindFinanceWith();
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

        protected void rptFinanceWith_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = FinanceWithManagement.tblFinanceWith_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnFinanceWithID.Value = lstEntity.FinanceWithID.ToString();
                    txtFinanceWith.Text = lstEntity.FinanceWith;
                    chkActive.Checked = lstEntity.Active;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                }
                catch (Exception ex)
                {
                    divSuccess.Visible = false;
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "Error : " + ex.Message;
                }


            }
            else if (e.CommandName.ToString() == "Delete")
            {
                try
                {
                    FinanceWithManagement.tblFinanceWith_Delete(Convert.ToInt32(e.CommandArgument));
                    BindFinanceWith();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Finance Type Deleted Successfully";
                }
                catch (Exception ex)
                {
                    divSuccess.Visible = false;
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "Error : " + ex.Message;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var lstEntity = FinanceWithManagement.tblFinanceWith_SelectForUpdate(txtFinanceWith.Text.Trim(), chkActive.Checked);
                if (lstEntity.FinanceWith != null)
                {
                    if (txtFinanceWith.Text.Trim() == lstEntity.FinanceWith && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Finance Type Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    FinanceWithEntity ObjEntity = new FinanceWithEntity();
                    ObjEntity.FinanceWithID = Convert.ToInt32(hdnFinanceWithID.Value);
                    ObjEntity.FinanceWith = txtFinanceWith.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    FinanceWithManagement.tblFinanceWith_Update(ObjEntity);
                    BindFinanceWith();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Finance Type Updated Successfully";
                    Reset();
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                }
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
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
            txtFinanceWith.Text = string.Empty;
            chkActive.Checked = true;
            hdnFinanceWithID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }


        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindFinanceWith();

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
using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.PagingUserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolarCRM.admin.masters
{
    public partial class leadcancelreason : System.Web.UI.Page
    {
        protected string SiteURL;

        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;

            if (!IsPostBack)
            {
                Session["PageNo"] = 1;
                Session["PageSize"] = 2;
                BindLeadCancelReason();
            }
        }

        private void BindLeadCancelReason()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<LeadCancelReasonEntity> lstEntity = new List<LeadCancelReasonEntity>();
                lstEntity = LeadCancelReasonManagement.tblContLeadCancelReason_Select(objCommon, out Count);
                rptLeadCancelReason.DataSource = lstEntity;
                rptLeadCancelReason.DataBind();
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
                LeadCancelReasonEntity objEntity = new LeadCancelReasonEntity();

                int Exist = LeadCancelReasonManagement.tblContLeadCancelReason_Exists(txtLeadCancelReason.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.ContLeadCancelReason = txtLeadCancelReason.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;                 
                    LeadCancelReasonManagement.tblContLeadCancelReason_Insert(objEntity);
                    BindLeadCancelReason();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Lead Cancel Reason Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Lead Cancel Reason Already Exist.";
                    // txtLeadCancelReason.Text = "";
                    // txtLeadCancelReason.Focus();
                    //BindLeadCancelReason();
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

        protected void rptLeadCancelReason_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = LeadCancelReasonManagement.tblContLeadCancelReason_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnContLeadCancelReasonID.Value = lstEntity.ContLeadCancelReasonID.ToString();
                    txtLeadCancelReason.Text = lstEntity.ContLeadCancelReason;
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
                    LeadCancelReasonManagement.tblContLeadCancelReason_Delete(Convert.ToInt32(e.CommandArgument));
                    BindLeadCancelReason();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Lead Cancel Reason Deleted Successfully";
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
                var lstEntity = LeadCancelReasonManagement.tblContLeadCancelReason_SelectForUpdate(txtLeadCancelReason.Text.Trim(), chkActive.Checked);
                if (lstEntity.ContLeadCancelReason != null)
                {
                    if (txtLeadCancelReason.Text.Trim() == lstEntity.ContLeadCancelReason && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Lead Cancel Reason Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    LeadCancelReasonEntity ObjEntity = new LeadCancelReasonEntity();
                    ObjEntity.ContLeadCancelReasonID = Convert.ToInt32(hdnContLeadCancelReasonID.Value);
                    ObjEntity.ContLeadCancelReason = txtLeadCancelReason.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    LeadCancelReasonManagement.tblContLeadCancelReason_Update(ObjEntity);
                    BindLeadCancelReason();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Lead Cancel Reason Updated Successfully";
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
            txtLeadCancelReason.Text = string.Empty;
            chkActive.Checked = true;
            hdnContLeadCancelReasonID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }



        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindLeadCancelReason();

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
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
    public partial class insuranceclaimstatus : System.Web.UI.Page
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
                BindInsuranceClaimStatus();
            }
        }

        private void BindInsuranceClaimStatus()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<InsuranceClaimStatusEntity> lstEntity = new List<InsuranceClaimStatusEntity>();
                lstEntity = InsuranceClaimStatusManagement.tblInsuranceClaimStatus_Select(objCommon, out Count);
                rptInsuranceClaimStatus.DataSource = lstEntity;
                rptInsuranceClaimStatus.DataBind();
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
                InsuranceClaimStatusEntity objEntity = new InsuranceClaimStatusEntity();

                int Exist = InsuranceClaimStatusManagement.tblInsuranceClaimStatus_Exists(txtInsuranceClaimStatus.Text.Trim());
                if (Exist == 0)
                {
                    objEntity.InsuranceClaimStatus = txtInsuranceClaimStatus.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    InsuranceClaimStatusManagement.tblInsuranceClaimStatus_Insert(objEntity);
                    BindInsuranceClaimStatus();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Insurance Claim Status Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Insurance Claim Status Already Exist.";
                    // txtInsuranceClaimStatus.Text = "";
                    // txtInsuranceClaimStatus.Focus();
                    //BindInsuranceClaimStatus();
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

        protected void rptInsuranceClaimStatus_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = InsuranceClaimStatusManagement.tblInsuranceClaimStatus_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnInsuranceClaimStatusID.Value = lstEntity.InsuranceClaimStatusID.ToString();
                    txtInsuranceClaimStatus.Text = lstEntity.InsuranceClaimStatus;
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
                    InsuranceClaimStatusManagement.tblInsuranceClaimStatus_Delete(Convert.ToInt32(e.CommandArgument));
                    BindInsuranceClaimStatus();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Insurance Claim Status Deleted Successfully";
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
                var lstEntity = InsuranceClaimStatusManagement.tblInsuranceClaimStatus_SelectForUpdate(txtInsuranceClaimStatus.Text.Trim(), chkActive.Checked);
                if (lstEntity.InsuranceClaimStatus != null)
                {
                    if (txtInsuranceClaimStatus.Text.Trim() == lstEntity.InsuranceClaimStatus && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Insurance Claim Status Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    InsuranceClaimStatusEntity ObjEntity = new InsuranceClaimStatusEntity();
                    ObjEntity.InsuranceClaimStatusID = Convert.ToInt32(hdnInsuranceClaimStatusID.Value);
                    ObjEntity.InsuranceClaimStatus = txtInsuranceClaimStatus.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    InsuranceClaimStatusManagement.tblInsuranceClaimStatus_Update(ObjEntity);
                    BindInsuranceClaimStatus();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Insurance Claim Status Updated Successfully";
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
            txtInsuranceClaimStatus.Text = string.Empty;
            chkActive.Checked = true;
            hdnInsuranceClaimStatusID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindInsuranceClaimStatus();

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
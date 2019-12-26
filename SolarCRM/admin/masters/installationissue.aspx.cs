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
    public partial class installationissue : System.Web.UI.Page
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
                BindInstallationIssue();
            }
        }

        private void BindInstallationIssue()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<InstallationIssueEntity> lstEntity = new List<InstallationIssueEntity>();
                lstEntity = InstallationIssueManagement.tblInstallationIssue_Select(objCommon, out Count);
                rptInstallationIssue.DataSource = lstEntity;
                rptInstallationIssue.DataBind();
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
                InstallationIssueEntity objEntity = new InstallationIssueEntity();

                int Exist = InstallationIssueManagement.tblInstallationIssue_Exists(txtInstallationIssue.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.InstallationIssue = txtInstallationIssue.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    InstallationIssueManagement.tblInstallationIssue_Insert(objEntity);
                    BindInstallationIssue();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Project OnHold Status Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Project OnHold Status Already Exist.";
                    // txtInstallationIssue.Text = "";
                    // txtInstallationIssue.Focus();
                    //BindInstallationIssue();
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

        protected void rptInstallationIssue_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = InstallationIssueManagement.tblInstallationIssue_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnInstallationIssueID.Value = lstEntity.InstallationIssueID.ToString();
                    txtInstallationIssue.Text = lstEntity.InstallationIssue;
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
                    InstallationIssueManagement.tblInstallationIssue_Delete(Convert.ToInt32(e.CommandArgument));
                    BindInstallationIssue();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Project OnHold Status Deleted Successfully";
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
                var lstEntity = InstallationIssueManagement.tblInstallationIssue_SelectForUpdate(txtInstallationIssue.Text.Trim(), chkActive.Checked);
                if (lstEntity.InstallationIssue != null)
                {
                    if (txtInstallationIssue.Text.Trim() == lstEntity.InstallationIssue && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Project OnHold Status Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    InstallationIssueEntity ObjEntity = new InstallationIssueEntity();
                    ObjEntity.InstallationIssueID = Convert.ToInt32(hdnInstallationIssueID.Value);
                    ObjEntity.InstallationIssue = txtInstallationIssue.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    InstallationIssueManagement.tblInstallationIssue_Update(ObjEntity);
                    BindInstallationIssue();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Project OnHold Status Updated Successfully";
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
            txtInstallationIssue.Text = string.Empty;
            chkActive.Checked = true;
            hdnInstallationIssueID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }


        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindInstallationIssue();

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
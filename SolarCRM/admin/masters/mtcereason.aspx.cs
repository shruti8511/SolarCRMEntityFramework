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
    public partial class mtcereason : System.Web.UI.Page
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
                BindProjectMtceReason();
            }
        }

        private void BindProjectMtceReason()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<ProjectMtceReasonEntity> lstEntity = new List<ProjectMtceReasonEntity>();
                lstEntity = ProjectMtceReasonManagement.tblProjectMtceReason_Select(objCommon, out Count);
                rptProjectMtceReason.DataSource = lstEntity;
                rptProjectMtceReason.DataBind();
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
                ProjectMtceReasonEntity objEntity = new ProjectMtceReasonEntity();

                int Exist = ProjectMtceReasonManagement.tblProjectMtceReason_Exists(txtProjectMtceReason.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.ProjectMtceReason = txtProjectMtceReason.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    ProjectMtceReasonManagement.tblProjectMtceReason_Insert(objEntity);
                    BindProjectMtceReason();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Reason Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Reason Already Exist.";
                    // txtProjectMtceReason.Text = "";
                    // txtProjectMtceReason.Focus();
                    //BindProjectMtceReason();
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

        protected void rptProjectMtceReason_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = ProjectMtceReasonManagement.tblProjectMtceReason_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnProjectMtceReasonID.Value = lstEntity.ProjectMtceReasonID.ToString();
                    txtProjectMtceReason.Text = lstEntity.ProjectMtceReason;
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
                    ProjectMtceReasonManagement.tblProjectMtceReason_Delete(Convert.ToInt32(e.CommandArgument));
                    BindProjectMtceReason();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Reason Deleted Successfully";
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
                var lstEntity = ProjectMtceReasonManagement.tblProjectMtceReason_SelectForUpdate(txtProjectMtceReason.Text.Trim(), chkActive.Checked);
                if (lstEntity.ProjectMtceReason != null)
                {
                    if (txtProjectMtceReason.Text.Trim() == lstEntity.ProjectMtceReason && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Reason Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    ProjectMtceReasonEntity ObjEntity = new ProjectMtceReasonEntity();
                    ObjEntity.ProjectMtceReasonID = Convert.ToInt32(hdnProjectMtceReasonID.Value);
                    ObjEntity.ProjectMtceReason = txtProjectMtceReason.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    ProjectMtceReasonManagement.tblProjectMtceReason_Update(ObjEntity);
                    BindProjectMtceReason();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Reason Updated Successfully";
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
            txtProjectMtceReason.Text = string.Empty;
            chkActive.Checked = true;
            hdnProjectMtceReasonID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }


        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindProjectMtceReason();

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
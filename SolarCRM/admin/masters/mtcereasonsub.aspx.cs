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
    public partial class mtcereasonsub : System.Web.UI.Page
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
                BindProjectMtceReasonSub();
            }
        }

        private void BindProjectMtceReasonSub()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<ProjectMtceReasonSubEntity> lstEntity = new List<ProjectMtceReasonSubEntity>();
                lstEntity = ProjectMtceReasonSubManagement.tblProjectMtceReasonSub_Select(objCommon, out Count);
                rptProjectMtceReasonSub.DataSource = lstEntity;
                rptProjectMtceReasonSub.DataBind();
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
                ProjectMtceReasonSubEntity objEntity = new ProjectMtceReasonSubEntity();

                int Exist = ProjectMtceReasonSubManagement.tblProjectMtceReasonSub_Exists(txtProjectMtceReasonSub.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.ProjectMtceReasonSub = txtProjectMtceReasonSub.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    ProjectMtceReasonSubManagement.tblProjectMtceReasonSub_Insert(objEntity);
                    BindProjectMtceReasonSub();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Mtce Reason Sub Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Mtce Reason Sub Already Exist.";
                    // txtProjectMtceReasonSub.Text = "";
                    // txtProjectMtceReasonSub.Focus();
                    //BindProjectMtceReasonSub();
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

        protected void rptProjectMtceReasonSub_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = ProjectMtceReasonSubManagement.tblProjectMtceReasonSub_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnProjectMtceReasonSubID.Value = lstEntity.ProjectMtceReasonSubID.ToString();
                    txtProjectMtceReasonSub.Text = lstEntity.ProjectMtceReasonSub;
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
                    ProjectMtceReasonSubManagement.tblProjectMtceReasonSub_Delete(Convert.ToInt32(e.CommandArgument));
                    BindProjectMtceReasonSub();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Mtce Reason Sub Deleted Successfully";
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
                var lstEntity = ProjectMtceReasonSubManagement.tblProjectMtceReasonSub_SelectForUpdate(txtProjectMtceReasonSub.Text.Trim(), chkActive.Checked);
                if (lstEntity.ProjectMtceReasonSub != null)
                {
                    if (txtProjectMtceReasonSub.Text.Trim() == lstEntity.ProjectMtceReasonSub && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Mtce Reason Sub Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    ProjectMtceReasonSubEntity ObjEntity = new ProjectMtceReasonSubEntity();
                    ObjEntity.ProjectMtceReasonSubID = Convert.ToInt32(hdnProjectMtceReasonSubID.Value);
                    ObjEntity.ProjectMtceReasonSub = txtProjectMtceReasonSub.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    ProjectMtceReasonSubManagement.tblProjectMtceReasonSub_Update(ObjEntity);
                    BindProjectMtceReasonSub();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Mtce Reason Sub Updated Successfully";
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
            txtProjectMtceReasonSub.Text = string.Empty;
            chkActive.Checked = true;
            hdnProjectMtceReasonSubID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }


        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindProjectMtceReasonSub();

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
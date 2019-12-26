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
    public partial class projectcancel : System.Web.UI.Page
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
                BindProjectCancel();
            }
        }

        private void BindProjectCancel()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<ProjectCancelEntity> lstEntity = new List<ProjectCancelEntity>();
                lstEntity = ProjectCancelManagement.tblProjectCancel_Select(objCommon, out Count);
                rptProjectCancel.DataSource = lstEntity;
                rptProjectCancel.DataBind();
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
                ProjectCancelEntity objEntity = new ProjectCancelEntity();

                int Exist = ProjectCancelManagement.tblProjectCancel_Exists(txtProjectCancel.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.ProjectCancel = txtProjectCancel.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    ProjectCancelManagement.tblProjectCancel_Insert(objEntity);
                    BindProjectCancel();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Project Cancel Type Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Project Cancel Type Already Exist.";
                    // txtProjectCancel.Text = "";
                    // txtProjectCancel.Focus();
                    //BindProjectCancel();
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

        protected void rptProjectCancel_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = ProjectCancelManagement.tblProjectCancel_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnProjectCancelID.Value = lstEntity.ProjectCancelID.ToString();
                    txtProjectCancel.Text = lstEntity.ProjectCancel;
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
                    ProjectCancelManagement.tblProjectCancel_Delete(Convert.ToInt32(e.CommandArgument));
                    BindProjectCancel();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Project Cancel Type Deleted Successfully";
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
                var lstEntity = ProjectCancelManagement.tblProjectCancel_SelectForUpdate(txtProjectCancel.Text.Trim(), chkActive.Checked);
                if (lstEntity.ProjectCancel != null)
                {
                    if (txtProjectCancel.Text.Trim() == lstEntity.ProjectCancel && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Project Cancel Type Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    ProjectCancelEntity ObjEntity = new ProjectCancelEntity();
                    ObjEntity.ProjectCancelID = Convert.ToInt32(hdnProjectCancelID.Value);
                    ObjEntity.ProjectCancel = txtProjectCancel.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    ProjectCancelManagement.tblProjectCancel_Update(ObjEntity);
                    BindProjectCancel();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Project Cancel Type Updated Successfully";
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
            txtProjectCancel.Text = string.Empty;
            chkActive.Checked = true;
            hdnProjectCancelID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }


        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindProjectCancel();

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
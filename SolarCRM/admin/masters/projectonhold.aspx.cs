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
    public partial class projectonhold : System.Web.UI.Page
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
                BindProjectOnHold();
            }
        }


        private void BindProjectOnHold()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<ProjectOnHoldEntity> lstEntity = new List<ProjectOnHoldEntity>();
                lstEntity = ProjectOnHoldManagement.tblProjectOnHold_Select(objCommon, out Count);
                rptProjectOnHold.DataSource = lstEntity;
                rptProjectOnHold.DataBind();
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
                ProjectOnHoldEntity objEntity = new ProjectOnHoldEntity();

                int Exist = ProjectOnHoldManagement.tblProjectOnHold_Exists(txtProjectOnHold.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.ProjectOnHold = txtProjectOnHold.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    ProjectOnHoldManagement.tblProjectOnHold_Insert(objEntity);
                    BindProjectOnHold();

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
                    // txtProjectOnHold.Text = "";
                    // txtProjectOnHold.Focus();
                    //BindProjectOnHold();
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

        protected void rptProjectOnHold_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = ProjectOnHoldManagement.tblProjectOnHold_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnProjectOnHoldID.Value = lstEntity.ProjectOnHoldID.ToString();
                    txtProjectOnHold.Text = lstEntity.ProjectOnHold;
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
                    ProjectOnHoldManagement.tblProjectOnHold_Delete(Convert.ToInt32(e.CommandArgument));
                    BindProjectOnHold();
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
                var lstEntity = ProjectOnHoldManagement.tblProjectOnHold_SelectForUpdate(txtProjectOnHold.Text.Trim(), chkActive.Checked);
                if (lstEntity.ProjectOnHold != null)
                {
                    if (txtProjectOnHold.Text.Trim() == lstEntity.ProjectOnHold && chkActive.Checked == lstEntity.Active)
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
                    ProjectOnHoldEntity ObjEntity = new ProjectOnHoldEntity();
                    ObjEntity.ProjectOnHoldID = Convert.ToInt32(hdnProjectOnHoldID.Value);
                    ObjEntity.ProjectOnHold = txtProjectOnHold.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    ProjectOnHoldManagement.tblProjectOnHold_Update(ObjEntity);
                    BindProjectOnHold();
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
            txtProjectOnHold.Text = string.Empty;
            chkActive.Checked = true;
            hdnProjectOnHoldID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }


        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindProjectOnHold();

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
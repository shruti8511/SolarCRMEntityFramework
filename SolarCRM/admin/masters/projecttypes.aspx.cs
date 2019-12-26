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
    public partial class projecttypes : System.Web.UI.Page
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
                BindProjectType();
            }
           
        }

        private void BindProjectType()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<ProjectTypeEntity> lstEntity = new List<ProjectTypeEntity>();
                lstEntity = ProjectTypeManagement.tblProjectType_Select(objCommon, out Count);
                rptProjectType.DataSource = lstEntity;
                rptProjectType.DataBind();
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
                ProjectTypeEntity objEntity = new ProjectTypeEntity();

                int Exist = ProjectTypeManagement.tblProjectType_Exists(txtProjectType.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.ProjectType = txtProjectType.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    ProjectTypeManagement.tblProjectType_Insert(objEntity);
                    BindProjectType();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Project Type Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Project Type Already Exist.";
                    // txtProjectType.Text = "";
                    // txtProjectType.Focus();
                    //BindProjectType();
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

        protected void rptProjectType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = ProjectTypeManagement.tblProjectType_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnProjectTypeID.Value = lstEntity.ProjectTypeID.ToString();
                    txtProjectType.Text = lstEntity.ProjectType;
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
                    ProjectTypeManagement.tblProjectType_Delete(Convert.ToInt32(e.CommandArgument));
                    BindProjectType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Project Type Deleted Successfully";
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
                var lstEntity = ProjectTypeManagement.tblProjectType_SelectForUpdate(txtProjectType.Text.Trim(), chkActive.Checked);
                if (lstEntity.ProjectType != null)
                {
                    if (txtProjectType.Text.Trim() == lstEntity.ProjectType && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Project Type Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    ProjectTypeEntity ObjEntity = new ProjectTypeEntity();
                    ObjEntity.ProjectTypeID = Convert.ToInt32(hdnProjectTypeID.Value);
                    ObjEntity.ProjectType = txtProjectType.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    ProjectTypeManagement.tblProjectType_Update(ObjEntity);
                    BindProjectType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Project Type Updated Successfully";
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
            txtProjectType.Text = string.Empty;
            chkActive.Checked = true;
            hdnProjectTypeID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }


        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindProjectType();

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
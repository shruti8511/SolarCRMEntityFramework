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
    public partial class leadgen : System.Web.UI.Page
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
               // ProjectManagerDropDownList();
                BindLeadGen();
            }
        }

        public void ProjectManagerDropDownList()
        {
            //List<LeadGenEntity> lstEntity = new List<LeadGenEntity>();
            //lstEntity = LeadGenManagement.tblCompanySource_SelectForDropdown();
            //ddlProjectManager.DataSource = lstEntity;
            //ddlProjectManager.DataTextField = "CompanySource";
            //ddlProjectManager.DataValueField = "CompanySourceID";
            //ddlProjectManager.DataBind();
            //ddlProjectManager.Items.Insert(0, new ListItem("Select", "0"));

        }



        private void BindLeadGen()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<LeadGenEntity> lstEntity = new List<LeadGenEntity>();
                lstEntity = LeadGenManagement.tblLeadGen_Select(objCommon, out Count);
                rptLeadGen.DataSource = lstEntity;
                rptLeadGen.DataBind();
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
                LeadGenEntity objEntity = new LeadGenEntity();

              //  int Exist = LeadGenManagement.tblLeadGen_Exists(txtLeadGen.Text.Trim());
               // if (Exist == 0)
                {

                    objEntity.ProjectMgrID = Convert.ToInt32(ddlProjectManager.SelectedValue);
                    objEntity.FName = txtFName.Text.Trim();
                    objEntity.LName = txtLName.Text.Trim();
                    objEntity.Name = txtName.Text.Trim();
                    objEntity.ContactNum = txtContactNum.Text.Trim();                    
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    LeadGenManagement.tblLeadGen_Insert(objEntity);
                    BindLeadGen();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Lead Gen Added Successfully";

                    Reset();
                }

                //else
                //{
                //    divAlert.Visible = true;
                //    divSuccess.Visible = false;
                //    lblErrorMsg.Text = "Company Source Sub Already Exist.";
                    
                //}

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

        protected void rptLeadGen_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    var lstEntity = LeadGenManagement.tblLeadGen_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnLeadGenID.Value = lstEntity.LeadGenID.ToString();
                    ddlProjectManager.SelectedValue = lstEntity.ProjectMgrID.ToString();
                    txtFName.Text = lstEntity.FName;
                    txtLName.Text = lstEntity.LName;
                    txtName.Text = lstEntity.Name;
                    txtContactNum.Text = lstEntity.ContactNum;
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
                    LeadGenManagement.tblLeadGen_Delete(Convert.ToInt32(e.CommandArgument));
                    BindLeadGen();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Lead Gen Deleted Successfully";
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
              //  var lstEntity = LeadGenManagement.tblLeadGen_SelectForUpdate(txtLeadGen.Text.Trim(), chkActive.Checked);
                //if (lstEntity.LeadGen != null)
                //{
                //    if (txtLeadGen.Text.Trim() == lstEntity.LeadGen && chkActive.Checked == lstEntity.Active)
                //    {
                //        divSuccess.Visible = false;
                //        divAlert.Visible = true;
                //        lblErrorMsg.Text = "Company Source Sub Already Exist.";
                //        Reset();
                //        // txtWatchDialColor.Focus();
                //    }
                //}
               // else
                {
                    LeadGenEntity ObjEntity = new LeadGenEntity();
                    ObjEntity.LeadGenID = Convert.ToInt32(hdnLeadGenID.Value);
                    ObjEntity.ProjectMgrID = Convert.ToInt32(ddlProjectManager.SelectedValue);
                    ObjEntity.FName = txtFName.Text.Trim();
                    ObjEntity.LName = txtLName.Text.Trim();
                    ObjEntity.Name = txtName.Text.Trim();
                    ObjEntity.ContactNum = txtContactNum.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    LeadGenManagement.tblLeadGen_Update(ObjEntity);
                    BindLeadGen();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Lead Gen Updated Successfully";
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
            txtFName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtName.Text = string.Empty;
            txtContactNum.Text = string.Empty;
            ddlProjectManager.SelectedIndex = 0;
            chkActive.Checked = true;
            hdnLeadGenID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindLeadGen();

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
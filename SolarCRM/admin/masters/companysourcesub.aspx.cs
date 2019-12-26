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
    public partial class leadsourcesub : System.Web.UI.Page
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
                CompanySourceDropDownList();
                BindCompanySourceSub();
            }
        }

        public void CompanySourceDropDownList()
        {
             List<CompanySourceSubEntity> lstEntity = new List<CompanySourceSubEntity>();
             lstEntity = CompanySourceSubManagement.tblCompanySource_SelectForDropdown();
             ddlCompanySource.DataSource = lstEntity;
             ddlCompanySource.DataTextField = "CompanySource";
             ddlCompanySource.DataValueField = "CompanySourceID";
             ddlCompanySource.DataBind();
             ddlCompanySource.Items.Insert(0, new ListItem("Select", "0"));

        }


        private void BindCompanySourceSub()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<CompanySourceSubEntity> lstEntity = new List<CompanySourceSubEntity>();
                lstEntity = CompanySourceSubManagement.tblCompanySourceSub_Select(objCommon, out Count);
                rptCompanySourceSub.DataSource = lstEntity;
                rptCompanySourceSub.DataBind();
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
                CompanySourceSubEntity objEntity = new CompanySourceSubEntity();

                int Exist = CompanySourceSubManagement.tblCompanySourceSub_Exists(txtCompanySourceSub.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.CompanySourceID = Convert.ToInt32(ddlCompanySource.SelectedValue);
                    objEntity.CompanySourceSub = txtCompanySourceSub.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    CompanySourceSubManagement.tblCompanySourceSub_Insert(objEntity);
                    BindCompanySourceSub();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Company Source Sub Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Company Source Sub Already Exist.";
                    // txtCompanySourceSub.Text = "";
                    // txtCompanySourceSub.Focus();
                    //BindCompanySourceSub();
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

        protected void rptCompanySourceSub_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    var lstEntity = CompanySourceSubManagement.tblCompanySourceSub_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnCustSourceSubID.Value = lstEntity.CompanySourceSubID.ToString();
                    ddlCompanySource.SelectedValue = lstEntity.CompanySourceID.ToString();
                    txtCompanySourceSub.Text = lstEntity.CompanySourceSub;
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
                    CompanySourceSubManagement.tblCompanySourceSub_Delete(Convert.ToInt32(e.CommandArgument));
                    BindCompanySourceSub();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Company Source Sub Deleted Successfully";
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
                var lstEntity = CompanySourceSubManagement.tblCompanySourceSub_SelectForUpdate(txtCompanySourceSub.Text.Trim(), chkActive.Checked);
                if (lstEntity.CompanySourceSub != null)
                {
                    if (txtCompanySourceSub.Text.Trim() == lstEntity.CompanySourceSub && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Company Source Sub Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    CompanySourceSubEntity ObjEntity = new CompanySourceSubEntity();
                    ObjEntity.CompanySourceSubID = Convert.ToInt32(hdnCustSourceSubID.Value);
                    ObjEntity.CompanySourceID = Convert.ToInt32(ddlCompanySource.SelectedValue);
                    ObjEntity.CompanySourceSub = txtCompanySourceSub.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    CompanySourceSubManagement.tblCompanySourceSub_Update(ObjEntity);
                    BindCompanySourceSub();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Company Source Sub Updated Successfully";
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
            txtCompanySourceSub.Text = string.Empty;
            ddlCompanySource.SelectedIndex = 0;
            chkActive.Checked = true;
            hdnCustSourceSubID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindCompanySourceSub();

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
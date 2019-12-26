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
    public partial class postcodes : System.Web.UI.Page
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
                BindPostCode();
                BindDropdown();
            }
        }

        public void BindPostCode()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<PostCodeEntity> lstEntity = new List<PostCodeEntity>();
                lstEntity = PostCodeManagement.tblPostCode_Select(objCommon, out Count);
                rptPostCode.DataSource = lstEntity;
                rptPostCode.DataBind();
                pageGrid.BindPageing(Count);

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        public void BindDropdown()
        {
            List<StateEntity> lstState = new List<StateEntity>();
            lstState = CompanyLocationsManagement.tblState_SelectActive();
            ddlState.DataSource = lstState;
            ddlState.DataMember = "StateName";
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateName";
            ddlState.DataBind();

            List<CompanyLocationsEntity> lstCompanyLocation = new List<CompanyLocationsEntity>();
            lstCompanyLocation = CompanyLocationsManagement.tblCompanyLocations_SelectActive();
            ddlCompanyLocation.DataSource = lstCompanyLocation;
            ddlCompanyLocation.DataMember = "CompanyLocation";
            ddlCompanyLocation.DataTextField = "CompanyLocation";
            ddlCompanyLocation.DataValueField = "CompanyLocationID";
            ddlCompanyLocation.DataBind();
        }

        protected void rptPostCode_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    var lstEntity = PostCodeManagement.tblPostCode_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnPostCodeID.Value = lstEntity.PostCodeID.ToString();
                    txtPostCode.Text = lstEntity.PostCode.ToString();
                    ddlState.SelectedValue = lstEntity.State;
                    txtSuburb.Text = lstEntity.Suburb.ToString();
                    txtArea.Text = lstEntity.Area.ToString();
                    rblArea.SelectedValue = lstEntity.AreaType.ToString();
                    txtPOBoxes.Text = lstEntity.POBoxes.ToString();
                    ddlCompanyLocation.SelectedValue = lstEntity.CompanyLocationID.ToString();

                    chkActive.Checked = lstEntity.Active;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                }
                catch (Exception ex)
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Error : " + ex.Message;
                }


            }
            else if (e.CommandName.ToString() == "Delete")
            {
                try
                {
                    PostCodeManagement.tblPostCode_Delete(Convert.ToInt32(e.CommandArgument));
                    BindPostCode();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "PostCode Deleted Successfully";
                }
                catch (Exception ex)
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Error : " + ex.Message;

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PostCodeEntity objEntity = new PostCodeEntity();

                int Exist = PostCodeManagement.tblPostCode_Exists(Convert.ToInt32(txtPostCode.Text.Trim()));
                if (Exist == 0)
                {

                    objEntity.PostCode = Convert.ToInt32(txtPostCode.Text.Trim());
                    objEntity.Suburb = txtSuburb.Text.Trim();
                    objEntity.State = ddlState.SelectedItem.Text;
                    objEntity.POBoxes = txtPOBoxes.Text.Trim();
                    objEntity.Area = txtPOBoxes.Text.Trim();
                    objEntity.AreaType = Convert.ToInt32(rblArea.SelectedValue);
                    objEntity.CompanyLocationID = Convert.ToInt32(ddlCompanyLocation.SelectedValue);
                    objEntity.Active = chkActive.Checked;

                    int i = PostCodeManagement.tblPostCode_Insert(objEntity);
                    BindPostCode();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "PostCode Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "PostCode Already Exist.";
                   
                }

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var lstEntity = PostCodeManagement.tblPostCode_SelectForUpdate(Convert.ToInt32(txtPostCode.Text.Trim()), chkActive.Checked);
                if (lstEntity.PostCode != 0)
                {
                    if (txtPostCode.Text.Trim() == lstEntity.PostCode.ToString() && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "PostCode Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    PostCodeEntity ObjEntity = new PostCodeEntity();
                    ObjEntity.PostCodeID = Convert.ToInt32(hdnPostCodeID.Value);
                    ObjEntity.PostCode = Convert.ToInt32(txtPostCode.Text.Trim());
                    ObjEntity.Suburb = txtSuburb.Text.Trim();
                    ObjEntity.State = ddlState.SelectedItem.Text;
                    ObjEntity.POBoxes = txtPOBoxes.Text.Trim();
                    ObjEntity.Area = txtArea.Text.Trim();
                    ObjEntity.AreaType = Convert.ToInt32(rblArea.SelectedValue);
                    ObjEntity.CompanyLocationID = Convert.ToInt32(ddlCompanyLocation.SelectedValue);
                    ObjEntity.Active = chkActive.Checked;
                    PostCodeManagement.tblPostCode_Update(ObjEntity);
                    BindPostCode();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "PostCode Updated Successfully";
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
            ddlCompanyLocation.Text = string.Empty;
            ddlState.SelectedIndex = 0;
            chkActive.Checked = true;
            hdnPostCodeID.Value = string.Empty;
            txtPostCode.Text = string.Empty;
            txtSuburb.Text = string.Empty;
            txtPOBoxes.Text = string.Empty;
            txtArea.Text = string.Empty;
            rblArea.SelectedIndex = -1;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindPostCode();

            //if (Convert.ToInt32(Session["pager"]) == 1)
            //{
            //    bindsearch();
            //}
            //else
            //{
            //    BindAmount();
            //}
        }

        protected void btnalert_Click(object sender, EventArgs e)
        {
            divAlert.Visible = false;
        }

        protected void btnSuccess_Click(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
        }

      
    }
}
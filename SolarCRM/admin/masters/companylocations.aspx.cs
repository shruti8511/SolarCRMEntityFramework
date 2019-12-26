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
    public partial class companylocations : System.Web.UI.Page
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
                BindCompanyLocation();
                BindState();
            }
        }

        public void BindState()
        {
            List<StateEntity> lstState = new List<StateEntity>();
            lstState = CompanyLocationsManagement.tblState_SelectActive();
            ddlState.DataSource = lstState;
            ddlState.DataMember = "StateName";
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateName";
            ddlState.DataBind();
        }

        public void BindCompanyLocation()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<CompanyLocationsEntity> lstEntity = new List<CompanyLocationsEntity>();
                lstEntity = CompanyLocationsManagement.tblCompanyLocations_Select(objCommon, out Count);
                rptCompanyLocation.DataSource = lstEntity;
                rptCompanyLocation.DataBind();
                pageGrid.BindPageing(Count);

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void rptCompanyLocation_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    var lstEntity = CompanyLocationsManagement.tblCompanyLocations_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnCompanyLocationID.Value = lstEntity.CompanyLocationID.ToString();
                    txtCompanyLocation.Text = lstEntity.CompanyLocation;
                    ddlState.SelectedItem.Text = lstEntity.State;
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
                    CompanyLocationsManagement.tblCompanyLocations_Delete(Convert.ToInt32(e.CommandArgument));
                    BindCompanyLocation();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Company Location Deleted Successfully";
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
                CompanyLocationsEntity objEntity = new CompanyLocationsEntity();

                int Exist = CompanyLocationsManagement.tblCompanyLocations_Exists(txtCompanyLocation.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.CompanyLocation = txtCompanyLocation.Text.Trim();
                    objEntity.State = ddlState.SelectedItem.Text;
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    int i = CompanyLocationsManagement.tblCompanyLocations_Insert(objEntity);
                    BindCompanyLocation();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Company Location Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Company Location Already Exist.";
               
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
                var lstEntity = CompanyLocationsManagement.tblCompanyLocations_SelectForUpdate(txtCompanyLocation.Text.Trim(), chkActive.Checked);
                if (lstEntity.CompanyLocation != null)
                {
                    if (txtCompanyLocation.Text.Trim() == lstEntity.CompanyLocation && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Company Location Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    CompanyLocationsEntity ObjEntity = new CompanyLocationsEntity();
                    ObjEntity.CompanyLocationID = Convert.ToInt32(hdnCompanyLocationID.Value);
                    ObjEntity.CompanyLocation = txtCompanyLocation.Text.Trim();
                    ObjEntity.State = ddlState.SelectedItem.Text;
                    ObjEntity.Active = chkActive.Checked;
                    CompanyLocationsManagement.tblCompanyLocations_Update(ObjEntity);
                    BindCompanyLocation();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Company Location Updated Successfully";
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
            txtCompanyLocation.Text = string.Empty;
            ddlState.SelectedIndex = 0;
            chkActive.Checked = true;
            hdnCompanyLocationID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindCompanyLocation();

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
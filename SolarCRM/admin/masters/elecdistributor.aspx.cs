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
    public partial class elecdistributor : System.Web.UI.Page
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
                BindElecDistributor();
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

        private void BindElecDistributor()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<ElecDistributorEntity> lstEntity = new List<ElecDistributorEntity>();
                lstEntity = ElecDistributorManagement.tblElecDistributor_Select(objCommon, out Count);
                rptElecDistributor.DataSource = lstEntity;
                rptElecDistributor.DataBind();
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
                ElecDistributorEntity objEntity = new ElecDistributorEntity();

                int Exist = ElecDistributorManagement.tblElecDistributor_Exists(txtElecDistributor.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.ElecDistributor = txtElecDistributor.Text.Trim();
                    objEntity.ElecDistABB = txtElecDistABB.Text.Trim();
                    objEntity.Address = txtAddress.Text.Trim();
                    objEntity.Mobile = txtMobileNo.Text.Trim();
                    objEntity.Email = txtEmail.Text.Trim();
                    objEntity.State = ddlState.SelectedItem.Text;
                    objEntity.ElecDistAppReq = chkElecDistAppReq.Checked;   
                    objEntity.Active = chkActive.Checked;                                                     
                    ElecDistributorManagement.tblElecDistributor_Insert(objEntity);
                    BindElecDistributor();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Elec Distributor Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Elec Distributor Already Exist.";
                    // txtElecDistributor.Text = "";
                    // txtElecDistributor.Focus();
                    //BindElecDistributor();
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

        protected void rptElecDistributor_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = ElecDistributorManagement.tblElecDistributor_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnElecDistributorID.Value = lstEntity.ElecDistributorID.ToString();
                    txtElecDistributor.Text = lstEntity.ElecDistributor;
                    txtElecDistABB.Text = lstEntity.ElecDistABB;
                    txtAddress.Text = lstEntity.Address;
                    ddlState.SelectedValue = lstEntity.State;
                    txtMobileNo.Text = lstEntity.Mobile;
                    txtEmail.Text = lstEntity.Email;
                    chkActive.Checked = lstEntity.Active;
                    chkElecDistAppReq.Checked = lstEntity.ElecDistAppReq;                    
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
                    ElecDistributorManagement.tblElecDistributor_Delete(Convert.ToInt32(e.CommandArgument));
                    BindElecDistributor();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Elec Distributor Deleted Successfully";
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
                var lstEntity = ElecDistributorManagement.tblElecDistributor_SelectForUpdate(txtElecDistributor.Text.Trim(), chkActive.Checked);
                if (lstEntity.ElecDistributor != null)
                {
                    if (txtElecDistributor.Text.Trim() == lstEntity.ElecDistributor && chkActive.Checked == lstEntity.Active && ddlState.SelectedValue == lstEntity.State)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Elec Distributor Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }

                    else
                    {
                        ElecDistributorEntity ObjEntity = new ElecDistributorEntity();
                        ObjEntity.ElecDistributorID = Convert.ToInt32(hdnElecDistributorID.Value);
                        ObjEntity.ElecDistributor = txtElecDistributor.Text.Trim();
                        ObjEntity.ElecDistABB = txtElecDistABB.Text.Trim();
                        ObjEntity.Address = txtAddress.Text.Trim();
                        ObjEntity.Mobile = txtMobileNo.Text.Trim();
                        ObjEntity.Email = txtEmail.Text.Trim();
                        ObjEntity.State = ddlState.SelectedItem.Text;
                        ObjEntity.ElecDistAppReq = chkElecDistAppReq.Checked;
                        ObjEntity.Active = chkActive.Checked;
                        ElecDistributorManagement.tblElecDistributor_Update(ObjEntity);
                        BindElecDistributor();
                        divSuccess.Visible = true;
                        divAlert.Visible = false;
                        lblSuccessMsg.Text = "Elec Distributor Updated Successfully";
                        Reset();
                        btnUpdate.Visible = false;
                        btnSave.Visible = true;
                    }
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
            txtElecDistributor.Text = string.Empty;
            txtElecDistABB.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ddlState.SelectedIndex = 0;
            chkActive.Checked = true;
            chkElecDistAppReq.Checked = true;
            hdnElecDistributorID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindElecDistributor();

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
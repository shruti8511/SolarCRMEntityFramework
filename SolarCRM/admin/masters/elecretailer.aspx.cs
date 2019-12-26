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
    public partial class elecretailer : System.Web.UI.Page
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
                BindElecRetailer();
            }
        }


        private void BindElecRetailer()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<ElecRetailerEntity> lstEntity = new List<ElecRetailerEntity>();
                lstEntity = ElecRetailerManagement.tblElecRetailer_Select(objCommon, out Count);
                rptElecRetailer.DataSource = lstEntity;
                rptElecRetailer.DataBind();
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
                ElecRetailerEntity objEntity = new ElecRetailerEntity();

                int Exist = ElecRetailerManagement.tblElecRetailer_Exists(txtElecRetailer.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.ElecRetailer = txtElecRetailer.Text.Trim();                    
                    objEntity.Address = txtAddress.Text.Trim();
                    objEntity.Mobile = txtMobileNo.Text.Trim();
                    objEntity.Email = txtEmail.Text.Trim();                   
                    objEntity.Active = chkActive.Checked;
                    ElecRetailerManagement.tblElecRetailer_Insert(objEntity);
                    BindElecRetailer();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Elec Retailer Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Elec Retailer Already Exist.";
                    // txtElecRetailer.Text = "";
                    // txtElecRetailer.Focus();
                    //BindElecRetailer();
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

        protected void rptElecRetailer_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = ElecRetailerManagement.tblElecRetailer_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnElecRetailerID.Value = lstEntity.ElecRetailerID.ToString();
                    txtElecRetailer.Text = lstEntity.ElecRetailer;                    
                    txtAddress.Text = lstEntity.Address;
                    txtMobileNo.Text = lstEntity.Mobile;
                    txtEmail.Text = lstEntity.Email;
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
                    ElecRetailerManagement.tblElecRetailer_Delete(Convert.ToInt32(e.CommandArgument));
                    BindElecRetailer();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Elec Retailer Deleted Successfully";
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
                var lstEntity = ElecRetailerManagement.tblElecRetailer_SelectForUpdate(txtElecRetailer.Text.Trim(), chkActive.Checked);
                if (lstEntity.ElecRetailer != null)
                {
                    if (txtElecRetailer.Text.Trim() == lstEntity.ElecRetailer && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Elec Retailer Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    ElecRetailerEntity ObjEntity = new ElecRetailerEntity();
                    ObjEntity.ElecRetailerID = Convert.ToInt32(hdnElecRetailerID.Value);
                    ObjEntity.ElecRetailer = txtElecRetailer.Text.Trim();                   
                    ObjEntity.Address = txtAddress.Text.Trim();
                    ObjEntity.Mobile = txtMobileNo.Text.Trim();
                    ObjEntity.Email = txtEmail.Text.Trim();                    
                    ObjEntity.Active = chkActive.Checked;
                    ElecRetailerManagement.tblElecRetailer_Update(ObjEntity);
                    BindElecRetailer();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Elec Retailer Updated Successfully";
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
            txtElecRetailer.Text = string.Empty;          
            txtAddress.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            chkActive.Checked = true;           
            hdnElecRetailerID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindElecRetailer();

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
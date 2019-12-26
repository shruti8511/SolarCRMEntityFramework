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
    public partial class rooftype : System.Web.UI.Page
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
                BindRoofType();
            }
        }

        private void BindRoofType()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<RoofTypeEntity> lstEntity = new List<RoofTypeEntity>();
                lstEntity = RoofTypeManagement.tblRoofType_Select(objCommon, out Count);
                rptRoofType.DataSource = lstEntity;
                rptRoofType.DataBind();
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
                RoofTypeEntity objEntity = new RoofTypeEntity();

                int Exist = RoofTypeManagement.tblRoofType_Exists(txtRoofType.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.RoofType = txtRoofType.Text.Trim();
                    objEntity.Variation = Convert.ToDecimal(txtVariations.Text.Trim());
                    objEntity.Seq = 0;
                    objEntity.Active = chkActive.Checked;
                    RoofTypeManagement.tblRoofType_Insert(objEntity);
                    BindRoofType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Roof Type Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Roof Type Already Exist.";
                    // txtRoofType.Text = "";
                    // txtRoofType.Focus();
                    //BindRoofType();
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

        protected void rptRoofType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = RoofTypeManagement.tblRoofType_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnRoofTypeID.Value = lstEntity.RoofTypeID.ToString();
                    txtRoofType.Text = lstEntity.RoofType;
                    txtVariations.Text = lstEntity.Variation.ToString();
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
                    RoofTypeManagement.tblRoofType_Delete(Convert.ToInt32(e.CommandArgument));
                    BindRoofType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Roof Type Deleted Successfully";
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
                var lstEntity = RoofTypeManagement.tblRoofType_SelectForUpdate(txtRoofType.Text.Trim(), chkActive.Checked);
                if (lstEntity.RoofType != null)
                {
                    if (txtRoofType.Text.Trim() == lstEntity.RoofType && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Roof Type Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    RoofTypeEntity ObjEntity = new RoofTypeEntity();
                    ObjEntity.RoofTypeID = Convert.ToInt32(hdnRoofTypeID.Value);
                    ObjEntity.RoofType = txtRoofType.Text.Trim();
                    ObjEntity.Variation = Convert.ToDecimal(txtVariations.Text.Trim());
                    ObjEntity.Active = chkActive.Checked;
                    RoofTypeManagement.tblRoofType_Update(ObjEntity);
                    BindRoofType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Roof Type Updated Successfully";
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
            txtRoofType.Text = string.Empty;
            txtVariations.Text = string.Empty;
            chkActive.Checked = true;
            hdnRoofTypeID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindRoofType();

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
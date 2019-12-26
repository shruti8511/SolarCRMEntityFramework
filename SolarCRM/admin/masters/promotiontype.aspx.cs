using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.PagingUserControl;

namespace SolarCRM.admin.masters
{
    public partial class promotiontype : System.Web.UI.Page
    {
        protected string SiteURL;

        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;
            if (!IsPostBack)
            {
                Session["PageNo"] = 1;
                Session["PageSize"] = 2;
                BindPromotionType();
            }
        }

        private void BindPromotionType()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<PromotionTypeEntity> lstEntity = new List<PromotionTypeEntity>();
                lstEntity = PromotionTypeManagement.tblPromotionType_Select(objCommon, out Count);
                rptPromotionType.DataSource = lstEntity;
                rptPromotionType.DataBind();
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
                PromotionTypeEntity objEntity = new PromotionTypeEntity();

                int Exist = PromotionTypeManagement.tblPromotionType_Exists(txtPromotionType.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.PromotionType = txtPromotionType.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    PromotionTypeManagement.tblPromotionType_Insert(objEntity);
                    BindPromotionType();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Promotion Type Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Promotion Type Already Exist.";
                    // txtPromotionType.Text = "";
                    // txtPromotionType.Focus();
                    //BindPromotionType();
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

        protected void rptPromotionType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = PromotionTypeManagement.tblPromotionType_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnPromotionTypeID.Value = lstEntity.PromotionTypeID.ToString();
                    txtPromotionType.Text = lstEntity.PromotionType;
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
                    PromotionTypeManagement.tblPromotionType_Delete(Convert.ToInt32(e.CommandArgument));
                    BindPromotionType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Promotion Type Deleted Successfully";
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
                var lstEntity = PromotionTypeManagement.tblPromotionType_SelectForUpdate(txtPromotionType.Text.Trim(), chkActive.Checked);
                if (lstEntity.PromotionType != null)
                {
                    if (txtPromotionType.Text.Trim() == lstEntity.PromotionType && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Promotion Type Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    PromotionTypeEntity ObjEntity = new PromotionTypeEntity();
                    ObjEntity.PromotionTypeID = Convert.ToInt32(hdnPromotionTypeID.Value);
                    ObjEntity.PromotionType = txtPromotionType.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    PromotionTypeManagement.tblPromotionType_Update(ObjEntity);
                    BindPromotionType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Promotion Type Updated Successfully";
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
            txtPromotionType.Text = string.Empty;
            chkActive.Checked = true;
            hdnPromotionTypeID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindPromotionType();

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
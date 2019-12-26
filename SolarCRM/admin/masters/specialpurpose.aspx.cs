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
    public partial class specialpurpose : System.Web.UI.Page
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
                BindSpecialPurpose();
            }
        }

        private void BindSpecialPurpose()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<SpecialPurposeEntity> lstEntity = new List<SpecialPurposeEntity>();
                lstEntity = SpecialPurposeManagement.tblSpecialPurpose_Select(objCommon, out Count);
                rptSpecialPurpose.DataSource = lstEntity;
                rptSpecialPurpose.DataBind();
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
                SpecialPurposeEntity objEntity = new SpecialPurposeEntity();

                int Exist = SpecialPurposeManagement.tblSpecialPurpose_Exists(txtSpecialPurpose.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.SpecialPurpose = txtSpecialPurpose.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    SpecialPurposeManagement.tblSpecialPurpose_Insert(objEntity);
                    BindSpecialPurpose();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Special Purpose Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Special Purpose Already Exist.";
                    // txtSpecialPurpose.Text = "";
                    // txtSpecialPurpose.Focus();
                    //BindSpecialPurpose();
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

        protected void rptSpecialPurpose_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = SpecialPurposeManagement.tblSpecialPurpose_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnSpecialPurposeID.Value = lstEntity.SpecialPurposeID.ToString();
                    txtSpecialPurpose.Text = lstEntity.SpecialPurpose;
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
                    SpecialPurposeManagement.tblSpecialPurpose_Delete(Convert.ToInt32(e.CommandArgument));
                    BindSpecialPurpose();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Special Purpose Deleted Successfully";
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
                var lstEntity = SpecialPurposeManagement.tblSpecialPurpose_SelectForUpdate(txtSpecialPurpose.Text.Trim(), chkActive.Checked);
                if (lstEntity.SpecialPurpose != null)
                {
                    if (txtSpecialPurpose.Text.Trim() == lstEntity.SpecialPurpose && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Special Purpose Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    SpecialPurposeEntity ObjEntity = new SpecialPurposeEntity();
                    ObjEntity.SpecialPurposeID = Convert.ToInt32(hdnSpecialPurposeID.Value);
                    ObjEntity.SpecialPurpose = txtSpecialPurpose.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    SpecialPurposeManagement.tblSpecialPurpose_Update(ObjEntity);
                    BindSpecialPurpose();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Special Purpose Updated Successfully";
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
            txtSpecialPurpose.Text = string.Empty;
            chkActive.Checked = true;
            hdnSpecialPurposeID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindSpecialPurpose();

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
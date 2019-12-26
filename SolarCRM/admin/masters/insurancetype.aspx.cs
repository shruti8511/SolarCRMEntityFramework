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
    public partial class insurancetype : System.Web.UI.Page
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
                BindInsuranceType();
            }
        }

        private void BindInsuranceType()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<InsuranceTypeEntity> lstEntity = new List<InsuranceTypeEntity>();
                lstEntity = InsuranceTypeManagement.tblInsuranceType_Select(objCommon, out Count);
                rptInsuranceType.DataSource = lstEntity;
                rptInsuranceType.DataBind();
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
                InsuranceTypeEntity objEntity = new InsuranceTypeEntity();

                int Exist = InsuranceTypeManagement.tblInsuranceType_Exists(txtInsuranceType.Text.Trim());
                if (Exist == 0)
                {
                    objEntity.InsuranceType = txtInsuranceType.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    InsuranceTypeManagement.tblInsuranceType_Insert(objEntity);
                    BindInsuranceType();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Insurance Type Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Insurance Type Already Exist.";
                    // txtInsuranceType.Text = "";
                    // txtInsuranceType.Focus();
                    //BindInsuranceType();
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

        protected void rptInsuranceType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = InsuranceTypeManagement.tblInsuranceType_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnInsuranceTypeID.Value = lstEntity.InsuranceTypeID.ToString();
                    txtInsuranceType.Text = lstEntity.InsuranceType;
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
                    InsuranceTypeManagement.tblInsuranceType_Delete(Convert.ToInt32(e.CommandArgument));
                    BindInsuranceType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Insurance Type Deleted Successfully";
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
                var lstEntity = InsuranceTypeManagement.tblInsuranceType_SelectForUpdate(txtInsuranceType.Text.Trim(), chkActive.Checked);
                if (lstEntity.InsuranceType != null)
                {
                    if (txtInsuranceType.Text.Trim() == lstEntity.InsuranceType && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Insurance Type Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    InsuranceTypeEntity ObjEntity = new InsuranceTypeEntity();
                    ObjEntity.InsuranceTypeID = Convert.ToInt32(hdnInsuranceTypeID.Value);
                    ObjEntity.InsuranceType = txtInsuranceType.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    InsuranceTypeManagement.tblInsuranceType_Update(ObjEntity);
                    BindInsuranceType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Insurance Type Updated Successfully";
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
            txtInsuranceType.Text = string.Empty;
            chkActive.Checked = true;
            hdnInsuranceTypeID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindInsuranceType();

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
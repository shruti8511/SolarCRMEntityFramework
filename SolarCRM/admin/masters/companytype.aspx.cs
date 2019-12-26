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
    public partial class companytype : System.Web.UI.Page
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
                BindCompanyType();
            }

        }

        private void BindCompanyType()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<CompanyTypeEntity> lstEntity = new List<CompanyTypeEntity>();
                lstEntity = CompanyTypeManagement.tblCompanyType_Select(objCommon, out Count);
                rptCompanyType.DataSource = lstEntity;
                rptCompanyType.DataBind();
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
                CompanyTypeEntity objEntity = new CompanyTypeEntity();

                int Exist = CompanyTypeManagement.tblCompanyType_Exists(txtCompanyType.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.CompanyType = txtCompanyType.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    CompanyTypeManagement.tblCompanyType_Insert(objEntity);
                    BindCompanyType();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Company Type Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Company Type Already Exist.";
                    // txtCompanyType.Text = "";
                    // txtCompanyType.Focus();
                    //BindCompanyType();
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

        protected void rptCompanyType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    var lstEntity = CompanyTypeManagement.tblCompanyType_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnCompanyTypeID.Value = lstEntity.CompanyTypeID.ToString();
                    txtCompanyType.Text = lstEntity.CompanyType;
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
                    CompanyTypeManagement.tblCompanyType_Delete(Convert.ToInt32(e.CommandArgument));
                    BindCompanyType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Company Type Deleted Successfully";
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
                var lstEntity = CompanyTypeManagement.tblCompanyType_SelectForUpdate(txtCompanyType.Text.Trim(), chkActive.Checked);
                if (lstEntity.CompanyType != null)
                {
                    if (txtCompanyType.Text.Trim() == lstEntity.CompanyType && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Company Type Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    CompanyTypeEntity ObjEntity = new CompanyTypeEntity();
                    ObjEntity.CompanyTypeID = Convert.ToInt32(hdnCompanyTypeID.Value);
                    ObjEntity.CompanyType = txtCompanyType.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    CompanyTypeManagement.tblCompanyType_Update(ObjEntity);
                    BindCompanyType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Company Type Updated Successfully";
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
            txtCompanyType.Text = string.Empty;
            chkActive.Checked = true;
            hdnCompanyTypeID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }


        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindCompanyType();

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
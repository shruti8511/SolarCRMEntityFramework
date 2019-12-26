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
    public partial class insurancecompany : System.Web.UI.Page
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
                BindInsuranceCompany();
            }
        }

        private void BindInsuranceCompany()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<InsuranceCompanyEntity> lstEntity = new List<InsuranceCompanyEntity>();
                lstEntity = InsuranceCompanyManagement.tblInsuranceCompany_Select(objCommon, out Count);
                rptInsuranceCompany.DataSource = lstEntity;
                rptInsuranceCompany.DataBind();
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
                InsuranceCompanyEntity objEntity = new InsuranceCompanyEntity();

                int Exist = InsuranceCompanyManagement.tblInsuranceCompany_Exists(txtInsuranceCompany.Text.Trim());
                if (Exist == 0)
                {
                    objEntity.InsuranceCompany = txtInsuranceCompany.Text.Trim();
                    objEntity.Active = chkActive.Checked;                    
                    InsuranceCompanyManagement.tblInsuranceCompany_Insert(objEntity);
                    BindInsuranceCompany();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Insurance Company Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Insurance Company Already Exist.";
                    // txtInsuranceCompany.Text = "";
                    // txtInsuranceCompany.Focus();
                    //BindInsuranceCompany();
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

        protected void rptInsuranceCompany_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = InsuranceCompanyManagement.tblInsuranceCompany_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnInsuranceCompanyID.Value = lstEntity.InsuranceCompanyID.ToString();
                    txtInsuranceCompany.Text = lstEntity.InsuranceCompany;
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
                    InsuranceCompanyManagement.tblInsuranceCompany_Delete(Convert.ToInt32(e.CommandArgument));
                    BindInsuranceCompany();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Insurance Company Deleted Successfully";
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
                var lstEntity = InsuranceCompanyManagement.tblInsuranceCompany_SelectForUpdate(txtInsuranceCompany.Text.Trim(), chkActive.Checked);
                if (lstEntity.InsuranceCompany != null)
                {
                    if (txtInsuranceCompany.Text.Trim() == lstEntity.InsuranceCompany && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Insurance Company Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    InsuranceCompanyEntity ObjEntity = new InsuranceCompanyEntity();
                    ObjEntity.InsuranceCompanyID = Convert.ToInt32(hdnInsuranceCompanyID.Value);
                    ObjEntity.InsuranceCompany = txtInsuranceCompany.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    InsuranceCompanyManagement.tblInsuranceCompany_Update(ObjEntity);
                    BindInsuranceCompany();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Insurance Company Updated Successfully";
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
            txtInsuranceCompany.Text = string.Empty;
            chkActive.Checked = true;
            hdnInsuranceCompanyID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }


        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindInsuranceCompany();

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
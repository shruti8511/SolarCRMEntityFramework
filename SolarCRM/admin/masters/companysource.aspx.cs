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
    public partial class leadsource : System.Web.UI.Page
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
                BindCompanySource();
            }

        }

        private void BindCompanySource()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<CompanySourceEntity> lstEntity = new List<CompanySourceEntity>();
                lstEntity = CompanySourceManagement.tblCompanySource_Select(objCommon, out Count);
                rptCompanySource.DataSource = lstEntity;
                rptCompanySource.DataBind();
                pageGrid.BindPageing(Count);

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }


            //List<CompanySourceEntity> lstEntity = new List<CompanySourceEntity>();
            //lstEntity = CompanySources.tblCompanySource_Select();
            //rptCompanySource.DataSource = lstEntity;
            //rptCompanySource.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CompanySourceEntity objEntity = new CompanySourceEntity();

                int Exist = CompanySourceManagement.tblCompanySource_Exists(txtCompanySource.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.CompanySource = txtCompanySource.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    objEntity.LeadSelect = false;
                    CompanySourceManagement.tblCompanySource_Insert(objEntity);
                    BindCompanySource();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Company Source Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Company Source Already Exist.";
                    // txtCompanySource.Text = "";
                    // txtCompanySource.Focus();
                    //BindCompanySource();
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

        protected void rptCompanySource_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = CompanySourceManagement.tblCompanySource_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnCompanySourceID.Value = lstEntity.CompanySourceID.ToString();
                    txtCompanySource.Text = lstEntity.CompanySource;
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
                    CompanySourceManagement.tblCompanySource_Delete(Convert.ToInt32(e.CommandArgument));
                    BindCompanySource();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Company Source Deleted Successfully";
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
                var lstEntity = CompanySourceManagement.tblCompanySource_SelectForUpdate(txtCompanySource.Text.Trim(), chkActive.Checked);
                if (lstEntity.CompanySource != null)
                {
                    if (txtCompanySource.Text.Trim() == lstEntity.CompanySource && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Company Source Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    CompanySourceEntity ObjEntity = new CompanySourceEntity();
                    ObjEntity.CompanySourceID = Convert.ToInt32(hdnCompanySourceID.Value);
                    ObjEntity.CompanySource = txtCompanySource.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    CompanySourceManagement.tblCompanySource_Update(ObjEntity);
                    BindCompanySource();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Company Source Updated Successfully";
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
            txtCompanySource.Text = string.Empty;
            chkActive.Checked = true;
            hdnCompanySourceID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }



        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindCompanySource();

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
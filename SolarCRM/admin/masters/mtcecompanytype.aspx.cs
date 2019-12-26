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
    public partial class mtcecompanytype : System.Web.UI.Page
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
                BindMtceCompanyType();
            }
        }

        private void BindMtceCompanyType()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<MtceCompanyTypeEntity> lstEntity = new List<MtceCompanyTypeEntity>();
                lstEntity = MtceCompanyTypeManagement.tblMtceCompanyType_Select(objCommon, out Count);
                rptMtceCompanyType.DataSource = lstEntity;
                rptMtceCompanyType.DataBind();
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
                MtceCompanyTypeEntity objEntity = new MtceCompanyTypeEntity();

                int Exist = MtceCompanyTypeManagement.tblMtceCompanyType_Exists(txtMtceCompanyType.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.MtceCompanyType = txtMtceCompanyType.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    MtceCompanyTypeManagement.tblMtceCompanyType_Insert(objEntity);
                    BindMtceCompanyType();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Mtce CompanyType Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Mtce CompanyType Already Exist.";
                    // txtMtceCompanyType.Text = "";
                    // txtMtceCompanyType.Focus();
                    //BindMtceCompanyType();
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

        protected void rptMtceCompanyType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = MtceCompanyTypeManagement.tblMtceCompanyType_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnMtceCompanyTypeID.Value = lstEntity.MtceCompanyTypeID.ToString();
                    txtMtceCompanyType.Text = lstEntity.MtceCompanyType;
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
                    MtceCompanyTypeManagement.tblMtceCompanyType_Delete(Convert.ToInt32(e.CommandArgument));
                    BindMtceCompanyType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Mtce CompanyType Deleted Successfully";
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
                var lstEntity = MtceCompanyTypeManagement.tblMtceCompanyType_SelectForUpdate(txtMtceCompanyType.Text.Trim(), chkActive.Checked);
                if (lstEntity.MtceCompanyType != null)
                {
                    if (txtMtceCompanyType.Text.Trim() == lstEntity.MtceCompanyType && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Mtce CompanyType Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    MtceCompanyTypeEntity ObjEntity = new MtceCompanyTypeEntity();
                    ObjEntity.MtceCompanyTypeID = Convert.ToInt32(hdnMtceCompanyTypeID.Value);
                    ObjEntity.MtceCompanyType = txtMtceCompanyType.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    MtceCompanyTypeManagement.tblMtceCompanyType_Update(ObjEntity);
                    BindMtceCompanyType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Mtce CompanyType Updated Successfully";
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
            txtMtceCompanyType.Text = string.Empty;
            chkActive.Checked = true;
            hdnMtceCompanyTypeID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }


        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindMtceCompanyType();

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
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
    public partial class prospectcategory : System.Web.UI.Page
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
                BindProspectCategory();
            }
        }

        private void BindProspectCategory()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<ProspectCategoryEntity> lstEntity = new List<ProspectCategoryEntity>();
                lstEntity = ProspectCategoryManagement.tblProspectCategory_Select(objCommon, out Count);
                rptProspectCategory.DataSource = lstEntity;
                rptProspectCategory.DataBind();
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
                ProspectCategoryEntity objEntity = new ProspectCategoryEntity();

                int Exist = ProspectCategoryManagement.tblProspectCats_Exists(txtCategories.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.ProspectCat = txtCategories.Text.Trim();
                    objEntity.ProspectCatABB = txtCategoriesABB.Text.Trim();
                    objEntity.Seq = 0;
                    objEntity.Active = chkActive.Checked;
                    ProspectCategoryManagement.tblProspectCats_Insert(objEntity);
                    BindProspectCategory();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Prospect Category Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Prospect Category Already Exist.";
                    // txtProspectCategory.Text = "";
                    // txtProspectCategory.Focus();
                    //BindProspectCategory();
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

        protected void rptProspectCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = ProspectCategoryManagement.tblProspectCats_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnProspectCatID.Value = lstEntity.ProspectCatID.ToString();
                    txtCategories.Text = lstEntity.ProspectCat;
                    txtCategoriesABB.Text = lstEntity.ProspectCatABB;
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
                    ProspectCategoryManagement.tblProspectCats_Delete(Convert.ToInt32(e.CommandArgument));
                    BindProspectCategory();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Prospect Category Deleted Successfully";
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
                var lstEntity = ProspectCategoryManagement.tblProspectCats_SelectForUpdate(txtCategories.Text.Trim(), chkActive.Checked);
                if (lstEntity.ProspectCat != null)
                {
                    if (txtCategories.Text.Trim() == lstEntity.ProspectCat && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Prospect Category Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    ProspectCategoryEntity ObjEntity = new ProspectCategoryEntity();
                    ObjEntity.ProspectCatID = Convert.ToInt32(hdnProspectCatID.Value);
                    ObjEntity.ProspectCat = txtCategories.Text.Trim();
                    ObjEntity.ProspectCatABB = txtCategoriesABB.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    ProspectCategoryManagement.tblProspectCats_Update(ObjEntity);
                    BindProspectCategory();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Prospect Category Updated Successfully";
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
            txtCategories.Text = string.Empty;
            txtCategoriesABB.Text = string.Empty;
            chkActive.Checked = true;
            hdnProspectCatID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindProspectCategory();

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
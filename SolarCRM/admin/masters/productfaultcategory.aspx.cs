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
    public partial class productfaultcategory : System.Web.UI.Page
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
                BindProductFaultCategory();
            }
        }

        private void BindProductFaultCategory()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<ProductFaultCategoryEntity> lstEntity = new List<ProductFaultCategoryEntity>();
                lstEntity = ProductFaultCategoryManagement.tblProductFaultCategory_Select(objCommon, out Count);
                rptProductFaultCategory.DataSource = lstEntity;
                rptProductFaultCategory.DataBind();
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
                ProductFaultCategoryEntity objEntity = new ProductFaultCategoryEntity();

                int Exist = ProductFaultCategoryManagement.tblProductFaultCategory_Exists(txtProductFaultCategory.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.ProductFaultCategory = txtProductFaultCategory.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    
                    ProductFaultCategoryManagement.tblProductFaultCategory_Insert(objEntity);
                    BindProductFaultCategory();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Category Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Category Already Exist.";
                    // txtProductFaultCategory.Text = "";
                    // txtProductFaultCategory.Focus();
                    //BindProductFaultCategory();
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

        protected void rptProductFaultCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = ProductFaultCategoryManagement.tblProductFaultCategory_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnProductFaultCategoryID.Value = lstEntity.ProductFaultCategoryID.ToString();
                    txtProductFaultCategory.Text = lstEntity.ProductFaultCategory;
                    chkActive.Checked = lstEntity.Active;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                }
                catch (Exception ex)
                {
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "Error : " + ex.Message;
                }


            }
            else if (e.CommandName.ToString() == "Delete")
            {
                try
                {
                    ProductFaultCategoryManagement.tblProductFaultCategory_Delete(Convert.ToInt32(e.CommandArgument));
                    BindProductFaultCategory();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Category Deleted Successfully";
                }
                catch (Exception ex)
                {
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "Error : " + ex.Message;

                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var lstEntity = ProductFaultCategoryManagement.tblProductFaultCategory_SelectForUpdate(txtProductFaultCategory.Text.Trim(), chkActive.Checked);
                if (lstEntity.ProductFaultCategory != null)
                {
                    if (txtProductFaultCategory.Text.Trim() == lstEntity.ProductFaultCategory && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Category Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    ProductFaultCategoryEntity ObjEntity = new ProductFaultCategoryEntity();
                    ObjEntity.ProductFaultCategoryID = Convert.ToInt32(hdnProductFaultCategoryID.Value);
                    ObjEntity.ProductFaultCategory = txtProductFaultCategory.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    ProductFaultCategoryManagement.tblProductFaultCategory_Update(ObjEntity);
                    BindProductFaultCategory();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Category Updated Successfully";
                    Reset();
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                }
            }
            catch (Exception ex)
            {
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
            txtProductFaultCategory.Text = string.Empty;
            chkActive.Checked = true;
            hdnProductFaultCategoryID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindProductFaultCategory();

            //if (Convert.ToInt32(Session["pager"]) == 1)
            //{
            //    bindsearch();
            //}
            //else
            //{
            //    BindAmount();
            //}
        }

        protected void btnalert_Click(object sender, EventArgs e)
        {
            divAlert.Visible = false;
        }

        protected void btnSuccess_Click(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
        }



    }
}
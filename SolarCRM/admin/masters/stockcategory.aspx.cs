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
    public partial class stockcategory : System.Web.UI.Page
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
                BindStockCategory();
            }
        }

        private void BindStockCategory()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<StockCategoryEntity> lstEntity = new List<StockCategoryEntity>();
                lstEntity = StockCategoryManagement.tblStockCategory_Select(objCommon, out Count);
                rptStockCategory.DataSource = lstEntity;
                rptStockCategory.DataBind();
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
                StockCategoryEntity objEntity = new StockCategoryEntity();

                int Exist = StockCategoryManagement.tblStockCategory_Exists(txtStockCategory.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.StockCategory = txtStockCategory.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    StockCategoryManagement.tblStockCategory_Insert(objEntity);
                    BindStockCategory();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Stock Category Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Stock Category Already Exist.";
                    // txtStockCategory.Text = "";
                    // txtStockCategory.Focus();
                    //BindStockCategory();
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

        protected void rptStockCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = StockCategoryManagement.tblStockCategory_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnStockCategoryID.Value = lstEntity.StockCategoryID.ToString();
                    txtStockCategory.Text = lstEntity.StockCategory;
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
                    StockCategoryManagement.tblStockCategory_Delete(Convert.ToInt32(e.CommandArgument));
                    BindStockCategory();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Stock Category Deleted Successfully";
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
                var lstEntity = StockCategoryManagement.tblStockCategory_SelectForUpdate(txtStockCategory.Text.Trim(), chkActive.Checked);
                if (lstEntity.StockCategory != null)
                {
                    if (txtStockCategory.Text.Trim() == lstEntity.StockCategory && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Stock Category Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    StockCategoryEntity ObjEntity = new StockCategoryEntity();
                    ObjEntity.StockCategoryID = Convert.ToInt32(hdnStockCategoryID.Value);
                    ObjEntity.StockCategory = txtStockCategory.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    StockCategoryManagement.tblStockCategory_Update(ObjEntity);
                    BindStockCategory();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Stock Category Updated Successfully";
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
            txtStockCategory.Text = string.Empty;
            chkActive.Checked = true;
            hdnStockCategoryID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindStockCategory();

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
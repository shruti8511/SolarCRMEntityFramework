using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.BAL.Implementations.StockModule;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.StockModule;
using SolarCRM.PagingUserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolarCRM.admin.stock
{
    public partial class stockitem : System.Web.UI.Page
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
                BindDropDown();
                BindStockItem();
            }
        }


        public void BindDropDown()
        {
            List<StockCategoryEntity> lstEntity = new List<StockCategoryEntity>();
            lstEntity = StockCategoryManagement.tblStockCategory_SelectForDropdown();
            ddlStockCategory.DataSource = lstEntity;
            ddlStockCategory.DataTextField = "StockCategory";
            ddlStockCategory.DataValueField = "StockCategoryID";
            ddlStockCategory.DataBind();
            ddlStockCategory.Items.Insert(0, new ListItem("Select", "0"));
        }

        protected void ddlStockCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int StockCategoryID =Convert.ToInt32(ddlStockCategory.SelectedValue);

            if ( StockCategoryID == 2)
            {
                pnlInverterPahase.Visible = true;
                pnlInverterMppt.Visible = true;
            }
            else
            {
                pnlInverterPahase.Visible = false;
                pnlInverterMppt.Visible = false;           
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                StockItemEntity objEntity = new StockItemEntity();

              //  int Exist = BillToManagement.tblBillTo_Exists(txtBillTo.Text.Trim());
              //  if (Exist == 0)
                {
                    objEntity.StockCategoryID =Convert.ToInt32(ddlStockCategory.SelectedValue);
                    objEntity.StockItem = txtStockItem.Text.Trim();
                    objEntity.StockModel = txtStockModel.Text.Trim();
                    objEntity.StockSize = txtStockSize.Text.Trim();
                    objEntity.InverterPhase = txtInverterPhase.Text.Trim();
                    objEntity.InverterCert = txtInverterCert.Text.Trim();
                    objEntity.StockManufacturer = txtStockManufacturer.Text.Trim();
                    objEntity.StockSeries = txtStockSeries.Text.Trim();
                    objEntity.CostPrice =Convert.ToDecimal( txtCostPrice.Text.Trim());
                    objEntity.MPPT = txtMPPT.Text.Trim();
                    objEntity.StockDescription = txtDescription.Text.Trim();
                    //objEntity.Active = chkActive.Checked;
                    StockItemManagement.tblStockItems_Insert(objEntity);
                    BindStockItem();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Stock Added Successfully";
                    Reset();
                }

                //else
                //{
                //    divAlert.Visible = true;
                //    divSuccess.Visible = false;
                //    lblErrorMsg.Text = "Bill To Status Already Exist.";
                //    // txtBillTo.Text = "";
                //    // txtBillTo.Focus();
                //    //BindBillTo();
                //    //Reset();
                //}

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }




        private void BindStockItem()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<StockItemEntity> lstEntity = new List<StockItemEntity>();
                lstEntity = StockItemManagement.tblStockItems_Select(objCommon, out Count);
                rptStockList.DataSource = lstEntity;
                rptStockList.DataBind();
                pageGrid.BindPageing(Count);

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindStockItem();         
        }

        protected void btnalert_Click(object sender, EventArgs e)
        {
            divAlert.Visible = false;
        }

        protected void btnSuccess_Click(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
        }



        private void Reset()
        {
            ddlStockCategory.SelectedIndex = 0;            
            txtStockItem.Text = string.Empty;
            txtStockModel.Text = string.Empty;
            txtStockSize.Text = string.Empty;
            txtInverterPhase.Text = string.Empty;
            txtInverterCert.Text = string.Empty;
            txtStockManufacturer.Text = string.Empty;
            txtStockSeries.Text = string.Empty;
            txtCostPrice.Text = string.Empty;
            txtMPPT.Text = string.Empty;
            txtDescription.Text = string.Empty;  
            btnUpdate.Visible = false;
            btnAdd.Visible = true;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        //protected void rptStockList_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    ModalPopupExtenderInvPay.Show();
        //}




    }
}
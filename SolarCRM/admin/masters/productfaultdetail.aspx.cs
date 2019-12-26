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
    public partial class productfaultdetail : System.Web.UI.Page
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
                ProductFaultCategoryDropDownList();
                BindProductFaultDetails();
            }
        }

        public void ProductFaultCategoryDropDownList()
        {
            List<ProductFaultDetailsEntity> lstEntity = new List<ProductFaultDetailsEntity>();
            lstEntity = ProductFaultDetailsManagement.tblProductFaultCategory_SelectForDropdown();
            ddlProductFaultCategory.DataSource = lstEntity;
            ddlProductFaultCategory.DataTextField = "ProductFaultCategory";
            ddlProductFaultCategory.DataValueField = "ProductFaultCategoryID";
            ddlProductFaultCategory.DataBind();
            ddlProductFaultCategory.Items.Insert(0, new ListItem("Select", "0"));

        }

        private void BindProductFaultDetails()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<ProductFaultDetailsEntity> lstEntity = new List<ProductFaultDetailsEntity>();
                lstEntity = ProductFaultDetailsManagement.tblProductFaultDetails_Select(objCommon, out Count);
                rptProductFaultDetails.DataSource = lstEntity;
                rptProductFaultDetails.DataBind();
                pageGrid.BindPageing(Count);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.InnerException + " or  Check your data.');", true);

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ProductFaultDetailsEntity objEntity = new ProductFaultDetailsEntity();

                int Exist = ProductFaultDetailsManagement.tblProductFaultDetails_Exists(txtProductFaultDetails.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.ProductFaultCategoryID = Convert.ToInt32(ddlProductFaultCategory.SelectedValue);
                    objEntity.ProductFaultDetails = txtProductFaultDetails.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                 
                    ProductFaultDetailsManagement.tblProductFaultDetails_Insert(objEntity);
                    BindProductFaultDetails();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Details Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Details Already Exist.";
                    // txtProductFaultDetails.Text = "";
                    // txtProductFaultDetails.Focus();
                    //BindProductFaultDetails();
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

        protected void rptProductFaultDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    var lstEntity = ProductFaultDetailsManagement.tblProductFaultDetails_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnProductFaultDetailsID.Value = lstEntity.ProductFaultDetailsID.ToString();
                    ddlProductFaultCategory.SelectedValue = lstEntity.ProductFaultCategoryID.ToString();
                    txtProductFaultDetails.Text = lstEntity.ProductFaultDetails;
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
                    ProductFaultDetailsManagement.tblProductFaultDetails_Delete(Convert.ToInt32(e.CommandArgument));
                    BindProductFaultDetails();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Details Deleted Successfully";
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
                var lstEntity = ProductFaultDetailsManagement.tblProductFaultDetails_SelectForUpdate(txtProductFaultDetails.Text.Trim(), chkActive.Checked);
                if (lstEntity.ProductFaultDetails != null)
                {
                    if (txtProductFaultDetails.Text.Trim() == lstEntity.ProductFaultDetails && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Details Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    ProductFaultDetailsEntity ObjEntity = new ProductFaultDetailsEntity();
                    ObjEntity.ProductFaultDetailsID = Convert.ToInt32(hdnProductFaultDetailsID.Value);
                    ObjEntity.ProductFaultCategoryID = Convert.ToInt32(ddlProductFaultCategory.SelectedValue);
                    ObjEntity.ProductFaultDetails = txtProductFaultDetails.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    ProductFaultDetailsManagement.tblProductFaultDetails_Update(ObjEntity);
                    BindProductFaultDetails();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Details Updated Successfully";
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
            txtProductFaultDetails.Text = string.Empty;
            ddlProductFaultCategory.SelectedIndex = 0;
            chkActive.Checked = true;
            hdnProductFaultDetailsID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindProductFaultDetails();

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
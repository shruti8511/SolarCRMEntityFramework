using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.PagingUserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolarCRM.admin.masters
{
    public partial class invoicetype : System.Web.UI.Page
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
                BindInvoiceType();
            }
        }

        private void BindInvoiceType()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<InvoiceTypeEntity> lstEntity = new List<InvoiceTypeEntity>();
                lstEntity = InvoiceTypeManagement.tblInvoiceType_Select(objCommon, out Count);
                rptInvoiceType.DataSource = lstEntity;
                rptInvoiceType.DataBind();
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
                InvoiceTypeEntity objEntity = new InvoiceTypeEntity();

                int Exist = InvoiceTypeManagement.tblInvoiceType_Exists(txtInvoiceType.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.InvoiceType = txtInvoiceType.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    InvoiceTypeManagement.tblInvoiceType_Insert(objEntity);
                    BindInvoiceType();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Invoice Type Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Invoice Type Already Exist.";
                    // txtInvoiceType.Text = "";
                    // txtInvoiceType.Focus();
                    //BindInvoiceType();
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

        protected void rptInvoiceType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = InvoiceTypeManagement.tblInvoiceType_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnInvoiceTypeID.Value = lstEntity.InvoiceTypeID.ToString();
                    txtInvoiceType.Text = lstEntity.InvoiceType;
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
                    InvoiceTypeManagement.tblInvoiceType_Delete(Convert.ToInt32(e.CommandArgument));
                    BindInvoiceType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Invoice Type Deleted Successfully";
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
                var lstEntity = InvoiceTypeManagement.tblInvoiceType_SelectForUpdate(txtInvoiceType.Text.Trim(), chkActive.Checked);
                if (lstEntity.InvoiceType != null)
                {
                    if (txtInvoiceType.Text.Trim() == lstEntity.InvoiceType && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Invoice Type Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    InvoiceTypeEntity ObjEntity = new InvoiceTypeEntity();
                    ObjEntity.InvoiceTypeID = Convert.ToInt32(hdnInvoiceTypeID.Value);
                    ObjEntity.InvoiceType = txtInvoiceType.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    InvoiceTypeManagement.tblInvoiceType_Update(ObjEntity);
                    BindInvoiceType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Invoice Type Updated Successfully";
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
            txtInvoiceType.Text = string.Empty;
            chkActive.Checked = true;
            hdnInvoiceTypeID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindInvoiceType();

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
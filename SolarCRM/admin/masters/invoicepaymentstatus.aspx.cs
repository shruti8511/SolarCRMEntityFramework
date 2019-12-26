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
    public partial class invoicepaymentstatus : System.Web.UI.Page
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
                BindInvoicePaymentStatus();
            }
        }

        private void BindInvoicePaymentStatus()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<InvoicePaymentStatusEntity> lstEntity = new List<InvoicePaymentStatusEntity>();
                lstEntity = InvoicePaymentStatusManagement.tblInvoicePaymentStatus_Select(objCommon, out Count);
                rptInvoicePaymentStatus.DataSource = lstEntity;
                rptInvoicePaymentStatus.DataBind();
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
                InvoicePaymentStatusEntity objEntity = new InvoicePaymentStatusEntity();

                int Exist = InvoicePaymentStatusManagement.tblInvoicePaymentStatus_Exists(txtInvoicePaymentStatus.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.InvoicePaymentStatus = txtInvoicePaymentStatus.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    InvoicePaymentStatusManagement.tblInvoicePaymentStatus_Insert(objEntity);
                    BindInvoicePaymentStatus();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Invoice Payment Status Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Invoice Payment Status Already Exist.";
                    // txtInvoicePaymentStatus.Text = "";
                    // txtInvoicePaymentStatus.Focus();
                    //BindInvoicePaymentStatus();
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

        protected void rptInvoicePaymentStatus_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = InvoicePaymentStatusManagement.tblInvoicePaymentStatus_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnInvoicePaymentStatusID.Value = lstEntity.InvoicePaymentStatusID.ToString();
                    txtInvoicePaymentStatus.Text = lstEntity.InvoicePaymentStatus;
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
                    InvoicePaymentStatusManagement.tblInvoicePaymentStatus_Delete(Convert.ToInt32(e.CommandArgument));
                    BindInvoicePaymentStatus();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Invoice Payment Status Deleted Successfully";
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
                var lstEntity = InvoicePaymentStatusManagement.tblInvoicePaymentStatus_SelectForUpdate(txtInvoicePaymentStatus.Text.Trim(), chkActive.Checked);
                if (lstEntity.InvoicePaymentStatus != null)
                {
                    if (txtInvoicePaymentStatus.Text.Trim() == lstEntity.InvoicePaymentStatus && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Invoice Payment Status Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    InvoicePaymentStatusEntity ObjEntity = new InvoicePaymentStatusEntity();
                    ObjEntity.InvoicePaymentStatusID = Convert.ToInt32(hdnInvoicePaymentStatusID.Value);
                    ObjEntity.InvoicePaymentStatus = txtInvoicePaymentStatus.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    InvoicePaymentStatusManagement.tblInvoicePaymentStatus_Update(ObjEntity);
                    BindInvoicePaymentStatus();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Invoice Payment Status Updated Successfully";
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
            txtInvoicePaymentStatus.Text = string.Empty;
            chkActive.Checked = true;
            hdnInvoicePaymentStatusID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindInvoicePaymentStatus();

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
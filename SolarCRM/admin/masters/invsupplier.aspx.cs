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
    public partial class invsupplier : System.Web.UI.Page
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
                BindInverterSupplier();
            }
        }

        private void BindInverterSupplier()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<InverterSupplierEntity> lstEntity = new List<InverterSupplierEntity>();
                lstEntity = InverterSupplierManagement.tblInverterSupplier_Select(objCommon, out Count);
                rptInverterSupplier.DataSource = lstEntity;
                rptInverterSupplier.DataBind();
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
                InverterSupplierEntity objEntity = new InverterSupplierEntity();

                int Exist = InverterSupplierManagement.tblInverterSupplier_Exists(txtInverterSupplier.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.InverterSupplier = txtInverterSupplier.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    InverterSupplierManagement.tblInverterSupplier_Insert(objEntity);
                    BindInverterSupplier();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Inverter Supplier Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Inverter Supplier Already Exist.";
                    // txtInverterSupplier.Text = "";
                    // txtInverterSupplier.Focus();
                    //BindInverterSupplier();
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

        protected void rptInverterSupplier_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = InverterSupplierManagement.tblInverterSupplier_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnInverterSupplierID.Value = lstEntity.InverterSupplierID.ToString();
                    txtInverterSupplier.Text = lstEntity.InverterSupplier;
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
                    InverterSupplierManagement.tblInverterSupplier_Delete(Convert.ToInt32(e.CommandArgument));
                    BindInverterSupplier();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Inverter Supplier Deleted Successfully";
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
                var lstEntity = InverterSupplierManagement.tblInverterSupplier_SelectForUpdate(txtInverterSupplier.Text.Trim(), chkActive.Checked);
                if (lstEntity.InverterSupplier != null)
                {
                    if (txtInverterSupplier.Text.Trim() == lstEntity.InverterSupplier && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Inverter Supplier Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    InverterSupplierEntity ObjEntity = new InverterSupplierEntity();
                    ObjEntity.InverterSupplierID = Convert.ToInt32(hdnInverterSupplierID.Value);
                    ObjEntity.InverterSupplier = txtInverterSupplier.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    InverterSupplierManagement.tblInverterSupplier_Update(ObjEntity);
                    BindInverterSupplier();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Inverter Supplier Updated Successfully";
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
            txtInverterSupplier.Text = string.Empty;
            chkActive.Checked = true;
            hdnInverterSupplierID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindInverterSupplier();

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
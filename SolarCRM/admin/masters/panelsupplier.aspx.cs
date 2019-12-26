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
    public partial class panelsupplier : System.Web.UI.Page
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
                BindPanelSupplier();
            }
        }

        private void BindPanelSupplier()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<PanelSupplierEntity> lstEntity = new List<PanelSupplierEntity>();
                lstEntity = PanelSupplierManagement.tblPanelSupplier_Select(objCommon, out Count);
                rptPanelSupplier.DataSource = lstEntity;
                rptPanelSupplier.DataBind();
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
                PanelSupplierEntity objEntity = new PanelSupplierEntity();

                int Exist = PanelSupplierManagement.tblPanelSupplier_Exists(txtPanelSupplier.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.PanelSupplier = txtPanelSupplier.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    PanelSupplierManagement.tblPanelSupplier_Insert(objEntity);
                    BindPanelSupplier();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Panel Supplier Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Panel Supplier Already Exist.";
                    // txtPanelSupplier.Text = "";
                    // txtPanelSupplier.Focus();
                    //BindPanelSupplier();
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

        protected void rptPanelSupplier_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = PanelSupplierManagement.tblPanelSupplier_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnPanelSupplierID.Value = lstEntity.PanelSupplierID.ToString();
                    txtPanelSupplier.Text = lstEntity.PanelSupplier;
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
                    PanelSupplierManagement.tblPanelSupplier_Delete(Convert.ToInt32(e.CommandArgument));
                    BindPanelSupplier();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Panel Supplier Deleted Successfully";
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
                var lstEntity = PanelSupplierManagement.tblPanelSupplier_SelectForUpdate(txtPanelSupplier.Text.Trim(), chkActive.Checked);
                if (lstEntity.PanelSupplier != null)
                {
                    if (txtPanelSupplier.Text.Trim() == lstEntity.PanelSupplier && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Panel Supplier Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    PanelSupplierEntity ObjEntity = new PanelSupplierEntity();
                    ObjEntity.PanelSupplierID = Convert.ToInt32(hdnPanelSupplierID.Value);
                    ObjEntity.PanelSupplier = txtPanelSupplier.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    PanelSupplierManagement.tblPanelSupplier_Update(ObjEntity);
                    BindPanelSupplier();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Panel Supplier Updated Successfully";
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
            txtPanelSupplier.Text = string.Empty;
            chkActive.Checked = true;
            hdnPanelSupplierID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindPanelSupplier();

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
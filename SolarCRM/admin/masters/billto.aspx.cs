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
    public partial class billto : System.Web.UI.Page
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
                BindBillTo();
            }
        }

        private void BindBillTo()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<BillToEntity> lstEntity = new List<BillToEntity>();
                lstEntity = BillToManagement.tblBillTo_Select(objCommon, out Count);
                rptBillTo.DataSource = lstEntity;
                rptBillTo.DataBind();
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
                BillToEntity objEntity = new BillToEntity();

                int Exist = BillToManagement.tblBillTo_Exists(txtBillTo.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.BillTo = txtBillTo.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    BillToManagement.tblBillTo_Insert(objEntity);
                    BindBillTo();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Bill To Status Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Bill To Status Already Exist.";
                    // txtBillTo.Text = "";
                    // txtBillTo.Focus();
                    //BindBillTo();
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

        protected void rptBillTo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = BillToManagement.tblBillTo_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnBillToID.Value = lstEntity.BillToID.ToString();
                    txtBillTo.Text = lstEntity.BillTo;
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
                    BillToManagement.tblBillTo_Delete(Convert.ToInt32(e.CommandArgument));
                    BindBillTo();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Bill To Status Deleted Successfully";
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
                var lstEntity = BillToManagement.tblBillTo_SelectForUpdate(txtBillTo.Text.Trim(), chkActive.Checked);
                if (lstEntity.BillTo != null)
                {
                    if (txtBillTo.Text.Trim() == lstEntity.BillTo && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Bill To Status Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    BillToEntity ObjEntity = new BillToEntity();
                    ObjEntity.BillToID = Convert.ToInt32(hdnBillToID.Value);
                    ObjEntity.BillTo = txtBillTo.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    BillToManagement.tblBillTo_Update(ObjEntity);
                    BindBillTo();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Bill To Status Updated Successfully";
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
            txtBillTo.Text = string.Empty;
            chkActive.Checked = true;
            hdnBillToID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindBillTo();

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
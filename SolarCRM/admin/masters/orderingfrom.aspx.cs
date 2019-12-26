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
    public partial class orderingfrom : System.Web.UI.Page
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
                BindOrderingFrom();
            }
        }

        private void BindOrderingFrom()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<OrderingFromEntity> lstEntity = new List<OrderingFromEntity>();
                lstEntity = OrderingFromManagement.tblOrderingFrom_Select(objCommon, out Count);
                rptOrderingFrom.DataSource = lstEntity;
                rptOrderingFrom.DataBind();
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
                OrderingFromEntity objEntity = new OrderingFromEntity();

                int Exist = OrderingFromManagement.tblOrderingFrom_Exists(txtOrderingFrom.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.OrderingFrom = txtOrderingFrom.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    OrderingFromManagement.tblOrderingFrom_Insert(objEntity);
                    BindOrderingFrom();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Ordering From Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Ordering From Already Exist.";
                    // txtOrderingFrom.Text = "";
                    // txtOrderingFrom.Focus();
                    //BindOrderingFrom();
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

        protected void rptOrderingFrom_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = OrderingFromManagement.tblOrderingFrom_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnOrderingFromID.Value = lstEntity.OrderingFromID.ToString();
                    txtOrderingFrom.Text = lstEntity.OrderingFrom;
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
                    OrderingFromManagement.tblOrderingFrom_Delete(Convert.ToInt32(e.CommandArgument));
                    BindOrderingFrom();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Ordering From Deleted Successfully";
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
                var lstEntity = OrderingFromManagement.tblOrderingFrom_SelectForUpdate(txtOrderingFrom.Text.Trim(), chkActive.Checked);
                if (lstEntity.OrderingFrom != null)
                {
                    if (txtOrderingFrom.Text.Trim() == lstEntity.OrderingFrom && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Ordering From Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    OrderingFromEntity ObjEntity = new OrderingFromEntity();
                    ObjEntity.OrderingFromID = Convert.ToInt32(hdnOrderingFromID.Value);
                    ObjEntity.OrderingFrom = txtOrderingFrom.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    OrderingFromManagement.tblOrderingFrom_Update(ObjEntity);
                    BindOrderingFrom();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Ordering From Updated Successfully";
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
            txtOrderingFrom.Text = string.Empty;
            chkActive.Checked = true;
            hdnOrderingFromID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindOrderingFrom();

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
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
    public partial class customertype : System.Web.UI.Page
    {
        protected string SiteURL;

        CustomerTypeManagement CustomerTypeservice = new CustomerTypeManagement();

        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;
            if (!IsPostBack)
            {
                Session["PageNo"] = 1;
                Session["PageSize"] = 10;
                BindCustomerType();
            }
        }

        private void BindCustomerType()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;

                List<CustomerTypeEntity> lstEntity = new List<CustomerTypeEntity>();
                lstEntity = CustomerTypeservice.tblCustType_Select(objCommon, out Count);
                rptCustomerType.DataSource = lstEntity;
                rptCustomerType.DataBind();

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
                CustomerTypeEntity objEntity = new CustomerTypeEntity();

                int Exist = CustomerTypeservice.tblCustType_Exists(txtCustomerType.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.CustType = txtCustomerType.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    CustomerTypeservice.tblCustomerType_Insert(objEntity);
                    BindCustomerType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Customer Type Added Successfully";
                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Customer Type Already Exist.";
                    // txtCustomerType.Text = "";
                    // txtCustomerType.Focus();
                    //BindCustomerType();
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

        protected void rptCustomerType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = CustomerTypeservice.tblCustType_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnCustTypeID.Value = lstEntity.CustTypeID.ToString();
                    txtCustomerType.Text = lstEntity.CustType;
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
                    CustomerTypeservice.tblCustType_Delete(Convert.ToInt32(e.CommandArgument));
                    BindCustomerType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Customer Type Deleted Successfully";
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
                var lstEntity = CustomerTypeservice.tblCustType_SelectForUpdate(txtCustomerType.Text.Trim(), chkActive.Checked);
                if (lstEntity.CustType != null)
                {
                    if (txtCustomerType.Text.Trim() == lstEntity.CustType && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Customer Type Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    CustomerTypeEntity ObjEntity = new CustomerTypeEntity();
                    ObjEntity.CustTypeID = Convert.ToInt32(hdnCustTypeID.Value);
                    ObjEntity.CustType = txtCustomerType.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    CustomerTypeservice.tblCustType_Update(ObjEntity);
                    BindCustomerType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Customer Type Updated Successfully";
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
            txtCustomerType.Text = string.Empty;
            chkActive.Checked = true;
            hdnCustTypeID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }


        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindCustomerType();

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
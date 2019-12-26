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
    public partial class salescommission : System.Web.UI.Page
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
                // ProjectManagerDropDownList();
                BindEmployeesCommission();
            }
           
        }


        private void BindEmployeesCommission()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<EmployeesCommissionEntity> lstEntity = new List<EmployeesCommissionEntity>();
                lstEntity = EmployeesCommissionManagement.tblEmployeesCommission_Select(objCommon, out Count);
                rptEmployeesCommission.DataSource = lstEntity;
                rptEmployeesCommission.DataBind();
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
                EmployeesCommissionEntity objEntity = new EmployeesCommissionEntity();

                //  int Exist = EmployeesCommissionManagement.tblEmployeesCommission_Exists(txtEmployeesCommission.Text.Trim());
                // if (Exist == 0)
                {

                    objEntity.EmployeeID = Convert.ToInt32(ddlSalesRep.SelectedValue);
                    objEntity.EmployeesCommission = txtEmployeesCommission.Text.Trim();
                    objEntity.EmployeesComment = txtEmployeesComment.Text.Trim();                  
                    objEntity.Active = chkActive.Checked;                  
                    EmployeesCommissionManagement.tblEmployeesCommission_Insert(objEntity);
                    BindEmployeesCommission();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Commission Added Successfully";

                    Reset();
                }

                //else
                //{
                //    divAlert.Visible = true;
                //    divSuccess.Visible = false;
                //    lblErrorMsg.Text = "Company Source Sub Already Exist.";

                //}

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

        protected void rptEmployeesCommission_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    var lstEntity = EmployeesCommissionManagement.tblEmployeesCommission_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnEmployeesCommissionID.Value = lstEntity.EmployeesCommissionID.ToString();
                    ddlSalesRep.SelectedValue = lstEntity.EmployeeID.ToString();
                    txtEmployeesCommission.Text = lstEntity.EmployeesCommission;
                    txtEmployeesComment.Text = lstEntity.EmployeesComment;                  
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
                    EmployeesCommissionManagement.tblEmployeesCommission_Delete(Convert.ToInt32(e.CommandArgument));
                    BindEmployeesCommission();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Commission Deleted Successfully";
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
                //  var lstEntity = EmployeesCommissionManagement.tblEmployeesCommission_SelectForUpdate(txtEmployeesCommission.Text.Trim(), chkActive.Checked);
                //if (lstEntity.EmployeesCommission != null)
                //{
                //    if (txtEmployeesCommission.Text.Trim() == lstEntity.EmployeesCommission && chkActive.Checked == lstEntity.Active)
                //    {
                //        divSuccess.Visible = false;
                //        divAlert.Visible = true;
                //        lblErrorMsg.Text = "Company Source Sub Already Exist.";
                //        Reset();
                //        // txtWatchDialColor.Focus();
                //    }
                //}
                // else
                {
                    EmployeesCommissionEntity ObjEntity = new EmployeesCommissionEntity();
                    ObjEntity.EmployeesCommissionID = Convert.ToInt32(hdnEmployeesCommissionID.Value);
                    ObjEntity.EmployeeID = Convert.ToInt32(ddlSalesRep.SelectedValue);
                    ObjEntity.EmployeesCommission = txtEmployeesCommission.Text.Trim();
                    ObjEntity.EmployeesComment = txtEmployeesComment.Text.Trim();                  
                    ObjEntity.Active = chkActive.Checked;
                    EmployeesCommissionManagement.tblEmployeesCommission_Update(ObjEntity);
                    BindEmployeesCommission();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Commission Updated Successfully";
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
            txtEmployeesCommission.Text = string.Empty;
            txtEmployeesComment.Text = string.Empty;          
            ddlSalesRep.SelectedIndex = 0;
            chkActive.Checked = true;
            hdnEmployeesCommissionID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindEmployeesCommission();

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
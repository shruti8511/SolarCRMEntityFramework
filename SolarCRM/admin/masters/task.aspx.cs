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
    public partial class task : System.Web.UI.Page
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
                BindTask();
                SalesTeamDropDownList();
            }
        }




        //public void BindRole()
        //{
        //    List<EmployeeEntity> lstEntity = new List<EmployeeEntity>();
        //    lstEntity = EmployeeManagement.SpRolesGetDataByAsc();
        //    lstRole.DataSource = lstEntity;
        //    lstRole.DataMember = "RoleName";
        //    lstRole.DataTextField = "RoleName";
        //    lstRole.DataValueField = "RoleName";
        //    lstRole.DataBind();
        //}


        public void SalesTeamDropDownList()
        {
            List<EmployeeEntity> lstEntity = new List<EmployeeEntity>();
            lstEntity = EmployeeManagement.SpRolesGetDataByAsc();
            ddlRole.DataSource = lstEntity;
            ddlRole.DataTextField = "RoleName";
            ddlRole.DataValueField = "RoleId";
            ddlRole.DataBind();
            ddlRole.Items.Insert(0, new ListItem("Select", "0"));
        }






        private void BindTask()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<TaskEntity> lstEntity = new List<TaskEntity>();
                lstEntity = TaskManagement.tblTask_Select(objCommon, out Count);
                rptTask.DataSource = lstEntity;
                rptTask.DataBind();
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
                TaskEntity objEntity = new TaskEntity();

                int Exist = TaskManagement.tblTask_Exists(txtTask.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.Task = txtTask.Text.Trim();
                    objEntity.RoleId = ddlRole.SelectedValue;
                    objEntity.Active = chkActive.Checked;
                    TaskManagement.tblTask_Insert(objEntity);
                    BindTask();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Task Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Task Already Exist.";
                    // txtTask.Text = "";
                    // txtTask.Focus();
                    //BindTask();
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

        protected void rptTask_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = TaskManagement.tblTask_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnTaskID.Value = lstEntity.TaskID.ToString();
                    txtTask.Text = lstEntity.Task;
                    ddlRole.SelectedValue = lstEntity.RoleId;
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
                    TaskManagement.tblTask_Delete(Convert.ToInt32(e.CommandArgument));
                    BindTask();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Task Deleted Successfully";
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
                var lstEntity = TaskManagement.tblTask_SelectForUpdate(txtTask.Text.Trim(), chkActive.Checked);
                if (lstEntity.Task != null)
                {
                    if (txtTask.Text.Trim() == lstEntity.Task && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Task Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    TaskEntity ObjEntity = new TaskEntity();
                    ObjEntity.TaskID = Convert.ToInt32(hdnTaskID.Value);
                    ObjEntity.Task = txtTask.Text.Trim();
                    ObjEntity.RoleId = ddlRole.SelectedValue;
                    ObjEntity.Active = chkActive.Checked;
                    TaskManagement.tblTask_Update(ObjEntity);
                    BindTask();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Task Updated Successfully";
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
            ddlRole.SelectedIndex = 0;
            txtTask.Text = string.Empty;
            chkActive.Checked = true;
            hdnTaskID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindTask();

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
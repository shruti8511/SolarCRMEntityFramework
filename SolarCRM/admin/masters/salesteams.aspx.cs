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
    public partial class salesteams : System.Web.UI.Page
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
                BindSalesTeam();
            }
        }

        private void BindSalesTeam()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<SalesTeamEntity> lstEntity = new List<SalesTeamEntity>();
                lstEntity = SalesTeamManagement.tblSalesTeam_Select(objCommon, out Count);
                rptSalesTeam.DataSource = lstEntity;
                rptSalesTeam.DataBind();
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
                SalesTeamEntity objEntity = new SalesTeamEntity();

                int Exist = SalesTeamManagement.tblSalesTeam_Exists(txtSalesTeam.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.SalesTeam = txtSalesTeam.Text.Trim();
                    objEntity.Active = chkActive.Checked;                
                    SalesTeamManagement.tblSalesTeam_Insert(objEntity);
                    BindSalesTeam();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Sales Team Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Sales Team Already Exist.";
                    // txtSalesTeam.Text = "";
                    // txtSalesTeam.Focus();
                    //BindSalesTeam();
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

        protected void rptSalesTeam_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = SalesTeamManagement.tblSalesTeam_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnSalesTeamID.Value = lstEntity.SalesTeamID.ToString();
                    txtSalesTeam.Text = lstEntity.SalesTeam;
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
                    SalesTeamManagement.tblSalesTeam_Delete(Convert.ToInt32(e.CommandArgument));
                    BindSalesTeam();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Sales Team Deleted Successfully";
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
                var lstEntity = SalesTeamManagement.tblSalesTeam_SelectForUpdate(txtSalesTeam.Text.Trim(), chkActive.Checked);
                if (lstEntity.SalesTeam != null)
                {
                    if (txtSalesTeam.Text.Trim() == lstEntity.SalesTeam && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Sales Team Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    SalesTeamEntity ObjEntity = new SalesTeamEntity();
                    ObjEntity.SalesTeamID = Convert.ToInt32(hdnSalesTeamID.Value);
                    ObjEntity.SalesTeam = txtSalesTeam.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    SalesTeamManagement.tblSalesTeam_Update(ObjEntity);
                    BindSalesTeam();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Sales Team Updated Successfully";
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
            txtSalesTeam.Text = string.Empty;
            chkActive.Checked = true;
            hdnSalesTeamID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindSalesTeam();

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
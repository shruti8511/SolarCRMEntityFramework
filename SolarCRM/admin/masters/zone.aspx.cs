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
    public partial class zone : System.Web.UI.Page
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
                BindZone();
            }

        }

        private void BindZone()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<ZoneEntity> lstEntity = new List<ZoneEntity>();
                lstEntity = ZoneManagement.tblZone_Select(objCommon, out Count);
                rptZone.DataSource = lstEntity;
                rptZone.DataBind();
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
                ZoneEntity objEntity = new ZoneEntity();

                int Exist = ZoneManagement.tblZone_Exists(txtZone.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.Zone = txtZone.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    ZoneManagement.tblZone_Insert(objEntity);
                    BindZone();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Zone Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Zone Already Exist.";
                    // txtZone.Text = "";
                    // txtZone.Focus();
                    //BindZone();
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

       
        protected void rptZone_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = ZoneManagement.tblZone_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnZoneID.Value = lstEntity.ZoneID.ToString();
                    txtZone.Text = lstEntity.Zone;
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
                    ZoneManagement.tblZone_Delete(Convert.ToInt32(e.CommandArgument));
                    BindZone();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Zone Deleted Successfully";
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
                var lstEntity = ZoneManagement.tblZone_SelectForUpdate(txtZone.Text.Trim(), chkActive.Checked);
                if (lstEntity.Zone != null)
                {
                    if (txtZone.Text.Trim() == lstEntity.Zone && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Zone Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    ZoneEntity ObjEntity = new ZoneEntity();
                    ObjEntity.ZoneID = Convert.ToInt32(hdnZoneID.Value);
                    ObjEntity.Zone = txtZone.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    ZoneManagement.tblZone_Update(ObjEntity);
                    BindZone();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Zone Updated Successfully";
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
            txtZone.Text = string.Empty;
            chkActive.Checked = true;
            hdnZoneID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }



        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindZone();

            //if (Convert.ToInt32(Session["pager"]) == 1)
            //{
            //    bindsearch();
            //}
            //else
            //{
            //    BindAmount();
            //}
        }

        protected void btnalert_Click(object sender, EventArgs e)
        {
            divAlert.Visible = false;
        }


        protected void btnSuccess_Click(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
        }


    }
}
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
    public partial class roofangles : System.Web.UI.Page
    {
        protected string SiteURL;

        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;
            if (!IsPostBack)
            {
                Session["PageNo"] = 1;
                Session["PageSize"] = 2;
                BindRoofAngle();
            }

        }

        private void BindRoofAngle()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<RoofAngleEntity> lstEntity = new List<RoofAngleEntity>();
                lstEntity = RoofAngleManagement.tblRoofAngle_Select(objCommon, out Count);
                rptRoofAngle.DataSource = lstEntity;
                rptRoofAngle.DataBind();
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
                RoofAngleEntity objEntity = new RoofAngleEntity();

                int Exist = RoofAngleManagement.tblRoofAngle_Exists(txtRoofAngle.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.RoofAngle = txtRoofAngle.Text.Trim();
                    objEntity.Variation = Convert.ToDecimal(txtVariations.Text.Trim());                   
                    objEntity.Seq = 0;
                    objEntity.Active = chkActive.Checked;
                    RoofAngleManagement.tblRoofAngle_Insert(objEntity);
                    BindRoofAngle();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Roof Angle Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Roof Angle Already Exist.";
                    // txtRoofAngle.Text = "";
                    // txtRoofAngle.Focus();
                    //BindRoofAngle();
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

        protected void rptRoofAngle_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = RoofAngleManagement.tblRoofAngle_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnRoofAngleID.Value = lstEntity.RoofAngleID.ToString();
                    txtRoofAngle.Text = lstEntity.RoofAngle;
                    txtVariations.Text = lstEntity.Variation.ToString();                  
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
                    RoofAngleManagement.tblRoofAngle_Delete(Convert.ToInt32(e.CommandArgument));
                    BindRoofAngle();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Roof Angle Deleted Successfully";
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
                var lstEntity = RoofAngleManagement.tblRoofAngle_SelectForUpdate(txtRoofAngle.Text.Trim(), chkActive.Checked);
                if (lstEntity.RoofAngle != null)
                {
                    if (txtRoofAngle.Text.Trim() == lstEntity.RoofAngle && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Roof Angle Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    RoofAngleEntity ObjEntity = new RoofAngleEntity();
                    ObjEntity.RoofAngleID = Convert.ToInt32(hdnRoofAngleID.Value);
                    ObjEntity.RoofAngle = txtRoofAngle.Text.Trim();
                    ObjEntity.Variation = Convert.ToDecimal(txtVariations.Text.Trim());                  
                    ObjEntity.Active = chkActive.Checked;
                    RoofAngleManagement.tblRoofAngle_Update(ObjEntity);
                    BindRoofAngle();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Roof Angle Updated Successfully";
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
            txtRoofAngle.Text = string.Empty;
            txtVariations.Text = string.Empty;
            chkActive.Checked = true;
            hdnRoofAngleID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindRoofAngle();

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
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
    public partial class housetype : System.Web.UI.Page
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
                BindHouseType();
            }
        }


        private void BindHouseType()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<HouseTypeEntity> lstEntity = new List<HouseTypeEntity>();
                lstEntity = HouseTypeManagement.tblHouseType_Select(objCommon, out Count);
                rptHouseType.DataSource = lstEntity;
                rptHouseType.DataBind();
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
                HouseTypeEntity objEntity = new HouseTypeEntity();

                int Exist = HouseTypeManagement.tblHouseType_Exists(txtHouseType.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.HouseType = txtHouseType.Text.Trim();
                    objEntity.Variation = Convert.ToDecimal(txtVariations.Text.Trim());
                    objEntity.HouseTypeABB = txtHouseTypeABB.Text.Trim();
                    objEntity.Seq = 0;                   
                    objEntity.Active = chkActive.Checked;
                    HouseTypeManagement.tblHouseType_Insert(objEntity);
                    BindHouseType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "House Type Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "House TypeAlready Exist.";
                    // txtHouseType.Text = "";
                    // txtHouseType.Focus();
                    //BindHouseType();
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

        protected void rptHouseType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = HouseTypeManagement.tblHouseType_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnHouseTypeID.Value = lstEntity.HouseTypeID.ToString();
                    txtHouseType.Text = lstEntity.HouseType;
                    txtVariations.Text = lstEntity.Variation.ToString();
                    txtHouseTypeABB.Text = lstEntity.HouseTypeABB;                  
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
                    HouseTypeManagement.tblHouseType_Delete(Convert.ToInt32(e.CommandArgument));
                    BindHouseType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "House Type Deleted Successfully";
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
                var lstEntity = HouseTypeManagement.tblHouseType_SelectForUpdate(txtHouseType.Text.Trim(), chkActive.Checked);
                if (lstEntity.HouseType != null)
                {
                    if (txtHouseType.Text.Trim() == lstEntity.HouseType && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "House Type Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    HouseTypeEntity ObjEntity = new HouseTypeEntity();
                    ObjEntity.HouseTypeID = Convert.ToInt32(hdnHouseTypeID.Value);
                    ObjEntity.HouseType = txtHouseType.Text.Trim();
                    ObjEntity.Variation = Convert.ToDecimal(txtVariations.Text.Trim());
                    ObjEntity.HouseTypeABB = txtHouseTypeABB.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    HouseTypeManagement.tblHouseType_Update(ObjEntity);
                    BindHouseType();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "House Type Updated Successfully";
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
            txtHouseType.Text = string.Empty;
            txtVariations.Text = string.Empty;
            txtHouseTypeABB.Text = string.Empty;           
            chkActive.Checked = true;
            hdnHouseTypeID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindHouseType();

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
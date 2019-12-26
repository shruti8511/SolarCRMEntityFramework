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
    public partial class promooffer : System.Web.UI.Page
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
                BindPromoOffer();
            }
        }

        private void BindPromoOffer()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<PromoOfferEntity> lstEntity = new List<PromoOfferEntity>();
                lstEntity = PromoOfferManagement.tblPromoOffer_Select(objCommon, out Count);
                rptPromoOffer.DataSource = lstEntity;
                rptPromoOffer.DataBind();
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
                PromoOfferEntity objEntity = new PromoOfferEntity();

                int Exist = PromoOfferManagement.tblPromoOffer_Exists(txtPromoOffer.Text.Trim());
                if (Exist == 0)
                {

                    objEntity.PromoOffer = txtPromoOffer.Text.Trim();
                    objEntity.Active = chkActive.Checked;
                    objEntity.Seq = 0;
                    PromoOfferManagement.tblPromoOffer_Insert(objEntity);
                    BindPromoOffer();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Promo Offer Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Promo Offer Already Exist.";
                    // txtPromoOffer.Text = "";
                    // txtPromoOffer.Focus();
                    //BindPromoOffer();
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

        protected void rptPromoOffer_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {

                    var lstEntity = PromoOfferManagement.tblPromoOffer_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnPromoOfferID.Value = lstEntity.PromoOfferID.ToString();
                    txtPromoOffer.Text = lstEntity.PromoOffer;
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
                    PromoOfferManagement.tblPromoOffer_Delete(Convert.ToInt32(e.CommandArgument));
                    BindPromoOffer();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Promo Offer Deleted Successfully";
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
                var lstEntity = PromoOfferManagement.tblPromoOffer_SelectForUpdate(txtPromoOffer.Text.Trim(), chkActive.Checked);
                if (lstEntity.PromoOffer != null)
                {
                    if (txtPromoOffer.Text.Trim() == lstEntity.PromoOffer && chkActive.Checked == lstEntity.Active)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Promo Offer Already Exist.";
                        Reset();
                        // txtWatchDialColor.Focus();
                    }
                }
                else
                {
                    PromoOfferEntity ObjEntity = new PromoOfferEntity();
                    ObjEntity.PromoOfferID = Convert.ToInt32(hdnPromoOfferID.Value);
                    ObjEntity.PromoOffer = txtPromoOffer.Text.Trim();
                    ObjEntity.Active = chkActive.Checked;
                    PromoOfferManagement.tblPromoOffer_Update(ObjEntity);
                    BindPromoOffer();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Promo Offer Updated Successfully";
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
            txtPromoOffer.Text = string.Empty;
            chkActive.Checked = true;
            hdnPromoOfferID.Value = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindPromoOffer();

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using SolarCRM.Entity.Models.EmployeeModule;
using SolarCRM.Entity.Models.CompanyModule;
using SolarCRM.BAL.Implementations.CompanyModule;
using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.BAL.Comman;
using SolarCRM.BAL.Implementations.ProjectModule;
using SolarCRM.Entity.Models.Common;
using SolarCRM.PagingUserControl;
using SolarCRM.Entity.Models.ProjectModule;

namespace SolarCRM.admin.company
{
    public partial class addcompany : System.Web.UI.Page
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
                BindDropDown();
                BindCompanyList();
            }
        }


        public void BindCompanyList()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<CustomersEntity> lstEntity = new List<CustomersEntity>();
                lstEntity = CustomersManagement.tblCustomers_SelectRoleWise(objCommon, out Count);
                rptCompanylist.DataSource = lstEntity;
                rptCompanylist.DataBind();
                pageGrid.BindPageing(Count);

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }


        }


        protected void rptCompanylist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    var lstEntity = CustomersManagement.tblCustomer_ForEdit(Convert.ToInt32(e.CommandArgument));

                    hdnCustomerID.Value =Convert.ToString(lstEntity.CustomerID);
                    txtContFirst.Text = lstEntity.CustFirst;
                    txtContLast.Text = lstEntity.CustLast;
                    txtCompany.Text = lstEntity.FullName;
                    txtContMobile.Text = lstEntity.CustMobile;
                    txtContEmail.Text = lstEntity.CustEmail;
                    txtCustPhone.Text = lstEntity.CustPhone;
                    txtCustAltPhone.Text = lstEntity.CustAltPhone;
                    ddlCustTypeID.SelectedValue = Convert.ToString(lstEntity.CustTypeID);
                    ddlProjectType.SelectedValue = Convert.ToString(lstEntity.ProjectTypeID);
                    ddlCustSourceID.SelectedValue = Convert.ToString(lstEntity.CustSourceID);

                    ddlSalutation.SelectedValue = Convert.ToString(lstEntity.CustMr);

                    rblArea.SelectedValue = Convert.ToString(lstEntity.Area);

                    List<CompanySourceSubEntity> lstCompanySourceSub = CompanySourceSubManagement.tblCustSourceSub_SelectByCSID(Convert.ToInt32(ddlCustSourceID.SelectedValue));
                    if (lstCompanySourceSub.Count > 0)
                    {
                        sourcesub.Visible = true;
                        ddlCustSourceSubID.DataSource = lstCompanySourceSub;
                        ddlCustSourceSubID.DataMember = "CompanySourceSub";
                        ddlCustSourceSubID.DataTextField = "CompanySourceSub";
                        ddlCustSourceSubID.DataValueField = "CompanySourceSubID";
                        ddlCustSourceSubID.DataBind();
                    }
                    else
                    {
                        sourcesub.Visible = false;
                    }

                    ddlCustSourceSubID.SelectedValue = Convert.ToString(lstEntity.CustSourceSubID);



                    txtCustWebSiteLink.Text = lstEntity.CustWebSite;
                    txtCustFax.Text = lstEntity.CustFax;
                    txtCustRating.Text = lstEntity.CustRating;
                    ddlCompanyType.SelectedValue = Convert.ToString(lstEntity.CompanyType);
                    ddlZone.SelectedValue = Convert.ToString(lstEntity.ZoneID);

                    txtSiteAddress.Text = lstEntity.StreetAddress;
                    ddlState.SelectedValue = lstEntity.StreetState;
                    txtArea.Text = lstEntity.StreetArea;
                    txtCity.Text = lstEntity.StreetCity;
                    txtPostCode.Text = lstEntity.StreetPostCode;


                    txtPostalAddress.Text = lstEntity.PostalAddress;
                    ddlPostalState.SelectedValue = lstEntity.PostalState;
                    txtPostalArea.Text = lstEntity.PostalArea;
                    txtPostalCity.Text = lstEntity.PostalCity;
                    txtPostalPostCode.Text = lstEntity.PostalPostCode;


                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                }
                catch (Exception ex)
                {
                    divSuccess.Visible = false;
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "Error : " + ex.Message;
                }


            }
            else if (e.CommandName.ToString() == "Detail")
            {

            }
        }


        protected void rptCompanylist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }


        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindCompanyList();

            //if (Convert.ToInt32(Session["pager"]) == 1)
            //{
            //    bindsearch();
            //}
            //else
            //{
            //    BindAmount();
            //}
        }



        public void BindDropDown()
        {
            try
            {
                List<CustomerTypeEntity> lstCustType = new List<CustomerTypeEntity>();
                lstCustType = CustomerTypeManagement.tblCustType_SelectActive();
                ddlCustTypeID.DataSource = lstCustType;
                ddlCustTypeID.DataMember = "CustType";
                ddlCustTypeID.DataTextField = "CustType";
                ddlCustTypeID.DataValueField = "CustTypeID";
                ddlCustTypeID.DataBind();
                if (Request.QueryString["custtypeid"] != null)
                {
                    ddlCustTypeID.SelectedValue = Request.QueryString["custtypeid"];
                }


                ddlProjectType.DataSource = ProjectTypeManagement.tblProjectType_SelectActive();
                ddlProjectType.DataMember = "ProjectType";
                ddlProjectType.DataTextField = "ProjectType";
                ddlProjectType.DataValueField = "ProjectTypeID";
                ddlProjectType.DataBind();

                ddlCustSourceID.DataSource = CompanySourceManagement.tblCompanySource_SelectActive();
                ddlCustSourceID.DataMember = "CompanySource";
                ddlCustSourceID.DataTextField = "CompanySource";
                ddlCustSourceID.DataValueField = "CompanySourceID";
                ddlCustSourceID.DataBind();

                ddlCompanyType.DataSource = CompanyTypeManagement.tblCompanyType_SelectActive();
                ddlCompanyType.DataMember = "CompanyType";
                ddlCompanyType.DataTextField = "CompanyType";
                ddlCompanyType.DataValueField = "CompanyTypeID";
                ddlCompanyType.DataBind();


                ddlZone.DataSource = ZoneManagement.tblZone_SelectActive();
                ddlZone.DataMember = "Zone";
                ddlZone.DataTextField = "Zone";
                ddlZone.DataValueField = "ZoneID";
                ddlZone.DataBind();

                ddlState.DataSource = CompanyLocationsManagement.tblState_SelectActive();
                ddlState.DataMember = "StateName";
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateName";
                ddlState.DataBind();

                ddlPostalState.DataSource = CompanyLocationsManagement.tblState_SelectActive();
                ddlPostalState.DataMember = "StateName";
                ddlPostalState.DataTextField = "StateName";
                ddlPostalState.DataValueField = "StateName";
                ddlPostalState.DataBind();

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }

        }

        protected void txtContLast_TextChanged(object sender, EventArgs e)
        {
            txtCompany.Text = txtContFirst.Text.Trim() + " " + txtContLast.Text.Trim();
            txtContMobile.Focus();

            if (txtContFirst.Text.Trim() != string.Empty || txtContLast.Text.Trim() != string.Empty)
            {
                List<CustomerExistEntity> lstContacts = CustomersManagement.tblContacts_ExistSelect(txtContFirst.Text.Trim() + ' ' + txtContLast.Text.Trim());
                if (lstContacts.Count > 0)
                {
                    rptNameDupCheck.DataSource = lstContacts;
                    rptNameDupCheck.DataBind();

                    // Show Popup
                    NameDupCheck.Attributes.Add("class", "modal fade modal-overflow in");
                    NameDupCheck.Attributes.Add("Style", "display:block;");

                    Session["Name"] = "";
                }
            }
        }

        protected void txtContMobile_TextChanged(object sender, EventArgs e)
        {
            if (txtContMobile.Text.Trim() != string.Empty)
            {
                List<CustomerExistEntity> lstContacts = CustomersManagement.tblContacts_ExistSelectMobile(txtContMobile.Text.Trim());
                if (lstContacts.Count > 0)
                {
                    rptMobileDupCheck.DataSource = lstContacts;
                    rptMobileDupCheck.DataBind();

                    // Show Popup
                    MobileDupCheck.Attributes.Add("class", "modal fade modal-overflow in");
                    MobileDupCheck.Attributes.Add("Style", "display:block;");

                    Session["Mobile"] = "";
                }
            }
        }

        protected void txtContEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtContEmail.Text.Trim() != string.Empty)
            {
                List<CustomerExistEntity> lstContacts = CustomersManagement.tblContacts_ExistSelectEmail(txtContEmail.Text.Trim());
                if (lstContacts.Count > 0)
                {
                    rptEmailCheck.DataSource = lstContacts;
                    rptEmailCheck.DataBind();

                    // Show Popup
                    EmailDupCheck.Attributes.Add("class", "modal fade modal-overflow in");
                    EmailDupCheck.Attributes.Add("Style", "display:block;");

                    Session["Email"] = "";
                }
            }
        }

        protected void txtCustPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtCustPhone.Text.Trim() != string.Empty)
            {
                List<CustomerExistEntity> lstContacts = CustomersManagement.tblContacts_ExistSelectPhone(txtCustPhone.Text.Trim());
                if (lstContacts.Count > 0)
                {
                    rptphonedupcheck.DataSource = lstContacts;
                    rptphonedupcheck.DataBind();

                    // Show Popup
                    PhoneDupCheck.Attributes.Add("class", "modal fade modal-overflow in");
                    PhoneDupCheck.Attributes.Add("Style", "display:block;");

                    Session["Phone"] = "";
                }
            }
        }

        protected void ddlCustSourceID_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlref.Visible = true;
            ddlCustSourceSubID.Items.Clear();
            ListItem lst = new ListItem();
            lst.Text = "Select";
            lst.Value = "0";
            ddlCustSourceSubID.Items.Add(lst);

            if (ddlCustSourceID.SelectedValue != "")
            {
                List<CompanySourceSubEntity> lstCompanySourceSub = CompanySourceSubManagement.tblCustSourceSub_SelectByCSID(Convert.ToInt32(ddlCustSourceID.SelectedValue));
                if (lstCompanySourceSub.Count > 0)
                {
                    sourcesub.Visible = true;
                    ddlCustSourceSubID.DataSource = lstCompanySourceSub;
                    ddlCustSourceSubID.DataMember = "CompanySourceSub";
                    ddlCustSourceSubID.DataTextField = "CompanySourceSub";
                    ddlCustSourceSubID.DataValueField = "CompanySourceSubID";
                    ddlCustSourceSubID.DataBind();
                }
                else
                {
                    sourcesub.Visible = false;
                }
            }
        }

        protected void ddlCustSourceSubID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCustSourceSubID.SelectedValue == "15")
            {
                pnlref.Visible = true;
            }
            else
            {
                pnlref.Visible = false;
            }
        }

        //protected void txtProjectNumber_TextChanged(object sender, EventArgs e)
        //{
        //    string ReferredByBalOwing = "";
        //    if (txtProjectNumber.Text != string.Empty)
        //    {
        //        DataTable sucrefbos = ClstblCustomers.tblProjects_SelectReferral(txtProjectNumber.Text);
        //        try
        //        {
        //            ReferredByBalOwing = SiteConfiguration.ChangeCurrency(sucrefbos.Rows[0]["BalOwing"].ToString());
        //        }
        //        catch
        //        {
        //        }
        //    }
        //}


        protected void chkSameasAbove_CheckedChanged(object sender, EventArgs e)
        {

            if (chkSameasAbove.Checked == true)
            {
                txtPostalAddress.Text = txtSiteAddress.Text.Trim();
                ddlPostalState.SelectedValue = ddlState.SelectedValue;
                txtPostalCity.Text = txtCity.Text.Trim();
                txtPostalArea.Text = txtArea.Text.Trim();
                txtPostalPostCode.Text = txtPostCode.Text;
            }
            else
            {
                txtPostalAddress.Text = string.Empty;
                ddlPostalState.SelectedValue = string.Empty;
                txtPostalCity.Text = string.Empty;
                txtPostalArea.Text = string.Empty;
                txtPostalPostCode.Text = string.Empty;
            }
        }

        protected void txtArea_TextChanged(object sender, EventArgs e)
        {
            string[] cityarr = txtArea.Text.Split('|');
            if (cityarr.Length > 1)
            {
                txtArea.Text = cityarr[3].Trim();
                txtCity.Text = cityarr[0].Trim();
                txtPostCode.Text = cityarr[2].Trim();
                hdnCompanyLocationID.Value = cityarr[5].Trim();
                rblArea.SelectedValue = cityarr[4].Trim();
            }

            //if (!string.IsNullOrEmpty(ddlStreetCity.Text.Trim()) && !string.IsNullOrEmpty(autocomplete.Text.Trim()))
            //{
            //    DataTable dt2 = ClstblCustomers.tblCustomers_SelectAddress(autocomplete.Text.Trim(), ddlStreetCity.Text.Trim());
            //    if (dt2.Rows.Count > 0)
            //    {
            //        if (!string.IsNullOrEmpty(hdnCustomerID.Value))
            //        {
            //            if (dt2.Rows[0]["CustomerID"].ToString() != hdnCustomerID.Value)
            //            {
            //                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Already Exists')", true);
            //                autocomplete.Text = "";
            //                ddlStreetCity.Text = "";
            //                txtStreetState.Text = "";
            //                txtStreetPostCode.Text = "";
            //            }
            //        }
            //        else
            //        {
            //            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Already Exists')", true);
            //            autocomplete.Text = "";
            //            ddlStreetCity.Text = "";
            //            txtStreetState.Text = "";
            //            txtStreetPostCode.Text = "";
            //        }
            //    }
            //}
        }

        protected void txtPostalArea_TextChanged(object sender, EventArgs e)
        {
            string[] cityarr = txtArea.Text.Split('|');
            if (cityarr.Length > 1)
            {
                txtPostalArea.Text = cityarr[3].Trim();
                txtPostalCity.Text = cityarr[0].Trim();
                txtPostalPostCode.Text = cityarr[2].Trim();
                //hdnCompanyLocationID.Value = cityarr[3].Trim();               
                rblArea.SelectedValue = cityarr[4].Trim();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlProjectType.SelectedValue == "2" && txtCompany.Text.Trim() == txtContFirst.Text.Trim() + " " + txtContLast.Text.Trim())
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please enter proper company name');", true);
                txtCompany.Text = string.Empty;
                // PanAddUpdate.Visible = true;
            }
            else
            {
                //if (ddlCustTypeID.SelectedValue == "13")
                //{
                //    RequiredFieldValidator3.Enabled = false;
                //    RequiredFieldValidator3.Visible = false;
                //    ddlStreetCity.Enabled = true;
                //    RequiredFieldValidator4.Visible = false;
                //    txtStreetState.Enabled = true;
                //    RequiredFieldValidator5.Visible = false;
                //    txtStreetPostCode.Enabled = true;
                //    RequiredFieldValidator6.Visible = false;
                //    RequiredFieldValidator2.Visible = false;
                //    txtCountry.Enabled = true;
                //    if (txtCountry.Text.Trim() == "" || txtCountry.Text.Trim() == null)
                //    {
                //        txtCountry.Text = "China";
                //    }
                //}

                string userid = Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString();
                EmployeeEntity st = EmployeeManagement.tblEmployees_SelectEmployeeID(userid);

                CustomersEntity CustEntity = new CustomersEntity();

                CustEntity.EmployeeID = st.EmployeeID;
                CustEntity.CustTypeID = Convert.ToInt32(ddlCustTypeID.SelectedValue);
                CustEntity.CustSourceID = Convert.ToInt32(ddlCustSourceID.SelectedValue);
                CustEntity.CustSourceSubID = Convert.ToInt32(ddlCustSourceSubID.SelectedValue);
                CustEntity.ProjectTypeID = Convert.ToInt32(ddlProjectType.SelectedValue);
                CustEntity.ZoneID = Convert.ToInt32(ddlZone.SelectedValue);

                CustEntity.CustEntered = DateTime.UtcNow;
                CustEntity.CustEnteredBy = st.EmployeeID;
                CustEntity.CustMr = ddlSalutation.SelectedItem.Text;
                CustEntity.CustFirst = txtContFirst.Text.Trim();
                CustEntity.CustLast = txtContLast.Text.Trim();
                CustEntity.Customer = txtCompany.Text.Trim();
                CustEntity.StreetAddress = txtSiteAddress.Text.Trim();
                CustEntity.StreetArea = txtArea.Text.Trim();
                CustEntity.StreetCity = txtCity.Text.Trim();
                CustEntity.StreetState = ddlState.SelectedItem.Text;
                CustEntity.StreetPostCode = txtPostCode.Text.Trim();
                CustEntity.PostalAddress = txtPostalAddress.Text.Trim();
                CustEntity.PostalArea = txtPostalArea.Text.Trim();
                CustEntity.PostalCity = txtPostalCity.Text;
                CustEntity.PostalState = ddlPostalState.SelectedItem.Text;
                CustEntity.PostalPostCode = txtPostalPostCode.Text;
                CustEntity.Country = txtCountry.Text.Trim(); //"Australia";
                CustEntity.CustEmail = txtContEmail.Text.Trim();
                CustEntity.CustMobile = txtContMobile.Text.Trim();
                CustEntity.CustPhone = txtCustPhone.Text;
                CustEntity.CustAltPhone = txtCustAltPhone.Text;
                CustEntity.CustFax = txtCustFax.Text;
                CustEntity.CustNotes = txtCustNotes.Text;
                CustEntity.CustWebSite = txtCustWebSiteLink.Text;
                CustEntity.BranchLocation = ddlState.SelectedItem.Text + " - " + txtCity.Text.Trim();
                CustEntity.Area = Convert.ToInt32(rblArea.SelectedValue);
                CustEntity.CustRating = txtCustRating.Text;

                CustEntity.ReferredByProjectNo = txtProjectNumber.Text;
                CustEntity.ReferredByCustomerName = txtRefBy.Text;
                CustEntity.ReferredByProjectStatus = "";
                CustEntity.ReferralNotes = txtrefnotes.Text;
                CustEntity.ReferredByBalOwing = "";

                CustEntity.CompanyType = Convert.ToInt32(ddlCompanyType.SelectedValue);
                // CustEntity.CompanyLocationID = Convert.ToInt32(hdnCompanyLocationID.Value);

                if (CustEntity.ReferredByProjectNo != string.Empty)
                {
                    try
                    {
                        var sucrefbos = ProjectsManagement.tblProjects_SelectReferral(Convert.ToInt64(CustEntity.ReferredByProjectNo));

                        CustEntity.ReferredByBalOwing = SiteConfiguration.ChangeCurrency(sucrefbos.BalOwing.ToString());

                        CustEntity.ReferredByProjectStatus = sucrefbos.ProjectStatusID.ToString();
                    }
                    catch { }
                }

                long success = CustomersManagement.tblCustomers_Insert(CustEntity);

                long sucContacts = CustomersManagement.tblCustomers_InsertContacts(success, ddlSalutation.SelectedValue, txtContFirst.Text.Trim(), txtContLast.Text.Trim(), txtContMobile.Text, txtContEmail.Text, CustEntity.EmployeeID, CustEntity.CustEnteredBy);

                // int sucCustInfo = ClstblCustInfo.tblCustInfo_Insert(Convert.ToString(success), "Customer Entered on " + DateTime.Now.AddHours(0).ToShortDateString(), DateTime.Now.AddHours(0).ToString(), Convert.ToString(sucContacts), CustEnteredBy, "1");

                //if (Session["AddCall_Cust"] != "0" && Session["AddCall_Cust"] != null && hdnAdd.Value == "1")
                //{
                //    bool succall = ClstblCallEntry.tblCallEntry_UpdateIsCustomer("true", Session["AddCall_Cust"].ToString());
                //}

                long sucno = CustomersManagement.tblCompanyNumber_Insert(success);
                long CompanyNumber = CustomersManagement.tblCompanyNumber_Select(success);
                //long CompanyNumber = dtCN.Rows[0]["CompanyNumberID"].ToString();
                CustomersManagement.tblCustomers_UpdateCompanyNumber(success, CompanyNumber);

                //ClstblCustomers.tblCustomers_UpdateD2DEmp(Convert.ToString(success), ddlD2DEmployee.SelectedValue, userid, txtD2DAppDate.Text.Trim(), ddlAppTime.SelectedValue);

                if ((txtRefBy.Text != string.Empty || txtProjectNumber.Text != string.Empty || txtrefnotes.Text != string.Empty))
                {
                    ReferralManagement.tblReferral_InsertByCompany(success, sucContacts, CustEntity.EmployeeID, DateTime.UtcNow, CustEntity.ReferredByProjectNo, CustEntity.ReferredByCustomerName, CustEntity.ReferredByProjectStatus, CustEntity.ReferralNotes, CustEntity.ReferredByBalOwing);
                }
                try
                {
                    long ContactID = CustomersManagement.tblCustomers_SelectContactID(CustEntity.ReferredByCustomerName);

                    if (ContactID != 0)
                    {
                        CustomersManagement.tblCustomers_UpdateReferral(success, ContactID);
                    }

                }
                catch
                { }
                try
                {
                    if (Session["Name"].ToString() != "" || Session["Mobile"].ToString() != "" || Session["Email"].ToString() != "")
                    {
                        long custdup = CustomersManagement.tblCustDup_Insert(CustEntity.CustEnteredBy, DateTime.UtcNow, Session["Name"].ToString(), Session["Mobile"].ToString(), Session["Email"].ToString(), CustEntity.Customer, txtContEmail.Text, txtContMobile.Text, success, CompanyNumber);
                    }
                }
                catch
                {
                }

                Session["Name"] = "";
                Session["Mobile"] = "";
                Session["Phone"] = "";
                Session["Email"] = "";

                //if (txtD2DAppDate.Text != string.Empty)
                //{
                //    bool succ1 = ClstblCustomers.tblCustomers_Updateappointment_status("0", Convert.ToString(success));
                //    bool succ2 = ClstblCustomers.tblCustomers_Updatecustomer_lead_status("0", Convert.ToString(success));
                //}

                long suc = CustomersManagement.tblCustLogReport_Insert(success);
                string LogReport = "";

                if (Convert.ToString(suc) != "")
                {
                    if (txtContFirst.Text != string.Empty && txtContLast.Text != string.Empty)
                    {
                        long exist = CustomersManagement.tblContacts_ExistName(txtContFirst.Text + ' ' + txtContLast.Text);
                        if (exist == 1)
                        {
                            LogReport = "Update tblCustLogReport set Name='" + txtContFirst.Text + ' ' + txtContLast.Text + "' WHERE CustomerID='" + Convert.ToString(success) + "'";
                        }
                    }
                    if (txtContMobile.Text != string.Empty)
                    {
                        long exist2 = CustomersManagement.tblContacts_ExistMobile(txtContMobile.Text);
                        if (exist2 == 1)
                        {
                            LogReport = "Update tblCustLogReport set Mobile='" + txtContMobile.Text + "' WHERE CustomerID='" + Convert.ToString(success) + "'";
                        }
                    }
                    if (txtContEmail.Text != string.Empty)
                    {
                        long exist3 = CustomersManagement.tblContacts_ExistEmail(txtContEmail.Text);
                        if (exist3 == 1)
                        {
                            LogReport = "Update tblCustLogReport set Email='" + txtContEmail.Text + "' WHERE CustomerID='" + Convert.ToString(success) + "'";
                        }
                    }
                    if (txtCustPhone.Text != string.Empty)
                    {
                        long exist4 = CustomersManagement.tblCustomers_ExistPhone(txtCustPhone.Text);
                        if (exist4 == 1)
                        {
                            LogReport = "Update tblCustLogReport set LocalNo='" + txtCustPhone.Text + "' WHERE CustomerID='" + Convert.ToString(success) + "'";
                        }
                    }
                    if (LogReport != "")
                    {
                        CustomersManagement.ap_form_element_execute(LogReport);
                    }
                }

                //ClstblContacts.tblContacts_Update_UserId(Convert.ToString(success), Membership.GetUser(username).ProviderUserKey.ToString());
                //if (ddlCustTypeID.SelectedValue == "11")
                //{
                //    Roles.AddUserToRole(username, "Installer");
                //}
                //if (ddlCustTypeID.SelectedValue == "3" || ddlCustTypeID.SelectedValue == "5")
                //{
                //    Roles.AddUserToRole(username, "Customer");
                //}
                //--- do not chage this code start------


                if (Convert.ToString(success) != "")
                {
                    SetAdd();
                    Reset();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Company  Added Successfully";
                    BindAddNewProjectDetails(Convert.ToInt64(success));
                    // SetUpdate();
                }
                else
                {
                    divSuccess.Visible = false;
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "Company Added Failed";
                    SetError();
                }

                BindCompanyList();
                //BindGrid(0);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //var lstEntity = ProjectTypeManagement.tblProjectType_SelectForUpdate(txtProjectType.Text.Trim(), chkActive.Checked);
                //if (lstEntity.ProjectType != null)
                //{
                //    if (txtProjectType.Text.Trim() == lstEntity.ProjectType && chkActive.Checked == lstEntity.Active)
                //    {
                //        divSuccess.Visible = false;
                //        divAlert.Visible = true;
                //        lblErrorMsg.Text = "Project Type Already Exist.";
                //        Reset();
                //        // txtWatchDialColor.Focus();
                //    }
                //}
                //else
                {
                    string userid = Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString();
                    EmployeeEntity st = EmployeeManagement.tblEmployees_SelectEmployeeID(userid);


                    CustomersEntity ObjEntity = new CustomersEntity();
                    ObjEntity.CustomerID = Convert.ToInt32(hdnCustomerID.Value);

                    ObjEntity.EmployeeID = st.EmployeeID;
                    ObjEntity.CustTypeID = Convert.ToInt32(ddlCustTypeID.SelectedValue);
                    ObjEntity.CustSourceID = Convert.ToInt32(ddlCustSourceID.SelectedValue);
                    ObjEntity.CustSourceSubID = Convert.ToInt32(ddlCustSourceSubID.SelectedValue);
                    ObjEntity.ProjectTypeID = Convert.ToInt32(ddlProjectType.SelectedValue);
                    ObjEntity.CustEntered = DateTime.UtcNow;
                    ObjEntity.CustEnteredBy = st.EmployeeID;
                    ObjEntity.CustMr = ddlSalutation.SelectedItem.Text;
                    ObjEntity.CustFirst = txtContFirst.Text.Trim();
                    ObjEntity.CustLast = txtContLast.Text.Trim();
                    ObjEntity.Customer = txtCompany.Text.Trim();
                    ObjEntity.StreetAddress = txtSiteAddress.Text.Trim();
                    ObjEntity.StreetArea = txtArea.Text.Trim();
                    ObjEntity.StreetCity = txtCity.Text.Trim();
                    ObjEntity.StreetState = ddlState.SelectedItem.Text;
                    ObjEntity.StreetPostCode = txtPostCode.Text.Trim();
                    ObjEntity.PostalAddress = txtPostalAddress.Text.Trim();
                    ObjEntity.PostalArea = txtPostalArea.Text.Trim();
                    ObjEntity.PostalCity = txtPostalCity.Text;
                    ObjEntity.PostalState = ddlPostalState.SelectedItem.Text;
                    ObjEntity.PostalPostCode = txtPostalPostCode.Text;
                    ObjEntity.Country = txtCountry.Text.Trim(); //"Australia";
                    ObjEntity.CustEmail = txtContEmail.Text.Trim();
                    ObjEntity.CustMobile = txtContMobile.Text.Trim();
                    ObjEntity.CustPhone = txtCustPhone.Text;
                    ObjEntity.CustAltPhone = txtCustAltPhone.Text;
                    ObjEntity.CustFax = txtCustFax.Text;
                    ObjEntity.CustNotes = txtCustNotes.Text;
                    ObjEntity.CustWebSite = txtCustWebSiteLink.Text;
                    ObjEntity.BranchLocation = ddlState.SelectedItem.Text + " - " + txtCity.Text.Trim();
                    ObjEntity.Area = Convert.ToInt32(rblArea.SelectedValue);
                    ObjEntity.CustRating = txtCustRating.Text;
                    ObjEntity.CompanyType = Convert.ToInt32(ddlCompanyType.SelectedValue);
                    ObjEntity.ZoneID = Convert.ToInt32(ddlZone.SelectedValue); 
                    CustomersManagement.tblCustomers_Update(ObjEntity);
                    BindCompanyList();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Customer Updated Successfully";
                    Reset();
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnReset.Visible = true;
            btnCancel.Visible = false;
            Reset();
        }

        protected void btnDupeName_Click(object sender, EventArgs e)
        {
            HideNameDupCheck();
            //HidePanels();
            rptNameDupCheck.DataSource = null;
            rptNameDupCheck.DataBind();
            txtContFirst.Text = string.Empty;
            txtContLast.Text = string.Empty;
            txtCompany.Text = string.Empty;
            Session["Name"] = "";
        }

        protected void btnNotDupeName_Click(object sender, EventArgs e)
        {
            HideNameDupCheck();
            Session["Name"] = txtContFirst.Text.Trim() + " " + txtContLast.Text.Trim();
        }

        public void HideNameDupCheck()
        {
            NameDupCheck.Attributes.Remove("class");
            NameDupCheck.Attributes.Add("class", "modal fade");
            NameDupCheck.Attributes.Remove("Style");
        }

        protected void btnDupeMobile_Click(object sender, EventArgs e)
        {
            HideMobileDupCheck();
            //HidePanels();
            rptMobileDupCheck.DataSource = null;
            rptMobileDupCheck.DataBind();

            txtContMobile.Text = string.Empty;
            Session["Mobile"] = "";


        }

        protected void btnNotDupeMobile_Click(object sender, EventArgs e)
        {
            HideMobileDupCheck();
            Session["Mobile"] = txtContMobile.Text.Trim();
        }


        public void HideMobileDupCheck()
        {
            MobileDupCheck.Attributes.Remove("class");
            MobileDupCheck.Attributes.Add("class", "modal fade");
            MobileDupCheck.Attributes.Remove("Style");
        }

        protected void btnDupePhone_Click(object sender, EventArgs e)
        {
            HidePhoneDupCheck();
            //HidePanels();
            rptphonedupcheck.DataSource = null;
            rptphonedupcheck.DataBind();

            txtCustPhone.Text = string.Empty;
            Session["Phone"] = "";
        }

        protected void btnNoteDupePhone_Click(object sender, EventArgs e)
        {
            HidePhoneDupCheck();
            Session["Phone"] = txtCustPhone.Text.Trim();
        }

        public void HidePhoneDupCheck()
        {
            PhoneDupCheck.Attributes.Remove("class");
            PhoneDupCheck.Attributes.Add("class", "modal fade");
            PhoneDupCheck.Attributes.Remove("Style");
        }

        protected void btnDupeEmailCheck_Click(object sender, EventArgs e)
        {
            HideEmailDupCheck();
            //HidePanels();
            rptEmailCheck.DataSource = null;
            rptEmailCheck.DataBind();

            txtContEmail.Text = string.Empty;
            Session["Email"] = "";
        }

        protected void btnNotDupeEmailCheck_Click(object sender, EventArgs e)
        {
            HideEmailDupCheck();
            Session["Email"] = txtContEmail.Text.Trim();
        }

        public void HideEmailDupCheck()
        {
            EmailDupCheck.Attributes.Remove("class");
            EmailDupCheck.Attributes.Add("class", "modal fade");
            EmailDupCheck.Attributes.Remove("Style");
        }

        public void SetAdd()
        {
            Reset();

            //PanSuccess.Visible = true;          
            //PanAlreadExists.Visible = false;
        }
        public void SetUpdate()
        {
            Reset();
            //PanSuccess.Visible = true;
        }

        public void SetError()
        {
            Reset();
            //PanError.Visible = true;
        }
        public void InitAdd()
        {
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnReset.Visible = true;
            btnCancel.Visible = false;

        }
        public void InitUpdate()
        {
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            btnCancel.Visible = true;
            btnReset.Visible = false;
        }

        public void Reset()
        {
            txtContFirst.Text = string.Empty;
            txtContLast.Text = string.Empty;
            txtContMobile.Text = string.Empty;
            txtContEmail.Text = string.Empty;
            txtCustFax.Text = string.Empty;
            txtSiteAddress.Text = string.Empty;
            txtArea.Text = string.Empty;
            txtCity.Text = string.Empty;
            ddlState.SelectedIndex = 0;

            ddlZone.SelectedIndex = 0;
            ddlCompanyType.SelectedIndex = 0;
            txtCustRating.Text = string.Empty;
            txtPostCode.Text = string.Empty;
            txtPostalAddress.Text = string.Empty;
            txtPostalArea.Text = string.Empty;
            txtPostalCity.Text = string.Empty;
            ddlPostalState.SelectedIndex = 0;
            txtPostalPostCode.Text = string.Empty;
            txtCustPhone.Text = string.Empty;
            txtCustAltPhone.Text = string.Empty;
            txtCustFax.Text = string.Empty;
            txtCustNotes.Text = string.Empty;
            txtCustWebSiteLink.Text = string.Empty;
            txtCompany.Text = string.Empty;
            chkSameasAbove.Checked = false;
            txtCountry.Enabled = false;
            txtCountry.Text = "India";
            //ddlCustSourceID_SelectedIndexChanged(ddlCustTypeID, new EventArgs());
            ddlCustSourceID.SelectedIndex = 0;
            ddlCustSourceSubID.SelectedIndex = 0;
            ddlProjectType.SelectedIndex = 0;
            rblArea.ClearSelection();
            ddlCustTypeID.SelectedIndex = 0;
            btnUpdate.Visible = false;
            btnAdd.Visible = true;

            //if (Roles.IsUserInRole("Lead Manager"))
            //{
            //    divD2DEmployee.Visible = true;
            //    divD2DAppDate.Visible = true;
            //    divD2DAppTime.Visible = true;
            //    ddlCustSourceID.SelectedValue = "21";
            //}
            //else
            //{
            //    divD2DEmployee.Visible = false;
            //    divD2DAppDate.Visible = false;
            //    divD2DAppTime.Visible = false;
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

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }





        protected void btnCancelAddNewProject_Click(object sender, EventArgs e)
        {
            ResetAddNewProject();
        }

        protected void btnAddProject_Click(object sender, EventArgs e)
        {
            try
            {

                ProjectsEntity ProEntity = new ProjectsEntity();

                ProEntity.CustomerID = Convert.ToInt64(hdnlblCustomerID.Value);
                ProEntity.ContactID = Convert.ToInt64(ddlContact.SelectedValue);

                string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
                EmployeeEntity stEmp = EmployeeManagement.tblEmployees_SelectEmployeeID(userid);

                ProEntity.EmployeeID = stEmp.EmployeeID;

                ProEntity.SalesRep = stEmp.EmployeeID;
                ProEntity.ProjectTypeID = Convert.ToInt32(ddlProjectTypeID.SelectedValue);
                ProEntity.OldProjectNumber = txtOldProjectNumber.Text;
                ProEntity.ManualQuoteNumber = txtManualQuoteNumber.Text;
                ProEntity.ProjectOpened = Convert.ToDateTime(txtProjectOpened.Text);

                CustomersEntity stCust = CustomersManagement.tblCustomers_SelectByCustomerID(ProEntity.CustomerID);
                ProEntity.Project = txtInstallCity.Text + "-" + txtInstallAddress.Text;
                ProEntity.InstallAddress = txtInstallAddress.Text.Trim(); ;
                ProEntity.InstallArea = txtInstallArea.Text.Trim();
                ProEntity.InstallCity = txtInstallCity.Text.Trim(); ;
                ProEntity.InstallState = txtInstallState.Text.Trim(); ;
                ProEntity.InstallPostCode = txtInstallPostCode.Text.Trim(); ;
                ProEntity.ProjectNotes = txtProjectNotes.Text.Trim(); ;
                ProEntity.InstallerNotes = txtInstallerNotes.Text.Trim(); ;
                ProEntity.MeterInstallerNotes = txtMeterInstallerNotes.Text.Trim(); ;

                ProEntity.ProjectMgr = stEmp.EmployeeID;

                ProEntity.CompanyLocationID = stCust.CompanyLocationID;

                ProEntity.ProjectEnteredBy = stEmp.EmployeeID;
                ProEntity.UpdateDate = DateTime.UtcNow;
                ProEntity.UpdateBy = stEmp.EmployeeID;
                ProEntity.ProjectStatusID = 2;


                if (stCust.StreetCity != string.Empty && stCust.StreetState != string.Empty && stCust.StreetPostCode != string.Empty)
                {

                    long success = ProjectsManagement.tblProjects_Insert(ProEntity);
                    ////bool suc = ClstblProjects.tblProjects_UpdateProjectNumber(Convert.ToString(success));
                    // int sucProject2 = ClstblProjects.tblProjects_InserttblProjects2(Convert.ToString(success), EmployeeID);
                    CustomersManagement.tblCustomers_UpdateCustType(4, ProEntity.CustomerID);

                    try
                    {
                        var stRef = ReferralManagement.tblReferral_SelectByReferralID(ProEntity.CustomerID, "0", "");

                        if (!String.IsNullOrEmpty(stRef.ReferredByCustomerName) || !String.IsNullOrEmpty(stRef.ReferredByProjectNo) || !String.IsNullOrEmpty(stRef.ReferralNotes))
                        {
                            ReferralEntity obj = new ReferralEntity();
                            obj.CustomerID = stRef.CustomerID;
                            obj.ContactID = stRef.ContactID;
                            obj.EmployeeID = stRef.EmployeeID;
                            obj.ReferralDate = stRef.ReferralDate;
                            obj.ReferredByProjectNo = stRef.ReferredByProjectNo;
                            obj.ReferredByCustomerName = stRef.ReferredByCustomerName;
                            obj.ReferredByProjectStatus = stRef.ReferredByProjectStatus;
                            obj.ReferralNotes = stRef.ReferralNotes;
                            obj.ReferredProjectNo = success;
                            obj.ReferredProjectStatus = 2;
                            obj.ReferredCustomerName = stCust.Customer;

                            obj.ReferredSystemSize = 0;
                            obj.ReferredBalOS = 0;
                            obj.ReferredByBalOS = stRef.ReferredByBalOS;
                            obj.ReferralPaidDate = DateTime.UtcNow;
                            obj.ReferralAmount = 0;
                            obj.PayMethodID = 0;
                            obj.PayReference = "";
                            obj.id = 1;
                            obj.ReferralID = stRef.ReferralID;
                            obj.IsRefPaid = false;

                            ReferralManagement.tblReferral_UpdateByCompany(obj);
                        }
                    }
                    catch { }


                    if (ddlProjectTypeID.SelectedValue == "1")
                    {
                        ProjectsManagement.tblProjects_UpdateFormsSolar(success);
                    }
                    if (ddlProjectTypeID.SelectedValue == "2")
                    {
                        ProjectsManagement.tblProjects_UpdateFormsSolarUG(success);
                    }

                    long EmpID = stEmp.EmployeeID;
                    int NumberPanels = 0;

                    ProjectsManagement.tblTrackProjStatus_Insert(ProEntity.ProjectStatusID, success, EmpID, NumberPanels);


                    //--- do not chage this code start------
                    if (Convert.ToString(success) != "")
                    {
                        CustomersManagement.tblContacts_UpdateContLeadStatus(5, Convert.ToInt64(ddlContact.SelectedValue));

                        divSuccess.Visible = true;
                        divAlert.Visible = false;
                        lblSuccessMsg.Text = "Project Added Successfully";
                        ResetAddNewProject();

                        BindProjectsList(Convert.ToInt64(hdnlblCustomerID.Value));
                     //   BindAddNewProjectDetails(Convert.ToInt64(hdnlblCustomerID.Value));

                    }
                    else
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Project Added Failed";
                    }

                }
                else
                {
                    divSuccess.Visible = false;
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "Please Enter Customer Address.";
                }
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }


        public void BindAddNewProjectDetails(long CustomerID)
        {
            tabaddproject.Attributes.Remove("class");
            tabaddproject.Attributes.Add("class", "tab-pane active");
            liaddproject.Attributes.Add("class", "active");

            tabaddcompany.Attributes.Remove("class");
            tabaddcompany.Attributes.Add("class", "tab-pane");
            liaddcompany.Attributes.Remove("class");

            var lstEntity = CustomersManagement.tblCustomers_SelectByCustomerID(CustomerID);


            txtInstallAddress.Text = lstEntity.StreetAddress;

            txtInstallArea.Text = lstEntity.StreetArea;

            txtInstallCity.Text = lstEntity.StreetCity;

            txtInstallState.Text = lstEntity.StreetState;

            txtInstallPostCode.Text = lstEntity.StreetPostCode;

            txtProjectOpened.Text = DateTime.Now.AddHours(0).ToShortDateString();

            string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
            EmployeeEntity stEmp = EmployeeManagement.tblEmployees_SelectEmployeeID(userid);
            txtSalesRep.Text = stEmp.EmpFirst + " " + stEmp.EmpLast;


            ddlContact.DataSource = CustomersManagement.tblContacts_SelectByCustomerID(CustomerID);
            ddlContact.DataValueField = "ContactID";
            ddlContact.DataTextField = "FullName";
            ddlContact.DataMember = "FullName";
            ddlContact.DataBind();
            // ddlContact.SelectedValue = Convert.ToString(cons.contact) ;

            ddlProjectTypeID.DataSource = ProjectTypeManagement.tblProjectType_SelectActive();
            ddlProjectTypeID.DataValueField = "ProjectTypeID";
            ddlProjectTypeID.DataTextField = "ProjectType";
            ddlProjectTypeID.DataMember = "ProjectType";
            ddlProjectTypeID.DataBind();
            ddlProjectTypeID.SelectedValue = Convert.ToString(lstEntity.ProjectTypeID);
        }


        public void ResetAddNewProject()
        {
            ddlProjectTypeID.SelectedIndex = 0;
            ddlContact.SelectedIndex = 0;
            txtOldProjectNumber.Text = "";
            txtManualQuoteNumber.Text = "";
            txtProjectNotes.Text = "";
            txtInstallerNotes.Text = "";
            txtMeterInstallerNotes.Text = "";
        }
        public void BindProjectsList(long CustomerID)
        {
            try
            {
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo1"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize1"]);
                int Count = 0;
                List<ProjectsEntity> lstEntity = new List<ProjectsEntity>();
                lstEntity = ProjectsManagement.tblProjects_SelectByCustomerID(objCommon, CustomerID, out Count);
                rptCompanyProjectsList.DataSource = lstEntity;
                rptCompanyProjectsList.DataBind();
                pageGrid1.BindPageing(Count);

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void rptCompanyProjectsList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToString() == "Detail")
                {
                    Response.Redirect(SiteURL + "/admin/project/projectlist.aspx?projectid=" + Encryption.Encrypt(e.CommandArgument.ToString()));
                }
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }
        protected void Pager_Changed1(object sender, PagerEventArgs e)
        {
            BindProjectsList(Convert.ToInt64(hdnlblCustomerID.Value));
        }


        //[System.Web.Services.WebMethod(EnableSession = true)]
        //public static string GetCitiesList(string prefixText, int count, string ContextKey)
        //{
        //    //List<Entity.AppointmentMaster> lstCal = new List<Entity.AppointmentMaster>();
        //    //lstCal = GetAppointment();
        //    //return lstCal;
        //    string a = "123";
        //    return a;
        //}

        //public static string GetAppointment()
        //{
        //    return "123";
        //    // return BAL.AppointmentMgmt.AppointmentMaster_SelectForAdminCalender(Convert.ToInt64(HttpContext.Current.Session["AGroupID"]));
        //}
    }
}
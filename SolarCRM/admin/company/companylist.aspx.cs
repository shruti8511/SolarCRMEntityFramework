using SolarCRM.BAL.Implementations.CompanyModule;
using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.BAL.Implementations.ProjectModule;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.CompanyModule;
using SolarCRM.Entity.Models.EmployeeModule;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.ProjectModule;
using SolarCRM.PagingUserControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolarCRM.admin.company
{
    public partial class companylist : System.Web.UI.Page
    {
        protected string SiteURL;
        long CustomerID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;
            //cmpNextDate.ValueToCompare = DateTime.Now.ToShortDateString();
            if (!IsPostBack)
            {
                Session["PageNo"] = 1;
                Session["PageSize"] = 10;
                Session["PageNo1"] = 1;
                Session["PageSize1"] = 10;
                BindCompanyList();
                BindProjectList();
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
                    //var lstEntity = ZoneManagement.tblZone_ForEdit(Convert.ToInt32(e.CommandArgument));

                    //hdnZoneID.Value = lstEntity.ZoneID.ToString();
                    //txtZone.Text = lstEntity.Zone;
                    //chkActive.Checked = lstEntity.Active;
                    //btnSave.Visible = false;
                    //btnUpdate.Visible = true;
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
                try
                {
                    divcompanydetails.Visible = true;
                    divcompanylist.Visible = false;
                    long CustomerID = Convert.ToInt64(e.CommandArgument);
                    BindSummary(CustomerID);

                    BindContactList(CustomerID);

                    BindAddNewProjectDetails(CustomerID);

                    BindProjectsList(CustomerID);

                    BindFollowUps(CustomerID);

                    ddlContacts.DataSource = CustomersManagement.tblContacts_SelectByCustomerID(CustomerID);
                    ddlContacts.DataValueField = "ContactID";
                    ddlContacts.DataTextField = "FullName";
                    ddlContacts.DataMember = "FullName";
                    ddlContacts.DataBind();

                }
                catch (Exception ex)
                {
                    divSuccess.Visible = false;
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "Error : " + ex.Message;
                }
            }
        }

        public void BindSummary(long CustomerID)
        {
            var lstEntity = CustomersManagement.tblCustomers_SelectByCustomerID(CustomerID);
            hdnlblCustomerID.Value = lstEntity.CustomerID.ToString();
            hdnlblEmployeeID.Value = lstEntity.EmployeeID.ToString();

            lblCustomer.Text = lstEntity.Customer;
            lblCompanyNumber.Text = lstEntity.CompanyNumber.ToString();
            lblFullName.Text = lstEntity.FullName;
            lblMobile.Text = lstEntity.CustMobile;
            lblEmail.Text = lstEntity.CustEmail;
            lblPhone.Text = "-";
            if (lstEntity.CustPhone != "")
            {
                lblPhone.Text = lstEntity.CustPhone;
            }
            lblAltPhone.Text = "-";
            if (lstEntity.CustAltPhone != "")
            {
                lblAltPhone.Text = lstEntity.CustAltPhone;
            }
            lblType.Text = lstEntity.CustType;
            lblSource.Text = lstEntity.CustSource;
            lblSubSource.Text = lstEntity.CustSourceSub;
            if (lstEntity.CustSourceSub != "")
            {
                trSubSource.Visible = true;
                lblSubSource.Text = lstEntity.CustSourceSub;
            }
            else
            {
                trSubSource.Visible = false;
            }
            lblProjectType.Text = lstEntity.ProjectType;
            lblNotes.Text = "-";
            if (lstEntity.CustNotes != "")
            {
                lblNotes.Text = lstEntity.CustNotes;
            }
            lblAssignTo.Text = lstEntity.AssignedTo;
            lblCompanyType.Text = lstEntity.CompanyTypeName;

            lblStreetAddress.Text = lstEntity.StreetAddress;
            lblStreetArea.Text = lstEntity.StreetArea;
            lblStreetCity.Text = lstEntity.StreetCity;
            lblStreetState.Text = lstEntity.StreetState;
            lblStreetPostCode.Text = lstEntity.StreetPostCode;


            lblPostalAddress.Text = "-";
            if (lstEntity.PostalAddress != "")
            {
                lblPostalAddress.Text = lstEntity.PostalAddress;
            }
            lblPostalArea.Text = "-";
            if (lstEntity.PostalAddress != "")
            {
                lblPostalArea.Text = lstEntity.PostalArea;
            }
            lblPostalCity.Text = "-";
            if (lstEntity.PostalCity != "")
            {
                lblPostalCity.Text = lstEntity.PostalCity;
            }
            lblPostalState.Text = "-";
            if (lstEntity.PostalState != "")
            {
                lblPostalState.Text = lstEntity.PostalState;
            }
            lblPostalPostCode.Text = "-";
            if (lstEntity.PostalPostCode != "")
            {
                lblPostalPostCode.Text = lstEntity.PostalPostCode;
            }
            lblCountry.Text = "-";
            if (lstEntity.Country != "")
            {
                lblCountry.Text = lstEntity.Country;
            }
            lblWebsite.Text = "-";
            if (lstEntity.CustWebSite != "")
            {
                lblWebsite.Text = lstEntity.CustWebSite;
            }

            lblArea.Text = lstEntity.AreaName;
            lblFax.Text = "-";
            if (lstEntity.CustFax != "")
            {
                lblFax.Text = lstEntity.CustFax;
            }
            lblCustRating.Text = "-";
            if (lstEntity.CustRating != "")
            {
                lblCustRating.Text = lstEntity.CustRating;
            }
        }

        public void BindContactList(long CustomerID)
        {
            try
            {
                List<ContactsEntity> lstEntity = new List<ContactsEntity>();
                lstEntity = CustomersManagement.tblContacts_SelectByCustomerID(CustomerID);
                rptContactList.DataSource = lstEntity;
                rptContactList.DataBind();
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

        public void BindFollowUps(long CustomerID)
        {
            try
            {
                List<CustInfoEntity> lstEntity = new List<CustInfoEntity>();
                lstEntity = CustInfoManagement.tblCustInfo_SelectByCustomerID(CustomerID);
                rptFollowUpList.DataSource = lstEntity;
                rptFollowUpList.DataBind();
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void rptCompanylist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            //DropDownList ddlCustTypeID = (DropDownList)e.Item.FindControl("ddlCustTypeID");
            //System.Web.UI.WebControls.ListItem item1 = new System.Web.UI.WebControls.ListItem();
            //item1.Text = "Select";
            //item1.Value = "";
            //ddlCustTypeID.Items.Clear();
            //ddlCustTypeID.Items.Add(item1);

            //ddlCustTypeID.DataSource = CustomerTypeManagement.tblCustType_SelectActive();
            //ddlCustTypeID.DataValueField = "CustTypeID";
            //ddlCustTypeID.DataTextField = "CustType";
            //ddlCustTypeID.DataMember = "CustType";
            //ddlCustTypeID.DataBind();

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnCustTypeID = (HiddenField)e.Item.FindControl("hdnCustTypeID");
                ((DropDownList)e.Item.FindControl("ddlCustTypeID")).DataSource = CustomerTypeManagement.tblCustType_SelectActive();//Or any other datasource.
                ((DropDownList)e.Item.FindControl("ddlCustTypeID")).DataMember = "CustType";
                ((DropDownList)e.Item.FindControl("ddlCustTypeID")).DataTextField = "CustType";
                ((DropDownList)e.Item.FindControl("ddlCustTypeID")).DataValueField = "CustTypeID";
                ((DropDownList)e.Item.FindControl("ddlCustTypeID")).DataBind();
                ((DropDownList)e.Item.FindControl("ddlCustTypeID")).SelectedValue = hdnCustTypeID.Value;

            }

        }

        protected void ddlCustTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenField hdnCustomerID = ((Control)sender).Parent.FindControl("hdnCustomerID") as HiddenField;
            int CustomerID = Convert.ToInt32(hdnCustomerID.Value);
            DropDownList ddlCustTypeID = sender as DropDownList;
            int CustTypeID =Convert.ToInt32(ddlCustTypeID.SelectedValue);
            CustomersManagement.tblCustomers_UpdateCustTypeID(CustomerID,CustTypeID);
            divSuccess.Visible = true;
            divAlert.Visible = false;
            lblSuccessMsg.Text = "Lead Status Updated Successfully";
           // ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
           // Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", "function HideLabel(){ setTimeout(function() {document.getlementById('" + divAlert.ClientID + "').style.display='none';},5000);};", true);
        }


        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindCompanyList();
          
        }

        protected void Pager_Changed1(object sender, PagerEventArgs e)
        {
            BindProjectsList(Convert.ToInt64(hdnlblCustomerID.Value));
        }

        protected void btnalert_Click(object sender, EventArgs e)
        {
            divAlert.Visible = false;
        }


        protected void btnSuccess_Click(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
        }

        protected void lnkbacktolist_Click(object sender, EventArgs e)
        {
            tab_summary.Attributes.Remove("class");
            tab_summary.Attributes.Add("class", "tab-pane active");
            lisummary.Attributes.Add("class", "active");

            tab_contact.Attributes.Remove("class");
            tab_contact.Attributes.Add("class", "tab-pane");
            licontact.Attributes.Remove("class");

            tab_project.Attributes.Remove("class");
            tab_project.Attributes.Add("class", "tab-pane");
            liproject.Attributes.Remove("class");

            tab_followup.Attributes.Remove("class");
            tab_followup.Attributes.Add("class", "tab-pane");
            lifollowup.Attributes.Remove("class");


            tab_detail.Attributes.Remove("class");
            tab_detail.Attributes.Add("class", "tab-pane active");
            lidetail.Attributes.Add("class", "active");

            tab_notes.Attributes.Remove("class");
            tab_notes.Attributes.Add("class", "tab-pane");
            linotes.Attributes.Remove("class");

            tab_promo.Attributes.Remove("class");
            tab_promo.Attributes.Add("class", "tab-pane");
            lipromo.Attributes.Remove("class");

            tab_info.Attributes.Remove("class");
            tab_info.Attributes.Add("class", "tab-pane");
            liinfo.Attributes.Remove("class");

            divcompanylist.Visible = true;
            divcompanydetails.Visible = false;
        }

        protected void lnkAddContact_Click(object sender, EventArgs e)
        {
            divaddcontact.Visible = true;
            divcontactlist.Visible = false;
            divContactDetails.Visible = false;

            tab_contact.Attributes.Remove("class");
            tab_contact.Attributes.Add("class", "tab-pane active");
            licontact.Attributes.Add("class", "active");

            tab_summary.Attributes.Remove("class");
            tab_summary.Attributes.Add("class", "tab-pane");
            lisummary.Attributes.Remove("class");

            tab_project.Attributes.Remove("class");
            tab_project.Attributes.Add("class", "tab-pane");
            liproject.Attributes.Remove("class");

            tab_followup.Attributes.Remove("class");
            tab_followup.Attributes.Add("class", "tab-pane");
            lifollowup.Attributes.Remove("class");


            tab_detail.Attributes.Remove("class");
            tab_detail.Attributes.Add("class", "tab-pane active");
            lidetail.Attributes.Add("class", "active");

            tab_notes.Attributes.Remove("class");
            tab_notes.Attributes.Add("class", "tab-pane");
            linotes.Attributes.Remove("class");

            tab_promo.Attributes.Remove("class");
            tab_promo.Attributes.Add("class", "tab-pane");
            lipromo.Attributes.Remove("class");

            tab_info.Attributes.Remove("class");
            tab_info.Attributes.Add("class", "tab-pane");
            liinfo.Attributes.Remove("class");
        }

        protected void lnkbacktocontactlist_Click(object sender, EventArgs e)
        {
            divaddcontact.Visible = false;
            divcontactlist.Visible = true;
            divContactDetails.Visible = false;

            tab_contact.Attributes.Remove("class");
            tab_contact.Attributes.Add("class", "tab-pane active");
            licontact.Attributes.Add("class", "active");

            tab_summary.Attributes.Remove("class");
            tab_summary.Attributes.Add("class", "tab-pane");
            lisummary.Attributes.Remove("class");

            tab_project.Attributes.Remove("class");
            tab_project.Attributes.Add("class", "tab-pane");
            liproject.Attributes.Remove("class");

            tab_followup.Attributes.Remove("class");
            tab_followup.Attributes.Add("class", "tab-pane");
            lifollowup.Attributes.Remove("class");


            tab_detail.Attributes.Remove("class");
            tab_detail.Attributes.Add("class", "tab-pane active");
            lidetail.Attributes.Add("class", "active");

            tab_notes.Attributes.Remove("class");
            tab_notes.Attributes.Add("class", "tab-pane");
            linotes.Attributes.Remove("class");

            tab_promo.Attributes.Remove("class");
            tab_promo.Attributes.Add("class", "tab-pane");
            lipromo.Attributes.Remove("class");

            tab_info.Attributes.Remove("class");
            tab_info.Attributes.Add("class", "tab-pane");
            liinfo.Attributes.Remove("class");
        }

        protected void btnAddContact_Click(object sender, EventArgs e)
        {
            try
            {
                string userid = Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString();
                EmployeeEntity st = EmployeeManagement.tblEmployees_SelectEmployeeID(userid);

                long sucContacts = CustomersManagement.tblCustomers_InsertContacts(Convert.ToInt64(hdnlblCustomerID.Value), ddlSalutation.SelectedValue, txtContFirst.Text.Trim(), txtContLast.Text.Trim(), txtContMobile.Text, txtContEmail.Text, st.EmployeeID, st.EmployeeID);

                BindContactList(Convert.ToInt64(hdnlblCustomerID.Value));

                divaddcontact.Visible = false;
                divcontactlist.Visible = true;
                divContactDetails.Visible = false;

                divSuccess.Visible = true;
                divAlert.Visible = false;
                lblSuccessMsg.Text = "Contact Added Successfully";

                tab_contact.Attributes.Remove("class");
                tab_contact.Attributes.Add("class", "tab-pane active");
                licontact.Attributes.Add("class", "active");

                tab_summary.Attributes.Remove("class");
                tab_summary.Attributes.Add("class", "tab-pane");
                lisummary.Attributes.Remove("class");

                tab_project.Attributes.Remove("class");
                tab_project.Attributes.Add("class", "tab-pane");
                liproject.Attributes.Remove("class");

                tab_followup.Attributes.Remove("class");
                tab_followup.Attributes.Add("class", "tab-pane");
                lifollowup.Attributes.Remove("class");
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void rptContactList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Detail")
            {
                try
                {
                    divContactDetails.Visible = true;
                    divcontactlist.Visible = true;
                    divaddcontact.Visible = false;

                    long ContactID = Convert.ToInt64(e.CommandArgument);
                    BindDetail(ContactID);
                    BindContactNotes();
                    BindContactInfo();

                    tab_contact.Attributes.Remove("class");
                    tab_contact.Attributes.Add("class", "tab-pane active");
                    licontact.Attributes.Add("class", "active");

                    tab_summary.Attributes.Remove("class");
                    tab_summary.Attributes.Add("class", "tab-pane");
                    lisummary.Attributes.Remove("class");

                    tab_project.Attributes.Remove("class");
                    tab_project.Attributes.Add("class", "tab-pane");
                    liproject.Attributes.Remove("class");

                    tab_followup.Attributes.Remove("class");
                    tab_followup.Attributes.Add("class", "tab-pane");
                    lifollowup.Attributes.Remove("class");


                }
                catch (Exception ex)
                {
                    divSuccess.Visible = false;
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "Error : " + ex.Message;
                }
            }
        }

        public void BindDetail(long ContactID)
        {
            try
            {
                ddlContLeadStatusID.DataSource = CustomersManagement.tblContLeadStatus_SelectActive();
                ddlContLeadStatusID.DataMember = "ContLeadStatus";
                ddlContLeadStatusID.DataTextField = "ContLeadStatus";
                ddlContLeadStatusID.DataValueField = "ContLeadStatusID";
                ddlContLeadStatusID.DataBind();

                ddlCancel.DataSource = CustomersManagement.tblContLeadCancelReason_SelectActive();
                ddlCancel.DataValueField = "ContLeadCancelReasonID";
                ddlCancel.DataTextField = "ContLeadCancelReason";
                ddlCancel.DataMember = "ContLeadCancelReason";
                ddlCancel.DataBind();


                var lstEntity = CustomersManagement.tblContacts_SelectByContactID(ContactID);

                var lstcust = CustomersManagement.tblCustomers_SelectByCustomerID(lstEntity.CustomerID);

                txtSite.Text = lstcust.Customer;

                hdnContactID.Value = lstEntity.ContactID.ToString();

                lblContactDetails.Text = lstEntity.ContMr + " " + lstEntity.ContFirst + " " + lstEntity.ContLast;

                ddlsalu.SelectedValue = lstEntity.ContMr;
                txtFname.Text = lstEntity.ContFirst;
                txtLname.Text = lstEntity.ContLast;
                txtEmail.Text = lstEntity.ContEmail;
                txtMobile.Text = lstEntity.ContMobile;
                txtPhone.Text = lstEntity.ContPhone;
                txtHomePhone.Text = lstEntity.ContHomePhone;
                txtFax.Text = lstEntity.ContFax;

                txtSiteAddress.Text = lstEntity.StreetAddress;
                txtSteet.Text = lstEntity.StreetArea;
                txtCity.Text = lstEntity.StreetCity;
                txtState.Text = lstEntity.StreetState;
                txtPinCode.Text = lstEntity.StreetPostCode;
                //  ddlSalesRep.SelectedValue = lstEntity.EmployeeID.ToString();

                ddlContLeadStatusID.SelectedValue = lstEntity.ContLeadStatusID.ToString();
                if (ddlContLeadStatusID.SelectedValue == "4")
                {
                    divcancelleadstatus.Visible = true;
                }
                else
                {
                    divcancelleadstatus.Visible = false;
                }

                chksendemail.Checked = lstEntity.SendEmail;
                chksendsms.Checked = lstEntity.SendSMS;
                chksalesactive.Checked = lstEntity.ActiveTag;

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }

        }

        protected void ddlContLeadStatusID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlContLeadStatusID.SelectedValue == "4")
            {
                divcancelleadstatus.Visible = true;
            }
            else
            {
                divcancelleadstatus.Visible = false;
            }

            tab_contact.Attributes.Remove("class");
            tab_contact.Attributes.Add("class", "tab-pane active");
            licontact.Attributes.Add("class", "active");

            tab_summary.Attributes.Remove("class");
            tab_summary.Attributes.Add("class", "tab-pane");
            lisummary.Attributes.Remove("class");

            tab_project.Attributes.Remove("class");
            tab_project.Attributes.Add("class", "tab-pane");
            liproject.Attributes.Remove("class");

            tab_followup.Attributes.Remove("class");
            tab_followup.Attributes.Add("class", "tab-pane");
            lifollowup.Attributes.Remove("class");
        }

        protected void btnUpdateContact_Click(object sender, EventArgs e)
        {
            try
            {
                ContactsEntity objentity = new ContactsEntity();

                objentity.ContactID = Convert.ToInt64(hdnContactID.Value);
                objentity.EmployeeID = Convert.ToInt64(ddlSalesRep.SelectedValue);
                objentity.ContLeadStatusID = Convert.ToInt32(ddlContLeadStatusID.SelectedValue);
                if (objentity.ContLeadStatusID == 4)
                {
                    objentity.ContLeadCancelReasonID = Convert.ToInt32(ddlCancel.SelectedValue);
                }
                else
                {
                    objentity.ContLeadCancelReasonID = 0;
                }

                objentity.ActiveTag = chksalesactive.Checked;
                objentity.SendEmail = chksendemail.Checked;
                objentity.SendSMS = chksendsms.Checked;
                objentity.ContMr = ddlsalu.SelectedItem.Text;
                objentity.ContFirst = txtFname.Text.Trim();
                objentity.ContLast = txtLname.Text.Trim();
                objentity.ContEmail = txtEmail.Text;
                objentity.ContMobile = txtMobile.Text;
                objentity.ContPhone = txtPhone.Text;
                objentity.ContHomePhone = txtHomePhone.Text;
                objentity.ContFax = txtFax.Text;

                CustomersManagement.tblContacts_UpdateDetail(objentity);

                tab_contact.Attributes.Remove("class");
                tab_contact.Attributes.Add("class", "tab-pane active");
                licontact.Attributes.Add("class", "active");

                tab_summary.Attributes.Remove("class");
                tab_summary.Attributes.Add("class", "tab-pane");
                lisummary.Attributes.Remove("class");

                tab_project.Attributes.Remove("class");
                tab_project.Attributes.Add("class", "tab-pane");
                liproject.Attributes.Remove("class");

                tab_followup.Attributes.Remove("class");
                tab_followup.Attributes.Add("class", "tab-pane");
                lifollowup.Attributes.Remove("class");
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void btnCancelContact_Click(object sender, EventArgs e)
        {
            try
            {
                long ContactID = Convert.ToInt64(hdnContactID.Value);

                BindDetail(ContactID);

                tab_contact.Attributes.Remove("class");
                tab_contact.Attributes.Add("class", "tab-pane active");
                licontact.Attributes.Add("class", "active");

                tab_summary.Attributes.Remove("class");
                tab_summary.Attributes.Add("class", "tab-pane");
                lisummary.Attributes.Remove("class");

                tab_project.Attributes.Remove("class");
                tab_project.Attributes.Add("class", "tab-pane");
                liproject.Attributes.Remove("class");

                tab_followup.Attributes.Remove("class");
                tab_followup.Attributes.Add("class", "tab-pane");
                lifollowup.Attributes.Remove("class");
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }



        protected void lnkAddNotes_Click(object sender, EventArgs e)
        {
            divAddNotes.Visible = true;
            divNotesList.Visible = false;

            tab_contact.Attributes.Remove("class");
            tab_contact.Attributes.Add("class", "tab-pane active");
            licontact.Attributes.Add("class", "active");

            tab_summary.Attributes.Remove("class");
            tab_summary.Attributes.Add("class", "tab-pane");
            lisummary.Attributes.Remove("class");

            tab_project.Attributes.Remove("class");
            tab_project.Attributes.Add("class", "tab-pane");
            liproject.Attributes.Remove("class");

            tab_followup.Attributes.Remove("class");
            tab_followup.Attributes.Add("class", "tab-pane");
            lifollowup.Attributes.Remove("class");

            tab_notes.Attributes.Remove("class");
            tab_notes.Attributes.Add("class", "tab-pane active");
            linotes.Attributes.Add("class", "active");

            tab_detail.Attributes.Remove("class");
            tab_detail.Attributes.Add("class", "tab-pane");
            lidetail.Attributes.Remove("class");

            tab_promo.Attributes.Remove("class");
            tab_promo.Attributes.Add("class", "tab-pane");
            lipromo.Attributes.Remove("class");

            tab_info.Attributes.Remove("class");
            tab_info.Attributes.Add("class", "tab-pane");
            liinfo.Attributes.Remove("class");
        }

        protected void lnkbacktoNoteslist_Click(object sender, EventArgs e)
        {
            divAddNotes.Visible = false;
            divNotesList.Visible = true;

            tab_contact.Attributes.Remove("class");
            tab_contact.Attributes.Add("class", "tab-pane active");
            licontact.Attributes.Add("class", "active");

            tab_summary.Attributes.Remove("class");
            tab_summary.Attributes.Add("class", "tab-pane");
            lisummary.Attributes.Remove("class");

            tab_project.Attributes.Remove("class");
            tab_project.Attributes.Add("class", "tab-pane");
            liproject.Attributes.Remove("class");

            tab_followup.Attributes.Remove("class");
            tab_followup.Attributes.Add("class", "tab-pane");
            lifollowup.Attributes.Remove("class");


            tab_notes.Attributes.Remove("class");
            tab_notes.Attributes.Add("class", "tab-pane active");
            linotes.Attributes.Add("class", "active");

            tab_detail.Attributes.Remove("class");
            tab_detail.Attributes.Add("class", "tab-pane");
            lidetail.Attributes.Remove("class");

            tab_promo.Attributes.Remove("class");
            tab_promo.Attributes.Add("class", "tab-pane");
            lipromo.Attributes.Remove("class");

            tab_info.Attributes.Remove("class");
            tab_info.Attributes.Add("class", "tab-pane");
            liinfo.Attributes.Remove("class");

        }

        public void BindContactNotes()
        {
            try
            {
                List<ContactNotesEntity> lstEntity = new List<ContactNotesEntity>();
                lstEntity = CustomersManagement.tblContNotes_SelectByContactID(Convert.ToInt64(hdnContactID.Value));
                rptNotesList.DataSource = lstEntity;
                rptNotesList.DataBind();
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void btnAddContactNotes_Click(object sender, EventArgs e)
        {
            try
            {
                string userid = Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString();
                EmployeeEntity st = EmployeeManagement.tblEmployees_SelectEmployeeID(userid);

                ContactNotesEntity ObjEntity = new ContactNotesEntity();
                ObjEntity.ContactID = Convert.ToInt64(hdnContactID.Value);
                ObjEntity.EmployeeID = Convert.ToInt64(hdnlblEmployeeID.Value);
                ObjEntity.NoteSetBy = st.EmployeeID;
                ObjEntity.ContNoteDate = DateTime.UtcNow;
                ObjEntity.ContNote = txtContactNotes.Text.Trim();

                CustomersManagement.tblContNotes_Insert(ObjEntity);

                BindContactNotes();
                txtContactNotes.Text = "";
                divAddNotes.Visible = false;
                divNotesList.Visible = true;

                tab_contact.Attributes.Remove("class");
                tab_contact.Attributes.Add("class", "tab-pane active");
                licontact.Attributes.Add("class", "active");

                tab_summary.Attributes.Remove("class");
                tab_summary.Attributes.Add("class", "tab-pane");
                lisummary.Attributes.Remove("class");

                tab_project.Attributes.Remove("class");
                tab_project.Attributes.Add("class", "tab-pane");
                liproject.Attributes.Remove("class");

                tab_followup.Attributes.Remove("class");
                tab_followup.Attributes.Add("class", "tab-pane");
                lifollowup.Attributes.Remove("class");


                tab_notes.Attributes.Remove("class");
                tab_notes.Attributes.Add("class", "tab-pane active");
                linotes.Attributes.Add("class", "active");

                tab_detail.Attributes.Remove("class");
                tab_detail.Attributes.Add("class", "tab-pane");
                lidetail.Attributes.Remove("class");

                tab_promo.Attributes.Remove("class");
                tab_promo.Attributes.Add("class", "tab-pane");
                lipromo.Attributes.Remove("class");

                tab_info.Attributes.Remove("class");
                tab_info.Attributes.Add("class", "tab-pane");
                liinfo.Attributes.Remove("class");
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void btnCancelContactNotes_Click(object sender, EventArgs e)
        {
            txtContactNotes.Text = "";

            divAddNotes.Visible = false;
            divNotesList.Visible = true;

            tab_contact.Attributes.Remove("class");
            tab_contact.Attributes.Add("class", "tab-pane active");
            licontact.Attributes.Add("class", "active");

            tab_summary.Attributes.Remove("class");
            tab_summary.Attributes.Add("class", "tab-pane");
            lisummary.Attributes.Remove("class");

            tab_project.Attributes.Remove("class");
            tab_project.Attributes.Add("class", "tab-pane");
            liproject.Attributes.Remove("class");

            tab_followup.Attributes.Remove("class");
            tab_followup.Attributes.Add("class", "tab-pane");
            lifollowup.Attributes.Remove("class");


            tab_notes.Attributes.Remove("class");
            tab_notes.Attributes.Add("class", "tab-pane active");
            linotes.Attributes.Add("class", "active");

            tab_detail.Attributes.Remove("class");
            tab_detail.Attributes.Add("class", "tab-pane");
            lidetail.Attributes.Remove("class");

            tab_promo.Attributes.Remove("class");
            tab_promo.Attributes.Add("class", "tab-pane");
            lipromo.Attributes.Remove("class");

            tab_info.Attributes.Remove("class");
            tab_info.Attributes.Add("class", "tab-pane");
            liinfo.Attributes.Remove("class");

        }

        public void BindContactInfo()
        {
            try
            {
                ContactsEntity lstEntity = new ContactsEntity();
                lstEntity = CustomersManagement.tblContacts_SelectByContactID(Convert.ToInt64(hdnContactID.Value));

                txtContactEntered.Text = lstEntity.ContactEntered.ToString("dd MMM, yyyy");
                EmployeeEntity stEmp = EmployeeManagement.tblEmployees_SelectBYEmployeeID(lstEntity.ContactEnteredBy);
                txtContactEnteredBy.Text = stEmp.EmpFirst + ' ' + stEmp.EmpLast;
                txtContactID.Text = hdnContactID.Value;

                //txtRefBSB.Text = lstEntity.RefBSB;
                //txtRefAccount.Text = lstEntity.RefAccount;
                //txtContNotes.Text = lstEntity.ContNotes;
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void btnAddInfo_Click(object sender, EventArgs e)
        {
            try
            {


                tab_contact.Attributes.Remove("class");
                tab_contact.Attributes.Add("class", "tab-pane active");
                licontact.Attributes.Add("class", "active");

                tab_summary.Attributes.Remove("class");
                tab_summary.Attributes.Add("class", "tab-pane");
                lisummary.Attributes.Remove("class");

                tab_project.Attributes.Remove("class");
                tab_project.Attributes.Add("class", "tab-pane");
                liproject.Attributes.Remove("class");

                tab_followup.Attributes.Remove("class");
                tab_followup.Attributes.Add("class", "tab-pane");
                lifollowup.Attributes.Remove("class");


                tab_info.Attributes.Remove("class");
                tab_info.Attributes.Add("class", "tab-pane active");
                liinfo.Attributes.Add("class", "active");

                tab_detail.Attributes.Remove("class");
                tab_detail.Attributes.Add("class", "tab-pane");
                lidetail.Attributes.Remove("class");

                tab_promo.Attributes.Remove("class");
                tab_promo.Attributes.Add("class", "tab-pane");
                lipromo.Attributes.Remove("class");

                tab_notes.Attributes.Remove("class");
                tab_notes.Attributes.Add("class", "tab-pane");
                linotes.Attributes.Remove("class");

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void btnCancelInfo_Click(object sender, EventArgs e)
        {
            BindContactInfo();

            tab_contact.Attributes.Remove("class");
            tab_contact.Attributes.Add("class", "tab-pane active");
            licontact.Attributes.Add("class", "active");

            tab_summary.Attributes.Remove("class");
            tab_summary.Attributes.Add("class", "tab-pane");
            lisummary.Attributes.Remove("class");

            tab_project.Attributes.Remove("class");
            tab_project.Attributes.Add("class", "tab-pane");
            liproject.Attributes.Remove("class");

            tab_followup.Attributes.Remove("class");
            tab_followup.Attributes.Add("class", "tab-pane");
            lifollowup.Attributes.Remove("class");


            tab_info.Attributes.Remove("class");
            tab_info.Attributes.Add("class", "tab-pane active");
            liinfo.Attributes.Add("class", "active");

            tab_detail.Attributes.Remove("class");
            tab_detail.Attributes.Add("class", "tab-pane");
            lidetail.Attributes.Remove("class");

            tab_promo.Attributes.Remove("class");
            tab_promo.Attributes.Add("class", "tab-pane");
            lipromo.Attributes.Remove("class");

            tab_notes.Attributes.Remove("class");
            tab_notes.Attributes.Add("class", "tab-pane");
            linotes.Attributes.Remove("class");
        }


        protected void btnAddNewProject_Click(object sender, EventArgs e)
        {
            DivAddNewProject.Visible = true;

            tab_project.Attributes.Remove("class");
            tab_project.Attributes.Add("class", "tab-pane active");
            liproject.Attributes.Add("class", "active");

            tab_summary.Attributes.Remove("class");
            tab_summary.Attributes.Add("class", "tab-pane");
            lisummary.Attributes.Remove("class");

            tab_contact.Attributes.Remove("class");
            tab_contact.Attributes.Add("class", "tab-pane");
            licontact.Attributes.Remove("class");

            tab_followup.Attributes.Remove("class");
            tab_followup.Attributes.Add("class", "tab-pane");
            lifollowup.Attributes.Remove("class");
        }


        //public void BindCompanyAllProject()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        divSuccess.Visible = false;
        //        divAlert.Visible = true;
        //        lblErrorMsg.Text = "Error : " + ex.Message;
        //    }
        //}

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

        protected void btnAddProject_Click(object sender, EventArgs e)
        {
            try
            {
                //string PCodeTest = "";
                //string AreaType = "";
                //try
                //{
                //    DataTable dt = ClstblPostCodes.tblPostCodes_ExistPostCode(txtInstallCity.Text, txtInstallPostCode.Text);
                //    if (dt.Rows.Count > 0)
                //    {
                //        PCodeTest = txtInstallPostCode.Text; //dt.Rows[0][""].ToString();
                //        if (dt.Rows[0]["AreaType"] != DBNull.Value)
                //        {
                //            AreaType = dt.Rows[0]["AreaType"].ToString();

                //            bool suc = ClstblCustomers.tblCustomers_UpdateArea(AreaType, Profile.eurosolar.companyid);
                //        }
                //    }
                //}
                //catch { }


                //if (PCodeTest == "" || AreaType == "")
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Invalid Post Code or Suburb. Please enter proper details');", true);
                //}
                //else
                //{
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
                //}
                tab_project.Attributes.Remove("class");
                tab_project.Attributes.Add("class", "tab-pane active");
                liproject.Attributes.Add("class", "active");

                tab_summary.Attributes.Remove("class");
                tab_summary.Attributes.Add("class", "tab-pane");
                lisummary.Attributes.Remove("class");

                tab_contact.Attributes.Remove("class");
                tab_contact.Attributes.Add("class", "tab-pane");
                licontact.Attributes.Remove("class");

                tab_followup.Attributes.Remove("class");
                tab_followup.Attributes.Add("class", "tab-pane");
                lifollowup.Attributes.Remove("class");

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void btnCancelAddNewProject_Click(object sender, EventArgs e)
        {
            ResetAddNewProject();
            DivAddNewProject.Visible = false;
            tab_project.Attributes.Remove("class");
            tab_project.Attributes.Add("class", "tab-pane active");
            liproject.Attributes.Add("class", "active");

            tab_summary.Attributes.Remove("class");
            tab_summary.Attributes.Add("class", "tab-pane");
            lisummary.Attributes.Remove("class");

            tab_contact.Attributes.Remove("class");
            tab_contact.Attributes.Add("class", "tab-pane");
            licontact.Attributes.Remove("class");

            tab_followup.Attributes.Remove("class");
            tab_followup.Attributes.Add("class", "tab-pane");
            lifollowup.Attributes.Remove("class");
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

        protected void btnAddNewFollowUp_Click(object sender, EventArgs e)
        {
            DivAddNewFollowUp.Visible = true;

            tab_followup.Attributes.Remove("class");
            tab_followup.Attributes.Add("class", "tab-pane active");
            lifollowup.Attributes.Add("class", "active");

            tab_summary.Attributes.Remove("class");
            tab_summary.Attributes.Add("class", "tab-pane");
            lisummary.Attributes.Remove("class");

            tab_contact.Attributes.Remove("class");
            tab_contact.Attributes.Add("class", "tab-pane");
            licontact.Attributes.Remove("class");

            tab_project.Attributes.Remove("class");
            tab_project.Attributes.Add("class", "tab-pane");
            liproject.Attributes.Remove("class");
        }

        protected void btnAddFollowUp_Click(object sender, EventArgs e)
        {
            try
            {
                CustInfoEntity ObjEntity = new CustInfoEntity();

                ObjEntity.CustomerID = Convert.ToInt64(hdnlblCustomerID.Value);
                ObjEntity.Description = txtDescription.Text.Trim();
                ObjEntity.FollowupDate = DateTime.ParseExact(txtFollowUpDate.Text, "MM/dd/yyyy", null);
                ObjEntity.NextFollowupDate = DateTime.ParseExact(txtNextFollowUpDate.Text, "MM/dd/yyyy", null);
                ObjEntity.ContactID = Convert.ToInt64(ddlContacts.SelectedValue);

                string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
                EmployeeEntity stEmp = EmployeeManagement.tblEmployees_SelectEmployeeID(userid);

                ObjEntity.CustInfoEnteredBy = stEmp.EmployeeID;
                ObjEntity.FollowupType = 1;

                long success = CustInfoManagement.tblCustInfo_Insert(ObjEntity);
                //--- do not chage this code start------
                if (Convert.ToString(success) != "")
                {
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "FollowUps Added Successfully";

                    ResetAddNewFollowUp();
                    BindFollowUps(Convert.ToInt64(hdnlblCustomerID.Value));

                }
                else
                {
                    divSuccess.Visible = false;
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "FollowUps Added Failed";
                }

                DivAddNewFollowUp.Visible = false;
                tab_followup.Attributes.Remove("class");
                tab_followup.Attributes.Add("class", "tab-pane active");
                lifollowup.Attributes.Add("class", "active");

                tab_summary.Attributes.Remove("class");
                tab_summary.Attributes.Add("class", "tab-pane");
                lisummary.Attributes.Remove("class");

                tab_contact.Attributes.Remove("class");
                tab_contact.Attributes.Add("class", "tab-pane");
                licontact.Attributes.Remove("class");

                tab_project.Attributes.Remove("class");
                tab_project.Attributes.Add("class", "tab-pane");
                liproject.Attributes.Remove("class");
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void btnCancelFollowUP_Click(object sender, EventArgs e)
        {
            ResetAddNewFollowUp();
            DivAddNewFollowUp.Visible = false;

            tab_followup.Attributes.Remove("class");
            tab_followup.Attributes.Add("class", "tab-pane active");
            lifollowup.Attributes.Add("class", "active");

            tab_summary.Attributes.Remove("class");
            tab_summary.Attributes.Add("class", "tab-pane");
            lisummary.Attributes.Remove("class");

            tab_contact.Attributes.Remove("class");
            tab_contact.Attributes.Add("class", "tab-pane");
            licontact.Attributes.Remove("class");

            tab_project.Attributes.Remove("class");
            tab_project.Attributes.Add("class", "tab-pane");
            liproject.Attributes.Remove("class");
        }

        public void ResetAddNewFollowUp()
        {
            ddlContacts.SelectedIndex = 0;
            txtFollowUpDate.Text = "";
            txtNextFollowUpDate.Text = "";
            txtDescription.Text = "";
        }

        protected void btnUpdateFollowUp_Click(object sender, EventArgs e)
        {
            try
            {
                CustInfoEntity ObjEntity = new CustInfoEntity();

                ObjEntity.CustInfoID = Convert.ToInt64(hdnCustInfoID.Value);
                ObjEntity.CustomerID = Convert.ToInt64(hdnlblCustomerID.Value);
                ObjEntity.Description = txtDescription.Text.Trim();
                ObjEntity.FollowupDate = Convert.ToDateTime(txtFollowUpDate.Text.Trim());
                ObjEntity.NextFollowupDate = Convert.ToDateTime(txtNextFollowUpDate.Text.Trim());
                ObjEntity.ContactID = Convert.ToInt64(ddlContacts.SelectedValue);

                string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
                EmployeeEntity stEmp = EmployeeManagement.tblEmployees_SelectEmployeeID(userid);

                ObjEntity.CustInfoEnteredBy = stEmp.EmployeeID;
                ObjEntity.FollowupType = 1;

                long success = CustInfoManagement.tblCustInfo_Update(ObjEntity);
                //--- do not chage this code start------
                if (Convert.ToString(success) != "")
                {
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "FollowUps Update Successfully";

                    ResetAddNewFollowUp();
                    BindFollowUps(Convert.ToInt64(hdnlblCustomerID.Value));

                }
                else
                {
                    divSuccess.Visible = false;
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "FollowUps Update Failed";
                }
                btnAddFollowUp.Visible = true;
                btnUpdateFollowUp.Visible = false;
                DivAddNewFollowUp.Visible = false;
                tab_followup.Attributes.Remove("class");
                tab_followup.Attributes.Add("class", "tab-pane active");
                lifollowup.Attributes.Add("class", "active");

                tab_summary.Attributes.Remove("class");
                tab_summary.Attributes.Add("class", "tab-pane");
                lisummary.Attributes.Remove("class");

                tab_contact.Attributes.Remove("class");
                tab_contact.Attributes.Add("class", "tab-pane");
                licontact.Attributes.Remove("class");

                tab_project.Attributes.Remove("class");
                tab_project.Attributes.Add("class", "tab-pane");
                liproject.Attributes.Remove("class");

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void rptFollowUpList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToString() == "Edit")
                {
                    var lstEntity = CustInfoManagement.tblCustInfo_SelectForEdit(Convert.ToInt64(e.CommandArgument));

                    hdnCustInfoID.Value = lstEntity.CustInfoID.ToString();
                    ddlContacts.SelectedValue = lstEntity.ContactID.ToString();
                    txtFollowUpDate.Text = lstEntity.FollowupDate.ToString("MM/dd/yyyy");
                    txtNextFollowUpDate.Text = lstEntity.NextFollowupDate.ToString("MM/dd/yyyy");
                    txtDescription.Text = lstEntity.Description.ToString();

                    btnAddFollowUp.Visible = false;
                    btnUpdateFollowUp.Visible = true;

                    DivAddNewFollowUp.Visible = true;
                    tab_followup.Attributes.Remove("class");
                    tab_followup.Attributes.Add("class", "tab-pane active");
                    lifollowup.Attributes.Add("class", "active");

                    tab_summary.Attributes.Remove("class");
                    tab_summary.Attributes.Add("class", "tab-pane");
                    lisummary.Attributes.Remove("class");

                    tab_contact.Attributes.Remove("class");
                    tab_contact.Attributes.Add("class", "tab-pane");
                    licontact.Attributes.Remove("class");

                    tab_project.Attributes.Remove("class");
                    tab_project.Attributes.Add("class", "tab-pane");
                    liproject.Attributes.Remove("class");
                }
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

     

        public void BindProjectList()
        {

            string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();

            List<CustomersEntity> lstNew = new List<CustomersEntity>();
            lstNew = CustomersManagement.tblCustomer_SelectForLeadDashboard("New", userid);
            rptNewList.DataSource = lstNew;
            rptNewList.DataBind();

            List<CustomersEntity> lstCold = new List<CustomersEntity>();
            lstCold = CustomersManagement.tblCustomer_SelectForLeadDashboard("Cold", userid);
            rptColdList.DataSource = lstCold;
            rptColdList.DataBind();

            List<CustomersEntity> lstHot = new List<CustomersEntity>();
            lstHot = CustomersManagement.tblCustomer_SelectForLeadDashboard("Hot", userid);
            rptHotList.DataSource = lstHot;
            rptHotList.DataBind();

            List<CustomersEntity> lstPotential = new List<CustomersEntity>();
            lstPotential = CustomersManagement.tblCustomer_SelectForLeadDashboard("Potential", userid);
            rptPotentialList.DataSource = lstPotential;
            rptPotentialList.DataBind();

            List<CustomerTypeEntity> lstCustType = new List<CustomerTypeEntity>();
            lstCustType = CustomerTypeManagement.tblCustType_SelectActive();
            ddlCustTypeID.DataSource = lstCustType;
            ddlCustTypeID.DataMember = "CustType";
            ddlCustTypeID.DataTextField = "CustType";
            ddlCustTypeID.DataValueField = "CustTypeID";
            ddlCustTypeID.DataBind();
        }
        protected void rptNewList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    CustomerID = Convert.ToInt64(e.CommandArgument);
                    hdnCustomerID.Value = CustomerID.ToString();
                    divCustType.Attributes.Add("class", "modal fade modal-overflow in");
                    divCustType.Attributes.Add("Style", "display:block;");

                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void rptNewList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptColdList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    CustomerID = Convert.ToInt64(e.CommandArgument);
                    hdnCustomerID.Value = CustomerID.ToString();
                    divCustType.Attributes.Add("class", "modal fade modal-overflow in");
                    divCustType.Attributes.Add("Style", "display:block;");

                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void rptColdList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptHotList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    // hdnCustomerID.Value = Request.QueryString["customerid"].ToString();
                    CustomerID = Convert.ToInt64(e.CommandArgument);
                    hdnCustomerID.Value = CustomerID.ToString();
                    divCustType.Attributes.Add("class", "modal fade modal-overflow in");
                    divCustType.Attributes.Add("Style", "display:block;");

                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void rptHotList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptPotentialList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Edit")
            {
                try
                {
                    // hdnCustomerID.Value = Request.QueryString["customerid"].ToString();
                    CustomerID = Convert.ToInt64(e.CommandArgument);
                    hdnCustomerID.Value = CustomerID.ToString();
                    divCustType.Attributes.Add("class", "modal fade modal-overflow in");
                    divCustType.Attributes.Add("Style", "display:block;");

                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void rptPotentialList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect(SiteURL + "/admin/company/addcompany.aspx?custtypeid=" + 9);
        }

        protected void btnEditPotential_Click(object sender, EventArgs e)
        {

        }

        protected void btnClosedivCustType_Click(object sender, EventArgs e)
        {
            divCustType.Attributes.Remove("class");
            divCustType.Attributes.Add("class", "modal fade");
            divCustType.Attributes.Remove("Style");

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ddlCustTypeID.SelectedValue != "")
            {
                CustomersManagement.tblCustomers_UpdateCustType(Convert.ToInt32(ddlCustTypeID.SelectedValue), Convert.ToInt32(hdnCustomerID.Value));
                divCustType.Attributes.Remove("class");
                divCustType.Attributes.Add("class", "modal fade");
                divCustType.Attributes.Remove("Style");
                ddlCustTypeID.Items.Clear();
                BindProjectList();
            }

        }

        protected void lnkview_Click(object sender, EventArgs e)
        {
            if (lnkview.Text == "Detail")
            {
                divcompanylist.Visible = false;
                frmOrder.Visible = true;
                lnkview.Text = "List";
            }
            else 
            {
                divcompanylist.Visible = true;
                frmOrder.Visible = false;
                lnkview.Text = "Detail";
            }
        }

    }
}
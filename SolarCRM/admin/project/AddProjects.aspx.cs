using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SolarCRM.BAL.Implementations.CompanyModule;
using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.BAL.Implementations.ProjectModule;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.CompanyModule;
using SolarCRM.Entity.Models.EmployeeModule;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.ProjectModule;
using SolarCRM.PagingUserControl;
using System.Web.Security;
using SolarCRM.BAL.Comman;
using SolarCRM.Common;
using SolarCRM.BAL.Implementations.StockModule;
using SolarCRM.Entity.Models.StockModule;
using System.IO;
using System.Configuration;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
using System.Globalization;


namespace SolarCRM.admin.project
{
    public partial class AddProjects : System.Web.UI.Page
    {
        protected string SiteURL;
        static long ProjectID = 0;
        decimal BalanceCost = 0;
        decimal TotalCost = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;

            if (!IsPostBack)
            {
                Session["PageNo"] = 1;
                Session["PageSize"] = 10;
                Session["PageNo1"] = 1;
                Session["PageSize1"] = 10;
                BindCompanyDropdown();
            }
        }

   

       public void BindCompanyDropdown()
       {
           try
           {
               ddlCompany.Items.Clear();
              
               if (ChkPotential.Checked == true)
               {
                   ddlCompany.DataSource = CustomersManagement.tblCustomer_SelectByCustomerTypeID(3);
                   ddlCompany.DataValueField = "CustomerID";
                   ddlCompany.DataTextField = "Customer";
                   ddlCompany.DataMember = "Customer";
                   ddlCompany.DataBind();
               }
               if (chkHot.Checked == true)
               {
                   ddlCompany.DataSource = CustomersManagement.tblCustomer_SelectByCustomerTypeID(5);
                   ddlCompany.DataValueField = "CustomerID";
                   ddlCompany.DataTextField = "Customer";
                   ddlCompany.DataMember = "Customer";
                   ddlCompany.DataBind();
               }
               if(chkCold.Checked == true)
               {
                   ddlCompany.DataSource = CustomersManagement.tblCustomer_SelectByCustomerTypeID(6);
                   ddlCompany.DataValueField = "CustomerID";
                   ddlCompany.DataTextField = "Customer";
                   ddlCompany.DataMember = "Customer";
                   ddlCompany.DataBind();
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

       

        protected void rptCompanylist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

       

        protected void btnalert_Click(object sender, EventArgs e)
        {
            divAlert.Visible = false;
        }


        protected void btnSuccess_Click(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
        }
        protected void btnAddNewProject_Click(object sender, EventArgs e)
        {
            divcompanydetails.Visible = true;
          //  divsalesinput.Visible = true;
       
            long CustomerID = Convert.ToInt64(ddlCompany.SelectedValue);

            BindAddNewProjectDetails(CustomerID);

            DivAddNewProject.Visible = true;
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

        protected void btnAddProject_Click(object sender, EventArgs e)
        {
            try
            {
               
                ProjectsEntity ProEntity = new ProjectsEntity();

                ProEntity.CustomerID = Convert.ToInt64(ddlCompany.SelectedValue);
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
                    CustomersManagement.tblCustomers_UpdateCustType(3, ProEntity.CustomerID);

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
                        divsalesinput.Visible = true;
                        ProjectID = success;
                        BindProjectDetails();

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

        protected void btnCancelAddNewProject_Click(object sender, EventArgs e)
        {
            ResetAddNewProject();
            DivAddNewProject.Visible = false;
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

        protected void ChkPotential_CheckedChanged(object sender, EventArgs e)
        {
           
                BindCompanyDropdown();
           
        }

        protected void chkHot_CheckedChanged(object sender, EventArgs e)
        {
           
                BindCompanyDropdown();
        }

        protected void chkCold_CheckedChanged(object sender, EventArgs e)
        {
          
                BindCompanyDropdown();
        }

        protected void btnSaveSalesInput_Click(object sender, EventArgs e)
        {
            ProjectsEntity st = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);
            CustomersEntity stCust = CustomersManagement.tblCustomers_SelectByCustomerID(st.CustomerID);
            ProjectsEntity ProjectEntity = new ProjectsEntity();


            int Exist = ProjectsManagement.tblProjectsSalesInput_ProjectIDExists(ProjectID);
            if (Exist == 0)
            {
                ProjectEntity.ProjectID = st.ProjectID;
                ProjectEntity.ProjectManegerID = Convert.ToInt64(ddlProjectMgr.SelectedValue);
                ProjectEntity.EmployeeID = st.EmployeeID;
                ProjectEntity.CustomerID = st.CustomerID;
                ProjectEntity.FollowUpDate = Convert.ToDateTime(txtFollowUpDate.Text);
                ProjectEntity.ContactID = st.ContactID;
                ProjectEntity.ManualQuoteNumber = txtManualQuoteNumber.Text;
                ProjectEntity.FollowUpNote = txtFollowUpNote.Text;
                ProjectEntity.PanelBrandID = Convert.ToInt32(ddlPanel.SelectedValue);
                ProjectEntity.NumberPanels = Convert.ToInt32(txtNoOfPanels.Text);
                ProjectEntity.InverterDetailsID = Convert.ToInt32(ddlInverter1.SelectedValue);
                ProjectEntity.SecondInverterDetailsID = Convert.ToInt32(ddlInverter2.SelectedValue);
                ProjectEntity.InverterModel = txtInverterModel.Text;
                ProjectEntity.InverterCert = txtInverterCert1.Text;
                ProjectEntity.SystemCapKW = Convert.ToDecimal(txtSystemCapacity.Text);
                ProjectEntity.PerKWCost = Convert.ToDecimal(txtPerKWCost.Text);
                ProjectEntity.BasicSystemCost = Convert.ToDecimal(txtBasicSystemCost.Text);
                ProjectEntity.OtherCost = Convert.ToDecimal(txtOtherCost.Text);
                ProjectEntity.SpecialDiscount = Convert.ToDecimal(txtSpecialDiscount.Text);
                decimal BasicSystemCost = 0;
                BasicSystemCost = Convert.ToDecimal(txtBasicSystemCost.Text);
                decimal CGST = 0;
                decimal SGST = 0;
                decimal IGST = 0;
                if (stCust.StreetState == "Gujarat")
                {
                    CGST = (BasicSystemCost / 100) * Convert.ToDecimal(2.5);
                    SGST = (BasicSystemCost / 100) * Convert.ToDecimal(2.5);
                    ProjectEntity.IGST = 0;
                }
                else
                {
                    IGST = (BasicSystemCost / 100) * Convert.ToDecimal(5);
                    CGST = 0;
                    SGST = 0;
                }
                ProjectEntity.CGST = CGST;
                ProjectEntity.SGST = SGST;
                ProjectEntity.IGST = IGST;
                ProjectEntity.TotalQuotePrice = Convert.ToDecimal(txtTotalCost.Text);
                ProjectEntity.DepositRequired = Convert.ToDecimal(txtDepositRequired.Text);
                ProjectEntity.HouseTypeID = Convert.ToInt32(ddlHouseType.SelectedValue);
                ProjectEntity.VarHouseType = Convert.ToDecimal(txtHouseType.Text);
                ProjectEntity.RoofTypeID = Convert.ToInt32(ddlRoofType.SelectedValue);
                ProjectEntity.VarRoofType = Convert.ToDecimal(txtRoofType.Text);
                ProjectEntity.RoofAngleID = Convert.ToInt32(ddlRoofAngle.SelectedValue);
                ProjectEntity.VarRoofAngle = Convert.ToDecimal(txtRoofAngle.Text);
                ProjectEntity.MeterInstallation = Convert.ToInt32(ddlMeterinst.SelectedValue);
                ProjectEntity.VarMeterInstallation = Convert.ToDecimal(txtMeterinst.Text);
                ProjectEntity.MeterPhase = Convert.ToInt32(txtMeterPhase.Text);
                ProjectEntity.MeterNumber = txtMeterNumber.Text;
                ProjectEntity.OffPeak = chkOffPeak.Checked;
                ProjectEntity.ElecDistributorID = Convert.ToInt32(ddlElecDistributor.SelectedValue);
                ProjectEntity.MeterEnoughSpace = chkMeterEnoughSpace.Checked;
                ProjectEntity.ElecRetailerID = Convert.ToInt32(ddlElecRetailer.SelectedValue);
                ProjectEntity.STCNumber = txtSTCNumber.Text;
                ProjectEntity.PeakMeterNumber = txtPeakMeterNumber.Text;
                ProjectEntity.QuoteAccepted = Convert.ToDateTime(txtQuoteAccepted.Text);
                ProjectEntity.SignedQuote = chkSignedQuote.Checked;
                ProjectEntity.QuoteSent = Convert.ToDateTime(txtQuoteSent.Text);
                ProjectEntity.QuotationNotes = txtQuotationNotes.Text;
                ProjectEntity.ProjectNotes = txtProjectNotes.Text;
                ProjectEntity.MeterBoxPhotosSaved = chkMeterBoxPhotosSaved.Checked;
                ProjectEntity.ElecBillSaved = chkElecBillSaved.Checked;
                ProjectEntity.SiteMap = chkSiteMap.Checked;
                ProjectEntity.PaymentReceipt = chkPaymentReceipt.Checked;
                ProjectEntity.MeterApproval = chkMeterApproval.Checked;

                ProjectsManagement.tblProjectsSalesInput_Insert(ProjectEntity);
                // BindRoofType();
                divSuccess.Visible = true;
                divAlert.Visible = false;
                lblSuccessMsg.Text = "Sales Input Added Successfully";

                // Reset();
            }


            else
            {
                ProjectEntity.ProjectID = st.ProjectID;
                ProjectEntity.ProjectManegerID = Convert.ToInt64(ddlProjectMgr.SelectedValue);
                ProjectEntity.EmployeeID = st.EmployeeID;
                ProjectEntity.CustomerID = st.CustomerID;
                ProjectEntity.FollowUpDate = Convert.ToDateTime(DateTime.Parse((txtFollowUpDate.Text), new CultureInfo("en-US", true)));
                ProjectEntity.ContactID = st.ContactID;
                ProjectEntity.ManualQuoteNumber = txtManualQuoteNumber.Text;
                ProjectEntity.FollowUpNote = txtFollowUpNote.Text;
                ProjectEntity.PanelBrandID = Convert.ToInt32(ddlPanel.SelectedValue);
                ProjectEntity.NumberPanels = Convert.ToInt32(txtNoOfPanels.Text);
                ProjectEntity.InverterDetailsID = Convert.ToInt32(ddlInverter1.SelectedValue);
                ProjectEntity.SecondInverterDetailsID = Convert.ToInt32(ddlInverter2.SelectedValue);
                ProjectEntity.InverterModel = txtInverterModel.Text;
                ProjectEntity.InverterCert = txtInverterCert1.Text;
                ProjectEntity.SystemCapKW = Convert.ToDecimal(txtSystemCapacity.Text);
                ProjectEntity.PerKWCost = Convert.ToDecimal(txtPerKWCost.Text);
                ProjectEntity.BasicSystemCost = Convert.ToDecimal(txtBasicSystemCost.Text);
                ProjectEntity.OtherCost = Convert.ToDecimal(txtOtherCost.Text);
                ProjectEntity.SpecialDiscount = Convert.ToDecimal(txtSpecialDiscount.Text);
                decimal BasicSystemCost = 0;
                BasicSystemCost = Convert.ToDecimal(txtBasicSystemCost.Text);
                decimal CGST = 0;
                decimal SGST = 0;
                decimal IGST = 0;
                if (stCust.StreetState == "Gujarat")
                {
                    CGST = (BasicSystemCost / 100) * Convert.ToDecimal(2.5);
                    SGST = (BasicSystemCost / 100) * Convert.ToDecimal(2.5);
                    ProjectEntity.IGST = 0;
                }
                else
                {
                    IGST = (BasicSystemCost / 100) * Convert.ToDecimal(5);
                    CGST = 0;
                    SGST = 0;
                }
                ProjectEntity.CGST = CGST;
                ProjectEntity.SGST = SGST;
                ProjectEntity.IGST = IGST;
                ProjectEntity.TotalQuotePrice = Convert.ToDecimal(txtTotalCost.Text);
                ProjectEntity.DepositRequired = Convert.ToDecimal(txtDepositRequired.Text);
                ProjectEntity.HouseTypeID = Convert.ToInt32(ddlHouseType.SelectedValue);
                ProjectEntity.VarHouseType = Convert.ToDecimal(txtHouseType.Text);
                ProjectEntity.RoofTypeID = Convert.ToInt32(ddlRoofType.SelectedValue);
                ProjectEntity.VarRoofType = Convert.ToDecimal(txtRoofType.Text);
                ProjectEntity.RoofAngleID = Convert.ToInt32(ddlRoofAngle.SelectedValue);
                ProjectEntity.VarRoofAngle = Convert.ToDecimal(txtRoofAngle.Text);
                ProjectEntity.MeterInstallation = Convert.ToInt32(ddlMeterinst.SelectedValue);
                ProjectEntity.VarMeterInstallation = Convert.ToDecimal(txtMeterinst.Text);
                ProjectEntity.MeterPhase = Convert.ToInt32(txtMeterPhase.Text);
                ProjectEntity.MeterNumber = txtMeterNumber.Text;
                ProjectEntity.OffPeak = chkOffPeak.Checked;
                ProjectEntity.ElecDistributorID = Convert.ToInt32(ddlElecDistributor.SelectedValue);
                ProjectEntity.MeterEnoughSpace = chkMeterEnoughSpace.Checked;
                ProjectEntity.ElecRetailerID = Convert.ToInt32(ddlElecRetailer.SelectedValue);
                ProjectEntity.STCNumber = txtSTCNumber.Text;
                ProjectEntity.PeakMeterNumber = txtPeakMeterNumber.Text;
                ProjectEntity.QuoteAccepted = Convert.ToDateTime(DateTime.Parse((txtQuoteAccepted.Text), new CultureInfo("en-US", true)));
                ProjectEntity.SignedQuote = chkSignedQuote.Checked;
                ProjectEntity.QuoteSent = Convert.ToDateTime(DateTime.Parse((txtQuoteSent.Text), new CultureInfo("en-US", true)));
                ProjectEntity.QuotationNotes = txtQuotationNotes.Text;
                ProjectEntity.ProjectNotes = txtProjectNotes.Text;
                ProjectEntity.MeterBoxPhotosSaved = chkMeterBoxPhotosSaved.Checked;
                ProjectEntity.ElecBillSaved = chkElecBillSaved.Checked;
                ProjectEntity.SiteMap = chkSiteMap.Checked;
                ProjectEntity.PaymentReceipt = chkPaymentReceipt.Checked;
                ProjectEntity.MeterApproval = chkMeterApproval.Checked;

                ProjectsManagement.tblProjectsSalesInput_Update(ProjectEntity);
                // BindRoofType();
                divSuccess.Visible = true;
                divAlert.Visible = false;
                lblSuccessMsg.Text = "Sales Input Updated Successfully";


            }

        }

        protected void txtNoOfPanels_TextChanged(object sender, EventArgs e)
        {
            string PanelBrand = "0";
            string PanelModel = "0";
            string Watts = "0";
            decimal capacity = 0;
            if (ddlPanel.SelectedValue != string.Empty)
            {
                StockEntity st = StockManagement.tblStockItems_SelectByStockItemID(Convert.ToInt32(ddlPanel.SelectedValue));

                PanelBrand = st.StockManufacturer;
                PanelModel = st.StockModel;
                Watts = st.StockSize;
            }

            if (txtNoOfPanels.Text != string.Empty)
            {
                try
                {
                    capacity = (Convert.ToDecimal(txtNoOfPanels.Text) * Convert.ToDecimal(Watts)) / 1000;
                }
                catch { }
                txtSystemCapacity.Text = Convert.ToString(capacity);
            }

        }
        protected void ddlInverter1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StockEntity st = StockManagement.tblStockItems_SelectByStockItemID(Convert.ToInt32(ddlInverter1.SelectedValue));
            txtInverterCert1.Text = st.InverterCert;

        }

        protected void txtPerKWCost_TextChanged(object sender, EventArgs e)
        {
            ProjectsEntity st = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);
            int ProjectStatusID = st.ProjectStatusID;
            ProjectID = st.ProjectID;
            int ProjectTypeID = Convert.ToInt32(ddlProjectType.SelectedValue);

            int PerKWCost = Convert.ToInt32(txtPerKWCost.Text);
            decimal SystemCapacity = Convert.ToDecimal(txtSystemCapacity.Text);
            decimal BasicSystemCost = PerKWCost * SystemCapacity;
            txtBasicSystemCost.Text = BasicSystemCost.ToString();

            if (ProjectTypeID == 1 || ProjectTypeID == 2 || ProjectTypeID == 3)
            {

                if (txtBasicSystemCost.Text == "" || Convert.ToDecimal(txtBasicSystemCost.Text) == 0)
                {
                    txtBasicSystemCost.Text = "0.00";
                }

                if (txtSpecialDiscount.Text == "" || Convert.ToDecimal(txtSpecialDiscount.Text) == 0)
                {
                    txtSpecialDiscount.Text = "0.00";
                }

                if (txtOtherCost.Text == string.Empty)
                {
                    txtOtherCost.Text = "0.00";
                }
                if (txtHouseType.Text == "" || Convert.ToDecimal(txtHouseType.Text) == 0)
                {
                    txtHouseType.Text = "0.00";
                }
                if (txtRoofType.Text == "" || Convert.ToDecimal(txtRoofType.Text) == 0)
                {
                    txtRoofType.Text = "0.00";
                }
                if (txtRoofAngle.Text == "" || Convert.ToDecimal(txtRoofAngle.Text) == 0)
                {
                    txtRoofAngle.Text = "0.00";
                }
                if (txtMeterinst.Text == "" || Convert.ToDecimal(txtMeterinst.Text) == 0)
                {
                    txtMeterinst.Text = "0.00";
                }

                decimal BasicSystemCostPerKW = PerKWCost * SystemCapacity;
                txtBasicSystemCost.Text = BasicSystemCostPerKW.ToString();
                decimal GST = (Convert.ToDecimal(BasicSystemCostPerKW) * 5) / 100;
                txtGST.Text = (GST).ToString();
                TotalCost = (Convert.ToDecimal(txtBasicSystemCost.Text) + Convert.ToDecimal(txtGST.Text));
                txtTotalCost.Text = TotalCost.ToString();
                if (ProjectStatusID == 2)
                {
                    txtDepositRequired.Text = ((Convert.ToDecimal(txtTotalCost.Text) * 20) / 100).ToString();
                }
                BalanceCost = (Convert.ToDecimal(txtBasicSystemCost.Text) + Convert.ToDecimal(txtGST.Text) + Convert.ToDecimal(txtOtherCost.Text)) - (Convert.ToDecimal(txtSpecialDiscount.Text) + Convert.ToDecimal(txtDepositRequired.Text));
                txtBaltoPay.Text = Convert.ToString(BalanceCost);
                txtHouseType.Focus();
            }

            else
            {

                if (txtBasicSystemCost.Text == "" || Convert.ToDecimal(txtBasicSystemCost.Text) == 0)
                {
                    txtBasicSystemCost.Text = "0.00";
                }

                if (txtSpecialDiscount.Text == "" || Convert.ToDecimal(txtSpecialDiscount.Text) == 0)
                {
                    txtSpecialDiscount.Text = "0.00";
                }
                if (txtOtherCost.Text == string.Empty)
                {
                    txtOtherCost.Text = "0.00";
                }
                if (txtHouseType.Text == "" || Convert.ToDecimal(txtHouseType.Text) == 0)
                {
                    txtHouseType.Text = "0.00";
                }
                if (txtRoofType.Text == "" || Convert.ToDecimal(txtRoofType.Text) == 0)
                {
                    txtRoofType.Text = "0.00";
                }
                if (txtRoofAngle.Text == "" || Convert.ToDecimal(txtRoofAngle.Text) == 0)
                {
                    txtRoofAngle.Text = "0.00";
                }
                if (txtMeterinst.Text == "" || Convert.ToDecimal(txtMeterinst.Text) == 0)
                {
                    txtMeterinst.Text = "0.00";
                }
                decimal BasicSystemCost1 = ((PerKWCost * 100) / 105);
                decimal BasicSystemCostPerKW = BasicSystemCost1 * SystemCapacity;
                txtBasicSystemCost.Text = BasicSystemCostPerKW.ToString();
                decimal TotalTax = TotalCost - BasicSystemCostPerKW;
                txtGST.Text = (TotalTax).ToString();
                if (txtOtherCost.Text == string.Empty)
                {
                    txtOtherCost.Text = "0.00";
                }
                TotalCost = (Convert.ToDecimal(txtBasicSystemCost.Text) + Convert.ToDecimal(txtGST.Text));

                txtTotalCost.Text = TotalCost.ToString();

                if (ProjectStatusID == 2)
                {
                    txtDepositRequired.Text = ((Convert.ToDecimal(txtTotalCost.Text) * 20) / 100).ToString();
                }
                BalanceCost = (Convert.ToDecimal(txtBasicSystemCost.Text) + Convert.ToDecimal(txtGST.Text) + Convert.ToDecimal(txtOtherCost.Text)) - (Convert.ToDecimal(txtSpecialDiscount.Text) + Convert.ToDecimal(txtDepositRequired.Text));
                txtBaltoPay.Text = Convert.ToString(BalanceCost);
                txtHouseType.Focus();
            }

        }

        protected void txtOtherCost_TextChanged(object sender, EventArgs e)
        {
            ProjectsEntity st = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);
            int ProjectStatusID = st.ProjectStatusID;

            decimal SystemCapacity = Convert.ToDecimal(txtSystemCapacity.Text);
            int PerKWCost = Convert.ToInt32(txtPerKWCost.Text);
            txtBasicSystemCost.Text = Convert.ToString(SystemCapacity * PerKWCost);

            if (txtBasicSystemCost.Text == "" || Convert.ToDecimal(txtBasicSystemCost.Text) == 0)
            {
                txtBasicSystemCost.Text = "0.00";
            }

            if (txtOtherCost.Text == "" || Convert.ToDecimal(txtOtherCost.Text) == 0)
            {
                txtOtherCost.Text = "0.00";
            }
            if (txtSpecialDiscount.Text == "" || Convert.ToDecimal(txtSpecialDiscount.Text) == 0)
            {
                txtSpecialDiscount.Text = "0.00";
            }
            if (txtHouseType.Text == "" || Convert.ToDecimal(txtHouseType.Text) == 0)
            {
                txtHouseType.Text = "0.00";
            }
            if (txtRoofType.Text == "" || Convert.ToDecimal(txtRoofType.Text) == 0)
            {
                txtRoofType.Text = "0.00";
            }
            if (txtRoofAngle.Text == "" || Convert.ToDecimal(txtRoofAngle.Text) == 0)
            {
                txtRoofAngle.Text = "0.00";
            }
            if (txtMeterinst.Text == "" || Convert.ToDecimal(txtMeterinst.Text) == 0)
            {
                txtMeterinst.Text = "0.00";
            }
            TotalCost = (Convert.ToDecimal(txtBasicSystemCost.Text) + Convert.ToDecimal(txtOtherCost.Text) + Convert.ToDecimal(txtGST.Text)) - (Convert.ToDecimal(txtSpecialDiscount.Text));
            txtTotalCost.Text = Convert.ToString(TotalCost);
            if (ProjectStatusID == 2)
            {
                txtDepositRequired.Text = ((Convert.ToDecimal(txtTotalCost.Text) * 20) / 100).ToString();
            }
            BalanceCost = (Convert.ToDecimal(txtBasicSystemCost.Text) + Convert.ToDecimal(txtGST.Text) + Convert.ToDecimal(txtOtherCost.Text)) - (Convert.ToDecimal(txtSpecialDiscount.Text) + Convert.ToDecimal(txtDepositRequired.Text));
            txtBaltoPay.Text = Convert.ToString(BalanceCost);
            txtDepositRequired.Focus();
        }

        protected void txtSpecialDiscount_TextChanged(object sender, EventArgs e)
        {
            ProjectsEntity st = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);
            int ProjectStatusID = st.ProjectStatusID;
            if (txtSpecialDiscount.Text == "" || Convert.ToDecimal(txtSpecialDiscount.Text) == 0)
            {
                txtSpecialDiscount.Text = "0.00";
            }
            TotalCost = (Convert.ToDecimal(txtBasicSystemCost.Text) + Convert.ToDecimal(txtOtherCost.Text) + Convert.ToDecimal(txtGST.Text)) - (Convert.ToDecimal(txtSpecialDiscount.Text));
            txtTotalCost.Text = (Convert.ToString(TotalCost));
            if (ProjectStatusID == 2)
            {
                txtDepositRequired.Text = ((Convert.ToDecimal(txtTotalCost.Text) * 20) / 100).ToString();
            }
            BalanceCost = (Convert.ToDecimal(txtBasicSystemCost.Text) + Convert.ToDecimal(txtGST.Text) + Convert.ToDecimal(txtOtherCost.Text)) - (Convert.ToDecimal(txtSpecialDiscount.Text) + Convert.ToDecimal(txtDepositRequired.Text));
            txtBaltoPay.Text = Convert.ToString(BalanceCost);
            txtDepositRequired.Focus();
        }
        protected void btnCreateQuotes_Click(object sender, ImageClickEventArgs e)
        {
            ProjectsEntity st = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);

            long EmployeeID = st.EmployeeID;
            ProjectID = st.ProjectID;
            long ProjectNumber = st.ProjectNumber;
            int ProjectTypeID = st.ProjectTypeID;
            decimal BasicSystemCost = st.BasicSystemCost;
            decimal TotalQuotePrice = st.TotalQuotePrice;



            long ProjectQuoteID = ProjectsManagement.tblProjectQuotes_Insert(ProjectID, ProjectNumber, EmployeeID, BasicSystemCost, TotalQuotePrice);

            string QuoteDoc = "Quotation.pdf";

            if (ProjectQuoteID != 0)
            {
                QuoteDoc = ProjectQuoteID + QuoteDoc;
                long suc = ProjectsManagement.tblProjectQuotes_UpdateProjectQuoteDoc(ProjectQuoteID, QuoteDoc);
            }

            TextWriter txtWriter = new StringWriter() as TextWriter;

            //if (st.ProjectTypeID == 2)
            //{
            // Response.Redirect("~/mailtemplate/Quotation.aspx?id=" + ProjectID);
            Server.Execute("~/mailtemplate/Quotation.aspx?id=" + ProjectID, txtWriter);
            String htmlText = txtWriter.ToString();
            SaveCOMMPDF(htmlText, QuoteDoc);
            //   }
            //BindQuote();
        }


        public void SaveCOMMPDF(string HTML, string filename)
        {
            System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
            try
            {
                string pdfUser = ConfigurationManager.AppSettings["PDFUserName"];
                string pdfKey = ConfigurationManager.AppSettings["PDFUserKey"];
                //create an API client instance
                pdfcrowd.Client client = new pdfcrowd.Client(pdfUser, pdfKey);
                //convert a web page and write the generated PDF to a memory stream
                MemoryStream Stream = new MemoryStream();

                client.setVerticalMargin("75pt");

                TextWriter txtWriter = new StringWriter() as TextWriter;
                //Server.Execute("~/mailtemplate/UREQuotationheader.aspx", txtWriter);

                string HeaderHtml = txtWriter.ToString();

                client.setHeaderHtml(HeaderHtml);

                FileStream fs = File.Create(Request.PhysicalApplicationPath + "\\userfiles\\QuotationDoc\\" + filename);
                client.convertHtml(HTML, fs);
                fs.Flush();
                fs.Close();
                //   SiteConfiguration.UploadPDFFile("QuotationDoc", filename);

            }
            catch (pdfcrowd.Error why)
            {
                //Response.Write(why.ToString());
                //Response.End();
            }
        }

        protected void rptQuote_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hndProjectQuoteID = (HiddenField)e.Item.FindControl("hndProjectQuoteID");
                HyperLink hypDoc = (HyperLink)e.Item.FindControl("hypDoc");

                ProjectsEntity st = ProjectsManagement.tblProjectQuotes_SelectByProjectQuoteID(Convert.ToInt32(hndProjectQuoteID.Value));
                hypDoc.NavigateUrl = "~/userfiles/QuotationDoc/" + st.QuoteDoc;

            }
        }

        public void BindProjectDetails()
        {

            ProjectsEntity st2 = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);
            ProjectID = st2.ProjectID;
            if (st2.ProjectMgr != null)
            {
                EmployeeEntity stpm = EmployeeManagement.tblEmployees_SelectActiveByEmployeeID(st2.ProjectMgr);
                string isactive = Convert.ToString(stpm.ActiveEmp);
                if (isactive == "False")
                {
                    ddlProjectMgr.DataSource = EmployeeManagement.tblEmployees_SelectASC(st2.ProjectMgr, 0);
                }
                else
                {
                    ddlProjectMgr.DataSource = EmployeeManagement.tblEmployees_SelectASC(st2.ProjectMgr, 1);
                }
            }
            else
            {
                ddlProjectMgr.DataSource = EmployeeManagement.tblEmployees_SelectASC(0, 1);
            }
            ddlProjectMgr.DataValueField = "EmployeeID";
            ddlProjectMgr.DataTextField = "fullname";
            ddlProjectMgr.DataMember = "fullname";
            ddlProjectMgr.DataBind();

            if (st2.SalesRep != null)
            {
                EmployeeEntity stpm = EmployeeManagement.tblEmployees_SelectActiveByEmployeeID(st2.SalesRep);
                string isactive = Convert.ToString(stpm.ActiveEmp);
                if (isactive == "False")
                {
                    ddlSalesRep.DataSource = EmployeeManagement.tblEmployees_SelectASC(st2.SalesRep, 0);
                }
                else
                {
                    ddlSalesRep.DataSource = EmployeeManagement.tblEmployees_SelectASC(st2.SalesRep, 1);
                }
            }
            else
            {
                ddlSalesRep.DataSource = EmployeeManagement.tblEmployees_SelectASC(0, 1);
            }
            ddlSalesRep.DataValueField = "EmployeeID";
            ddlSalesRep.DataTextField = "fullname";
            ddlSalesRep.DataMember = "fullname";
            ddlSalesRep.DataBind();

            ddlContact.DataSource = CustomersManagement.tblContacts_SelectByCustId(st2.CustomerID);
            ddlContact.DataValueField = "ContactID";
            ddlContact.DataTextField = "FullName";
            ddlContact.DataMember = "FullName";
            ddlContact.DataBind();

            ddlPanel.DataSource = StockManagement.tblStockItems_SelectPanel();
            ddlPanel.DataMember = "StockItem";
            ddlPanel.DataTextField = "StockItem";
            ddlPanel.DataValueField = "StockItemID";
            ddlPanel.DataBind();


            ddlInverter1.DataSource = StockManagement.tblStockItems_SelectInverter();
            ddlInverter1.DataMember = "StockItem";
            ddlInverter1.DataTextField = "StockItem";
            ddlInverter1.DataValueField = "StockItemID";
            ddlInverter1.DataBind();

            ddlInverter2.DataSource = StockManagement.tblStockItems_SelectInverter();
            ddlInverter2.DataMember = "StockItem";
            ddlInverter2.DataTextField = "StockItem";
            ddlInverter2.DataValueField = "StockItemID";
            ddlInverter2.DataBind();

            ddlHouseType.DataSource = HouseTypeManagement.tblHouseType_SelectASC();
            ddlHouseType.DataMember = "HouseType";
            ddlHouseType.DataTextField = "HouseType";
            ddlHouseType.DataValueField = "HouseTypeID";
            ddlHouseType.DataBind();

            ddlRoofType.DataSource = RoofTypeManagement.tblRoofType_SelectASC();
            ddlRoofType.DataMember = "RoofType";
            ddlRoofType.DataTextField = "RoofType";
            ddlRoofType.DataValueField = "RoofTypeID";
            ddlRoofType.DataBind();

            ddlRoofAngle.DataSource = RoofAngleManagement.tblRoofAngle_SelectASC();
            ddlRoofAngle.DataMember = "RoofAngle";
            ddlRoofAngle.DataTextField = "RoofAngle";
            ddlRoofAngle.DataValueField = "RoofAngleID";
            ddlRoofAngle.DataBind();

            ddlElecDistributor.DataSource = ElecDistributorManagement.tblElecDistributor_SelectActiveByState(st2.InstallState);
            ddlElecDistributor.DataMember = "ElecDistributor";
            ddlElecDistributor.DataTextField = "ElecDistributor";
            ddlElecDistributor.DataValueField = "ElecDistributorID";
            ddlElecDistributor.DataBind();

            ddlElecRetailer.DataSource = ElecRetailerManagement.tblElecRetailer_SelectASC();
            ddlElecRetailer.DataMember = "ElecRetailer";
            ddlElecRetailer.DataTextField = "ElecRetailer";
            ddlElecRetailer.DataValueField = "ElecRetailerID";
            ddlElecRetailer.DataBind();

            ddlPromoOffer.DataSource = PromoOfferManagement.tblPromoOffer_SelectActive();
            ddlPromoOffer.DataMember = "PromoOffer";
            ddlPromoOffer.DataTextField = "PromoOffer";
            ddlPromoOffer.DataValueField = "PromoOfferID";
            ddlPromoOffer.DataBind();

            ddlPromoOffer2.DataSource = PromoOfferManagement.tblPromoOffer_SelectActive();
            ddlPromoOffer2.DataMember = "PromoOffer";
            ddlPromoOffer2.DataTextField = "PromoOffer";
            ddlPromoOffer2.DataValueField = "PromoOfferID";
            ddlPromoOffer2.DataBind();


            try
            {
                ddlProjectType.DataSource = ProjectTypeManagement.tblProjectType_SelectActive();
                ddlProjectType.DataMember = "ProjectType";
                ddlProjectType.DataTextField = "ProjectType";
                ddlProjectType.DataValueField = "ProjectTypeID";
                ddlProjectType.DataBind();
            }

            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
            int Exist = ProjectsManagement.tblProjectsSalesInput_ProjectIDExists(ProjectID);
            if (Exist == 1)
            {
                ProjectsEntity Pt = ProjectsManagement.tblProjectsSalesInputByProjectID(ProjectID);
                txtFollowUpDate.Text = Pt.FollowUpDate.ToString("MM/dd/yyyy");
                txtManualQuoteNumber.Text = Pt.ManualQuoteNumber;
                ddlPanel.SelectedIndex = Pt.PanelBrandID;
                txtNoOfPanels.Text = Pt.NumberPanels.ToString();
                //ddlInverter1.SelectedIndex = Pt.InverterDetailsID;
                //ddlInverter2.SelectedIndex = Pt.SecondInverterDetailsID;
                txtInverterModel.Text = Pt.InverterModel;
                txtInverterCert1.Text = Pt.InverterCert;
                txtSystemCapacity.Text = Pt.SystemCapKW.ToString();

                txtPerKWCost.Text = Pt.SystemCapKW.ToString();
                txtBasicSystemCost.Text = Pt.BasicSystemCost.ToString();
                txtGST.Text = Pt.CGST.ToString();
                txtOtherCost.Text = Pt.OtherCost.ToString();
                txtSpecialDiscount.Text = Pt.SpecialDiscount.ToString();
                txtDepositRequired.Text = Pt.DepositRequired.ToString();
                ddlHouseType.SelectedIndex = Pt.HouseTypeID;
                ddlRoofType.SelectedIndex = Pt.RoofTypeID;
                txtRoofType.Text = Pt.VarRoofType.ToString();
                ddlRoofAngle.SelectedIndex = Pt.RoofAngleID;
                txtRoofAngle.Text = Pt.VarRoofAngle.ToString();
                txtMeterinst.Text = Pt.VarMeterInstallation.ToString();
                ddlMeterinst.SelectedIndex = Pt.MeterInstallation;
                txtMeterPhase.Text = Pt.MeterPhase.ToString();
                txtMeterNumber.Text = Pt.MeterNumber;
                chkOffPeak.Checked = Convert.ToBoolean(Pt.OffPeak);

                ddlElecDistributor.SelectedIndex = Pt.ElecDistributorID;
                chkMeterEnoughSpace.Checked = Convert.ToBoolean(Pt.MeterEnoughSpace);
                ddlElecRetailer.SelectedIndex = Pt.ElecRetailerID;
                txtSTCNumber.Text = Pt.STCNumber;
                txtPeakMeterNumber.Text = Pt.PeakMeterNumber;

                txtQuoteAccepted.Text = Pt.QuoteAccepted.ToString();
                txtRoofType.Text = Pt.VarRoofType.ToString();
                chkSignedQuote.Checked = Convert.ToBoolean(Pt.SignedQuote);
                txtQuoteSent.Text = Pt.QuoteSent.ToString();
                txtQuotationNotes.Text = Pt.QuotationNotes;
                txtProjectNotes.Text = Pt.ProjectNotes;
                chkMeterBoxPhotosSaved.Checked = Convert.ToBoolean(Pt.MeterBoxPhotosSaved.ToString());

                chkElecBillSaved.Checked = Convert.ToBoolean(Pt.ElecBillSaved);
                chkSiteMap.Checked = Convert.ToBoolean(Pt.SiteMap);
                chkPaymentReceipt.Checked = Convert.ToBoolean(Pt.PaymentReceipt);
                chkMeterApproval.Checked = Convert.ToBoolean(Pt.MeterApproval.ToString());
            }
        }

    }
}
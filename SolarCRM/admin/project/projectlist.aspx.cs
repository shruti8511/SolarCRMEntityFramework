using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SolarCRM.Entity.Models.EmployeeModule;
using SolarCRM.Entity.Models.CompanyModule;
using SolarCRM.BAL.Implementations.CompanyModule;
using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.BAL.Comman;
using SolarCRM.Common;
using SolarCRM.BAL.Implementations.ProjectModule;
using SolarCRM.Entity.Models.Common;
using SolarCRM.PagingUserControl;
using SolarCRM.Entity.Models.ProjectModule;
using SolarCRM.BAL.Implementations.StockModule;
using SolarCRM.Entity.Models.StockModule;
using System.IO;
using System.Configuration;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
using System.Globalization;


namespace SolarCRM.admin.project
{
    public partial class projectlist : System.Web.UI.Page
    {
        protected string SiteURL;
        static long ProjectID = 0;
        decimal BalanceCost = 0;
        decimal TotalCost = 0;


        protected void Page_Load(object sender, EventArgs e)
        {

            string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
            ProjectsEntity objrole = ProjectsManagement.GetRoleIDByUserID(userid);
            if (objrole.RoleName == "DSalesRep")
            {
                liins.Visible = false;
                liinvc.Visible = false;
                limntc.Visible = false;
                lidcms.Visible = false;
                lisip.Attributes.Add("class", "active");
            }
            else if (objrole.RoleName == "Accountant")
            {
                lidcms.Visible = false;
            }
            else if (objrole.RoleName == "Installer")
            {
                lisip.Visible = false;
                lifncc.Visible = false;
                liins.Visible = false;
                liinvc.Visible = false;
                limntc.Visible = false;
                liprtr.Visible = false;
            }
            else
            { }


            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;
            if (!IsPostBack)
            {
                Session["PageNo"] = 1;
                Session["PageSize"] = 10;
                BindProjectList();
            }
        }


        public void BindProjectElecInv()
        {
            ProjectsEntity st = ProjectsManagement.tblProjectsSalesInputByProjectID(ProjectID);
            if (Convert.ToString(st.InvoiceNumber) == string.Empty)
            {
                btnCreateInvoice.Visible = true;
                btnOpenInvoice.Visible = false;
            }
            else
            {
                btnCreateInvoice.Visible = false;
                btnOpenInvoice.Visible = true;
            }
        }



        protected void btnalert_Click(object sender, EventArgs e)
        {
            divAlert.Visible = false;
        }

        protected void btnSuccess_Click(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
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

                txtProjectOpend.Text = Pt.ProjectOpened.ToString("dd/MM/yyyy");

                txtPerKWCost.Text = Pt.PerKWCost.ToString("0.00");
                txtBasicSystemCost.Text = Pt.BasicSystemCost.ToString("0.00");
                txtGST.Text = Pt.CGST.ToString("0.00");
                txtOtherCost.Text = Pt.OtherCost.ToString("0.00");
                txtSpecialDiscount.Text = Pt.SpecialDiscount.ToString("0.00");
                txtDepositRequired.Text = Pt.DepositRequired.ToString("0.00");
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
                // txtTotalCost.Text = Convert.ToString(Pt.TotalQuotePrice);

                txtTotalCost.Text = Pt.TotalQuotePrice.ToString("0.00");

                decimal BaltoPay = ((Pt.TotalQuotePrice) - (Pt.DepositRequired));
                txtBaltoPay.Text = BaltoPay.ToString("0.00");
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

        public void BindProjectExpenses()
        {

            txtExpenDate.Text = DateTime.Now.ToString("MM/dd/yyyy");

            ddlExpense.DataSource = ExpensesManagement.tblExpenses_SelectForDropdown();
            ddlExpense.DataValueField = "ExpenseID";
            ddlExpense.DataTextField = "ExpenseName";
            ddlExpense.DataMember = "ExpenseName";
            ddlExpense.DataBind();

            BindExpenseList();



        }

        public void BindExpenseList()
        {
            List<ExpensesEntity> lstEntity = new List<ExpensesEntity>();
            lstEntity = ExpensesManagement.tblExpensesDescription_Select();
            //lstEntity = ExpensesManagement.tblExpensesDescription_SelectAll();
            for (int i = 0; i < lstEntity.Count; i++)
            {
                DateTime Expendate = lstEntity[i].ExpenseDate;
                //  int diffmin = (DateTime.Now - lstEntity[i].DateEntered).Minutes;
                int diffdays = (DateTime.Now - lstEntity[i].ExpenseDate).Days;
                int diffmonths = (diffdays % 365) / 31;
                int diffyears = diffdays / 365;
                if (diffdays == 0)
                {
                    lstEntity[i].Diff = " Today";
                }
                else if (diffdays > 365)
                {
                    lstEntity[i].Diff = diffyears.ToString() + "years ago";
                }
                else if (diffdays > 31)
                {
                    lstEntity[i].Diff = diffmonths.ToString() + "months ago";
                }
                else
                {
                    lstEntity[i].Diff = diffdays.ToString() + "days ago";
                }
                //string str = lstEntity[i].ExpenseDescription;

                //string[] splitString = str.Split(' ');
                //lstEntity[i].ExpenseName = splitString[0];
                //lstEntity[i].ExpenseDescription = splitString[1];
                //lstEntity[i].ExpenseCosting = splitString[3]; 

            }
            rpttimeline.DataSource = lstEntity;
            rpttimeline.DataBind();
        }

        //public void BindProjectInstallation()
        //{
        //    List<CompanyLocationsEntity> lstCompanyLocation = new List<CompanyLocationsEntity>();
        //    lstCompanyLocation = CompanyLocationsManagement.tblCompanyLocations_SelectActive();
        //    ddlStockAllocationStore.DataSource = lstCompanyLocation;
        //    ddlStockAllocationStore.DataValueField = "CompanyLocationID";
        //    ddlStockAllocationStore.DataMember = "CompanyLocation";
        //    ddlStockAllocationStore.DataTextField = "CompanyLocation";

        //    ddlStockAllocationStore.DataBind();

        //    List<RexStatus> lstRexStatus = new List<RexStatus>();
        //    lstRexStatus = RexStatusManagement.tblREXStatus_SelectASC();


        //    ddlRexStatus.DataSource = lstRexStatus;

        //    ddlRexStatus.DataValueField = "RexStatusID";
        //    ddlRexStatus.DataMember = "RexStatusABB";
        //    ddlRexStatus.DataTextField = "RexStatusABB";
        //    ddlRexStatus.DataBind();

        //    List<EmployeeEntity> Instemp = new List<EmployeeEntity>();
        //    Instemp = EmployeeManagement.tblEmployees_SelectInstaller();


        //    ddlInstaller.DataSource = Instemp;

        //    ddlInstaller.DataValueField = "UserId";
        //    ddlInstaller.DataMember = "fullname";
        //    ddlInstaller.DataTextField = "fullname";
        //    ddlInstaller.DataBind();

        //    List<EmployeeEntity> designemp = new List<EmployeeEntity>();
        //    designemp = EmployeeManagement.tblEmployees_SelectInstallerDesigner();

        //    ddlDesigner.DataSource = designemp;

        //    ddlDesigner.DataValueField = "UserId";
        //    ddlDesigner.DataMember = "fullname";
        //    ddlDesigner.DataTextField = "fullname";
        //    ddlDesigner.DataBind();


        //    List<EmployeeEntity> eleemp = new List<EmployeeEntity>();
        //    eleemp = EmployeeManagement.tblEmployees_SelectInstallerElectrician();

        //    ddlElectrician.DataSource = eleemp;

        //    ddlElectrician.DataValueField = "UserId";
        //    ddlElectrician.DataMember = "fullname";
        //    ddlElectrician.DataTextField = "fullname";
        //    ddlElectrician.DataBind();

        //    ProjectsEntity st2 = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);
        //    ProjectID = st2.ProjectID;

        //    //if (txtInstallBookDate.Text.Trim() != string.Empty)
        //    //{
        //    //    ProjectsEntity stPro = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);
        //    //    CustomersEntity ststate = CustomersManagement.tblCustomers_SelectByCustomerID(stPro.CustomerID);
        //    //    string date1 = txtInstallBookDate.Text.Trim();
        //    //    string date2 = Convert.ToString(Convert.ToDateTime(txtInstallBookDate.Text.Trim()).AddDays(Convert.ToInt32(txtdays.Text.Trim())));
        //    //    string InstallState = ststate.StreetState;

        //    //   if (st2.InstallerID.ToString() != string.Empty)
        //    //   {
        //    //       ddlInstaller.DataSource = EmployeeManagement.tblEmployees_SelectInstaller();
        //    //       //   ddlInstaller.DataSource = CustomersManagement.tblContacts_SelectAvailInstaller(date1, date2, InstallState, 0, st2.InstallerID.ToString());
        //    //   }
        //    //    else
        //    //    {
        //    //        ddlInstaller.DataSource = EmployeeManagement.tblEmployees_SelectInstaller();

        //    //     //  ddlInstaller.DataSource = CustomersManagement.tblContacts_SelectAvailInstaller(date1, date2, InstallState, 1, "0");
        //    //    }

        //    //   ddlInstaller.DataValueField = "UserId";
        //    //   ddlInstaller.DataMember = "EmpName";
        //    //   ddlInstaller.DataTextField = "EmpName";
        //    //   ddlInstaller.DataBind();
        //    //}
        //    //else
        //    //{
        //    //    ProjectsEntity stPro = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);
        //    //    ContactsEntity ststate = CustomersManagement.tblCustomers_SelectByCustType(intinstaller);
        //    //    string InstallState = ststate.StreetState;

        //    //    ddlInstaller.DataSource = CustomersManagement.tblContacts_SelectInstallerByState(InstallState);
        //    //    ddlInstaller.DataValueField = "ContactID";
        //    //    ddlInstaller.DataTextField = "Contact";
        //    //    ddlInstaller.DataMember = "Contact";
        //    //    ddlInstaller.DataBind();
        //    //}
        //    if (st2.MeterElecID.ToString() != string.Empty)
        //    {
        //        ProjectsEntity stPro = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);

        //        ContactsEntity stptd = CustomersManagement.tblContacts_SelectByContactID(st2.MeterElecID);
        //        string isactive = stptd.MeterElectrician.ToString();


        //        if (isactive == "False")
        //        {
        //            ddlMeterElec.DataSource = CustomersManagement.tblContacts_SelectMeterElectrician(0, stPro.MeterElecID.ToString());
        //        }
        //        else
        //        {
        //            ddlMeterElec.DataSource = CustomersManagement.tblContacts_SelectMeterElectrician(1, stPro.MeterElecID.ToString());
        //        }
        //    }
        //    else
        //    {
        //        ddlMeterElec.DataSource = CustomersManagement.tblContacts_SelectMeterElectrician(1, "0");
        //    }

        //    ddlMeterElec.DataValueField = "ContactID";
        //    ddlMeterElec.DataTextField = "Contact";
        //    ddlMeterElec.DataMember = "Contact";
        //    ddlMeterElec.DataBind();



        //    //if (st2.DesignerID.ToString() != string.Empty)
        //    //{
        //    //    ContactsEntity stptd = CustomersManagement.tblContacts_SelectByContactID(st2.DesignerID);
        //    //    string isactive = stptd.Designer.ToString();


        //    //    if (isactive == "False")
        //    //    {
        //    //        ddlDesigner.DataSource = CustomersManagement.tblContacts_SelectDesigner(0, st2.DesignerID.ToString());
        //    //    }
        //    //    else
        //    //    {
        //    //        ddlDesigner.DataSource = CustomersManagement.tblContacts_SelectDesigner(1, st2.DesignerID.ToString());
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    ddlDesigner.DataSource = CustomersManagement.tblContacts_SelectDesigner(1, "0");
        //    //}

        //    //ddlDesigner.DataValueField = "ContactID";
        //    //ddlDesigner.DataTextField = "Contact";
        //    //ddlDesigner.DataMember = "Contact";
        //    //ddlDesigner.DataBind();

        //    //if (st2.ElectricianID.ToString() != string.Empty)
        //    //{
        //    //    ContactsEntity stptd = CustomersManagement.tblContacts_SelectByContactID(st2.ElectricianID);
        //    //    string isactive = stptd.Electrician.ToString();


        //    //    if (isactive == "False")
        //    //    {
        //    //        ddlElectrician.DataSource = CustomersManagement.tblContacts_SelectElectrician(0, st2.ElectricianID.ToString());
        //    //    }
        //    //    else
        //    //    {
        //    //        ddlElectrician.DataSource = CustomersManagement.tblContacts_SelectElectrician(1, st2.ElectricianID.ToString());
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    ddlElectrician.DataSource = CustomersManagement.tblContacts_SelectElectrician(1, "0");
        //    //}

        //    //ddlElectrician.DataValueField = "ContactID";
        //    //ddlElectrician.DataTextField = "Contact";
        //    //ddlElectrician.DataMember = "Contact";
        //    //ddlElectrician.DataBind();
        //    if (Roles.IsUserInRole("Sales Manager") || Roles.IsUserInRole("DSales Manager"))
        //    {
        //        ddlSTC.DataSource = EmployeeManagement.tblEmployees_ManagerSelect(st2.SalesRep);
        //    }
        //    else
        //    {
        //        if (st2.STCCheckedByID.ToString() != string.Empty)
        //        {
        //            EmployeeEntity stptd = EmployeeManagement.tblEmployees_SelectActiveByEmployeeID(st2.STCCheckedByID);
        //            string isactive = stptd.ActiveEmp.ToString();


        //            if (isactive == "False")
        //            {
        //                ddlSTC.DataSource = EmployeeManagement.tblEmployees_SelectASC(st2.STCCheckedByID, 0);
        //            }
        //            else
        //            {
        //                ddlSTC.DataSource = EmployeeManagement.tblEmployees_SelectASC(st2.STCCheckedByID, 1);
        //            }
        //        }
        //        else
        //        {
        //            ddlSTC.DataSource = EmployeeManagement.tblEmployees_SelectASC(0, 1);
        //        }
        //    }
        //    //ddlSTCCheckedBy.DataSource = ClstblEmployees.tblEmployees_SelectASC();
        //    ddlSTC.DataValueField = "EmployeeID";
        //    ddlSTC.DataMember = "fullname";
        //    ddlSTC.DataTextField = "fullname";
        //    ddlSTC.DataBind();

        //    if (st2.SpecialPurposeID.ToString() != string.Empty)
        //    {
        //        SpecialPurposeEntity stptd = SpecialPurposeManagement.tblSpecialPurpose_SelectBySpecialPurposeID(st2.SpecialPurposeID);
        //        string isactive = stptd.Active.ToString();


        //        if (isactive == "False")
        //        {
        //            ddlSpecialPurpose.DataSource = SpecialPurposeManagement.tblSpecialPurpose_SelectActive(0, st2.SpecialPurposeID.ToString());
        //        }
        //        else
        //        {
        //            ddlSpecialPurpose.DataSource = SpecialPurposeManagement.tblSpecialPurpose_SelectActive(1, st2.SpecialPurposeID.ToString());
        //        }
        //    }
        //    else
        //    {
        //        ddlSpecialPurpose.DataSource = SpecialPurposeManagement.tblSpecialPurpose_SelectActive(1, "0");
        //    }

        //    ddlSpecialPurpose.DataValueField = "SpecialPurposeID";
        //    ddlSpecialPurpose.DataTextField = "SpecialPurpose";
        //    ddlSpecialPurpose.DataMember = "SpecialPurpose";
        //    ddlSpecialPurpose.DataBind();
        //    if (st2.InstallationIssueID.ToString() != string.Empty)
        //    {
        //        JobStatusEntity stptd = JobStatusManagement.tblJobStatus_SelectByJobStatusID(st2.InstallationIssueID);
        //        string isactive = stptd.Active.ToString();
        //        if (isactive == "False")
        //        {
        //            ddlInstallationIssue.DataSource = InstallationIssueManagement.tblInstallationIssue_SelectActive(0, st2.InstallationIssueID);
        //        }
        //        else
        //        {
        //            ddlInstallationIssue.DataSource = InstallationIssueManagement.tblInstallationIssue_SelectActive(1, st2.InstallationIssueID);
        //        }
        //    }
        //    else
        //    {
        //        ddlInstallationIssue.DataSource = InstallationIssueManagement.tblInstallationIssue_SelectActive(1, 0);
        //    }
        //    ddlInstallationIssue.DataValueField = "InstallationIssueID";
        //    ddlInstallationIssue.DataTextField = "InstallationIssue";
        //    ddlInstallationIssue.DataMember = "InstallationIssue";
        //    ddlInstallationIssue.DataBind();


        //    if (st2.STCAppliedByID.ToString() != string.Empty)
        //    {
        //        EmployeeEntity stptd = EmployeeManagement.tblEmployees_SelectActiveByEmployeeID(st2.STCAppliedByID);
        //        string isactive = stptd.Active.ToString();


        //        if (isactive == "False")
        //        {
        //            ddlSTCAppliedBy.DataSource = EmployeeManagement.tblEmployees_SelectASC(st2.STCAppliedByID, 0);
        //        }
        //        else
        //        {
        //            ddlSTCAppliedBy.DataSource = EmployeeManagement.tblEmployees_SelectASC(st2.STCAppliedByID, 1);
        //        }
        //    }
        //    else
        //    {
        //        ddlSTCAppliedBy.DataSource = EmployeeManagement.tblEmployees_SelectASC(0, 1);
        //    }

        //    ddlSTCAppliedBy.DataValueField = "EmployeeID";
        //    ddlSTCAppliedBy.DataMember = "fullname";
        //    ddlSTCAppliedBy.DataTextField = "fullname";
        //    ddlSTCAppliedBy.DataBind();


        //    if (st2.PVDStatusID.ToString() != string.Empty)
        //    {
        //        PVDStatusEntity stptd = PVDStatusManagement.tblPVDStatus_SelectByPVDStatusID(st2.PVDStatusID);
        //        string isactive = stptd.Active.ToString();


        //        if (isactive == "False")
        //        {
        //            ddlPVDStatus.DataSource = PVDStatusManagement.tblPVDStatus_SelectActive(0, st2.PVDStatusID);
        //        }
        //        else
        //        {
        //            ddlPVDStatus.DataSource = PVDStatusManagement.tblPVDStatus_SelectActive(1, st2.PVDStatusID);
        //        }
        //    }
        //    else
        //    {
        //        ddlPVDStatus.DataSource = PVDStatusManagement.tblPVDStatus_SelectActive(1, 0);
        //    }

        //    ddlPVDStatus.DataValueField = "PVDStatusID";
        //    ddlPVDStatus.DataMember = "PVDStatus";
        //    ddlPVDStatus.DataTextField = "PVDStatus";
        //    ddlPVDStatus.DataBind();

        //    int Exist = ProjectsManagement.tblProjectsInstallation_ProjectIDExists(ProjectID);
        //    if (Exist == 1)
        //    {
        //        ProjectsEntity Pt = ProjectsManagement.tblProjectsInstallationByProjectID(ProjectID);
        //        txtMeterApplied.Text = Pt.MeterAppliedDate.ToString("MM/dd/yyyy");
        //        txtMeterApplyRef.Text = Pt.MeterApplyRef;
        //        txtMeterApproval.Text = Pt.MeterApprovalDate.ToString("MM/dd/yyyy");
        //        txtMeterApprovalRef.Text = Pt.MeterApprovalRef;
        //        txtRexApplied.Text = Pt.RexAppliedDate.ToString("MM/dd/yyyy");
        //        txtRexAppliedRef.Text = Pt.RexAppliedRef;
        //        ddlRexStatus.SelectedIndex = Convert.ToInt32(Pt.RexStatusID);             
        //        txtPanelModel.Text = Pt.PanelModel;
        //        txtNoOfPanel.Text = Pt.NumberPanels.ToString();
        //        txtInvModel.Text = Pt.InverterModel;
        //        txtNoOfInv.Text = Pt.NoOfInverter;
        //        ddlMeterType.SelectedIndex = Convert.ToInt32(Pt.MeterType);
        //        chkcustnotmeter.Checked = Convert.ToBoolean(Pt.CustomerNotifiedMeter);
        //        txtInitialInstallDate.Text = Pt.InitialInstallDate.ToString("MM/dd/yyyy");
        //        txtInstallBookDate.Text = Pt.InstallBookingDate.ToString("MM/dd/yyyy");
        //        txtdays.Text = Pt.Days.ToString();
        //        ddlInstaller.SelectedIndex = Convert.ToInt32(Pt.InstallerID);
        //        ddlDesigner.SelectedIndex = Convert.ToInt32(Pt.DesignerID);
        //        ddlElectrician.SelectedIndex = Convert.ToInt32(Pt.ElectricianID);
        //        txtInstallerNotified.Text = Pt.InstallerNotifiedDate.ToString("MM/dd/yyyy");
        //        ddlInstallationIssue.SelectedIndex = Convert.ToInt32(Pt.InstallationIssueID);
        //        ddlStockAllocationStore.SelectedIndex = Convert.ToInt32(Pt.StockAllocationStoreID);
        //        ddlSpecialPurpose.SelectedIndex = Convert.ToInt32(Pt.SpecialPurposeID);
        //        txtInstallComplete.Text = Pt.InstallationCompletionDate.ToString("MM/dd/yyyy");
        //        txtInstallVerifiedBy.Text = Pt.InstallationVerifiedBy;
        //        txtInstallDocsRec.Text = Pt.InstallDocsRec.ToString("MM/dd/yyyy");
        //        chkinsconfdayprior.Checked = Convert.ToBoolean(Pt.InstallationConfirmed);
        //        chkSTC.Checked = Convert.ToBoolean(Pt.STCChecked);
        //        ddlSTC.SelectedIndex = Convert.ToInt32(Pt.STCCheckedByID);
        //        txtCertificateIssued.Text = Pt.CertificateIssuedDate.ToString("MM/dd/yyyy");
        //        txtInvSerialNo.Text = Pt.INVSerialNo;
        //        txtInvSerialNo2.Text = Pt.INVSerialNo2;
        //        ddlMeterElec.SelectedIndex = Convert.ToInt32(Pt.MeterElecID);
        //        txtMtrInstDocs.Text = Pt.MeterInstallationDocSent.ToString("MM/dd/yyyy");
        //        txtMeterJobBooked.Text = Pt.MeterJobBooked.ToString("MM/dd/yyyy");
        //        txtMeterCompleted.Text = Pt.MeterCompleted.ToString("MM/dd/yyyy");
        //        chkCCEW.Checked = Convert.ToBoolean(Pt.CCEW);
        //        chkstcformsaved.Checked = Convert.ToBoolean(Pt.STCFormSaved);
        //        chkCertificateSaved.Checked = Convert.ToBoolean(Pt.CertificateSaved);
        //        chkAdditionalSystem.Checked = Convert.ToBoolean(Pt.AdditionalSystem);
        //        chkOwnerGSTReg.Checked = Convert.ToBoolean(Pt.OwnerGSTReg);
        //        txtCompanyABN.Text = Pt.CompanyABNName;
        //        chknewmodelpanel.Checked = Convert.ToBoolean(Pt.NewModelPanel);
        //        chkNewModelInv.Checked = Convert.ToBoolean(Pt.NewModelINV);
        //        txtSTCAppliedDate.Text = Pt.STCAppliedDate.ToString("MM/dd/yyyy");
        //        txtSTCUploadNumber.Text = Pt.STCUploadNumber;
        //        txtPVDNumber.Text = Pt.PVDNumber;
        //        ddlPVDStatus.SelectedIndex = Convert.ToInt32(Pt.PVDStatusID);
        //        ddlSTCAppliedBy.SelectedIndex = Convert.ToInt32(Pt.STCAppliedByID);

        //    }
        //}

        protected void btnCancelSalesInout_Click(object sender, EventArgs e)
        {
            BindProjectDetails();
        }

        //protected void btnsaveinstallation_Click(object sender, EventArgs e)
        //{

        //    ProjectsEntity st = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);
        //    CustomersEntity stCust = CustomersManagement.tblCustomers_SelectByCustomerID(st.CustomerID);
        //    ProjectsEntity ProjectEntity = new ProjectsEntity();

        //    ProjectEntity.ProjectID = ProjectID;
        //    ProjectEntity.MeterAppliedDate = Convert.ToDateTime(DateTime.Parse((txtMeterApplied.Text), new CultureInfo("en-US", true)));
        //    ProjectEntity.MeterApplyRef = txtMeterApplyRef.Text;
        //    ProjectEntity.MeterApprovalDate = Convert.ToDateTime(DateTime.Parse((txtMeterApproval.Text), new CultureInfo("en-US", true)));
        //    ProjectEntity.MeterApprovalRef = txtMeterApprovalRef.Text;
        //    ProjectEntity.RexAppliedDate = Convert.ToDateTime(DateTime.Parse((txtRexApplied.Text), new CultureInfo("en-US", true)));
        //    ProjectEntity.RexAppliedRef = txtRexAppliedRef.Text;
        //    ProjectEntity.RexStatusID = Convert.ToInt32(ddlRexStatus.SelectedIndex);
        //    ProjectEntity.PanelModel = txtPanelModel.Text;
        //    ProjectEntity.NumberPanels = Convert.ToInt32(txtNoOfPanel.Text);
        //    ProjectEntity.InverterModel = txtInverterModel.Text;
        //    ProjectEntity.NoOfInverter = txtNoOfInv.Text;
        //    ProjectEntity.CustomerNotifiedMeter = chkcustnotmeter.Checked;
        //    ProjectEntity.MeterType = Convert.ToInt32(ddlMeterType.SelectedIndex);
        //    ProjectEntity.InitialInstallDate = Convert.ToDateTime(DateTime.Parse((txtInitialInstallDate.Text), new CultureInfo("en-US", true)));
        //    ProjectEntity.InstallBookingDate = Convert.ToDateTime(DateTime.Parse((txtInstallBookDate.Text), new CultureInfo("en-US", true)));
        //    ProjectEntity.Days = Convert.ToInt32(txtdays.Text);
        //    ProjectEntity.InstallerIDs = ddlInstaller.SelectedIndex.ToString();
        //    ProjectEntity.DesignerIDs = ddlDesigner.SelectedIndex.ToString();
        //    ProjectEntity.ElectricianIDs = ddlElectrician.SelectedIndex.ToString();
        //    ProjectEntity.InstallerNotifiedDate = Convert.ToDateTime(DateTime.Parse((txtInstallerNotified.Text), new CultureInfo("en-US", true)));
        //    ProjectEntity.InstallationIssueID = Convert.ToInt32(ddlInstaller.SelectedIndex);
        //    ProjectEntity.StockAllocationStoreID = Convert.ToInt32(ddlStockAllocationStore.SelectedIndex);
        //    ProjectEntity.SpecialPurposeID = Convert.ToInt32(ddlSpecialPurpose.SelectedIndex);
        //    ProjectEntity.InstallationCompletionDate = Convert.ToDateTime(DateTime.Parse((txtInstallComplete.Text), new CultureInfo("en-US", true)));
        //    ProjectEntity.InstallationVerifiedBy = txtInstallVerifiedBy.Text;
        //    ProjectEntity.InstallDocsRec = Convert.ToDateTime(DateTime.Parse((txtInstallDocsRec.Text), new CultureInfo("en-US", true)));
        //    ProjectEntity.InstallationConfirmed = chkinsconfdayprior.Checked;
        //    ProjectEntity.STCChecked = chkSTC.Checked;
        //    ProjectEntity.STCCheckedByID = Convert.ToInt32(ddlSTC.SelectedIndex);
        //    ProjectEntity.CertificateIssuedDate = Convert.ToDateTime(DateTime.Parse((txtCertificateIssued.Text), new CultureInfo("en-US", true)));
        //    ProjectEntity.INVSerialNo = txtInvSerialNo.Text;
        //    ProjectEntity.INVSerialNo2 = txtInvSerialNo2.Text;
        //    ProjectEntity.MeterElecID = Convert.ToInt32(ddlMeterElec.SelectedIndex);
        //    ProjectEntity.MeterInstallationDocSent = Convert.ToDateTime(DateTime.Parse((txtMtrInstDocs.Text), new CultureInfo("en-US", true)));
        //    ProjectEntity.MeterJobBooked = Convert.ToDateTime(DateTime.Parse((txtMeterJobBooked.Text), new CultureInfo("en-US", true)));
        //    ProjectEntity.MeterCompleted = Convert.ToDateTime(DateTime.Parse((txtMeterCompleted.Text), new CultureInfo("en-US", true)));
        //    ProjectEntity.CCEW = chkCCEW.Checked;
        //    ProjectEntity.STCFormSaved = chkstcformsaved.Checked;
        //    ProjectEntity.CertificateSaved = chkCertificateSaved.Checked;
        //    ProjectEntity.AdditionalSystem = chkAdditionalSystem.Checked;
        //    ProjectEntity.OwnerGSTReg = chkOwnerGSTReg.Checked;
        //    ProjectEntity.NewModelPanel = chkNewModelPanel1.Checked;
        //    ProjectEntity.NewModelINV = chkNewModelInv.Checked;
        //    ProjectEntity.CompanyABNName = txtCompanyABN.Text;
        //    ProjectEntity.STCAppliedDate = Convert.ToDateTime(DateTime.Parse((txtSTCAppliedDate.Text), new CultureInfo("en-US", true)));
        //    ProjectEntity.STCUploadNumber = txtSTCUploadNumber.Text;
        //    ProjectEntity.PVDNumber = txtPVDNumber.Text;
        //    ProjectEntity.PVDStatusID = Convert.ToInt32(ddlPVDStatus.SelectedIndex);
        //    ProjectEntity.STCAppliedByID = Convert.ToInt32(ddlSTCAppliedBy.SelectedIndex);

        //    int Exist = ProjectsManagement.tblProjectsInstallation_ProjectIDExists(ProjectID);
        //    if (Exist == 0)
        //    {
        //        ProjectsManagement.tblProjectsInstallation_Insert(ProjectEntity);
        //        divSuccess.Visible = true;
        //        divAlert.Visible = false;
        //        lblSuccessMsg.Text = " Installation Added Successfully";
        //    }
        //    else
        //    {
        //        ProjectsManagement.tblProjectsInstallation_Update(ProjectEntity);
        //        divSuccess.Visible = true;
        //        divAlert.Visible = false;
        //        lblSuccessMsg.Text = "Installation Updated Successfully";
        //    }
        //}

        //protected void btncnclinstallation_Click(object sender, EventArgs e)
        //{
        //    BindProjectInstallation();
        //}

        //protected void ddlInstaller_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlInstaller.SelectedValue != string.Empty)
        //    {
        //        List<ContactsEntity> lstcontact = new List<ContactsEntity>();
        //   lstcontact = CustomersManagement.tblContacts_SelectDesignerByContactID(ddlInstaller.SelectedIndex);
        //        ddlStockAllocationStore.DataSource = lstcontact;
        //        if (lstcontact.Count > 0)
        //        {
        //            ddlDesigner.SelectedValue = ddlInstaller.SelectedValue;
        //        }
        //        else
        //        {
        //            ddlDesigner.SelectedValue = "";
        //        }
        //        List<ContactsEntity> lstcontact1 = new List<ContactsEntity>();
        //        lstcontact1 = CustomersManagement.tblContacts_SelectElectricianByContactID(ddlInstaller.SelectedIndex);
        //        if (lstcontact1.Count > 0)
        //        {
        //            ddlElectrician.SelectedValue = ddlInstaller.SelectedValue;
        //        }
        //        else
        //        {
        //            ddlElectrician.SelectedValue = "";
        //        }
        //    }
        //    else
        //    {
        //        ddlDesigner.SelectedValue = "";
        //        ddlElectrician.SelectedValue = "";
        //    }

        //}
        //public void BindDropDown()
        //{

        //    ProjectsEntity st2 = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);

        //    if (st2.ProjectMgr != null)
        //    {

        //        EmployeeEntity stpm = EmployeeManagement.tblEmployees_SelectActiveByEmployeeID(st2.ProjectMgr);
        //        string isactive = Convert.ToString(stpm.ActiveEmp);


        //        if (isactive == "False")
        //        {
        //            ddlProjectMgr.DataSource = EmployeeManagement.tblEmployees_SelectASC(st2.ProjectMgr, 0);
        //        }


        //        else
        //        {
        //            ddlProjectMgr.DataSource = EmployeeManagement.tblEmployees_SelectASC(st2.ProjectMgr, 1);
        //        }
        //    }
        //    else
        //    {
        //        ddlProjectMgr.DataSource = EmployeeManagement.tblEmployees_SelectASC(0, 1);
        //    }
        //    ddlProjectMgr.DataValueField = "EmployeeID";
        //    ddlProjectMgr.DataTextField = "fullname";
        //    ddlProjectMgr.DataMember = "fullname";
        //    ddlProjectMgr.DataBind();

        //    if (st2.SalesRep != null)
        //    {

        //        EmployeeEntity stpm = EmployeeManagement.tblEmployees_SelectActiveByEmployeeID(st2.SalesRep);
        //        string isactive = Convert.ToString(stpm.ActiveEmp);


        //        if (isactive == "False")
        //        {
        //            ddlSalesRep.DataSource = EmployeeManagement.tblEmployees_SelectASC(st2.SalesRep, 0);
        //        }


        //        else
        //        {
        //            ddlSalesRep.DataSource = EmployeeManagement.tblEmployees_SelectASC(st2.SalesRep, 1);
        //        }
        //    }
        //    else
        //    {
        //        ddlSalesRep.DataSource = EmployeeManagement.tblEmployees_SelectASC(0, 1);
        //    }
        //    ddlSalesRep.DataValueField = "EmployeeID";
        //    ddlSalesRep.DataTextField = "fullname";
        //    ddlSalesRep.DataMember = "fullname";
        //    ddlSalesRep.DataBind();


        //    ddlContact.DataSource = CustomersManagement.tblContacts_SelectByCustId(st2.CustomerID);
        //    ddlContact.DataValueField = "ContactID";
        //    ddlContact.DataTextField = "FullName";
        //    ddlContact.DataMember = "FullName";
        //    ddlContact.DataBind();


        //    //ListItem item16 = new ListItem();
        //    //item16.Text = "Select";
        //    //item16.Value = "";
        //    //ddlPanel.Items.Clear();
        //    //ddlPanel.Items.Add(item16);
        //    //ddlPanel.DataSource = StockManagement.tblStockItems_SelectPanel();
        //    //ddlPanel.DataValueField = "StockItemID";
        //    //ddlPanel.DataMember = "StockItem";
        //    //ddlPanel.DataTextField = "StockItem";
        //    //ddlPanel.DataBind();




        //    ddlPanel.DataSource = StockManagement.tblStockItems_SelectPanel();
        //    ddlPanel.DataMember = "StockItem";
        //    ddlPanel.DataTextField = "StockItem";
        //    ddlPanel.DataValueField = "StockItemID";
        //    ddlPanel.DataBind();


        //    ddlInverter1.DataSource = StockManagement.tblStockItems_SelectInverter();
        //    ddlInverter1.DataMember = "StockItem";
        //    ddlInverter1.DataTextField = "StockItem";
        //    ddlInverter1.DataValueField = "StockItemID";
        //    ddlInverter1.DataBind();

        //    ddlInverter2.DataSource = StockManagement.tblStockItems_SelectInverter();
        //    ddlInverter2.DataMember = "StockItem";
        //    ddlInverter2.DataTextField = "StockItem";
        //    ddlInverter2.DataValueField = "StockItemID";
        //    ddlInverter2.DataBind();



        //    ddlHouseType.DataSource = HouseTypeManagement.tblHouseType_SelectASC();
        //    ddlHouseType.DataMember = "HouseType";
        //    ddlHouseType.DataTextField = "HouseType";
        //    ddlHouseType.DataValueField = "HouseTypeID";
        //    ddlHouseType.DataBind();


        //    ddlRoofType.DataSource = RoofTypeManagement.tblRoofType_SelectASC();
        //    ddlRoofType.DataMember = "RoofType";
        //    ddlRoofType.DataTextField = "RoofType";
        //    ddlRoofType.DataValueField = "RoofTypeID";
        //    ddlRoofType.DataBind();

        //    ddlRoofAngle.DataSource = RoofAngleManagement.tblRoofAngle_SelectASC();
        //    ddlRoofAngle.DataMember = "RoofAngle";
        //    ddlRoofAngle.DataTextField = "RoofAngle";
        //    ddlRoofAngle.DataValueField = "RoofAngleID";
        //    ddlRoofAngle.DataBind();

        //    ddlElecDistributor.DataSource = ElecDistributorManagement.tblElecDistributor_SelectActive();
        //    ddlElecDistributor.DataMember = "ElecDistributor";
        //    ddlElecDistributor.DataTextField = "ElecDistributor";
        //    ddlElecDistributor.DataValueField = "ElecDistributorID";
        //    ddlElecDistributor.DataBind();

        //    ddlElecRetailer.DataSource = ElecRetailerManagement.tblElecRetailer_SelectASC();
        //    ddlElecRetailer.DataMember = "ElecRetailer";
        //    ddlElecRetailer.DataTextField = "ElecRetailer";
        //    ddlElecRetailer.DataValueField = "ElecRetailerID";
        //    ddlElecRetailer.DataBind();

        //    ddlPromoOffer.DataSource = PromoOfferManagement.tblPromoOffer_SelectActive();
        //    ddlPromoOffer.DataMember = "PromoOffer";
        //    ddlPromoOffer.DataTextField = "PromoOffer";
        //    ddlPromoOffer.DataValueField = "PromoOfferID";
        //    ddlPromoOffer.DataBind();

        //    ddlPromoOffer2.DataSource = PromoOfferManagement.tblPromoOffer_SelectActive();
        //    ddlPromoOffer2.DataMember = "PromoOffer";
        //    ddlPromoOffer2.DataTextField = "PromoOffer";
        //    ddlPromoOffer2.DataValueField = "PromoOfferID";
        //    ddlPromoOffer2.DataBind();


        //    try
        //    {
        //        ddlProjectType.DataSource = ProjectTypeManagement.tblProjectType_SelectActive();
        //        ddlProjectType.DataMember = "ProjectType";
        //        ddlProjectType.DataTextField = "ProjectType";
        //        ddlProjectType.DataValueField = "ProjectTypeID";
        //        ddlProjectType.DataBind();
        //    }

        //    catch (Exception ex)
        //    {
        //        divSuccess.Visible = false;
        //        divAlert.Visible = true;
        //        lblErrorMsg.Text = "Error : " + ex.Message;
        //    }
        //    int Exist = ProjectsManagement.tblProjectsSalesInput_ProjectIDExists(ProjectID);
        //    if (Exist == 1)
        //    {
        //        ProjectsEntity Pt = ProjectsManagement.tblProjectsSalesInputByProjectID(ProjectID);
        //        txtFollowUpDate.Text = Pt.FollowUpDate.ToString("MM/dd/yyyy");
        //        txtManualQuoteNumber.Text = Pt.ManualQuoteNumber;
        //        ddlPanel.SelectedIndex = Pt.PanelBrandID;
        //        txtNoOfPanels.Text = Pt.NumberPanels.ToString();
        //        //ddlInverter1.SelectedIndex = Convert.ToInt32(Pt.InverterDetailsID);
        //        //ddlInverter2.SelectedIndex = Pt.SecondInverterDetailsID;
        //        txtInverterModel.Text = Pt.InverterModel;
        //        txtInverterCert1.Text = Pt.InverterCert;
        //        txtSystemCapacity.Text = Pt.SystemCapKW.ToString();

        //        txtPerKWCost.Text = Pt.PerKWCost.ToString();
        //        txtBasicSystemCost.Text = Pt.BasicSystemCost.ToString();
        //        txtGST.Text = Pt.CGST.ToString();
        //        txtOtherCost.Text = Pt.OtherCost.ToString();
        //        txtSpecialDiscount.Text = Pt.SpecialDiscount.ToString();


        //        txtDepositRequired.Text = Pt.DepositRequired.ToString();





        //        ddlHouseType.SelectedIndex = Pt.HouseTypeID;
        //        ddlRoofType.SelectedIndex = Pt.RoofTypeID;
        //        txtRoofType.Text = Pt.VarRoofType.ToString();
        //        ddlRoofAngle.SelectedIndex = Pt.RoofAngleID;
        //        txtRoofAngle.Text = Pt.VarRoofAngle.ToString();
        //        txtMeterinst.Text = Pt.VarMeterInstallation.ToString();
        //        ddlMeterinst.SelectedIndex = Pt.MeterInstallation;
        //        txtMeterPhase.Text = Pt.MeterPhase.ToString();
        //        txtMeterNumber.Text = Pt.MeterNumber;
        //        chkOffPeak.Checked = Convert.ToBoolean(Pt.OffPeak);

        //        ddlElecDistributor.SelectedIndex = Pt.ElecDistributorID;
        //        chkMeterEnoughSpace.Checked = Convert.ToBoolean(Pt.MeterEnoughSpace);
        //        ddlElecRetailer.SelectedIndex = Pt.ElecRetailerID;
        //        txtSTCNumber.Text = Pt.STCNumber;
        //        txtPeakMeterNumber.Text = Pt.PeakMeterNumber;

        //        txtTotalCost.Text =Convert.ToString(Pt.TotalQuotePrice);

        //        decimal BaltoPay = ((Pt.TotalQuotePrice) - (Pt.DepositRequired));
        //        txtBaltoPay.Text = BaltoPay.ToString();


        //        txtQuoteAccepted.Text = Pt.QuoteAccepted.ToString();
        //        txtRoofType.Text = Pt.VarRoofType.ToString();
        //        chkSignedQuote.Checked = Convert.ToBoolean(Pt.SignedQuote);
        //        txtQuoteSent.Text = Pt.QuoteSent.ToString("dd/MM/yyyy");
        //        txtQuotationNotes.Text = Pt.QuotationNotes;
        //        txtProjectNotes.Text = Pt.ProjectNotes;
        //        chkMeterBoxPhotosSaved.Checked = Convert.ToBoolean(Pt.MeterBoxPhotosSaved.ToString());

        //        chkElecBillSaved.Checked = Convert.ToBoolean(Pt.ElecBillSaved);
        //        chkSiteMap.Checked = Convert.ToBoolean(Pt.SiteMap);
        //        chkPaymentReceipt.Checked = Convert.ToBoolean(Pt.PaymentReceipt);
        //        chkMeterApproval.Checked = Convert.ToBoolean(Pt.MeterApproval.ToString());
        //    }
        //}


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

        public void BindProjectList()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<ProjectsEntity> lstEntity = new List<ProjectsEntity>();
                lstEntity = ProjectsManagement.tblProjects_Select(objCommon, out Count);
                rptProjectlist.DataSource = lstEntity;
                rptProjectlist.DataBind();
                pageGrid.BindPageing(Count);

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }


        }

        //protected void ddlInstaller_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    string userid = ddlInstaller.SelectedValue;
        //    if (ddlInstaller.SelectedValue != string.Empty)
        //    {
        //        List<EmployeeEntity> lstElectrician = new List<EmployeeEntity>();
        //        lstElectrician = EmployeeManagement.tblEmployees_CheckInstElectrician(userid);
        //        if (lstElectrician.Count > 0)
        //        {
        //            ddlElectrician.SelectedValue = ddlInstaller.SelectedValue;
        //        }
        //        else
        //        {
        //            ddlElectrician.SelectedValue = "";
        //        }
        //        List<EmployeeEntity> lstDesigner = new List<EmployeeEntity>();
        //        lstDesigner = EmployeeManagement.tblEmployees_CheckInstDesigner(userid);
        //        ddlStockAllocationStore.DataSource = lstDesigner;
        //        if (lstDesigner.Count > 0)
        //        {
        //            ddlDesigner.SelectedValue = ddlInstaller.SelectedValue;
        //        }
        //        else
        //        {
        //            ddlDesigner.SelectedValue = "";
        //        }
        //        InstTab();
        //        //liins.Attributes.Add("class", "active");

        //    }


        //}




        public void BindQuote()
        {
            List<ProjectsEntity> lstEntity = new List<ProjectsEntity>();
            lstEntity = ProjectsManagement.tblProjectQuotes_SelectByProjectID(ProjectID);
            rptQuote.DataSource = lstEntity;
            rptQuote.DataBind();


            if (lstEntity.Count > 0)
            {
                btnCreateInvoice.Enabled = true;
            }
            else
            {
                btnCreateInvoice.Enabled = false;
            }
        }

        public void BindProjectListSearch()
        {
            try
            {
                Session["pager"] = 1;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<ProjectsEntity> lstEntity = new List<ProjectsEntity>();
                lstEntity = ProjectsManagement.tblProjects_SelectSearch(objCommon, txtSearch.Text.Trim(), out Count);
                rptProjectlist.DataSource = lstEntity;
                rptProjectlist.DataBind();
                pageGrid.BindPageing(Count);
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }



        protected void rptProjectlist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName.ToString() == "Detail")
            {
                try
                {

                    //if (Request.QueryString["projectid"] != null)
                    // {
                    try
                    {
                        divprojectdetails.Visible = true;
                        divprojectlist.Visible = false;
                        ProjectID = Convert.ToInt64(e.CommandArgument);
                        BindProjectDetails();
                        BindProjectInstallation();
                        BindProjectExpenses();
                        BindProjectTeam();
                        BindProjectTeamList();
                        BindProjectElecInv();

                    }
                    catch (Exception ex)
                    {
                        divSuccess.Visible = false;
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Error : " + ex.Message;
                    }
                    //   }


                    BindQuote();

                    //BindSummary(CustomerID);




                    //BindContactList(CustomerID);

                    //BindAddNewProjectDetails(CustomerID);

                    //BindProjectsList(CustomerID);

                    //BindFollowUps(CustomerID);

                    //ddlContacts.DataSource = CustomersManagement.tblContacts_SelectByCustomerID(CustomerID);
                    //ddlContacts.DataValueField = "ContactID";
                    //ddlContacts.DataTextField = "FullName";
                    //ddlContacts.DataMember = "FullName";
                    //ddlContacts.DataBind();

                }
                catch (Exception ex)
                {
                    divSuccess.Visible = false;
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "Error : " + ex.Message;
                }
            }
        }

        protected void rptProjectlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindProjectList();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Session["PageNo"] = 1;
            txtSearch.Text = "";
            BindProjectList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            Session["PageNo"] = 1;
            BindProjectListSearch();
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
            BindQuote();
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
               // Server.Execute("~/mailtemplate/UREQuotationheader.aspx", txtWriter);

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


     




        public static bool UploadPDFFile(string foldername, string filename)
        {
            GC.Collect();
            string username = ConfigurationManager.AppSettings["ClaudUsername"];
            string api_key = ConfigurationManager.AppSettings["ClaudKey"];
            string chosenContainer = ConfigurationManager.AppSettings["ClaudContainer"];
            string filePath = HttpContext.Current.Request.PhysicalApplicationPath + "/" + foldername;
            var cloudIdentity = new CloudIdentity() { APIKey = api_key, Username = username };
            var cloudFilesProvider = new CloudFilesProvider(cloudIdentity);
            //ObjectStore createContainerResponse = cloudFilesProvider.CreateContainer(chosenContainer);
            try
            {
                using (FileStream stream = System.IO.File.OpenRead(HttpContext.Current.Request.PhysicalApplicationPath + "/userfiles/" + foldername + "/" + filename))
                {
                    if (foldername != "")
                    {
                        chosenContainer = Path.Combine(chosenContainer, foldername);
                    }
                    cloudFilesProvider.CreateObject(chosenContainer, stream, filename);
                    stream.Flush();
                    stream.Close();
                }
            }
            catch
            {
            }

            return true;
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

        protected void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            ProjectsEntity st = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);

            string InvoiceDoc = ProjectID + "Quotation.pdf";
            if (Convert.ToString(ProjectID) != "")
            {

                bool suc = ProjectsManagement.tblProjects_UpdateInvoiceDoc(ProjectID, st.ProjectNumber);
                if (suc)
                {
                    btnCreateInvoice.Visible = false;
                    btnOpenInvoice.Visible = true;
                }
                else
                {
                    btnCreateInvoice.Visible = true;
                    btnOpenInvoice.Visible = false;
                }
            }
            //  BindInvoice();
            BindProjectElecInv();
            // }

        }

        protected void btnOpenInvoice_Click(object sender, EventArgs e)
        {

            ProjectsEntity st = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);
            //CustomersEntity stCust = CustomersManagement.tblCustomers_SelectByCustomerID(st.CustomerID);

            TextWriter txtWriter = new StringWriter() as TextWriter;

            {
                Server.Execute("~/mailtemplate/Invoice.aspx?id=" + ProjectID, txtWriter);
                String htmlText = txtWriter.ToString();
                HTMLExportToPDF(htmlText, ProjectID + "Invoice.pdf");
            }
            BindProjectElecInv();
            // BindInvoice();
        }

        public void HTMLExportToPDF(string HTML, string filename)
        {
            System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
            try
            {
                string pdfUser = ConfigurationManager.AppSettings["PDFUserName"];
                string pdfKey = ConfigurationManager.AppSettings["PDFUserKey"];
                // create an API client instance
                pdfcrowd.Client client = new pdfcrowd.Client(pdfUser, pdfKey);
                // convert a web page and write the generated PDF to a memory stream
                MemoryStream Stream = new MemoryStream();
                client.setVerticalMargin("75pt");

                TextWriter txtWriter = new StringWriter() as TextWriter;
              //  Server.Execute("~/mailtemplate/UREQuotationheader.aspx", txtWriter);

                string HeaderHtml = txtWriter.ToString();

                client.setHeaderHtml(HeaderHtml);
                client.convertHtml(HTML, Stream);

                // set HTTP response headers
                Response.Clear();
                Response.AddHeader("Content-Type", "application/pdf");
                Response.AddHeader("Cache-Control", "no-cache");
                Response.AddHeader("Accept-Ranges", "none");
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                // send the generated PDF
                Stream.WriteTo(Response.OutputStream);
                Stream.Close();
                Response.Flush();
                Response.End();
            }
            catch (pdfcrowd.Error why)
            {
                //Response.Write(why.ToString());
                //Response.End();
            }
        }

        protected void btnInvoicePay_Click(object sender, EventArgs e)
        {
            // ModalPopupExtenderInvPay.Show();
        }
        public void SetTabFocus(string value)
        {
            switch (value)
            {
                case "1":
                    SItab();
                    break;
                case "2":
                    FItab();
                    break;
                case "3":
                    Invtab();
                    break;

                case "4":
                    ProjTeamTab();
                    break;

                case "5":
                    InstTab();
                    break;
                case "6":
                    mntcTab();
                    break;
                case "7":
                    Doctab();
                    break;
                case "8":
                    ConvTab();
                    break;
                case "9":
                    prtrtab();
                    break;
                case "10":
                    expentab();
                    break;
                default:

                    break;
            }
        }

        public void SItab()
        {
            sip.Attributes.Remove("class");
            sip.Attributes.Add("class", "tab-pane active");
            lisip.Attributes.Add("class", "active");

            fnc.Attributes.Remove("class");
            fnc.Attributes.Add("class", "tab-pane");
            lifncc.Attributes.Remove("class");

            invc.Attributes.Remove("class");
            invc.Attributes.Add("class", "tab-pane");
            liinvc.Attributes.Remove("class");

            projectteam.Attributes.Remove("class");
            projectteam.Attributes.Add("class", "tab-pane");
            lipt.Attributes.Remove("class");

            ins.Attributes.Remove("class");
            ins.Attributes.Add("class", "tab-pane");
            liins.Attributes.Remove("class");

            mntc.Attributes.Remove("class");
            mntc.Attributes.Add("class", "tab-pane");
            limntc.Attributes.Remove("class");

            dcms.Attributes.Remove("class");
            dcms.Attributes.Add("class", "tab-pane");
            lidcms.Attributes.Remove("class");

            cnvs.Attributes.Remove("class");
            cnvs.Attributes.Add("class", "tab-pane");
            licnvs.Attributes.Remove("class");

            prtr.Attributes.Remove("class");
            prtr.Attributes.Add("class", "tab-pane");
            liprtr.Attributes.Remove("class");

            expen.Attributes.Remove("class");
            expen.Attributes.Add("class", "tab-pane");
            liexpen.Attributes.Remove("class");

        }
        public void FItab()
        {
            sip.Attributes.Remove("class");
            sip.Attributes.Add("class", "tab-pane");
            lisip.Attributes.Remove("class");

            fnc.Attributes.Remove("class");
            fnc.Attributes.Add("class", "tab-pane active");
            lifncc.Attributes.Add("class", "active");

            invc.Attributes.Remove("class");
            invc.Attributes.Add("class", "tab-pane");
            liinvc.Attributes.Remove("class");

            projectteam.Attributes.Remove("class");
            projectteam.Attributes.Add("class", "tab-pane");
            lipt.Attributes.Remove("class");

            ins.Attributes.Remove("class");
            ins.Attributes.Add("class", "tab-pane");
            liins.Attributes.Remove("class");

            mntc.Attributes.Remove("class");
            mntc.Attributes.Add("class", "tab-pane");
            limntc.Attributes.Remove("class");

            dcms.Attributes.Remove("class");
            dcms.Attributes.Add("class", "tab-pane");
            lidcms.Attributes.Remove("class");

            cnvs.Attributes.Remove("class");
            cnvs.Attributes.Add("class", "tab-pane");
            licnvs.Attributes.Remove("class");

            prtr.Attributes.Remove("class");
            prtr.Attributes.Add("class", "tab-pane");
            liprtr.Attributes.Remove("class");

            expen.Attributes.Remove("class");
            expen.Attributes.Add("class", "tab-pane");
            liexpen.Attributes.Remove("class");
        }
        public void Invtab()
        {
            sip.Attributes.Remove("class");
            sip.Attributes.Add("class", "tab-pane");
            lisip.Attributes.Remove("class");

            fnc.Attributes.Remove("class");
            fnc.Attributes.Add("class", "tab-pane");
            lifncc.Attributes.Remove("class");

            invc.Attributes.Remove("class");
            invc.Attributes.Add("class", "tab-pane active");
            liinvc.Attributes.Add("class", "active");

            projectteam.Attributes.Remove("class");
            projectteam.Attributes.Add("class", "tab-pane");
            lipt.Attributes.Remove("class");

            ins.Attributes.Remove("class");
            ins.Attributes.Add("class", "tab-pane");
            liins.Attributes.Remove("class");

            mntc.Attributes.Remove("class");
            mntc.Attributes.Add("class", "tab-pane");
            limntc.Attributes.Remove("class");

            dcms.Attributes.Remove("class");
            dcms.Attributes.Add("class", "tab-pane");
            lidcms.Attributes.Remove("class");

            cnvs.Attributes.Remove("class");
            cnvs.Attributes.Add("class", "tab-pane");
            licnvs.Attributes.Remove("class");

            prtr.Attributes.Remove("class");
            prtr.Attributes.Add("class", "tab-pane");
            liprtr.Attributes.Remove("class");

            expen.Attributes.Remove("class");
            expen.Attributes.Add("class", "tab-pane");
            liexpen.Attributes.Remove("class");
        }
        public void ProjTeamTab()
        {
            sip.Attributes.Remove("class");
            sip.Attributes.Add("class", "tab-pane");
            lisip.Attributes.Remove("class");

            fnc.Attributes.Remove("class");
            fnc.Attributes.Add("class", "tab-pane");
            lifncc.Attributes.Remove("class");

            invc.Attributes.Remove("class");
            invc.Attributes.Add("class", "tab-pane");
            liinvc.Attributes.Remove("class");

            projectteam.Attributes.Remove("class");
            projectteam.Attributes.Add("class", "tab-pane active");
            lipt.Attributes.Add("class", "active");

            ins.Attributes.Remove("class");
            ins.Attributes.Add("class", "tab-pane");
            liins.Attributes.Remove("class");

            mntc.Attributes.Remove("class");
            mntc.Attributes.Add("class", "tab-pane");
            limntc.Attributes.Remove("class");

            dcms.Attributes.Remove("class");
            dcms.Attributes.Add("class", "tab-pane");
            lidcms.Attributes.Remove("class");

            cnvs.Attributes.Remove("class");
            cnvs.Attributes.Add("class", "tab-pane");
            licnvs.Attributes.Remove("class");

            prtr.Attributes.Remove("class");
            prtr.Attributes.Add("class", "tab-pane");
            liprtr.Attributes.Remove("class");

            expen.Attributes.Remove("class");
            expen.Attributes.Add("class", "tab-pane");
            liexpen.Attributes.Remove("class");
        }


        public void InstTab()
        {
            sip.Attributes.Remove("class");
            sip.Attributes.Add("class", "tab-pane");
            lisip.Attributes.Remove("class");

            fnc.Attributes.Remove("class");
            fnc.Attributes.Add("class", "tab-pane");
            lifncc.Attributes.Remove("class");

            invc.Attributes.Remove("class");
            invc.Attributes.Add("class", "tab-pane");
            liinvc.Attributes.Remove("class");

            projectteam.Attributes.Remove("class");
            projectteam.Attributes.Add("class", "tab-pane");
            lipt.Attributes.Remove("class");

            ins.Attributes.Remove("class");
            ins.Attributes.Add("class", "tab-pane active");
            liins.Attributes.Add("class", "active");

            mntc.Attributes.Remove("class");
            mntc.Attributes.Add("class", "tab-pane");
            limntc.Attributes.Remove("class");

            dcms.Attributes.Remove("class");
            dcms.Attributes.Add("class", "tab-pane");
            lidcms.Attributes.Remove("class");

            cnvs.Attributes.Remove("class");
            cnvs.Attributes.Add("class", "tab-pane");
            licnvs.Attributes.Remove("class");

            prtr.Attributes.Remove("class");
            prtr.Attributes.Add("class", "tab-pane");
            liprtr.Attributes.Remove("class");

            expen.Attributes.Remove("class");
            expen.Attributes.Add("class", "tab-pane");
            liexpen.Attributes.Remove("class");
        }
        public void mntcTab()
        {
            sip.Attributes.Remove("class");
            sip.Attributes.Add("class", "tab-pane");
            lisip.Attributes.Remove("class");

            fnc.Attributes.Remove("class");
            fnc.Attributes.Add("class", "tab-pane");
            lifncc.Attributes.Remove("class");

            invc.Attributes.Remove("class");
            invc.Attributes.Add("class", "tab-pane");
            liinvc.Attributes.Remove("class");

            projectteam.Attributes.Remove("class");
            projectteam.Attributes.Add("class", "tab-pane");
            lipt.Attributes.Remove("class");

            ins.Attributes.Remove("class");
            ins.Attributes.Add("class", "tab-pane");
            liins.Attributes.Remove("class");

            mntc.Attributes.Remove("class");
            mntc.Attributes.Add("class", "tab-pane active");
            limntc.Attributes.Add("class", "active");

            dcms.Attributes.Remove("class");
            dcms.Attributes.Add("class", "tab-pane");
            lidcms.Attributes.Remove("class");

            cnvs.Attributes.Remove("class");
            cnvs.Attributes.Add("class", "tab-pane");
            licnvs.Attributes.Remove("class");

            prtr.Attributes.Remove("class");
            prtr.Attributes.Add("class", "tab-pane");
            liprtr.Attributes.Remove("class");

            expen.Attributes.Remove("class");
            expen.Attributes.Add("class", "tab-pane");
            liexpen.Attributes.Remove("class");
        }
        public void Doctab()
        {
            sip.Attributes.Remove("class");
            sip.Attributes.Add("class", "tab-pane");
            lisip.Attributes.Remove("class");

            fnc.Attributes.Remove("class");
            fnc.Attributes.Add("class", "tab-pane");
            lifncc.Attributes.Remove("class");

            invc.Attributes.Remove("class");
            invc.Attributes.Add("class", "tab-pane");
            liinvc.Attributes.Remove("class");

            projectteam.Attributes.Remove("class");
            projectteam.Attributes.Add("class", "tab-pane");
            lipt.Attributes.Remove("class");

            ins.Attributes.Remove("class");
            ins.Attributes.Add("class", "tab-pane");
            liins.Attributes.Remove("class");

            mntc.Attributes.Remove("class");
            mntc.Attributes.Add("class", "tab-pane");
            limntc.Attributes.Remove("class");

            dcms.Attributes.Remove("class");
            dcms.Attributes.Add("class", "tab-pane active");
            lidcms.Attributes.Add("class", "active");

            cnvs.Attributes.Remove("class");
            cnvs.Attributes.Add("class", "tab-pane");
            licnvs.Attributes.Remove("class");

            prtr.Attributes.Remove("class");
            prtr.Attributes.Add("class", "tab-pane");
            liprtr.Attributes.Remove("class");

            expen.Attributes.Remove("class");
            expen.Attributes.Add("class", "tab-pane");
            liexpen.Attributes.Remove("class");
        }
        public void ConvTab()
        {
            sip.Attributes.Remove("class");
            sip.Attributes.Add("class", "tab-pane");
            lisip.Attributes.Remove("class");

            fnc.Attributes.Remove("class");
            fnc.Attributes.Add("class", "tab-pane");
            lifncc.Attributes.Remove("class");

            invc.Attributes.Remove("class");
            invc.Attributes.Add("class", "tab-pane");
            liinvc.Attributes.Remove("class");

            projectteam.Attributes.Remove("class");
            projectteam.Attributes.Add("class", "tab-pane");
            lipt.Attributes.Remove("class");

            ins.Attributes.Remove("class");
            ins.Attributes.Add("class", "tab-pane");
            liins.Attributes.Remove("class");

            mntc.Attributes.Remove("class");
            mntc.Attributes.Add("class", "tab-pane");
            limntc.Attributes.Remove("class");

            dcms.Attributes.Remove("class");
            dcms.Attributes.Add("class", "tab-pane");
            lidcms.Attributes.Remove("class");

            cnvs.Attributes.Remove("class");
            cnvs.Attributes.Add("class", "tab-pane active");
            licnvs.Attributes.Add("class", "active");

            prtr.Attributes.Remove("class");
            prtr.Attributes.Add("class", "tab-pane");
            liprtr.Attributes.Remove("class");

            expen.Attributes.Remove("class");
            expen.Attributes.Add("class", "tab-pane");
            liexpen.Attributes.Remove("class");
        }
        public void prtrtab()
        {
            sip.Attributes.Remove("class");
            sip.Attributes.Add("class", "tab-pane");
            lisip.Attributes.Remove("class");

            fnc.Attributes.Remove("class");
            fnc.Attributes.Add("class", "tab-pane");
            lifncc.Attributes.Remove("class");

            invc.Attributes.Remove("class");
            invc.Attributes.Add("class", "tab-pane");
            liinvc.Attributes.Remove("class");

            projectteam.Attributes.Remove("class");
            projectteam.Attributes.Add("class", "tab-pane");
            lipt.Attributes.Remove("class");

            ins.Attributes.Remove("class");
            ins.Attributes.Add("class", "tab-pane");
            liins.Attributes.Remove("class");

            mntc.Attributes.Remove("class");
            mntc.Attributes.Add("class", "tab-pane");
            limntc.Attributes.Remove("class");

            dcms.Attributes.Remove("class");
            dcms.Attributes.Add("class", "tab-pane");
            lidcms.Attributes.Remove("class");

            cnvs.Attributes.Remove("class");
            cnvs.Attributes.Add("class", "tab-pane");
            licnvs.Attributes.Remove("class");

            prtr.Attributes.Remove("class");
            prtr.Attributes.Add("class", "tab-pane active");
            liprtr.Attributes.Add("class", "active");

            expen.Attributes.Remove("class");
            expen.Attributes.Add("class", "tab-pane");
            liexpen.Attributes.Remove("class");
        }

        public void expentab()
        {
            sip.Attributes.Remove("class");
            sip.Attributes.Add("class", "tab-pane");
            lisip.Attributes.Remove("class");

            fnc.Attributes.Remove("class");
            fnc.Attributes.Add("class", "tab-pane");
            lifncc.Attributes.Remove("class");

            invc.Attributes.Remove("class");
            invc.Attributes.Add("class", "tab-pane");
            liinvc.Attributes.Remove("class");

            projectteam.Attributes.Remove("class");
            projectteam.Attributes.Add("class", "tab-pane");
            lipt.Attributes.Remove("class");

            ins.Attributes.Remove("class");
            ins.Attributes.Add("class", "tab-pane");
            liins.Attributes.Remove("class");

            mntc.Attributes.Remove("class");
            mntc.Attributes.Add("class", "tab-pane");
            limntc.Attributes.Remove("class");

            dcms.Attributes.Remove("class");
            dcms.Attributes.Add("class", "tab-pane");
            lidcms.Attributes.Remove("class");

            cnvs.Attributes.Remove("class");
            cnvs.Attributes.Add("class", "tab-pane");
            licnvs.Attributes.Remove("class");

            prtr.Attributes.Remove("class");
            prtr.Attributes.Add("class", "tab-pane");
            liprtr.Attributes.Remove("class");

            expen.Attributes.Remove("class");
            expen.Attributes.Add("class", "tab-pane active");
            liexpen.Attributes.Add("class", "active");
        }

        protected void btnCancelExpenses_Click(object sender, EventArgs e)
        {

        }

        protected void btnSaveExpenses_Click(object sender, EventArgs e)
        {
            try
            {
                string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();

                ExpensesEntity objEntity = new ExpensesEntity();
                objEntity.ExpenseID = Convert.ToInt32(ddlExpense.SelectedValue);
                objEntity.ExpenseDescription = txtExpensedescription.Text.Trim();
                objEntity.ExpenseCosting = txtExpenseCosting.Text.Trim();
                objEntity.ExpenseDate = Convert.ToDateTime(DateTime.Parse((txtExpenDate.Text), new CultureInfo("en-US", true)));
                objEntity.UserId = userid;


                long Success = ExpensesManagement.tblExpenseDescription_Insert(objEntity);

                //  BindExpense();

                divSuccess.Visible = true;
                divAlert.Visible = false;
                lblSuccessMsg.Text = "Expense Added Successfully";
                ClearExpense();
                expentab();
                BindExpenseList();



            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }

        }

        public void ClearExpense()
        {
            txtExpenDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            txtExpenseCosting.Text = "";
            txtExpensedescription.Text = "";
            ddlExpense.SelectedIndex = 0;


        }

        protected void rpttimeline_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                List<ExpensesEntity> lstEntity = new List<ExpensesEntity>();
                lstEntity = ExpensesManagement.tblExpensesDescription_SelectAll();

                for (int i = 0; i < lstEntity.Count; i++)
                {
                    if (i == 0)
                    {
                    }
                    else if (lstEntity[i].ExpenseDate == lstEntity[i - 1].ExpenseDate)
                    {
                        // HtmlControl div = new HtmlGenericControl("timelinediv");
                        //div.Attributes.Add("visible", "false");
                        //  var Timelabel = e.Item.FindControl("Timelabel") as HtmlGenericControl;
                        var Timelabel = new HtmlGenericControl("Timelabel");
                        if (Timelabel != null)
                        {

                            Timelabel.Attributes.Add("Visible", "false");
                        }

                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "Error : " + ex.Message;
            }

            if (rpttimeline.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    Label lblFooter = (Label)e.Item.FindControl("lbltimelinetext");
                    var EmptyHistory = e.Item.FindControl("EmptyHistory") as HtmlGenericControl;
                    EmptyHistory.Visible = true;
                }
            }
        }

        public void BindProjectTeam()
        {
            List<TaskEntity> lstEntity = new List<TaskEntity>();
            lstEntity = TaskManagement.tblTask_SelectList();
            string str = "";
            foreach (var item in lstEntity)
            {
                str += "<div class='col-md-6'>";
                str += "<div class='form-group'>";
                str += "<label class='col-sm-4'>" + item.Task + "</label>";
                str += "<div class='col-sm-8'>";
                str += BindUserDropdownRoleWise(item.RoleId, item.TaskID);
                str += "</div>";
                str += "</div>";
                str += "</div>";
            }
            ltrProjectTeam.Text = str;
        }

        public string BindUserDropdownRoleWise(string RoleId, int TaskID)
        {
            List<EmployeeEntity> lstUser = EmployeeManagement.aspnet_UsersInRoles_Select(RoleId);
            string str = "";
            str += "<div id = 'start'>";
            str += "<div class='ProjectTeamTasks'>";
            str += "<select id='" + TaskID + "Task' class='form-control select2 " + TaskID + "Task' style='width: 100%;'>";
            str += "<option value='0'> Select </option>";
            foreach (var item in lstUser)
            {
                string value = TaskID + "," + item.EmployeeID;
                TaskEntity Task = TaskManagement.tblProjectTeam_SelectByTaskID(ProjectID, TaskID);
                if (item.EmployeeID == Task.EmployeeID)
                {
                    str += "<option value='" + value + "' selected='true'>" + item.FullName + "</option>";
                }
                else
                {
                    str += "<option value='" + value + "'>" + item.FullName + "</option>";
                }
            }
            str += "</select>";
            str += "</div>";
            str += "</div>";
            return str;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]

        public static bool SaveProjectTeam(List<string> lstdata)
        {
            try
            {
                foreach (var item in lstdata)
                {
                    string[] arr = item.Split(',');
                    if (arr.Length == 2)
                    {
                        //string TaskID = arr[0];
                        //string EmployeeID = arr[1];
                        TaskEntity Task = TaskManagement.tblTask_SelectByTaskID(Convert.ToInt32(arr[0]));
                        int ProjectTeamID = TaskManagement.tblProjectTeam_ProjectIDExists(ProjectID, Convert.ToInt32(arr[0]));
                        if (ProjectTeamID == 0)
                        {
                            TaskEntity objEntity = new TaskEntity();
                            objEntity.TaskID = Convert.ToInt32(arr[0]);
                            objEntity.EmployeeID = Convert.ToInt32(arr[1]);
                            objEntity.ProjectID = Convert.ToInt32(ProjectID);
                            objEntity.RoleId = Task.RoleId;
                            objEntity.CreatedOn = DateTime.Now;
                            TaskManagement.tblProjectTeam_Insert(objEntity);

                        }
                        else
                        {
                            TaskEntity objEntity = new TaskEntity();

                            objEntity.ProjectTeamID = ProjectTeamID;
                            objEntity.RoleId = Task.RoleId;
                            objEntity.TaskID = Convert.ToInt32(arr[0]);
                            objEntity.EmployeeID = Convert.ToInt32(arr[1]);
                            TaskManagement.tblProjectTeam_Update(objEntity);

                        }

                        // projectlist foo = new projectlist();
                        //foo.BindProjectTeamList();
                        //foo.ProjTeamTab();

                        // get details from tblTask where TaskId = @TaskID

                        // Check entry exist or not from tblProjectTeam where Project = and TaskID = and EmployeeID = 

                        // If exist = 1 then fire Update otherwise not exist then Insert 

                    }
                }

                return true;
            }
            catch
            {
                return false;
            }

        }



        private void BindProjectTeamList()
        {
            try
            {
                List<TaskEntity> lstEntity = new List<TaskEntity>();
                lstEntity = TaskManagement.tblProjectTeam_Select(ProjectID);
                rptProjectTeamList.DataSource = lstEntity;
                rptProjectTeamList.DataBind();
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void btncnclinstallation_Click(object sender, EventArgs e)
        {
          //  BindProjectInstallation();
        }

        protected void btnsaveinstallation_Click(object sender, EventArgs e)
        {
              

            ProjectsEntity st = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);
            CustomersEntity stCust = CustomersManagement.tblCustomers_SelectByCustomerID(st.CustomerID);
            ProjectsEntityInstallation ProjectEntity = new ProjectsEntityInstallation();

            ProjectEntity.ProjectID = ProjectID;
            ProjectEntity.GedaAppliedDate = Convert.ToDateTime(DateTime.Parse((txtGedaApplied.Text), new CultureInfo("en-US", true)));
           
            ProjectEntity.GedaAppliedRef= txtGedaApplyRef.Text;
            ProjectEntity.GedaApprovalDate=  Convert.ToDateTime(DateTime.Parse((txtGedaApproval.Text), new CultureInfo("en-US", true)));
            ProjectEntity.GedaApprovalRef=txtGedaApprovalRef.Text;
            ProjectEntity.ElectricityBoardID =Convert.ToInt32(ddlElectricityBoard.SelectedIndex);
            ProjectEntity.GedaStatusID =Convert.ToInt32(ddlGedaStatus.SelectedIndex);
            ProjectEntity.GedaDepositID =Convert.ToInt32(ddlGedaDeposit.SelectedIndex);
           
            if (fileupldApprovalLetter.FileName != "")
            {
                long ProjectNumber1 = st.ProjectNumber;
                long ProjectInstallationLetterID1 = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber1, "ApprovalLetter");
               
                string DISCOMApprovalForm = st.ProjectNumber + "ApprovalLetter" + Path.GetExtension(fileupldApprovalLetter.FileName).ToString();
                fileupldApprovalLetter.SaveAs(Server.MapPath("~/userfiles/ApprovalLetter/" + DISCOMApprovalForm));
                long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(ProjectInstallationLetterID1, DISCOMApprovalForm);
               
            }
         
            

                long ProjectNumber = st.ProjectNumber;
                long ProjectInstallationLetterID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "ApprovalLetter");
                string QuoteDoc = "ApprovalLetter.pdf";

                if (ProjectInstallationLetterID != 0)
                {
                    QuoteDoc = ProjectInstallationLetterID + QuoteDoc;
                    long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(ProjectInstallationLetterID, QuoteDoc);
                }
                TextWriter txtWriter = new StringWriter() as TextWriter;
                Server.Execute("~/mailtemplate/Quotation.aspx?id=" + ProjectID, txtWriter);
                String htmlText = txtWriter.ToString();
                SaveCOMMPDF(htmlText, QuoteDoc);
               
                long RegformID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "RegistrationForm");
                string regform = "RegistrationForm.pdf";

                if (RegformID != 0)
                {
                    regform = RegformID + regform;
                    long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(RegformID, regform);
                }

                ProjectEntity.ApprovalLetter = QuoteDoc;
                ProjectEntity.RegistrationForm = regform;
         ProjectEntity.CeigAppliedDate = Convert.ToDateTime(DateTime.Parse((txtCeigAppliedDate.Text), new CultureInfo("en-US", true)));
         ProjectEntity.CeigAppliedRef =txtceigappliedref.Text;;
         ProjectEntity.CeigApprovalDate = Convert.ToDateTime(DateTime.Parse((txtCeigApprovalDate.Text), new CultureInfo("en-US", true)));
         ProjectEntity.CeigApprovalRef =txtCeigApprovalRef.Text;
         ProjectEntity.NetMeterDepositID = Convert.ToInt32(ddlNetMeterDeposit.SelectedIndex);
         ProjectEntity.CeigStatusID = Convert.ToInt32(txtCeigStatus.SelectedIndex);
         ProjectEntity.CustNotifiedMeter =chkCustomerNotifiedMeter.Checked;
         long DrawingID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "Drawing");
         string DrawingForm = "Drawing.pdf";

         if (DrawingID != 0)
         {
             DrawingForm = DrawingID + DrawingForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(DrawingID, DrawingForm);
         }
         ProjectEntity.Drawing =DrawingForm;

         long ApprovalLetterCEIGID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "ApprovalLetterCEIG");
         string ApprovalLetterCEIGForm = "ApprovalLetterCEIG.pdf";

         if (ApprovalLetterCEIGID != 0)
         {
             ApprovalLetterCEIGForm = ApprovalLetterCEIGID + ApprovalLetterCEIGForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(ApprovalLetterCEIGID, ApprovalLetterCEIGForm);
         }
         ProjectEntity.ApprovalLetterCEIG = ApprovalLetterCEIGForm;
         long CoveringLetterCeigID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "CoveringLetterCeig");
         string CoveringLetterCeigForm = "CoveringLetterCeig.pdf";

         if (CoveringLetterCeigID != 0)
         {
             CoveringLetterCeigForm = CoveringLetterCeigID + CoveringLetterCeigForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(CoveringLetterCeigID, CoveringLetterCeigForm);
         }
         ProjectEntity.CoveringLetterCeig = CoveringLetterCeigForm;
         ProjectEntity.NOCDispatched =chkNocDispatced.Checked;
         ProjectEntity.MaterialDispatchedDate = Convert.ToDateTime(DateTime.Parse((txtMaterialDispatchedDate.Text), new CultureInfo("en-US", true)));
         ProjectEntity.InstallationStartDate = Convert.ToDateTime(DateTime.Parse((txtinstallationstartdate.Text), new CultureInfo("en-US", true)));
         ProjectEntity.InstallerNotifiedDate = Convert.ToDateTime(DateTime.Parse((txtInstallerNotifiedDate.Text), new CultureInfo("en-US", true)));
         ProjectEntity.InstallerID =ddlInstaller.SelectedValue.ToString();
         ProjectEntity.InstallationIssueID =Convert.ToInt32(ddlInstallationIssue.SelectedIndex);
         ProjectEntity.StoreAllocationID =Convert.ToInt32(ddlStockAllocationStore.SelectedIndex);
         long NocDispatchedLetterID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "NocDispatchedLetter");
         string NocDispatchedLetterForm = "NocDispatchedLetter.pdf";

         if (NocDispatchedLetterID != 0)
         {
             NocDispatchedLetterForm = NocDispatchedLetterID + NocDispatchedLetterForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(NocDispatchedLetterID, NocDispatchedLetterForm);
         }
         ProjectEntity.NocDispatchedLetter = NocDispatchedLetterForm;
         ProjectEntity.am1 =chkAM1.Checked;
         ProjectEntity.am2 =chkAM2.Checked;
         ProjectEntity.pm1 =chkPM1.Checked;
         ProjectEntity.pm2 =chkPM2.Checked;
         ProjectEntity.days =txtdays.Text;
         ProjectEntity.ConnectivityPaymentDate = Convert.ToDateTime(DateTime.Parse((txtConncectivityPaymentDate.Text), new CultureInfo("en-US", true)));
         ProjectEntity.CustNotifiedInstallDate =chkcustnotfy.Checked;
         ProjectEntity.InstallCompleteDate = Convert.ToDateTime(DateTime.Parse((txtInstallComplete.Text), new CultureInfo("en-US", true)));
         ProjectEntity.InstallVerifyBy =Convert.ToInt32(ddlPostInstallverifyby.SelectedIndex);
         ProjectEntity.MtrSentForTestDate = Convert.ToDateTime(DateTime.Parse((txtmtrsentfortest.Text), new CultureInfo("en-US", true)));
         ProjectEntity.MeterJobBookedDate = Convert.ToDateTime(DateTime.Parse((txtMeterJobBooked.Text), new CultureInfo("en-US", true)));
         long CoveringLetterPostInstallationID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "CoveringLetterPostInstallation");
         string CoveringLetterPostInstallationForm = "CoveringLetterPostInstallation.pdf";

         if (CoveringLetterPostInstallationID != 0)
         {
             CoveringLetterPostInstallationForm = CoveringLetterPostInstallationID + CoveringLetterPostInstallationForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(CoveringLetterPostInstallationID, CoveringLetterPostInstallationForm);
         }
         ProjectEntity.CoveringLetterPostInstallation = CoveringLetterPostInstallationForm;
         ProjectEntity.InvSrno =txtInvSerialNo.Text;
         ProjectEntity.InvSrno2 =txtInvSerialNo2.Text;;
         ProjectEntity.MeterCompletedDate = Convert.ToDateTime(DateTime.Parse((txtMeterCompleted.Text), new CultureInfo("en-US", true)));
         ProjectEntity.DiscomAppliedDate = Convert.ToDateTime(DateTime.Parse((txtDiscomAppliedDate.Text), new CultureInfo("en-US", true)));
         ProjectEntity.AgreementDate = Convert.ToDateTime(DateTime.Parse((txtAgreementDate.Text), new CultureInfo("en-US", true)));
         long DiscomAppliedFormID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "DiscomAppliedForm");
         string DiscomAppliedForm = "DiscomAppliedForm.pdf";

         if (DiscomAppliedFormID != 0)
         {
             DiscomAppliedForm = DiscomAppliedFormID + DiscomAppliedForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(DiscomAppliedFormID, DiscomAppliedForm);
         }
         ProjectEntity.DiscomAppliedForm = DiscomAppliedForm;
         long TechnicalFeasibleReportID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "TechnicalFeasibleReport");
         string TechnicalFeasibleReport = "TechnicalFeasibleReport.pdf";

         if (TechnicalFeasibleReportID != 0)
         {
             TechnicalFeasibleReport = TechnicalFeasibleReportID + TechnicalFeasibleReport;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(TechnicalFeasibleReportID, TechnicalFeasibleReport);
         }
         ProjectEntity.TechnicalFeasibleReport = TechnicalFeasibleReport;
         long AgreementDocID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "AgreementDoc");
         string AgreementDocForm = "AgreementDoc.pdf";

         if (AgreementDocID != 0)
         {
             AgreementDocForm = AgreementDocID + AgreementDocForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(AgreementDocID, AgreementDocForm);
         }
         ProjectEntity.AgreementDoc = AgreementDocForm;
         long SignedAgreementDocID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "SignedAgreementDoc");
         string SignedAgreementDocForm = "SignedAgreementDoc.pdf";

         if (SignedAgreementDocID != 0)
         {
             SignedAgreementDocForm = SignedAgreementDocID + SignedAgreementDocForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(SignedAgreementDocID, SignedAgreementDocForm);
         }
         ProjectEntity.SignedAgreementDoc = SignedAgreementDocForm;
         ProjectEntity.CCPaidByID =Convert.ToInt32(ddlCCPaidBy.SelectedIndex);
         long EstimateReportID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "EstimateReport");
         string EstimateReportForm = "EstimateReport.pdf";

         if (EstimateReportID != 0)
         {
             EstimateReportForm = EstimateReportID + EstimateReportForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(EstimateReportID, EstimateReportForm);
         }
         ProjectEntity.EstimateReport = EstimateReportForm;
         long ConfirmPaymentReceiptID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "ConfirmPaymentReceipt");
         string ConfirmPaymentReceiptForm = "ConfirmPaymentReceipt.pdf";

         if (ConfirmPaymentReceiptID != 0)
         {
             ConfirmPaymentReceiptForm = ConfirmPaymentReceiptID + ConfirmPaymentReceiptForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(ConfirmPaymentReceiptID, ConfirmPaymentReceiptForm);
         }
         ProjectEntity.ConfirmPaymentReceipt = ConfirmPaymentReceiptForm;
         ProjectEntity.ConnectivityCharges =txtConnectivityCharges.Text;
         ProjectEntity.DisComElectricityBoardID =Convert.ToInt32(ddlElectricityBrd.SelectedIndex);
         ProjectEntity.MnreAppliedDate = Convert.ToDateTime(DateTime.Parse((txtMnreAppliedDate.Text), new CultureInfo("en-US", true)));
         ProjectEntity.MnreApprovalDate = Convert.ToDateTime(DateTime.Parse((txtApprovalDate.Text), new CultureInfo("en-US", true)));
         ProjectEntity.AppliedAmount =txtAppliedAmount.Text;;
         ProjectEntity.AppliedStatusID =Convert.ToInt32(ddlAppliedStatus.SelectedIndex);
         long MnreFormBID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "MnreFormB");
         string MnreFormBForm = "MnreFormB.pdf";

         if (MnreFormBID != 0)
         {
             MnreFormBForm = MnreFormBID + MnreFormBForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(MnreFormBID, MnreFormBForm);
         }
         ProjectEntity.MnreFormB = MnreFormBForm;
         long MnreFormcID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "MnreFormc");
         string MnreFormcForm = "MnreFormc.pdf";

         if (MnreFormcID != 0)
         {
             MnreFormcForm = MnreFormcID + MnreFormcForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(MnreFormcID, MnreFormcForm);
         }
         ProjectEntity.MnreFormc ="";
         long CACertificateID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "CACertificate");
         string CACertificateForm = "CACertificate.pdf";

         if (CACertificateID != 0)
         {
             CACertificateForm = CACertificateID + CACertificateForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(CACertificateID, CACertificateForm);
         }
         ProjectEntity.CACertificate = CACertificateForm;
         long SencationLetterID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "SencationLetter");
         string SencationLetterForm = "SencationLetter.pdf";

         if (SencationLetterID != 0)
         {
             SencationLetterForm = SencationLetterID + SencationLetterForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(SencationLetterID, SencationLetterForm);
         }
         ProjectEntity.SencationLetter = SencationLetterForm;
         long AffidavitID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "Affidavit");
         string AffidavitForm = "Affidavit.pdf";

         if (AffidavitID != 0)
         {
             AffidavitForm = AffidavitID + AffidavitForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(AffidavitID, AffidavitForm);
         }
         ProjectEntity.Affidavit = AffidavitForm;
         ProjectEntity.GedaCommissioningDate =Convert.ToDateTime(DateTime.Parse((txtcommissioningdate.Text), new CultureInfo("en-US", true)));
         ProjectEntity.GedaCommissioningApprovalDate =Convert.ToDateTime(DateTime.Parse((txtGedaCommissioningApprovalDate.Text), new CultureInfo("en-US", true)));
         ProjectEntity.GedaCommissioningCertificateNumber =txtCommissioningCertificateNumber.Text;
         ProjectEntity.GedaPostStatusID =Convert.ToInt32(ddlGedaPostStatus.SelectedIndex);
         ProjectEntity.GedaSubsidyStatusID =Convert.ToInt32(ddlSubsidyStatus.SelectedIndex);;
         ProjectEntity.GedaAppliedbyID =Convert.ToInt32(ddlGedaAppliedBy.SelectedIndex);;
         ProjectEntity.GedaSubsidyAppliedDate = Convert.ToDateTime(DateTime.Parse((txtGedaSubsidyAppliedDate.Text), new CultureInfo("en-US", true)));
         ProjectEntity.GedaAppliedAmount =txtGedaAppliedAmount.Text;
         ProjectEntity.GedaSubsidyRecieved =txtGedaSubsidyRec.Text;
         long CommissioningCertiID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "CommissioningCerti");
         string CommissioningCertiForm = "CommissioningCerti.pdf";

         if (CommissioningCertiID != 0)
         {
             CommissioningCertiForm = CommissioningCertiID + CommissioningCertiForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(CommissioningCertiID, CommissioningCertiForm);
         }
         ProjectEntity.CommissioningCerti = CommissioningCertiForm;
         long MDUID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "MDU");
         string MDUForm = "MDU.pdf";

         if (MDUID != 0)
         {
             MDUForm = MDUID + MDUForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(MDUID, MDUForm);
         }
         ProjectEntity.MDU = MDUForm;
         long PanelInverterSrnoID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "PanelInverterSrno");
         string PanelInverterSrnoForm = "PanelInverterSrno.pdf";

         if (PanelInverterSrnoID != 0)
         {
             AffidavitForm = AffidavitID + AffidavitForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(PanelInverterSrnoID, PanelInverterSrnoForm);
         }
         ProjectEntity.PanelInverterSrno = PanelInverterSrnoForm;
         long MeterCallingReportID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "MeterCallingReport");
         string MeterCallingReportForm = "MeterCallingReport.pdf";

         if (MeterCallingReportID != 0)
         {
             MeterCallingReportForm = MeterCallingReportID + MeterCallingReportForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(MeterCallingReportID, MeterCallingReportForm);
         }
         ProjectEntity.MeterCallingReport = MeterCallingReportForm;
         long InvoiceID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "Invoice");
         string InvoiceForm = "Invoice.pdf";

         if (InvoiceID != 0)
         {
             InvoiceForm = InvoiceID + InvoiceForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(InvoiceID, InvoiceForm);
         }
         ProjectEntity.Invoice = InvoiceForm;
         long PlantPhotoID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "PlantPhoto");
         string PlantPhotoForm = "PlantPhoto.pdf";

         if (PlantPhotoID != 0)
         {
             PlantPhotoForm = PlantPhotoID + PlantPhotoForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(PlantPhotoID, PlantPhotoForm);
         }
         ProjectEntity.PlantPhoto = PlantPhotoForm;
         long GedaChecklistID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "GedaChecklist");
         string GedaChecklistForm = "GedaChecklist.pdf";

         if (GedaChecklistID != 0)
         {
             GedaChecklistForm = GedaChecklistID + GedaChecklistForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(GedaChecklistID, GedaChecklistForm);
         }
         ProjectEntity.GedaChecklist = GedaChecklistForm;
         long GedaSubsidyRecieveLetterID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "GedaSubsidyRecieveLetter");
         string GedaSubsidyRecieveLetterForm = "GedaSubsidyRecieveLetter.pdf";

         if (GedaSubsidyRecieveLetterID != 0)
         {
             GedaSubsidyRecieveLetterForm = GedaSubsidyRecieveLetterID + GedaSubsidyRecieveLetterForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(GedaSubsidyRecieveLetterID, GedaSubsidyRecieveLetterForm);
         }
         ProjectEntity.GedaSubsidyRecieveLetter = GedaSubsidyRecieveLetterForm;
         long BeneficiaryPhotoID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "BeneficiaryPhoto");
         string BeneficiaryPhotoForm = "BeneficiaryPhoto.pdf";

         if (BeneficiaryPhotoID != 0)
         {
             BeneficiaryPhotoForm = BeneficiaryPhotoID + BeneficiaryPhotoForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(BeneficiaryPhotoID, BeneficiaryPhotoForm);
         }
         ProjectEntity.BeneficiaryPhoto = BeneficiaryPhotoForm;
         ProjectEntity.CeigPostAppliedDate = Convert.ToDateTime(DateTime.Parse((txtCeigPostAppliedDate.Text), new CultureInfo("en-US", true)));
         ProjectEntity.CeigPostAppliedRef =txtCeigPostAppliedRef.Text;
         ProjectEntity.CeigPostApprovalDate = Convert.ToDateTime(DateTime.Parse((txtCeigPostApprovalDate.Text), new CultureInfo("en-US", true)));
         ProjectEntity.CeigPostApprovalRef =txtCeigPostApprovalREf.Text;;
         ProjectEntity.CeigPostStatusID =Convert.ToInt32(ddlCeigPostStatus.SelectedIndex);
         ProjectEntity.CustPostMeterNotifiedDate =chkCustPostNotifiedMeter.Checked;
         long TestReportID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "TestReport");
         string TestReportForm = "TestReport.pdf";

         if (TestReportID != 0)
         {
             TestReportForm = TestReportID + TestReportForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(TestReportID, TestReportForm);
         }
         ProjectEntity.TestReport = TestReportForm;
         long ChargingNocFormID = ProjectsManagement.tblProjectsInstallationDocuments_Insert(ProjectID, ProjectNumber, "ChargingNocForm");
         string ChargingNocForm = "ChargingNocForm.pdf";

         if (ChargingNocFormID != 0)
         {
             ChargingNocForm = ChargingNocFormID + ChargingNocForm;
             long suc = ProjectsManagement.tblProjectsInstallationDocuments_Update(ChargingNocFormID, ChargingNocForm);
         }
         ProjectEntity.ChargingNocForm = ChargingNocForm;
            
          

            int Exist = ProjectsManagement.tblProjectsNewInstallation_ProjectIDExists(ProjectID);
            if (Exist == 0)
            {
              
                ProjectsManagement.tblProjectsNewInstallation_Insert(ProjectEntity);
                divSuccess.Visible = true;
                divAlert.Visible = false;
                lblSuccessMsg.Text = " Installation Added Successfully";
            }
            else
            {
                ProjectsManagement.tblProjectsNewInstallation_Update(ProjectEntity);
                divSuccess.Visible = true;
                divAlert.Visible = false;
                lblSuccessMsg.Text = "Installation Updated Successfully";
            }
            InstTab();
        }

        public void BindProjectInstallation()
        {
            List<CompanyLocationsEntity> lstCompanyLocation = new List<CompanyLocationsEntity>();
            lstCompanyLocation = CompanyLocationsManagement.tblCompanyLocations_SelectActive();
            ddlStockAllocationStore.DataSource = lstCompanyLocation;
            ddlStockAllocationStore.DataValueField = "CompanyLocationID";
            ddlStockAllocationStore.DataMember = "CompanyLocation";
            ddlStockAllocationStore.DataTextField = "CompanyLocation";

            ddlStockAllocationStore.DataBind();

            List<EmployeeEntity> Instemp = new List<EmployeeEntity>();
            Instemp = EmployeeManagement.tblEmployees_SelectInstaller();


            ddlInstaller.DataSource = Instemp;

            ddlInstaller.DataValueField = "UserId";
            ddlInstaller.DataMember = "fullname";
            ddlInstaller.DataTextField = "fullname";
            ddlInstaller.DataBind();


            ProjectsEntity st2 = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);
            ProjectID = st2.ProjectID;
            ddlElectricityBoard.DataSource = ElecDistributorManagement.tblElecDistributor_SelectActiveByState(st2.InstallState);
            ddlElectricityBoard.DataMember = "ElecDistributor";
            ddlElectricityBoard.DataTextField = "ElecDistributor";
            ddlElectricityBoard.DataValueField = "ElecDistributorID";
            ddlElectricityBoard.DataBind();

            ddlElectricityBrd.DataSource = ElecDistributorManagement.tblElecDistributor_SelectActiveByState(st2.InstallState);
            ddlElectricityBrd.DataMember = "ElecDistributor";
            ddlElectricityBrd.DataTextField = "ElecDistributor";
            ddlElectricityBrd.DataValueField = "ElecDistributorID";
            ddlElectricityBrd.DataBind();

  
            if (st2.InstallationIssueID.ToString() != string.Empty)
            {
                JobStatusEntity stptd = JobStatusManagement.tblJobStatus_SelectByJobStatusID(st2.InstallationIssueID);
                string isactive = stptd.Active.ToString();
                if (isactive == "False")
                {
                    ddlInstallationIssue.DataSource = InstallationIssueManagement.tblInstallationIssue_SelectActive(0, st2.InstallationIssueID);
                }
                else
                {
                    ddlInstallationIssue.DataSource = InstallationIssueManagement.tblInstallationIssue_SelectActive(1, st2.InstallationIssueID);
                }
            }
            else
            {
                ddlInstallationIssue.DataSource = InstallationIssueManagement.tblInstallationIssue_SelectActive(1, 0);
            }
            ddlInstallationIssue.DataValueField = "InstallationIssueID";
            ddlInstallationIssue.DataTextField = "InstallationIssue";
            ddlInstallationIssue.DataMember = "InstallationIssue";
            ddlInstallationIssue.DataBind();


            if (st2.STCAppliedByID.ToString() != string.Empty)
            {
                EmployeeEntity stptd = EmployeeManagement.tblEmployees_SelectActiveByEmployeeID(st2.STCAppliedByID);
                string isactive = stptd.Active.ToString();


                if (isactive == "False")
                {
                    ddlPostInstallverifyby.DataSource = EmployeeManagement.tblEmployees_SelectASC(st2.STCAppliedByID, 0);
                }
                else
                {
                    ddlPostInstallverifyby.DataSource = EmployeeManagement.tblEmployees_SelectASC(st2.STCAppliedByID, 1);
                }
            }
            else
            {
                ddlPostInstallverifyby.DataSource = EmployeeManagement.tblEmployees_SelectASC(0, 1);
            }

            ddlPostInstallverifyby.DataValueField = "EmployeeID";
            ddlPostInstallverifyby.DataMember = "fullname";
            ddlPostInstallverifyby.DataTextField = "fullname";
            ddlPostInstallverifyby.DataBind();



         
            int Exist = ProjectsManagement.tblProjectsNewInstallation_ProjectIDExists(ProjectID);
            if (Exist == 1)
            {
                ProjectsEntityInstallation Pt = ProjectsManagement.tblProjectsNewInstallationByProjectID(ProjectID);
              
                
                txtGedaApplied.Text = Pt.GedaAppliedDate.ToString("MM/dd/yyyy");
                txtGedaApplyRef.Text = Pt.GedaAppliedRef;
                txtGedaApproval.Text = Pt.GedaApprovalDate.ToString("MM/dd/yyyy");
                txtGedaApprovalRef.Text = Pt.GedaApprovalRef;
                ddlElectricityBoard.SelectedIndex = Convert.ToInt32(Pt.ElectricityBoardID);
                ddlGedaStatus.SelectedIndex = Convert.ToInt32(Pt.GedaStatusID);
                ddlGedaDeposit.SelectedIndex = Convert.ToInt32(Pt.GedaDepositID);
                txtCeigAppliedDate.Text = Pt.CeigAppliedDate.ToString("MM/dd/yyyy");
                txtceigappliedref.Text = Pt.CeigAppliedRef;
                txtCeigApprovalDate.Text = Pt.CeigApprovalDate.ToString("MM/dd/yyyy");
                txtCeigApprovalRef.Text = Pt.CeigApprovalRef;
                ddlNetMeterDeposit.SelectedIndex = Convert.ToInt32(Pt.NetMeterDepositID);
                ddlCeigPostStatus.SelectedIndex = Convert.ToInt32(Pt.CeigStatusID);
                chkCustomerNotifiedMeter.Checked = Convert.ToBoolean(Pt.CustNotifiedMeter);
               chkNocDispatced.Checked = Convert.ToBoolean(Pt.NOCDispatched);
                 txtMaterialDispatchedDate.Text = Pt.MaterialDispatchedDate.ToString("MM/dd/yyyy");
              txtinstallationstartdate.Text = Pt.InstallationStartDate.ToString("MM/dd/yyyy");
              txtInstallerNotifiedDate.Text = Pt.InstallerNotifiedDate.ToString("MM/dd/yyyy");
              // ddlInstaller.SelectedItem = Pt.InstallerID.;
               ddlInstallationIssue.SelectedIndex = Convert.ToInt32(Pt.InstallationIssueID);  
                ddlStockAllocationStore.SelectedIndex = Convert.ToInt32(Pt.StoreAllocationID);
                chkAM1.Checked= Convert.ToBoolean(Pt.am1);
                chkAM2.Checked= Convert.ToBoolean(Pt.am2);
                chkPM1.Checked= Convert.ToBoolean(Pt.pm1);
                chkPM2.Checked= Convert.ToBoolean(Pt.pm2);
                txtdays.Text = Pt.days;

                chkcustnotfy.Checked =Convert.ToBoolean(Pt.CustNotifiedInstallDate);
                ddlPostInstallverifyby.SelectedIndex = Convert.ToInt32(Pt.InstallVerifyBy);
                txtInstallComplete.Text = Pt.InstallCompleteDate.ToString("MM/dd/yyyy");
                txtmtrsentfortest.Text = Pt.MtrSentForTestDate.ToString("MM/dd/yyyy");
                txtMeterJobBooked.Text = Pt.MeterJobBookedDate.ToString("MM/dd/yyyy");
                txtInvSerialNo.Text = Pt.InvSrno;
                txtInvSerialNo2.Text = Pt.InvSrno2;
                txtMeterCompleted.Text = Pt.MeterCompletedDate.ToString("MM/dd/yyyy");
                txtDiscomAppliedDate.Text = Pt.DiscomAppliedDate.ToString("MM/dd/yyyy");
                txtAgreementDate.Text = Pt.AgreementDate.ToString("MM/dd/yyyy");
                txtConncectivityPaymentDate.Text = Pt.ConnectivityPaymentDate.ToString("MM/dd/yyyy");
                ddlCCPaidBy.SelectedIndex = Convert.ToInt32(Pt.CCPaidByID);
                txtConnectivityCharges.Text = Pt.ConnectivityCharges;
                ddlElectricityBrd.SelectedIndex = Convert.ToInt32(Pt.DisComElectricityBoardID);
                 txtMnreAppliedDate.Text = Pt.MnreAppliedDate.ToString("MM/dd/yyyy");
                txtApprovalDate.Text = Pt.MnreApprovalDate.ToString("MM/dd/yyyy");
                txtAppliedAmount.Text = Pt.AppliedAmount;
                ddlAppliedStatus.SelectedIndex = Convert.ToInt32(Pt.AppliedStatusID);
                txtcommissioningdate.Text = Pt.GedaCommissioningDate.ToString("MM/dd/yyyy");
                txtGedaCommissioningApprovalDate.Text = Pt.GedaCommissioningApprovalDate.ToString("MM/dd/yyyy");
                //txtCommissioningCertificateNumber.Text = Pt.CommissioningCerti;
                ddlGedaPostStatus.SelectedIndex = Convert.ToInt32(Pt.GedaPostStatusID);
                ddlSubsidyStatus.SelectedIndex = Convert.ToInt32(Pt.GedaSubsidyStatusID);
                ddlGedaAppliedBy.SelectedIndex = Convert.ToInt32(Pt.GedaAppliedbyID);
                txtGedaSubsidyAppliedDate.Text = Pt.GedaSubsidyAppliedDate.ToString("MM/dd/yyyy");
                txtGedaAppliedAmount.Text = Pt.GedaAppliedAmount;
                txtGedaSubsidyRec.Text = Pt.GedaSubsidyRecieved;
                txtCeigPostAppliedDate.Text = Pt.CeigPostAppliedDate.ToString("MM/dd/yyyy");
                chkCustPostNotifiedMeter.Checked = Convert.ToBoolean(Pt.CustPostMeterNotifiedDate);
                txtCeigPostApprovalDate.Text = Pt.CeigPostApprovalDate.ToString("MM/dd/yyyy");
                txtCeigPostAppliedRef.Text = Pt.CeigPostAppliedRef;
                txtCeigPostApprovalREf.Text = Pt.CeigPostApprovalRef;
                ddlCeigPostStatus.SelectedIndex = Convert.ToInt32(Pt.CeigPostStatusID);
             

            }
        }
    }
}
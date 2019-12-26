using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.ProjectModule
{
    public class ProjectsEntity
    {
        public long ProjectSalesInputID { get; set; }
        public long ProjectID { get; set; }
        public long ProjectManegerID { get; set; }
        public long CustomerID { get; set; }
        public DateTime FollowUpDate { get; set; }
        public long ContactID { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public long SalesRep { get; set; }
        public int ProjectTypeID { get; set; }
        public string ProjectType { get; set; }
        public int ProjectStatusID { get; set; }
        public string ProjectStatus { get; set; }
        public int CompanyLocationID { get; set; }
        public int ProjectCancelID { get; set; }
        public int ProjectOnHoldID { get; set; }
        public DateTime ProjectOpened { get; set; }
        public DateTime ProjectCancelled { get; set; }
        public long ProjectNumber { get; set; }
        public string OldProjectNumber { get; set; }
        public string ManualQuoteNumber { get; set; }
        public string FollowUpNote { get; set; }
        public string ProjectDetail { get; set; }

        public int PanelBrandID { get; set; }
        public int NumberPanels { get; set; }
        public int InverterDetailsID { get; set; }
        public int SecondInverterDetailsID { get; set; }
        public string InverterModel { get; set; }
        public string InverterCert { get; set; }
        public decimal SystemCapKW { get; set; }
        public decimal PerKWCost { get; set; }
        public decimal BasicSystemCost { get; set; }
        public string PanelBrand { get; set; }
        public string InverterDetails { get; set; }
        public string SecondInverterDetails { get; set; }
        public string SystemCapKWst { get; set; }
        public string NumberPanelsst { get; set; }



        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal IGST { get; set; }
        public decimal OtherCost { get; set; }

        public decimal SpecialDiscount { get; set; }
        public decimal TotalQuotePrice { get; set; }
        public decimal DepositRequired { get; set; }


        public int HouseTypeID { get; set; }
        public decimal VarHouseType { get; set; }
        public int RoofTypeID { get; set; }
        public decimal VarRoofType { get; set; }
        public int RoofAngleID { get; set; }
        public decimal VarRoofAngle { get; set; }
        public int MeterInstallation { get; set; }
        public decimal VarMeterInstallation { get; set; }

        public int MeterPhase { get; set; }
        public string MeterNumber { get; set; }
        public Boolean OffPeak { get; set; }


        public int ElecDistributorID { get; set; }
        public Boolean MeterEnoughSpace { get; set; }
        public int ElecRetailerID { get; set; }
        public string STCNumber { get; set; }
        public string PeakMeterNumber { get; set; }

        public DateTime QuoteAccepted { get; set; }
        public Boolean SignedQuote { get; set; }
        public DateTime QuoteSent { get; set; }

        public string QuotationNotes { get; set; }

        public Boolean MeterBoxPhotosSaved { get; set; }
        public Boolean ElecBillSaved { get; set; }
        public Boolean SiteMap { get; set; }
        public Boolean PaymentReceipt { get; set; }
        public Boolean MeterApproval { get; set; }


        public string Project { get; set; }
        public DateTime NextMaintenanceCall { get; set; }
        public string InstallAddress { get; set; }
        public string InstallArea { get; set; }
        public string InstallCity { get; set; }
        public string InstallState { get; set; }
        public string InstallPostCode { get; set; }
        public long ProjectMgr { get; set; }
        public string ProjectNotes { get; set; }
        public string InstallerNotes { get; set; }
        public string MeterInstallerNotes { get; set; }
        public long ProjectEnteredBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsActive { get; set; }
        public int CustSourceID { get; set; }
        public string ProjectAddress { get; set; }
        public string UpdateName { get; set; }

        public string BalOwing { get; set; }


        // public string ProjectAddress { get; set; }
        //    public string UpdateName { get; set; }
        public string CustomerName { get; set; }
        public string Location { get; set; }
        public string ContactNO { get; set; }

        public int ProjectQuoteID { get; set; }
        public DateTime ProjectQuoteDate { get; set; }
        public int ProjectQuoteDoc { get; set; }
        public string QuoteDoc { get; set; }
        public int InvoiceNumber { get; set; }
        public int InvoiceDoc { get; set; }

        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public long ProjectInstallationID { get; set; }
        public DateTime MeterAppliedDate { get; set; }
        public string MeterApplyRef { get; set; }
        public DateTime MeterApprovalDate { get; set; }
        public string MeterApprovalRef { get; set; }
        public DateTime RexAppliedDate { get; set; }
        public string RexAppliedRef { get; set; }
        public long RexStatusID { get; set; }
        public Boolean CustomerNotifiedMeter { get; set; }
        public DateTime InitialInstallDate { get; set; }
        public DateTime InstallBookingDate { get; set; }
        public long ElectricianID { get; set; }
        public long InstallerID { get; set; }
        public long DesignerID { get; set; }
        public string ElectricianIDs { get; set; }
        public string InstallerIDs { get; set; }
        public string DesignerIDs { get; set; }
        public DateTime InstallerNotifiedDate { get; set; }
        public long InstallationIssueID { get; set; }
        public long StockAllocationStoreID { get; set; }
        public long SpecialPurposeID { get; set; }
        public DateTime InstallationCompletionDate { get; set; }
        public string InstallationVerifiedBy { get; set; }
        public DateTime InstallDocsRec { get; set; }
        public Boolean InstallationConfirmed { get; set; }
        public Boolean STCChecked { get; set; }
        public long STCCheckedByID { get; set; }
        public DateTime CertificateIssuedDate { get; set; }
        public string INVSerialNo { get; set; }
        public string INVSerialNo2 { get; set; }
        public long MeterElecID { get; set; }
        public DateTime MeterInstallationDocSent { get; set; }
        public DateTime MeterJobBooked { get; set; }
        public DateTime MeterCompleted { get; set; }
        public Boolean CCEW { get; set; }
        public Boolean STCFormSaved { get; set; }
        public Boolean CertificateSaved { get; set; }
        public Boolean AdditionalSystem { get; set; }
        public Boolean OwnerGSTReg { get; set; }
        public string CompanyABNName { get; set; }
        public Boolean NewModelPanel { get; set; }
        public Boolean NewModelINV { get; set; }
        public DateTime STCAppliedDate { get; set; }
        public string STCUploadNumber { get; set; }
        public string PVDNumber { get; set; }
        public long PVDStatusID { get; set; }
        public long STCAppliedByID { get; set; }
        public string PanelModel { get; set; }
        public string NoOfInverter { get; set; }
        public int MeterType { get; set; }
        public int Days { get; set; }
        public string Task { get; set; }

        public DateTime DepositReceived { get; set; }
        public DateTime SalesVerificationDate { get; set; }
        public long FinanceWithID { get; set; }
        public long FinAppStatusID { get; set; }
        public string FinAppStatus { get; set; }
        public DateTime DocumentReceivedDate { get; set; }
        public long InvoiceStatusID { get; set; }
        public Boolean InvoiceStatus { get; set; }
        public string SalesRepName { get; set; }
        public DateTime InvPayDate { get; set; }



    }

    public class ProjectsEntityInstallation
    {
        public long ProjectInstallationID { get; set; }
        public long ProjectID { get; set; }
        public DateTime GedaAppliedDate { get; set; }
        public string GedaAppliedRef { get; set; }
        public DateTime GedaApprovalDate { get; set; }
        public string GedaApprovalRef { get; set; }
        public long ElectricityBoardID { get; set; }
        public long GedaStatusID { get; set; }
        public long GedaDepositID { get; set; }
        public string ApprovalLetter { get; set; }
        public string RegistrationForm { get; set; }
        public DateTime CeigAppliedDate { get; set; }
        public string CeigAppliedRef { get; set; }
        public DateTime CeigApprovalDate { get; set; }
        public string CeigApprovalRef { get; set; }
        public long NetMeterDepositID { get; set; }
        public long CeigStatusID { get; set; }
        public Boolean CustNotifiedMeter { get; set; }
        public string Drawing { get; set; }
        public string ApprovalLetterCEIG { get; set; }
        public string CoveringLetterCeig { get; set; }
        public Boolean NOCDispatched { get; set; }
        public DateTime MaterialDispatchedDate { get; set; }
        public DateTime InstallationStartDate { get; set; }
        public DateTime InstallerNotifiedDate { get; set; }
        public string InstallerID { get; set; }
        public long InstallationIssueID { get; set; }
        public long StoreAllocationID { get; set; }
        public string NocDispatchedLetter { get; set; }
        public Boolean am1 { get; set; }
        public Boolean am2 { get; set; }
        public Boolean pm1 { get; set; }
        public Boolean pm2 { get; set; }
        public string days { get; set; }
        public Boolean CustNotifiedInstallDate { get; set; }
        public DateTime InstallCompleteDate { get; set; }
        public long InstallVerifyBy { get; set; }
        public DateTime MtrSentForTestDate { get; set; }
        public DateTime MeterJobBookedDate { get; set; }
        public string CoveringLetterPostInstallation { get; set; }
        public string InvSrno { get; set; }
        public string InvSrno2 { get; set; }
        public DateTime MeterCompletedDate { get; set; }
        public DateTime DiscomAppliedDate { get; set; }
        public DateTime AgreementDate { get; set; }
        public string DiscomAppliedForm { get; set; }
        public DateTime ConnectivityPaymentDate { get; set; }
        public string TechnicalFeasibleReport { get; set; }
        public string AgreementDoc { get; set; }
        public string SignedAgreementDoc { get; set; }
        public long CCPaidByID { get; set; }
        public string EstimateReport { get; set; }
        public string ConfirmPaymentReceipt { get; set; }
        public string ConnectivityCharges { get; set; }
        public long DisComElectricityBoardID { get; set; }
        public DateTime MnreAppliedDate { get; set; }
        public DateTime MnreApprovalDate { get; set; }
        public string AppliedAmount { get; set; }
        public long AppliedStatusID { get; set; }
        public string MnreFormB { get; set; }
        public string MnreFormc { get; set; }
        public string CACertificate { get; set; }
        public string SencationLetter { get; set; }
        public string Affidavit { get; set; }
        public DateTime GedaCommissioningDate { get; set; }
        public DateTime GedaCommissioningApprovalDate { get; set; }
        public string GedaCommissioningCertificateNumber { get; set; }
        public long GedaPostStatusID { get; set; }
        public long GedaSubsidyStatusID { get; set; }
        public long GedaAppliedbyID { get; set; }
        public DateTime GedaSubsidyAppliedDate { get; set; }
        public string GedaAppliedAmount { get; set; }
        public string GedaSubsidyRecieved { get; set; }
        public string CommissioningCerti { get; set; }
        public string MDU { get; set; }
        public string PanelInverterSrno { get; set; }
        public string MeterCallingReport { get; set; }
        public string Invoice { get; set; }
        public string PlantPhoto { get; set; }
        public string GedaChecklist { get; set; }
        public string GedaSubsidyRecieveLetter { get; set; }
        public string BeneficiaryPhoto { get; set; }
        public DateTime CeigPostAppliedDate { get; set; }
        public string CeigPostAppliedRef { get; set; }
        public DateTime CeigPostApprovalDate { get; set; }
        public string CeigPostApprovalRef { get; set; }
        public long CeigPostStatusID { get; set; }
        public Boolean CustPostMeterNotifiedDate { get; set; }
        public string TestReport { get; set; }
        public string ChargingNocForm { get; set; }

    }
}
	

	

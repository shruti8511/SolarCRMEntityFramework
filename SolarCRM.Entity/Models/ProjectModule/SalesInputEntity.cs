using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.ProjectModule
{
    public class SalesInputEntity
    {
        public long ProjectSalesInputID { get; set; }
        public long ProjectID { get; set; }
        public int HouseTypeID { get; set; }
        public int RoofTypeID { get; set; }
        public int RoofAngleID { get; set; }
        public int InstallBase { get; set; }
        public int StockAllocationStore { get; set; }
        public bool StandardPack { get; set; }
        public int PanelBrandID { get; set; }
        public string PanelBrand { get; set; }
        public string PanelModel { get; set; }
        public string PanelOutput { get; set; }
        public string PanelDetails { get; set; }
        public int InverterDetailsID { get; set; }
        public int SecondInverterDetailsID { get; set; }
        public string InverterBrand { get; set; }
        public string InverterModel { get; set; }
        public string InverterSeries { get; set; }

        public decimal InverterOutput { get; set; }
        public decimal SecondInverterOutput { get; set; }
        public decimal TotalInverterOutput { get; set; }
        public string InverterCert { get; set; }
        public string InverterDetails { get; set; }
        public string SystemDetails { get; set; }
        public int NumberPanels { get; set; }
        public int PreviousNumberPanels { get; set; }

        public int PanelConfigNW { get; set; }
        public int PanelConfigOTH { get; set; }
        public decimal SystemCapKW { get; set; }
        public int STCMultiplier { get; set; }
        public decimal STCZoneRating { get; set; }
        public int STCNumber { get; set; }
        public decimal STCValue { get; set; }
        public int ElecRetailerID { get; set; }
        public int ElecDistributorID { get; set; }
        public DateTime ElecDistApplied { get; set; }
        public int ElecDistApplyMethod { get; set; }
        public int ElecDistApplyBy { get; set; }
        public string ElecDistApplySentFrom { get; set; }
        public DateTime ElecDistApproved { get; set; }

        public string ElecDistApprovelRef { get; set; }
        public bool ElecDistOK { get; set; }
        public string RegPlanNo { get; set; }
        public int LotNumber { get; set; }
        public bool Asbestoss { get; set; }
        public bool MeterUG { get; set; }
        public bool MeterEnoughSpace { get; set; }
        public bool SplitSystem { get; set; }
        public bool CherryPicker { get; set; }

        public int TravelTime { get; set; }
        public string VariationOther { get; set; }
        public decimal VarRoofType { get; set; }
        public decimal VarRoofAngle { get; set; }
        public decimal VarHouseType { get; set; }
        public decimal VarAsbestos { get; set; }
        public decimal VarMeterInstallation { get; set; }
        public decimal VarMeterUG { get; set; }
        public decimal VarTravelTime { get; set; }
        public decimal VarSplitSystem { get; set; }
        public decimal VarEnoughSpace { get; set; }
        public decimal VarCherryPicker { get; set; }

        public decimal VarOther { get; set; }
        public decimal SpecialDiscount { get; set; }
        public decimal DepositRequired { get; set; }
        public decimal TotalQuotePrice { get; set; }
        public decimal PreviousTotalQuotePrice { get; set; }


        //InvoiceExGST	money
        //InvoiceGST	money
        //BalanceGST	money
        //QuoteSent	datetime
        //QuoteSentNo	int	
        //QuoteAccepted	datetime
        //SignedQuote	bit
        //MeterBoxPhotosSaved	bit
        //ElecBillSaved	bit	
        //ProposedDesignSaved	bit
        //MeterApproval	bit
        //PaymentReceipt	bit
        //FollowUp	datetime
        //FollowUpNote	nvarchar(255)
        //UpdateDate	datetime
        //UpdateBy	bigint
    }
}

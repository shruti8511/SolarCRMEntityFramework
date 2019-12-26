using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.StockModule
{
    public class StockItemEntity
    {
        public int StockItemID { get; set; }
        public int StockCategoryID { get; set; }
        public string StockCategory { get; set; }
        public string StockItem { get; set; }
        public string StockManufacturer { get; set; }
        public string StockModel { get; set; }
        public string StockSeries { get; set; }
        public string StockSize { get; set; }
        public string ShortName { get; set; }
        public string StockDescription { get; set; }
        public long StockCode { get; set; }
        public string InverterCert { get; set; }
        public int StockQuantity { get; set; }
        public int StockLocation { get; set; }
        public int MinLevel { get; set; }
        public int Reserved { get; set; }
        public decimal PlanA { get; set; }
        public decimal PlanB { get; set; }
        public decimal PlanC { get; set; }
        public decimal MinPrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal CustomerPrice { get; set; }
        public Boolean Active { get; set; }
        public Boolean Active1 { get; set; }
        public Boolean SalesTag { get; set; }
        public Boolean DeleteTag { get; set; }
        public int LastStockTake { get; set; }
        public int PrevStockTake { get; set; }
        public string InverterPhase { get; set; }
        public string MPPT { get; set; }
        public string StockNewModel { get; set; }
        public string StockNewSeries { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}

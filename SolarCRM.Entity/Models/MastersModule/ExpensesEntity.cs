using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.MastersModule
{
    public class ExpensesEntity
    {
        public int ExpenseID { get; set; }
      
        public string ExpenseName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
     
        public Boolean IsActive { get; set; }

        public int ExpenseDescriptionID { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string ExpenseDescription { get; set; }
        public DateTime DateEntered { get; set; }
        public string ExpenseCosting { get; set; }
        public string Symbol { get; set; }
        public string Diff { get; set; }
    }
}

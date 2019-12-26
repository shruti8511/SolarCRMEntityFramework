using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.MastersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.MastersModule
{
    public class ExpensesManagement
    {
        public static long tblExpenses_Insert(ExpensesEntity ObjEntity)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ExpenseSQL().tblExpenses_Insert(ObjEntity));
        }
        public static int tblExpense_Exists(string ExpenseName)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ExpenseSQL().tblExpense_Exists(ExpenseName));
        }
        public static List<ExpensesEntity> tblExpenses_Select(PagingEntity CommonEntity, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ExpenseSQL().tblExpenses_Select(CommonEntity, out Count));
        }
        public static List<ExpensesEntity> tblExpenses_SelectSearch(PagingEntity CommonEntity, string Searchkeyword, out int Count)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ExpenseSQL().tblExpenses_SelectSearch(CommonEntity, Searchkeyword, out Count));
        }
        public static List<ExpensesEntity> tblExpenses_SelectForDropdown()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ExpenseSQL().tblExpenses_SelectForDropdown());
        }
        public static long tblExpenseDescription_Insert(ExpensesEntity ObjEntity)
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ExpenseSQL().tblExpenseDescription_Insert(ObjEntity));
        }
        public static List<ExpensesEntity> tblExpensesDescription_Select()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ExpenseSQL().tblExpensesDescription_Select());
        }
        public static List<ExpensesEntity> tblExpensesDescription_SelectAll()
        {
            return (new SolarCRM.DAL.Implementations.MastersModule.ExpenseSQL().tblExpensesDescription_SelectAll());
        }

    }
}

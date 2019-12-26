

namespace SolarCRM.DAL.Implementations.MastersModule
{
    using SolarCRM.Entity.Models.Common;
    using SolarCRM.Entity.Models.EmployeeModule;
    using SolarCRM.Entity.Models.MastersModule;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class ExpenseSQL:BaseSqlManager
    {
        public virtual long tblExpenses_Insert(ExpensesEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblExpense_Insert";
            cmdAdd.Parameters.AddWithValue("@ExpenseName", ObjEntity.ExpenseName);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.IsActive);
            cmdAdd.Parameters.AddWithValue("@UserId", ObjEntity.UserId);
            cmdAdd.Parameters.AddWithValue("@Symbol", ObjEntity.Symbol);
            long Expense = Convert.ToInt64(ExecuteScalar(cmdAdd));
            ForceCloseConnection();
            return Expense;
        }
      
        public virtual int tblExpense_Exists(string ExpenseName)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblExpense_Exists";
            cmdGet.Parameters.AddWithValue("@ExpenseName", ExpenseName);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "ExpenseID");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<ExpensesEntity> tblExpenses_Select(PagingEntity CommonEntity, out int Count)
        {
            List<ExpensesEntity> lstLocation = new List<ExpensesEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblExpenses_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ExpensesEntity objEntity = new ExpensesEntity();
                objEntity.ExpenseID = GetInt32(dr, "ExpenseID");
                objEntity.ExpenseName = GetTextValue(dr, "ExpenseName");
                objEntity.IsActive = GetBoolean(dr, "IsActive");
                objEntity.UserId = GetTextValue(dr, "UserID");
                objEntity.UserName = GetTextValue(dr, "UserName");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<ExpensesEntity> tblExpenses_SelectSearch(PagingEntity CommonEntity, string Searchkeyword, out int Count)
        {
            List<ExpensesEntity> lstExpense = new List<ExpensesEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblExpenses_SelectSearch";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            cmdGet.Parameters.AddWithValue("@searchkeyword", Searchkeyword);
           
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ExpensesEntity objEntity = new ExpensesEntity();
                objEntity.ExpenseID = GetInt32(dr, "ExpenseID");
                objEntity.ExpenseName = GetTextValue(dr, "ExpenseName");
                objEntity.IsActive = GetBoolean(dr, "IsActive");
                objEntity.UserName = GetTextValue(dr, "UserName");
                objEntity.UserId = GetTextValue(dr, "UserID");
                lstExpense.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstExpense;
        }

        public virtual List<ExpensesEntity> tblExpenses_SelectForDropdown()
        {
            List<ExpensesEntity> lstLocation = new List<ExpensesEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblExpenses_SelectForDropdown";
         
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ExpensesEntity objEntity = new ExpensesEntity();
                objEntity.ExpenseID = GetInt32(dr, "ExpenseID");
                objEntity.ExpenseName = GetTextValue(dr, "ExpenseName");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
         
        public virtual long tblExpenseDescription_Insert(ExpensesEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblExpenseDescription_Insert";
            cmdAdd.Parameters.AddWithValue("@ExpenseID", ObjEntity.ExpenseID);
            cmdAdd.Parameters.AddWithValue("@ExpenseDate", ObjEntity.ExpenseDate);
            cmdAdd.Parameters.AddWithValue("@ExpenseDescription", ObjEntity.ExpenseDescription);
            cmdAdd.Parameters.AddWithValue("@ExpenseBy", ObjEntity.UserId);
            cmdAdd.Parameters.AddWithValue("@ExpenseCosting", ObjEntity.ExpenseCosting);

            long Expense = Convert.ToInt64(ExecuteScalar(cmdAdd));
            ForceCloseConnection();
            return Expense;
        }

        public virtual List<ExpensesEntity> tblExpensesDescription_Select()
        {
            List<ExpensesEntity> lstLocation = new List<ExpensesEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblExpensesDescription_Select";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ExpensesEntity objEntity = new ExpensesEntity();
               
                objEntity.ExpenseID = GetInt32(dr, "ExpenseID");
                objEntity.ExpenseDate = GetDateTime(dr, "ExpenseDate");
                objEntity.UserName = GetTextValue(dr, "UserName");
                objEntity.ExpenseName = GetTextValue(dr, "ExpenseName");
                objEntity.ExpenseDescription = GetTextValue(dr, "ExpenseDescription");
                objEntity.Symbol = GetTextValue(dr,"Symbol");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<ExpensesEntity> tblExpensesDescription_SelectAll()
        {
            List<ExpensesEntity> lstLocation = new List<ExpensesEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblExpensesDescription_SelectAll";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ExpensesEntity objEntity = new ExpensesEntity();

                objEntity.ExpenseID = GetInt32(dr, "ExpenseID");
                objEntity.ExpenseDescriptionID = GetInt32(dr, "ExpensesDescriptionID");
                objEntity.ExpenseDate = GetDateTime(dr, "ExpenseDate");
                objEntity.UserName = GetTextValue(dr, "UserName");
                objEntity.ExpenseName = GetTextValue(dr, "ExpenseName");
                objEntity.ExpenseDescription = GetTextValue(dr, "ExpenseDescription");
                objEntity.Symbol = GetTextValue(dr, "Symbol");
                objEntity.ExpenseCosting = GetTextValue(dr, "ExpenseCosting");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
        
    }
      
}

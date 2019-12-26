
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

    public class EmployeeSQL : BaseSqlManager
    {
        public virtual List<EmployeeEntity> tblEmployeeType_SelectForDropdown()
        {
            List<EmployeeEntity> lstLocation = new List<EmployeeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployeeType_SelectForDropdown";
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                EmployeeEntity objEntity = new EmployeeEntity();
                objEntity.EmployeeTypeID = GetInt32(dr, "EmployeeTypeID");
                objEntity.EmployeeType = GetTextValue(dr, "EmployeeType");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<EmployeeEntity> tblEmployeeStatus_SelectForDropdown()
        {
            List<EmployeeEntity> lstLocation = new List<EmployeeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployeeStatus_SelectForDropdown";
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                EmployeeEntity objEntity = new EmployeeEntity();
                objEntity.EmployeeStatusID = GetInt32(dr, "EmployeeStatusID");
                objEntity.EmployeeStatus = GetTextValue(dr, "EmployeeStatus");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<EmployeeEntity> tblCompanyLocations_ForDropdown()
        {
            List<EmployeeEntity> lstLocation = new List<EmployeeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanyLocations_ForDropdown";
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                EmployeeEntity objEntity = new EmployeeEntity();
                objEntity.CompanyLocationID = GetInt32(dr, "CompanyLocationID");
                objEntity.CompanyLocation = GetTextValue(dr, "CompanyLocation");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<EmployeeEntity> tblSalesTeam_ForDropdown()
        {
            List<EmployeeEntity> lstLocation = new List<EmployeeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblSalesTeam_ForDropdown";
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                EmployeeEntity objEntity = new EmployeeEntity();
                objEntity.SalesTeamID = GetInt32(dr, "SalesTeamID");
                objEntity.SalesTeam = GetTextValue(dr, "SalesTeam");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual int aspnet_Users_Exists(string UserName)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "aspnet_Users_Exists";
            cmdGet.Parameters.AddWithValue("@UserName", UserName);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "ID");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<EmployeeEntity> SpRolesGetDataByAsc()
        {
            List<EmployeeEntity> lstLocation = new List<EmployeeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "SpRolesGetDataByAsc";
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                EmployeeEntity objEntity = new EmployeeEntity();
                objEntity.RoleId = GetTextValue(dr, "RoleId");
                objEntity.RoleName = GetTextValue(dr, "RoleName");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual long tblEmployees_Insert(EmployeeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblEmployees_Insert";
            cmdAdd.Parameters.AddWithValue("@EmpTitle", ObjEntity.EmpTitle);
            cmdAdd.Parameters.AddWithValue("@EmpFirst", ObjEntity.EmpFirst);
            cmdAdd.Parameters.AddWithValue("@EmpLast", ObjEntity.EmpLast);
            cmdAdd.Parameters.AddWithValue("@EmpEmail", ObjEntity.EmpEmail);
            cmdAdd.Parameters.AddWithValue("@EmpMobile", ObjEntity.EmpMobile);
            cmdAdd.Parameters.AddWithValue("@EmpNicName", ObjEntity.EmpNicName);
            cmdAdd.Parameters.AddWithValue("@SalesTeamID", ObjEntity.SalesTeamID);
            //   cmdAdd.Parameters.AddWithValue("@EmployeeTypeID", ObjEntity.EmployeeTypeID);
            //  cmdAdd.Parameters.AddWithValue("@LTeamOutDoor", ObjEntity.LTeamOutDoor);
            // cmdAdd.Parameters.AddWithValue("@LTeamCloser", ObjEntity.LTeamCloser);


            cmdAdd.Parameters.AddWithValue("@EmpInitials", ObjEntity.EmpInitials);

            cmdAdd.Parameters.AddWithValue("@HireDate", ObjEntity.HireDate);
            cmdAdd.Parameters.AddWithValue("@EmployeeStatusID", ObjEntity.EmployeeStatusID);
            cmdAdd.Parameters.AddWithValue("@UserPassword", ObjEntity.UserPassword);
            cmdAdd.Parameters.AddWithValue("@CompanyLocationID", ObjEntity.CompanyLocationID);
            cmdAdd.Parameters.AddWithValue("@TaxFileNumber", ObjEntity.TaxFileNumber);
            cmdAdd.Parameters.AddWithValue("@EmpABN", ObjEntity.EmpABN);
            cmdAdd.Parameters.AddWithValue("@EmpAccountName", ObjEntity.EmpAccountName);
            cmdAdd.Parameters.AddWithValue("@ActiveEmp", ObjEntity.ActiveEmp);
            cmdAdd.Parameters.AddWithValue("@StartTime", ObjEntity.StartTime);
            cmdAdd.Parameters.AddWithValue("@Include", ObjEntity.Include);
            cmdAdd.Parameters.AddWithValue("@EndTime", ObjEntity.EndTime);
            cmdAdd.Parameters.AddWithValue("@OnRoster", ObjEntity.OnRoster);
            cmdAdd.Parameters.AddWithValue("@BreakTime", ObjEntity.BreakTime);
            cmdAdd.Parameters.AddWithValue("@PaysOwnSuper", ObjEntity.PaysOwnSuper);
            cmdAdd.Parameters.AddWithValue("@GSTPayment", ObjEntity.GSTPayment);
            cmdAdd.Parameters.AddWithValue("@EmpInfo", ObjEntity.EmpInfo);
            cmdAdd.Parameters.AddWithValue("@SalesRep", ObjEntity.SalesRep);
            cmdAdd.Parameters.AddWithValue("@AdminStaff", ObjEntity.AdminStaff);
            cmdAdd.Parameters.AddWithValue("@ExecAccess", ObjEntity.ExecAccess);
            cmdAdd.Parameters.AddWithValue("@AdminAccess", ObjEntity.AdminAccess);
            cmdAdd.Parameters.AddWithValue("@DeleteAccess", ObjEntity.DeleteAccess);
            cmdAdd.Parameters.AddWithValue("@ProjDispAccess", ObjEntity.ProjDispAccess);
            cmdAdd.Parameters.AddWithValue("@ManagerAccess", ObjEntity.ManagerAccess);
            cmdAdd.Parameters.AddWithValue("@AdminPL", ObjEntity.AdminPL);
            cmdAdd.Parameters.AddWithValue("@BillsOwingPL", ObjEntity.BillsOwingPL);
            cmdAdd.Parameters.AddWithValue("@BillsPaidPL", ObjEntity.BillsPaidPL);
            cmdAdd.Parameters.AddWithValue("@BookingsPL", ObjEntity.BookingsPL);
            cmdAdd.Parameters.AddWithValue("@CompaniesPL", ObjEntity.CompaniesPL);
            cmdAdd.Parameters.AddWithValue("@ContactsPL", ObjEntity.ContactsPL);
            cmdAdd.Parameters.AddWithValue("@FollowUpPL", ObjEntity.FollowUpPL);
            cmdAdd.Parameters.AddWithValue("@InvIssuedPL", ObjEntity.InvIssuedPL);
            cmdAdd.Parameters.AddWithValue("@InvPaidPL", ObjEntity.InvPaidPL);
            cmdAdd.Parameters.AddWithValue("@MeetingsPL", ObjEntity.MeetingsPL);
            cmdAdd.Parameters.AddWithValue("@ProjectsPL", ObjEntity.ProjectsPL);
            cmdAdd.Parameters.AddWithValue("@StatisticsPL", ObjEntity.StatisticsPL);
            cmdAdd.Parameters.AddWithValue("@StockItemsPL", ObjEntity.StockItemsPL);
            cmdAdd.Parameters.AddWithValue("@StockOrdersPL", ObjEntity.StockOrdersPL);
            cmdAdd.Parameters.AddWithValue("@SuperTaxPL", ObjEntity.SuperTaxPL);
            cmdAdd.Parameters.AddWithValue("@WagesPL", ObjEntity.WagesPL);
            cmdAdd.Parameters.AddWithValue("@WholesalePL", ObjEntity.WholesalePL);
            cmdAdd.Parameters.AddWithValue("@IsDesigner", ObjEntity.IsDesigner);
            cmdAdd.Parameters.AddWithValue("@IsElectrician", ObjEntity.IsElectrician);
            cmdAdd.Parameters.AddWithValue("@IsInstaller", ObjEntity.IsInstaller);
            
            long Employee = Convert.ToInt64(ExecuteScalar(cmdAdd));
            ForceCloseConnection();
            return Employee;
        }

        public virtual void tblEmployees_Update_Userid(long EmployeeID, string userid)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblEmployees_Update_Userid";
            cmdAdd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmdAdd.Parameters.AddWithValue("@userid", userid);

            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblEmployees_Update_Team(long EmployeeID, string SalesTeamID, string EmpType, Boolean LTeamOutDoor, Boolean LTeamCloser)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblEmployees_Update_Team";
            cmdAdd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmdAdd.Parameters.AddWithValue("@SalesTeamID", SalesTeamID);
            cmdAdd.Parameters.AddWithValue("@EmpType", EmpType);
            cmdAdd.Parameters.AddWithValue("@LTeamOutDoor", LTeamOutDoor);
            cmdAdd.Parameters.AddWithValue("@LTeamCloser", LTeamCloser);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual List<EmployeeEntity> tblEmployeesGetDataBySearch(PagingEntity CommonEntity, out int Count)
        {
            List<EmployeeEntity> lstLocation = new List<EmployeeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployeesGetDataBySearch";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                EmployeeEntity objEntity = new EmployeeEntity();
                objEntity.EmployeeID = GetInt32(dr, "EmployeeID");
                objEntity.fullname = GetTextValue(dr, "fullname");
                objEntity.JobTitle = GetTextValue(dr, "JobTitle");
                objEntity.EmpNicName = GetTextValue(dr, "EmpNicName");
                objEntity.EmployeeStatus = GetTextValue(dr, "EmployeeStatus");
                objEntity.SalesTeam = GetTextValue(dr, "SalesTeam");
                // objEntity.Active = GetBoolean(dr, "Active");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual EmployeeEntity tblEmployees_SelectByyEmployeeID(int EmployeeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployees_SelectByyEmployeeID";
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            EmployeeEntity objEntity = new EmployeeEntity();
            while (dr.Read())
            {
                objEntity.EmployeeID = GetInt32(dr, "EmployeeID");
                objEntity.userid = GetTextValue(dr, "userid");
                objEntity.EmpFirst = GetTextValue(dr, "EmpFirst");
                objEntity.EmpLast = GetTextValue(dr, "EmpLast");
                objEntity.EmpTitle = GetTextValue(dr, "EmpTitle");
                objEntity.EmpNicName = GetTextValue(dr, "EmpNicName");
                objEntity.EmpInitials = GetTextValue(dr, "EmpInitials");
                objEntity.EmpEmail = GetTextValue(dr, "EmpEmail");
                objEntity.EmpMobile = GetTextValue(dr, "EmpMobile");
                objEntity.EmployeeStatusID = GetInt32(dr, "EmployeeStatusID");
                objEntity.CompanyLocationID = GetInt32(dr, "Location");
                objEntity.HireDate = GetDateTime(dr, "HireDate");

                objEntity.StartTime = GetTextValue(dr, "StartTime");
                // objEntity.StartTime = GetDateTime(dr, "StartTime");
                //TimeSpan DBStartTime = (TimeSpan)dr["StartTime"];
                //objEntity.StartTime = DBStartTime.ToString();

                objEntity.EndTime = GetTextValue(dr, "EndTime");
                objEntity.BreakTime = GetTextValue(dr, "BreakTime");
                objEntity.ActiveEmp = GetBoolean(dr, "ActiveEmp");
                objEntity.Include = GetBoolean(dr, "Include");
                objEntity.OnRoster = GetBoolean(dr, "OnRoster");
                objEntity.EmpInfo = GetTextValue(dr, "EmpInfo");

                objEntity.AdminPL = GetBoolean(dr, "AdminPL");
                objEntity.InvIssuedPL = GetBoolean(dr, "InvIssuedPL");
                objEntity.SuperTaxPL = GetBoolean(dr, "SuperTaxPL");
                objEntity.ExecAccess = GetBoolean(dr, "ExecAccess");
                objEntity.BookingsPL = GetBoolean(dr, "BookingsPL");
                objEntity.InvPaidPL = GetBoolean(dr, "InvPaidPL");
                objEntity.WagesPL = GetBoolean(dr, "WagesPL");
                objEntity.DeleteAccess = GetBoolean(dr, "DeleteAccess");
                objEntity.CompaniesPL = GetBoolean(dr, "CompaniesPL");
                objEntity.ProjectsPL = GetBoolean(dr, "ProjectsPL");
                objEntity.WholesalePL = GetBoolean(dr, "WholesalePL");
                objEntity.AdminAccess = GetBoolean(dr, "AdminAccess");
                objEntity.ContactsPL = GetBoolean(dr, "ContactsPL");
                objEntity.StockItemsPL = GetBoolean(dr, "StockItemsPL");
                objEntity.BillsOwingPL = GetBoolean(dr, "BillsOwingPL");
                objEntity.ProjDispAccess = GetBoolean(dr, "ProjDispAccess");
                objEntity.StockOrdersPL = GetBoolean(dr, "StockOrdersPL");
                objEntity.FollowUpPL = GetBoolean(dr, "FollowUpPL");
                objEntity.BillsPaidPL = GetBoolean(dr, "BillsPaidPL");
                objEntity.ManagerAccess = GetBoolean(dr, "ManagerAccess");

                objEntity.TaxFileNumber = GetTextValue(dr, "TaxFileNumber");
                objEntity.SuperFund = GetTextValue(dr, "SuperFund");
                objEntity.SuperFundAccount = GetTextValue(dr, "SuperFundAccount");
                objEntity.EmpBSB = GetTextValue(dr, "EmpBSB");
                objEntity.EmpBankAcct = GetTextValue(dr, "EmpBankAcct");
                objEntity.InitialSalesQuota = GetDecimal(dr, "InitialSalesQuota");
                objEntity.EmpAddress = GetTextValue(dr, "EmpAddress");
                objEntity.EmpState = GetTextValue(dr, "EmpState");
                objEntity.EmpPostCode = GetTextValue(dr, "EmpPostCode");
                objEntity.AdminStaff = GetBoolean(dr, "AdminStaff");
                objEntity.SalesRep = GetBoolean(dr, "SalesRep");

            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual void tblEmployees_Update(EmployeeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblEmployees_Update";
            cmdAdd.Parameters.AddWithValue("@EmployeeID", ObjEntity.EmployeeID);
            cmdAdd.Parameters.AddWithValue("@EmpTitle", ObjEntity.EmpTitle);
            cmdAdd.Parameters.AddWithValue("@EmpFirst", ObjEntity.EmpFirst);
            cmdAdd.Parameters.AddWithValue("@EmpLast", ObjEntity.EmpLast);
            cmdAdd.Parameters.AddWithValue("@EmpNicName", ObjEntity.EmpNicName);
            cmdAdd.Parameters.AddWithValue("@EmpInitials", ObjEntity.EmpInitials);
            cmdAdd.Parameters.AddWithValue("@EmpEmail", ObjEntity.EmpEmail);
            cmdAdd.Parameters.AddWithValue("@EmpMobile", ObjEntity.EmpMobile);
            cmdAdd.Parameters.AddWithValue("@EmployeeStatusID", ObjEntity.EmployeeStatusID);
            cmdAdd.Parameters.AddWithValue("@CompanyLocationID", ObjEntity.CompanyLocationID);
            cmdAdd.Parameters.AddWithValue("@HireDate", ObjEntity.HireDate);
            cmdAdd.Parameters.AddWithValue("@StartTime", ObjEntity.StartTime);
            cmdAdd.Parameters.AddWithValue("@EndTime", ObjEntity.EndTime);
            cmdAdd.Parameters.AddWithValue("@BreakTime", ObjEntity.BreakTime);
            cmdAdd.Parameters.AddWithValue("@ActiveEmp", ObjEntity.ActiveEmp);
            cmdAdd.Parameters.AddWithValue("@Include", ObjEntity.Include);
            cmdAdd.Parameters.AddWithValue("@OnRoster", ObjEntity.OnRoster);
            cmdAdd.Parameters.AddWithValue("@EmpInfo", ObjEntity.EmpInfo);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblEmployees_UpdatePermissions(EmployeeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblEmployees_UpdatePermissions";
            cmdAdd.Parameters.AddWithValue("@EmployeeID", ObjEntity.EmployeeID);
            cmdAdd.Parameters.AddWithValue("@AdminPL", ObjEntity.AdminPL);
            cmdAdd.Parameters.AddWithValue("@InvIssuedPL", ObjEntity.InvIssuedPL);
            cmdAdd.Parameters.AddWithValue("@SuperTaxPL", ObjEntity.SuperTaxPL);
            cmdAdd.Parameters.AddWithValue("@ExecAccess", ObjEntity.ExecAccess);
            cmdAdd.Parameters.AddWithValue("@BookingsPL", ObjEntity.BookingsPL);
            cmdAdd.Parameters.AddWithValue("@InvPaidPL", ObjEntity.InvPaidPL);
            cmdAdd.Parameters.AddWithValue("@WagesPL", ObjEntity.WagesPL);
            cmdAdd.Parameters.AddWithValue("@DeleteAccess", ObjEntity.DeleteAccess);
            cmdAdd.Parameters.AddWithValue("@CompaniesPL", ObjEntity.CompaniesPL);
            cmdAdd.Parameters.AddWithValue("@ProjectsPL", ObjEntity.ProjectsPL);
            cmdAdd.Parameters.AddWithValue("@WholesalePL", ObjEntity.WholesalePL);
            cmdAdd.Parameters.AddWithValue("@AdminAccess", ObjEntity.AdminAccess);
            cmdAdd.Parameters.AddWithValue("@ContactsPL", ObjEntity.ContactsPL);
            cmdAdd.Parameters.AddWithValue("@StockItemsPL", ObjEntity.StockItemsPL);
            cmdAdd.Parameters.AddWithValue("@BillsOwingPL", ObjEntity.BillsOwingPL);
            cmdAdd.Parameters.AddWithValue("@ProjDispAccess", ObjEntity.ProjDispAccess);
            cmdAdd.Parameters.AddWithValue("@StockOrdersPL", ObjEntity.StockOrdersPL);
            cmdAdd.Parameters.AddWithValue("@FollowUpPL", ObjEntity.FollowUpPL);
            cmdAdd.Parameters.AddWithValue("@BillsPaidPL", ObjEntity.BillsPaidPL);
            cmdAdd.Parameters.AddWithValue("@ManagerAccess", ObjEntity.ManagerAccess);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblEmployees_UpdateReferences(EmployeeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblEmployees_UpdateReferences";
            cmdAdd.Parameters.AddWithValue("@EmployeeID", ObjEntity.EmployeeID);
            cmdAdd.Parameters.AddWithValue("@TaxFileNumber", ObjEntity.TaxFileNumber);
            cmdAdd.Parameters.AddWithValue("@SuperFund", ObjEntity.SuperFund);
            cmdAdd.Parameters.AddWithValue("@SuperFundAccount", ObjEntity.SuperFundAccount);
            cmdAdd.Parameters.AddWithValue("@EmpBSB", ObjEntity.EmpBSB);
            cmdAdd.Parameters.AddWithValue("@EmpBankAcct", ObjEntity.EmpBankAcct);
            cmdAdd.Parameters.AddWithValue("@InitialSalesQuota", ObjEntity.InitialSalesQuota);
            cmdAdd.Parameters.AddWithValue("@EmpAddress", ObjEntity.EmpAddress);
            cmdAdd.Parameters.AddWithValue("@EmpCity", ObjEntity.EmpCity);
            cmdAdd.Parameters.AddWithValue("@EmpState", ObjEntity.EmpState);
            cmdAdd.Parameters.AddWithValue("@EmpPostCode", ObjEntity.EmpPostCode);
            cmdAdd.Parameters.AddWithValue("@AdminStaff", ObjEntity.AdminStaff);
            cmdAdd.Parameters.AddWithValue("@SalesRep", ObjEntity.SalesRep);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual bool tblEmployees_UpdatePassword(string UserId, string Password)
        {
            try
            {
                SqlCommand cmdAdd = new SqlCommand();
                cmdAdd.CommandType = CommandType.StoredProcedure;
                cmdAdd.CommandText = "tblEmployees_UpdatePassword";
                cmdAdd.Parameters.AddWithValue("@UserId", UserId);
                cmdAdd.Parameters.AddWithValue("@Password", Password);
                ExecuteNonQuery(cmdAdd);
                ForceCloseConnection();
                return true;
            }

            catch
            {
                return false;
            }
        }



        #region Manoj Code

        public virtual EmployeeEntity tblEmployees_SelectByUserId(String userid)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployees_SelectByUserId";
            cmdGet.Parameters.AddWithValue("@userid", userid);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            EmployeeEntity details = new EmployeeEntity();
            while (dr.Read())
            {
                details.EmployeeID = GetInt32(dr, "EmployeeID");
                details.ContactID = GetInt32(dr, "ContactID");
                details.EmployeeStatusID = GetInt32(dr, "EmployeeStatusID");
                details.SalesRep = GetBoolean(dr, "SalesRep");
                details.SalesTeamID = GetInt32(dr, "SalesTeamID");
                details.SalesQuotaPeriodID = GetTextValue(dr, "SalesQuotaPeriodID");
                details.InitialSalesQuota = GetDecimal(dr, "InitialSalesQuota");
                details.AdminStaff = GetBoolean(dr, "AdminStaff");
                details.HireDate = GetDateTime(dr, "HireDate");
                details.CompanyLocationID = GetInt32(dr, "Location");
                details.EmpMr = GetTextValue(dr, "EmpMr");
                details.EmpFirst = GetTextValue(dr, "EmpFirst");
                details.EmpLast = GetTextValue(dr, "EmpLast");
                details.EmpAddress = GetTextValue(dr, "EmpAddress");
                details.EmpCity = GetTextValue(dr, "EmpCity");
                details.EmpState = GetTextValue(dr, "EmpState");
                details.EmpPostCode = GetTextValue(dr, "EmpPostCode");
                details.EmpTitle = GetTextValue(dr, "EmpTitle");
                details.EmpMobile = GetTextValue(dr, "EmpMobile");
                details.EmpEmail = GetTextValue(dr, "EmpEmail");
                details.EmpPersEmail = GetTextValue(dr, "EmpPersEmail");
                details.EmpInitials = GetTextValue(dr, "EmpInitials");
                details.EmpInfo = GetTextValue(dr, "EmpInfo");
                details.UserPassword = GetTextValue(dr, "UserPassword");
                details.TaxFileNumber = GetTextValue(dr, "TaxFileNumber");
                details.SuperFund = GetTextValue(dr, "SuperFund");
                details.SuperFundAccount = GetTextValue(dr, "SuperFundAccount");
                details.PaysOwnSuper = GetBoolean(dr, "PaysOwnSuper");
                details.EmpBSB = GetTextValue(dr, "EmpBSB");
                details.EmpBankAcct = GetTextValue(dr, "EmpBankAcct");
                details.Include = GetBoolean(dr, "Include");
                details.ActiveEmp = GetBoolean(dr, "ActiveEmp");
                details.EmpNicName = GetTextValue(dr, "EmpNicName");
                details.DateOfBirth = GetTextValue(dr, "DateOfBirth");
                details.ExecAccess = GetBoolean(dr, "ExecAccess");
                details.AdminAccess = GetBoolean(dr, "AdminAccess");
                details.DeleteAccess = GetBoolean(dr, "DeleteAccess");
                details.ProjDispAccess = GetBoolean(dr, "ProjDispAccess");
                details.ManagerAccess = GetBoolean(dr, "ManagerAccess");
                details.AdminPL = GetBoolean(dr, "AdminPL");
                details.BillsOwingPL = GetBoolean(dr, "BillsOwingPL");
                details.BillsPaidPL = GetBoolean(dr, "BillsPaidPL");
                details.BookingsPL = GetBoolean(dr, "BookingsPL");
                details.CompaniesPL = GetBoolean(dr, "CompaniesPL");
                details.ContactsPL = GetBoolean(dr, "ContactsPL");
                details.FollowUpPL = GetBoolean(dr, "FollowUpPL");
                details.InvIssuedPL = GetBoolean(dr, "InvIssuedPL");
                details.InvPaidPL = GetBoolean(dr, "InvPaidPL");
                details.MeetingsPL = GetBoolean(dr, "MeetingsPL");
                details.ProjectsPL = GetBoolean(dr, "ProjectsPL");
                details.StatisticsPL = GetBoolean(dr, "StatisticsPL");
                details.StockItemsPL = GetBoolean(dr, "StockItemsPL");
                details.StockOrdersPL = GetBoolean(dr, "StockOrdersPL");
                details.SuperTaxPL = GetBoolean(dr, "SuperTaxPL");
                details.WagesPL = GetBoolean(dr, "WagesPL");
                details.WholesalePL = GetBoolean(dr, "WholesalePL");
                details.OnRoster = GetBoolean(dr, "OnRoster");
                details.StartTime = GetTextValue(dr, "StartTime");
                details.EndTime = GetTextValue(dr, "EndTime");
                details.BreakTime = GetTextValue(dr, "BreakTime");
               // details.upsize_ts = GetTextValue(dr, "upsize_ts");
                details.userid = GetTextValue(dr, "userid");
                details.EmpType = GetInt32(dr, "EmpType");
                details.EmpABN = GetTextValue(dr, "EmpABN");
                details.EmpAccountName = GetTextValue(dr, "EmpAccountName");
            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }

        public virtual EmployeeEntity tblEmployees_SelectEmployeeID(String userid)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployees_SelectEmployeeID";
            cmdGet.Parameters.AddWithValue("@userid", userid);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            EmployeeEntity details = new EmployeeEntity();
            while (dr.Read())
            {
                details.EmployeeID = GetInt32(dr, "EmployeeID");
                details.EmpFirst = GetTextValue(dr, "EmpFirst");
                details.EmpLast = GetTextValue(dr, "EmpLast");
            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }

        public virtual EmployeeEntity tblEmployees_SelectBYEmployeeID(long EmployeeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployees_SelectBYEmployeeID";
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            EmployeeEntity details = new EmployeeEntity();
            while (dr.Read())
            {
                details.EmployeeID = GetInt32(dr, "EmployeeID");
                details.EmpFirst = GetTextValue(dr, "EmpFirst");
                details.EmpLast = GetTextValue(dr, "EmpLast");
            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }

        public virtual AspnetUserEntity aspnet_Users_SelectByUserId(string userid)
        {
            AspnetUserEntity details = new AspnetUserEntity();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "aspnet_Users_SelectByUserId";
            cmdGet.Parameters.AddWithValue("@userid", userid);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                details.ApplicationId = GetTextValue(dr, "ApplicationId");
                details.UserId = GetTextValue(dr, "UserId");
                details.UserName = GetTextValue(dr, "UserName");
                details.LoweredUserName = GetTextValue(dr, "LoweredUserName");
                details.MobileAlias = GetTextValue(dr, "MobileAlias");
                details.IsAnonymous = GetTextValue(dr, "IsAnonymous");
                details.LastActivityDate = GetTextValue(dr, "LastActivityDate");
            }
            dr.Close();
            ForceCloseConnection();
            return details;

        }

        public virtual bool aspnetUsers_Update_LastActivityDate(string userid)
        {
            try
            {
                SqlCommand cmdAdd = new SqlCommand();
                cmdAdd.CommandType = CommandType.StoredProcedure;
                cmdAdd.CommandText = "aspnetUsers_Update_LastActivityDate";
                cmdAdd.Parameters.AddWithValue("@userid", userid);
                ExecuteNonQuery(cmdAdd);
                ForceCloseConnection();
                return true;
            }
            catch
            {
                return false;
            }

        }

        #endregion



        public virtual EmployeeEntity tblEmployees_SelectActiveByEmployeeID(long EmployeeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployees_SelectActiveByEmployeeID";
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            EmployeeEntity details = new EmployeeEntity();
            while (dr.Read())
            {
                details.EmployeeID = GetInt32(dr, "EmployeeID");
                details.ActiveEmp = GetBoolean(dr, "ActiveEmp");
               
            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }





        public virtual List<EmployeeEntity> tblEmployees_SelectASC(long EmployeeID, int ActiveEmp)
        {
            List<EmployeeEntity> lstLocation = new List<EmployeeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployees_SelectASC";
            cmdGet.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmdGet.Parameters.AddWithValue("@ActiveEmp", ActiveEmp);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                EmployeeEntity objEntity = new EmployeeEntity();
                objEntity.EmployeeID = GetInt32(dr, "EmployeeID");
                objEntity.fullname = GetTextValue(dr, "fullname");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual EmployeeEntity tblEmployees_ManagerSelect(long SalesTeamID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployees_ManagerSelect";
            cmdGet.Parameters.AddWithValue("@SalesTeamID", SalesTeamID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            EmployeeEntity details = new EmployeeEntity();
            while (dr.Read())
            {
                details.EmployeeID = GetInt32(dr, "EmployeeID");
                details.fullname = GetTextValue(dr, "fullname");
                details.EmpNicName = GetTextValue(dr, "EmpNicName");
                details.userid = GetTextValue(dr, "userid");
            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }

        public virtual List<EmployeeEntity> tblEmployees_SelectInstaller()
        {
            List<EmployeeEntity> lstLocation = new List<EmployeeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployees_SelectInstaller";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                EmployeeEntity objEntity = new EmployeeEntity();
                objEntity.fullname = GetTextValue(dr, "EmpName");
                objEntity.userid = GetTextValue(dr, "UserID");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
        public virtual List<EmployeeEntity> tblEmployees_SelectInstallerDesigner()
        {
            List<EmployeeEntity> lstLocation = new List<EmployeeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployees_SelectInstallerDesigner";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                EmployeeEntity objEntity = new EmployeeEntity();
                objEntity.fullname = GetTextValue(dr, "EmpName");
                objEntity.userid = GetTextValue(dr, "UserID");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
        public virtual List<EmployeeEntity> tblEmployees_SelectInstallerElectrician()
        {
            List<EmployeeEntity> lstLocation = new List<EmployeeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployees_SelectInstallerElectrician";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                EmployeeEntity objEntity = new EmployeeEntity();
                objEntity.fullname = GetTextValue(dr, "EmpName");
                objEntity.userid = GetTextValue(dr, "UserID");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
        public virtual List<EmployeeEntity> tblEmployees_CheckInstDesigner(string userid)
        {
            List<EmployeeEntity> lstLocation = new List<EmployeeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployees_CheckInstDesigner";
            cmdGet.Parameters.AddWithValue("@UserId", userid);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                EmployeeEntity objEntity = new EmployeeEntity();
              
                objEntity.userid = GetTextValue(dr, "UserID");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
        public virtual List<EmployeeEntity> tblEmployees_CheckInstElectrician( string userid)
        {
            List<EmployeeEntity> lstLocation = new List<EmployeeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployees_CheckInstElectrician";
            cmdGet.Parameters.AddWithValue("@UserId", userid);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                EmployeeEntity objEntity = new EmployeeEntity();
               
                objEntity.userid = GetTextValue(dr, "UserID");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<EmployeeEntity> aspnet_UsersInRoles_Select(string RoleId)
        {
            List<EmployeeEntity> lstLocation = new List<EmployeeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "aspnet_UsersInRoles_Select";
            cmdGet.Parameters.AddWithValue("@RoleId", RoleId);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                EmployeeEntity objEntity = new EmployeeEntity();
                objEntity.EmployeeID = GetInt32(dr, "EmployeeID");
                objEntity.FullName = GetTextValue(dr, "FullName");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
       
        public virtual ProjectCount tblEmployees_Count()
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployees_Count";
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectCount objEntity = new ProjectCount();
            while (dr.Read())
            {
                objEntity.Total = GetInt32(dr, "TotalEmp");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }
    }
}

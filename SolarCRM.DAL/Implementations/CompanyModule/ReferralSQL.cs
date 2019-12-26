using SolarCRM.Entity.Models.CompanyModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.DAL.Implementations.CompanyModule
{
    public class ReferralSQL : BaseSqlManager
    {
        public virtual void tblReferral_InsertByCompany(long CustomerID, long ContactID, long EmployeeID, DateTime ReferralDate, string ReferredByProjectNo, string ReferredByCustomerName, string ReferredByProjectStatus, string ReferralNotes, string ReferredByBalOwing)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblReferral_InsertByCompany";
            cmdAdd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdAdd.Parameters.AddWithValue("@ContactID", ContactID);
            cmdAdd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmdAdd.Parameters.AddWithValue("@ReferralDate", ReferralDate);
            cmdAdd.Parameters.AddWithValue("@ReferredByProjectNo", ReferredByProjectNo);
            cmdAdd.Parameters.AddWithValue("@ReferredByCustomerName", ReferredByCustomerName);
            cmdAdd.Parameters.AddWithValue("@ReferredByProjectStatus", ReferredByProjectStatus);
            cmdAdd.Parameters.AddWithValue("@ReferralNotes", ReferralNotes);
            cmdAdd.Parameters.AddWithValue("@ReferredByBalOwing", ReferredByBalOwing);

            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
        }


        public virtual ReferralEntity tblReferral_SelectByReferralID(long CustomerID, string id, string ProjectID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblReferral_SelectByReferralID";
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdGet.Parameters.AddWithValue("@id", id);
            cmdGet.Parameters.AddWithValue("@ProjectID", ProjectID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ReferralEntity ObjEntity = new ReferralEntity();
            while (dr.Read())
            {
                ObjEntity.ReferralID = GetInt64(dr, "ReferralID");
                ObjEntity.CustomerID = GetInt64(dr, "CustomerID");
                ObjEntity.ContactID = GetInt64(dr, "ContactID");
                ObjEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                ObjEntity.ReferralDate = GetDateTime(dr, "ReferralDate");
                ObjEntity.ReferralPaidDate = GetDateTime(dr, "ReferralPaidDate");
                ObjEntity.ReferralAmount = GetDecimal(dr,"ReferralAmount");
                ObjEntity.PayMethodID = GetInt32(dr, "PayMethodID");
                ObjEntity.PayReference = GetTextValue(dr, "PayReference");
                ObjEntity.ReferredProjectNo = GetInt64(dr, "ReferredProjectNo");
                ObjEntity.ReferredProjectStatus = GetInt32(dr, "ReferredProjectStatus");
                ObjEntity.ReferredCustomerName = GetTextValue(dr, "ReferredCustomerName");
                ObjEntity.ReferredSystemSize = GetDecimal(dr, "ReferredSystemSize");
                ObjEntity.ReferredBalOS = GetDecimal(dr, "ReferredBalOS");
                ObjEntity.ReferredByProjectNo = GetTextValue(dr, "ReferredByProjectNo");
                ObjEntity.ReferredByCustomerName = GetTextValue(dr, "ReferredByCustomerName");
                ObjEntity.ReferredByProjectStatus = GetInt32(dr, "ReferredByProjectStatus");
                ObjEntity.ReferredByBalOS = GetDecimal(dr, "ReferredByBalOS");
                ObjEntity.ReferralNotes = GetTextValue(dr, "ReferralNotes");
                ObjEntity.IsRefPaid = GetBoolean(dr, "IsRefPaid");
            }
            dr.Close();
            ForceCloseConnection();
            return ObjEntity;
        }


        public virtual void tblReferral_UpdateByCompany(ReferralEntity obj)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblReferral_UpdateByCompany";
            cmdAdd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmdAdd.Parameters.AddWithValue("@ContactID", obj.ContactID);
            cmdAdd.Parameters.AddWithValue("@EmployeeID", obj.EmployeeID);
            cmdAdd.Parameters.AddWithValue("@ReferralDate", obj.ReferralDate);
            cmdAdd.Parameters.AddWithValue("@ReferredByProjectNo", obj.ReferredByProjectNo);
            cmdAdd.Parameters.AddWithValue("@ReferredByCustomerName", obj.ReferredByCustomerName);
            cmdAdd.Parameters.AddWithValue("@ReferredByProjectStatus", obj.ReferredByProjectStatus);
            cmdAdd.Parameters.AddWithValue("@ReferralNotes", obj.ReferralNotes);
            cmdAdd.Parameters.AddWithValue("@ReferredProjectNo", obj.ReferredProjectNo);
            cmdAdd.Parameters.AddWithValue("@ReferredProjectStatus", obj.ReferredProjectStatus);
            cmdAdd.Parameters.AddWithValue("@ReferredCustomerName", obj.ReferredCustomerName);
            cmdAdd.Parameters.AddWithValue("@ReferredSystemSize", obj.ReferredSystemSize);
            cmdAdd.Parameters.AddWithValue("@ReferredBalOS", obj.ReferredBalOS);
            cmdAdd.Parameters.AddWithValue("@ReferredByBalOS", obj.ReferredByBalOS);
            cmdAdd.Parameters.AddWithValue("@ReferralPaidDate", obj.ReferralPaidDate);
            cmdAdd.Parameters.AddWithValue("@ReferralAmount", obj.ReferralAmount);
            cmdAdd.Parameters.AddWithValue("@PayMethodID", obj.PayMethodID);
            cmdAdd.Parameters.AddWithValue("@PayReference", obj.PayReference);
            cmdAdd.Parameters.AddWithValue("@id", obj.id);
            cmdAdd.Parameters.AddWithValue("@ReferralID", obj.ReferralID);
            cmdAdd.Parameters.AddWithValue("@IsRefPaid", obj.IsRefPaid);

            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }
    }
}

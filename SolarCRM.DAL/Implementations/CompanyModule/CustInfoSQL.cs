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
    public class CustInfoSQL : BaseSqlManager
    {
        public virtual long tblCustInfo_Insert(CustInfoEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCustInfo_Insert";
            cmdAdd.Parameters.AddWithValue("@CustomerID", ObjEntity.CustomerID);
            cmdAdd.Parameters.AddWithValue("@Description", ObjEntity.Description);
            cmdAdd.Parameters.AddWithValue("@FollowupDate", ObjEntity.FollowupDate);
            cmdAdd.Parameters.AddWithValue("@NextFollowupDate", ObjEntity.NextFollowupDate);
            cmdAdd.Parameters.AddWithValue("@ContactID", ObjEntity.ContactID);
            cmdAdd.Parameters.AddWithValue("@CustInfoEnteredBy", ObjEntity.CustInfoEnteredBy);
            cmdAdd.Parameters.AddWithValue("@FollowupType", ObjEntity.FollowupType);

            long CustInfoID = Convert.ToInt64(ExecuteScalar(cmdAdd));
            //long CustomerID = ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
            return CustInfoID;
        }


        public virtual List<CustInfoEntity> tblCustInfo_SelectByCustomerID(long CustomerID)
        {
            List<CustInfoEntity> lstContactNotes = new List<CustInfoEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustInfo_SelectByCustomerID";
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CustInfoEntity objEntity = new CustInfoEntity();

                objEntity.CustInfoID = GetInt64(dr, "CustInfoID");
                objEntity.ContactName = GetTextValue(dr, "ContactName");
                objEntity.FollowupDate = GetDateTime(dr, "FollowupDate");
                objEntity.NextFollowupDate = GetDateTime(dr, "NextFollowupDate");
                objEntity.Description = GetTextValue(dr, "Description");

                lstContactNotes.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstContactNotes;
        }


        public virtual CustInfoEntity tblCustInfo_SelectForEdit(long CustInfoID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustInfo_SelectForEdit";
            cmdGet.Parameters.AddWithValue("@CustInfoID", CustInfoID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            CustInfoEntity objEntity = new CustInfoEntity();
            while (dr.Read())
            {
                objEntity.CustInfoID = GetInt64(dr, "CustInfoID");
                objEntity.ContactID = GetInt64(dr, "ContactID");
                objEntity.FollowupDate = GetDateTime(dr, "FollowupDate");
                objEntity.NextFollowupDate = GetDateTime(dr, "NextFollowupDate");
                objEntity.Description = GetTextValue(dr, "Description");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual long tblCustInfo_Update(CustInfoEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCustInfo_Update";
            cmdAdd.Parameters.AddWithValue("@CustInfoID", ObjEntity.CustInfoID);
            cmdAdd.Parameters.AddWithValue("@CustomerID", ObjEntity.CustomerID);
            cmdAdd.Parameters.AddWithValue("@Description", ObjEntity.Description);
            cmdAdd.Parameters.AddWithValue("@FollowupDate", ObjEntity.FollowupDate);
            cmdAdd.Parameters.AddWithValue("@NextFollowupDate", ObjEntity.NextFollowupDate);
            cmdAdd.Parameters.AddWithValue("@ContactID", ObjEntity.ContactID);
            cmdAdd.Parameters.AddWithValue("@CustInfoEnteredBy", ObjEntity.CustInfoEnteredBy);

            long CustInfoID = Convert.ToInt64(ExecuteScalar(cmdAdd));
            //long CustomerID = ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
            return CustInfoID;
        }

        
    }
}

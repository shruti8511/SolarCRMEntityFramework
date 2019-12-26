
namespace SolarCRM.DAL.Implementations.MastersModule
{
    using SolarCRM.Entity.Models.Common;
    using SolarCRM.Entity.Models.MastersModule;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InsuranceClaimStatusSQL : BaseSqlManager
    {
        public virtual void tblInsuranceClaimStatus_Insert(InsuranceClaimStatusEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblInsuranceClaimStatus_Insert";
            cmdAdd.Parameters.AddWithValue("@InsuranceClaimStatus", ObjEntity.InsuranceClaimStatus);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblInsuranceClaimStatus_Exists(string InsuranceClaimStatus)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInsuranceClaimStatus_Exists";
            cmdGet.Parameters.AddWithValue("@InsuranceClaimStatus", InsuranceClaimStatus);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "InsuranceClaimStatus");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<InsuranceClaimStatusEntity> tblInsuranceClaimStatus_Select(PagingEntity CommonEntity, out int Count)
        {
            List<InsuranceClaimStatusEntity> lstLocation = new List<InsuranceClaimStatusEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInsuranceClaimStatus_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                InsuranceClaimStatusEntity objEntity = new InsuranceClaimStatusEntity();
                objEntity.InsuranceClaimStatusID = GetInt32(dr, "InsuranceClaimStatusID");
                objEntity.InsuranceClaimStatus = GetTextValue(dr, "InsuranceClaimStatus");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<InsuranceClaimStatusEntity> tblInsuranceClaimStatus_SelectActive()
        {
            List<InsuranceClaimStatusEntity> lstLocation = new List<InsuranceClaimStatusEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInsuranceClaimStatus_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                InsuranceClaimStatusEntity objEntity = new InsuranceClaimStatusEntity();
                objEntity.InsuranceClaimStatusID = GetInt32(dr, "InsuranceClaimStatusID");
                objEntity.InsuranceClaimStatus = GetTextValue(dr, "InsuranceClaimStatus");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual InsuranceClaimStatusEntity tblInsuranceClaimStatus_ForEdit(int InsuranceClaimStatusID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInsuranceClaimStatus_ForEdit";
            cmdGet.Parameters.AddWithValue("@InsuranceClaimStatusID", InsuranceClaimStatusID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            InsuranceClaimStatusEntity objEntity = new InsuranceClaimStatusEntity();
            while (dr.Read())
            {
                objEntity.InsuranceClaimStatusID = GetInt32(dr, "InsuranceClaimStatusID");
                objEntity.InsuranceClaimStatus = GetTextValue(dr, "InsuranceClaimStatus");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual InsuranceClaimStatusEntity tblInsuranceClaimStatus_SelectForUpdate(string InsuranceClaimStatus, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInsuranceClaimStatus_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@InsuranceClaimStatus", InsuranceClaimStatus);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            InsuranceClaimStatusEntity objEntity = new InsuranceClaimStatusEntity();
            while (dr.Read())
            {
                objEntity.InsuranceClaimStatus = GetTextValue(dr, "InsuranceClaimStatus");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblInsuranceClaimStatus_Update(InsuranceClaimStatusEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblInsuranceClaimStatus_Update";
            cmdAdd.Parameters.AddWithValue("@InsuranceClaimStatusID", ObjEntity.InsuranceClaimStatusID);
            cmdAdd.Parameters.AddWithValue("@InsuranceClaimStatus", ObjEntity.InsuranceClaimStatus);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblInsuranceClaimStatus_Delete(int InsuranceClaimStatusID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblInsuranceClaimStatus_Delete";
            cmdDel.Parameters.AddWithValue("@InsuranceClaimStatusID", InsuranceClaimStatusID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

    }
}

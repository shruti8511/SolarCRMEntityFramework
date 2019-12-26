
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

    public class InsuranceCompanySQL : BaseSqlManager
    {
        public virtual void tblInsuranceCompany_Insert(InsuranceCompanyEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblInsuranceCompany_Insert";
            cmdAdd.Parameters.AddWithValue("@InsuranceCompany", ObjEntity.InsuranceCompany);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblInsuranceCompany_Exists(string InsuranceCompany)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInsuranceCompany_Exists";
            cmdGet.Parameters.AddWithValue("@InsuranceCompany", InsuranceCompany);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "InsuranceCompany");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<InsuranceCompanyEntity> tblInsuranceCompany_Select(PagingEntity CommonEntity, out int Count)
        {
            List<InsuranceCompanyEntity> lstLocation = new List<InsuranceCompanyEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInsuranceCompany_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                InsuranceCompanyEntity objEntity = new InsuranceCompanyEntity();
                objEntity.InsuranceCompanyID = GetInt32(dr, "InsuranceCompanyID");
                objEntity.InsuranceCompany = GetTextValue(dr, "InsuranceCompany");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<InsuranceCompanyEntity> tblInsuranceCompany_SelectActive()
        {
            List<InsuranceCompanyEntity> lstLocation = new List<InsuranceCompanyEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInsuranceCompany_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                InsuranceCompanyEntity objEntity = new InsuranceCompanyEntity();
                objEntity.InsuranceCompanyID = GetInt32(dr, "InsuranceCompanyID");
                objEntity.InsuranceCompany = GetTextValue(dr, "InsuranceCompany");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual InsuranceCompanyEntity tblInsuranceCompany_ForEdit(int InsuranceCompanyID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInsuranceCompany_ForEdit";
            cmdGet.Parameters.AddWithValue("@InsuranceCompanyID", InsuranceCompanyID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            InsuranceCompanyEntity objEntity = new InsuranceCompanyEntity();
            while (dr.Read())
            {
                objEntity.InsuranceCompanyID = GetInt32(dr, "InsuranceCompanyID");
                objEntity.InsuranceCompany = GetTextValue(dr, "InsuranceCompany");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual InsuranceCompanyEntity tblInsuranceCompany_SelectForUpdate(string InsuranceCompany, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInsuranceCompany_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@InsuranceCompany", InsuranceCompany);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            InsuranceCompanyEntity objEntity = new InsuranceCompanyEntity();
            while (dr.Read())
            {
                objEntity.InsuranceCompany = GetTextValue(dr, "InsuranceCompany");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblInsuranceCompany_Update(InsuranceCompanyEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblInsuranceCompany_Update";
            cmdAdd.Parameters.AddWithValue("@InsuranceCompanyID", ObjEntity.InsuranceCompanyID);
            cmdAdd.Parameters.AddWithValue("@InsuranceCompany", ObjEntity.InsuranceCompany);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblInsuranceCompany_Delete(int InsuranceCompanyID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblInsuranceCompany_Delete";
            cmdDel.Parameters.AddWithValue("@InsuranceCompanyID", InsuranceCompanyID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

    }
}

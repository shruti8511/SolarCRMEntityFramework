
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

    public class InsuranceTypeSQL : BaseSqlManager
    {
        public virtual void tblInsuranceType_Insert(InsuranceTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblInsuranceType_Insert";
            cmdAdd.Parameters.AddWithValue("@InsuranceType", ObjEntity.InsuranceType);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblInsuranceType_Exists(string InsuranceType)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInsuranceType_Exists";
            cmdGet.Parameters.AddWithValue("@InsuranceType", InsuranceType);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "InsuranceType");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<InsuranceTypeEntity> tblInsuranceType_Select(PagingEntity CommonEntity, out int Count)
        {
            List<InsuranceTypeEntity> lstLocation = new List<InsuranceTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInsuranceType_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                InsuranceTypeEntity objEntity = new InsuranceTypeEntity();
                objEntity.InsuranceTypeID = GetInt32(dr, "InsuranceTypeID");
                objEntity.InsuranceType = GetTextValue(dr, "InsuranceType");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<InsuranceTypeEntity> tblInsuranceType_SelectActive()
        {
            List<InsuranceTypeEntity> lstLocation = new List<InsuranceTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInsuranceType_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                InsuranceTypeEntity objEntity = new InsuranceTypeEntity();
                objEntity.InsuranceTypeID = GetInt32(dr, "InsuranceTypeID");
                objEntity.InsuranceType = GetTextValue(dr, "InsuranceType");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual InsuranceTypeEntity tblInsuranceType_ForEdit(int InsuranceTypeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInsuranceType_ForEdit";
            cmdGet.Parameters.AddWithValue("@InsuranceTypeID", InsuranceTypeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            InsuranceTypeEntity objEntity = new InsuranceTypeEntity();
            while (dr.Read())
            {
                objEntity.InsuranceTypeID = GetInt32(dr, "InsuranceTypeID");
                objEntity.InsuranceType = GetTextValue(dr, "InsuranceType");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual InsuranceTypeEntity tblInsuranceType_SelectForUpdate(string InsuranceType, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblInsuranceType_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@InsuranceType", InsuranceType);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            InsuranceTypeEntity objEntity = new InsuranceTypeEntity();
            while (dr.Read())
            {
                objEntity.InsuranceType = GetTextValue(dr, "InsuranceType");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblInsuranceType_Update(InsuranceTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblInsuranceType_Update";
            cmdAdd.Parameters.AddWithValue("@InsuranceTypeID", ObjEntity.InsuranceTypeID);
            cmdAdd.Parameters.AddWithValue("@InsuranceType", ObjEntity.InsuranceType);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblInsuranceType_Delete(int InsuranceTypeID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblInsuranceType_Delete";
            cmdDel.Parameters.AddWithValue("@InsuranceTypeID", InsuranceTypeID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

    }
}

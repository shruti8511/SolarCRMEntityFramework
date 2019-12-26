

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

    public class CompanyTypeSQL : BaseSqlManager
    {
        public virtual void tblCompanyType_Insert(CompanyTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCompanyType_Insert";
            cmdAdd.Parameters.AddWithValue("@CompanyType", ObjEntity.CompanyType);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblCompanyType_Exists(string CompanyType)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanyType_Exists";
            cmdGet.Parameters.AddWithValue("@CompanyType", CompanyType);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "CompanyType");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<CompanyTypeEntity> tblCompanyType_Select(PagingEntity CommonEntity, out int Count)
        {
            List<CompanyTypeEntity> lstLocation = new List<CompanyTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanyType_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CompanyTypeEntity objEntity = new CompanyTypeEntity();
                objEntity.CompanyTypeID = GetInt32(dr, "CompanyTypeID");
                objEntity.CompanyType = GetTextValue(dr, "CompanyType");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<CompanyTypeEntity> tblCompanyType_SelectActive()
        {
            List<CompanyTypeEntity> lstLocation = new List<CompanyTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanyType_SelectActive";
           
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CompanyTypeEntity objEntity = new CompanyTypeEntity();
                objEntity.CompanyTypeID = GetInt32(dr, "CompanyTypeID");
                objEntity.CompanyType = GetTextValue(dr, "CompanyType");             
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual CompanyTypeEntity tblCompanyType_ForEdit(int CompanyTypeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanyType_ForEdit";
            cmdGet.Parameters.AddWithValue("@CompanyTypeID", CompanyTypeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            CompanyTypeEntity objEntity = new CompanyTypeEntity();
            while (dr.Read())
            {
                objEntity.CompanyTypeID = GetInt32(dr, "CompanyTypeID");
                objEntity.CompanyType = GetTextValue(dr, "CompanyType");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual CompanyTypeEntity tblCompanyType_SelectForUpdate(string CompanyType, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanyType_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@CompanyType", CompanyType);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            CompanyTypeEntity objEntity = new CompanyTypeEntity();
            while (dr.Read())
            {
                objEntity.CompanyType = GetTextValue(dr, "CompanyType");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblCompanyType_Update(CompanyTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCompanyType_Update";
            cmdAdd.Parameters.AddWithValue("@CompanyTypeID", ObjEntity.CompanyTypeID);
            cmdAdd.Parameters.AddWithValue("@CompanyType", ObjEntity.CompanyType);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblCompanyType_Delete(int CompanyTypeID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblCompanyType_Delete";
            cmdDel.Parameters.AddWithValue("@CompanyTypeID", CompanyTypeID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }
    }
}

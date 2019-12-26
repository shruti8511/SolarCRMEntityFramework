

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

    public class CompanySourceSQL : BaseSqlManager
    {
        public virtual void tblCompanySource_Insert(CompanySourceEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCompanySource_Insert";
            cmdAdd.Parameters.AddWithValue("@CompanySource", ObjEntity.CompanySource);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            cmdAdd.Parameters.AddWithValue("@LeadSelect", ObjEntity.LeadSelect);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblCompanySource_Exists(string CompanySource)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanySource_Exists";
            cmdGet.Parameters.AddWithValue("@CompanySource", CompanySource);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "CompanySource");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<CompanySourceEntity> tblCompanySource_Select(PagingEntity CommonEntity, out int Count)
        {
            List<CompanySourceEntity> lstLocation = new List<CompanySourceEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanySource_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CompanySourceEntity objEntity = new CompanySourceEntity();
                objEntity.CompanySourceID = GetInt32(dr, "CompanySourceID");
                objEntity.CompanySource = GetTextValue(dr, "CompanySource");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<CompanySourceEntity> tblCompanySource_SelectActive()
        {
            List<CompanySourceEntity> lstLocation = new List<CompanySourceEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanySource_SelectActive";
           
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CompanySourceEntity objEntity = new CompanySourceEntity();
                objEntity.CompanySourceID = GetInt32(dr, "CompanySourceID");
                objEntity.CompanySource = GetTextValue(dr, "CompanySource");          
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual CompanySourceEntity tblCompanySource_ForEdit(int CompanySourceID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanySource_ForEdit";
            cmdGet.Parameters.AddWithValue("@CompanySourceID", CompanySourceID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            CompanySourceEntity objEntity = new CompanySourceEntity();
            while (dr.Read())
            {
                objEntity.CompanySourceID = GetInt32(dr, "CompanySourceID");
                objEntity.CompanySource = GetTextValue(dr, "CompanySource");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual CompanySourceEntity tblCompanySource_SelectForUpdate(string CompanySource, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanySource_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@CompanySource", CompanySource);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            CompanySourceEntity objEntity = new CompanySourceEntity();
            while (dr.Read())
            {
                objEntity.CompanySource = GetTextValue(dr, "CompanySource");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblCompanySource_Update(CompanySourceEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCompanySource_Update";
            cmdAdd.Parameters.AddWithValue("@CompanySourceID", ObjEntity.CompanySourceID);
            cmdAdd.Parameters.AddWithValue("@CompanySource", ObjEntity.CompanySource);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblCompanySource_Delete(int CompanySourceID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblCompanySource_Delete";
            cmdDel.Parameters.AddWithValue("@CompanySourceID", CompanySourceID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

    }
}

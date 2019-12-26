

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

    public class CompanySourceSubSQL : BaseSqlManager
    {

        public virtual List<CompanySourceSubEntity> tblCompanySource_SelectForDropdown()
       {
           List<CompanySourceSubEntity> lstLocation = new List<CompanySourceSubEntity>();
           SqlCommand cmdGet = new SqlCommand();
           cmdGet.CommandType = CommandType.StoredProcedure;
           cmdGet.CommandText = "tblCompanySource_SelectForDropdown";          
           SqlDataReader dr = ExecuteDataReader(cmdGet);
           while (dr.Read())
           {
               CompanySourceSubEntity objEntity = new CompanySourceSubEntity();
               objEntity.CompanySourceID = GetInt32(dr, "CompanySourceID");
               objEntity.CompanySource = GetTextValue(dr, "CompanySource");
               lstLocation.Add(objEntity);
           }
           dr.Close();
           ForceCloseConnection();
           return lstLocation;
       }


        public virtual void tblCompanySourceSub_Insert(CompanySourceSubEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCompanySourceSub_Insert";
            cmdAdd.Parameters.AddWithValue("@CompanySourceID", ObjEntity.CompanySourceID);
            cmdAdd.Parameters.AddWithValue("@CompanySourceSub", ObjEntity.CompanySourceSub);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblCompanySourceSub_Exists(string CompanySourceSub)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanySourceSub_Exists";
            cmdGet.Parameters.AddWithValue("@CompanySourceSub", CompanySourceSub);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "CompanySourceSub");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<CompanySourceSubEntity> tblCompanySourceSub_Select(PagingEntity CommonEntity, out int Count)
        {
            List<CompanySourceSubEntity> lstLocation = new List<CompanySourceSubEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanySourceSub_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CompanySourceSubEntity objEntity = new CompanySourceSubEntity();
                objEntity.CompanySourceSubID = GetInt32(dr, "CompanySourceSubID");
                objEntity.CompanySourceID = GetInt32(dr, "CompanySourceID");
                objEntity.CompanySource = GetTextValue(dr, "CompanySource");
                objEntity.CompanySourceSub = GetTextValue(dr, "CompanySourceSub");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual CompanySourceSubEntity tblCompanySourceSub_ForEdit(int CompanySourceSubID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanySourceSub_ForEdit";
            cmdGet.Parameters.AddWithValue("@CompanySourceSubID", CompanySourceSubID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            CompanySourceSubEntity objEntity = new CompanySourceSubEntity();
            while (dr.Read())
            {
                objEntity.CompanySourceSubID = GetInt32(dr, "CompanySourceSubID");
                objEntity.CompanySourceID = GetInt32(dr, "CompanySourceID");
                objEntity.CompanySourceSub = GetTextValue(dr, "CompanySourceSub");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual CompanySourceSubEntity tblCompanySourceSub_SelectForUpdate(string CompanySourceSub, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanySourceSub_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@CompanySourceSub", CompanySourceSub);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            CompanySourceSubEntity objEntity = new CompanySourceSubEntity();
            while (dr.Read())
            {
                objEntity.CompanySourceSub = GetTextValue(dr, "CompanySourceSub");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblCompanySourceSub_Update(CompanySourceSubEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCompanySourceSub_Update";
            cmdAdd.Parameters.AddWithValue("@CompanySourceSubID", ObjEntity.CompanySourceSubID);
            cmdAdd.Parameters.AddWithValue("@CompanySourceID", ObjEntity.CompanySourceID);           
            cmdAdd.Parameters.AddWithValue("@CompanySourceSub", ObjEntity.CompanySourceSub);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblCompanySourceSub_Delete(int CompanySourceSubID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblCompanySourceSub_Delete";
            cmdDel.Parameters.AddWithValue("@CompanySourceSubID", CompanySourceSubID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }


        public virtual List<CompanySourceSubEntity> tblCustSourceSub_SelectByCSID(int CompanySourceID)
        {
            List<CompanySourceSubEntity> lstLocation = new List<CompanySourceSubEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustSourceSub_SelectByCSID";
            cmdGet.Parameters.AddWithValue("@CompanySourceID", CompanySourceID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CompanySourceSubEntity objEntity = new CompanySourceSubEntity();
                objEntity.CompanySourceSubID = GetInt32(dr, "CompanySourceSubID");
                objEntity.CompanySourceSub = GetTextValue(dr, "CompanySourceSub");
            
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }



    }
}

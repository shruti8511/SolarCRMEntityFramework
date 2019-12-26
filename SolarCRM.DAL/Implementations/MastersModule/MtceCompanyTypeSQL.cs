
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

    public class MtceCompanyTypeSQL : BaseSqlManager
    {
        public virtual void tblMtceCompanyType_Insert(MtceCompanyTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblMtceCompanyType_Insert";
            cmdAdd.Parameters.AddWithValue("@MtceCompanyType", ObjEntity.MtceCompanyType);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblMtceCompanyType_Exists(string MtceCompanyType)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblMtceCompanyType_Exists";
            cmdGet.Parameters.AddWithValue("@MtceCompanyType", MtceCompanyType);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "MtceCompanyType");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<MtceCompanyTypeEntity> tblMtceCompanyType_Select(PagingEntity CommonEntity, out int Count)
        {
            List<MtceCompanyTypeEntity> lstLocation = new List<MtceCompanyTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblMtceCompanyType_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                MtceCompanyTypeEntity objEntity = new MtceCompanyTypeEntity();
                objEntity.MtceCompanyTypeID = GetInt32(dr, "MtceCompanyTypeID");
                objEntity.MtceCompanyType = GetTextValue(dr, "MtceCompanyType");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<MtceCompanyTypeEntity> tblMtceCompanyType_SelectActive()
        {
            List<MtceCompanyTypeEntity> lstLocation = new List<MtceCompanyTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblMtceCompanyType_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                MtceCompanyTypeEntity objEntity = new MtceCompanyTypeEntity();
                objEntity.MtceCompanyTypeID = GetInt32(dr, "MtceCompanyTypeID");
                objEntity.MtceCompanyType = GetTextValue(dr, "MtceCompanyType");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual MtceCompanyTypeEntity tblMtceCompanyType_ForEdit(int MtceCompanyTypeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblMtceCompanyType_ForEdit";
            cmdGet.Parameters.AddWithValue("@MtceCompanyTypeID", MtceCompanyTypeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            MtceCompanyTypeEntity objEntity = new MtceCompanyTypeEntity();
            while (dr.Read())
            {
                objEntity.MtceCompanyTypeID = GetInt32(dr, "MtceCompanyTypeID");
                objEntity.MtceCompanyType = GetTextValue(dr, "MtceCompanyType");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual MtceCompanyTypeEntity tblMtceCompanyType_SelectForUpdate(string MtceCompanyType, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblMtceCompanyType_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@MtceCompanyType", MtceCompanyType);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            MtceCompanyTypeEntity objEntity = new MtceCompanyTypeEntity();
            while (dr.Read())
            {
                objEntity.MtceCompanyType = GetTextValue(dr, "MtceCompanyType");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblMtceCompanyType_Update(MtceCompanyTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblMtceCompanyType_Update";
            cmdAdd.Parameters.AddWithValue("@MtceCompanyTypeID", ObjEntity.MtceCompanyTypeID);
            cmdAdd.Parameters.AddWithValue("@MtceCompanyType", ObjEntity.MtceCompanyType);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblMtceCompanyType_Delete(int MtceCompanyTypeID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblMtceCompanyType_Delete";
            cmdDel.Parameters.AddWithValue("@MtceCompanyTypeID", MtceCompanyTypeID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }
    }
}

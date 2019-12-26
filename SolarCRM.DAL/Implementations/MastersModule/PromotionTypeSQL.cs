
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

    public class PromotionTypeSQL : BaseSqlManager
    {
        public virtual void tblPromotionType_Insert(PromotionTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblPromotionType_Insert";
            cmdAdd.Parameters.AddWithValue("@PromotionType", ObjEntity.PromotionType);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);

            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblPromotionType_Exists(string PromotionType)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPromotionType_Exists";
            cmdGet.Parameters.AddWithValue("@PromotionType", PromotionType);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "PromotionType");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<PromotionTypeEntity> tblPromotionType_Select(PagingEntity CommonEntity, out int Count)
        {
            List<PromotionTypeEntity> lstLocation = new List<PromotionTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPromotionType_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                PromotionTypeEntity objEntity = new PromotionTypeEntity();
                objEntity.PromotionTypeID = GetInt32(dr, "PromotionTypeID");
                objEntity.PromotionType = GetTextValue(dr, "PromotionType");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<PromotionTypeEntity> tblPromotionType_SelectActive()
        {
            List<PromotionTypeEntity> lstLocation = new List<PromotionTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPromotionType_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                PromotionTypeEntity objEntity = new PromotionTypeEntity();
                objEntity.PromotionTypeID = GetInt32(dr, "PromotionTypeID");
                objEntity.PromotionType = GetTextValue(dr, "PromotionType");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual PromotionTypeEntity tblPromotionType_ForEdit(int PromotionTypeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPromotionType_ForEdit";
            cmdGet.Parameters.AddWithValue("@PromotionTypeID", PromotionTypeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            PromotionTypeEntity objEntity = new PromotionTypeEntity();
            while (dr.Read())
            {
                objEntity.PromotionTypeID = GetInt32(dr, "PromotionTypeID");
                objEntity.PromotionType = GetTextValue(dr, "PromotionType");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual PromotionTypeEntity tblPromotionType_SelectForUpdate(string PromotionType, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPromotionType_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@PromotionType", PromotionType);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            PromotionTypeEntity objEntity = new PromotionTypeEntity();
            while (dr.Read())
            {
                objEntity.PromotionType = GetTextValue(dr, "PromotionType");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblPromotionType_Update(PromotionTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblPromotionType_Update";
            cmdAdd.Parameters.AddWithValue("@PromotionTypeID", ObjEntity.PromotionTypeID);
            cmdAdd.Parameters.AddWithValue("@PromotionType", ObjEntity.PromotionType);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblPromotionType_Delete(int PromotionTypeID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblPromotionType_Delete";
            cmdDel.Parameters.AddWithValue("@PromotionTypeID", PromotionTypeID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

    }
}

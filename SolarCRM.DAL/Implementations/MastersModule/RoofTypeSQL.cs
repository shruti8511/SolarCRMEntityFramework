
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

    public class RoofTypeSQL : BaseSqlManager
    {
        public virtual void tblRoofType_Insert(RoofTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblRoofType_Insert";
            cmdAdd.Parameters.AddWithValue("@RoofType", ObjEntity.RoofType);
            cmdAdd.Parameters.AddWithValue("@Variation", ObjEntity.Variation);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblRoofType_Exists(string RoofType)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblRoofType_Exists";
            cmdGet.Parameters.AddWithValue("@RoofType", RoofType);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "RoofType");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<RoofTypeEntity> tblRoofType_Select(PagingEntity CommonEntity, out int Count)
        {
            List<RoofTypeEntity> lstLocation = new List<RoofTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblRoofType_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                RoofTypeEntity objEntity = new RoofTypeEntity();
                objEntity.RoofTypeID = GetInt32(dr, "RoofTypeID");
                objEntity.RoofType = GetTextValue(dr, "RoofType");
                objEntity.Variation = GetDecimal(dr, "Variation");
                objEntity.Active = GetBoolean(dr, "Active");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<RoofTypeEntity> tblRoofType_SelectActive()
        {
            List<RoofTypeEntity> lstLocation = new List<RoofTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblRoofType_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                RoofTypeEntity objEntity = new RoofTypeEntity();
                objEntity.RoofTypeID = GetInt32(dr, "RoofTypeID");
                objEntity.RoofType = GetTextValue(dr, "RoofType");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual RoofTypeEntity tblRoofType_ForEdit(int RoofTypeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblRoofType_ForEdit";
            cmdGet.Parameters.AddWithValue("@RoofTypeID", RoofTypeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            RoofTypeEntity objEntity = new RoofTypeEntity();
            while (dr.Read())
            {
                objEntity.RoofTypeID = GetInt32(dr, "RoofTypeID");
                objEntity.RoofType = GetTextValue(dr, "RoofType");
                objEntity.Variation = GetDecimal(dr, "Variation");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual RoofTypeEntity tblRoofType_SelectForUpdate(string RoofType, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblRoofType_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@RoofType", RoofType);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            RoofTypeEntity objEntity = new RoofTypeEntity();
            while (dr.Read())
            {
                objEntity.RoofType = GetTextValue(dr, "RoofType");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblRoofType_Update(RoofTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblRoofType_Update";
            cmdAdd.Parameters.AddWithValue("@RoofTypeID", ObjEntity.RoofTypeID);
            cmdAdd.Parameters.AddWithValue("@RoofType", ObjEntity.RoofType);
            cmdAdd.Parameters.AddWithValue("@Variation", ObjEntity.Variation);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblRoofType_Delete(int RoofTypeID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblRoofType_Delete";
            cmdDel.Parameters.AddWithValue("@RoofTypeID", RoofTypeID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }


        public virtual List<RoofTypeEntity> tblRoofType_SelectASC()
        {
            List<RoofTypeEntity> lstLocation = new List<RoofTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblRoofType_SelectASC";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                RoofTypeEntity objEntity = new RoofTypeEntity();
                objEntity.RoofTypeID = GetInt32(dr, "RoofTypeID");
                objEntity.RoofType = GetTextValue(dr, "RoofType");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

    }
}

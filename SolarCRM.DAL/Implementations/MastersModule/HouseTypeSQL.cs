
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

    public class HouseTypeSQL : BaseSqlManager
    {
        public virtual void tblHouseType_Insert(HouseTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblHouseType_Insert";
            cmdAdd.Parameters.AddWithValue("@HouseType", ObjEntity.HouseType);
            cmdAdd.Parameters.AddWithValue("@Variation", ObjEntity.Variation);
            cmdAdd.Parameters.AddWithValue("@HouseTypeABB", ObjEntity.HouseTypeABB);           
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblHouseType_Exists(string HouseType)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblHouseType_Exists";
            cmdGet.Parameters.AddWithValue("@HouseType", HouseType);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "HouseType");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<HouseTypeEntity> tblHouseType_Select(PagingEntity CommonEntity, out int Count)
        {
            List<HouseTypeEntity> lstLocation = new List<HouseTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblHouseType_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                HouseTypeEntity objEntity = new HouseTypeEntity();
                objEntity.HouseTypeID = GetInt32(dr, "HouseTypeID");
                objEntity.HouseType = GetTextValue(dr, "HouseType");
                objEntity.Variation = GetDecimal(dr, "Variation");
                objEntity.HouseTypeABB = GetTextValue(dr, "HouseTypeABB");             
                objEntity.Active = GetBoolean(dr, "Active");                            
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<HouseTypeEntity> tblHouseType_SelectActive()
        {
            List<HouseTypeEntity> lstLocation = new List<HouseTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblHouseType_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                HouseTypeEntity objEntity = new HouseTypeEntity();
                objEntity.HouseTypeID = GetInt32(dr, "HouseTypeID");
                objEntity.HouseType = GetTextValue(dr, "HouseType");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual HouseTypeEntity tblHouseType_ForEdit(int HouseTypeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblHouseType_ForEdit";
            cmdGet.Parameters.AddWithValue("@HouseTypeID", HouseTypeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            HouseTypeEntity objEntity = new HouseTypeEntity();
            while (dr.Read())
            {
                objEntity.HouseTypeID = GetInt32(dr, "HouseTypeID");
                objEntity.HouseType = GetTextValue(dr, "HouseType");
                objEntity.Variation = GetDecimal(dr, "Variation");
                objEntity.HouseTypeABB = GetTextValue(dr, "HouseTypeABB");              
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual HouseTypeEntity tblHouseType_SelectForUpdate(string HouseType, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblHouseType_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@HouseType", HouseType);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            HouseTypeEntity objEntity = new HouseTypeEntity();
            while (dr.Read())
            {
                objEntity.HouseType = GetTextValue(dr, "HouseType");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblHouseType_Update(HouseTypeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblHouseType_Update";
            cmdAdd.Parameters.AddWithValue("@HouseTypeID", ObjEntity.HouseTypeID);
            cmdAdd.Parameters.AddWithValue("@HouseType", ObjEntity.HouseType);
            cmdAdd.Parameters.AddWithValue("@Variation", ObjEntity.Variation);
            cmdAdd.Parameters.AddWithValue("@HouseTypeABB", ObjEntity.HouseTypeABB);            
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);          
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblHouseType_Delete(int HouseTypeID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblHouseType_Delete";
            cmdDel.Parameters.AddWithValue("@HouseTypeID", HouseTypeID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }


        public virtual List<HouseTypeEntity> tblHouseType_SelectASC()
        {
            List<HouseTypeEntity> lstLocation = new List<HouseTypeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblHouseType_SelectASC";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                HouseTypeEntity objEntity = new HouseTypeEntity();
                objEntity.HouseTypeID = GetInt32(dr, "HouseTypeID");
                objEntity.HouseType = GetTextValue(dr, "HouseType");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }


    }
}

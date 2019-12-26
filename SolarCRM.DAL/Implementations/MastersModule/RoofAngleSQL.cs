
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

    public class RoofAngleSQL : BaseSqlManager
    {
        public virtual void tblRoofAngle_Insert(RoofAngleEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblRoofAngle_Insert";
            cmdAdd.Parameters.AddWithValue("@RoofAngle", ObjEntity.RoofAngle);
            cmdAdd.Parameters.AddWithValue("@Variation", ObjEntity.Variation);           
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblRoofAngle_Exists(string RoofAngle)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblRoofAngle_Exists";
            cmdGet.Parameters.AddWithValue("@RoofAngle", RoofAngle);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "RoofAngle");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<RoofAngleEntity> tblRoofAngle_Select(PagingEntity CommonEntity, out int Count)
        {
            List<RoofAngleEntity> lstLocation = new List<RoofAngleEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblRoofAngle_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                RoofAngleEntity objEntity = new RoofAngleEntity();
                objEntity.RoofAngleID = GetInt32(dr, "RoofAngleID");
                objEntity.RoofAngle = GetTextValue(dr, "RoofAngle");
                objEntity.Variation = GetDecimal(dr, "Variation");              
                objEntity.Active = GetBoolean(dr, "Active");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<RoofAngleEntity> tblRoofAngle_SelectActive()
        {
            List<RoofAngleEntity> lstLocation = new List<RoofAngleEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblRoofAngle_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                RoofAngleEntity objEntity = new RoofAngleEntity();
                objEntity.RoofAngleID = GetInt32(dr, "RoofAngleID");
                objEntity.RoofAngle = GetTextValue(dr, "RoofAngle");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual RoofAngleEntity tblRoofAngle_ForEdit(int RoofAngleID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblRoofAngle_ForEdit";
            cmdGet.Parameters.AddWithValue("@RoofAngleID", RoofAngleID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            RoofAngleEntity objEntity = new RoofAngleEntity();
            while (dr.Read())
            {
                objEntity.RoofAngleID = GetInt32(dr, "RoofAngleID");
                objEntity.RoofAngle = GetTextValue(dr, "RoofAngle");
                objEntity.Variation = GetDecimal(dr, "Variation");               
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual RoofAngleEntity tblRoofAngle_SelectForUpdate(string RoofAngle, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblRoofAngle_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@RoofAngle", RoofAngle);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            RoofAngleEntity objEntity = new RoofAngleEntity();
            while (dr.Read())
            {
                objEntity.RoofAngle = GetTextValue(dr, "RoofAngle");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblRoofAngle_Update(RoofAngleEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblRoofAngle_Update";
            cmdAdd.Parameters.AddWithValue("@RoofAngleID", ObjEntity.RoofAngleID);
            cmdAdd.Parameters.AddWithValue("@RoofAngle", ObjEntity.RoofAngle);
            cmdAdd.Parameters.AddWithValue("@Variation", ObjEntity.Variation);           
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblRoofAngle_Delete(int RoofAngleID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblRoofAngle_Delete";
            cmdDel.Parameters.AddWithValue("@RoofAngleID", RoofAngleID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

        public virtual List<RoofAngleEntity> tblRoofAngle_SelectASC()
        {
            List<RoofAngleEntity> lstLocation = new List<RoofAngleEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblRoofAngle_SelectASC";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                RoofAngleEntity objEntity = new RoofAngleEntity();
                objEntity.RoofAngleID = GetInt32(dr, "RoofAngleID");
                objEntity.RoofAngle = GetTextValue(dr, "RoofAngle");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

    }
}

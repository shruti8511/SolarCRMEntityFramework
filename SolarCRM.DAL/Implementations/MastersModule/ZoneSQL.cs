

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

    public class ZoneSQL : BaseSqlManager
    {

        public virtual void tblZone_Insert(ZoneEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblZone_Insert";
            cmdAdd.Parameters.AddWithValue("@Zone", ObjEntity.Zone);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblZone_Exists(string Zone)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblZone_Exists";
            cmdGet.Parameters.AddWithValue("@Zone", Zone);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "Zone");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<ZoneEntity> tblZone_Select(PagingEntity CommonEntity, out int Count)
        {
            List<ZoneEntity> lstLocation = new List<ZoneEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblZone_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);           
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ZoneEntity objEntity = new ZoneEntity();
                objEntity.ZoneID = GetInt32(dr, "ZoneID");
                objEntity.Zone = GetTextValue(dr, "Zone");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<ZoneEntity> tblZone_SelectActive()
        {
            List<ZoneEntity> lstLocation = new List<ZoneEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblZone_SelectActive";
           
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ZoneEntity objEntity = new ZoneEntity();
                objEntity.ZoneID = GetInt32(dr, "ZoneID");
                objEntity.Zone = GetTextValue(dr, "Zone");             
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual ZoneEntity tblZone_ForEdit(int ZoneID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblZone_ForEdit";
            cmdGet.Parameters.AddWithValue("@ZoneID", ZoneID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ZoneEntity objEntity = new ZoneEntity();
            while (dr.Read())
            {
                objEntity.ZoneID = GetInt32(dr, "ZoneID");
                objEntity.Zone = GetTextValue(dr, "Zone");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual ZoneEntity tblZone_SelectForUpdate(string Zone, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblZone_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@Zone", Zone);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ZoneEntity objEntity = new ZoneEntity();
            while (dr.Read())
            {
                objEntity.Zone = GetTextValue(dr, "Zone");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblZone_Update(ZoneEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblZone_Update";
            cmdAdd.Parameters.AddWithValue("@ZoneID", ObjEntity.ZoneID);
            cmdAdd.Parameters.AddWithValue("@Zone", ObjEntity.Zone);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblZone_Delete(int ZoneID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblZone_Delete";
            cmdDel.Parameters.AddWithValue("@ZoneID", ZoneID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

    }
}

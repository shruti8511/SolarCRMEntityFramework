
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

    public class SpecialPurposeSQL : BaseSqlManager
    {
        public virtual void tblSpecialPurpose_Insert(SpecialPurposeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblSpecialPurpose_Insert";
            cmdAdd.Parameters.AddWithValue("@SpecialPurpose", ObjEntity.SpecialPurpose);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblSpecialPurpose_Exists(string SpecialPurpose)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblSpecialPurpose_Exists";
            cmdGet.Parameters.AddWithValue("@SpecialPurpose", SpecialPurpose);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "SpecialPurpose");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<SpecialPurposeEntity> tblSpecialPurpose_Select(PagingEntity CommonEntity, out int Count)
        {
            List<SpecialPurposeEntity> lstLocation = new List<SpecialPurposeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblSpecialPurpose_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                SpecialPurposeEntity objEntity = new SpecialPurposeEntity();
                objEntity.SpecialPurposeID = GetInt32(dr, "SpecialPurposeID");
                objEntity.SpecialPurpose = GetTextValue(dr, "SpecialPurpose");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<SpecialPurposeEntity> tblSpecialPurpose_SelectActive(int isactive, string SpecialPurposeID)
        {
            List<SpecialPurposeEntity> lstLocation = new List<SpecialPurposeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.Parameters.AddWithValue("@isactive", isactive);
            cmdGet.Parameters.AddWithValue("@SpecialPurposeID", SpecialPurposeID);

            cmdGet.CommandText = "tblSpecialPurpose_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                SpecialPurposeEntity objEntity = new SpecialPurposeEntity();
                objEntity.SpecialPurposeID = GetInt32(dr, "SpecialPurposeID");
                objEntity.SpecialPurpose = GetTextValue(dr, "SpecialPurpose");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual SpecialPurposeEntity tblSpecialPurpose_ForEdit(int SpecialPurposeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblSpecialPurpose_ForEdit";
            cmdGet.Parameters.AddWithValue("@SpecialPurposeID", SpecialPurposeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            SpecialPurposeEntity objEntity = new SpecialPurposeEntity();
            while (dr.Read())
            {
                objEntity.SpecialPurposeID = GetInt32(dr, "SpecialPurposeID");
                objEntity.SpecialPurpose = GetTextValue(dr, "SpecialPurpose");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual SpecialPurposeEntity tblSpecialPurpose_SelectForUpdate(string SpecialPurpose, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblSpecialPurpose_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@SpecialPurpose", SpecialPurpose);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            SpecialPurposeEntity objEntity = new SpecialPurposeEntity();
            while (dr.Read())
            {
                objEntity.SpecialPurpose = GetTextValue(dr, "SpecialPurpose");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblSpecialPurpose_Update(SpecialPurposeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblSpecialPurpose_Update";
            cmdAdd.Parameters.AddWithValue("@SpecialPurposeID", ObjEntity.SpecialPurposeID);
            cmdAdd.Parameters.AddWithValue("@SpecialPurpose", ObjEntity.SpecialPurpose);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblSpecialPurpose_Delete(int SpecialPurposeID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblSpecialPurpose_Delete";
            cmdDel.Parameters.AddWithValue("@SpecialPurposeID", SpecialPurposeID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }
        public virtual SpecialPurposeEntity tblSpecialPurpose_SelectBySpecialPurposeID(long SpecialPurposeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblSpecialPurpose_SelectBySpecialPurposeID";
            cmdGet.Parameters.AddWithValue("@SpecialPurposeID", SpecialPurposeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            SpecialPurposeEntity details = new SpecialPurposeEntity();
            while (dr.Read())
            {
                details.SpecialPurposeID = GetInt32(dr, "SpecialPurposeID");
                details.SpecialPurpose = GetTextValue(dr, "SpecialPurpose");

            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }
    }
}

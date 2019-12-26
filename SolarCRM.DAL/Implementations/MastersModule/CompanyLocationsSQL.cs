

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
    public class CompanyLocationsSQL : BaseSqlManager
    {
        public virtual int tblCompanyLocations_Insert(CompanyLocationsEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCompanyLocations_Insert";
            cmdAdd.Parameters.AddWithValue("@CompanyLocation", ObjEntity.CompanyLocation);
            cmdAdd.Parameters.AddWithValue("@State", ObjEntity.State);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            int i = ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
            return i;

        }

        public virtual int tblCompanyLocations_Exists(string CompanyLocation)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanyLocations_Exists";
            cmdGet.Parameters.AddWithValue("@CompanyLocation", CompanyLocation);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "CompanyLocation");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<CompanyLocationsEntity> tblCompanyLocations_Select(PagingEntity CommonEntity, out int Count)
        {
            List<CompanyLocationsEntity> lstCompanyLocation = new List<CompanyLocationsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanyLocations_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CompanyLocationsEntity objEntity = new CompanyLocationsEntity();
                objEntity.CompanyLocationID = GetInt32(dr, "CompanyLocationID");
                objEntity.CompanyLocation = GetTextValue(dr, "CompanyLocation");
                objEntity.State = GetTextValue(dr, "State");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstCompanyLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstCompanyLocation;
        }

        public virtual List<CompanyLocationsEntity> tblCompanyLocations_SelectActive()
        {
            List<CompanyLocationsEntity> lstLocation = new List<CompanyLocationsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanyLocations_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CompanyLocationsEntity objEntity = new CompanyLocationsEntity();
                objEntity.CompanyLocationID = GetInt32(dr, "CompanyLocationID");
                objEntity.CompanyLocation = GetTextValue(dr, "CompanyLocation");
                objEntity.State = GetTextValue(dr, "State");
                objEntity.CompanyLocation = objEntity.CompanyLocation + ":" + objEntity.State;
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual CompanyLocationsEntity tblCompanyLocations_ForEdit(int CompanyLocationID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanyLocations_ForEdit";
            cmdGet.Parameters.AddWithValue("@CompanyLocationID", CompanyLocationID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            CompanyLocationsEntity objEntity = new CompanyLocationsEntity();
            while (dr.Read())
            {
                objEntity.CompanyLocationID = GetInt32(dr, "CompanyLocationID");
                objEntity.CompanyLocation = GetTextValue(dr, "CompanyLocation");
                objEntity.Active = GetBoolean(dr, "Active");
                objEntity.State = GetTextValue(dr, "State");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual CompanyLocationsEntity tblCompanyLocations_SelectForUpdate(string CompanyLocation, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanyLocations_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@CompanyLocation", CompanyLocation);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            CompanyLocationsEntity objEntity = new CompanyLocationsEntity();
            while (dr.Read())
            {
                objEntity.CompanyLocation = GetTextValue(dr, "CompanyLocation");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblCompanyLocations_Update(CompanyLocationsEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCompanyLocations_Update";
            cmdAdd.Parameters.AddWithValue("@CompanyLocationID", ObjEntity.CompanyLocationID);
            cmdAdd.Parameters.AddWithValue("@CompanyLocation", ObjEntity.CompanyLocation);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblCompanyLocations_Delete(int CompanyLocationID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblCompanyLocations_Delete";
            cmdDel.Parameters.AddWithValue("@CompanyLocationID", CompanyLocationID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

        public virtual List<StateEntity> tblState_SelectActive()
        {
            List<StateEntity> lstState = new List<StateEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblState_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                StateEntity objEntity = new StateEntity();
                objEntity.StateId = GetInt32(dr, "StateId");
                objEntity.StateName = GetTextValue(dr, "StateName");
                lstState.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstState;
        }
    }
}

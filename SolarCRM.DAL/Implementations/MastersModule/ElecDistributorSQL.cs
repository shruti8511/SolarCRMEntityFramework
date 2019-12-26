

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


    public class ElecDistributorSQL : BaseSqlManager
    {
        public virtual void tblElecDistributor_Insert(ElecDistributorEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblElecDistributor_Insert";
            cmdAdd.Parameters.AddWithValue("@ElecDistributor", ObjEntity.ElecDistributor);
            cmdAdd.Parameters.AddWithValue("@ElecDistABB", ObjEntity.ElecDistABB);
            cmdAdd.Parameters.AddWithValue("@Address", ObjEntity.Address);
            cmdAdd.Parameters.AddWithValue("@Mobile", ObjEntity.Mobile);
            cmdAdd.Parameters.AddWithValue("@Email", ObjEntity.Email);           
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@State", ObjEntity.State);
            cmdAdd.Parameters.AddWithValue("@ElecDistAppReq", ObjEntity.ElecDistAppReq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblElecDistributor_Exists(string ElecDistributor)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblElecDistributor_Exists";
            cmdGet.Parameters.AddWithValue("@ElecDistributor", ElecDistributor);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "ElecDistributor");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<ElecDistributorEntity> tblElecDistributor_Select(PagingEntity CommonEntity, out int Count)
        {
            List<ElecDistributorEntity> lstLocation = new List<ElecDistributorEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblElecDistributor_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ElecDistributorEntity objEntity = new ElecDistributorEntity();
                objEntity.ElecDistributorID = GetInt32(dr, "ElecDistributorID");
                objEntity.ElecDistributor = GetTextValue(dr, "ElecDistributor");
                objEntity.ElecDistABB = GetTextValue(dr, "ElecDistABB");
                objEntity.Address = GetTextValue(dr, "Address");
                objEntity.Mobile = GetTextValue(dr, "Mobile");
                objEntity.Email = GetTextValue(dr, "Email");
                objEntity.Active = GetBoolean(dr, "Active");
                objEntity.State = GetTextValue(dr, "State");
                objEntity.ElecDistAppReq = GetBoolean(dr, "ElecDistAppReq");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<ElecDistributorEntity> tblElecDistributor_SelectActiveByState(string State)
        {
            List<ElecDistributorEntity> lstLocation = new List<ElecDistributorEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblElecDistributor_SelectActiveByState";
            cmdGet.Parameters.AddWithValue("@State", State);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ElecDistributorEntity objEntity = new ElecDistributorEntity();
                objEntity.ElecDistributorID = GetInt32(dr, "ElecDistributorID");
                objEntity.ElecDistributor = GetTextValue(dr, "ElecDistributor");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual ElecDistributorEntity tblElecDistributor_ForEdit(int ElecDistributorID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblElecDistributor_ForEdit";
            cmdGet.Parameters.AddWithValue("@ElecDistributorID", ElecDistributorID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ElecDistributorEntity objEntity = new ElecDistributorEntity();
            while (dr.Read())
            {
                objEntity.ElecDistributorID = GetInt32(dr, "ElecDistributorID");
                objEntity.ElecDistributor = GetTextValue(dr, "ElecDistributor");
                objEntity.ElecDistABB = GetTextValue(dr, "ElecDistABB");
                objEntity.Address = GetTextValue(dr, "Address");
                objEntity.Mobile = GetTextValue(dr, "Mobile");
                objEntity.Email = GetTextValue(dr, "Email");
                objEntity.State = GetTextValue(dr, "State");
                objEntity.ElecDistAppReq = GetBoolean(dr, "ElecDistAppReq");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual ElecDistributorEntity tblElecDistributor_SelectForUpdate(string ElecDistributor, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblElecDistributor_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@ElecDistributor", ElecDistributor);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ElecDistributorEntity objEntity = new ElecDistributorEntity();
            while (dr.Read())
            {
                objEntity.ElecDistributor = GetTextValue(dr, "ElecDistributor");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblElecDistributor_Update(ElecDistributorEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblElecDistributor_Update";
            cmdAdd.Parameters.AddWithValue("@ElecDistributorID", ObjEntity.ElecDistributorID);
            cmdAdd.Parameters.AddWithValue("@ElecDistributor", ObjEntity.ElecDistributor);
            cmdAdd.Parameters.AddWithValue("@ElecDistABB", ObjEntity.ElecDistABB);
            cmdAdd.Parameters.AddWithValue("@Address", ObjEntity.Address);
            cmdAdd.Parameters.AddWithValue("@Mobile", ObjEntity.Mobile);
            cmdAdd.Parameters.AddWithValue("@Email", ObjEntity.Email);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@State", ObjEntity.State);
            cmdAdd.Parameters.AddWithValue("@ElecDistAppReq", ObjEntity.ElecDistAppReq);           
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblElecDistributor_Delete(int ElecDistributorID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblElecDistributor_Delete";
            cmdDel.Parameters.AddWithValue("@ElecDistributorID", ElecDistributorID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

    }
}

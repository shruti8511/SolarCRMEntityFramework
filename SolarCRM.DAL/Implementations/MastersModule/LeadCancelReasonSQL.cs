

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

    public class LeadCancelReasonSQL : BaseSqlManager
    {
        public virtual void tblContLeadCancelReason_Insert(LeadCancelReasonEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblContLeadCancelReason_Insert";
            cmdAdd.Parameters.AddWithValue("@ContLeadCancelReason", ObjEntity.ContLeadCancelReason);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);           
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblContLeadCancelReason_Exists(string ContLeadCancelReason)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContLeadCancelReason_Exists";
            cmdGet.Parameters.AddWithValue("@ContLeadCancelReason", ContLeadCancelReason);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "ContLeadCancelReason");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<LeadCancelReasonEntity> tblContLeadCancelReason_Select(PagingEntity CommonEntity, out int Count)
        {
            List<LeadCancelReasonEntity> lstLocation = new List<LeadCancelReasonEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContLeadCancelReason_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                LeadCancelReasonEntity objEntity = new LeadCancelReasonEntity();
                objEntity.ContLeadCancelReasonID = GetInt32(dr, "ContLeadCancelReasonID");
                objEntity.ContLeadCancelReason = GetTextValue(dr, "ContLeadCancelReason");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        //public virtual List<LeadCancelReasonEntity> tblContLeadCancelReason_SelectActive()
        //{
        //    List<LeadCancelReasonEntity> lstLocation = new List<LeadCancelReasonEntity>();
        //    SqlCommand cmdGet = new SqlCommand();
        //    cmdGet.CommandType = CommandType.StoredProcedure;
        //    cmdGet.CommandText = "tblContLeadCancelReason_SelectActive";

        //    SqlDataReader dr = ExecuteDataReader(cmdGet);
        //    while (dr.Read())
        //    {
        //        LeadCancelReasonEntity objEntity = new LeadCancelReasonEntity();
        //        objEntity.ContLeadCancelReasonID = GetInt32(dr, "ContLeadCancelReasonID");
        //        objEntity.ContLeadCancelReason = GetTextValue(dr, "ContLeadCancelReason");
        //        lstLocation.Add(objEntity);
        //    }
        //    dr.Close();
        //    ForceCloseConnection();
        //    return lstLocation;
        //}

        public virtual LeadCancelReasonEntity tblContLeadCancelReason_ForEdit(int ContLeadCancelReasonID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContLeadCancelReason_ForEdit";
            cmdGet.Parameters.AddWithValue("@ContLeadCancelReasonID", ContLeadCancelReasonID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            LeadCancelReasonEntity objEntity = new LeadCancelReasonEntity();
            while (dr.Read())
            {
                objEntity.ContLeadCancelReasonID = GetInt32(dr, "ContLeadCancelReasonID");
                objEntity.ContLeadCancelReason = GetTextValue(dr, "ContLeadCancelReason");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual LeadCancelReasonEntity tblContLeadCancelReason_SelectForUpdate(string ContLeadCancelReason, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContLeadCancelReason_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@ContLeadCancelReason", ContLeadCancelReason);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            LeadCancelReasonEntity objEntity = new LeadCancelReasonEntity();
            while (dr.Read())
            {
                objEntity.ContLeadCancelReason = GetTextValue(dr, "ContLeadCancelReason");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblContLeadCancelReason_Update(LeadCancelReasonEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblContLeadCancelReason_Update";
            cmdAdd.Parameters.AddWithValue("@ContLeadCancelReasonID", ObjEntity.ContLeadCancelReasonID);
            cmdAdd.Parameters.AddWithValue("@ContLeadCancelReason", ObjEntity.ContLeadCancelReason);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblContLeadCancelReason_Delete(int ContLeadCancelReasonID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblContLeadCancelReason_Delete";
            cmdDel.Parameters.AddWithValue("@ContLeadCancelReasonID", ContLeadCancelReasonID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }
    }
}

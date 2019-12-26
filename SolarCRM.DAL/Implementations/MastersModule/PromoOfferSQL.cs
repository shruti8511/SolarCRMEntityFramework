
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

   public class PromoOfferSQL : BaseSqlManager
    {
        public virtual void tblPromoOffer_Insert(PromoOfferEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblPromoOffer_Insert";
            cmdAdd.Parameters.AddWithValue("@PromoOffer", ObjEntity.PromoOffer);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblPromoOffer_Exists(string PromoOffer)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPromoOffer_Exists";
            cmdGet.Parameters.AddWithValue("@PromoOffer", PromoOffer);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "PromoOffer");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<PromoOfferEntity> tblPromoOffer_Select(PagingEntity CommonEntity, out int Count)
        {
            List<PromoOfferEntity> lstLocation = new List<PromoOfferEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPromoOffer_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                PromoOfferEntity objEntity = new PromoOfferEntity();
                objEntity.PromoOfferID = GetInt32(dr, "PromoOfferID");
                objEntity.PromoOffer = GetTextValue(dr, "PromoOffer");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<PromoOfferEntity> tblPromoOffer_SelectActive()
        {
            List<PromoOfferEntity> lstLocation = new List<PromoOfferEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPromoOffer_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                PromoOfferEntity objEntity = new PromoOfferEntity();
                objEntity.PromoOfferID = GetInt32(dr, "PromoOfferID");
                objEntity.PromoOffer = GetTextValue(dr, "PromoOffer");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual PromoOfferEntity tblPromoOffer_ForEdit(int PromoOfferID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPromoOffer_ForEdit";
            cmdGet.Parameters.AddWithValue("@PromoOfferID", PromoOfferID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            PromoOfferEntity objEntity = new PromoOfferEntity();
            while (dr.Read())
            {
                objEntity.PromoOfferID = GetInt32(dr, "PromoOfferID");
                objEntity.PromoOffer = GetTextValue(dr, "PromoOffer");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual PromoOfferEntity tblPromoOffer_SelectForUpdate(string PromoOffer, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPromoOffer_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@PromoOffer", PromoOffer);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            PromoOfferEntity objEntity = new PromoOfferEntity();
            while (dr.Read())
            {
                objEntity.PromoOffer = GetTextValue(dr, "PromoOffer");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblPromoOffer_Update(PromoOfferEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblPromoOffer_Update";
            cmdAdd.Parameters.AddWithValue("@PromoOfferID", ObjEntity.PromoOfferID);
            cmdAdd.Parameters.AddWithValue("@PromoOffer", ObjEntity.PromoOffer);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblPromoOffer_Delete(int PromoOfferID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblPromoOffer_Delete";
            cmdDel.Parameters.AddWithValue("@PromoOfferID", PromoOfferID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }
    }
}

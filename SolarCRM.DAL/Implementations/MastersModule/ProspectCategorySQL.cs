
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

    public class ProspectCategorySQL : BaseSqlManager
    {
        public virtual void tblProspectCats_Insert(ProspectCategoryEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProspectCats_Insert";
            cmdAdd.Parameters.AddWithValue("@ProspectCat", ObjEntity.ProspectCat);
            cmdAdd.Parameters.AddWithValue("@ProspectCatABB", ObjEntity.ProspectCatABB);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            cmdAdd.Parameters.AddWithValue("@Seq", ObjEntity.Seq);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblProspectCats_Exists(string ProspectCat)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProspectCats_Exists";
            cmdGet.Parameters.AddWithValue("@ProspectCat", ProspectCat);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "ProspectCat");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<ProspectCategoryEntity> tblProspectCategory_Select(PagingEntity CommonEntity, out int Count)
        {
            List<ProspectCategoryEntity> lstLocation = new List<ProspectCategoryEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProspectCats_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProspectCategoryEntity objEntity = new ProspectCategoryEntity();
                objEntity.ProspectCatID = GetInt32(dr, "ProspectCatID");
                objEntity.ProspectCat = GetTextValue(dr, "ProspectCat");
                objEntity.ProspectCatABB = GetTextValue(dr, "ProspectCatABB");
                objEntity.Active = GetBoolean(dr, "Active");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        //public virtual List<ProspectCategoryEntity> tblProspectCategory_SelectActive()
        //{
        //    List<ProspectCategoryEntity> lstLocation = new List<ProspectCategoryEntity>();
        //    SqlCommand cmdGet = new SqlCommand();
        //    cmdGet.CommandType = CommandType.StoredProcedure;
        //    cmdGet.CommandText = "tblProspectCategory_SelectActive";

        //    SqlDataReader dr = ExecuteDataReader(cmdGet);
        //    while (dr.Read())
        //    {
        //        ProspectCategoryEntity objEntity = new ProspectCategoryEntity();
        //        objEntity.ProspectCategoryID = GetInt32(dr, "ProspectCategoryID");
        //        objEntity.ProspectCategory = GetTextValue(dr, "ProspectCategory");
        //        lstLocation.Add(objEntity);
        //    }
        //    dr.Close();
        //    ForceCloseConnection();
        //    return lstLocation;
        //}

        public virtual ProspectCategoryEntity tblProspectCats_ForEdit(int ProspectCatID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProspectCats_ForEdit";
            cmdGet.Parameters.AddWithValue("@ProspectCatID", ProspectCatID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProspectCategoryEntity objEntity = new ProspectCategoryEntity();
            while (dr.Read())
            {
                objEntity.ProspectCatID = GetInt32(dr, "ProspectCatID");
                objEntity.ProspectCat = GetTextValue(dr, "ProspectCat");
                objEntity.ProspectCatABB = GetTextValue(dr, "ProspectCatABB");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual ProspectCategoryEntity tblProspectCats_SelectForUpdate(string ProspectCat, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProspectCats_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@ProspectCat", ProspectCat);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProspectCategoryEntity objEntity = new ProspectCategoryEntity();
            while (dr.Read())
            {
                objEntity.ProspectCat = GetTextValue(dr, "ProspectCat");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblProspectCats_Update(ProspectCategoryEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProspectCats_Update";
            cmdAdd.Parameters.AddWithValue("@ProspectCatID", ObjEntity.ProspectCatID);
            cmdAdd.Parameters.AddWithValue("@ProspectCat", ObjEntity.ProspectCat);
            cmdAdd.Parameters.AddWithValue("@ProspectCatABB", ObjEntity.ProspectCatABB);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblProspectCats_Delete(int ProspectCatID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblProspectCats_Delete";
            cmdDel.Parameters.AddWithValue("@ProspectCatID", ProspectCatID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

    }
}

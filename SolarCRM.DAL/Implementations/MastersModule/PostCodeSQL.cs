
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
    public class PostCodeSQL : BaseSqlManager
    {
        public virtual int tblPostCode_Insert(PostCodeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblPostCode_Insert";
            cmdAdd.Parameters.AddWithValue("@PostCode", ObjEntity.PostCode);
            cmdAdd.Parameters.AddWithValue("@Suburb", ObjEntity.Suburb);
            cmdAdd.Parameters.AddWithValue("@State", ObjEntity.State);
            cmdAdd.Parameters.AddWithValue("@POBoxes", ObjEntity.POBoxes);
            cmdAdd.Parameters.AddWithValue("@Area", ObjEntity.Area);
            cmdAdd.Parameters.AddWithValue("@AreaType", ObjEntity.AreaType);
            cmdAdd.Parameters.AddWithValue("@CompanyLocationID", ObjEntity.CompanyLocationID);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            int i = ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
            return i;

        }

        public virtual int tblPostCode_Exists(int PostCode)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPostCode_Exists";
            cmdGet.Parameters.AddWithValue("@PostCode", PostCode);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "PostCode");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<PostCodeEntity> tblPostCode_Select(PagingEntity CommonEntity, out int Count)
        {
            List<PostCodeEntity> lstPostCode = new List<PostCodeEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPostCode_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                PostCodeEntity objEntity = new PostCodeEntity();
                objEntity.PostCodeID = GetInt32(dr, "PostCodeID");
                objEntity.PostCode = GetInt32(dr, "PostCode");
                objEntity.POBoxes = GetTextValue(dr, "POBoxes");
                objEntity.Suburb = GetTextValue(dr, "Suburb");
                objEntity.Area = GetTextValue(dr, "Area");
                objEntity.AreaType = GetInt32(dr, "AreaType");
                if (objEntity.AreaType == 1)
                {
                    objEntity.AreaTypee = "Metro";
                }
                else
                {
                    objEntity.AreaTypee = "Regional";
                }
                objEntity.State = GetTextValue(dr, "State");
                objEntity.CompanyLocation = GetTextValue(dr, "CompanyLocation");
                objEntity.Active = GetBoolean(dr, "Active");            
                lstPostCode.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstPostCode;
        }

        //public virtual List<PostCodeEntity> tblPostCode_SelectActive()
        //{
        //    List<PostCodeEntity> lstLocation = new List<PostCodeEntity>();
        //    SqlCommand cmdGet = new SqlCommand();
        //    cmdGet.CommandType = CommandType.StoredProcedure;
        //    cmdGet.CommandText = "tblPostCode_SelectActive";

        //    SqlDataReader dr = ExecuteDataReader(cmdGet);
        //    while (dr.Read())
        //    {
        //        PostCodeEntity objEntity = new PostCodeEntity();
        //        objEntity.CompanyLocationID = GetInt32(dr, "CompanyLocationID");
        //        objEntity.CompanyLocation = GetTextValue(dr, "CompanyLocation");
        //        objEntity.State = GetTextValue(dr, "State");
        //        objEntity.CompanyLocation = objEntity.CompanyLocation + ":" + objEntity.State;
        //        lstLocation.Add(objEntity);
        //    }
        //    dr.Close();
        //    ForceCloseConnection();
        //    return lstLocation;
        //}

        public virtual PostCodeEntity tblPostCode_ForEdit(int PostCodeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPostCode_ForEdit";
            cmdGet.Parameters.AddWithValue("@PostCodeID", PostCodeID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            PostCodeEntity objEntity = new PostCodeEntity();
            while (dr.Read())
            {
                objEntity.PostCodeID = GetInt32(dr, "PostCodeID");
                objEntity.PostCode = GetInt32(dr, "PostCode");
                objEntity.POBoxes = GetTextValue(dr, "POBoxes");
                objEntity.Suburb = GetTextValue(dr, "Suburb");
                objEntity.Area = GetTextValue(dr, "Area");
                objEntity.AreaType = GetInt32(dr, "AreaType");
                objEntity.State = GetTextValue(dr, "State");
                objEntity.CompanyLocationID = GetInt32(dr, "CompanyLocationID");
                objEntity.Active = GetBoolean(dr, "Active");     
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual PostCodeEntity tblPostCode_SelectForUpdate(int PostCode, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPostCode_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@PostCode", PostCode);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            PostCodeEntity objEntity = new PostCodeEntity();
            while (dr.Read())
            {
                objEntity.PostCode = GetInt32(dr, "PostCode");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblPostCode_Update(PostCodeEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblPostCode_Update";
            cmdAdd.Parameters.AddWithValue("@PostCodeID", ObjEntity.PostCodeID);
            cmdAdd.Parameters.AddWithValue("@PostCode", ObjEntity.PostCode);
            cmdAdd.Parameters.AddWithValue("@Suburb", ObjEntity.Suburb);
            cmdAdd.Parameters.AddWithValue("@State", ObjEntity.State);
            cmdAdd.Parameters.AddWithValue("@POBoxes", ObjEntity.POBoxes);
            cmdAdd.Parameters.AddWithValue("@Area", ObjEntity.Area);
            cmdAdd.Parameters.AddWithValue("@AreaType", ObjEntity.AreaType);
            cmdAdd.Parameters.AddWithValue("@CompanyLocationID", ObjEntity.CompanyLocationID);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblPostCode_Delete(int PostCodeID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblPostCode_Delete";
            cmdDel.Parameters.AddWithValue("@PostCodeID", PostCodeID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }
    }
}

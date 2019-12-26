
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

    public class ElecRetailerSQL : BaseSqlManager
    {
        public virtual void tblElecRetailer_Insert(ElecRetailerEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblElecRetailer_Insert";
            cmdAdd.Parameters.AddWithValue("@ElecRetailer", ObjEntity.ElecRetailer);           
            cmdAdd.Parameters.AddWithValue("@Address", ObjEntity.Address);
            cmdAdd.Parameters.AddWithValue("@Mobile", ObjEntity.Mobile);
            cmdAdd.Parameters.AddWithValue("@Email", ObjEntity.Email);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);           
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblElecRetailer_Exists(string ElecRetailer)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblElecRetailer_Exists";
            cmdGet.Parameters.AddWithValue("@ElecRetailer", ElecRetailer);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "ElecRetailer");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<ElecRetailerEntity> tblElecRetailer_Select(PagingEntity CommonEntity, out int Count)
        {
            List<ElecRetailerEntity> lstLocation = new List<ElecRetailerEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblElecRetailer_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ElecRetailerEntity objEntity = new ElecRetailerEntity();
                objEntity.ElecRetailerID = GetInt32(dr, "ElecRetailerID");
                objEntity.ElecRetailer = GetTextValue(dr, "ElecRetailer");               
                objEntity.Address = GetTextValue(dr, "Address");
                objEntity.Mobile = GetTextValue(dr, "Mobile");
                objEntity.Email = GetTextValue(dr, "Email");
                objEntity.Active = GetBoolean(dr, "Active");                            
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        //public virtual List<ElecRetailerEntity> tblElecRetailer_SelectActive()
        //{
        //    List<ElecRetailerEntity> lstLocation = new List<ElecRetailerEntity>();
        //    SqlCommand cmdGet = new SqlCommand();
        //    cmdGet.CommandType = CommandType.StoredProcedure;
        //    cmdGet.CommandText = "tblElecRetailer_SelectActive";

        //    SqlDataReader dr = ExecuteDataReader(cmdGet);
        //    while (dr.Read())
        //    {
        //        ElecRetailerEntity objEntity = new ElecRetailerEntity();
        //        objEntity.ElecRetailerID = GetInt32(dr, "ElecRetailerID");
        //        objEntity.ElecRetailer = GetTextValue(dr, "ElecRetailer");
        //        lstLocation.Add(objEntity);
        //    }
        //    dr.Close();
        //    ForceCloseConnection();
        //    return lstLocation;
        //}

        public virtual ElecRetailerEntity tblElecRetailer_ForEdit(int ElecRetailerID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblElecRetailer_ForEdit";
            cmdGet.Parameters.AddWithValue("@ElecRetailerID", ElecRetailerID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ElecRetailerEntity objEntity = new ElecRetailerEntity();
            while (dr.Read())
            {
                objEntity.ElecRetailerID = GetInt32(dr, "ElecRetailerID");
                objEntity.ElecRetailer = GetTextValue(dr, "ElecRetailer");               
                objEntity.Address = GetTextValue(dr, "Address");
                objEntity.Mobile = GetTextValue(dr, "Mobile");
                objEntity.Email = GetTextValue(dr, "Email");                
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual ElecRetailerEntity tblElecRetailer_SelectForUpdate(string ElecRetailer, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblElecRetailer_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@ElecRetailer", ElecRetailer);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ElecRetailerEntity objEntity = new ElecRetailerEntity();
            while (dr.Read())
            {
                objEntity.ElecRetailer = GetTextValue(dr, "ElecRetailer");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblElecRetailer_Update(ElecRetailerEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblElecRetailer_Update";
            cmdAdd.Parameters.AddWithValue("@ElecRetailerID", ObjEntity.ElecRetailerID);
            cmdAdd.Parameters.AddWithValue("@ElecRetailer", ObjEntity.ElecRetailer);            
            cmdAdd.Parameters.AddWithValue("@Address", ObjEntity.Address);
            cmdAdd.Parameters.AddWithValue("@Mobile", ObjEntity.Mobile);
            cmdAdd.Parameters.AddWithValue("@Email", ObjEntity.Email);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);           
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblElecRetailer_Delete(int ElecRetailerID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblElecRetailer_Delete";
            cmdDel.Parameters.AddWithValue("@ElecRetailerID", ElecRetailerID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }

        public virtual List<ElecRetailerEntity> tblElecRetailer_SelectASC()
        {
            List<ElecRetailerEntity> lstLocation = new List<ElecRetailerEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblElecRetailer_SelectASC";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ElecRetailerEntity objEntity = new ElecRetailerEntity();
                objEntity.ElecRetailerID = GetInt32(dr, "ElecRetailerID");
                objEntity.ElecRetailer = GetTextValue(dr, "ElecRetailer");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

    }
}

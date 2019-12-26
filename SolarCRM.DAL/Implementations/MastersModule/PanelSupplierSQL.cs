
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

    public class PanelSupplierSQL : BaseSqlManager
    {
        public virtual void tblPanelSupplier_Insert(PanelSupplierEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblPanelSupplier_Insert";
            cmdAdd.Parameters.AddWithValue("@PanelSupplier", ObjEntity.PanelSupplier);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblPanelSupplier_Exists(string PanelSupplier)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPanelSupplier_Exists";
            cmdGet.Parameters.AddWithValue("@PanelSupplier", PanelSupplier);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "PanelSupplier");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<PanelSupplierEntity> tblPanelSupplier_Select(PagingEntity CommonEntity, out int Count)
        {
            List<PanelSupplierEntity> lstLocation = new List<PanelSupplierEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPanelSupplier_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                PanelSupplierEntity objEntity = new PanelSupplierEntity();
                objEntity.PanelSupplierID = GetInt32(dr, "PanelSupplierID");
                objEntity.PanelSupplier = GetTextValue(dr, "PanelSupplier");
                objEntity.Active = GetBoolean(dr, "Active");
                // objEntity.Seq = GetInt32(dr, "Seq");              
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<PanelSupplierEntity> tblPanelSupplier_SelectActive()
        {
            List<PanelSupplierEntity> lstLocation = new List<PanelSupplierEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPanelSupplier_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                PanelSupplierEntity objEntity = new PanelSupplierEntity();
                objEntity.PanelSupplierID = GetInt32(dr, "PanelSupplierID");
                objEntity.PanelSupplier = GetTextValue(dr, "PanelSupplier");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual PanelSupplierEntity tblPanelSupplier_ForEdit(int PanelSupplierID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPanelSupplier_ForEdit";
            cmdGet.Parameters.AddWithValue("@PanelSupplierID", PanelSupplierID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            PanelSupplierEntity objEntity = new PanelSupplierEntity();
            while (dr.Read())
            {
                objEntity.PanelSupplierID = GetInt32(dr, "PanelSupplierID");
                objEntity.PanelSupplier = GetTextValue(dr, "PanelSupplier");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual PanelSupplierEntity tblPanelSupplier_SelectForUpdate(string PanelSupplier, Boolean Active)
        {

            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblPanelSupplier_SelectForUpdate";

            cmdGet.Parameters.AddWithValue("@PanelSupplier", PanelSupplier);
            cmdGet.Parameters.AddWithValue("@Active", Active);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            PanelSupplierEntity objEntity = new PanelSupplierEntity();
            while (dr.Read())
            {
                objEntity.PanelSupplier = GetTextValue(dr, "PanelSupplier");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;

        }

        public virtual void tblPanelSupplier_Update(PanelSupplierEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblPanelSupplier_Update";
            cmdAdd.Parameters.AddWithValue("@PanelSupplierID", ObjEntity.PanelSupplierID);
            cmdAdd.Parameters.AddWithValue("@PanelSupplier", ObjEntity.PanelSupplier);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblPanelSupplier_Delete(int PanelSupplierID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblPanelSupplier_Delete";
            cmdDel.Parameters.AddWithValue("@PanelSupplierID", PanelSupplierID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }
    }
}

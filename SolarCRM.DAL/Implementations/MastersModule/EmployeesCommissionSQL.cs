
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

    public class EmployeesCommissionSQL : BaseSqlManager
    {
        public virtual void tblEmployeesCommission_Insert(EmployeesCommissionEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblEmployeesCommission_Insert";
            cmdAdd.Parameters.AddWithValue("@EmployeeID", ObjEntity.EmployeeID);
            cmdAdd.Parameters.AddWithValue("@EmployeesCommission", ObjEntity.EmployeesCommission);
            cmdAdd.Parameters.AddWithValue("@EmployeesComment", ObjEntity.EmployeesComment);           
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        //public virtual int tblEmployeesCommission_Exists(string EmployeesCommission)
        //{
        //    int ID = 0;
        //    SqlCommand cmdGet = new SqlCommand();
        //    cmdGet.CommandType = CommandType.StoredProcedure;
        //    cmdGet.CommandText = "tblEmployeesCommission_Exists";
        //    cmdGet.Parameters.AddWithValue("@EmployeesCommission", EmployeesCommission);
        //    SqlDataReader dr = ExecuteDataReader(cmdGet);
        //    while (dr.Read())
        //    {
        //        ID = GetInt32(dr, "EmployeesCommission");
        //    }
        //    dr.Close();
        //    ForceCloseConnection();
        //    return ID;

        //}

        public virtual List<EmployeesCommissionEntity> tblEmployeesCommission_Select(PagingEntity CommonEntity, out int Count)
        {
            List<EmployeesCommissionEntity> lstLocation = new List<EmployeesCommissionEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployeesCommission_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                EmployeesCommissionEntity objEntity = new EmployeesCommissionEntity();
                objEntity.EmployeesCommissionID = GetInt32(dr, "EmployeesCommissionID");
                objEntity.EmployeesCommission = GetTextValue(dr, "EmployeesCommission");
                objEntity.EmployeesComment = GetTextValue(dr, "EmployeesComment");
                objEntity.Active = GetBoolean(dr, "Active");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual EmployeesCommissionEntity tblEmployeesCommission_ForEdit(int EmployeesCommissionID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblEmployeesCommission_ForEdit";
            cmdGet.Parameters.AddWithValue("@EmployeesCommissionID", EmployeesCommissionID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            EmployeesCommissionEntity objEntity = new EmployeesCommissionEntity();
            while (dr.Read())
            {
                objEntity.EmployeesCommissionID = GetInt32(dr, "EmployeesCommissionID");
                objEntity.EmployeeID = GetInt32(dr, "EmployeeID");
                objEntity.EmployeesCommission = GetTextValue(dr, "EmployeesCommission");
                objEntity.EmployeesComment = GetTextValue(dr, "EmployeesComment");              
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        //public virtual EmployeesCommissionEntity tblEmployeesCommission_SelectForUpdate(string EmployeesCommission, Boolean Active)
        //{

        //    SqlCommand cmdGet = new SqlCommand();
        //    cmdGet.CommandType = CommandType.StoredProcedure;
        //    cmdGet.CommandText = "tblEmployeesCommission_SelectForUpdate";

        //    cmdGet.Parameters.AddWithValue("@EmployeesCommission", EmployeesCommission);
        //    cmdGet.Parameters.AddWithValue("@Active", Active);
        //    SqlDataReader dr = ExecuteDataReader(cmdGet);
        //    EmployeesCommissionEntity objEntity = new EmployeesCommissionEntity();
        //    while (dr.Read())
        //    {
        //        objEntity.FName = GetTextValue(dr, "FName");
        //        objEntity.Active = GetBoolean(dr, "Active");
        //    }
        //    dr.Close();
        //    ForceCloseConnection();
        //    return objEntity;

        //}

        public virtual void tblEmployeesCommission_Update(EmployeesCommissionEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblEmployeesCommission_Update";
            cmdAdd.Parameters.AddWithValue("@EmployeesCommissionID", ObjEntity.EmployeesCommissionID);
            cmdAdd.Parameters.AddWithValue("@EmployeeID", ObjEntity.EmployeeID);
            cmdAdd.Parameters.AddWithValue("@EmployeesCommission", ObjEntity.EmployeesCommission);
            cmdAdd.Parameters.AddWithValue("@EmployeesComment", ObjEntity.EmployeesComment);          
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblEmployeesCommission_Delete(int EmployeesCommissionID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblEmployeesCommission_Delete";
            cmdDel.Parameters.AddWithValue("@EmployeesCommissionID", EmployeesCommissionID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }


    }
}

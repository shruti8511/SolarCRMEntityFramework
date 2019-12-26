

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

    public class LeadGenSQL : BaseSqlManager
    {
        public virtual void tblLeadGen_Insert(LeadGenEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblLeadGen_Insert";
            cmdAdd.Parameters.AddWithValue("@ProjectMgrID", ObjEntity.ProjectMgrID);
            cmdAdd.Parameters.AddWithValue("@FName", ObjEntity.FName);
            cmdAdd.Parameters.AddWithValue("@LName", ObjEntity.LName);
            cmdAdd.Parameters.AddWithValue("@Name", ObjEntity.Name);
            cmdAdd.Parameters.AddWithValue("@ContactNum", ObjEntity.ContactNum);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);          
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        //public virtual int tblLeadGen_Exists(string LeadGen)
        //{
        //    int ID = 0;
        //    SqlCommand cmdGet = new SqlCommand();
        //    cmdGet.CommandType = CommandType.StoredProcedure;
        //    cmdGet.CommandText = "tblLeadGen_Exists";
        //    cmdGet.Parameters.AddWithValue("@LeadGen", LeadGen);
        //    SqlDataReader dr = ExecuteDataReader(cmdGet);
        //    while (dr.Read())
        //    {
        //        ID = GetInt32(dr, "LeadGen");
        //    }
        //    dr.Close();
        //    ForceCloseConnection();
        //    return ID;

        //}

        public virtual List<LeadGenEntity> tblLeadGen_Select(PagingEntity CommonEntity, out int Count)
        {
            List<LeadGenEntity> lstLocation = new List<LeadGenEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblLeadGen_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                LeadGenEntity objEntity = new LeadGenEntity();
                objEntity.LeadGenID = GetInt32(dr, "LeadGenID");
                objEntity.Name = GetTextValue(dr, "Name");
                objEntity.ContactNum = GetTextValue(dr, "ContactNum");
                objEntity.Active = GetBoolean(dr, "Active");                        
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual LeadGenEntity tblLeadGen_ForEdit(int LeadGenID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblLeadGen_ForEdit";
            cmdGet.Parameters.AddWithValue("@LeadGenID", LeadGenID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            LeadGenEntity objEntity = new LeadGenEntity();
            while (dr.Read())
            {
                objEntity.LeadGenID = GetInt32(dr, "LeadGenID");
                objEntity.ProjectMgrID = GetInt32(dr, "ProjectMgrID");
                objEntity.FName = GetTextValue(dr, "FName");
                objEntity.LName = GetTextValue(dr, "LName");
                objEntity.Name = GetTextValue(dr, "Name");
                objEntity.ContactNum = GetTextValue(dr, "ContactNum");
                objEntity.Active = GetBoolean(dr, "Active");
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        //public virtual LeadGenEntity tblLeadGen_SelectForUpdate(string LeadGen, Boolean Active)
        //{

        //    SqlCommand cmdGet = new SqlCommand();
        //    cmdGet.CommandType = CommandType.StoredProcedure;
        //    cmdGet.CommandText = "tblLeadGen_SelectForUpdate";

        //    cmdGet.Parameters.AddWithValue("@LeadGen", LeadGen);
        //    cmdGet.Parameters.AddWithValue("@Active", Active);
        //    SqlDataReader dr = ExecuteDataReader(cmdGet);
        //    LeadGenEntity objEntity = new LeadGenEntity();
        //    while (dr.Read())
        //    {
        //        objEntity.FName = GetTextValue(dr, "FName");
        //        objEntity.Active = GetBoolean(dr, "Active");
        //    }
        //    dr.Close();
        //    ForceCloseConnection();
        //    return objEntity;

        //}

        public virtual void tblLeadGen_Update(LeadGenEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblLeadGen_Update";
            cmdAdd.Parameters.AddWithValue("@LeadGenID", ObjEntity.LeadGenID);
            cmdAdd.Parameters.AddWithValue("@ProjectMgrID", ObjEntity.ProjectMgrID);
            cmdAdd.Parameters.AddWithValue("@FName", ObjEntity.FName);
            cmdAdd.Parameters.AddWithValue("@LName", ObjEntity.LName);
            cmdAdd.Parameters.AddWithValue("@Name", ObjEntity.Name);
            cmdAdd.Parameters.AddWithValue("@ContactNum", ObjEntity.ContactNum);
            cmdAdd.Parameters.AddWithValue("@Active", ObjEntity.Active);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual void tblLeadGen_Delete(int LeadGenID)
        {
            SqlCommand cmdDel = new SqlCommand();
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.CommandText = "tblLeadGen_Delete";
            cmdDel.Parameters.AddWithValue("@LeadGenID", LeadGenID);
            ExecuteNonQuery(cmdDel);
            ForceCloseConnection();
        }


        //public virtual List<LeadGenEntity> tblCustSourceSub_SelectByCSID(int CompanySourceID)
        //{
        //    List<LeadGenEntity> lstLocation = new List<LeadGenEntity>();
        //    SqlCommand cmdGet = new SqlCommand();
        //    cmdGet.CommandType = CommandType.StoredProcedure;
        //    cmdGet.CommandText = "tblCustSourceSub_SelectByCSID";
        //    cmdGet.Parameters.AddWithValue("@CompanySourceID", CompanySourceID);
        //    SqlDataReader dr = ExecuteDataReader(cmdGet);
        //    while (dr.Read())
        //    {
        //        LeadGenEntity objEntity = new LeadGenEntity();
        //        objEntity.LeadGenID = GetInt32(dr, "LeadGenID");
        //        objEntity.LeadGen = GetTextValue(dr, "LeadGen");

        //        lstLocation.Add(objEntity);
        //    }
        //    dr.Close();
        //    ForceCloseConnection();
        //    return lstLocation;
        //}

    }
}

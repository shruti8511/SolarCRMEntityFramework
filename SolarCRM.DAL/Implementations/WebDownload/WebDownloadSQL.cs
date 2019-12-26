using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.WebDownloadModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.DAL.Implementations.WebDownload
{
    public class WebDownloadSQL : BaseSqlManager
    {

        public virtual long tblWebDownload_Insert(string Customer, string First, string Last, string Email, string Phone, string Mobile, string Address, string City, string State, string PostCode, string Source, string System, string Roof, string Angle, string Story, string HouseAge, string Notes, string SubSource)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblWebDownload_Insert";
            cmdAdd.Parameters.AddWithValue("@Customer", Customer);
            cmdAdd.Parameters.AddWithValue("@ContFirst", First);
            cmdAdd.Parameters.AddWithValue("@ContLast", Last);
            cmdAdd.Parameters.AddWithValue("@ContEmail", Email);
            cmdAdd.Parameters.AddWithValue("@CustPhone", Phone);
            cmdAdd.Parameters.AddWithValue("@ContMobile", Mobile);
            cmdAdd.Parameters.AddWithValue("@Address", Address);
            cmdAdd.Parameters.AddWithValue("@City", City);
            cmdAdd.Parameters.AddWithValue("@State", State);
            cmdAdd.Parameters.AddWithValue("@PostCode", PostCode);
            cmdAdd.Parameters.AddWithValue("@Source", Source);
            cmdAdd.Parameters.AddWithValue("@System", System);
            cmdAdd.Parameters.AddWithValue("@Roof", Roof);
            cmdAdd.Parameters.AddWithValue("@Angle", Angle);
            cmdAdd.Parameters.AddWithValue("@Story", Story);
            cmdAdd.Parameters.AddWithValue("@HouseAge", HouseAge);
            cmdAdd.Parameters.AddWithValue("@Notes", Notes);
            cmdAdd.Parameters.AddWithValue("@SubSource", SubSource);
            long ID = Convert.ToInt64(ExecuteScalar(cmdAdd));
            ForceCloseConnection();
            return ID;
            //ExecuteNonQuery(cmdAdd);
            //ForceCloseConnection();

        }



        public virtual List<WebDownloadEntity> tblWebDownload_Select(PagingEntity CommonEntity, out int Count)
        {
            List<WebDownloadEntity> lstLocation = new List<WebDownloadEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblWebDownload_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                WebDownloadEntity objEntity = new WebDownloadEntity();
                objEntity.WebDownloadID = GetInt32(dr, "WebDownloadID");
                objEntity.Customer = GetTextValue(dr, "Customer");
                objEntity.System = GetTextValue(dr, "System");
                objEntity.ContEmail = GetTextValue(dr, "ContEmail");
                objEntity.CustPhone = GetTextValue(dr, "CustPhone");               
                objEntity.ContMobile = GetTextValue(dr, "ContMobile");
                objEntity.Address = GetTextValue(dr, "Address");
                objEntity.City = GetTextValue(dr, "City");
                objEntity.State = GetTextValue(dr, "State");
                objEntity.Duplicate = GetBoolean(dr, "Duplicate");
                objEntity.NotDuplicate = GetBoolean(dr, "NotDuplicate");
                objEntity.Notes = GetTextValue(dr, "Notes");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }


    }
}

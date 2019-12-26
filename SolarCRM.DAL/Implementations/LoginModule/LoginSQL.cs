
namespace SolarCRM.DAL.Implementations.LoginModule
{
    using SolarCRM.Entity.Models.Common;
    using SolarCRM.Entity.Models.LoginModule;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class LoginSQL : BaseSqlManager
    {
        public virtual LoginEntity SpUtilitiesGetDataStructById(string id)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "SpUtilitiesGetDataStructById";
            cmdGet.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            LoginEntity details = new LoginEntity();
            while (dr.Read())
            {
                details.id = GetInt32(dr, "id");
                details.sitename = GetTextValue(dr, "sitename");
                details.sitelogo = GetTextValue(dr, "sitelogo");
                details.siteurl = GetTextValue(dr, "siteurl");
                details.MailServer = GetTextValue(dr, "MailServer");
                details.from = GetTextValue(dr, "from");
                details.cc = GetTextValue(dr, "cc");
                details.username = GetTextValue(dr, "username");
                details.Password = GetTextValue(dr, "Password");
                details.OrderThanksMessage = GetTextValue(dr, "OrderThanksMessage");
                details.ContactUsThanksmessage = GetTextValue(dr, "ContactUsThanksmessage");
                details.OrderSubject = GetTextValue(dr, "OrderSubject");
                details.Contactussubject = GetTextValue(dr, "Contactussubject");
                details.Regards_Name = GetTextValue(dr, "Regards_Name");
                details.emailbodybordercolor = GetTextValue(dr, "emailbodybordercolor");
                details.adminfooter = GetTextValue(dr, "adminfooter");
                details.PaypalAccountName = GetTextValue(dr, "PaypalAccountName");
                details.PaypalMode = GetTextValue(dr, "PaypalMode");
                details.PaypalCurrencySymbol = GetTextValue(dr, "PaypalCurrencySymbol");
                details.emailtop = GetTextValue(dr, "emailtop");
                details.emailbottom = GetTextValue(dr, "emailbottom");
                details.sitelogoupload = GetTextValue(dr, "sitelogoupload");
                details.Authenticate = GetTextValue(dr, "Authenticate");
                details.SSLPortno = GetTextValue(dr, "SSLPortno");
                details.SSLValue = GetTextValue(dr, "SSLValue");
                details.Hours = GetTextValue(dr, "Hours");
                details.Minutes = GetTextValue(dr, "Minutes");

            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }

        public virtual void tblLogInTrack_Insert(string UserId, string LogInTime, string IPAddress, string LogOutTime, string IsSession)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblLogInTrack_Insert";
            cmdAdd.Parameters.AddWithValue("@UserId", UserId);
            cmdAdd.Parameters.AddWithValue("@LogInTime", Convert.ToDateTime(LogInTime));
            cmdAdd.Parameters.AddWithValue("@IPAddress", IPAddress);
            cmdAdd.Parameters.AddWithValue("@LogOutTime", LogOutTime);
            cmdAdd.Parameters.AddWithValue("@IsSession", IsSession);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual LogInTrackEntity tblLogInTrack_Select(string UserId, string IPAddress)
        {
            string ID = string.Empty;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblLogInTrack_Select";
            cmdGet.Parameters.AddWithValue("@UserId", UserId);
            cmdGet.Parameters.AddWithValue("@IPAddress", IPAddress);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            LogInTrackEntity details = new LogInTrackEntity();
            while (dr.Read())
            {
                details.ID = GetTextValue(dr, "ID");
                details.UserId = GetTextValue(dr, "UserId");
                details.LogInTime = GetDateTime(dr, "LogInTime");
                details.LogOutTime = GetDateTime(dr, "LogOutTime");
                details.IPAddress = GetTextValue(dr, "IPAddress");
                details.IsSession = GetBoolean(dr, "IsSession");
            }
            dr.Close();
            ForceCloseConnection();
            return details;

        }

        public virtual bool tblLogInTrack_Update(string ID, string LogOutTime, string IsSession)
        {
            try
            {
                SqlCommand cmdAdd = new SqlCommand();
                cmdAdd.CommandType = CommandType.StoredProcedure;
                cmdAdd.CommandText = "tblLogInTrack_Update";
                cmdAdd.Parameters.AddWithValue("@ID", ID);
                cmdAdd.Parameters.AddWithValue("@LogOutTime", LogOutTime);
                cmdAdd.Parameters.AddWithValue("@IsSession", IsSession);
                ExecuteNonQuery(cmdAdd);
                ForceCloseConnection();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public virtual List<LogInTrackEntity> tblLogInTrack_SelectAll(PagingEntity CommonEntity, out int Count)
        {
            List<LogInTrackEntity> lstLocation = new List<LogInTrackEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblLogInTrack_SelectAll";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                LogInTrackEntity objEntity = new LogInTrackEntity();
                objEntity.ID = GetTextValue(dr, "ID");
                objEntity.UserId = GetTextValue(dr, "UserId");
                objEntity.UserName = GetTextValue(dr, "UserName");
                //  objEntity.LoginDate = GetTextValue(dr, "LoginDate");
                objEntity.IPAddress = GetTextValue(dr, "IPAddress");
                objEntity.LogInTime = GetDateTime(dr, "LogInTime");
                objEntity.LogOutTime = GetDateTime(dr, "LogOutTime");
                objEntity.IsSession = GetBoolean(dr, "IsSession");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstLocation;
        }
    }
}

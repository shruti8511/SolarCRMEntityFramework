using System;
using System.Data;
using System.Collections.Generic;
using System.Web.Services;
using System.Collections;
using System.Web.Services.Protocols;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for Search
/// </summary>

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class Search : System.Web.Services.WebService
{
    public Search()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //[WebMethod]
    //public string[] GetCitiesList(string prefixText, int count,string contextKey)
    //{
    //    count = 10;

    //    string sql = String.Format("select Area   + ' | '+ Suburb+ ' | ' +State+ ' | '+ CONVERT(nvarchar(100),PostCode) + ' | ' +  CONVERT(nvarchar(100),CompanyLocationID)  from tblPostCodes where State = @State and  (Area like @name + '%' or Suburb like @name + '%' or PostCode like @name + '%')");     
    //    List<string> BeneficiaryList = new List<string>();
    //    SqlConnection connection = new SqlConnection();
    //    connection.ConnectionString = SiteConfiguration.DbConnectionString;
    //    using (SqlCommand command = new SqlCommand(sql, connection))
    //    {
    //        connection.Open();
    //        command.Parameters.AddWithValue("@State", contextKey);
    //        command.Parameters.AddWithValue("@name", prefixText);
    //        using (SqlDataReader reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                BeneficiaryList.Add(reader.GetString(0));
    //            }
    //        }
    //    }
    //    return BeneficiaryList.ToArray();
    //}

    //[WebMethod]
    //public string[] GetCities(string prefixText, int count)
    //{
    //    count = 10;
    //    string sql = String.Format("select Suburb from tblPostCodes where Suburb like @name + '%'");
    //    List<string> BeneficiaryList = new List<string>();
    //    SqlConnection connection = new SqlConnection();
    //    connection.ConnectionString = SiteConfiguration.DbConnectionString;
    //    using (SqlCommand command = new SqlCommand(sql, connection))
    //    {
    //        connection.Open();
    //        command.Parameters.AddWithValue("@name", prefixText);
    //        using (SqlDataReader reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                BeneficiaryList.Add(reader.GetString(0));
    //            }
    //        }
    //    }
    //    return BeneficiaryList.ToArray();
    //}

    //[WebMethod]
    //public string[] GetPostCodeList(string prefixText, int count)
    //{
    //    count = 10;
    //    string sql = String.Format("select distinct CONVERT(nvarchar(100),PostCode) from tblPostCodes where PostCode like @name + '%'");
    //    List<string> BeneficiaryList = new List<string>();
    //    SqlConnection connection = new SqlConnection();
    //    connection.ConnectionString = SiteConfiguration.DbConnectionString;
    //    using (SqlCommand command = new SqlCommand(sql, connection))
    //    {
    //        connection.Open();
    //        command.Parameters.AddWithValue("@name", prefixText);
    //        using (SqlDataReader reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                BeneficiaryList.Add(reader.GetString(0));
    //            }
    //        }
    //    }
    //    return BeneficiaryList.ToArray();
    //}
    
    //[WebMethod]
    //public string[] GetCompanyList(string prefixText, int count)
    //{
    //    count = 10;
    //    string sql = String.Format("select distinct Customer from tblCustomers where Customer like @name + '%'");
    //    List<string> BeneficiaryList = new List<string>();
    //    SqlConnection connection = new SqlConnection();
    //    connection.ConnectionString = SiteConfiguration.DbConnectionString;
    //    using (SqlCommand command = new SqlCommand(sql, connection))
    //    {
    //        connection.Open();
    //        command.Parameters.AddWithValue("@name", prefixText);
    //        using (SqlDataReader reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                BeneficiaryList.Add(reader.GetString(0));
    //            }
    //        }
    //    }
    //    return BeneficiaryList.ToArray();
    //}


    //[WebMethod]
    //public string[] GetWHSCustList(string prefixText, int count)
    //{
    //    count = 10;
    //    string sql = String.Format("select distinct Customer from tblCustomers where CustTypeID=14 and Customer like @name + '%'");
    //    List<string> BeneficiaryList = new List<string>();
    //    SqlConnection connection = new SqlConnection();
    //    connection.ConnectionString = SiteConfiguration.DbConnectionString;
    //    using (SqlCommand command = new SqlCommand(sql, connection))
    //    {
    //        connection.Open();
    //        command.Parameters.AddWithValue("@name", prefixText);
    //        using (SqlDataReader reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                BeneficiaryList.Add(reader.GetString(0));
    //            }
    //        }
    //    }
    //    return BeneficiaryList.ToArray();
    //}

    //[WebMethod]
    //public string[] GetContactList(string prefixText, int count)
    //{
    //    count = 10;
    //    string sql = String.Format("select distinct ContFirst + ' '+ ContLast from tblContacts where ContFirst like @name + '%' or ContLast like @name + '%'");
    //    List<string> BeneficiaryList = new List<string>();
    //    SqlConnection connection = new SqlConnection();
    //    connection.ConnectionString = SiteConfiguration.DbConnectionString;
    //    using (SqlCommand command = new SqlCommand(sql, connection))
    //    {
    //        connection.Open();
    //        command.Parameters.AddWithValue("@name", prefixText);
    //        using (SqlDataReader reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //               BeneficiaryList.Add(reader.GetString(0));
    //            }
    //        }
    //    }
    //    return BeneficiaryList.ToArray();
    //}

    //[WebMethod]
    //public string[] GetInvoiceNumber(string prefixText, int count)
    //{
    //    count = 10;
    //    string sql = String.Format("select convert(varchar(20),InvoiceNumber) from tblProjects where convert(varchar(20),InvoiceNumber) like @MQN + '%'");
    //    List<string> MQNList = new List<string>();
    //    SqlConnection connection = new SqlConnection();
    //    connection.ConnectionString = SiteConfiguration.DbConnectionString;
    //    using (SqlCommand command = new SqlCommand(sql, connection))
    //    {
    //        connection.Open();
    //        command.Parameters.AddWithValue("@MQN", prefixText);
    //        using (SqlDataReader reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                MQNList.Add(reader.GetString(0));
    //            }
    //        }
    //    }
    //    return MQNList.ToArray();
    //}

    //[WebMethod]
    //public string[] GetManualQuoteNumber(string prefixText, int count)
    //{
    //    count = 10;
    //    string sql = String.Format("select distinct ManualQuoteNumber from tblProjects where ManualQuoteNumber like @MQN + '%'");
    //    List<string> MQNList = new List<string>();
    //    SqlConnection connection = new SqlConnection();
    //    connection.ConnectionString = SiteConfiguration.DbConnectionString;
    //    using (SqlCommand command = new SqlCommand(sql, connection))
    //    {
    //        connection.Open();
    //        command.Parameters.AddWithValue("@MQN", prefixText);
    //        using (SqlDataReader reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                MQNList.Add(reader.GetString(0));
    //            }
    //        }
    //    }
    //    return MQNList.ToArray();
    //}

    //[WebMethod]
    //public string[] GetProjectNumber(string prefixText, int count)
    //{
    //    count = 10;
    //    string sql = String.Format("select convert(varchar(20),ProjectNumber) from tblProjects where convert(varchar(20),ProjectNumber) like @PN + '%'");
    //    List<string> ProjectNumberList = new List<string>();
    //    SqlConnection connection = new SqlConnection();
    //    connection.ConnectionString = SiteConfiguration.DbConnectionString;
    //    using (SqlCommand command = new SqlCommand(sql, connection))
    //    {
    //        connection.Open();
    //        command.Parameters.AddWithValue("@PN", prefixText);
    //        using (SqlDataReader reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                ProjectNumberList.Add(reader.GetString(0));
    //            }
    //        }
    //    }
    //    return ProjectNumberList.ToArray();
    //}

    //[WebMethod]
    //public string[] GetCompanyNumber(string prefixText, int count)
    //{
    //    count = 10;
    //    string sql = String.Format("select convert(varchar(20),CompanyNumber) from tblCustomers where convert(varchar(20),CompanyNumber) like @CN + '%'");
    //    List<string> CompanyNumberList = new List<string>();
    //    SqlConnection connection = new SqlConnection();
    //    connection.ConnectionString = SiteConfiguration.DbConnectionString;
    //    using (SqlCommand command = new SqlCommand(sql, connection))
    //    {
    //        connection.Open();
    //        command.Parameters.AddWithValue("@CN", prefixText);
    //        using (SqlDataReader reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                CompanyNumberList.Add(reader.GetString(0));
    //            }
    //        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
    //    }
    //    return CompanyNumberList.ToArray();
    //}

    //[WebMethod]
    //public string[] GetProjectList(string prefixText, int count)
    //{
    //    count = 10;
    //    string sql = String.Format("select distinct Project from tblProjects where Project like @name + '%'");
    //    List<string> ProjectList = new List<string>();
    //    SqlConnection connection = new SqlConnection();
    //    connection.ConnectionString = SiteConfiguration.DbConnectionString;
    //    using (SqlCommand command = new SqlCommand(sql, connection))
    //    {
    //        connection.Open();
    //        command.Parameters.AddWithValue("@name", prefixText);
    //        using (SqlDataReader reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                ProjectList.Add(reader.GetString(0));
    //            }
    //        }
    //    }
    //    return ProjectList.ToArray();
    //}

    //[WebMethod]
    //public string[] GetPVDNumber(string prefixText, int count)
    //{
    //    count = 10;
    //    string sql = String.Format("select distinct PVDNumber from tblProjects where PVDNumber like @name + '%'");
    //    List<string> PVDNumberList = new List<string>();
    //    SqlConnection connection = new SqlConnection();
    //    connection.ConnectionString = SiteConfiguration.DbConnectionString;
    //    using (SqlCommand command = new SqlCommand(sql, connection))
    //    {
    //        connection.Open();
    //        command.Parameters.AddWithValue("@name", prefixText);
    //        using (SqlDataReader reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                PVDNumberList.Add(reader.GetString(0));
    //            }
    //        }
    //    }
    //    return PVDNumberList.ToArray();
    //}

    //[WebMethod]
    //public string[] GetPromoList(string prefixText, int count)
    //{
    //    count = 10;
    //    string sql = String.Format("select distinct Promo from tblPromo where Promo like @name + '%'");
    //    List<string> PromoList = new List<string>();
    //    SqlConnection connection = new SqlConnection();
    //    connection.ConnectionString = SiteConfiguration.DbConnectionString;
    //    using (SqlCommand command = new SqlCommand(sql, connection))
    //    {
    //        connection.Open();
    //        command.Parameters.AddWithValue("@name", prefixText);
    //        using (SqlDataReader reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                PromoList.Add(reader.GetString(0));
    //            }
    //        }
    //    }
    //    return PromoList.ToArray();
    //}
}

using System;
using System.Data;
using System.Collections.Generic;
using System.Web.Services;
using System.Collections;
using System.Web.Services.Protocols;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

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

    [WebMethod]
    public string[] GetCitiesList(string prefixText, int count, string contextKey)
    {
        count = 10;
        string sql = String.Format("select Suburb+ ' | '+State+' | '+ CONVERT(nvarchar(100),PostCode) + ' | ' +  CONVERT(nvarchar(100),Area) + ' | ' +  CONVERT(nvarchar(100),AreaType) + ' | ' +  CONVERT(nvarchar(100),CompanyLocationID) from tblPostCodes where State like @state + '%' and Suburb like @name + '%' or State like @name + '%' or PostCode like @name + '%'");
        List<string> BeneficiaryList = new List<string>();
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            connection.Open();
            command.Parameters.AddWithValue("@name", prefixText);
            command.Parameters.AddWithValue("@state", contextKey);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    BeneficiaryList.Add(reader.GetString(0));
                }
            }
        }
        return BeneficiaryList.ToArray();
    }

    [WebMethod]
    public string[] GetCompanyList(string prefixText, int count)
    {
        count = 10;
        string sql = String.Format("select distinct Customer from tblCustomers where Customer like @name + '%'");
        List<string> BeneficiaryList = new List<string>();
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            connection.Open();
            command.Parameters.AddWithValue("@name", prefixText);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    BeneficiaryList.Add(reader.GetString(0));
                }
            }
        }
        return BeneficiaryList.ToArray();
    }


    [WebMethod]
    public string[] GetProjectNumber(string prefixText, int count)
    {
        count = 10;
        string sql = String.Format("select convert(varchar(20),ProjectNumber) from tblProjects where convert(varchar(20),ProjectNumber) like @PN + '%'");
        List<string> ProjectNumberList = new List<string>();
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            connection.Open();
            command.Parameters.AddWithValue("@PN", prefixText);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProjectNumberList.Add(reader.GetString(0));
                }
            }
        }
        return ProjectNumberList.ToArray();
    }
}

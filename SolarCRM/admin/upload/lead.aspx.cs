using SolarCRM.BAL.Implementations.WebDownload;
using SolarCRM.Entity.Models;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.WebDownloadModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SolarCRM.PagingUserControl;

namespace SolarCRM.admin.upload
{
    public partial class lead : System.Web.UI.Page
    {
        protected string SiteURL;

        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;
             if (!IsPostBack)
            {
                Session["PageNo"] = 1;
                Session["PageSize"] = 10;
                BindLead();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           // int success = 0;
            long ProID = 0;
            Response.Expires = 400;
            Server.ScriptTimeout = 1200;
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Request.PhysicalApplicationPath + "\\userfiles" + "\\LeadFormate\\" + FileUpload1.FileName);
                string connectionString = "";

                connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Request.PhysicalApplicationPath + "userfiles" + "\\LeadFormate\\" + FileUpload1.FileName + ";Extended Properties=Excel 12.0;";

                OleDbConnection excelConnection = new OleDbConnection(connectionString);
                //Create OleDbCommand to fetch data from Excel
                OleDbCommand cmd = new OleDbCommand("Select * from [Sheet1$]", excelConnection);

                excelConnection.Open();



                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");

                using (DbConnection connection = factory.CreateConnection())
                {

                    connection.ConnectionString = connectionString;
                    connection.Open();

                    using (DbCommand command = connection.CreateCommand())
                    {
                        // Cities$ comes from the name of the worksheet

                        command.CommandText = "SELECT * FROM [Sheet1$]";
                        command.CommandType = CommandType.Text;

                        string employeeid = string.Empty;
                        string flag = "true";
                        using (DbDataReader dr1 = command.ExecuteReader())
                        {
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    string Source = dr1["Source"].ToString();
                                    if (Source == string.Empty)
                                    {
                                        string First = "";
                                        string Last = "";
                                        string Email = "";
                                        string Phone = "";
                                        string Mobile = "";
                                        string Address = "";
                                        string City = "";
                                        string State = "";
                                        string PostCode = "";
                                        string System = "";
                                        string Roof = "";
                                        string Angle = "";
                                        string Story = "";
                                        string HouseAge = "";
                                        string Notes = "";
                                        string SubSource = "";

                                        First = dr1["First"].ToString();
                                        Last = dr1["Last"].ToString();
                                        Email = dr1["Email"].ToString();
                                        Phone = dr1["Phone"].ToString();
                                        Mobile = dr1["Mobile"].ToString();
                                        Address = dr1["Address"].ToString();
                                        City = dr1["City"].ToString();
                                        State = dr1["State"].ToString();
                                        PostCode = dr1["PostCode"].ToString();
                                        Source = dr1["Source"].ToString();
                                        System = dr1["System"].ToString();
                                        Roof = dr1["Roof"].ToString();
                                        Angle = dr1["Angle"].ToString();
                                        Story = dr1["Story"].ToString();
                                        HouseAge = dr1["HouseAge"].ToString();
                                        Notes = dr1["Notes"].ToString();
                                        SubSource = dr1["SubSource"].ToString();

                                        if ((First != string.Empty) || (Last != string.Empty) || (Email != string.Empty) || (Phone != string.Empty) || (Mobile != string.Empty) || (Address != string.Empty) || (City != string.Empty) || (State != string.Empty) || (PostCode != string.Empty) || (System != string.Empty) || (Roof != string.Empty) || (Angle != string.Empty) || (Story != string.Empty) || (HouseAge != string.Empty) || (Notes != string.Empty))
                                        {
                                            flag = "false";
                                        }
                                    }
                                }
                            }
                        }
                        using (DbDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                if (flag == "false")
                                {
                                    PanEmpty.Visible = true;
                                    lblPanEmpty.Text = "Please Enter Lead Source.";
                                }
                                else
                                {
                                    while (dr.Read())
                                    {
                                        string Customer = "";
                                        string First = "";
                                        string Last = "";
                                        string Email = "";
                                        string Phone = "";
                                        string Mobile = "";
                                        string Address = "";
                                        string City = "";
                                        string State = "";
                                        string PostCode = "";
                                        string Source = "";
                                        string System = "";
                                        string Roof = "";
                                        string Angle = "";
                                        string Story = "";
                                        string HouseAge = "";
                                        string Notes = "";
                                        string SubSource = "";

                                        First = dr["First"].ToString();
                                        Last = dr["Last"].ToString();
                                        Email = dr["Email"].ToString();
                                        Phone = dr["Phone"].ToString();
                                        Mobile = dr["Mobile"].ToString();
                                        Address = dr["Address"].ToString();
                                        City = dr["City"].ToString();
                                        State = dr["State"].ToString();
                                        PostCode = dr["PostCode"].ToString();
                                        Source = dr["Source"].ToString();
                                        System = dr["System"].ToString();
                                        Roof = dr["Roof"].ToString();
                                        Angle = dr["Angle"].ToString();
                                        Story = dr["Story"].ToString();
                                        HouseAge = dr["HouseAge"].ToString();
                                        Notes = dr["Notes"].ToString();
                                        SubSource = dr["SubSource"].ToString();

                                        if (dr["Mobile"].ToString() != string.Empty)
                                        {
                                            if (Mobile.Substring(0, 1) == "0")
                                            {
                                                Mobile = dr["Mobile"].ToString();
                                            }
                                            else
                                            {
                                                Mobile = "0" + dr["Mobile"].ToString();
                                            }
                                        }
                                        
                                        //if (Source.Trim() == "Lead Source")
                                        //{
                                        //    if (SubSource == string.Empty)
                                        //    {
                                        //        SubSource = "Q-Company";
                                        //    }
                                        //    else
                                        //    {
                                        //        DataTable dtSubSource = ClstblWebDownload.tblCustSourceSub_SelectBySourceSub(SubSource);
                                        //        if (dtSubSource.Rows.Count > 0)
                                        //        {
                                        //            SubSource = dtSubSource.Rows[0]["CustSourceSub"].ToString();
                                        //        }
                                        //        else
                                        //        {
                                        //            SubSource = "Q-Company";
                                        //        }
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    SubSource = "";
                                        //}
                                       
                                        Customer = First.Trim() + " " + Last.Trim();
                                        if ((First != string.Empty) || (Last != string.Empty) || (Email != string.Empty) || (Phone != string.Empty) || (Mobile != string.Empty) || (Address != string.Empty) || (City != string.Empty) || (State != string.Empty) || (PostCode != string.Empty) || (System != string.Empty) || (Roof != string.Empty) || (Angle != string.Empty) || (Story != string.Empty) || (HouseAge != string.Empty) || (Notes != string.Empty))                                   
                                        {
                                            
                                            try
                                            {
                                                ProID = WebDownloadManagement.tblWebDownload_Insert(Customer, First, Last, Email, Phone, Mobile, Address, City, State, PostCode, Source, System, Roof, Angle, Story, HouseAge, Notes, SubSource);
                                                BindLead();
                                            }
                                            catch { }
                                        }
                                        if (ProID > 0)
                                        {
                                            divSuccess.Visible = true;
                                            divAlert.Visible = false;
                                            PanEmpty.Visible = false;
                                            lblSuccessMsg.Text = "Transaction Successful.";
                                        }
                                        else
                                        {
                                            divAlert.Visible = true;
                                            lblErrorMsg.Text = "Transaction Failed.";
                                            divSuccess.Visible = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }


        private void BindLead()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<WebDownloadEntity> lstEntity = new List<WebDownloadEntity>();
                lstEntity = WebDownloadManagement.tblWebDownload_Select(objCommon, out Count);
                rptLead.DataSource = lstEntity;
                rptLead.DataBind();
                pageGrid.BindPageing(Count);

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }





        protected void btnalert_Click(object sender, EventArgs e)
        {
            divAlert.Visible = false;
        }

        protected void btnSuccess_Click(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
        }

        protected void PanEmpty_Click(object sender, EventArgs e)
        {
            divPanEmpty.Visible = false;
        }



        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindLead();

            //if (Convert.ToInt32(Session["pager"]) == 1)
            //{
            //    bindsearch();
            //}
            //else
            //{
            //    BindAmount();
            //}
        }

        protected void btnAddLead_Click(object sender, EventArgs e)
        {
            Response.Redirect(SiteURL + "/admin/company/addcompany.aspx");
           
        }


       
    }
}
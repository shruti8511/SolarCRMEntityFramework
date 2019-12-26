using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SolarCRM.BAL.Implementations.CompanyModule;
using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.BAL.Implementations.ProjectModule;
using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.CompanyModule;
using SolarCRM.Entity.Models.EmployeeModule;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.ProjectModule;
using SolarCRM.PagingUserControl;
using System.Web.Security;
using SolarCRM.BAL.Comman;
using SolarCRM.Common;
using SolarCRM.BAL.Implementations.StockModule;
using SolarCRM.Entity.Models.StockModule;
using System.IO;
using System.Configuration;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
using System.Globalization;

namespace SolarCRM.admin.invoice
{
    public partial class Quotation : System.Web.UI.Page
    {
        protected string SiteURL;
        static long ProjectID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;

            if (!IsPostBack)
            {
                BindProjectDropdown();
                BindDetail();

            }
        }
        public void BindProjectDropdown()
        {
            try
            {
                ddlProject.Items.Clear();
                string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();

                if (chkActive.Checked == true)
                {
                    ddlProject.DataSource = ProjectsManagement.tblProjects_SelectByProjectStatusForDropdown("Active", userid);
                    // ddlProject.DataSource = CustomersManagement.tblCustomer_SelectByCustomerTypeID(3);
                    ddlProject.DataValueField = "ProjectID";
                    ddlProject.DataTextField = "ProjectDetail";
                    ddlProject.DataMember = "ProjectDetail";
                    ddlProject.DataBind();

                }
                if (chkComplete.Checked == true)
                {
                    ddlProject.DataSource = ProjectsManagement.tblProjects_SelectByProjectStatusForDropdown("Complete", userid);
                    // ddlProject.DataSource = CustomersManagement.tblCustomer_SelectByCustomerTypeID(5);
                    ddlProject.DataValueField = "ProjectID";
                    ddlProject.DataTextField = "ProjectDetail";
                    ddlProject.DataMember = "ProjectDetail";
                    ddlProject.DataBind();
                }

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
        protected void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            BindProjectDropdown();
        }

        protected void chkComplete_CheckedChanged(object sender, EventArgs e)
        {
            BindProjectDropdown();
        }

        public void BindDetail()
        {
            if (ddlProject.SelectedValue != "0")
            {
                string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
                ProjectID = Convert.ToInt64(ddlProject.SelectedValue);
                List<ProjectsEntity> lstProject = new List<ProjectsEntity>();
                lstProject = ProjectsManagement.tblProjects_SelectByProjectIDForQuote(ProjectID);
                rptTaskList.DataSource = lstProject;
                rptTaskList.DataBind();
                BindQuote();
            }
        }
        protected void rptTaskList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptTaskList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "ConvertToInvoice")
            {
                try
                {
                    try
                    {
                        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                        {
                            HiddenField hndProjectQuoteID = (HiddenField)e.Item.FindControl("hndProjectQuoteID");
                            HyperLink hypDoc = (HyperLink)e.Item.FindControl("hypDoc");

                            ProjectsEntity st = ProjectsManagement.tblProjectQuotes_SelectByProjectQuoteID(Convert.ToInt32(hndProjectQuoteID.Value));
                            hypDoc.NavigateUrl = "~/userfiles/QuotationDoc/" + st.QuoteDoc;

                        }
                        long ProjectID;
                        ProjectID = Convert.ToInt64(e.CommandArgument);
                        ProjectsEntity st1 = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);

                        TextWriter txtWriter = new StringWriter() as TextWriter;

                        {
                            Server.Execute("~/mailtemplate/Invoice.aspx?id=" + ProjectID, txtWriter);
                            String htmlText = txtWriter.ToString();
                            HTMLExportToPDF(htmlText, ProjectID + "Invoice.pdf");
                        }
                        //  BindProjectElecInv();
                        BindQuote();
                    }
                    catch (Exception ex)
                    {
                        string ERR;
                        ERR = "Error : " + ex.Message;
                    }


                }
                catch (Exception ex)
                {

                }
            }

        }

        public void HTMLExportToPDF(string HTML, string filename)
        {
            System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
            try
            {
                string pdfUser = ConfigurationManager.AppSettings["PDFUserName"];
                string pdfKey = ConfigurationManager.AppSettings["PDFUserKey"];
                // create an API client instance
                pdfcrowd.Client client = new pdfcrowd.Client(pdfUser, pdfKey);
                // convert a web page and write the generated PDF to a memory stream
                MemoryStream Stream = new MemoryStream();
                client.setVerticalMargin("75pt");

                TextWriter txtWriter = new StringWriter() as TextWriter;
              //  Server.Execute("~/mailtemplate/UREQuotationheader.aspx", txtWriter);

                string HeaderHtml = txtWriter.ToString();

                client.setHeaderHtml(HeaderHtml);
                client.convertHtml(HTML, Stream);

                // set HTTP response headers
                Response.Clear();
                Response.AddHeader("Content-Type", "application/pdf");
                Response.AddHeader("Cache-Control", "no-cache");
                Response.AddHeader("Accept-Ranges", "none");
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                // send the generated PDF
                Stream.WriteTo(Response.OutputStream);
                Stream.Close();
                Response.Flush();
                Response.End();
            }

            catch (pdfcrowd.Error why)
            {
                //Response.Write(why.ToString());
                //Response.End();
            }
        }

        public void BindProjectElecInv()
        {
            ProjectsEntity st = ProjectsManagement.tblProjectsSalesInputByProjectID(ProjectID);
            if (Convert.ToString(st.InvoiceNumber) == string.Empty)
            {
                //  btnCreateInvoice.Visible = true;
                // btnOpenInvoice.Visible = false;
            }
            else
            {
                // btnCreateInvoice.Visible = false;
                // btnOpenInvoice.Visible = true;
            }
        }
        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProject.SelectedValue != "")
            {
                divdetails.Visible = true;
                divQuot.Visible = true;
                BindDetail();
            }
        }
        protected void rptQuote_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hndProjectQuoteID = (HiddenField)e.Item.FindControl("hndProjectQuoteID");
                HyperLink hypDoc = (HyperLink)e.Item.FindControl("hypDoc");

                ProjectsEntity st = ProjectsManagement.tblProjectQuotes_SelectByProjectQuoteID(Convert.ToInt32(hndProjectQuoteID.Value));
                hypDoc.NavigateUrl = "~/userfiles/QuotationDoc/" + st.QuoteDoc;

            }
        }
        public void BindQuote()
        {
            List<ProjectsEntity> lstEntity = new List<ProjectsEntity>();
            lstEntity = ProjectsManagement.tblProjectQuotes_SelectByProjectID(ProjectID);
            rptQuote.DataSource = lstEntity;
            rptQuote.DataBind();


            if (lstEntity.Count > 0)
            {
                //btnCreateInvoice.Enabled = true;
                //btnCreateInvoice.Visible = true;
            }
            else
            {
                //btnCreateInvoice.Enabled = false;
                //btnCreateInvoice.Visible = false;
            }
        }

        //protected void btnCreateInvoice_Click(object sender, EventArgs e)
        //{
        //    ProjectsEntity st = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);

        //    string InvoiceDoc = ProjectID + "Quotation.pdf";
        //    if (Convert.ToString(ProjectID) != "")
        //    {

        //        bool suc = ProjectsManagement.tblProjects_UpdateInvoiceDoc(ProjectID, st.ProjectNumber);
        //        if (suc)
        //        {
        //            //btnCreateInvoice.Visible = false;
        //            //btnOpenInvoice.Visible = true;
        //        }
        //        else
        //        {
        //            //btnCreateInvoice.Visible = true;
        //            //btnOpenInvoice.Visible = false;
        //        }
        //    }
        //    BindProjectElecInv();
        //    // }

        //}

        //protected void btnOpenInvoice_Click(object sender, EventArgs e)
        //{
        //    ProjectsEntity st = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);
        //    TextWriter txtWriter = new StringWriter() as TextWriter;

        //    {
        //        Server.Execute("~/mailtemplate/Invoice.aspx?id=" + ProjectID, txtWriter);
        //        String htmlText = txtWriter.ToString();
        //        HTMLExportToPDF(htmlText, ProjectID + "Invoice.pdf");
        //    }
        //    BindProjectElecInv();
        //    // BindInvoice();
        //}

        protected void rptQuote_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "ConvertToInvoice")
            {
                try
                {
                    try
                    {
                        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                        {
                            HiddenField hndProjectQuoteID = (HiddenField)e.Item.FindControl("hndProjectQuoteID");
                            HyperLink hypDoc = (HyperLink)e.Item.FindControl("hypDoc");

                            ProjectsEntity st = ProjectsManagement.tblProjectQuotes_SelectByProjectQuoteID(Convert.ToInt32(hndProjectQuoteID.Value));
                            lblbasicsystemCost.Text = st.BasicSystemCost.ToString();
                            hdnProjID.Value = st.ProjectID.ToString();
                            divQuotDetails.Attributes.Add("class", "modal fade modal-overflow in");
                            divQuotDetails.Attributes.Add("Style", "display:block;");

                        }

                    }
                    catch (Exception ex)
                    {
                        string ERR;
                        ERR = "Error : " + ex.Message;
                    }


                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            ProjectsEntity st = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);

            string InvoiceDoc = ProjectID + "Quotation.pdf";
            if (Convert.ToString(ProjectID) != "")
            {

                bool suc = ProjectsManagement.tblProjects_UpdateInvoiceDoc(ProjectID, st.ProjectNumber);
                if (suc)
                {
                    // btnCreateInvoice.Visible = false;
                    //btnOpenInvoice.Visible = true;
                }
                else
                {
                    //btnCreateInvoice.Visible = true;
                    //btnOpenInvoice.Visible = false;
                }
            }
            //  BindInvoice();

            // }

            TextWriter txtWriter = new StringWriter() as TextWriter;

            {
                Server.Execute("~/mailtemplate/Invoice.aspx?id=" + ProjectID, txtWriter);
                String htmlText = txtWriter.ToString();
                HTMLExportToPDF(htmlText, ProjectID + "Invoice.pdf");
            }
            BindProjectElecInv();
            divQuotDetails.Attributes.Remove("class");
            divQuotDetails.Attributes.Add("class", "modal fade");
            divQuotDetails.Attributes.Remove("Style");




        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            divQuotDetails.Attributes.Remove("class");
            divQuotDetails.Attributes.Add("class", "modal fade");
            divQuotDetails.Attributes.Remove("Style");
        }

        protected void btnCreateQuotes_Click(object sender, ImageClickEventArgs e)
        {
            ProjectsEntity st = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);

            long EmployeeID = st.EmployeeID;
            ProjectID = st.ProjectID;
            long ProjectNumber = st.ProjectNumber;
            int ProjectTypeID = st.ProjectTypeID;



            long ProjectQuoteID = ProjectsManagement.tblProjectQuotes_Insert(ProjectID, ProjectNumber, EmployeeID, st.BasicSystemCost ,st.TotalQuotePrice);

            string QuoteDoc = "Quotation.pdf";

            if (ProjectQuoteID != 0)
            {
                QuoteDoc = ProjectQuoteID + QuoteDoc;
                long suc = ProjectsManagement.tblProjectQuotes_UpdateProjectQuoteDoc(ProjectQuoteID, QuoteDoc);
            }

            TextWriter txtWriter = new StringWriter() as TextWriter;

            //if (st.ProjectTypeID == 2)
            //{
            // Response.Redirect("~/mailtemplate/Quotation.aspx?id=" + ProjectID);
            Server.Execute("~/mailtemplate/Quotation.aspx?id=" + ProjectID, txtWriter);
            String htmlText = txtWriter.ToString();
            SaveCOMMPDF(htmlText, QuoteDoc);
            BindQuote();
            //   }
            //BindQuote();
        }
        public void SaveCOMMPDF(string HTML, string filename)
        {
            System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
            try
            {
                string pdfUser = ConfigurationManager.AppSettings["PDFUserName"];
                string pdfKey = ConfigurationManager.AppSettings["PDFUserKey"];
                //create an API client instance
                pdfcrowd.Client client = new pdfcrowd.Client(pdfUser, pdfKey);
                //convert a web page and write the generated PDF to a memory stream
                MemoryStream Stream = new MemoryStream();

                client.setVerticalMargin("75pt");

                TextWriter txtWriter = new StringWriter() as TextWriter;
               // Server.Execute("~/mailtemplate/UREQuotationheader.aspx", txtWriter);

                string HeaderHtml = txtWriter.ToString();

                client.setHeaderHtml(HeaderHtml);

                FileStream fs = File.Create(Request.PhysicalApplicationPath + "\\userfiles\\QuotationDoc\\" + filename);
                client.convertHtml(HTML, fs);
                fs.Flush();
                fs.Close();
                //   SiteConfiguration.UploadPDFFile("QuotationDoc", filename);

            }
            catch (pdfcrowd.Error why)
            {
                //Response.Write(why.ToString());
                //Response.End();
            }
        }

    }
}
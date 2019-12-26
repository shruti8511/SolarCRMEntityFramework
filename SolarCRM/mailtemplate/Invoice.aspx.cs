using SolarCRM.BAL.Implementations.CompanyModule;
using SolarCRM.BAL.Implementations.ProjectModule;
using SolarCRM.Entity.Models.CompanyModule;
using SolarCRM.Entity.Models.ProjectModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolarCRM.mailtemplate
{
    public partial class Invoice : System.Web.UI.Page
    {
        protected string SiteURL;

        public static string MakeImageSrcData(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] filebytes = new byte[fs.Length];
            fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
            return "data:image/png;base64," +
              Convert.ToBase64String(filebytes, Base64FormattingOptions.None);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;

            if (!IsPostBack)
            {
                long ProjectID = Convert.ToInt64(Request.QueryString["id"]);

                ProjectsEntity stPro = ProjectsManagement.tblProjects_SelectByProjectID(ProjectID);
                CustomersEntity stCust = CustomersManagement.tblCustomers_SelectByCustomerID(stPro.CustomerID);
                ProjectsEntity stProSales = ProjectsManagement.tblProjectsSalesInput_SelectByProjectID(ProjectID);


                long ProjectTypeID = stPro.ProjectTypeID;
                if (ProjectTypeID == 1 || ProjectTypeID == 2 || ProjectTypeID == 4)
                {
                    //if (stPro.GSTNumber != "")
                    //{
                    //    lblTaxTitle.Text = "Tax Invoice";
                    //}
                    //else
                    //{
                    //    lblTaxTitle.Text = "Bill Of Supply";
                    //}



                    lblDate.Text = string.Format("{0:dd MMM yyyy}", DateTime.Now.AddHours(0));

                    //  lblManualInvoiceNumber.Text = stPro.ManualInvoiceNo;

                    lblContact.Text = stCust.Customer;
                    lblPostalAddress.Text = stCust.PostalAddress;
                    lblPostalAddress2.Text = stCust.PostalCity + ", " + stCust.PostalState + ", " + stCust.PostalPostCode;

                    //lblStateCode.Text = stCust.StateCode;
                    //lblPlaceofSupply.Text = stCust.PlaceofSupply;
                    //lblGSTNumber.Text = stCust.GSTNumber;
                    //lblDeliveryAddress.Text = stCust.DeliveryAddress;

                    lblInstalledCapacity.Text = Convert.ToString(stProSales.SystemCapKW);
                    int PerKWCost = Convert.ToInt32(stProSales.PerKWCost);


                    decimal TotalSystemCost = Convert.ToDecimal(PerKWCost) * Convert.ToDecimal(stProSales.SystemCapKW);
                    lblRate.Text = string.Format("{0:0}", PerKWCost);
                    lblValue.Text = string.Format("{0:0}", TotalSystemCost);

                    if (stCust.StreetState == "Gujarat")
                    {

                        lblCGST.Text = Convert.ToString(stProSales.CGST);
                        lblCGSTPer.Text = "2.5";
                        lblSGST.Text = Convert.ToString(stProSales.SGST);
                        lblSGSTPer.Text = "2.5";
                        lblIGST.Text = string.Format("{0:0}", stProSales.IGST);
                        lblIGSTPer.Text = string.Format("{0:0}", 0);
                    }
                    else
                    {
                        lblCGST.Text = string.Format("{0:0}", stProSales.CGST);
                        lblCGSTPer.Text = string.Format("{0:0}", 0);

                        lblSGST.Text = string.Format("{0:0}", stProSales.SGST);
                        lblSGSTPer.Text = string.Format("{0:0}", 0);

                        lblIGST.Text = Convert.ToString(stProSales.IGST);
                        lblIGSTPer.Text = string.Format("{0:0}", 5);
                    }

                    lblTotalInstalledCapacity.Text = Convert.ToString(stProSales.SystemCapKW);
                    decimal TotalCost = Convert.ToDecimal(TotalSystemCost + stProSales.CGST + stProSales.SGST + stProSales.IGST);
                    lblTotalCost.Text = string.Format("{0:0}", TotalCost);

                    int number = Convert.ToInt32(TotalCost);
                    string NumberToWord = NumberToWords(number);
                    lblAmountInWord.Text = NumberToWord;

                    int CGSTtax = Convert.ToInt32(stProSales.CGST);
                    string CGSTTaxStr = CGSTtaxNumber(CGSTtax);
                    lblCGSTTax.Text = CGSTTaxStr;


                    int SGSTtax = Convert.ToInt32(stProSales.SGST);
                    string SGSTTaxStr = SGSTtaxNumber(SGSTtax);
                    lblSGSTTax.Text = SGSTTaxStr;


                    int IGSTtax = Convert.ToInt32(stProSales.IGST);
                    string IGSTTaxStr = IGSTtaxNumber(IGSTtax);
                    lblIGSTTax.Text = IGSTTaxStr;

                    try
                    {
                        decimal newtotalcost = Convert.ToDecimal(stPro.TotalQuotePrice);
                    }
                    catch { }

                    //DataTable dtCount = ClstblInvoicePayments.tblInvoicePayments_CountTotal(ProjectID);
                    //decimal paiddate = 0;
                    //decimal balown = 0;
                    //if (dtCount.Rows[0]["InvoicePayTotal"].ToString() != string.Empty)
                    //{
                    //    paiddate = Convert.ToDecimal(dtCount.Rows[0]["InvoicePayTotal"].ToString());
                    //    balown = Convert.ToDecimal(stPro.TotalQuotePrice) - Convert.ToDecimal(paiddate);

                    //}

                }

                else
                {
                    //if (stPro.GSTNumber != "")
                    //{
                    //    lblTaxTitle.Text = "Tax Invoice";
                    //}
                    //else
                    //{
                    //    lblTaxTitle.Text = "Bill Of Supply";
                    //}


                    lblDate.Text = string.Format("{0:dd MMM yyyy}", DateTime.Now.AddHours(0));

                  //  lblManualInvoiceNumber.Text = stPro.ManualInvoiceNo;


                    lblContact.Text = stCust.Customer;
                    lblPostalAddress.Text = stCust.PostalAddress;
                    lblPostalAddress2.Text = stCust.PostalCity + ", " + stCust.PostalState + ", " + stCust.PostalPostCode;



                    //lblStateCode.Text = stCust.StateCode;
                    //lblPlaceofSupply.Text = stCust.PlaceofSupply;
                    //lblGSTNumber.Text = stCust.GSTNumber;
                    //lblDeliveryAddress.Text = stCust.DeliveryAddress;

                    lblInstalledCapacity.Text = Convert.ToString(stProSales.SystemCapKW);
                    int PerKWCost = Convert.ToInt32(stProSales.PerKWCost);


                    decimal ServiceValue = (Convert.ToDecimal(stProSales.BasicSystemCost));


                    lblRate.Text = string.Format("{0:0}", ServiceValue);
                    lblValue.Text = string.Format("{0:0}", ServiceValue);


                    if (stCust.StreetState == "Gujarat")
                    {
                        lblCGST.Text = Convert.ToString(stProSales.CGST);
                        lblCGSTPer.Text = "2.5";
                        lblSGST.Text = Convert.ToString(stProSales.SGST);
                        lblSGSTPer.Text = "2.5";
                        lblIGST.Text = string.Format("{0:0}", stProSales.IGST);
                        lblIGSTPer.Text = string.Format("{0:0}", 0);
                    }
                    else
                    {
                        lblCGST.Text = string.Format("{0:0}", stProSales.CGST);
                        lblCGSTPer.Text = string.Format("{0:0}", 0);

                        lblSGST.Text = string.Format("{0:0}", stProSales.SGST);
                        lblSGSTPer.Text = string.Format("{0:0}", 0);

                        lblIGST.Text = Convert.ToString(stProSales.IGST);
                        lblIGSTPer.Text = string.Format("{0:0}", 5);
                    }

                    decimal TotalCost = Convert.ToDecimal(ServiceValue + stProSales.CGST + stProSales.SGST + stProSales.IGST);
                    lblTotalCost.Text = string.Format("{0:0}", TotalCost);


                    int number = Convert.ToInt32(TotalCost);
                    string NumberToWord = NumberToWords(number);
                    lblAmountInWord.Text = NumberToWord;


                    int CGSTtax = Convert.ToInt32(lblCGST.Text);
                    string CGSTTaxStr = CGSTtaxNumber(CGSTtax);
                    lblCGSTTax.Text = CGSTTaxStr;


                    int SGSTtax = Convert.ToInt32(lblSGST.Text);
                    string SGSTTaxStr = SGSTtaxNumber(SGSTtax);
                    lblSGSTTax.Text = SGSTTaxStr;



                    int IGSTtax = Convert.ToInt32(lblIGST.Text);
                    string IGSTTaxStr = IGSTtaxNumber(IGSTtax);
                    lblIGSTTax.Text = IGSTTaxStr;


                    try
                    {

                        decimal newtotalcost = Convert.ToDecimal(stPro.TotalQuotePrice);
                        try
                        {
                            //  lblTotalQuotePrice.Text = SiteConfiguration.ChangeCurrencyVal(Convert.ToString(newtotalcost));
                        }
                        catch { }
                    }
                    catch { }

                    try
                    {
                        //lblNetCost.Text = SiteConfiguration.ChangeCurrencyVal(stPro.TotalQuotePrice);
                    }
                    catch { }

                }




            }
        }



        public string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";



            //if ((number / 1000000000) > 0)
            //{
            //    words += NumberToWords(number / 1000000000) + " billion  ";
            //    number %= 1000000000;
            //}


            if ((number / 10000000) > 0)
            {
                words += NumberToWords(number / 10000000) + " crore ";
                number %= 10000000;
            }


            if ((number / 100000) > 0)
            {
                words += NumberToWords(number / 100000) + " lakhs ";
                number %= 100000;
            }


            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public string CGSTtaxNumber(int CGSTtax)
        {
            if (CGSTtax == 0)
                return "zero";

            if (CGSTtax < 0)
                return "minus " + CGSTtaxNumber(Math.Abs(CGSTtax));

            string words1 = "";



            //if ((number / 1000000000) > 0)
            //{
            //    words += NumberToWords(number / 1000000000) + " billion  ";
            //    number %= 1000000000;
            //}


            if ((CGSTtax / 10000000) > 0)
            {
                words1 += CGSTtaxNumber(CGSTtax / 10000000) + " crore ";
                CGSTtax %= 10000000;
            }


            if ((CGSTtax / 100000) > 0)
            {
                words1 += CGSTtaxNumber(CGSTtax / 100000) + " lakhs ";
                CGSTtax %= 100000;
            }


            if ((CGSTtax / 1000) > 0)
            {
                words1 += CGSTtaxNumber(CGSTtax / 1000) + " thousand ";
                CGSTtax %= 1000;
            }

            if ((CGSTtax / 100) > 0)
            {
                words1 += CGSTtaxNumber(CGSTtax / 100) + " hundred ";
                CGSTtax %= 100;
            }

            if (CGSTtax > 0)
            {
                if (words1 != "")
                    words1 += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (CGSTtax < 20)
                    words1 += unitsMap[CGSTtax];
                else
                {
                    words1 += tensMap[CGSTtax / 10];
                    if ((CGSTtax % 10) > 0)
                        words1 += "-" + unitsMap[CGSTtax % 10];
                }
            }

            return words1;
        }

        public string SGSTtaxNumber(int SGSTtax)
        {
            if (SGSTtax == 0)
                return "zero";

            if (SGSTtax < 0)
                return "minus " + SGSTtaxNumber(Math.Abs(SGSTtax));

            string words1 = "";



            //if ((number / 1000000000) > 0)
            //{
            //    words += NumberToWords(number / 1000000000) + " billion  ";
            //    number %= 1000000000;
            //}


            if ((SGSTtax / 10000000) > 0)
            {
                words1 += SGSTtaxNumber(SGSTtax / 10000000) + " crore ";
                SGSTtax %= 10000000;
            }


            if ((SGSTtax / 100000) > 0)
            {
                words1 += SGSTtaxNumber(SGSTtax / 100000) + " lakhs ";
                SGSTtax %= 100000;
            }


            if ((SGSTtax / 1000) > 0)
            {
                words1 += SGSTtaxNumber(SGSTtax / 1000) + " thousand ";
                SGSTtax %= 1000;
            }

            if ((SGSTtax / 100) > 0)
            {
                words1 += SGSTtaxNumber(SGSTtax / 100) + " hundred ";
                SGSTtax %= 100;
            }

            if (SGSTtax > 0)
            {
                if (words1 != "")
                    words1 += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (SGSTtax < 20)
                    words1 += unitsMap[SGSTtax];
                else
                {
                    words1 += tensMap[SGSTtax / 10];
                    if ((SGSTtax % 10) > 0)
                        words1 += "-" + unitsMap[SGSTtax % 10];
                }
            }

            return words1;
        }

        public string IGSTtaxNumber(int IGSTtax)
        {
            if (IGSTtax == 0)
                return "zero";

            if (IGSTtax < 0)
                return "minus " + IGSTtaxNumber(Math.Abs(IGSTtax));

            string words1 = "";



            //if ((number / 1000000000) > 0)
            //{
            //    words += NumberToWords(number / 1000000000) + " billion  ";
            //    number %= 1000000000;
            //}


            if ((IGSTtax / 10000000) > 0)
            {
                words1 += IGSTtaxNumber(IGSTtax / 10000000) + " crore ";
                IGSTtax %= 10000000;
            }


            if ((IGSTtax / 100000) > 0)
            {
                words1 += IGSTtaxNumber(IGSTtax / 100000) + " lakhs ";
                IGSTtax %= 100000;
            }


            if ((IGSTtax / 1000) > 0)
            {
                words1 += IGSTtaxNumber(IGSTtax / 1000) + " thousand ";
                IGSTtax %= 1000;
            }

            if ((IGSTtax / 100) > 0)
            {
                words1 += IGSTtaxNumber(IGSTtax / 100) + " hundred ";
                IGSTtax %= 100;
            }

            if (IGSTtax > 0)
            {
                if (words1 != "")
                    words1 += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (IGSTtax < 20)
                    words1 += unitsMap[IGSTtax];
                else
                {
                    words1 += tensMap[IGSTtax / 10];
                    if ((IGSTtax % 10) > 0)
                        words1 += "-" + unitsMap[IGSTtax % 10];
                }
            }

            return words1;
        }




    }
}
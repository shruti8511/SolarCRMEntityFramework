using SolarCRM.BAL.Implementations.CompanyModule;
using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.BAL.Implementations.ProjectModule;
using SolarCRM.Entity.Models.CompanyModule;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.Entity.Models.ProjectModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolarCRM.mailtemplate
{
    public partial class Quotation : System.Web.UI.Page
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

                ProjectsEntity stProSales = ProjectsManagement.tblProjectsSalesInput_SelectByProjectID(ProjectID);



                ContactsEntity stCont = CustomersManagement.tblContacts_SelectByContactID(stPro.ContactID);
                string userid = Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString();


                EmployeeEntity stEpm = EmployeeManagement.tblEmployees_SelectByUserId(userid);


                int EmployeeID = stEpm.EmployeeID;

                lblEmpFullName.Text = stEpm.EmpMr + " " + stEpm.EmpFirst + " " + stEpm.EmpLast;
                lblEmail.Text = stEpm.EmpEmail;
                lblMobile.Text = stEpm.EmpMobile;
                lblQuotationDate.Text = string.Format("{0:dd MMM yyyy}", DateTime.Now.AddHours(0));
                lblContFirst.Text = stCont.ContFirst;
                lblContLast.Text = stCont.ContLast;


                lblInstallCity.Text = stPro.InstallCity;
                lblInstalledCapacity.Text = Convert.ToString(stProSales.SystemCapKW);
                lblRate.Text = Convert.ToString(stProSales.PerKWCost);
                lblPlantCapacitySecondYear.Text = Convert.ToString(stProSales.SystemCapKW);
                lblPlantCapacityThiredYear.Text = Convert.ToString(stProSales.SystemCapKW);
                lblPlantCapacityFirstYear.Text = Convert.ToString(stProSales.SystemCapKW);




                lblTotalGenerationFirstYear.Text = (Convert.ToDecimal(lblPlantCapacityFirstYear.Text) * Convert.ToDecimal(lblUnitGenerationFirstYear.Text)).ToString();
                decimal TotalGenerationFirstYear = Convert.ToDecimal(lblTotalGenerationFirstYear.Text);
                decimal TotalSavingFirstYear = TotalGenerationFirstYear * Convert.ToDecimal(lblUnitRateFY.Text);
                decimal UnitRateFY = Convert.ToDecimal(lblUnitRateFY.Text);
                lblTotalSavingFirstYear.Text = TotalSavingFirstYear.ToString();


                decimal UnitGenerationFirstYear = Convert.ToDecimal(lblUnitGenerationFirstYear.Text);
                decimal diff = UnitGenerationFirstYear / 100;

                decimal cal = UnitGenerationFirstYear - diff;

                lblUnitGenerationSecondYear.Text = string.Format("{0:0}", cal);

                lblTotalGenerationSecondYear.Text = (Convert.ToDecimal(lblPlantCapacitySecondYear.Text) * Convert.ToDecimal(lblUnitGenerationSecondYear.Text)).ToString();
                decimal TotalGenerationSecondYear = Convert.ToDecimal(lblTotalGenerationSecondYear.Text);
                decimal unitper = 0.03m;
                decimal unitratediff = unitper * Convert.ToDecimal(UnitRateFY);
                decimal Unitdiff = unitratediff + Convert.ToDecimal(UnitRateFY);
                lblUnitRateSY.Text = Unitdiff.ToString();
                decimal UnitRateSY = Convert.ToDecimal(lblUnitRateSY.Text);
                decimal TotalSavingSecondYear = TotalGenerationSecondYear * Convert.ToDecimal(lblUnitRateSY.Text);

                lblTotalSavingSecondYear.Text = string.Format("{0:0}", TotalSavingSecondYear);

                decimal UnitGenerationSecondYear = Convert.ToDecimal(lblUnitGenerationSecondYear.Text);
                decimal diff1 = UnitGenerationSecondYear / 100;
                decimal cal1 = UnitGenerationSecondYear - diff1;

                lblUnitGenerationThiredYear.Text = string.Format("{0:0}", cal1);
                lblTotalGenerationThiredYear.Text = (Convert.ToDecimal(lblPlantCapacityThiredYear.Text) * Convert.ToDecimal(lblUnitGenerationThiredYear.Text)).ToString();
                decimal TotalGenerationThiredYear = Convert.ToDecimal(lblTotalGenerationThiredYear.Text);
                decimal unitratediff1 = unitper * Convert.ToDecimal(UnitRateSY);
                decimal Unitdiff1 = unitratediff1 + Convert.ToDecimal(UnitRateSY);
                lblUnitRateTY.Text = string.Format("{0:0.00}", Unitdiff1);
                decimal TotalSavingThiredYear = TotalGenerationThiredYear * Convert.ToDecimal(lblUnitRateTY.Text);
                lblTotalSavingThiredYear.Text = string.Format("{0:0}", TotalSavingThiredYear);
                decimal TotalSaving = TotalSavingFirstYear + TotalSavingSecondYear + TotalSavingThiredYear;
                lblTotalSaving.Text = string.Format("{0:0}", TotalSaving);
                decimal InstalledCapacity = Convert.ToDecimal(lblInstalledCapacity.Text);
                lblValue.Text = (Convert.ToDecimal(lblInstalledCapacity.Text) * Convert.ToDecimal(lblRate.Text)).ToString();
                decimal Value = Convert.ToDecimal(lblValue.Text);
                lblTotalValue.Text = Convert.ToDecimal(Value).ToString();

            }




        }
    }
}
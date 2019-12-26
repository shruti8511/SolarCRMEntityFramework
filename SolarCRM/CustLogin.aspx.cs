using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SolarCRM.Entity.Models.ProjectModule;
using SolarCRM.BAL.Implementations.ProjectModule;

namespace SolarCRM
{
    public partial class CustLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {


            List<ProjectsEntity> lstEntity = new List<ProjectsEntity>();
            string ProjectNumber = "";
            ProjectsEntity objrole = ProjectsManagement.tblProjects_SelectCustLogin(Convert.ToInt64(txtProjNum.Text.Trim()));


            if (objrole.InstallPostCode.ToString() == txtPCode.Text.Trim())
            {
                Session["user"] = objrole.CustomerName.ToString();
                Response.Redirect("~/Customer/CustomerDashboard.aspx?ProjectID=" + objrole.ProjectID.ToString());

            }
            else
            {
                Session["user"] = "";

            }

        }
    }
}
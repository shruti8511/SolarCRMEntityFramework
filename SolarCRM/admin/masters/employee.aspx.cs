using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SolarCRM.Entity.Models.MastersModule;
using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.PagingUserControl;
using SolarCRM.Entity.Models.Common;
using System.Web.Security;
using System.Globalization;

namespace SolarCRM.admin.masters
{
    public partial class employee : System.Web.UI.Page
    {
        protected string SiteURL;

        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;
            if (!IsPostBack)
            {

                designer.Visible = false;
                electrician.Visible = false;
                Session["PageNo"] = 1;
                Session["PageSize"] = 10;
                 string HostName = System.Net.Dns.GetHostName();
                 System.Net.IPHostEntry myIPs = System.Net.Dns.GetHostEntry(HostName);
                 string asd = myIPs.HostName;
                string  IPAddres = System.Net.Dns.GetHostAddresses(HostName).GetValue(1).ToString();
                string ip1 = System.Net.Dns.GetHostAddresses("www.google.com").GetValue(0).ToString();
                ProjectCount lst = new ProjectCount();
                lst = EmployeeManagement.tblEmployees_Count();
                long total = lst.Total;
                EmployeeTypeDropDownList();
                EmployeeStatusDropDownList();
                CompanyLocationsDropDownList();
                SalesTeamDropDownList();
                BindRole();
                BindEmployee();
            }
        }

        public void EmployeeTypeDropDownList()
        {
            List<EmployeeEntity> lstEntity = new List<EmployeeEntity>();
            lstEntity = EmployeeManagement.tblEmployeeType_SelectForDropdown();
            ddlEmployeeType.DataSource = lstEntity;
            ddlEmployeeType.DataTextField = "EmployeeType";
            ddlEmployeeType.DataValueField = "EmployeeTypeID";
            ddlEmployeeType.DataBind();
            ddlEmployeeType.Items.Insert(0, new ListItem("Select", "0"));

        }

        public void EmployeeStatusDropDownList()
        {
            List<EmployeeEntity> lstEntity = new List<EmployeeEntity>();
            lstEntity = EmployeeManagement.tblEmployeeStatus_SelectForDropdown();
            ddlEmployeeStatusID.DataSource = lstEntity;
            ddlEmployeeStatusID.DataTextField = "EmployeeStatus";
            ddlEmployeeStatusID.DataValueField = "EmployeeStatusID";
            ddlEmployeeStatusID.DataBind();
            ddlEmployeeStatusID.Items.Insert(0, new ListItem("Select", "0"));

        }

        public void CompanyLocationsDropDownList()
        {
            List<EmployeeEntity> lstEntity = new List<EmployeeEntity>();
            lstEntity = EmployeeManagement.tblCompanyLocations_ForDropdown();
            ddlLocation.DataSource = lstEntity;
            ddlLocation.DataTextField = "CompanyLocation";
            ddlLocation.DataValueField = "CompanyLocationID";
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new ListItem("Select", "0"));

        }

        public void SalesTeamDropDownList()
        {
            List<EmployeeEntity> lstEntity = new List<EmployeeEntity>();
            lstEntity = EmployeeManagement.tblSalesTeam_ForDropdown();
            ddlSalesTeamID.DataSource = lstEntity;
            ddlSalesTeamID.DataTextField = "SalesTeam";
            ddlSalesTeamID.DataValueField = "SalesTeamID";
            ddlSalesTeamID.DataBind();
            ddlSalesTeamID.Items.Insert(0, new ListItem("Select", "0"));

        }

        public void BindRole()
        {
            List<EmployeeEntity> lstEntity = new List<EmployeeEntity>();
            lstEntity = EmployeeManagement.SpRolesGetDataByAsc();
            lstRole.DataSource = lstEntity;
            lstRole.DataMember = "RoleName";
            lstRole.DataTextField = "RoleName";
            lstRole.DataValueField = "RoleName";
            lstRole.DataBind();
        }

        private void BindEmployee()
        {
            try
            {
                Session["pager"] = 0;
                PagingEntity objCommon = new PagingEntity();
                objCommon.PageNo = Convert.ToInt32(Session["PageNo"]);
                objCommon.PageSize = Convert.ToInt32(Session["PageSize"]);
                int Count = 0;
                List<EmployeeEntity> lstEntity = new List<EmployeeEntity>();
                lstEntity = EmployeeManagement.tblEmployeesGetDataBySearch(objCommon, out Count);
                rptEmployee.DataSource = lstEntity;
                rptEmployee.DataBind();
                pageGrid.BindPageing(Count);

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }

        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            BindEmployee();
            
            //if (Convert.ToInt32(Session["pager"]) == 1)
            //{
            //    bindsearch();
            //}
            //else
            //{
            //    BindAmount();
            //}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeEntity objEntity = new EmployeeEntity();

                //int Exist = EmployeeManagement.aspnet_Users_Exists(txtUserName.Text.Trim());
                //if (Exist == 0)
                //{

                objEntity.username = txtUserName.Text.Trim();
                objEntity.UserPassword = txtConfirmPassword.Text.Trim();
                objEntity.EmpFirst = txtEmpFirst.Text.Trim();
                objEntity.EmpLast = txtEmpLast.Text.Trim();
                objEntity.EmpTitle = txtEmpTitle.Text.Trim();
                objEntity.EmpEmail = txtEmpEmail.Text.Trim();
                objEntity.EmpMobile = txtEmpMobile.Text.Trim();
                objEntity.EmpNicName = txtEmpNicName.Text.Trim();
                objEntity.SalesTeamID = Convert.ToInt32(ddlSalesTeamID.SelectedValue);
                objEntity.EmployeeTypeID = Convert.ToInt32(ddlEmployeeType.SelectedValue);

                objEntity.EmpInitials = txtEmpInitials.Text.Trim();

                objEntity.LTeamOutDoor = chkTeamOutDoor.Checked;
                objEntity.LTeamCloser = chkTeamCloser.Checked;

               // objEntity.HireDate = Convert.ToDateTime(txtHireDate.Text.Trim());
                objEntity.HireDate = Convert.ToDateTime(txtHireDate.Text, new CultureInfo("en-US"));

                objEntity.EmployeeStatusID = Convert.ToInt32(ddlEmployeeStatusID.SelectedValue);
                objEntity.CompanyLocationID = Convert.ToInt32(ddlLocation.SelectedValue);
                objEntity.TaxFileNumber = txtTaxFileNumber.Text.Trim();
                objEntity.EmpABN = txtEmpPAN.Text.Trim();
                objEntity.EmpAccountName = txtEmpBank.Text.Trim();
                objEntity.ActiveEmp = chkActiveEmp.Checked;

                objEntity.StartTime = txtStartTime.Text;
              //  objEntity.StartTime = Convert.ToDateTime(txtStartTime.Text, new CultureInfo("en-US"));
                objEntity.IsDesigner = chkIsDesigner.Checked;
                objEntity.IsElectrician = chkIsElectrician.Checked;
                objEntity.Include = chkInclude.Checked;
                objEntity.EndTime = txtEndTime.Text;
                objEntity.OnRoster = chkOnRoster.Checked;
                objEntity.BreakTime = txtBreakTime.Text;
                objEntity.PaysOwnSuper = chkPaysOwnSuper.Checked;
                objEntity.GSTPayment = chkTDSPayment.Checked;
                objEntity.EmpInfo = txtEmpInfo.Text;
                objEntity.SalesRep = false;
                objEntity.AdminStaff = false;


                objEntity.ExecAccess = false;
                objEntity.AdminAccess = false;
                objEntity.DeleteAccess = false;
                objEntity.ProjDispAccess = false;
                objEntity.ManagerAccess = false;
                objEntity.AdminPL = false;
                objEntity.BillsOwingPL = false;
                objEntity.BillsPaidPL = false;
                objEntity.BookingsPL = false;
                objEntity.CompaniesPL = false;
                objEntity.ContactsPL = false;
                objEntity.FollowUpPL = false;
                objEntity.InvIssuedPL = false;
                objEntity.InvPaidPL = false;
                objEntity.MeetingsPL = false;
                objEntity.ProjectsPL = false;
                objEntity.StatisticsPL = false;
                objEntity.StockItemsPL = false;
                objEntity.StockOrdersPL = false;
                objEntity.SuperTaxPL = false;
                objEntity.WagesPL = false;
                objEntity.WholesalePL = false;
                foreach (ListItem itemval in lstRole.Items)
                {
                    if (lstRole.SelectedIndex == 7)
                    {
                        objEntity.IsInstaller = true;
                    }
                    else
                    {
                        objEntity.IsInstaller = false;
                    }
                }

                int Exist = EmployeeManagement.aspnet_Users_Exists(objEntity.username);
                if (Exist == 0)
                {

                    Membership.CreateUser(objEntity.username, objEntity.UserPassword, objEntity.EmpEmail);
                    string userid = Membership.GetUser(objEntity.username).ProviderUserKey.ToString();
                   
                    long Success = EmployeeManagement.tblEmployees_Insert(objEntity);
                    EmployeeManagement.tblEmployees_Update_Userid(Success, Membership.GetUser(objEntity.username).ProviderUserKey.ToString());
                    EmployeeManagement.tblEmployees_Update_Team(Success, ddlSalesTeamID.SelectedValue, ddlEmployeeType.SelectedValue, chkTeamOutDoor.Checked, chkTeamCloser.Checked);

                    foreach (ListItem itemval in lstRole.Items)
                    {
                        if (itemval.Selected)
                        {
                            //Roles.CreateRole("Call Center");
                            Roles.AddUserToRole(objEntity.username, itemval.Value);
                        }
                    }

                    //--- do not chage this code start------
                    //if (Convert.ToString(Success) != "")
                    //{
                    //    SetAdd();
                    //}
                    //else
                    //{
                    //    SetError();
                    //}
                    BindEmployee();

                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Users Added Successfully";

                    Reset();
                }

                else
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    lblErrorMsg.Text = "Users Already Exist.";
                    // txtProjectType.Text = "";
                    // txtProjectType.Focus();
                    //BindProjectType();
                    //Reset();
                }

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;
            }
        }


        private void Reset()
        {
            txtUserName.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtEmpFirst.Text = string.Empty;
            txtEmpLast.Text = string.Empty;
            txtEmpTitle.Text = string.Empty;
            txtEmpEmail.Text = string.Empty;
            txtEmpMobile.Text = string.Empty;
            txtEmpNicName.Text = string.Empty;
            ddlSalesTeamID.SelectedIndex = 0;
            ddlEmployeeType.SelectedIndex = 0;
            chkTeamOutDoor.Checked = true;
            chkTeamCloser.Checked = true;
            txtHireDate.Text = string.Empty;
            ddlEmployeeStatusID.SelectedIndex = 0;
            ddlLocation.SelectedIndex = 0;
            txtTaxFileNumber.Text = string.Empty;
            txtEmpPAN.Text = string.Empty;
            txtEmpBank.Text = string.Empty;
            chkActiveEmp.Checked = true;
            txtStartTime.Text = string.Empty;
            chkInclude.Checked = true;
            txtEndTime.Text = string.Empty;
            chkOnRoster.Checked = true;
            txtBreakTime.Text = string.Empty;
            chkPaysOwnSuper.Checked = true;
            chkTDSPayment.Checked = true;
            txtEmpInfo.Text = string.Empty;
            //btnUpdate.Visible = false;
            btnSave.Visible = true;

        }

        protected void btnalert_Click(object sender, EventArgs e)
        {
            divAlert.Visible = false;
        }

        protected void btnSuccess_Click(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
        }

        protected void rptEmployee_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Detail")
            {
                try
                {
                    divEmployeeDetails.Visible = true;
                    divEmployee.Visible = false;
                    int EmployeeID = Convert.ToInt32(e.CommandArgument);
                    BindEmployeeDetails(EmployeeID);
                    BindPermissions(EmployeeID);
                    BindEmployeeReferences(EmployeeID);

                }
                catch (Exception ex)
                {
                    divSuccess.Visible = false;
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "Error : " + ex.Message;
                }
            }


            else if (e.CommandName.ToString() == "Reset")
            {
                try
                {
                    int EmployeeID =  Convert.ToInt32(e.CommandArgument);
                    var Emp = EmployeeManagement.tblEmployees_SelectByyEmployeeID(EmployeeID);
                    Random random = new Random();
                    string Password = Convert.ToString(random.Next(000000, 999999));
                    bool Success = EmployeeManagement.tblEmployees_UpdatePassword(Emp.userid, Password);

                    //if (Success)
                    //{
                    //    string from = ClsAdminUtilities.StUtilitiesGetDataStructById("1").from.ToString();
                    //    TextWriter txtWriter = new StringWriter() as TextWriter;

                    //    Server.Execute("~/mailtemplate/resetpassword.aspx?username=" + stEmp.username + "&password=" + Password, txtWriter);
                    //    try
                    //    {
                    //        Utilities.SendMail(from, stEmp.EmpEmail, "Reset Password", txtWriter.ToString());
                    //    }
                    //    catch
                    //    {
                    //    }
                    //}

                   // EmployeeManagement.tblEmployees_UpdatePassword(Emp.userid, Password);                    
                    //BindBillTo();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Password Updated Successfully";
                }
                catch (Exception ex)
                {
                    divSuccess.Visible = false;
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "Error : " + ex.Message;
                }
            }

        }

        public void BindEmployeeDetails(int EmployeeID)
        {
            var lstEntity = EmployeeManagement.tblEmployees_SelectByyEmployeeID(EmployeeID);

            //hdnlblCustomerID.Value = lstEntity.CustomerID.ToString();
            //hdnlblEmployeeID.Value = lstEntity.EmployeeID.ToString();

            List<EmployeeEntity> lstEntity1 = new List<EmployeeEntity>();
            lstEntity1 = EmployeeManagement.tblEmployeeStatus_SelectForDropdown();
            ddlEmpStatus.DataSource = lstEntity1;
            ddlEmpStatus.DataTextField = "EmployeeStatus";
            ddlEmpStatus.DataValueField = "EmployeeStatusID";
            ddlEmpStatus.DataBind();
            ddlEmpStatus.Items.Insert(0, new ListItem("Select", "0"));

            List<EmployeeEntity> lstEntity2 = new List<EmployeeEntity>();
            lstEntity2 = EmployeeManagement.tblCompanyLocations_ForDropdown();
            ddlLocationID.DataSource = lstEntity2;
            ddlLocationID.DataTextField = "CompanyLocation";
            ddlLocationID.DataValueField = "CompanyLocationID";
            ddlLocationID.DataBind();
            ddlLocationID.Items.Insert(0, new ListItem("Select", "0"));

            hdnEmployeeID.Value = lstEntity.EmployeeID.ToString();
            txtFirstName.Text = lstEntity.EmpFirst;
            txtLastName.Text = lstEntity.EmpLast;
            txtTitle.Text = lstEntity.EmpTitle;
            txtNicName.Text = lstEntity.EmpNicName;
            txtInitials.Text = lstEntity.EmpInitials;
            txtEmail.Text = lstEntity.EmpEmail;
            txtMobile.Text = lstEntity.EmpMobile;
            ddlEmpStatus.SelectedValue = lstEntity.EmployeeStatusID.ToString();
            ddlLocationID.SelectedValue = lstEntity.CompanyLocationID.ToString();
            txtDateHired.Text = lstEntity.HireDate.ToString("MM/dd/yyyy");

            //txtSTime.Text = lstEntity.HireDate.ToString("HH:mm tt");
            txtSTime.Text = lstEntity.StartTime;
            txtETime.Text = lstEntity.EndTime;
            txtBTime.Text = lstEntity.BreakTime;
            chkActive.Checked = lstEntity.ActiveEmp;
            chkIncludeList.Checked = lstEntity.Include;
            chkRoster.Checked = lstEntity.OnRoster;
            txtInfo.Text = lstEntity.EmpInfo;
        }

        protected void btnUpdateDetails_Click(object sender, EventArgs e)
        {
            try
            {
                //var lstEntity = CompanySourceSubManagement.tblCompanySourceSub_SelectForUpdate(txtCompanySourceSub.Text.Trim(), chkActive.Checked);
                //if (lstEntity.CompanySourceSub != null)
                //{
                //    if (txtCompanySourceSub.Text.Trim() == lstEntity.CompanySourceSub && chkActive.Checked == lstEntity.Active)
                //    {
                //        divSuccess.Visible = false;
                //        divAlert.Visible = true;
                //        lblErrorMsg.Text = "Company Source Sub Already Exist.";
                //        Reset();
                //        // txtWatchDialColor.Focus();
                //    }
                //}
                // else
                {
                    EmployeeEntity ObjEntity = new EmployeeEntity();
                    ObjEntity.EmployeeID = Convert.ToInt32(hdnEmployeeID.Value);
                    ObjEntity.EmpTitle = txtTitle.Text.Trim();
                    ObjEntity.EmpFirst = txtFirstName.Text.Trim();
                    ObjEntity.EmpLast = txtLastName.Text.Trim();
                    ObjEntity.EmpNicName = txtNicName.Text.Trim();
                    ObjEntity.EmpInitials = txtInitials.Text.Trim();
                    ObjEntity.EmpEmail = txtEmail.Text.Trim();
                    ObjEntity.EmpMobile = txtMobile.Text.Trim();
                    ObjEntity.EmployeeStatusID = Convert.ToInt32(ddlEmpStatus.SelectedValue);
                    ObjEntity.CompanyLocationID = Convert.ToInt32(ddlLocationID.SelectedValue);
                    ObjEntity.HireDate = Convert.ToDateTime(txtDateHired.Text, new CultureInfo("en-US"));

                 //   ObjEntity.StartTime = Convert.ToDateTime(txtSTime.Text, new CultureInfo("en-US"));

                    ObjEntity.StartTime = txtSTime.Text.Trim();
                    ObjEntity.EndTime = txtETime.Text.Trim();
                    ObjEntity.BreakTime = txtBTime.Text.Trim();
                    ObjEntity.ActiveEmp = chkActive.Checked;
                    ObjEntity.Include = chkIncludeList.Checked;
                    ObjEntity.OnRoster = chkRoster.Checked;
                    ObjEntity.EmpInfo = txtInfo.Text.Trim();
                    ObjEntity.IsElectrician = chkIsElectrician.Checked;
                    ObjEntity.IsDesigner = chkIsDesigner.Checked;
                    EmployeeManagement.tblEmployees_Update(ObjEntity);
                    //BindCompanySourceSub();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Employee Detail Updated Successfully";
                    //Reset();
                    //btnUpdate.Visible = false;
                    //btnSave.Visible = true;
                }
            }
            catch (Exception ex)
            {
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;

            }
        }

        protected void btnCancelDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/masters/employee.aspx");

        }

        public void BindPermissions(int EmployeeID)
        {

            var lstEntity = EmployeeManagement.tblEmployees_SelectByyEmployeeID(EmployeeID);

            List<EmployeeEntity> lstEntity1 = new List<EmployeeEntity>();

            hdnEmployeeID.Value = lstEntity.EmployeeID.ToString();
            chkAdminPL.Checked = lstEntity.AdminPL;
            chkInvIssuedPL.Checked = lstEntity.InvIssuedPL;
            chkSuperTaxPL.Checked = lstEntity.SuperTaxPL;
            chkExecAccess.Checked = lstEntity.ExecAccess;
            chkBookingsPL.Checked = lstEntity.BookingsPL;
            chkInvPaidPL.Checked = lstEntity.InvPaidPL;
            chkWagesPL.Checked = lstEntity.WagesPL;
            chkDeleteAccess.Checked = lstEntity.DeleteAccess;
            chkCompaniesPL.Checked = lstEntity.CompaniesPL;
            chkProjectsPL.Checked = lstEntity.ProjectsPL;
            chkWholesalePL.Checked = lstEntity.WholesalePL;
            chkAdminAccess.Checked = lstEntity.AdminAccess;
            chkContactsPL.Checked = lstEntity.ContactsPL;
            chkStockItemsPL.Checked = lstEntity.StockItemsPL;
            chkBillsOwingPL.Checked = lstEntity.BillsOwingPL;
            chkProjDispAccess.Checked = lstEntity.ProjDispAccess;
            chkStockOrdersPL.Checked = lstEntity.StockOrdersPL;
            chkFollowUpPL.Checked = lstEntity.FollowUpPL;
            chkBillsPaidPL.Checked = lstEntity.BillsPaidPL;
            chkManagerAccess.Checked = lstEntity.ManagerAccess;

        }

        protected void btnUpdatePermissions_Click(object sender, EventArgs e)
        {
            try
            {
                //var lstEntity = CompanySourceSubManagement.tblCompanySourceSub_SelectForUpdate(txtCompanySourceSub.Text.Trim(), chkActive.Checked);
                //if (lstEntity.CompanySourceSub != null)
                //{
                //    if (txtCompanySourceSub.Text.Trim() == lstEntity.CompanySourceSub && chkActive.Checked == lstEntity.Active)
                //    {
                //        divSuccess.Visible = false;
                //        divAlert.Visible = true;
                //        lblErrorMsg.Text = "Company Source Sub Already Exist.";
                //        Reset();
                //        // txtWatchDialColor.Focus();
                //    }
                //}
                // else
                {
                    EmployeeEntity ObjEntity = new EmployeeEntity();
                    ObjEntity.EmployeeID = Convert.ToInt32(hdnEmployeeID.Value);
                    ObjEntity.AdminPL = chkAdminPL.Checked;
                    ObjEntity.InvIssuedPL = chkInvIssuedPL.Checked;
                    ObjEntity.SuperTaxPL = chkSuperTaxPL.Checked;
                    ObjEntity.ExecAccess = chkExecAccess.Checked;
                    ObjEntity.BookingsPL = chkBookingsPL.Checked;
                    ObjEntity.InvPaidPL = chkInvPaidPL.Checked;
                    ObjEntity.WagesPL = chkWagesPL.Checked;
                    ObjEntity.DeleteAccess = chkDeleteAccess.Checked;
                    ObjEntity.CompaniesPL = chkCompaniesPL.Checked;
                    ObjEntity.ProjectsPL = chkProjectsPL.Checked;
                    ObjEntity.WholesalePL = chkWholesalePL.Checked;
                    ObjEntity.AdminAccess = chkAdminAccess.Checked;
                    ObjEntity.ContactsPL = chkContactsPL.Checked;
                    ObjEntity.StockItemsPL = chkStockItemsPL.Checked;
                    ObjEntity.BillsOwingPL = chkBillsOwingPL.Checked;
                    ObjEntity.ProjDispAccess = chkProjDispAccess.Checked;
                    ObjEntity.StockOrdersPL = chkStockOrdersPL.Checked;
                    ObjEntity.FollowUpPL = chkFollowUpPL.Checked;
                    ObjEntity.BillsPaidPL = chkBillsPaidPL.Checked;
                    ObjEntity.ManagerAccess = chkManagerAccess.Checked;

                    EmployeeManagement.tblEmployees_UpdatePermissions(ObjEntity);
                    //BindCompanySourceSub();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Employee Permissions Updated Successfully";
                    //Reset();
                    //btnUpdate.Visible = false;
                    //btnSave.Visible = true;
                }
            }
            catch (Exception ex)
            {
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;

            }
        }

        protected void btnCancelPermissions_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/masters/employee.aspx");
        }

        public void BindEmployeeReferences(int EmployeeID)
        {

            var lstEntity = EmployeeManagement.tblEmployees_SelectByyEmployeeID(EmployeeID);

            List<EmployeeEntity> lstEntity1 = new List<EmployeeEntity>();

            hdnEmployeeID.Value = lstEntity.EmployeeID.ToString();
            txtTaxFileNo.Text = lstEntity.TaxFileNumber;
            txtSuperFund.Text = lstEntity.SuperFund;
            txtSuperFundAccount.Text = lstEntity.SuperFundAccount;
            txtEmpBSB.Text = lstEntity.EmpBSB;
            txtEmpBankAcct.Text = lstEntity.EmpBankAcct;
            txtInitialSalesQuota.Text = lstEntity.InitialSalesQuota.ToString();
            txtEmpAddress.Text = lstEntity.EmpAddress;
            txtEmpCity.Text = lstEntity.EmpCity;
            txtEmpState.Text = lstEntity.EmpState;
            txtEmpPostCode.Text = lstEntity.EmpPostCode;
            chkAdminStaff.Checked = lstEntity.AdminStaff;
            chkSalesRep.Checked = lstEntity.SalesRep;

        }

        protected void btnEmployeeReferences_Click(object sender, EventArgs e)
        {
            try
            {
                //var lstEntity = CompanySourceSubManagement.tblCompanySourceSub_SelectForUpdate(txtCompanySourceSub.Text.Trim(), chkActive.Checked);
                //if (lstEntity.CompanySourceSub != null)
                //{
                //    if (txtCompanySourceSub.Text.Trim() == lstEntity.CompanySourceSub && chkActive.Checked == lstEntity.Active)
                //    {
                //        divSuccess.Visible = false;
                //        divAlert.Visible = true;
                //        lblErrorMsg.Text = "Company Source Sub Already Exist.";
                //        Reset();
                //        // txtWatchDialColor.Focus();
                //    }
                //}
                // else
                {
                    EmployeeEntity ObjEntity = new EmployeeEntity();
                    ObjEntity.EmployeeID = Convert.ToInt32(hdnEmployeeID.Value);
                    ObjEntity.TaxFileNumber = txtTaxFileNo.Text.Trim();
                    ObjEntity.SuperFund = txtSuperFund.Text.Trim();
                    ObjEntity.SuperFundAccount = txtSuperFundAccount.Text.Trim();
                    ObjEntity.EmpBSB = txtEmpBSB.Text.Trim();
                    ObjEntity.EmpBankAcct = txtEmpBankAcct.Text.Trim();
                    ObjEntity.InitialSalesQuota =Convert.ToDecimal(txtInitialSalesQuota.Text.Trim());
                    ObjEntity.EmpAddress = txtEmpAddress.Text.Trim();
                    ObjEntity.EmpCity = txtEmpCity.Text.Trim();
                    ObjEntity.EmpState = txtEmpState.Text.Trim();
                    ObjEntity.EmpPostCode = txtEmpPostCode.Text.Trim();
                    ObjEntity.AdminStaff = chkAdminStaff.Checked;
                    ObjEntity.SalesRep = chkSalesRep.Checked;


                    EmployeeManagement.tblEmployees_UpdateReferences(ObjEntity);
                    //BindCompanySourceSub();
                    divSuccess.Visible = true;
                    divAlert.Visible = false;
                    lblSuccessMsg.Text = "Employee References Updated Successfully";
                    //Reset();
                    //btnUpdate.Visible = false;
                    //btnSave.Visible = true;
                }
            }
            catch (Exception ex)
            {
                divAlert.Visible = true;
                lblErrorMsg.Text = "Error : " + ex.Message;

            }
        }

        protected void btnCancelReferences_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/masters/employee.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/masters/employee.aspx");
        }

        protected void lstRole_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            string curItem = lstRole.SelectedItem.ToString();

            foreach (ListItem itemval in lstRole.Items)
            {
                if (lstRole.SelectedIndex == 7)
                {
                    designer.Visible = true;
                    electrician.Visible = true;
                }
                else 
                {
                    designer.Visible = false;
                    electrician.Visible = false;
                }
            }
          
        }

        protected void pageGrid_PagerChanged()
        {

        }

       

    }
}
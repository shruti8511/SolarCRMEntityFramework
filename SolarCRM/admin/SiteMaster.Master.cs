using SolarCRM.BAL.Implementations.LoginModule;
using SolarCRM.BAL.Implementations.MastersModule;
using SolarCRM.Entity.Models.EmployeeModule;
using SolarCRM.Entity.Models.LoginModule;
using SolarCRM.Entity.Models.MastersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolarCRM
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected string SiteURL;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteURL = HttpContext.Current.Request.Url.Authority;
            SiteURL = "http://" + SiteURL;
            if (Roles.IsUserInRole("DSalesRep") || Roles.IsUserInRole("SalesRep"))
            {
                lidashboardinstaller.Visible = false;
                lidashboard.Visible = false;
               // limaster.Visible = false;
                //liinstallations.Visible = false;
               // licontacts.Visible = false;
                //liinvoice.Visible = false;
                //liinvoicepaid.Visible = false;
                //listockitem.Visible = false;
                //lifollowups.Visible = false;
                //litracker.Visible = false;
              //  lilead.Visible = false;
               // limaintenance.Visible = false;
             

            }
            else if (Roles.IsUserInRole("Accountant"))
            {
                lidashboardinstaller.Visible = false;
                lidashboard2.Visible = false;
                //limaster.Visible = false;
                //licontacts.Visible = false;
                //liinvoice.Visible = false;
                //liinvoicepaid.Visible = false;
                listockitem.Visible = false;
                //lifollowups.Visible = false;
                //litracker.Visible = false;
               // lilead.Visible = false;
               // limaintenance.Visible = false;
                lireports.Visible = false;
            }
            else if (Roles.IsUserInRole("Installation Manager"))
            {
                lidashboardinstaller.Visible = false;
                lidashboard2.Visible = false;
               // limaster.Visible = false;
              //  licontacts.Visible = false;
              //  lileadtracker.Visible = false;
              //  lifollowups.Visible = false;
               // lilead.Visible = false;
            }
            else if (Roles.IsUserInRole("Installer"))
            {
                lidashboard.Visible = false;
                lidashboard2.Visible = false;
               // limaster.Visible = false;
                licompany.Visible = false;
              //  lileadtracker.Visible = false;
                liprojects.Visible = false;
              //  liinstallations.Visible = false;
              //  liinvoice.Visible = false;
               // liinvoicepaid.Visible = false;
               // lifollowups.Visible = false;
              //  lilead.Visible = false;
                lireports.Visible = false;
                listockitem.Visible = false;
              //  limaintenance.Visible = false;
            }
          
            else
            {
                lidashboardinstaller.Visible = false;
                lidashboard2.Visible = false;
            }
            if (Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Customer") || Roles.IsUserInRole("Accountant") || Roles.IsUserInRole("Installer") || Roles.IsUserInRole("DSalesRep") || Roles.IsUserInRole("Installation Manager"))
            {
              
            }
            else
            {
                if (Session["userid"] != "" && Session["userid"] != null)
                {
                    string userid = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
                    EmployeeEntity stEmp = EmployeeManagement.tblEmployees_SelectByUserId(userid);
                    // SttblContacts stCont = ClstblContacts.tblContacts_StructByUserId(userid);
                    string StartTime = "";
                    string EndTime = "";

                    if (Roles.IsUserInRole("Installer"))
                    {
                       
                        //StartTime = stCont.StartTime;
                        //EndTime = stCont.EndTime;
                    }
                    else
                    {
                        StartTime = stEmp.StartTime;
                        EndTime = stEmp.EndTime;

                        string CurTime = DateTime.Now.AddHours(0).ToString("HH:mm:ss");
                        if (StartTime != string.Empty && EndTime != string.Empty)
                        {
                            if (Convert.ToDateTime(CurTime) >= Convert.ToDateTime(StartTime) && Convert.ToDateTime(CurTime) <= Convert.ToDateTime(EndTime))
                            {

                            }
                            else
                            {
                                Response.Redirect(SiteURL + "/login.aspx?success=false");
                            }
                        }
                    }


                    string UserId = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
                    AspnetUserEntity objemp = EmployeeManagement.aspnet_Users_SelectByUserId(UserId);

                    string LogInTime = DateTime.Now.ToUniversalTime().ToString();
                    //string LastActivityDate = dtU.Rows[0]["LastActivityDate"].ToString();

                    if (objemp != null)
                    {
                        TimeSpan span = Convert.ToDateTime(LogInTime).Subtract(Convert.ToDateTime(objemp.LastActivityDate));
                        int totalMins = Convert.ToInt32(span.TotalMinutes);

                        if (totalMins > 30)
                        {
                            string LogOutTime = DateTime.Now.AddHours(0).ToString();
                            string IPAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();

                            LogInTrackEntity Objlogin = LoginManagement.tblLogInTrack_Select(UserId, IPAddress);
                            if (Objlogin != null)
                            {
                                //string Id = dt.Rows[0]["ID"].ToString();
                                LoginManagement.tblLogInTrack_Update(Objlogin.ID, LogOutTime, "True");
                            }
                            Session.Abandon();
                            Response.Redirect(SiteURL + "/login.aspx");
                        }
                        else
                        {
                            EmployeeManagement.aspnetUsers_Update_LastActivityDate(UserId);
                        }
                    }
                }
                else
                {
                    Response.Redirect("http://localhost:8084/login.aspx");
                }
               
            }
           
        }
    }
}
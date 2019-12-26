using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI;
using System.Web.UI.WebControls;
using SolarCRM.Entity.Models.ProjectModule;
using SolarCRM.BAL.Implementations.ProjectModule;
using SolarCRM.Entity.Models.CompanyModule;
using SolarCRM.BAL.Implementations.CompanyModule;

namespace SolarCRM.Customer
{
    public partial class CustomerDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ProjectID"] != null && Request.QueryString[""] != "")
            {
               ProjectsEntity st = ProjectsManagement.tblProjects_SelectByProjectID(Convert.ToInt64(Request.QueryString["ProjectID"]));
               CustomersEntity stcust = CustomersManagement.tblCustomers_SelectByCustomerID(st.CustomerID);

                if (Session["user"] == null || Session["user"] == "")
                {
                    Response.Redirect("~/CustLogin.aspx");
                }
                else
               {
                  // if (Session["user"].ToString().Trim() != stcust.FullName.Trim())
                  //  {
                  //      Response.Redirect("~/CustLogin.aspx");
                  //}
                }
                if (stcust.CustSource == "22")
                {
                    trd2d.Visible = true;
                    tdd2d.Visible = true;
                    d2dtxt.Visible = true;
                }
                else
                {
                    trd2d.Visible = false;
                    tdd2d.Visible = false;
                    d2dtxt.Visible = false;
                }
                if (st.InstallState == "NSW")
                {
                    tdnsw1.Visible = true;
                    tdnsw2.Visible = true;
                    tdnswtxt1.Visible = true;
                    tdnswtxt2.Visible = true;
                    trmtrinstbook.Visible = true;
                    trmtrinstcomp.Visible = true;
                    lblmat.Text = "3 to 4 Weeks";
                }
                else if (st.InstallState == "SA")
                {
                    tdnsw1.Visible = false;
                    tdnsw2.Visible = false;
                    tdnswtxt1.Visible = false;
                    tdnswtxt2.Visible = false;
                    trmtrinstbook.Visible = false;
                    trmtrinstcomp.Visible = false;
                    lblmat.Text = "1 to 2 Weeks";
                }
                else if (st.InstallState == "WA")
                {
                    tdnsw1.Visible = false;
                    tdnsw2.Visible = false;
                    tdnswtxt1.Visible = false;
                    tdnswtxt2.Visible = false;
                    trmtrinstbook.Visible = false;
                    trmtrinstcomp.Visible = false;
                    lblmat.Text = "4 to 5 Weeks";
                }
                else
                {
                    tdnsw1.Visible = false;
                    tdnsw2.Visible = false;
                    tdnswtxt1.Visible = false;
                    tdnswtxt2.Visible = false;
                    trmtrinstbook.Visible = false;
                    trmtrinstcomp.Visible = false;
                    lblmat.Text = "4 to 5 Weeks";
                }

                //lblcustname.Text = st.Customer;
                lblcusthdr.Text = stcust.FullName;

                if (!string.IsNullOrEmpty(st.SalesVerificationDate.ToString()))
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgvc.ImageUrl = "~/img/completed.png";
                            imgvc1.ImageUrl = "~/img/GreenNew.png";
                           // imgvc.ImageUrl = "~/img/greennew110.png";
                        }
                        else
                        {
                            //imgvc.ImageUrl = "~/img/completed.png";
                            imgvc1.ImageUrl = "~/img/GreenNew.png";
                           // imgvc.ImageUrl = "~/img/greennew130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                          //  imgvc.ImageUrl = "~/img/completed.png";
                            imgvc1.ImageUrl = "~/img/GreenNew.png";
                            //imgvc.ImageUrl = "~/img/greennew130.png";
                        }
                        else
                        {
                          //  imgvc.ImageUrl = "~/img/completed.png";
                            imgvc1.ImageUrl = "~/img/GreenNew.png";
                            //imgvc.ImageUrl = "~/img/greennew.png";
                        }
                    }
                    try
                    {
                        lblVeriCallDate.Text = Convert.ToDateTime(st.SalesVerificationDate).ToString("dd/MM/yyyy");
                    }
                    catch { }
                    lblverificationcall.Text = "Verification Done";
                    lblVeriCallDesc.Text = "Verification Done";
                    chkvericall.Checked = true;
                }
                else
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                            //imgvc.ImageUrl = "~/img/waiting.png";
                            imgvc1.ImageUrl = "~/img/GrayNew.png";
                           // imgvc.ImageUrl = "~/img/rednew3110.png";
                        }
                        else
                        {
                           // imgvc.ImageUrl = "~/img/waiting.png";
                            imgvc1.ImageUrl = "~/img/GrayNew.png";

                           // imgvc.ImageUrl = "~/img/rednew3130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                            //imgvc.ImageUrl = "~/img/waiting.png";
                            imgvc1.ImageUrl = "~/img/Graynew.png";

                           // imgvc.ImageUrl = "~/img/rednew3130.png";
                        }
                        else
                        {
                         //   imgvc.ImageUrl = "~/img/waiting.png";
                            imgvc1.ImageUrl = "~/img/GrayNew.png";

                           // imgvc.ImageUrl = "~/img/rednew3.png";
                        }
                    }
                    lblverificationcall.Text = "Please call on 1800 38 76 76 to complete verification";
                    lblVeriCallDesc.Text = "Please call on 1800 38 76 76 to complete verification";
                    lblVeriCallDate.Text = "";
                    chkvericall.Checked = false;
                }


                if (!string.IsNullOrEmpty(st.DepositReceived.ToString()))
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgoc.ImageUrl = "~/img/completed.png";
                            imggoc1.ImageUrl = "~/img/GreenNew.png";
                           // imgoc.ImageUrl = "~/img/greennew110.png";
                        }
                        else
                        {
                          //  imgoc.ImageUrl = "~/img/completed.png";
                            imggoc1.ImageUrl = "~/img/GreenNew.png";
                           // imgoc.ImageUrl = "~/img/greennew130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgoc.ImageUrl = "~/img/completed.png";
                            imggoc1.ImageUrl = "~/img/GreenNew.png";
                            //imgoc.ImageUrl = "~/img/greennew130.png";
                        }
                        else
                        {
                           // imgoc.ImageUrl = "~/img/completed.png";
                            imggoc1.ImageUrl = "~/img/GreenNew.png";
                         //   imgoc.ImageUrl = "~/img/greennew.png";
                        }
                    }
                    try
                    {
                        lblOrderConfDate.Text = Convert.ToDateTime(st.DepositReceived).ToString("dd/MM/yyyy");
                    }
                    catch { }
                    lblOrderConfDesc.Visible = true;
                    chkOrderConf.Checked = true;
                }
                else
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                          //  imgoc.ImageUrl = "~/img/waiting.png";
                            imggoc1.ImageUrl = "~/img/GrayNew.png";
                           // imgoc.ImageUrl = "~/img/rednew3110.png";
                        }
                        else
                        {
                           // imgoc.ImageUrl = "~/img/waiting.png";
                            imggoc1.ImageUrl = "~/img/GrayNew.png";
                            //imgoc.ImageUrl = "~/img/rednew3130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                            //imgoc.ImageUrl = "~/img/waiting.png";
                            imggoc1.ImageUrl = "~/img/GrayNew.png";
                           // imgoc.ImageUrl = "~/img/rednew3130.png";
                        }
                        else
                        {
                          //  imgoc.ImageUrl = "~/img/waiting.png";
                            imggoc1.ImageUrl = "~/img/GrayNew.png";
                          //  imgoc.ImageUrl = "~/img/rednew3.png";
                        }
                    }
                    lblOrderConfDesc.Visible = false;
                    lblOrderConfDate.Text = "";
                    chkOrderConf.Checked = false;
                }
                if (chkOrderConf.Checked == true)
                {
                    chkimgorderconf.Visible = true;
                    nchkimgorderconf.Visible = false;
                }
                else {
                    chkimgorderconf.Visible = false;
                    nchkimgorderconf.Visible = true;
                }
                if ((st.MeterBoxPhotosSaved.ToString().ToLower() == "true" || st.ElecBillSaved.ToString().ToLower() == "true" || st.SignedQuote.ToString().ToLower() == "true") && !string.IsNullOrEmpty(st.DepositReceived.ToString()))
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgdr.ImageUrl = "~/img/completed.png";
                            imgdr1.ImageUrl = "~/img/GreenNew.png";

                           // imgdr.ImageUrl = "~/img/greennew110.png";
                        }
                        else
                        {
                          //  imgdr.ImageUrl = "~/img/completed.png";
                            imgdr1.ImageUrl = "~/img/GreenNew.png";

                           // imgdr.ImageUrl = "~/img/greennew130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                          //  imgdr.ImageUrl = "~/img/completed.png";
                            imgdr1.ImageUrl = "~/img/GreenNew.png";
                            
                            //imgdr.ImageUrl = "~/img/greennew130.png";
                        }
                        else
                        {
                           // imgdr.ImageUrl = "~/img/completed.png";
                            imgdr1.ImageUrl = "~/img/GreenNew.png";

                           // imgdr.ImageUrl = "~/img/greennew.png";
                        }
                    }
                    try
                    {
                        lblDocRecDate.Text = Convert.ToDateTime(st.DepositReceived).ToString("dd/MM/yyyy");
                    }
                    catch { }
                    lblDocRecDesc.Visible = true;
                    chkMP.Visible = true;
                    lblSQ.Visible = true;
                    chkSQ.Visible = true;
                    lblEB.Visible = true;
                    chkEB.Visible = true;
                    chkDocRec.Checked = true;

                    if (st.MeterBoxPhotosSaved.ToString().ToLower() == "true")
                    {
                        chkMP.Checked = true;
                        chkimgMP.Visible = true;
                        nchkimgMP.Visible = false;
                    }
                    if (st.ElecBillSaved.ToString().ToLower() == "true")
                    {
                        chkEB.Checked = true;
                        chkimgEB.Visible = true;
                        nchkimgEB.Visible = false;
                    }
                    if (st.SignedQuote.ToString().ToLower() == "true")
                    {
                        chkSQ.Checked = true;
                        chkimgSQ.Visible = true;
                        nchkimgSQ.Visible = false;
                    }
                }
                else
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgdr.ImageUrl = "~/img/completed.png";
                            imgdr1.ImageUrl = "~/img/Green-New.png";

                           // imgdr.ImageUrl = "~/img/rednew3110.png";
                        }
                        else
                        {
                            //imgdr.ImageUrl = "~/img/waiting.png";
                            imgdr1.ImageUrl = "~/img/GrayNew.png";

                          //  imgdr.ImageUrl = "~/img/rednew3130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgdr.ImageUrl = "~/img/waiting.png";
                            imgdr1.ImageUrl = "~/img/GrayNew.png";

                           // imgdr.ImageUrl = "~/img/rednew3130.png";
                        }
                        else
                        {
                          //  imgdr.ImageUrl = "~/img/waiting.png";
                            imgdr1.ImageUrl = "~/img/GrayNew.png";
                            
                           // imgdr.ImageUrl = "~/img/rednew3.png";
                        }
                    }
                    lblDocRecDate.Text = "";
                    lblDocRecDesc.Visible = false;
                    chkMP.Visible = false;
                    lblSQ.Visible = false;
                    chkSQ.Visible = false;
                    lblEB.Visible = false;
                    chkEB.Visible = false;
                    chkDocRec.Checked = false;
                }
                if (chkDocRec.Checked == true)
                {
                    chkimgDocRec.Visible = true;
                    nchkimgDocRec.Visible = false;
                }
                else
                {
                    chkimgDocRec.Visible = false;
                    nchkimgDocRec.Visible = true;
                }
              
                if (!string.IsNullOrEmpty(st.MeterAppliedDate.ToString()))
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgma.ImageUrl = "~/img/completed.png";
                            imgma1.ImageUrl = "~/img/GreenNew.png";

                           // imgma.ImageUrl = "~/img/greennew110.png";
                        }
                        else
                        {
                           // imgma.ImageUrl = "~/img/completed.png";
                            imgma1.ImageUrl = "~/img/GreenNew.png";

                          //  imgma.ImageUrl = "~/img/greennew130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgma.ImageUrl = "~/img/completed.png";
                            imgma1.ImageUrl = "~/img/GreenNew.png";

                           // imgma.ImageUrl = "~/img/greennew130.png";
                        }
                        else
                        {
                           // imgma.ImageUrl = "~/img/completed.png";
                            imgma1.ImageUrl = "~/img/GreenNew.png";

                           // imgma.ImageUrl = "~/img/greennew.png";
                        }
                    }
                    try
                    {
                        lblMeterAppDate.Text = Convert.ToDateTime(st.MeterAppliedDate).ToString("dd/MM/yyyy");
                        lblMeterAppDesc.Visible = true;
                        chkMeterApp.Checked = true;
                    }
                    catch { }
                }
                else
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgma.ImageUrl = "~/img/waiting.png";
                            imgma1.ImageUrl = "~/img/GrayNew.png";

                           // imgma.ImageUrl = "~/img/rednew3110.png";
                        }
                        else
                        {
                           // imgma.ImageUrl = "~/img/waiting.png";
                            imgma1.ImageUrl = "~/img/GrayNew.png";

                           // imgma.ImageUrl = "~/img/rednew3130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgma.ImageUrl = "~/img/waiting.png";
                            imgma1.ImageUrl = "~/img/GrayNew.png";

                          //  imgma.ImageUrl = "~/img/rednew3130.png";
                        }
                        else
                        {
                            //imgma.ImageUrl = "~/img/waiting.png";
                            imgma1.ImageUrl = "~/img/GrayNew.png";

                           // imgma.ImageUrl = "~/img/rednew3.png";
                        }
                    }
                    lblMeterAppDate.Text = "";
                    lblMeterAppDesc.Visible = false;
                    chkMeterApp.Checked = false;
                }
                if (chkMeterApp.Checked == true)
                {
                    chkimgMeterApp.Visible = true;
                    nchkimgMeterApp.Visible = false;
                }
                else
                {
                    chkimgMeterApp.Visible = false;
                    nchkimgMeterApp.Visible = true;
                }
                if (!string.IsNullOrEmpty(st.MeterApprovalDate.ToString()))
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgapr.ImageUrl = "~/img/completed.png";
                            imgapr1.ImageUrl = "~/img/GreenNew.png";

                           // imgapr.ImageUrl = "~/img/greennew110.png";
                        }
                        else
                        {
                            //imgapr.ImageUrl = "~/img/completed.png";
                            imgapr1.ImageUrl = "~/img/GreenNew.png";

                          //  imgapr.ImageUrl = "~/img/greennew130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                          //  imgapr.ImageUrl = "~/img/completed.png";
                            imgapr1.ImageUrl = "~/img/GreenNew.png";

                           // imgapr.ImageUrl = "~/img/greennew130.png";
                        }
                        else
                        {
                            //imgapr.ImageUrl = "~/img/completed.png";
                            imgapr1.ImageUrl = "~/img/GreenNew.png";

                           // imgapr.ImageUrl = "~/img/greennew.png";
                        }
                    }
                    try
                    {
                        lblmad.Text = Convert.ToDateTime(st.MeterApprovalDate).ToString("dd/MM/yyyy");
                        lblMeterApprDate.Text = Convert.ToDateTime(st.MeterApprovalDate).ToString("dd/MM/yyyy");
                    }
                    catch { }
                    lblMeterApprDesc.Visible = true;
                    chkMeterAppr.Checked = true;
                }
                else
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                            //imgapr.ImageUrl = "~/img/waiting.png";
                            imgapr1.ImageUrl = "~/img/GrayNew.png";

                          //  imgapr.ImageUrl = "~/img/rednew3110.png";
                        }
                        else
                        {
                           // imgapr.ImageUrl = "~/img/waiting.png";
                            imgapr1.ImageUrl = "~/img/GrayNew.png";

//                            imgapr.ImageUrl = "~/img/rednew3130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                            //imgapr.ImageUrl = "~/img/waiting.png";
                            imgapr1.ImageUrl = "~/img/GrayNew.png";

//                            imgapr.ImageUrl = "~/img/rednew3130.png";
                        }
                        else
                        {
                           // imgapr.ImageUrl = "~/img/rednew3.png";
                            imgapr1.ImageUrl = "~/img/GrayNew.png";

                        }
                    }
                    lblmad.Text = "- - -";
                    lblMeterApprDate.Text = "";
                    lblMeterApprDesc.Visible = false;
                    chkMeterAppr.Checked = false;
                }

                if (chkMeterAppr.Checked == true)
                {
                    chkimgMeterAppr.Visible = true;
                    nchkimgMeterAppr.Visible = false;
                }
                else
                {
                    chkimgMeterAppr.Visible = false;
                    nchkimgMeterAppr.Visible = true;
                }
                if (st.FinanceWithID != 1)
                {
                    lblFinOpt.Text = "Finance Application";
                    lblFinOption.Text = "Finance Application";

                    if (st.FinanceWithID == 2 || st.FinAppStatusID == 4 || st.FinAppStatusID == 5)
                    {
                        if (st.InstallState == "NSW")
                        {
                            if (stcust.CustSourceID == 22)
                            {
                              //  imgap.ImageUrl = "~/img/waiting.png";
                                imgap1.ImageUrl = "~/img/GrayNew.png";


                              //  imgap.ImageUrl = "~/img/rednew110.png";
                            }
                            else
                            {
                             //   imgap.ImageUrl = "~/img/waiting.png";
                                imgap1.ImageUrl = "~/img/GrayNew.png";


                              //  imgap.ImageUrl = "~/img/rednew130.png";
                            }
                        }
                        else
                        {
                            if (stcust.CustSourceID == 22)
                            {
                               // imgap.ImageUrl = "~/img/waiting.png";
                                imgap1.ImageUrl = "~/img/GrayNew.png";

                               
                               // imgap.ImageUrl = "~/img/rednew130.png";
                            }
                            else
                            {
                               // imgap.ImageUrl = "~/img/waiting.png";
                                imgap1.ImageUrl = "~/img/GrayNew.png";

                               
                              //  imgap.ImageUrl = "~/img/rednew.png";
                            }
                        }
                        chkAdPay.Checked = false;
                        lblAdPayDesc.Text = "Finance Status : " + st.FinAppStatus;
                        lblAdPayDesc.Text = lblAdPayDesc.Text + " " + "Contact EuroSolar to submit finance documents";
                        lblfp.Text = "Please contact Euro Solar to submit finance documents";
                    }
                    else
                    {
                        if (st.InstallState == "NSW")
                        {
                            if (stcust.CustSourceID == 22)
                            {
                                //imgap.ImageUrl = "~/img/completed.png";
                                imgap1.ImageUrl = "~/img/GreenNew.png";

                                
                             //   imgap.ImageUrl = "~/img/greennew110.png";
                            }
                            else
                            {
                               // imgap.ImageUrl = "~/img/completed.png";
                                imgap1.ImageUrl = "~/img/GreenNew.png";

                               // imgap.ImageUrl = "~/img/greennew130.png";
                            }
                        }
                        else
                        {
                            if (stcust.CustSourceID == 22)
                            {
                               // imgap.ImageUrl = "~/img/completed.png";
                                imgap1.ImageUrl = "~/img/GreenNew.png";

                               // imgap.ImageUrl = "~/img/greennew130.png";
                            }
                            else
                            {
                               // imgap.ImageUrl = "~/img/completed.png";
                                imgap1.ImageUrl = "~/img/GreenNew.png";

                               // imgap.ImageUrl = "~/img/greennew.png";
                            }
                        }
                        chkAdPay.Checked = true;
                        lblAdPayDesc.Text = "Finance Status : " + st.FinAppStatus;
                        lblfp.Text = "Finance Status : " + st.FinAppStatus;
                    }

                    try
                    {
                        lblAdPayDate.Text = Convert.ToDateTime(st.DocumentReceivedDate).ToString("dd/MM/yyyy");
                    }
                    catch { }
                    lblAdPayDesc.Visible = true;
                    if (st.FinAppStatusID == 7 || st.FinAppStatusID == 8 || st.FinAppStatusID == 9)
                    {
                        lblAdPayDesc.Text = "Finance Status : Approved";
                        lblfp.Text = "Finance Status : Approved";
                    }
                }
                else
                {
                    lblFinOpt.Text = "Advance Payment";
                    lblFinOption.Text = "Advance Payment";

                    lblAdPayDesc.Visible = true;

                    if (st.InvoiceStatusID == 2)
                    {
                        if (st.InstallState == "NSW")
                        {
                            if (stcust.CustSourceID == 22)
                            {
                              //  imgap.ImageUrl = "~/img/completed.png";
                                imgap1.ImageUrl = "~/img/GreenNew.png";

                               // imgap.ImageUrl = "~/img/greennew110.png";
                            }
                            else
                            {
                               // imgap.ImageUrl = "~/img/completed.png";
                                imgap1.ImageUrl = "~/img/GreenNew.png";

                                //imgap.ImageUrl = "~/img/greennew130.png";
                            }
                        }
                        else
                        {
                            if (stcust.CustSourceID == 22)
                            {
                               // imgap.ImageUrl = "~/img/completed.png";
                                imgap1.ImageUrl = "~/img/GreenNew.png";

                                //imgap.ImageUrl = "~/img/greennew130.png";
                            }
                            else
                            {
                                //imgap.ImageUrl = "~/img/completed.png";
                                imgap1.ImageUrl = "~/img/GreenNew.png";

                              //  imgap.ImageUrl = "~/img/greennew.png";
                            }
                        }

                        try
                        {
                            ProjectsEntity stc = ProjectsManagement.tblProjects_SelectByProjectNumberCust(st.ProjectNumber);

                            lblAdPayDate.Text = Convert.ToDateTime(stc.InvPayDate).ToString("dd/MM/yyyy");
                        }
                        catch { lblAdPayDate.Text = ""; }

                        lblAdPayDesc.Text = "Full System Payment has been done";

                        chkAdPay.Checked = true;
                        lblfp.Text = "Fully Paid";
                    }
                    else
                    {
                        if (st.InstallState == "NSW")
                        {
                            if (stcust.CustSourceID == 22)
                            {
                               // imgap.ImageUrl = "~/img/waiting.png";
                                imgap1.ImageUrl = "~/img/GrayNew.png";

                              //  imgap.ImageUrl = "~/img/rednew3110.png";
                            }
                            else
                            {
                               // imgap.ImageUrl = "~/img/waiting.png";
                                imgap1.ImageUrl = "~/img/GrayNew.png";

                               // imgap.ImageUrl = "~/img/rednew3130.png";
                            }
                        }
                        else
                        {
                            if (stcust.CustSourceID == 22)
                            {
                                //imgap.ImageUrl = "~/img/waiting.png";
                                imgap1.ImageUrl = "~/img/GrayNew.png";
                               
                              //  imgap.ImageUrl = "~/img/rednew3130.png";
                            }
                            else
                            {
                               // imgap.ImageUrl = "~/img/waiting.png";
                                imgap1.ImageUrl = "~/img/GrayNew.png";

                               // imgap.ImageUrl = "~/img/rednew3.png";
                            }
                        }
                        lblAdPayDate.Text = "";
                        lblAdPayDesc.Text = "Please contact Euro Solar to make a Payment";
                        lblfp.Text = "Please contact Euro Solar to make a Payment";
                        chkAdPay.Checked = false;
                    }
                }
                if (chkAdPay.Checked == true)
                {
                    chkimgAdPay.Visible = true;
                    nchkimgAdPay.Visible = false;
                }
                else
                {
                    chkimgAdPay.Visible = false;
                    nchkimgAdPay.Visible = true;
                }
               

                if (!string.IsNullOrEmpty(st.InstallBookingDate.ToString()) && !string.IsNullOrEmpty(st.InstallerIDs))
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgib.ImageUrl = "~/img/completed.png";
                            imgib1.ImageUrl = "~/img/GreenNew.png";
                           
                           // imgib.ImageUrl = "~/img/greennew110.png";
                        }
                        else
                        {
                           // imgib.ImageUrl = "~/img/completed.png";
                            imgib1.ImageUrl = "~/img/GreenNew.png";

                           // imgib.ImageUrl = "~/img/greennew130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgib.ImageUrl = "~/img/completed.png";
                            imgib1.ImageUrl = "~/img/GreenNew.png";
                           
                            //imgib.ImageUrl = "~/img/greennew130.png";
                        }
                        else
                        {
                          //  imgib.ImageUrl = "~/img/completed.png";
                            imgib1.ImageUrl = "~/img/GreenNew.png";
                          
                          //  imgib.ImageUrl = "~/img/greennew.png";
                        }
                    }
                    try
                    {
                        lblibd.Text = Convert.ToDateTime(st.InstallBookingDate).ToString("dd/MM/yyyy");
                        lblInstBookDate.Text = Convert.ToDateTime(st.InstallBookingDate).ToString("dd/MM/yyyy");
                    }
                    catch { }
                    lblInstBookDesc.Visible = true;
                    chkInstBook.Checked = true;
                }
                else
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgib.ImageUrl = "~/img/waiting.png";
                            imgib1.ImageUrl = "~/img/GrayNew.png";

                           // imgib.ImageUrl = "~/img/rednew3110.png";
                        }
                        else
                        {
                           // imgib.ImageUrl = "~/img/waiting.png";
                            imgib1.ImageUrl = "~/img/GrayNew.png";


                           // imgib.ImageUrl = "~/img/rednew3130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgib.ImageUrl = "~/img/waiting.png";
                            imgib1.ImageUrl = "~/img/GrayNew.png";

                           
                            //imgib.ImageUrl = "~/img/rednew3130.png";
                        }
                        else
                        {
                           // imgib.ImageUrl = "~/img/waiting.png";
                            imgib1.ImageUrl = "~/img/GrayNew.png";


                           // imgib.ImageUrl = "~/img/rednew3.png";
                        }
                    }
                    lblibd.Text = "- - -";
                    lblInstBookDate.Text = "";
                    lblInstBookDesc.Visible = false;
                    chkInstBook.Checked = false;
                }
                if (chkInstBook.Checked == true)
                {
                    chkimgInstBook.Visible = true;
                    nchkimgInstBook.Visible = false;
                }
                else
                {
                    chkimgInstBook.Visible = false;
                    nchkimgInstBook.Visible = true;
                }
                if (!string.IsNullOrEmpty(st.InstallationCompletionDate.ToString()))
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                            //imgic.ImageUrl = "~/img/completed.png";
                            imgic1.ImageUrl = "~/img/Completed.png";

                           
                           // imgic.ImageUrl = "~/img/greennew110.png";
                        }
                        else
                        {
                            //imgic.ImageUrl = "~/img/completed.png";
                            imgic1.ImageUrl = "~/img/Completed.png";
                          
//                            imgic.ImageUrl = "~/img/greennew130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgic.ImageUrl = "~/img/completed.png";
                            imgic1.ImageUrl = "~/img/Completed.png";
  
//                            imgic.ImageUrl = "~/img/greennew130.png";
                        }
                        else
                        {
                            //imgic.ImageUrl = "~/img/completed.png";
                            imgic1.ImageUrl = "~/img/Completed.png";
  
  //                          imgic.ImageUrl = "~/img/greennew.png";
                        }
                    }
                    try
                    {
                        lblInstCompDate.Text = Convert.ToDateTime(st.InstallationCompletionDate).ToString("dd/MM/yyyy");
                    }
                    catch { }
                    lblInstCompDesc.Visible = true;
                    chkInstComp.Checked = true;
                }
                else
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgic.ImageUrl = "~/img/waiting.png";
                            imgic1.ImageUrl = "~/img/waiting.png";
                         
                        //    imgic.ImageUrl = "~/img/rednew3110.png";
                        }
                        else
                        {
                           // imgic.ImageUrl = "~/img/waiting.png";
                            imgic1.ImageUrl = "~/img/waiting.png";

                          //  imgic.ImageUrl = "~/img/rednew3130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                          //  imgic.ImageUrl = "~/img/rednew3130.png";
                           // imgic.ImageUrl = "~/img/waiting.png";
                            imgic1.ImageUrl = "~/img/waiting.png";

                        }
                        else
                        {
                           // imgic.ImageUrl = "~/img/waiting.png";
                            imgic1.ImageUrl = "~/img/waiting.png";

                          //  imgic.ImageUrl = "~/img/rednew3.png";
                        }
                    }
                    lblInstCompDate.Text = "";
                    lblInstCompDesc.Visible = false;
                    chkInstComp.Checked = false;
                }
                if (chkInstComp.Checked == true)
                {
                    chkimgInstComp.Visible = true;
                    nchkimgInstComp.Visible = false;
                }
                else
                {
                    chkimgInstComp.Visible = false;
                    nchkimgInstComp.Visible = true;
                }
              
                if (!string.IsNullOrEmpty(st.MeterJobBooked.ToString()))
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                          //  imgmib.ImageUrl = "~/img/completed.png";
                            imgmib1.ImageUrl = "~/img/GreenNew.png";

                           // imgmib.ImageUrl = "~/img/greennew110.png";
                        }
                        else
                        {
                           // imgmib.ImageUrl = "~/img/completed.png";
                            imgmib1.ImageUrl = "~/img/GreenNew.png";

                           // imgmib.ImageUrl = "~/img/greennew130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgmib.ImageUrl = "~/img/completed.png";
                            imgmib1.ImageUrl = "~/img/GreenNew.png";

                           // imgmib.ImageUrl = "~/img/greennew130.png";
                        }
                        else
                        {
                           // imgmib.ImageUrl = "~/img/completed.png";
                            imgmib1.ImageUrl = "~/img/GreenNew.png";

                           // imgmib.ImageUrl = "~/img/greennew.png";
                        }
                    }
                    try
                    {
                        lblmibd.Text = Convert.ToDateTime(st.MeterJobBooked).ToString("dd/MM/yyyy");
                        lblMeterInstBooked.Text = Convert.ToDateTime(st.MeterJobBooked).ToString("dd/MM/yyyy");
                    }
                    catch { }
                    lblMeterInstBookedDesc.Visible = true;
                    chkMeterInstBooked.Checked = true;
                }
                else
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgmib.ImageUrl = "~/img/waiting.png";
                            imgmib1.ImageUrl = "~/img/GrayNew.png";

                         //   imgmib.ImageUrl = "~/img/rednew3110.png";
                        }
                        else
                        {
                           // imgmib.ImageUrl = "~/img/waiting.png";
                            imgmib1.ImageUrl = "~/img/GrayNew.png";

                           // imgmib.ImageUrl = "~/img/rednew3130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgmib.ImageUrl = "~/img/waiting.png";
                            imgmib1.ImageUrl = "~/img/GrayNew.png";

                            //imgmib.ImageUrl = "~/img/rednew3130.png";
                        }
                        else
                        {
                          //  imgmib.ImageUrl = "~/img/waiting.png";
                            imgmib1.ImageUrl = "~/img/GrayNew.png";

                           // imgmib.ImageUrl = "~/img/rednew3.png";
                        }
                    }
                    lblmibd.Text = "- - -";
                    lblMeterInstBooked.Text = "";
                    lblMeterInstBookedDesc.Visible = false;
                    chkMeterInstBooked.Checked = false;
                }
                if (!string.IsNullOrEmpty(st.MeterCompleted.ToString()))
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                         //   imgmic.ImageUrl = "~/img/completed.png";
                            imgmic1.ImageUrl = "~/img/GreenNew.png";

                         //   imgmic.ImageUrl = "~/img/greennew110.png";
                        }
                        else
                        {
                          //  imgmic.ImageUrl = "~/img/completed.png";
                            imgmic1.ImageUrl = "~/img/GreenNew.png";
                          
                          //  imgmic.ImageUrl = "~/img/greennew130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                            //imgmic.ImageUrl = "~/img/completed.png";
                            imgmic1.ImageUrl = "~/img/GreenNew.png";

                          //  imgmic.ImageUrl = "~/img/greennew130.png";
                        }
                        else
                        {
                           // imgmic.ImageUrl = "~/img/completed.png";
                            imgmic1.ImageUrl = "~/img/GreenNew.png";
                         
                            //imgmic.ImageUrl = "~/img/greennew.png";
                        }
                    }
                    try
                    {
                        lblmicd.Text = Convert.ToDateTime(st.MeterCompleted).ToString("dd/MM/yyyy");
                        lblMeterInstComp.Text = Convert.ToDateTime(st.MeterCompleted).ToString("dd/MM/yyyy");
                    }
                    catch { }
                    lblMeterInstCompDesc.Visible = true;
                    chkMeterInstComp.Checked = true;
                }
                else
                {
                    if (st.InstallState == "NSW")
                    {
                        if (stcust.CustSourceID == 22)
                        {
                           // imgmic.ImageUrl = "~/img/waiting.png";
                            imgmic1.ImageUrl = "~/img/GrayNew.png";
                           
                          //  imgmic.ImageUrl = "~/img/rednew3110.png";
                        }
                        else
                        {
                            //imgmic.ImageUrl = "~/img/waiting.png";
                            imgmic1.ImageUrl = "~/img/GrayNew.png";
                            
                           // imgmic.ImageUrl = "~/img/rednew3130.png";
                        }
                    }
                    else
                    {
                        if (stcust.CustSourceID == 22)
                        {
                            //imgmic.ImageUrl = "~/img/waiting.png";
                            imgmic1.ImageUrl = "~/img/GrayNew.png";
                           
                           // imgmic.ImageUrl = "~/img/rednew3130.png";
                        }
                        else
                        {
                            //imgmic.ImageUrl = "~/img/waiting.png";
                            imgmic1.ImageUrl = "~/img/GrayNew.png";
                          
                            //imgmic.ImageUrl = "~/img/rednew3.png";
                        }
                    }
                    lblmicd.Text = "- - -";
                    lblMeterInstComp.Text = "";
                    lblMeterInstCompDesc.Visible = false;
                    chkMeterInstComp.Checked = false;
                }
             

            }
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session["user"] = "";
            Response.Redirect("../CustLogin.aspx");
           
        }

        protected void imgdoc1_Click(object sender, ImageClickEventArgs e)
        {
            string filePath = "~/pdffiles/Jinko PV Module.pdf";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + "Jinko PV Module.pdf" + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();
        }

        protected void imgdoc3_Click(object sender, ImageClickEventArgs e)
        {
            string filePath = "~/pdffiles/ABB Inverter.pdf";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + "ABB Inverter.pdf" + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();
        }
        protected void imgdoc4_Click(object sender, ImageClickEventArgs e)
        {
            string filePath = "~/pdffiles/SMA Inverter.pdf";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + "SMA Inverter.pdf" + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();
        }
        protected void imgdoc5_Click(object sender, ImageClickEventArgs e)
        {
            string filePath = "~/pdffiles/Fronius Inverter.pdf";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + "Fronius Inverter.pdf" + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();
        }
        protected void imgdoc6_Click(object sender, ImageClickEventArgs e)
        {
            string filePath = "~/pdffiles/Zeversolar Inverter.pdf";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + "Zeversolar Inverter.pdf" + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();
        }
        protected void imgdoc7_Click(object sender, ImageClickEventArgs e)
        {
            string filePath = "~/pdffiles/UREnergy Inverter.pdf";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + "UREnergy Inverter.pdf" + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();
        }
        protected void imgdoc8_Click(object sender, ImageClickEventArgs e)
        {
            string filePath = "~/pdffiles/Omnik Inverter.pdf";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + "Omnik Inverter.pdf" + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();
        }

        protected void imgdoc10_Click(object sender, ImageClickEventArgs e)
        {
            string filePath = "~/pdffiles/Trina PV Module.pdf";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + "Trina PV Module.pdf" + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();
        }
        protected void imgdoc11_Click(object sender, ImageClickEventArgs e)
        {
            string filePath = "~/pdffiles/Solax Power Warranty.pdf";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + "Solax Power Warranty.pdf" + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();
        }
        protected void imgdoc12_Click(object sender, ImageClickEventArgs e)
        {
            string filePath = "~/pdffiles/USP PV Module.pdf";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + "USP PV Module.pdf" + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();
        }
        protected void imgdoc13_Click(object sender, ImageClickEventArgs e)
        {
            string filePath = "~/pdffiles/Enphase_AU_NZ_Warranty.pdf";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + "Enphase_AU_NZ_Warranty.pdf" + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();
        }
    }
}
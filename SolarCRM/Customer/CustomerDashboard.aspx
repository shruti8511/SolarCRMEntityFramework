<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerDashboard.aspx.cs" Inherits="SolarCRM.Customer.CustomerDashboard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>




<!DOCTYPE html>

<html lang="en">

<head  runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Karmanta - Bootstrap 3 Responsive Admin Template">
    <meta name="author" content="GeeksLabs">
    <meta name="keyword" content="Karmanta, Dashboard, Admin, Template, Theme, Bootstrap, Responsive, Retina, Minimal">
    <link rel="shortcut icon" href="../img/favicon.png">

    <title> </title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css'>

    <!-- Bootstrap CSS -->
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- bootstrap theme -->
    <link href="../bootstrap/css/bootstrap-theme.css" rel="stylesheet">
    <!--external css-->
    <!-- font icon -->
    <link href="../bootstrap/css/elegant-icons-style.css" rel="stylesheet" />
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <!-- full calendar css-->
    <link href="../bootstrap/css/bootstrap-fullcalendar.css" rel="stylesheet" />
    <!-- easy pie chart-->
    <link href="../bootstrap/css/jquery.easy-pie-chart.css" rel="stylesheet" type="text/css" media="screen" />
    <!-- owl carousel -->
    <link rel="stylesheet" href="../bootstrap/css/owl.carousel.css" type="text/css">

    <!-- Custom styles -->
    <link href="../bootstrap/css/style.css" rel="stylesheet">
    <link href="../bootstrap/css/style-responsive.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
  
     <asp:ScriptManager ID="sm2" runat="server"></asp:ScriptManager>
        <section id="container" class="">
            <header class="header" style="background-color:white">
                 <div class="toggle-nav">
                    <div class="icon-reorder tooltips" data-original-title="Toggle Navigation" data-placement="bottom"></div>
                </div>
                <div>
                     <a href="<%--http://eurosolar.com.au/--%>" target="_blank" class="logo" style="margin-left:43%">
                    <asp:Image ID="img" runat="server" style="height:50px;" ImageUrl="../../content/img/logo_new.png" ImageAlign="Middle" /></a>
                <!--logo end-->
                </div>
                  <div class="top-nav notification-row">
                    <!-- notificatoin dropdown start-->
                    <ul class="nav pull-right top-menu">
                        <!-- user login dropdown start-->
                        <li class="dropdown">
                            <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                                <span class="profile-ava">
                                    <i class="icon_profile"></i>
                                </span>
                                <span class="username">
                                    <asp:Label ID="lblcusthdr" runat="server"></asp:Label></span>
                                    &nbsp;&nbsp;<asp:Button ID="btnlogout"  CssClass="btn btn-default btn-flat" Text="Log Out" runat="server" OnClick="btnlogout_Click" />

                               <%-- <b class="caret"></b>--%>
                            </a>
                            <ul class="dropdown-menu extended logout">
                                <div class="log-arrow-up"></div>
                                <li class="eborder-top">
                                    <i class="icon_key_alt"></i>
                                    <%--<a href="login.html">--%><%-- Log Out</a>--%>
                                </li>
                            </ul>
                        </li>
                        <!-- user login dropdown end -->
                    </ul>
                    <!-- notificatoin dropdown end-->
                </div>
            </header>
         
            <section id="main-content">
                <section class="wrapper">
                    <div class="row">
                        <div class="col-lg-12" style="padding-right:100px;padding-top:30px; padding-left:100px">
                            <div class="panel-body progress-panel">
                                <div class="row"  style="text-align:center;">
                                    <div class="col-lg-12 task-progress" >
                                        <h1><b style="background-color:#f0a41b; color:white; border-radius:5px;">Solar PV System Installation Status</b></h1>
                                    </div>

                                </div>
                            </div>

                                <table class="table table-striped table" style="text-align: center;" cell-spacing="0">
                                    <tbody>
                                        <tr>
                                           
                                            <td style="background-color:white; border:none">
                                              
                                                <asp:Image ID="imggoc1" CssClass="dropdown-toggle" runat="server"/>
                                              
                                            </td>
                                            <cc1:BalloonPopupExtender ID="BalloonPopupExtender1" TargetControlID="imggoc1"  DisplayOnFocus="true" Position="TopRight"  BalloonPopupControlID="popupImage" BalloonStyle="Custom" DisplayOnMouseOver="true" ScrollBars="Auto" runat="server" UseShadow="False" CustomCssUrl="bgcolor" CustomClassName="bgcolor" />
                                           
                                            <td  style="background-color:white; border:none">
                                               
                                                  <asp:Image ID="imgdr1" runat="server" />
                                            </td>
                                            
                                            <cc1:BalloonPopupExtender ID="BalloonPopupExtender2" TargetControlID="imgdr1"  DisplayOnFocus="true"
                                                Position="TopRight" BalloonPopupControlID="popupImage2" BalloonStyle="Custom" DisplayOnMouseOver="true" ScrollBars="Auto" runat="server" UseShadow="False" CustomCssUrl="bgcolor" CustomClassName="bgcolor" />
                                           
                                            <td id="tdd2d" runat="server"  style="background-color:white;border:none">
                                             
                                                    <asp:Image ID="imgvc1" runat="server" />
                                            </td>
                                            <cc1:BalloonPopupExtender ID="BalloonPopupExtender10" TargetControlID="imgvc1"  DisplayOnFocus="true"
                                                Position="TopRight" BalloonPopupControlID="popupImage10" BalloonStyle="Custom" DisplayOnMouseOver="true" ScrollBars="Auto" runat="server" UseShadow="False" CustomCssUrl="bgcolor" CustomClassName="bgcolor" />

                                            <td  style="background-color:white; border:none">
                                               
                                                  <asp:Image ID="imgma1" runat="server" />
                                            </td>
                                            <cc1:BalloonPopupExtender ID="BalloonPopupExtender3" TargetControlID="imgma1"  DisplayOnFocus="true"
                                                Position="TopRight" BalloonPopupControlID="popupImage3" BalloonStyle="Custom" DisplayOnMouseOver="true" ScrollBars="Auto" runat="server" UseShadow="False" CustomCssUrl="bgcolor" CustomClassName="bgcolor" />
                                           
                                            <td  style="background-color:white; border:none">
                                              
                                                 <asp:Image ID="imgapr1" runat="server" />
                                            </td>

                                            <cc1:BalloonPopupExtender ID="BalloonPopupExtender4" TargetControlID="imgapr1"  DisplayOnFocus="true"
                                                Position="TopRight" BalloonPopupControlID="popupImage4" BalloonStyle="Custom" DisplayOnMouseOver="true" ScrollBars="Auto" runat="server" UseShadow="False" CustomCssUrl="bgcolor" CustomClassName="bgcolor" />
                                           
                                            <td  style="background-color:white; border:none">
                                               
                                                 <asp:Image ID="imgap1" runat="server" />
                                            </td>

                                            <cc1:BalloonPopupExtender ID="BalloonPopupExtender5" TargetControlID="imgap1"  DisplayOnFocus="true"
                                                Position="TopRight" BalloonPopupControlID="popupImage5" BalloonStyle="Custom" DisplayOnMouseOver="true" ScrollBars="Auto" runat="server" UseShadow="False" CustomCssUrl="bgcolor" CustomClassName="bgcolor" />
                                          
                                            <td  style="background-color:white; border:none">
                                               
                                                 <asp:Image ID="imgib1" runat="server" Style=" padding-right:10px;"/>
                                            </td>

                                            <cc1:BalloonPopupExtender ID="BalloonPopupExtender6" TargetControlID="imgib1"  DisplayOnFocus="true"
                                                Position="TopRight" BalloonPopupControlID="popupImage6" BalloonStyle="Custom" DisplayOnMouseOver="true" ScrollBars="Auto" runat="server" UseShadow="False" CustomCssUrl="bgcolor" CustomClassName="bgcolor" />
                                            
                                            <td  style="background-color:white; border:none">
                                               
                                                 <asp:Image ID="imgic1" runat="server" Style=" padding-right:10px;" />
                                            </td>

                                            <cc1:BalloonPopupExtender ID="BalloonPopupExtender7" TargetControlID="imgic1"  DisplayOnFocus="true"
                                                Position="TopRight" BalloonPopupControlID="popupImage7" BalloonStyle="Custom" DisplayOnMouseOver="true" ScrollBars="Auto" runat="server" UseShadow="False" CustomCssUrl="bgcolor" CustomClassName="bgcolor" />
                                           
                                            <td id="tdnsw1" runat="server"  style="background-color:white; border:none">
                                                
                                                 <asp:Image ID="imgmib1" runat="server" />
                                            </td>

                                            <cc1:BalloonPopupExtender ID="BalloonPopupExtender8" TargetControlID="imgmib1"  DisplayOnFocus="true"
                                                Position="TopRight" BalloonPopupControlID="popupImage8" BalloonStyle="Custom" DisplayOnMouseOver="true" ScrollBars="Auto" runat="server" UseShadow="False" CustomCssUrl="bgcolor" CustomClassName="bgcolor" />
                                           
                                            <td id="tdnsw2" runat="server"  style="background-color:white; border:none">
                                             
                                                 <asp:Image ID="imgmic1" runat="server" />
                                            </td>
                                            <div style="padding-right:30px">
                                            <cc1:BalloonPopupExtender ID="BalloonPopupExtender9" TargetControlID="imgmic1"  DisplayOnFocus="true"
                                               Position="TopRight" BalloonPopupControlID="popupImage9" BalloonStyle="Custom" DisplayOnMouseOver="true" ScrollBars="Auto" runat="server" UseShadow="False" CustomCssUrl="bgcolor" CustomClassName="bgcolor"  />
                                           </div>
                                        </tr>
                                        <tr>
                                            <td style="border:none">
                                                <b>Order Confirmation</b>
                                                
                                                  
                                            </td>
                                            <td  style="border:none">
                                                <b>Documents Received</b></td>
                                            <td id="d2dtxt" runat="server"  style="border:none"><b>Verification Call</b></td>
                                            <td  style="border:none; padding-left:25px;">
                                                <b>Meter <br /> Applied</b></td>
                                            <td  style="border:none;  padding-left:25px;">
                                                <b>Meter <br /> Approved</b></td>
                                            <td  style="border:none">
                                                <b>
                                                    <asp:Label ID="lblFinOpt" runat="server"></asp:Label></b></td>
                                            <td  style="border:none ">
                                                <b>Installation <br /> Booked</b></td>
                                            <td  style="border:none ;  padding-right:30px;">
                                                <b>Installation Completed</b></td>
                                            <td id="tdnswtxt1" runat="server"  style="border:none">
                                                <b>Meter Inst Booked</b>
                                            </td>
                                            <td id="tdnswtxt2" runat="server"  style="border:none">
                                                <b>Meter Inst Completed</b>
                                            </td>
                                        </tr>
                                        <tr><td colspan="5" style="background-color:white; border:none"></td></tr>
                                    </tbody>
                                </table>
                         
                        </div>
                    </div>

                   
                    <div runat="server" id="popupImage" >
                       

                        <p  style="color:green; width:200px; margin-top: 7px;">Congratulation on your Solar Purchase!!!</p>
                        <%--</div>--%>
                    </div>
                    <div runat="server" id="popupImage2" style="display: none;">
                        <%--<a class="close-ribbonn"></a>
                        <div class="modaln-contentn">--%>

                        <p   style="color:green;width:200px; margin-top: 7px;">
                            Required Any-One/All of following Documents:<br />
                             Meter Photo,
                             Signed Quote, 
                             Electricity Bill<br />
                        </p>
                        <%--</div>--%>
                    </div>
                    <div runat="server" id="popupImage10" style="display: none;">
                      

                        <p  style="color:green;width:200px;  margin-top: 7px;">
                            <asp:Label ID="lblverificationcall" runat="server"></asp:Label>
                        </p>
                        <%--</div>--%>
                    </div>
                    <div runat="server" id="popupImage3" style="display: none;">
                       

                        <p  style="color:green; width:200px;  margin-top: 7px;">
                            Standard Meter Approval Time :<br />
                            <br />
                            <asp:Label ID="lblmat" runat="server"></asp:Label>
                        </p>
                        <%--</div>--%>
                    </div>

                    <div runat="server" id="popupImage4" style="display: none;">
                        <%--<a class="close-ribbonn"></a>
                        <div class="modaln-contentn">--%>

                        <p   style="color:green; width:200px;  margin-top: 7px;">
                            Your meter application approved on
                                <asp:Label ID="lblmad" runat="server"></asp:Label>
                        </p>
                        <%--</div>--%>
                    </div>

                    <div runat="server" id="popupImage5" style="display: none;">
                      

                        <p style="color:green; width:200px;  margin-top: 7px;">
                            <asp:Label ID="lblfp" runat="server"></asp:Label>
                        </p>
                        <%--</div>--%>
                    </div>

                    <div runat="server" id="popupImage6" style="display: none;">
                        <%--<a class="close-ribbonn"></a>
                        <div class="modaln-contentn">--%>

                        <p   style="color:green; width:200px;  margin-top: 7px;">
                            Your Solar System Installation is booked on
                                <asp:Label ID="lblibd" runat="server"></asp:Label>
                        </p>
                        <%--</div>--%>
                    </div>

                    <div runat="server" id="popupImage7" style="display: none;">
                       
                    </div>
                    <div runat="server" id="popupImage8" style="display: none;">
                      

                        <p   style="color:green; width:200px;  margin-top: 7px;">
                            Your Meter Installation Booked On
                                <asp:Label ID="lblmibd" runat="server"></asp:Label>
                        </p>
                        <%--</div>--%>
                    </div>
                    <div runat="server" id="popupImage9" style="display: none;;">
                        <%--<a class="close-ribbonn"></a>
                        <div class="modaln-contentn">--%>

                        <p style="color:green; width:200px;  margin-top: 7px;">
                            Meter Installation Completed On
                                <asp:Label ID="lblmicd" runat="server"></asp:Label>
                        </p>
                        <%--</div>--%>
                    </div>
                   
                    <!--overview start-->
                    <div class="row state-overview" >
                        <div class="col-lg-12" style="padding-right:100px;padding-top:50px; padding-left:100px">
                            <section class="panel">
                                <div class="panel-body progress-panel">
                                    <div class="row">
                                        <div class="col-lg-12 task-progress">
                                            <h1><b style="background-color:#29a2ce; color: white; border-radius:5px">Solar PV System Installation Details</b></h1>
                                        </div>
                                       
                                    </div>
                                </div>
                               
                               <%-- <div class="table-responsive">--%>
                                    <table class="table table-striped table-hover">
                                        <tbody>
                                            <tr>
                                                <th>Installation Steps</th>
                                                <th>Date</th>
                                                <th>Description</th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkOrderConf" Visible="false" Enabled="false" runat="server" />
                                                     <asp:Image ID="chkimgorderconf" runat="server" visible ="false" ImageUrl="~/img/Checkbox.jpg" />
                                                     <asp:Image ID="nchkimgorderconf" runat="server" visible ="false" ImageUrl="~/img/Non-checkbox.jpg" />
                                                    Order Confirmation</td>
                                                <td>
                                                    <asp:Label ID="lblOrderConfDate" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblOrderConfDesc" runat="server" Text="Deposit Received" ForeColor="#29a2ce" ></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkDocRec" Visible="false" Enabled="false" runat="server" />
                                                       <asp:Image ID="chkimgDocRec" runat="server" visible ="false" ImageUrl="~/img/Checkbox.jpg" />
                                                     <asp:Image ID="nchkimgDocRec" runat="server" visible ="false" ImageUrl="~/img/Non-checkbox.jpg" />
                                                    Documents Received</td>
                                                <td>
                                                    <asp:Label ID="lblDocRecDate" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblDocRecDesc" runat="server" Text="Meter Photo" ForeColor="#29a2ce"></asp:Label>
                                                    <asp:CheckBox ID="chkMP" Enabled="false" Visible="false" runat="server" />
                                                    <asp:Image ID="chkimgMP" runat="server" visible ="false" ImageUrl="~/img/Checkbox.jpg" />
                                                     <asp:Image ID="nchkimgMP" runat="server" visible ="false" ImageUrl="~/img/Non-checkbox.jpg" />
                                                 
                                                    <asp:Label ID="lblSQ" runat="server" Text="Signed Quote" ForeColor="#29a2ce"></asp:Label>
                                                    <asp:CheckBox ID="chkSQ" Enabled="false" Visible="false" runat="server" />
                                                      <asp:Image ID="chkimgSQ" runat="server" visible ="false" ImageUrl="~/img/Checkbox.jpg" />
                                                     <asp:Image ID="nchkimgSQ" runat="server" visible ="false" ImageUrl="~/img/Non-checkbox.jpg" />
                                                 

                                                    <asp:Label ID="lblEB" runat="server" Text="Electricity Bill" ForeColor="#29a2ce"></asp:Label>
                                                   <asp:Image ID="chkimgEB" runat="server" visible ="false" ImageUrl="~/img/Checkbox.jpg" />
                                                     <asp:Image ID="nchkimgEB" runat="server" visible ="false" ImageUrl="~/img/Non-checkbox.jpg" />
                                                 
                                                    
                                                      <asp:CheckBox ID="chkEB" Enabled="false"  Visible="false" runat="server" /></td>
                                            </tr>
                                            <tr id="trd2d" runat="server">
                                                <td>
                                                    <asp:CheckBox ID="chkvericall" Visible="false" Enabled="false" runat="server" />
                                                    <asp:Image ID="chkimgvericall" runat="server" visible ="false" ImageUrl="~/img/Checkbox.jpg" />
                                                     <asp:Image ID="nchkimgvericall" runat="server" visible ="false" ImageUrl="~/img/Non-checkbox.jpg" />
                                                    Verification Call</td>
                                                <td>
                                                    <asp:Label ID="lblVeriCallDate" runat="server" ></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblVeriCallDesc" runat="server"  ForeColor="#29a2ce"></asp:Label></td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkMeterApp" Enabled="false" Visible="false" runat="server" />
                                                       <asp:Image ID="chkimgMeterApp" runat="server" visible ="false" ImageUrl="~/img/Checkbox.jpg" />
                                                     <asp:Image ID="nchkimgMeterApp" runat="server" visible ="false" ImageUrl="~/img/Non-checkbox.jpg" />
                                                 
                                                    Meter Applied</td>
                                                <td>
                                                    <asp:Label ID="lblMeterAppDate" runat="server" ></asp:Label></td>
                                                <td style="align-content:center">
                                                    <asp:Label ID="lblMeterAppDesc" runat="server" Text="Grid Connection has been applied"  ForeColor="#29a2ce"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkMeterAppr" Visible="false" Enabled="false" runat="server" />
                                                        <asp:Image ID="chkimgMeterAppr" runat="server" visible ="false" ImageUrl="~/img/Checkbox.jpg" />
                                                     <asp:Image ID="nchkimgMeterAppr" runat="server" visible ="false" ImageUrl="~/img/Non-checkbox.jpg" />
                                                 
                                                    Meter Approved</td>
                                                <td>
                                                    <asp:Label ID="lblMeterApprDate" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblMeterApprDesc" runat="server" Text="Grid Connection has been approved" ForeColor="#29a2ce"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkAdPay" Visible="false" Enabled="false" runat="server" />

                                                      <asp:Image ID="chkimgAdPay" runat="server" visible ="false" ImageUrl="~/img/Checkbox.jpg" />
                                                     <asp:Image ID="nchkimgAdPay" runat="server" visible ="false" ImageUrl="~/img/Non-checkbox.jpg" />
                                               
                                                    <asp:Label ID="lblFinOption" runat="server" ></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblAdPayDate" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblAdPayDesc" runat="server"  ForeColor="#29a2ce"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkInstBook" Visible="false" Enabled="false" runat="server" />
                                                      <asp:Image ID="chkimgInstBook" runat="server" visible ="false" ImageUrl="~/img/Checkbox.jpg" />
                                                     <asp:Image ID="nchkimgInstBook" runat="server" visible ="false" ImageUrl="~/img/Non-checkbox.jpg" />
                                               
                                                    Installation Booked</td>
                                                <td>
                                                    <asp:Label ID="lblInstBookDate" runat="server" ></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblInstBookDesc" runat="server" Text="Installation has been Booked"  ForeColor="#29a2ce"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkInstComp" Visible="false" Enabled="false" runat="server" />
                                                      <asp:Image ID="chkimgInstComp" runat="server" visible ="false" ImageUrl="~/img/Checkbox.jpg" />
                                                     <asp:Image ID="nchkimgInstComp" runat="server" visible ="false" ImageUrl="~/img/Non-checkbox.jpg" />
                                               
                                                    Installation Completed</td>
                                                <td>
                                                    <asp:Label ID="lblInstCompDate" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblInstCompDesc" runat="server" Text="Installation has been Completed"  ForeColor="#29a2ce"></asp:Label></td>
                                            </tr>
                                            <tr id="trmtrinstbook" runat="server">
                                                <td>
                                                    <asp:CheckBox ID="chkMeterInstBooked" Visible="false" Enabled="false" runat="server" />
                                                      <asp:Image ID="chkimgMeterInstBooked" runat="server" visible ="false" ImageUrl="~/img/Checkbox.jpg" />
                                                     <asp:Image ID="nchkMeterimgInstBooked" runat="server" visible ="false" ImageUrl="~/img/Non-checkbox.jpg" />
                                               
                                                    Meter Inst Booked</td>
                                                <td>
                                                    <asp:Label ID="lblMeterInstBooked" runat="server" ></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblMeterInstBookedDesc" runat="server"  ForeColor="#29a2ce" Text="Meter Installation has been Booked"></asp:Label></td>
                                            </tr>
                                            <tr id="trmtrinstcomp" runat="server">
                                                <td>
                                                    <asp:CheckBox ID="chkMeterInstComp" Visible="false" Enabled="false" runat="server" />
                                                      <asp:Image ID="chkimgMeterInstComp" runat="server" visible ="false" ImageUrl="~/img/Checkbox.jpg" />
                                                     <asp:Image ID="nchkimgMeterInstComp" runat="server" visible ="false" ImageUrl="~/img/Non-checkbox.jpg" />
                                               
                                                    Meter Inst Completed</td>
                                                <td>
                                                    <asp:Label ID="lblMeterInstComp" runat="server" ></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblMeterInstCompDesc" runat="server"  ForeColor="#29a2ce" Text="Meter Installation has been Completed"></asp:Label></td>
                                            </tr>
                                        </tbody>
                                    </table>
                               
                            </section>
                        </div>
                    </div>
                    <!--overview end-->

                    <!-- project team & activity start -->

                    <!-- project team & activity end -->
                <%--    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel-body progress-panel">
                                <div class="row">
                                    <div class="col-lg-8 task-progress pull-left">
                                        <h1><b>Warranty Documents</b></h1>
                                    </div>

                                </div>
                                <hr style="border-color: #DDDDDD;" />
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="lbldoc1" Font-Size="16px" Text="Jinko PV Module" runat="server" CssClass="form-group"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:ImageButton ID="imgdoc1" runat="server" Width="115px" OnClick="imgdoc1_Click" ImageUrl="~/img/download-button-new.png" />
                                    </div>
                                    
                                    <div class="col-md-3">
                                        <asp:Label ID="lbldoc10" Font-Size="16px" Text="Trina PV Module" runat="server" CssClass="form-group"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:ImageButton ID="imgdoc10" runat="server" Width="115px" OnClick="imgdoc10_Click" ImageUrl="~/img/download-button-new.png" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="lbldoc3" Font-Size="16px" Text="ABB Inverter" runat="server" CssClass="form-group"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:ImageButton ID="imgdoc3" runat="server" Width="115px" OnClick="imgdoc3_Click" ImageUrl="~/img/download-button-new.png" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lbldoc4" Font-Size="16px" Text="SMA Inverter" runat="server" CssClass="form-group"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:ImageButton ID="imgdoc4" runat="server" Width="115px" OnClick="imgdoc4_Click" ImageUrl="~/img/download-button-new.png" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="lbldoc5" Font-Size="16px" Text="Fronius Inverter" runat="server" CssClass="form-group"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:ImageButton ID="imgdoc5" runat="server" Width="115px" OnClick="imgdoc5_Click" ImageUrl="~/img/download-button-new.png" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lbldoc6" Font-Size="16px" Text="Zeversolar Inverter" runat="server" CssClass="form-group"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:ImageButton ID="imgdoc6" runat="server" Width="115px" OnClick="imgdoc6_Click" ImageUrl="~/img/download-button-new.png" />
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="lbldoc7" Font-Size="16px" Text="UREnergy Inverter" runat="server" CssClass="form-group"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:ImageButton ID="imgdoc7" runat="server" Width="115px" OnClick="imgdoc7_Click" ImageUrl="~/img/download-button-new.png" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lbldoc8" Font-Size="16px" Text="Omnik Inverter" runat="server" CssClass="form-group"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:ImageButton ID="imgdoc8" runat="server" Width="115px" OnClick="imgdoc8_Click" ImageUrl="~/img/download-button-new.png" />
                                    </div>
                                </div>

                                
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="lbldoc11" Font-Size="16px" Text="Solax Power Warranty" runat="server" CssClass="form-group"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:ImageButton ID="imgdoc11" runat="server" Width="115px" OnClick="imgdoc11_Click" ImageUrl="~/img/download-button-new.png" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lbldoc12" Font-Size="16px" Text="USP PV Module" runat="server" CssClass="form-group"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:ImageButton ID="imgdoc12" runat="server" Width="115px" OnClick="imgdoc12_Click" ImageUrl="~/img/download-button-new.png" />
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="lbldoc13" Font-Size="16px" Text="Enphase_AU_NZ_Warranty" runat="server" CssClass="form-group"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:ImageButton ID="imgdoc13" runat="server" Width="115px" OnClick="imgdoc13_Click" ImageUrl="~/img/download-button-new.png" />
                                    </div>
                                  
                                </div>
                            </div>

                        </div>
                    </div>--%>
                </section>
            </section>

            <footer class="footer" style="background-color:grey; height:50px">
                
            </footer>
        </section>
    </form>
    <script src="js/jquery.js"></script>
    <script src="js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.9.2.custom.min.js"></script>
    <!-- bootstrap -->
    <script src="js/bootstrap.min.js"></script>
    <!-- nice scroll -->
    <script src="js/jquery.scrollTo.min.js"></script>
    <script src="js/jquery.nicescroll.js" type="text/javascript"></script>
    <!-- charts scripts -->
    <script src="assets/jquery-knob/js/jquery.knob.js"></script>
    <script src="js/jquery.sparkline.js" type="text/javascript"></script>
    <script src="assets/jquery-easy-pie-chart/jquery.easy-pie-chart.js"></script>
    <script src="js/owl.carousel.js"></script>
    <!-- jQuery full calendar -->
    <script src="assets/fullcalendar/fullcalendar/fullcalendar.min.js"></script>
    <!--script for this page only-->
    <script src="js/calendar-custom.js"></script>
    <!-- custom select -->
    <script src="js/jquery.customSelect.min.js"></script>
    <!--custome script for all page-->
    <script src="js/scripts.js"></script>
    <!-- custom script for this page-->
    <script src="js/sparkline-chart.js"></script>
    <script src="js/easy-pie-chart.js"></script>
    <style type="text/css" ">
    .bgcolor
    {

     background-image: url('/img/Info-Box1.png');
    display: inline-block;
    width: 209px;
    height: 96px;
  position:relative;
    text-align: center;
    vertical-align: top;
    font-size: 12px;
    }
    
    </style>
 

   
    <script>

        //knob
        $(function () {
            $(".knob").knob({
                'draw': function () {
                    $(this.i).val(this.cv + '%')
                }
            })
        });

        //carousel
        $(document).ready(function () {
            $("#owl-slider").owlCarousel({
                navigation: true,
                slideSpeed: 300,
                paginationSpeed: 400,
                singleItem: true

            });
        });

        //custom select box

        $(function () {
            $('select.styled').customSelect();
        });

    </script>
</body>
</html>

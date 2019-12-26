<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="SolarCRM.admin.dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
        <h1>Dashboard
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        </ol>
    </section>

    <section class="content">

        <!-- Info boxes -->
        <div class="row">
            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-aqua"><i class="fa fa-users"></i></span>
                    <a target="_blank" href="#">
                         <div class="col-md-4 pull-right">
                       
                            <span class="info-box-text">New Leads</span>
                            <span class="info-box-number">
                                <asp:Label ID="lblnewleads" runat="server" Text="1000"></asp:Label>
                            </span>
                       
                             </div>
                    </a>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-yellow"><i class="fa fa-users"></i></span>
                    <a target="_blank" href="#">
                        <div class="info-box-content">
                            <span class="info-box-text">Leads</span>
                            <span class="info-box-number">
                                <asp:Label ID="lblleads" runat="server"></asp:Label>
                            </span>
                        </div>
                    </a>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->

            <!-- fix for small devices only -->
            <div class="clearfix visible-sm-block"></div>

            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-green"><i class="fa fa-smile-o"></i></span>
                    <a target="_blank" href="#">
                        <div class="info-box-content">
                            <span class="info-box-text">Potential</span>
                            <span class="info-box-number">
                                <asp:Label ID="lblprospects" runat="server"></asp:Label>
                            </span>
                        </div>
                    </a>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->

        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="">
                    <div class="nav-tabs-custom">
                        <!-- Horizontal Form -->

                        <ul id="tabs" class="nav nav-tabs">
                            <li class="active"><a  href="#todays" data-toggle="tab">Todays</a></li>
                            <li><a href="#weekly"  data-toggle="tab">Weekly</a></li>
                            <li><a href="#monthly"  data-toggle="tab">Monthly</a></li>
                        </ul>


                        <div class="tab-content">

                            <div class="active tab-pane" id="todays">
                                <div class="box-body chart-responsive">
                                    <div class="chart" id="todays-chart" style="height: 300px; position: relative;"></div>
                                </div>
                            </div>

                            <div class="tab-pane" id="weekly">                             
                                <div class="box-body chart-responsive">
                                    <div class="chart" id="weekly-chart" style="height: 300px; position: relative;"></div>
                                </div>
                            </div>

                            <div class="tab-pane" id="monthly">
                                <div class="box-body chart-responsive">
                                    <div class="chart" id="month-chart" style="height: 300px; position: relative;"></div>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="box box-success">
                    <div class="box-header with-border">
                        <h3 class="box-title">Sales</h3>
                    </div>
                    <div class="box-body chart-responsive">
                        <div class="chart" id="bar-chart" style="height: 300px;"></div>
                    </div>
                </div>
            </div>

        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="nav-tabs-custom">
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="#reminder" data-toggle="tab">Reminder</a></li>
                        <li><a href="#followups" data-toggle="tab">Last 10 FollowUps</a></li>
                    </ul>
                    <div class="tab-content">
                        <div class="active tab-pane" id="reminder">

                            <%--<asp:Repeater ID="rptreminder" runat="server">
                                        <HeaderTemplate>--%>
                            <table id="example2" class="table table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th>Date</th>
                                        <th>Contact</th>
                                        <th>Description</th>


                                    </tr>
                                </thead>
                                <tbody>
                                    <%--  </HeaderTemplate>

                                        <ItemTemplate>--%>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lbldate" runat="server" Text="20 Mar 2017"></asp:Label>
                                        </td>

                                        <td>
                                            <a href="#">John Hitchcock</a>

                                        </td>

                                        <td>
                                            <asp:Label ID="lbldesc" runat="server" Text="Customer Entered on 15/03/2016. Call back mid May '16. Unemployed. Solar project pushed out to 2017."></asp:Label>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="22 Mar 2017"></asp:Label>
                                        </td>

                                        <td>
                                            <a href="#">Martin Smith</a>

                                        </td>

                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Customer Entered on 15/03/2016. Call back mid May '16. Unemployed. Solar project pushed out to 2017."></asp:Label>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="24 Mar 2017"></asp:Label>
                                        </td>

                                        <td>
                                            <a href="#">smith Yess</a>

                                        </td>

                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="Customer Entered on 15/03/2016. Call back mid May '16. Unemployed. Solar project pushed out to 2017."></asp:Label>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text="27 Mar 2017"></asp:Label>
                                        </td>

                                        <td>
                                            <a href="#">Jesicca Tailor</a>

                                        </td>

                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text="Customer Entered on 15/03/2016. Call back mid May '16. Unemployed. Solar project pushed out to 2017."></asp:Label>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Text="28 Mar 2017"></asp:Label>
                                        </td>

                                        <td>
                                            <a href="#">Jordan M.</a>

                                        </td>

                                        <td>
                                            <asp:Label ID="Label12" runat="server" Text="Customer Entered on 15/03/2016. Call back mid May '16. Unemployed. Solar project pushed out to 2017."></asp:Label>
                                        </td>

                                    </tr>

                                    <%-- </ItemTemplate>

                                        <FooterTemplate>--%>
                                </tbody>

                            </table>
                            <%-- </FooterTemplate>
                                    </asp:Repeater>--%>

                            <div class="box-footer clearfix">
                                <a href="#" class="btn btn-sm btn-default btn-flat pull-right">View All Reminders</a>

                            </div>

                        </div>
                        <!-- /.tab-pane -->
                        <div class="tab-pane" id="followups">


                            <%-- <asp:Repeater ID="rptfollowups" runat="server">
                                        <HeaderTemplate>--%>
                            <table id="example3" class="table table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th>Date</th>
                                        <th>Contact</th>
                                        <th>Description</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <%--  </HeaderTemplate>
                                        <ItemTemplate>--%>

                                    <tr>

                                        <td>
                                            <asp:Label ID="lbldate1" runat="server" Text="24 Feb 2017"></asp:Label>
                                        </td>
                                        <td>
                                            <a href="#">John Yazdani</a>

                                        </td>
                                        <td>
                                            <asp:Label ID="lbldesc1" runat="server" Text="Customer Entered on 05/05/2016. Quote emailed. Call back late May, or mornings on Mondays."></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:Label ID="Label13" runat="server" Text="21 Feb 2017"></asp:Label>
                                        </td>
                                        <td>
                                            <a href="#">Smith Tailor</a>

                                        </td>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" Text="Customer Entered on 05/05/2016. Quote emailed. Call back late May, or mornings on Mondays."></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:Label ID="Label16" runat="server" Text="20 Feb 2017"></asp:Label>
                                        </td>
                                        <td>
                                            <a href="#">Martin Yazdani</a>

                                        </td>
                                        <td>
                                            <asp:Label ID="Label18" runat="server" Text="Customer Entered on 05/05/2016. Quote emailed. Call back late May, or mornings on Mondays."></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:Label ID="Label19" runat="server" Text="19 Feb 2017"></asp:Label>
                                        </td>
                                        <td>
                                            <a href="#">Paul walk</a>

                                        </td>
                                        <td>
                                            <asp:Label ID="Label21" runat="server" Text="Customer Entered on 05/05/2016. Quote emailed. Call back late May, or mornings on Mondays."></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:Label ID="Label22" runat="server" Text="17 Feb 2017"></asp:Label>
                                        </td>
                                        <td>
                                            <a href="#">Reyan Yazdani</a>

                                        </td>
                                        <td>
                                            <asp:Label ID="Label24" runat="server" Text="Customer Entered on 05/05/2016. Quote emailed. Call back late May, or mornings on Mondays."></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:Label ID="Label25" runat="server" Text="16 Feb 2017"></asp:Label>
                                        </td>
                                        <td>
                                            <a href="#">Phill Yess</a>

                                        </td>
                                        <td>
                                            <asp:Label ID="Label27" runat="server" Text="Customer Entered on 05/05/2016. Quote emailed. Call back late May, or mornings on Mondays."></asp:Label>
                                        </td>
                                    </tr>
                                    <%-- </ItemTemplate>
                                        <FooterTemplate>--%>
                                </tbody>
                            </table>

                            <%-- </FooterTemplate>
                                    </asp:Repeater>--%>

                            <div class="box-footer clearfix">
                                <a href="#" class="btn btn-sm btn-default btn-flat pull-right">View All FollowUps</a>
                            </div>

                        </div>
                        <!-- /.tab-pane -->
                    </div>
                </div>
                <!-- /.nav-tabs-custom -->
            </div>
        </div>


    </section>

    <script src="<%=SiteURL%>/plugins/jQuery/jQuery-2.2.0.min.js"></script>
    <script>
        $(function () {
            debugger;
            var Planned = "";
            var OnHold = "";
            var Active = "";
            var Completed = "";
            var Cancelled = "";
            var Rec = "";

            var wPlanned = "";
            var wOnHold = "";
            var wActive = "";
            var wCompleted = "";
            var wCancelled = "";
            var wRec = "";

            var mPlanned = "";
            var mOnHold = "";
            var mActive = "";
            var mCompleted = "";
            var mCancelled = "";
            var mRec = "";
            $.ajax({
                type: 'POST',
                url: 'dashboard.aspx/GetPiechartTodaysData',
                data: {},
                dataType: 'json',
                async: false,
                contentType: "application/json; charset=utf-8",

                success: function (data) {
                    // data = result.d;

                    "use strict";
                    Planned = data.d.Planned;
                    OnHold = data.d.OnHold;
                    Active = data.d.Active;
                    Completed = data.d.Complete;
                    Cancelled = data.d.Cancelled;
                   
                    wOnHold = data.d.wOnHold;
                    wPlanned = data.d.wPlanned;
                    wActive = data.d.wActive;
                    wCompleted = data.d.wComplete;
                    wCancelled = data.d.wCancelled;

                    mOnHold = data.d.mOnHold;
                    mPlanned = data.d.mPlanned;
                    mActive = data.d.mActive;
                    mCompleted = data.d.mComplete;
                    mCancelled = data.d.mCancelled;
                    //DONUT CHART
                    var donut = new Morris.Donut({
                        element: 'todays-chart',
                        resize: true,
                        colors: ["#3c8dbc", "#f56954", "#00a65a", "#FBBA00", "#FF7F2A", "#000000"],
                        data: [
                          { label: "Planned", value: Planned },
                          { label: "On Hold", value: OnHold },
                           { label: "Active", value: Active },
                           { label: "Completed", value: Completed },
                            { label: "Dep. Rec", value: 1200 },
                             { label: "Cancelled", value: Cancelled }
                        ],
                        hideHover: 'auto'
                    });

                    //DONUT CHART
                    var donuta = new Morris.Donut({
                        element: 'weekly-chart',
                        resize: true,
                        colors: ["#3c8dbc", "#f56954", "#00a65a", "#FBBA00", "#FF7F2A", "#000000"],
                        data: [
                          { label: "Planned", value: wPlanned },
                          { label: "On Hold", value: wOnHold },
                           { label: "Active", value: wActive },
                           { label: "Completed", value: wCompleted },
                            { label: "Dep. Rec", value: 1200 },
                             { label: "Cancelled", value: wCancelled }
                        ],
                        hideHover: 'auto'
                    });

            //Donut Chart
                    var donutb = new Morris.Donut({
                      
                element: 'month-chart',
                resize: true,
                colors: ["#3c8dbc", "#f56954", "#00a65a", "#FBBA00", "#FF7F2A", "#000000"],
                data: [
                  { label: "Planned", value: mPlanned },
                  { label: "On Hold", value: mOnHold },
                   { label: "Active", value: mActive },
                   { label: "Completed", value: mCompleted },
                    { label: "Dep. Rec", value: 1200 },
                     { label: "Cancelled", value: mCancelled }
                ],
                hideHover: 'auto'
            });
        },
            error: function (xhr, status, error) {
                alert(error);
            }
        });
        //BAR CHART
            var bar = new Morris.Bar({
                element: 'bar-chart',
                resize: true,
                data: [
                  { y: '2011', a: 100, b: 90 },
                  { y: '2012', a: 75, b: 65 },
                  { y: '2013', a: 50, b: 40 },
                  { y: '2014', a: 75, b: 65 },
                  { y: '2015', a: 50, b: 40 },
                  { y: '2016', a: 75, b: 65 },
                  { y: '2017', a: 100, b: 90 }
                ],
                barColors: ['#00a65a', '#f56954'],
                xkey: 'y',
                ykeys: ['a', 'b'],
                labels: ['CPU', 'DISK'],
                hideHover: 'auto'
            });



        });
       

    </script>

</asp:Content>






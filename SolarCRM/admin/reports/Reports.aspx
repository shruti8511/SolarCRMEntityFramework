<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="SolarCRM.admin.reports.Reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/PagingUserControl/PagingUserControl.ascx" TagPrefix="uc1" TagName="page" %>
<%@ Register Src="~/PagingUserControl/Paggingctrl.ascx" TagPrefix="uc2" TagName="page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Reports </h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/reports/Reports.aspx"><i class="fa fa-dashboard"></i>Dashboard</a></li>
            <li><a href="#">Reports</a></li>

        </ol>
    </section>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div id="OrderList" class="form-horizontal tblresponsive">
                                <table class="table table-bordered table-bordered" id="tblreports">
                                    <thead>
                                        <tr class="form-group">
                                            <th class="nosort col-sm-3" style="background-color: #559ad9; color: white;"><i class="fa fa-pencil-square-o"></i>&nbsp;Report</th>
                                            <th class="nosort col-sm-9" style="background-color: #96ca84; color: white;"><i class="fa fa-file-text-o"></i>&nbsp;Status</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr class="form-group" id="trclear">

                                            <td style="background-color: lightgray;">
                                                <div id="leadreport" class=" box box-widget widget-user-2" style="background: rgba(255,255,255,0.50); padding: 10px; height: 80vh;">
                                                    <!-- Add the bg color to the header using any of the bg-* classes -->
                                                    <b>
                                                        <h3 style="color: #559ad9">Lead report</h3>
                                                    </b>
                                                    <ul>
                                                        <li><asp:LinkButton ID="lnkTodayLead" runat="server"  OnClick="lnkTodayLead_Click">Today Lead</asp:LinkButton></li>
                                                        <li><asp:LinkButton ID="lnkThisWeek" runat="server" OnClick="lnkThisWeek_Click">This Week Leads</asp:LinkButton></li>
                                                        <li><asp:LinkButton ID="lnkthismonth" runat="server" OnClick="lnkthismonth_Click">This Month Leads</asp:LinkButton></li>
                                                        <li><asp:LinkButton ID="lnkAllLead" runat="server" OnClick="lnkAllLead_Click">All</asp:LinkButton></li>


                                                    </ul>
                                                    <!-- Add the bg color to the header using any of the bg-* classes -->
                                                    <b>
                                                        <h3 style="color: #559ad9">Project report</h3>
                                                    </b>
                                                    <ul>
                                                        <li><asp:LinkButton ID="lnkActiveProject" runat="server"  OnClick="lnkActiveProject_Click">Active Project</asp:LinkButton></li>
                                                        <li><asp:LinkButton ID="lnkClosedProject" runat="server"  OnClick="lnkClosedProject_Click">Closed Project</asp:LinkButton></li>
                                                        <li><asp:LinkButton ID="lnkCompletedProject" runat="server" OnClick="lnkCompletedProject_Click">Completed Project</asp:LinkButton></li>
                                                        <li><asp:LinkButton ID="lnkCancelledProject" runat="server"  OnClick="lnkCancelledProject_Click">Cancelled Project</asp:LinkButton></li>

                                                       
                                                    </ul>
                                                </div>

                                            </td>

                                            <td style="background-color: lightskyblue;">
                                             
                                                <div class="row" id="divcompanylist" runat="server">
                                                    <div class="col-md-12">
                                                       <div class="box box-primary" style="width:100%">
                                                            <div class="box-header">

                                                                <div class="col-md-6 pull-right">

                                                                    <div class="input-group input-group-sm">
                                                                       <%-- <asp:TextBox ID="txtSearch" ClientIDMode="Static" runat="server" placeholder="search keyword" class="form-control"></asp:TextBox>
                                                                        <span class="input-group-btn">
                                                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-info btn-flat" Text="Search" OnClick="btnSearch_Click" />
                                                                            <asp:Button ID="btnClear" runat="server" class="btn btn-default" Text="Clear" OnClick="btnClear_Click" />
                                                                        </span>--%>
                                                                    </div>
                                                                </div>


                                                            </div>
                                                            <!-- /.box-header -->
                                                            <div class="box-body table-scrollable1">
                                                                <asp:Repeater ID="rptCompanylist" runat="server" OnItemDataBound="rptCompanylist_ItemDataBound">
                                                                    <HeaderTemplate>
                                                                        <table id="example2" class="table table-bordered table-hover">
                                                                            <thead>
                                                                                <tr>
                                                                                    <th class="text-center">Company Name</th>
                                                                                    <th class="text-center">Address</th>
                                                                                    <th class="text-center">Location</th>
                                                                                    <th class="text-center">Project Type</th>
                                                                                    <th class="text-center">Customer Type</th>
                                                                                    <th class="text-center">Phone</th>
                                                                                    <th class="text-center">Assigned To</th>
                                                                                    <%-- <th class="text-center">Detail</th>--%>
                                                                                    <%-- <th class="text-center">Edit</th>--%>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>

                                                                        <tr>
                                                                            <td>

                                                                                <asp:HiddenField ID="hndEmployeeID" runat="server" Value='<%#Eval("EmployeeID") %>' />
                                                                                <asp:HiddenField ID="hdnCustomerID" runat="server" Value='<%#Eval("CustomerID") %>' />

                                                                                <asp:Label ID="lblZone" runat="server" Text='<%#Eval("Customer") %>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("StreetAddress") %>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Location") %>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("ProjectType") %>'></asp:Label></td>

                                                                            <td>
                                                                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("ProjectType") %>'></asp:Label></td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("CustMobile") %>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("AssignedTo") %>'></asp:Label></td>
                                                                            <%-- <td class="text-center">
                                                                                <span>
                                                                                    <asp:LinkButton ID="lnkDetail" runat="server" ToolTip="Detail" CommandName="Detail"
                                                                                        CommandArgument='<%# Eval("CustomerID") %>'><i class="fa fa-hand-o-right"></i>
                                                                                    </asp:LinkButton>
                                                                                </span>
                                                                            </td>--%>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </tbody>

                                                                </table>
                                                                    </FooterTemplate>
                                                                </asp:Repeater>
                                                                <div>
                                                                    <%--<uc1:page ID="pageGrid" runat="server" Visible="true" OnPagerChanged="Pager_Changed" />--%>
                                                                </div>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </div>

                                                    </div>
                                                    <!-- /.col -->
                                                </div>

                                                <div class="row" id="divprojectlist" runat="server" visible="false">
                                                    <div class="col-md-12">
                                                        <div class="box box-primary" style="width:85vh">
                                                            <div class="box-header">

                                                                <div class="col-md-6 pull-right">

                                                                    <div class="input-group input-group-sm">
                                                                    <%--    <asp:TextBox ID="txtSearch1" ClientIDMode="Static" runat="server" placeholder="search keyword" class="form-control"></asp:TextBox>
                                                                        <span class="input-group-btn">
                                                                            <asp:Button ID="btnSearch1" runat="server" class="btn btn-info btn-flat" Text="Search" OnClientClick="return validate1()" OnClick="btnSearch1_Click" />
                                                                            <asp:Button ID="btnClear1" runat="server" class="btn btn-default" Text="Clear" OnClick="btnClear1_Click" />
                                                                        </span>--%>
                                                                    </div>
                                                                </div>


                                                            </div>
                                                            <!-- /.box-header -->
                                                            <div class="box-body table-scrollable1">
                                                                <asp:Repeater ID="rptProjectlist" runat="server" OnItemDataBound="rptProjectlist_ItemDataBound">
                                                                    <HeaderTemplate>
                                                                        <table id="example2" class="table table-bordered table-hover">
                                                                            <thead>
                                                                                <tr>
                                                                                    <th>Project No.</th>
                                                                                    <th>Man#</th>
                                                                                    <th>Project Type</th>
                                                                                    <th>Project Status</th>
                                                                                    <th>Customer</th>
                                                                                    <th>Contact</th>
                                                                                    <th>Project Opened</th>
                                                                                    <th>Location</th>
                                                                                    <th>Area</th>
                                                                                    <th>City</th>
                                                                                    <th>State</th>
                                                                                    <th>Installer Notes</th>
                                                                                    <%--  <th>Updated By</th>--%>
                                                                                    
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>

                                                                        <tr>
                                                                            <td>
                                                                                <asp:HiddenField ID="hdnProjectId" runat="server" Value='<%#Eval("ProjectID") %>' />

                                                                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("ProjectNumber") %>'></asp:Label></td>

                                                                            <td>
                                                                                <asp:Label ID="lblMan" runat="server" Text='<%#Eval("ManualQuoteNumber") %>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblProjectType" runat="server" Text='<%#Eval("ProjectType") %>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblProjectStatus" runat="server" Text='<%#Eval("ProjectStatus") %>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblCustomer" runat="server" Text='<%#Eval("CustomerName") %>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblContact" runat="server" Text='<%#Eval("ContactNO") %>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblProjectOpened" runat="server" Text='<%#Eval("ProjectOpened", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("Location") %>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblArea" runat="server" Text='<%#Eval("InstallArea") %>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblCity" runat="server" Text='<%#Eval("InstallCity") %>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblState" runat="server" Text='<%#Eval("InstallState") %>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblInstallerNotes" runat="server" Text='<%#Eval("InstallerNotes") %>'></asp:Label></td>
                                                                            <%--  <td>
                                                <asp:Label ID="lblUpdatedby" runat="server" Text='<%#Eval("UpdateBy") %>'></asp:Label></td>
                                                                            --%>
                                                                         


                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </tbody>

                                                                   </table>
                                                                    </FooterTemplate>
                                                                </asp:Repeater>
                                                             <%--   <div>
                                                                    <uc1:page ID="page1" runat="server" Visible="true" OnPagerChanged="Pager_Changed" />
                                                                </div>--%>
                                                            </div>
                                                            <!-- /.box-body -->
                                                        </div>
                                                        
                                                    </div>
                                                    <!-- /.col -->
                                                </div>
                                            
                                            </td>

                                        </tr>

                                    </tbody>
                                </table>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </section>
            <script>
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_pageLoaded(pageLoaded);
                //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
                prm.add_beginRequest(BeginRequestHandler);
                // Raised after an asynchronous postback is finished and control has been returned to the browser.
                prm.add_endRequest(EndRequestHandler);
                function BeginRequestHandler(sender, args) {
                    //Shows the modal popup - the update progress
                    var popup = $find('<%= newmodalPopup.ClientID %>');
                      if (popup != null) {
                          popup.show();
                      }
                  }
                  function EndRequestHandler(sender, args) {
                      //Hide the modal popup - the update progress
                      var popup = $find('<%= newmodalPopup.ClientID %>');
                    if (popup != null) {
                        popup.hide();
                    }
                    if (args.get_error() != undefined) {
                        args.set_errorHandled(true);
                    }
                }
                function pageLoaded() {
                    //alert($(".search-select").attr("class"));
                    $(".select2").select2({
                        placeholder: "Select",
                        allowClear: true
                    });

                    $('.datepicker').datepicker({
                        autoclose: true,
                    });

                    if ($(".tooltips").length) {
                        $('.tooltips').tooltip();
                    }
                    $(function () {
                        var $progressnote = $('.slideProgressBoard');
                        $('#clickme2').click(function (e) {
                            e.stopPropagation();
                            if ($progressnote.is(":hidden")) {
                                $progressnote.slideDown("slow");
                            } else {
                                $progressnote.slideUp("slow");
                            }
                        }); $('.slideProgressBoard').click(function (e) {
                            e.stopPropagation();
                        });
                        $(document.body).click(function () {
                            if ($progressnote.not(":hidden")) {
                                $progressnote.slideUp("slow");
                            }
                        });
                    });
                }
            </script>

            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
                <ProgressTemplate>
                    <div>
                        <asp:Image ID="imgloading" ImageUrl="~/Content/img/progressbar.gif" ClientIDMode="Static" AlternateText="Processing"
                            runat="server" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>

            <asp:ModalPopupExtender ID="newmodalPopup" runat="server" TargetControlID="UpdateProgress1"
                PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup1" />

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

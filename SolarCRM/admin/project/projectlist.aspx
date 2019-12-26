<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="projectlist.aspx.cs" Inherits="SolarCRM.admin.project.projectlist" %>

<%@ Register Src="~/PagingUserControl/PagingUserControl.ascx" TagPrefix="uc1" TagName="page" %>
<%@ Register Src="~/PagingUserControl/Paggingctrl.ascx" TagPrefix="uc2" TagName="page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
        <h1>Projects</h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>DashBoard</a></li>
            <li>Project</li>
            <li class="active">Project List</li>
        </ol>
    </section>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="content-header">
                <div class="col-md-12">
                    <div id="divAlert" runat="server" class="alert alert-danger alert-dismissible" visible="false">
                        <asp:Button ID="btnalert" class="close" runat="server" Text="x" OnClick="btnalert_Click" />
                        <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
                    </div>

                    <div id="divSuccess" runat="server" class="alert alert-success alert-dismissible" visible="false">
                        <asp:Button ID="btnSuccess" class="close" runat="server" Text="x" OnClick="btnSuccess_Click" />
                        <asp:Label ID="lblSuccessMsg" runat="server"></asp:Label>
                    </div>

                </div>
            </div>

            <section class="content">

                <div class="row" id="divprojectlist" runat="server">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header">

                                <div class="col-md-6 pull-right">

                                    <div class="input-group input-group-sm">
                                        <asp:TextBox ID="txtSearch" ClientIDMode="Static" runat="server" placeholder="search keyword" class="form-control"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-info btn-flat" Text="Search" OnClientClick="return validate()" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btnClear" runat="server" class="btn btn-default" Text="Clear" OnClick="btnClear_Click" />
                                        </span>
                                    </div>
                                </div>


                            </div>
                            <!-- /.box-header -->
                            <div class="box-body table-scrollable1">
                                <asp:Repeater ID="rptProjectlist" runat="server" OnItemCommand="rptProjectlist_ItemCommand" OnItemDataBound="rptProjectlist_ItemDataBound">
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
                                                    <th>Detail</th>
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
                                            <td class="text-center">
                                                <span>
                                                    <asp:LinkButton ID="lnkDetail" runat="server" ToolTip="Detail" CommandName="Detail"
                                                        CommandArgument='<%# Eval("ProjectID") %>'><i class="fa fa-hand-o-right"></i>
                                                    </asp:LinkButton>
                                                </span>
                                            </td>


                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>

                                    </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <div>
                                    <uc1:page ID="pageGrid" runat="server" Visible="true" OnPagerChanged="Pager_Changed" />
                                </div>
                            </div>
                            <!-- /.box-body -->
                        </div>

                    </div>
                    <!-- /.col -->
                </div>

                <div id="divprojectdetails" runat="server" visible="false" clintidmode="static">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="box box-info">

                                <div class="box-header">
                                    <h4>Details</h4>
                                </div>

                                <div class="box-body">

                                    <div class="nav-tabs-custom">
                                        <ul class="nav nav-tabs">
                                            <li id="lisip" class="active" runat="server"><a href="#sip" data-toggle="tab">Sales</a></li>

                                            <li id="lifncc" runat="server"><a href="#fnc" data-toggle="tab">Finance</a></li>
                                            <li id="liinvc" runat="server"><a href="#invc" data-toggle="tab">Invoice</a></li>
                                            <li id="lipt" runat="server"><a href="#projectteam" data-toggle="tab">Team</a></li>
                                            <li id="liins" runat="server"><a href="#ins" data-toggle="tab">Installation</a></li>
                                            <li id="limntc" runat="server"><a href="#mntc" data-toggle="tab">Mtce</a></li>
                                            <li id="lidcms" runat="server"><a href="#dcms" data-toggle="tab">Docs</a></li>
                                            <li id="licnvs" runat="server"><a href="#cnvs" data-toggle="tab">Conversation</a></li>
                                            <li id="liprtr" runat="server"><a href="#prtr" data-toggle="tab">Track</a></li>
                                            <li id="liexpen" runat="server"><a href="#expen" data-toggle="tab">Expenses</a></li>

                                        </ul>
                                        <div class="tab-content">
                                            <div class="tab-pane active" id="sip" runat="server" clientidmode="static">
                                                <div class="form-horizontal">
                                                    <div class="box-body">

                                                        <div class="panel-group" id="accordionsalesip" role="tablist" aria-multiselectable="true">

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingprojdetail">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionsalesip" href="#collapseprojdetail" aria-expanded="false" aria-controls="collapseprojdetail">Project Detail
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapseprojdetail" class="panel-collapse in" role="tabpanel" aria-labelledby="headingprojdetail">
                                                                    <div class="panel-body">

                                                                        <div class="form-group">

                                                                            <div class="col-md-3">
                                                                                <label>Project Type</label>
                                                                                <asp:DropDownList ID="ddlProjectType" runat="server" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <%-- <asp:TextBox ID="TextBox13" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                                                            </div>

                                                                            <div class="col-md-3">
                                                                                <label>Project Mgr</label>
                                                                                <asp:DropDownList ID="ddlProjectMgr" runat="server" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>

                                                                            </div>

                                                                            <div class="col-md-3">
                                                                                <label>Sales Rep.</label>
                                                                                <asp:DropDownList ID="ddlSalesRep" runat="server" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>

                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label>Project Opened</label>
                                                                                <asp:TextBox ID="txtProjectOpend" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

                                                                            </div>

                                                                        </div>

                                                                        <div class="form-group">

                                                                            <div class="col-md-3">
                                                                                <label>FollowUp Date</label>
                                                                                <div class="input-group date">
                                                                                    <div class="input-group-addon">
                                                                                        <i class="fa fa-calendar"></i>
                                                                                    </div>
                                                                                    <asp:TextBox ID="txtFollowUpDate" class="form-control pull-right datepicker" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="col-md-3">
                                                                                <label>Lead Gen</label>
                                                                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>

                                                                            </div>

                                                                            <div class="col-md-3">
                                                                                <label>Contact</label>
                                                                                <asp:DropDownList ID="ddlContact" runat="server" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>

                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label>Manual Quote No.</label>
                                                                                <asp:TextBox ID="txtManualQuoteNumber" runat="server" CssClass="form-control"></asp:TextBox>

                                                                            </div>

                                                                        </div>

                                                                        <div class="form-group">

                                                                            <div class="col-md-4">
                                                                                <label>FollowUp</label>
                                                                                <asp:TextBox ID="txtFollowUpNote" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>

                                                                            </div>

                                                                        </div>

                                                                    </div>

                                                                </div>

                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingsalesipproduct">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionsalesip" href="#collapsesalesipproduct" aria-expanded="false" aria-controls="collapsesalesipproduct">Product
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsesalesipproduct" class="panel-collapse in" role="tabpanel" aria-labelledby="headingsalesipproduct">
                                                                    <div class="panel-body">

                                                                        <div class="form-group">


                                                                            <div class="col-md-3">
                                                                                <label>Panel</label>
                                                                                <asp:DropDownList ID="ddlPanel" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>


                                                                            <div class="col-md-1" style="padding: 24px 12px; font-size: 17px">
                                                                                <label></label>
                                                                                <asp:Label runat="server" ID="multiply" Text="X"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-1">
                                                                                <label></label>
                                                                                <asp:TextBox ID="txtNoOfPanels" runat="server" CssClass="form-control" OnTextChanged="txtNoOfPanels_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-md-1">
                                                                                <label></label>
                                                                                <asp:TextBox ID="txtSystemCapacity" runat="server" CssClass="form-control"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-md-1" style="padding: 24px 12px; font-size: 17px">
                                                                                <label></label>
                                                                                <asp:Label runat="server" ID="Label5" Text="KW"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>Inv1</label>
                                                                                <asp:DropDownList ID="ddlInverter1" runat="server" CssClass="form-control select2" TabIndex="10" Style="width: 100%;" OnSelectedIndexChanged="ddlInverter1_SelectedIndexChanged" AutoPostBack="true">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label>Inv2</label>
                                                                                <asp:DropDownList ID="ddlInverter2" runat="server" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>


                                                                        </div>

                                                                        <div class="form-group">

                                                                            <div class="col-md-12">

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-1">Model </label>
                                                                                    <div class="col-sm-2">
                                                                                        <asp:TextBox ID="txtInverterModel" class="form-control" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                    <label class="col-sm-1">Inv Cert </label>
                                                                                    <div class="col-sm-2">
                                                                                        <asp:TextBox ID="txtInverterCert1" class="form-control" runat="server"></asp:TextBox>
                                                                                    </div>

                                                                                    <div class="col-sm-2">
                                                                                        <asp:TextBox ID="txtPerKWCost" class="form-control" runat="server" OnTextChanged="txtPerKWCost_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                    </div>

                                                                                </div>

                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingsystemcosting">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionsalesip" href="#collapsesystemcosting" aria-expanded="false" aria-controls="collapsesystemcosting">System Costing
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsesystemcosting" class="panel-collapse in" role="tabpanel" aria-labelledby="headingsystemcosting">
                                                                    <div class="panel-body">
                                                                        <div class="col-md-6">

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Base System Cost </label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtBasicSystemCost" class="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">
                                                                                    <asp:DropDownList ID="ddlHouseType" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtHouseType" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">
                                                                                    <asp:DropDownList ID="ddlRoofType" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtRoofType" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">
                                                                                    <asp:DropDownList ID="ddlRoofAngle" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtRoofAngle" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">
                                                                                    <asp:DropDownList ID="ddlMeterinst" runat="server" CssClass="form-control select2"
                                                                                        AppendDataBoundItems="true" TabIndex="12">
                                                                                        <asp:ListItem Value="">Meter Installation</asp:ListItem>
                                                                                        <asp:ListItem Value="1">YES</asp:ListItem>
                                                                                        <asp:ListItem Value="2">NO</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtMeterinst" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <%-- <div class="form-group">
                                                                                <label class="col-sm-6">
                                                                                    <asp:DropDownList ID="ddlOther1" runat="server" CssClass="form-control select2"
                                                                                        AppendDataBoundItems="true" TabIndex="12">
                                                                                        <asp:ListItem Value="">Other1</asp:ListItem>
                                                                                        <asp:ListItem Value="5">Asbestos</asp:ListItem>
                                                                                        <asp:ListItem Value="1">Meter Upgrade</asp:ListItem>
                                                                                        <asp:ListItem Value="2">Cherry Picker</asp:ListItem>
                                                                                        <asp:ListItem Value="3">Travel Cost</asp:ListItem>
                                                                                        <asp:ListItem Value="4">Other</asp:ListItem>
                                                                                        <asp:ListItem Value="6">Meter Isolator</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtOtherCost" class="form-control" runat="server" OnTextChanged="txtOtherCost_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                </div>
                                                                            </div>--%>


                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Other Charges</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtOtherCost" class="form-control" runat="server" OnTextChanged="txtOtherCost_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                </div>
                                                                            </div>


                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">GST</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtGST" class="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                                                </div>
                                                                            </div>



                                                                        </div>

                                                                        <div class="col-md-6">

                                                                            <%--  <div class="form-group">
                                                                                <label class="col-sm-6">Other Charges</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtOtherCharges" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>--%>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Special Discount</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtSpecialDiscount" class="form-control" runat="server" OnTextChanged="txtSpecialDiscount_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Total Cost</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtTotalCost" class="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Deposit Require</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtDepositRequired" class="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Balance To Pay</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtBaltoPay" class="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Payment Plan</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="TextBox144" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingmeterdetails">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionsalesip" href="#collapsemeterdetails" aria-expanded="false" aria-controls="collapsemeterdetails">Meter Details
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsemeterdetails" class="panel-collapse in" role="tabpanel" aria-labelledby="headingmeterdetails">
                                                                    <div class="panel-body">

                                                                        <div class="col-md-6">

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Meter Phase 1-2-3 </label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtMeterPhase" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Is System Off-Peak</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:CheckBox ID="chkOffPeak" runat="server"></asp:CheckBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Enough Meter Space</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:CheckBox ID="chkMeterEnoughSpace" runat="server"></asp:CheckBox>

                                                                                </div>
                                                                            </div>

                                                                            <%--  <div class="form-group">
                                                                                <label class="col-sm-6">NMI / Acc No</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="TextBox146" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>--%>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Peak Meter No</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtPeakMeterNumber" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                        </div>

                                                                        <div class="col-md-6">

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Off-Peak Meter No</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtMeterNumber" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Distributor</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:DropDownList ID="ddlElecDistributor" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Retailer</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:DropDownList ID="ddlElecRetailer" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">STC Number</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtSTCNumber" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingfreebies">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionsalesip" href="#collapsefreebies" aria-expanded="false" aria-controls="collapsefreebies">Freebies / Promo Items
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsefreebies" class="panel-collapse in" role="tabpanel" aria-labelledby="headingfreebies">
                                                                    <div class="panel-body">

                                                                        <div class="col-md-6">

                                                                            <div class="form-group">
                                                                                <label class="col-sm-4">Promo 1 </label>
                                                                                <div class="col-sm-8">
                                                                                    <asp:DropDownList ID="ddlPromoOffer" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-4">Promo 2 </label>
                                                                                <div class="col-sm-8">
                                                                                    <asp:DropDownList ID="ddlPromoOffer2" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-4">Quotation Notes </label>
                                                                                <div class="col-sm-8">
                                                                                    <asp:TextBox ID="txtQuotationNotes" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-4">First QuoteSent </label>
                                                                                <div class="col-sm-8">
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtQuoteSent" class="form-control pull-right datepicker" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                            </div>


                                                                        </div>

                                                                        <div class="col-md-6">

                                                                            <div class="form-group">
                                                                                <label class="col-sm-4">Quote Accepted </label>
                                                                                <div class="col-sm-8">
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtQuoteAccepted" class="form-control pull-right datepicker" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-4">Sign Quote Stored</label>
                                                                                <div class="col-sm-8">
                                                                                    <asp:CheckBox runat="server" ID="chkSignedQuote" />
                                                                                    <asp:FileUpload runat="server" ID="FileUpload4" />
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-4">Project Notes </label>
                                                                                <div class="col-sm-8">
                                                                                    <asp:TextBox ID="txtProjectNotes" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-4">Quotes </label>
                                                                                <div class="col-sm-8">

                                                                                    <asp:ImageButton ID="btnCreateQuotes" runat="server" ImageUrl="../../Content/img/btn_create_new_quote.png"
                                                                                        OnClick="btnCreateQuotes_Click" CausesValidation="false" />

                                                                                </div>
                                                                            </div>



                                                                            <div class="box">
                                                                                <div class="box-header">
                                                                                    <h3 class="box-title">
                                                                                    Quotes
                                                                                </div>
                                                                                <!-- /.box-header -->
                                                                                <div class="box-body table-scrollable1">
                                                                                    <asp:Repeater ID="rptQuote" runat="server" OnItemDataBound="rptQuote_ItemDataBound">
                                                                                        <HeaderTemplate>
                                                                                            <table id="Table1" class="table table-bordered table-hover">
                                                                                                <thead>
                                                                                                    <tr>
                                                                                                        <th>Quote Date</th>
                                                                                                        <th>Doc No.</th>
                                                                                                        <th>Document</th>

                                                                                                    </tr>
                                                                                                </thead>
                                                                                                <tbody>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="ProjectQuoteDate" runat="server" Text='<%#Eval("ProjectQuoteDate", "{0:ddd - dd MMM yyyy}") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Label ID="ProjectQuoteDoc" runat="server" Text='<%#Eval("ProjectQuoteDoc") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:HiddenField ID="hndProjectQuoteID" runat="server" Value='<%#Eval("ProjectQuoteID") %>' />
                                                                                                    <asp:HyperLink ID="hypDoc" runat="server" ToolTip="SignedQuote" Target="_blank">
                                                                                                        <asp:Image ID="imgDoc" runat="server" ImageUrl="../../Content/img/icon_document_downalod.png" />
                                                                                                    </asp:HyperLink>

                                                                                                </td>


                                                                                            </tr>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            </tbody>
                                        </table>
                                                                                        </FooterTemplate>
                                                                                    </asp:Repeater>

                                                                                </div>
                                                                                <!-- /.box-body -->
                                                                            </div>



                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingdocument">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionsalesip" href="#collapsedocument" aria-expanded="false" aria-controls="collapsedocument">Documents
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsedocument" class="panel-collapse in" role="tabpanel" aria-labelledby="headingdocument">
                                                                    <div class="panel-body">

                                                                        <div class="form-group">
                                                                            <div class="col-md-3">
                                                                                <label>Meter Photo</label>
                                                                                <asp:CheckBox ID="chkMeterBoxPhotosSaved" runat="server"></asp:CheckBox>

                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label>Electricity Bill</label>
                                                                                <asp:CheckBox ID="chkElecBillSaved" runat="server"></asp:CheckBox>

                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label>Site Map</label>
                                                                                <asp:CheckBox ID="chkSiteMap" runat="server"></asp:CheckBox>

                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label>Payment Receipt</label>
                                                                                <asp:CheckBox ID="chkPaymentReceipt" runat="server"></asp:CheckBox>

                                                                            </div>
                                                                        </div>
                                                                      
                                                                        <div class="form-group">
                                                                            <div class="col-md-3">
                                                                                <label>Meter Approval</label>
                                                                                <asp:CheckBox ID="chkMeterApproval" runat="server"></asp:CheckBox>

                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label>Other Documents</label>
                                                                                <asp:FileUpload ID="FLUPDocuments" runat="server"></asp:FileUpload>

                                                                            </div>

                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>


                                                        </div>

                                                    </div>

                                                    <div class="box-footer">
                                                        <asp:Button ID="btnCancelSalesInout" runat="server" TabIndex="20" CssClass="btn btn-default" Text="Cancel" />
                                                        <asp:Button ID="btnSaveSalesInput" runat="server" TabIndex="21" CssClass="btn btn-info pull-right" Text="Save" OnClick="btnSaveSalesInput_Click" />
                                                    </div>

                                                </div>
                                            </div>

                                            <div class="tab-pane" id="fnc" runat="server" clientidmode="static">
                                                <div class="form-horizontal">
                                                    <div class="box-body">

                                                        <div class="panel-group" id="accordionfinance" role="tablist" aria-multiselectable="true">

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingappdetail">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionfinance" href="#collapseappdetail" aria-expanded="false" aria-controls="collapseappdetail">Application Detail
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapseappdetail" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingappdetail">
                                                                    <div class="panel-body">

                                                                        <div class="form-group">
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Application Date : </label>
                                                                                    <div class="col-sm-8">
                                                                                        <div class="input-group date">
                                                                                            <div class="input-group-addon">
                                                                                                <i class="fa fa-calendar"></i>
                                                                                            </div>
                                                                                            <asp:TextBox ID="TextBox45" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Applied By : </label>
                                                                                    <div class="col-sm-8">
                                                                                        <select class="form-control">
                                                                                            <option>option 1</option>
                                                                                            <option>option 2</option>
                                                                                            <option>option 3</option>
                                                                                            <option>option 4</option>
                                                                                            <option>option 5</option>
                                                                                        </select>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Purchase No. : </label>
                                                                                    <div class="col-sm-8">

                                                                                        <asp:TextBox ID="TextBox47" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <div class="form-group">
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Document SentDate: </label>
                                                                                    <div class="col-sm-8">
                                                                                        <div class="input-group date">
                                                                                            <div class="input-group-addon">
                                                                                                <i class="fa fa-calendar"></i>
                                                                                            </div>
                                                                                            <asp:TextBox ID="TextBox48" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Document Sent By : </label>
                                                                                    <div class="col-sm-8">
                                                                                        <select class="form-control">
                                                                                            <option>option 1</option>
                                                                                            <option>option 2</option>
                                                                                            <option>option 3</option>
                                                                                            <option>option 4</option>
                                                                                            <option>option 5</option>
                                                                                        </select>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Verification No. : </label>
                                                                                    <div class="col-sm-8">

                                                                                        <asp:TextBox ID="TextBox50" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                </div>

                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingdocrec">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionfinance" href="#collapsedocrec" aria-expanded="false" aria-controls="collapsedocrec">Document Receive from Customer
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsedocrec" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingdocrec">
                                                                    <div class="panel-body">
                                                                        <div class="form-group">
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Document Received Date : </label>
                                                                                    <div class="col-sm-8">
                                                                                        <div class="input-group date">
                                                                                            <div class="input-group-addon">
                                                                                                <i class="fa fa-calendar"></i>
                                                                                            </div>
                                                                                            <asp:TextBox ID="TextBox51" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Document Received By: </label>
                                                                                    <div class="col-sm-8">
                                                                                        <select class="form-control">
                                                                                            <option>option 1</option>
                                                                                            <option>option 2</option>
                                                                                            <option>option 3</option>
                                                                                            <option>option 4</option>
                                                                                            <option>option 5</option>
                                                                                        </select>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Document Verified : </label>
                                                                                    <div class="col-sm-8">

                                                                                        <asp:CheckBox ID="chkdocverified" runat="server"></asp:CheckBox>
                                                                                        <asp:FileUpload ID="flupdocument" runat="server" />

                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <div class="form-group">
                                                                            <div class="col-md-4">
                                                                            </div>
                                                                            <div class="col-md-4">

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Expire Date : </label>
                                                                                    <div class="col-sm-8">
                                                                                        <div class="input-group date">
                                                                                            <div class="input-group-addon">
                                                                                                <i class="fa fa-calendar"></i>
                                                                                            </div>
                                                                                            <asp:TextBox ID="TextBox53" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Satisfaction Report : </label>
                                                                                    <div class="col-sm-8">

                                                                                        <asp:CheckBox ID="CheckBox6" runat="server"></asp:CheckBox><asp:Label runat="server" ID="lblreport" Text="34343.pdf"></asp:Label>
                                                                                        <asp:FileUpload ID="FileUpload1" runat="server" />

                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                </div>

                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingdocsent">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionfinance" href="#collapsedocsent" aria-expanded="false" aria-controls="collapsedocsent">Document Sent By Company
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsedocsent" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingdocsent">
                                                                    <div class="panel-body">

                                                                        <div class="form-group">
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Sent By : </label>
                                                                                    <div class="col-sm-8">
                                                                                        <select class="form-control">
                                                                                            <option>option 1</option>
                                                                                            <option>option 2</option>
                                                                                            <option>option 3</option>
                                                                                            <option>option 4</option>
                                                                                            <option>option 5</option>
                                                                                        </select>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Sent Date </label>
                                                                                    <div class="col-sm-8">
                                                                                        <div class="input-group date">
                                                                                            <div class="input-group-addon">
                                                                                                <i class="fa fa-calendar"></i>
                                                                                            </div>
                                                                                            <asp:TextBox ID="TextBox46" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Postal Tracking No. </label>
                                                                                    <div class="col-sm-8">
                                                                                        <asp:TextBox ID="TextBox49" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <div class="form-group">

                                                                            <div class="col-md-4">

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Remarks: </label>
                                                                                    <div class="col-sm-8">

                                                                                        <asp:TextBox ID="TextBox56" class="form-control" runat="server" TextMode="MultiLine" TabIndex="7"></asp:TextBox>

                                                                                    </div>
                                                                                </div>

                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                </div>

                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingpayrec">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionfinance" href="#collapsepayrec" aria-expanded="false" aria-controls="collapsepayrec">Payment Receive
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsepayrec" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingpayrec">
                                                                    <div class="panel-body">
                                                                        <div class="form-group">
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Received Date: </label>
                                                                                    <div class="col-sm-8">
                                                                                        <div class="input-group date">
                                                                                            <div class="input-group-addon">
                                                                                                <i class="fa fa-calendar"></i>
                                                                                            </div>
                                                                                            <asp:TextBox ID="TextBox57" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Received By:: </label>
                                                                                    <div class="col-sm-8">
                                                                                        <select class="form-control">
                                                                                            <option>option 1</option>
                                                                                            <option>option 2</option>
                                                                                            <option>option 3</option>
                                                                                            <option>option 4</option>
                                                                                            <option>option 5</option>
                                                                                        </select>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Payment Received: </label>
                                                                                    <div class="col-sm-8">
                                                                                        <asp:TextBox ID="TextBox54" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                    </div>

                                                                </div>

                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingfndetail">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionfinance" href="#collapsefndetail" aria-expanded="false" aria-controls="collapsefndetail">Finance Detail
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsefndetail" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingfndetail">
                                                                    <div class="panel-body">
                                                                        <div class="form-group">

                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Finance With: </label>
                                                                                    <div class="col-sm-8">
                                                                                        <select class="form-control">
                                                                                            <option>option 1</option>
                                                                                            <option>option 2</option>
                                                                                            <option>option 3</option>
                                                                                            <option>option 4</option>
                                                                                            <option>option 5</option>
                                                                                        </select>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Finance With Sub: </label>
                                                                                    <div class="col-sm-8">
                                                                                        <select class="form-control">
                                                                                            <option>option 1</option>
                                                                                            <option>option 2</option>
                                                                                            <option>option 3</option>
                                                                                            <option>option 4</option>
                                                                                            <option>option 5</option>
                                                                                        </select>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Approval Status:</label>
                                                                                    <div class="col-sm-8">
                                                                                        <select class="form-control">
                                                                                            <option>option 1</option>
                                                                                            <option>option 2</option>
                                                                                            <option>option 3</option>
                                                                                            <option>option 4</option>
                                                                                            <option>option 5</option>
                                                                                        </select>
                                                                                    </div>
                                                                                </div>


                                                                            </div>

                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Total Purchase: </label>
                                                                                    <div class="col-sm-8">
                                                                                        <asp:TextBox ID="TextBox52" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Finance Months: </label>
                                                                                    <div class="col-sm-8">
                                                                                        <asp:TextBox ID="TextBox55" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                                    </div>
                                                                                </div>


                                                                            </div>


                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Finance Notes: </label>
                                                                                    <div class="col-sm-8">
                                                                                        <asp:TextBox ID="TextBox58" class="form-control" runat="server" TextMode="MultiLine" TabIndex="7"></asp:TextBox>

                                                                                    </div>
                                                                                </div>


                                                                            </div>


                                                                        </div>
                                                                    </div>

                                                                </div>

                                                            </div>

                                                        </div>

                                                    </div>
                                                    <!-- /.box-body -->
                                                    <div class="box-footer">
                                                        <asp:Button ID="btnSaveFinance" runat="server" TabIndex="17" CssClass="btn btn-default" Text="Cancel" />
                                                        <asp:Button ID="btnCancelFinance" runat="server" TabIndex="18" CssClass="btn btn-info pull-right" Text="Save" />
                                                    </div>
                                                    <!-- /.box-footer -->
                                                </div>
                                            </div>

                                            <div class="tab-pane" id="invc" runat="server" clientidmode="static">
                                                <div class="form-horizontal">
                                                    <div class="box-body">

                                                        <div class="panel-group" id="accordioninvoice" role="tablist" aria-multiselectable="true">

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingsysdetail">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninvoice" href="#collapsesysdetail" aria-expanded="false" aria-controls="collapsesysdetail">System Detail
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsesysdetail" class="panel-collapse in" role="tabpanel" aria-labelledby="headingsysdetail">
                                                                    <div class="panel-body">

                                                                        <div class="form-group">
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">House Type</label>
                                                                                    <div class="col-sm-8">

                                                                                        <asp:TextBox ID="TextBox59" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Roof Type</label>
                                                                                    <div class="col-sm-8">

                                                                                        <asp:TextBox ID="TextBox61" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Roof Angle</label>
                                                                                    <div class="col-sm-8">

                                                                                        <asp:TextBox ID="TextBox62" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                            </div>

                                                                            <div class="col-md-4">

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">System Details</label>
                                                                                    <div class="col-sm-8">

                                                                                        <asp:TextBox ID="TextBox63" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Other Variations</label>
                                                                                    <div class="col-sm-8">

                                                                                        <asp:TextBox ID="TextBox64" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Travel Dist</label>
                                                                                    <div class="col-sm-8">

                                                                                        <asp:TextBox ID="TextBox65" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Split System</label>
                                                                                    <div class="col-sm-8">

                                                                                        <asp:CheckBox ID="chkSplitSystem" runat="server"></asp:CheckBox>

                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Cert Saved</label>
                                                                                    <div class="col-sm-8">

                                                                                        <asp:CheckBox ID="chkCertSaved" runat="server"></asp:CheckBox>

                                                                                    </div>
                                                                                </div>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Chery Picker</label>
                                                                                    <div class="col-sm-8">

                                                                                        <asp:CheckBox ID="CheckBox7" runat="server"></asp:CheckBox>

                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">STC Saved</label>
                                                                                    <div class="col-sm-8">

                                                                                        <asp:CheckBox ID="CheckBox8" runat="server"></asp:CheckBox>

                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                    </div>

                                                                </div>

                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingcrinv">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninvoice" href="#collapsecrinv" aria-expanded="false" aria-controls="collapsecrinv">Create Invoice
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsecrinv" class="panel-collapse in" role="tabpanel" aria-labelledby="headingcrinv">
                                                                    <div class="panel-body">
                                                                        <div class="col-xs-12">
                                                                            <div class="form-group">

                                                                                <div class="col-md-4">
                                                                                    <div class="form-group">
                                                                                        <div class="col-sm-6">
                                                                                            <asp:Button ID="btnCreateInvoice" runat="server" CssClass="btn btn-info pull-right" Text="Create Invoice" Enabled="false" OnClick="btnCreateInvoice_Click" />
                                                                                            <asp:Button ID="btnOpenInvoice" runat="server" CssClass="btn btn-info pull-right" Text="Open Invoice" Visible="false" OnClick="btnOpenInvoice_Click" />

                                                                                        </div>
                                                                                        <div class="col-sm-6">
                                                                                            Legal
                                                                <asp:CheckBox runat="server" ID="chkLegal" />
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group">
                                                                                        <label class="col-sm-4">Invoice No</label>
                                                                                        <div class="col-sm-8">

                                                                                            <asp:TextBox ID="TextBox72" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group">
                                                                                        <label class="col-sm-4">Deposit Rec</label>
                                                                                        <div class="col-sm-8">
                                                                                            <div class="input-group date">
                                                                                                <div class="input-group-addon">
                                                                                                    <i class="fa fa-calendar"></i>
                                                                                                </div>
                                                                                                <asp:TextBox ID="TextBox60" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group">
                                                                                        <label class="col-sm-4">Verify Date</label>
                                                                                        <div class="col-sm-8">
                                                                                            <div class="input-group date">
                                                                                                <div class="input-group-addon">
                                                                                                    <i class="fa fa-calendar"></i>
                                                                                                </div>
                                                                                                <asp:TextBox ID="TextBox66" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>

                                                                                <div class="col-md-4">
                                                                                    <div class="form-group">
                                                                                        <div class="col-sm-12">
                                                                                            <asp:Button ID="btnInvoicePay" runat="server" CssClass="btn btn-info" Text="Edit Invoice Payment" OnClick="btnInvoicePay_Click" />

                                                                                        </div>

                                                                                    </div>

                                                                                    <div class="form-group">
                                                                                        <label class="col-sm-4">Invoice Sent</label>
                                                                                        <div class="col-sm-8">
                                                                                            <div class="input-group date">
                                                                                                <div class="input-group-addon">
                                                                                                    <i class="fa fa-calendar"></i>
                                                                                                </div>
                                                                                                <asp:TextBox ID="TextBox67" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>


                                                                                    <div class="form-group">
                                                                                        <label class="col-sm-4">Invoice Doc</label>
                                                                                        <div class="col-sm-8">

                                                                                            <asp:TextBox ID="TextBox71" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group">
                                                                                        <label class="col-sm-6">Total Paid:  0.00 </label>
                                                                                        <label class="col-sm-6">
                                                                                            Bal Owing: 0.00
                                                                                        </label>
                                                                                    </div>

                                                                                </div>

                                                                                <div class="col-md-4">
                                                                                    <div class="form-group">
                                                                                        <div class="col-sm-12">
                                                                                            <asp:Button ID="Button12" runat="server" CssClass="btn btn-info" Text="Check Active" />

                                                                                        </div>

                                                                                    </div>

                                                                                    <div class="form-group">
                                                                                        <div class="col-sm-12">
                                                                                            <asp:Button ID="Button13" runat="server" CssClass="btn btn-info" Text="Welcome Docs" />

                                                                                        </div>

                                                                                    </div>

                                                                                    <div class="form-group">
                                                                                        <label class="col-sm-6">Ignore WLP</label>
                                                                                        <div class="col-sm-6">
                                                                                            <asp:CheckBox runat="server" ID="chkIgnoreWLP" />
                                                                                        </div>
                                                                                    </div>


                                                                                </div>

                                                                            </div>


                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingsalesver">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninvoice" href="#collapsesalesver" aria-expanded="false" aria-controls="collapsesalesver">Sales Verification
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsesalesver" class="panel-collapse in" role="tabpanel" aria-labelledby="headingsalesver">
                                                                    <div class="panel-body">
                                                                        <div class="form-group">

                                                                            <div class="col-md-4">

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-6">
                                                                                        Sales Verification
                                                                                    </label>
                                                                                    <div class="col-sm-6">

                                                                                        <asp:CheckBox runat="server" ID="chkSalesVerification" />
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-6">
                                                                                        Attach Recording Attachment
                                                                                    </label>
                                                                                    <div class="col-sm-6">

                                                                                        <asp:CheckBox runat="server" ID="CheckBox9" />
                                                                                        <asp:FileUpload runat="server" ID="flupattachtrecording" />
                                                                                    </div>
                                                                                </div>

                                                                            </div>

                                                                            <div class="col-md-4">

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Verification Comment</label>
                                                                                    <div class="col-sm-8">

                                                                                        <asp:TextBox ID="TextBox73" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                                    </div>
                                                                                </div>

                                                                            </div>

                                                                            <div class="col-md-4">

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Sales Verification Date</label>
                                                                                    <div class="col-sm-8">
                                                                                        <div class="input-group date">
                                                                                            <div class="input-group-addon">
                                                                                                <i class="fa fa-calendar"></i>
                                                                                            </div>
                                                                                            <asp:TextBox ID="TextBox68" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                </div>

                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingsolarinspay">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninvoice" href="#collapsesolarinspay" aria-expanded="false" aria-controls="collapsesolarinspay">Solar Installer Payment
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsesolarinspay" class="panel-collapse in" role="tabpanel" aria-labelledby="headingsolarinspay">
                                                                    <div class="panel-body">

                                                                        <div class="form-group">
                                                                            <div class="col-md-6">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Select Type</label>
                                                                                    <div class="col-md-8">
                                                                                        <asp:DropDownList runat="server" ID="gridMonedaEdit" CssClass="form-control select2" Style="width: 100%">
                                                                                            <asp:ListItem Value="MONEDA"> MONEDA </asp:ListItem>
                                                                                            <asp:ListItem Value="USD"> USD </asp:ListItem>
                                                                                            <asp:ListItem Value="MONEDA/USD"> MONEDA/USD </asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </div>
                                                                                </div>

                                                                            </div>

                                                                            <div class="col-md-6">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-6">Sales Comm Paid</label>
                                                                                    <div class="col-sm-6">
                                                                                        <asp:CheckBox runat="server" ID="chksalescommpaid" />
                                                                                    </div>
                                                                                </div>
                                                                            </div>

                                                                        </div>

                                                                    </div>

                                                                </div>

                                                            </div>

                                                        </div>


                                                    </div>
                                                    <!-- /.box-body -->
                                                    <div class="box-footer">
                                                        <asp:Button ID="btncnclInvoice" runat="server" CssClass="btn btn-default" Text="Cancel" />
                                                        <asp:Button ID="btnSaveInvoice" runat="server" CssClass="btn btn-info pull-right" Text="Save" />
                                                    </div>
                                                    <!-- /.box-footer -->

                                                </div>
                                            </div>

                                            <div class="tab-pane" id="projectteam" runat="server" clientidmode="static">

                                                <section class="content">
                                                    <div class="row">

                                                        <div class="form-horizontal">
                                                            <div class="box-body">

                                                                <div class="panel-group" id="accordionprojectteam" role="tablist" aria-multiselectable="true">

                                                                    <div class="panel panel-default box box-info">
                                                                        <div class="box-header with-border" role="tab" id="headingprojectteam">
                                                                            <h4 class="panel-title">
                                                                                <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninvoice" href="#collapsesysdetail" aria-expanded="false" aria-controls="collapsesysdetail">Project Team
                                                                                </a>
                                                                            </h4>
                                                                        </div>
                                                                        <div id="collapseprojectteam" class="panel-collapse in" role="tabpanel" aria-labelledby="headingsysdetail">
                                                                            <div class="panel-body">

                                                                                <div class="form-group">
                                                                                    <asp:Literal runat="server" ID="ltrProjectTeam"></asp:Literal>

                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- /.box-body -->
                                                            <div class="box-footer">
                                                                <asp:Button ID="Button17" runat="server" CssClass="btn btn-default" Text="Cancel" />
                                                            <asp:Button ID="btnSaveProjectTeam" runat="server" CssClass="btn btn-info pull-right" Text="Save" ClientIDMode="Static" /> </div>
                                                            <!-- /.box-footer -->
                                                        </div>

                                                        <div class="col-md-12">
                                                            <div class="box box-primary">
                                                                <div class="box-header">
                                                                    <div class="col-md-6">
                                                                        <h3 class="box-title">Project Team List</h3>
                                                                    </div>
                                                                    <div class="col-md-6 pull-right">

                                                                        <%-- <div class="input-group input-group-sm">
                                                                            <asp:TextBox ID="TextBox5" ClientIDMode="Static" runat="server" placeholder="search keyword" class="form-control"></asp:TextBox>
                                                                            <span class="input-group-btn">
                                                                                <asp:Button ID="Button1" runat="server" class="btn btn-info btn-flat" Text="Search" />
                                                                                <asp:Button ID="Button2" runat="server" class="btn btn-default" Text="Clear" />
                                                                            </span>
                                                                        </div>--%>
                                                                    </div>


                                                                </div>
                                                                <!-- /.box-header -->
                                                                <div class="box-body table-scrollable1">
                                                                    <asp:Repeater ID="rptProjectTeamList" runat="server">
                                                                        <HeaderTemplate>
                                                                            <table id="Table1" class="table table-bordered table-hover">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th class="text-center">Task</th>
                                                                                        <th class="text-center">Employee</th>
                                                                                        <th class="text-center">Created Date</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <tr>
                                                                                <td class="text-center">
                                                                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("Task") %>'></asp:Label>
                                                                                </td>
                                                                                <td class="text-center">
                                                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("EmployeeName") %>'></asp:Label>
                                                                                </td>

                                                                                <td class="text-center">
                                                                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("CreatedOn","{0:dd/M/yyyy}") %>'></asp:Label>
                                                                                </td>

                                                                            </tr>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            </tbody>
                                        </table>
                                                                        </FooterTemplate>
                                                                    </asp:Repeater>

                                                                    <%-- <div>
                                    <uc1:page ID="page1" runat="server" Visible="true" OnPagerChanged="Pager_Changed" />
                                </div>--%>
                                                                </div>
                                                                <!-- /.box-body -->
                                                            </div>

                                                        </div>

                                                    </div>
                                                </section>

                                            </div>

                                           <%-- <div class="tab-pane" id="ins" runat="server" clientidmode="static">
                                                <div class="form-horizontal">
                                                    <div class="box-body">


                                                        <div class="panel-group" id="accordioninstallation" role="tablist" aria-multiselectable="true">

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headinggridapp">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninstallation" href="#collapsegridapp" aria-expanded="false" aria-controls="collapsegridapp">GRID APPLICATION & REX
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsegridapp" class="panel-collapse in" role="tabpanel" aria-labelledby="headinggridapp">
                                                                    <div class="panel-body">

                                                                        <div class="col-md-6">

                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>Meter Applied: </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtMeterApplied" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Meter Apply Ref.: </label>

                                                                                    <asp:TextBox ID="txtMeterApplyRef" class="form-control" runat="server"></asp:TextBox>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Mtr Approval: </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtMeterApproval" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Mtr Approval Ref.:</label>

                                                                                    <asp:TextBox ID="txtMeterApprovalRef" class="form-control" runat="server"></asp:TextBox>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>REX Applied Date: </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtRexApplied" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>REX Applied Ref.: </label>

                                                                                    <asp:TextBox ID="txtRexAppliedRef" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>REX Status: </label>
                                                                                    <asp:DropDownList ID="ddlRexStatus" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                            </div>

                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <h4>
                                                                                        <label>Existing system Details</label>
                                                                                    </h4>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Panel Model: </label>

                                                                                    <asp:TextBox ID="txtPanelModel" class="form-control" runat="server"></asp:TextBox>

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>No. Of Panel: </label>

                                                                                    <asp:TextBox ID="txtNoOfPanel" class="form-control" runat="server"></asp:TextBox>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Inv Model: </label>

                                                                                    <asp:TextBox ID="txtInvModel" class="form-control" runat="server"></asp:TextBox>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>No. Of Inv: </label>

                                                                                    <asp:TextBox ID="txtNoOfInv" class="form-control" runat="server"></asp:TextBox>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Meter Type: </label>
                                                                                    <asp:DropDownList ID="ddlMeterType" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                        <asp:ListItem Value="1">Net Meter</asp:ListItem>
                                                                                        <asp:ListItem Value="2">Gross Meter</asp:ListItem>
                                                                                    </asp:DropDownList>

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label></label>

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Customer Notified Meter/REX: </label>
                                                                                    <asp:CheckBox runat="server" ID="chkcustnotmeter" />
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingpreins">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninstallation" href="#collapsepreins" aria-expanded="false" aria-controls="collapsegridapp">PRE INSTALLATION
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsepreins" class="panel-collapse in" role="tabpanel" aria-labelledby="headingpreins">
                                                                    <div class="panel-body">

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>Initial Install Date </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtInitialInstallDate" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Install Booking Date </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtInstallBookDate" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <div class="col-sm-3">
                                                                                        <label>AM </label>
                                                                                        <br />
                                                                                        <asp:CheckBox ID="chkAM1" runat="server"></asp:CheckBox>
                                                                                        <asp:CheckBox ID="chkAM2" runat="server"></asp:CheckBox>

                                                                                    </div>
                                                                                    <div class="col-sm-3">
                                                                                        <label>PM </label>
                                                                                        <br />
                                                                                        <asp:CheckBox ID="chkPM1" runat="server"></asp:CheckBox>
                                                                                        <asp:CheckBox ID="chkPM2" runat="server"></asp:CheckBox>
                                                                                    </div>
                                                                                    <div class="col-sm-6">
                                                                                        <label>Days </label>
                                                                                        <asp:TextBox ID="txtdays" CssClass="form-control" runat="server"></asp:TextBox>

                                                                                    </div>

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <asp:Button ID="btnInstallerDetails" runat="server" CssClass="btn btn-info" Text="Installer Details" />

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Installer: </label>

                                                                                    <asp:DropDownList ID="ddlInstaller" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;" OnSelectedIndexChanged="ddlInstaller_SelectedIndexChanged" AutoPostBack="true">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Designer: </label>
                                                                                    <asp:DropDownList ID="ddlDesigner" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>


                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-6">
                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>Electrician: </label>
                                                                                    <asp:DropDownList ID="ddlElectrician" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Installer Notified: </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtInstallerNotified" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Cust Notified of Install Date: </label>
                                                                                    <asp:CheckBox runat="server" ID="chkcustnotfy" />
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Installation Issue: </label>
                                                                                    <asp:DropDownList ID="ddlInstallationIssue" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Stock Allocation Store </label>
                                                                                    <asp:DropDownList ID="ddlStockAllocationStore" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label></label>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label><a href="#">Stock Allocation Pick List </a></label>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Special Purpose: </label>
                                                                                    <asp:DropDownList ID="ddlSpecialPurpose" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingpostins">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninstallation" href="#collapsepostins" aria-expanded="false" aria-controls="collapsepostins">POST INSTALLATION
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsepostins" class="panel-collapse in" role="tabpanel" aria-labelledby="headingpostins">
                                                                    <div class="panel-body">

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>Install Complete </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtInstallComplete" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Install Verified By </label>

                                                                                    <asp:TextBox ID="txtInstallVerifiedBy" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Install Docs Rec </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtInstallDocsRec" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Installation confirmed a day prior </label>
                                                                                    <asp:CheckBox runat="server" ID="chkinsconfdayprior" />
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>
                                                                                        STC Checked 
                                                                                        <asp:CheckBox runat="server" ID="chkSTC" />
                                                                                        By</label>
                                                                                    <asp:DropDownList ID="ddlSTC" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Certificate Issued </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtCertificateIssued" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Inv Serial No </label>
                                                                                    <asp:TextBox ID="txtInvSerialNo" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>



                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>2nd Inv Serial No </label>
                                                                                    <asp:TextBox ID="txtInvSerialNo2" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label></label>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <asp:Button ID="btnPanelSerialNo" runat="server" CssClass="btn btn-info" Text="Panel Serial No" />

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Meter Elec: </label>
                                                                                    <asp:DropDownList ID="ddlMeterElec" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Mtr Inst Docs Sent: </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtMtrInstDocs" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Meter Job Booked: </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtMeterJobBooked" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Meter Completed: </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtMeterCompleted" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label></label>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>CCEW </label>
                                                                                    <asp:CheckBox runat="server" ID="chkCCEW" />
                                                                                </div>
                                                                            </div>

                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingmeterins">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninstallation" href="#collapsemeterins" aria-expanded="false" aria-controls="collapsemeterins">STC & METER INSTALLATION
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsemeterins" class="panel-collapse in" role="tabpanel" aria-labelledby="headingmeterins">
                                                                    <div class="panel-body">

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>STC Form Saved </label>
                                                                                    <asp:CheckBox runat="server" ID="chkstcformsaved" Checked="true" />
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label><a href="#">123Saved.pdf</a></label>
                                                                                    <asp:FileUpload runat="server" ID="FileUpload3" />

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Certificate Saved </label>
                                                                                    <asp:CheckBox runat="server" ID="chkCertificateSaved" Checked="true" />
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label><a href="#">123CerSaved.pdf</a></label>
                                                                                    <asp:FileUpload runat="server" ID="FileUpload2" />

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label></label>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <asp:Button ID="BTNSendMail" runat="server" CssClass="btn btn-info" Text="Send Mail" />

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Additional System </label>

                                                                                    <asp:CheckBox runat="server" ID="chkAdditionalSystem" />
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Owner GST Reg </label>

                                                                                    <asp:CheckBox runat="server" ID="chkOwnerGSTReg" />
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Company ABN</label>

                                                                                    <asp:TextBox runat="server" ID="txtCompanyABN" CssClass="form-control" />
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label></label>

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>New Model Panel? </label>

                                                                                    <asp:CheckBox runat="server" ID="chkNewModelPanel1" />
                                                                                </div>

                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label><a href="#"><i class="fa fa-file"></i>Create STC</a></label>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>New Model Inv? </label>

                                                                                    <asp:CheckBox runat="server" ID="chkNewModelInv" />
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>STC Applied Date </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtSTCAppliedDate" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>STC Upload Number </label>

                                                                                    <asp:TextBox ID="txtSTCUploadNumber" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>PVD Number </label>

                                                                                    <asp:TextBox ID="txtPVDNumber" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>PVD Status</label>
                                                                                    <asp:DropDownList ID="ddlPVDStatus" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>STC Applied By</label>
                                                                                    <asp:DropDownList ID="ddlSTCAppliedBy" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>

                                                    </div>
                                                    <!-- /.box-body -->
                                                    <div class="box-footer">
                                                        <asp:Button ID="btncnclinstallation" runat="server" CssClass="btn btn-default" Text="Cancel" OnClick="btncnclinstallation_Click" />
                                                        <asp:Button ID="btnsaveinstallation" runat="server" CssClass="btn btn-info pull-right" Text="Save" OnClick="btnsaveinstallation_Click" />
                                                    </div>
                                                    <!-- /.box-footer -->

                                                </div>

                                            </div>--%>

                                             <div class="tab-pane" id="ins" runat="server" clientidmode="static">
                                                <div class="form-horizontal">
                                                    <div class="box-body">


                                                        <div class="panel-group" id="accordioninstallation" role="tablist" aria-multiselectable="true">

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headinggridapp">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninstallation" href="#collapsegridapp" aria-expanded="false" aria-controls="collapsegridapp">PRE GEDA APPLICATION
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsegridapp" class="panel-collapse in" role="tabpanel" aria-labelledby="headinggridapp">
                                                                    <div class="panel-body">

                                                                        <div class="col-md-6">

                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>GEDA Applied: </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtGedaApplied" class="form-control pull-right datepicker" runat="server" TabIndex="1"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>GEDA Apply Ref.: </label>

                                                                                    <asp:TextBox ID="txtGedaApplyRef" class="form-control" runat="server"></asp:TextBox>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Geda Approval: </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtGedaApproval" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Geda Approval Ref.:</label>

                                                                                    <asp:TextBox ID="txtGedaApprovalRef" class="form-control" runat="server"></asp:TextBox>

                                                                                </div>
                                                                          </div>

                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>Electricity Board </label>
                                                                                    <asp:DropDownList ID="ddlElectricityBoard" runat="server" AppendDataBoundItems="true" CssClass="form-control select2"  Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                         
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                                 <div class="col-sm-12">
                                                                                    <label>Geda Status</label>
                                                                                    <asp:DropDownList ID="ddlGedaStatus" runat="server" AppendDataBoundItems="true" CssClass="form-control select2"  Style="width: 100%;">
                                                                                      <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                          <asp:ListItem Value="1" Text="Applied">Applied</asp:ListItem>
                                                                                          <asp:ListItem Value="2" Text="Approved">Approved</asp:ListItem>
                                                                                          <asp:ListItem Value="3" Text="Cancel">Cancel</asp:ListItem>
                                                                                          <asp:ListItem Value="4" Text="New">New</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                 <div class="col-sm-12">
                                                                                    <label>Geda Deposit</label>
                                                                                    <asp:DropDownList ID="ddlGedaDeposit" runat="server" AppendDataBoundItems="true" CssClass="form-control select2"  Style="width: 100%;">
                                                                                       
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                          <asp:ListItem Value="1" Text="Company">Comapny</asp:ListItem>
                                                                                          <asp:ListItem Value="2" Text="Customer">Customer</asp:ListItem>
                                                                                         
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                          
                                                                                  <div class="col-sm-12">
                                                                                    <label>Approval Letter</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldApprovalLetter" />

                                                                                </div>
                                                                                  <div class="col-sm-12">
                                                                                    <label>Registration Form</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldregistration" />

                                                                                </div>

                                                                             

                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                              <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingceig">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninstallation" href="#collapseceig" aria-expanded="false" aria-controls="collapseceig">PRE CEIG APPLICATION
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapseceig" class="panel-collapse in" role="tabpanel" aria-labelledby="headingceig">
                                                                    <div class="panel-body">

                                                                        <div class="col-md-6">

                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>CEIG Applied: </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtCeigAppliedDate" class="form-control pull-right datepicker" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                 <div class="col-sm-12">
                                                                                    <label>CEIG Applied Ref.:</label>

                                                                                    <asp:TextBox ID="txtceigappliedref" class="form-control" runat="server"></asp:TextBox>

                                                                                </div>
                                                                                 <div class="col-sm-12">
                                                                                    <label>CEIG Approval: </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtCeigApprovalDate" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>CEIG Approval Ref.: </label>

                                                                                    <asp:TextBox ID="txtCeigApprovalRef" class="form-control" runat="server"></asp:TextBox>

                                                                                </div>
                                                                               
                                                                              <div class="col-sm-12">
                                                                                    <label>Drawing</label>
                                                                                    <asp:FileUpload runat="server" ID="fileuplddrawing" />

                                                                                </div>
                                                                               

                                                                            </div>

                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">

                                                                                 <div class="col-sm-12">
                                                                                    <label>Net Meter Deposit</label>
                                                                                    <asp:DropDownList ID="ddlNetMeterDeposit" runat="server" AppendDataBoundItems="true" CssClass="form-control select2"  Style="width: 100%;">
                                                                                         <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                          <asp:ListItem Value="1" Text="Company">Comapny</asp:ListItem>
                                                                                          <asp:ListItem Value="2" Text="Customer">Customer</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                                 <div class="col-sm-12">
                                                                                    <label>CEIG Status: </label>
                                                                                    <asp:DropDownList ID="txtCeigStatus" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" Style="width: 100%;">
                                                                                         <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                          <asp:ListItem Value="1" Text="Applied">Applied</asp:ListItem>
                                                                                          <asp:ListItem Value="2" Text="Approved">Approved</asp:ListItem>
                                                                                          <asp:ListItem Value="3" Text="Cancel">Cancel</asp:ListItem>
                                                                                          <asp:ListItem Value="4" Text="New">New</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                                
                                                                                  <div class="col-sm-12">
                                                                                    <label>Approval Letter</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldApprovalLetterCeig" />

                                                                                </div>
                                                                                 <div class="col-sm-12">
                                                                                    <label>Covering Letter</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldCoveringLetter" />

                                                                                </div>
                                                                           
                                                                              <div class="col-md-12"><label><br /></label></div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Customer Notified Meter/ CEIG: </label>
                                                                                    <asp:CheckBox runat="server" ID="chkCustomerNotifiedMeter" />
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingpreins">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninstallation" href="#collapsepreins" aria-expanded="false" aria-controls="collapsegridapp">PRE INSTALLATION
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsepreins" class="panel-collapse in" role="tabpanel" aria-labelledby="headingpreins">
                                                                    <div class="panel-body">

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">

                                                                                 <div class="col-sm-12">
                                                                                    <label>NOC for Dispatch</label>
                                                                                    <asp:CheckBox runat="server" ID="chkNocDispatced" />
                                                                                </div>
                                                                                 <div class="col-sm-12">
                                                                                    <label>Material Dispatched Date </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtMaterialDispatchedDate" class="form-control pull-right datepicker" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                
                                                                                <div class="col-sm-12">
                                                                                    <label>Installer: </label>

                                                                                    <asp:DropDownList ID="ddlInstaller" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;" >
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>

                                                                                </div>

                                                                                  <div class="col-sm-12">
                                                                                    <label>Installation Issue: </label>
                                                                                    <asp:DropDownList ID="ddlInstallationIssue" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Stock Allocation Store </label>
                                                                                    <asp:DropDownList ID="ddlStockAllocationStore" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                 <div class="col-sm-12">
                                                                                    <label>NOC Dispatched Letter</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldNocDispatched" />

                                                                                </div>


                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-6">
                                                                            <div class="form-group">
                                                                                  <div class="col-sm-12">
                                                                                    <label>Installation Start Date </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtinstallationstartdate" class="form-control pull-right datepicker" runat="server" ></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Installer Notified </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtInstallerNotifiedDate" class="form-control pull-right datepicker" runat="server" ></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <div class="col-sm-3">
                                                                                        <label>AM </label>
                                                                                        <br />
                                                                                        <asp:CheckBox ID="chkAM1" runat="server"></asp:CheckBox>
                                                                                        <asp:CheckBox ID="chkAM2" runat="server"></asp:CheckBox>

                                                                                    </div>
                                                                                    <div class="col-sm-3">
                                                                                        <label>PM </label>
                                                                                        <br />
                                                                                        <asp:CheckBox ID="chkPM1" runat="server"></asp:CheckBox>
                                                                                        <asp:CheckBox ID="chkPM2" runat="server"></asp:CheckBox>
                                                                                    </div>
                                                                                    <div class="col-sm-6">
                                                                                        <label>Days </label>
                                                                                        <asp:TextBox ID="txtdays" CssClass="form-control" runat="server"></asp:TextBox>

                                                                                    </div>

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <asp:Button ID="btnInstallerDetails" runat="server" CssClass="btn btn-info" Text="Installer Details" />

                                                                                </div>

                                                                              
                                                                                 <div class="col-sm-12">
                                                                                    <label></label>

                                                                                </div>
                                                                               
                                                                                <div class="col-sm-12">
                                                                                    <label>Cust Notified of Install Date: </label>
                                                                                    <asp:CheckBox runat="server" ID="chkcustnotfy" />
                                                                                </div>
                                                                              
                                                                                <div class="col-sm-12">
                                                                                    <label></label>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label><a href="#">Stock Allocation Pick List </a></label>

                                                                                </div>
                                                                              

                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingpostins">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninstallation" href="#collapsepostins" aria-expanded="false" aria-controls="collapsepostins">POST INSTALLATION
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsepostins" class="panel-collapse in" role="tabpanel" aria-labelledby="headingpostins">
                                                                    <div class="panel-body">

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>Install Complete </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtInstallComplete" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Install Verified By </label>
                                                                                  <asp:DropDownList ID="ddlPostInstallverifyby" runat="server" CssClass="form-control select2" TabIndex="1" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList> 
                                                                               
                                                                                </div>

                                                                                 <div class="col-sm-12">
                                                                                    <label>Mtr Sent For Test: </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtmtrsentfortest" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Meter Job Booked: </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtMeterJobBooked" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                  <div class="col-sm-12">
                                                                                    <label>Covering Letter</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldPostCoveringletter" />

                                                                                </div>

                                                                            
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">
                                                                                   <div class="col-sm-12 pull-right">
                                                                                    <asp:Button ID="btnInvSerialNo" runat="server" CssClass="btn btn-info" Text="INV Serial No" />

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Inv Serial No </label>
                                                                                    <asp:TextBox ID="txtInvSerialNo" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>2nd Inv Serial No </label>
                                                                                    <asp:TextBox ID="txtInvSerialNo2" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label></label>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <asp:Button ID="btnPanelSerialNo" runat="server" CssClass="btn btn-info" Text="Panel Serial No" />

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Meter Completed: </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtMeterCompleted" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label></label>

                                                                                </div>
                                                                              
                                                                            </div>

                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingmeterins">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninstallation" href="#collapsemeterins" aria-expanded="false" aria-controls="collapsemeterins">CONNECTIVITY CHARGES AND DISCOM AGREEMENT
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsemeterins" class="panel-collapse in" role="tabpanel" aria-labelledby="headingmeterins">
                                                                    <div class="panel-body">

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">
                                                                                  <div class="col-sm-12">
                                                                                    <label>DISCOM Applied Date </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtDiscomAppliedDate" class="form-control pull-right datepicker" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                     <div class="col-md-12"><label></label></div>
                                                                                <div class="col-sm-12">
                                                                                    <label>DISCOM Applied Form: </label>
                                                                                     <label><a href="#">123Saved.pdf</a></label>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <asp:FileUpload runat="server" ID="fileDiscomAppliedform" />
                                                                                </div>
                                                                                <div class="col-md-12"><label></label></div>
                                                                                 <div class="col-sm-12">
                                                                                    <label>Technical Feasibility Report: </label>
                                                                                     <label><a href="#">TechnicalReport.pdf</a></label>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <asp:FileUpload runat="server" ID="fileTectnicalReport" />
                                                                                </div>

                                                                                     <div class="col-md-12"><label></label></div>
                                                                                   <div class="col-sm-12">
                                                                                    <label>Connectivity Payment Date </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtConncectivityPaymentDate" class="form-control pull-right datepicker" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                     <div class="col-md-12"><label></label></div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Estimate Report: </label>
                                                                                     <label><a href="#">EstimateReport.pdf</a></label>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <asp:FileUpload runat="server" ID="fileupldEstimateReport" />
                                                                                </div>
                                                                                     <div class="col-md-12"><label></label></div>
                                                                                 <div class="col-sm-12">
                                                                                    <label>Confirm Payment Receipt: </label>
                                                                                     <label><a href="#">PaymentReceipt.pdf</a></label>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <asp:FileUpload runat="server" ID="fileupldConfirmPaymentRec" />
                                                                                </div>


                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">
                                                                                   <div class="col-sm-12">
                                                                                    <label>Agreement Date </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtAgreementDate" class="form-control pull-right datepicker" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                     <div class="col-md-12"><label></label></div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Agreement Doc: </label>
                                                                                     <label><a href="#">AgreementDoc.pdf</a></label>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <asp:FileUpload runat="server" ID="fileupldAgreementDoc" />
                                                                                </div>

                                                                                     <div class="col-md-12"><label></label></div>
                                                                                 <div class="col-sm-12">
                                                                                    <label>Signed Agreement Doc: </label>
                                                                                     <label><a href="#">signedAgreement.pdf</a></label>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <asp:FileUpload runat="server" ID="fileupldSignedagreement" />
                                                                                </div>
                                                                            
                                                                                     <div class="col-md-12"><label></label></div>
                                                                                <div class="col-sm-12">
                                                                                    <label>CC Paid By</label>
                                                                                    <asp:DropDownList ID="ddlCCPaidBy" runat="server" AppendDataBoundItems="true" CssClass="form-control select2"  Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                        <asp:ListItem Value="1" Text="Company">Company</asp:ListItem>
                                                                                        <asp:ListItem Value="2" Text="Customer">Customer</asp:ListItem>

                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                              
                                                                                <div class="col-sm-12">
                                                                                    <label>Connectivity Charges </label>

                                                                                    <asp:TextBox ID="txtConnectivityCharges" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                                </div>
                                                                            
                                                                             
                                                                                <div class="col-sm-12">
                                                                                    <label>Electricity Board</label>
                                                                                    <asp:DropDownList ID="ddlElectricityBrd" runat="server" AppendDataBoundItems="true" CssClass="form-control select2"  Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                        
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                               <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingmnre">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninstallation" href="#collapsemnre" aria-expanded="false" aria-controls="collapsemnre">MNRE
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsemnre" class="panel-collapse in" role="tabpanel" aria-labelledby="headingmnre">
                                                                    <div class="panel-body">

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">

                                                                                   <div class="col-sm-12">
                                                                                    <label>Applied Date </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtMnreAppliedDate" class="form-control pull-right datepicker" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                   <div class="col-sm-12">
                                                                                    <label>Approval Date </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtApprovalDate" class="form-control pull-right datepicker" runat="server" ></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                   <div class="col-sm-12">
                                                                                    <label>MNRE Form B</label>
                                                                                    <asp:FileUpload runat="server" ID="fileUpldMnreB" />

                                                                                </div>
                                                                                <div class="col-md-12"><label></label></div>
                                                                                   <div class="col-sm-12">
                                                                                    <label>MNRE Form C</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldMnreC" />

                                                                                </div>
                                                                                 <div class="col-md-12"><label></label></div>

                                                                               
                                                                                   <div class="col-sm-12">
                                                                                    <label>CA Certificate</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldCACerti" />

                                                                                </div>
                                                                             
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">
                                                                                <div class="col-md-12"><label></label></div>
                                                                                   <div class="col-sm-12">
                                                                                    <label>Sencation Letter Form GEDA</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldSencationletter" />

                                                                                </div>
                                                                                  <div class="col-md-12"><label></label></div>
                                                                                   <div class="col-sm-12">
                                                                                    <label>Affidavit</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldAffidavit" />

                                                                                </div>

                                                                                  <div class="col-sm-12">
                                                                                    <label>Applied Amount</label>

                                                                                    <asp:TextBox runat="server" ID="txtAppliedAmount" CssClass="form-control" />
                                                                                </div>

                                                                            
                                                                                <div class="col-sm-12">
                                                                                    <label>Applied Status</label>
                                                                                    <asp:DropDownList ID="ddlAppliedStatus" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                          <asp:ListItem Value="1" Text="Select">Active</asp:ListItem>
                                                                                          <asp:ListItem Value="2" Text="Select">Disabled</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                              

                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                               <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingpostgeda">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninstallation" href="#collapsepostgeda" aria-expanded="false" aria-controls="collapsepostgeda">POST GEDA APPLICATION
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsepostgeda" class="panel-collapse in" role="tabpanel" aria-labelledby="headingpostgeda">
                                                                     <div class="panel-body">

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">
                                                                                  <div class="col-sm-12">
                                                                                    <label>Geda Commissioning Date </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtcommissioningdate" class="form-control pull-right datepicker" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                  <div class="col-sm-12">
                                                                                    <label>Geda Commissioning Approval Date </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtGedaCommissioningApprovalDate" class="form-control pull-right datepicker" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                 <div class="col-sm-12">
                                                                                    <label>Geda Commissioning Certificate Number</label>
                                                                                 
                                                                                    <asp:TextBox ID="txtCommissioningCertificateNumber" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                              
                                                                                </div>
                                                                                 <div class="col-sm-12">
                                                                                    <label>GEDA Status</label>
                                                                                    <asp:DropDownList ID="ddlGedaPostStatus" runat="server" AppendDataBoundItems="true" CssClass="form-control select2"  Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                          <asp:ListItem Value="1" Text="Applied">Applied</asp:ListItem>
                                                                                          <asp:ListItem Value="2" Text="Approved">Approved</asp:ListItem>
                                                                                          <asp:ListItem Value="3" Text="Cancel">Cancel</asp:ListItem>
                                                                                          <asp:ListItem Value="4" Text="New">New</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                 <div class="col-sm-12">
                                                                                    <label>GEDA Subsidy Status</label>
                                                                                    <asp:DropDownList ID="ddlSubsidyStatus" runat="server" AppendDataBoundItems="true" CssClass="form-control select2"  Style="width: 100%;">
                                                                                       
                                                                                         <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                          <asp:ListItem Value="1" Text="Pending">Pending</asp:ListItem>
                                                                                          <asp:ListItem Value="2" Text="Completed">Completed</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                 <div class="col-sm-12">
                                                                                    <label>GEDA Applied By</label>
                                                                                    <asp:DropDownList ID="ddlGedaAppliedBy" runat="server" AppendDataBoundItems="true" CssClass="form-control select2"  Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                        <asp:ListItem Value="1" Text="Company">Company</asp:ListItem>
                                                                                        <asp:ListItem Value="2" Text="Customer">Customer</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div class="col-md-4"><label></label></div>
                                                                                  <div class="col-sm-12">
                                                                                    <label>Commissioning Certi</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldCommcerti" />

                                                                                </div>
                                                                                   <div class="col-md-4"><label></label></div>
                                                                                  <div class="col-sm-12">
                                                                                    <label>MDU</label>
                                                                                    <asp:FileUpload runat="server" ID="fileUpldMDU" />

                                                                                </div>
                                                                                   <div class="col-md-4"><label></label></div>
                                                                                  <div class="col-sm-12">
                                                                                    <label>Panel And Inverter Sr No.</label>
                                                                                    <asp:FileUpload runat="server" ID="fileUpldPanelsrno" />

                                                                                </div>



                                                                            


                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">

                                                                                     <div class="col-sm-12">
                                                                                    <label>Meter Calling Report</label>
                                                                                    <asp:FileUpload runat="server" ID="fileUpldmeterCallingreport" />

                                                                                </div>
                                                                                   <div class="col-md-4"><label></label></div>
                                                                                  <div class="col-sm-12">
                                                                                    <label>Invoice</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldInvoice" />

                                                                                </div>
                                                                                   <div class="col-md-4"><label></label></div>
                                                                                  <div class="col-sm-12">
                                                                                    <label>Plant Photo</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldPlantPhoto" />

                                                                                </div>
                                                                                   <div class="col-md-4"><label></label></div>
                                                                                   <div class="col-sm-12">
                                                                                    <label>GEDA Subsidy Applied Date </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtGedaSubsidyAppliedDate" class="form-control pull-right datepicker" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                    
                                                                            
                                                                                  
                                                                              
                                                                                <div class="col-sm-12">
                                                                                    <label>GEDA Applied Amount </label>

                                                                                    <asp:TextBox ID="txtGedaAppliedAmount" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>GEDA Subsidy Received </label>

                                                                                    <asp:TextBox ID="txtGedaSubsidyRec" class="form-control" runat="server" TabIndex="7"></asp:TextBox>

                                                                                </div>
                                                                                <div class="col-md-4"><label></label></div>
                                                                              <div class="col-sm-12">
                                                                                    <label>GEDA Subsidy Received Letter</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldSubsidyletter" />

                                                                                </div>
                                                                                   <div class="col-md-4"><label></label></div>
                                                                                  <div class="col-sm-12">
                                                                                    <label>GEDA Checklist</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldGedaChecklst" />

                                                                                </div>
                                                                                   <div class="col-md-4"><label></label></div>
                                                                                  <div class="col-sm-12">
                                                                                    <label>Beneficiary Photo</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldBenficPhoto" />

                                                                                </div>

                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                               <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingpostceig">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordioninstallation" href="#collapsepostceig" aria-expanded="false" aria-controls="collapsepostceig">POST CEIG APPLICATION
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsepostceig" class="panel-collapse in" role="tabpanel" aria-labelledby="headingpostceig">
                                                                   <div class="panel-body">

                                                                        <div class="col-md-6">

                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>CEIG Applied: </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtCeigPostAppliedDate" class="form-control pull-right datepicker" runat="server" TabIndex="1"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>CEIG Applied Ref.: </label>

                                                                                    <asp:TextBox ID="txtCeigPostAppliedRef" class="form-control" runat="server"></asp:TextBox>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>CEIG Approval: </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtCeigPostApprovalDate" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>CEIG Approval Ref.:</label>

                                                                                    <asp:TextBox ID="txtCeigPostApprovalREf" class="form-control" runat="server"></asp:TextBox>

                                                                                </div>
                                                                          </div>

                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">

                                                                               
                                                                                 <div class="col-sm-12">
                                                                                    <label>CEIG Status</label>
                                                                                    <asp:DropDownList ID="ddlCeigPostStatus" runat="server" AppendDataBoundItems="true" CssClass="form-control select2"  Style="width: 100%;">
                                                                                         <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                          <asp:ListItem Value="1" Text="Applied">Applied</asp:ListItem>
                                                                                          <asp:ListItem Value="2" Text="Approved">Approved</asp:ListItem>
                                                                                          <asp:ListItem Value="3" Text="Cancel">Cancel</asp:ListItem>
                                                                                          <asp:ListItem Value="4" Text="New">New</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                 <div class="col-md-4"><label></label></div>
                                                                                 <div class="col-sm-12">
                                                                                    <label>Customer Notified Meter/CEIG: </label>
                                                                                    <asp:CheckBox runat="server" ID="chkCustPostNotifiedMeter" />
                                                                                </div>
                                                                                 <div class="col-md-4"><label></label></div>
                                                                                  <div class="col-sm-12">
                                                                                    <label>Test Report</label>
                                                                                    <asp:FileUpload runat="server" ID="fileUPldTestreport" />

                                                                                </div>
                                                                                 <div class="col-md-4"><label></label></div>
                                                                                  <div class="col-sm-12">
                                                                                    <label>Charging NOC Form</label>
                                                                                    <asp:FileUpload runat="server" ID="fileupldChargingNOC" />

                                                                                </div>

                                                                             

                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>

                                                    </div>
                                                    <!-- /.box-body -->
                                                    <div class="box-footer">
                                                        <asp:Button ID="btncnclinstallation" runat="server" CssClass="btn btn-default" Text="Cancel" OnClick="btncnclinstallation_Click" />
                                                        <asp:Button ID="btnsaveinstallation" runat="server" CssClass="btn btn-info pull-right" Text="Save" OnClick="btnsaveinstallation_Click"  />
                                                    </div>
                                                    <!-- /.box-footer -->

                                                </div>

                                            </div>

                                            <div class="tab-pane" id="mntc" runat="server" clientidmode="static">
                                                <div class="form-horizontal">
                                                    <div class="box-body">
                                                        <div class="form-group">
                                                            <div class="col-md-10"></div>
                                                            <div class="col-md-2">
                                                                <a href="#" class="pull-right"><i class="fa fa-wrench"></i>Add Mtce</a>
                                                            </div>
                                                        </div>


                                                        <div class="panel-group" id="accordionmtce" role="tablist" aria-multiselectable="true">

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headinginsdetail">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionmtce" href="#collapseinsdetail" aria-expanded="false" aria-controls="collapseinsdetail">Installation Details
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapseinsdetail" class="panel-collapse in" role="tabpanel" aria-labelledby="headinginsdetail">
                                                                    <div class="panel-body">

                                                                        <div class="form-group">
                                                                            <div class="col-md-6">
                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Installer</label>
                                                                                    <div class="col-sm-8">
                                                                                        <asp:Label runat="server" ID="lblInstaller" Text="N/A"></asp:Label>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">System</label>
                                                                                    <div class="col-sm-8">
                                                                                        <asp:Label runat="server" ID="Label1" Text="10 X CAN250 + ABB PVI 10.0 kW 3 PHASE 2 MPPT"></asp:Label>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Sales Rep</label>
                                                                                    <div class="col-sm-8">
                                                                                        <asp:Label runat="server" ID="Label4" Text="Neil Clark"></asp:Label>
                                                                                    </div>
                                                                                </div>
                                                                            </div>

                                                                            <div class="col-md-6">

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Install Date</label>
                                                                                    <div class="col-sm-8">
                                                                                        <asp:Label runat="server" ID="Label2" Text="N/A"></asp:Label>

                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-4">Meter Elec</label>
                                                                                    <div class="col-sm-8">
                                                                                        <asp:Label runat="server" ID="Label3" Text="N/A"></asp:Label>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingmtcedetail">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionmtce" href="#collapsemtcedetail" aria-expanded="false" aria-controls="collapsemtcedetail">Maintenance Details
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsemtcedetail" class="panel-collapse in" role="tabpanel" aria-labelledby="headinginsdetail">
                                                                    <div class="panel-body">
                                                                        <div class="col-md-6">

                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>Call Date </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="TextBox2" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Call Reason </label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Sub Reason </label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Employee </label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Call Method </label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label></label>

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Warranty Tick </label>
                                                                                    <asp:CheckBox runat="server" ID="chkwarrantrytick" />
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Call Status</label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>

                                                                            </div>

                                                                        </div>

                                                                        <div class="col-md-6">

                                                                            <div class="form-group">
                                                                                <div class="col-sm-12">
                                                                                    <label>Product Fault Details</label>
                                                                                </div>

                                                                            </div>
                                                                            <div class="form-group">
                                                                                <div class="col-sm-12">
                                                                                    <label>Fault Category</label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Fault Details</label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Claim Date</label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="TextBox91" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Claim Detail</label>
                                                                                    <asp:TextBox ID="TextBox97" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Claim Amount $</label>
                                                                                    <asp:TextBox ID="TextBox98" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Claim Comment</label>
                                                                                    <asp:TextBox ID="TextBox99" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Claim Reference</label>
                                                                                    <asp:TextBox ID="TextBox100" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Claim Status</label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Claim Resolved Date</label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="TextBox101" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                            </div>

                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingprorepdetail">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionmtce" href="#collapseprorepdetail" aria-expanded="false" aria-controls="collapseprorepdetail">Product Replacement Details
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapseprorepdetail" class="panel-collapse in" role="tabpanel" aria-labelledby="headingprorepdetail">
                                                                    <div class="panel-body">

                                                                        <div class="col-md-6">

                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>Inv Replacement </label>
                                                                                    <asp:CheckBox runat="server" ID="chkInvReplacement" />
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Own Stock </label>
                                                                                    <asp:CheckBox runat="server" ID="chkownstock" />
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Old Inv Supplier </label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>New Inv Supplier </label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>New Inv </label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Old Inv Serial#</label>
                                                                                    <asp:TextBox ID="TextBox102" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>New Inv Serial#</label>
                                                                                    <asp:TextBox ID="TextBox109" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>New Second Inv</label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Old Second Inv Serial#</label>
                                                                                    <asp:TextBox ID="TextBox110" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>New Second Inv Serial#</label>
                                                                                    <asp:TextBox ID="TextBox103" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>

                                                                            </div>

                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">
                                                                                <div class="col-sm-12">
                                                                                    <label>Panel Replacement </label>
                                                                                    <asp:CheckBox runat="server" ID="CheckBox17" />
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Own Stock </label>
                                                                                    <asp:CheckBox runat="server" ID="CheckBox18" />
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Old Panel Supplier </label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>New Panel Supplier </label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>New Panel </label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Old Panel Serial#</label>
                                                                                    <asp:TextBox ID="TextBox104" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>New Panel Serial#</label>
                                                                                    <asp:TextBox ID="TextBox105" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Num of Panels</label>
                                                                                    <asp:TextBox ID="TextBox106" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingworkpaycos">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionmtce" href="#collapseworkpaycos" aria-expanded="false" aria-controls="collapseworkpaycos">Work Done & Payment Costing
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapseworkpaycos" class="panel-collapse in" role="tabpanel" aria-labelledby="headingworkpaycos">
                                                                    <div class="panel-body">
                                                                        <div class="col-md-6">

                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>Tech Assigned </label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Prop Fix Date </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="TextBox107" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Fixed Date </label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="TextBox116" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Closed By </label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>

                                                                            </div>

                                                                            <div class="form-group">
                                                                                <div class="col-sm-12">
                                                                                    <h4>
                                                                                        <label>Payment & Costing</label></h4>

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Mtce Cost $</label>
                                                                                    <asp:TextBox ID="TextBox117" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Supplier Paid $</label>
                                                                                    <asp:TextBox ID="TextBox118" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Sup Paid Date</label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="TextBox119" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Customer Paid $</label>
                                                                                    <asp:TextBox ID="TextBox120" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Cust Paid Date</label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="TextBox121" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                            </div>

                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>Balance $</label>
                                                                                    <asp:TextBox ID="TextBox122" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Paid By</label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Rec By</label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Invoice Amount $</label>
                                                                                    <asp:TextBox ID="TextBox123" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Invoice Comment</label>
                                                                                    <asp:TextBox ID="TextBox124" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Mtc STC Applied</label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="TextBox108" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Mtc PVD Number</label>
                                                                                    <asp:TextBox ID="TextBox111" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Mtc PVD Status</label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headinginsclaim">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionmtce" href="#collapseinsclaim" aria-expanded="false" aria-controls="collapseinsclaim">Insurance Claims
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapseinsclaim" class="panel-collapse in" role="tabpanel" aria-labelledby="headinginsclaim">
                                                                    <div class="panel-body">
                                                                        <div class="col-md-6">

                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>Insurance Claim</label>
                                                                                    <asp:CheckBox runat="server" ID="chkinsclaim" />
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Insurance Type </label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Insurance Company </label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Insurance Amount $ </label>
                                                                                    <asp:TextBox ID="TextBox113" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Claim Date</label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="TextBox7" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Insurance Claim Status </label>
                                                                                    <select class="form-control select2" style="width: 100%">
                                                                                        <option>option 1</option>
                                                                                        <option>option 2</option>
                                                                                        <option>option 3</option>
                                                                                        <option>option 4</option>
                                                                                        <option>option 5</option>
                                                                                    </select>
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Insurance Claim Details</label>
                                                                                    <asp:TextBox ID="TextBox114" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>

                                                                            </div>

                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">

                                                                                <div class="col-sm-12">
                                                                                    <label>Excess Paid</label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="TextBox21" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Insurance Resolved Date</label>
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="TextBox125" class="form-control pull-right datepicker" runat="server" TabIndex="7"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Tech Ref No.</label>
                                                                                    <asp:TextBox ID="TextBox126" class="form-control" runat="server" TabIndex="7"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Documents</label>
                                                                                    <asp:CheckBox runat="server" ID="CheckBox1" />
                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Installer Mtc Report </label>
                                                                                    <asp:CheckBox runat="server" ID="CheckBox22" Checked="true" />
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label><a href="#">123mtcreport.pdf</a></label>
                                                                                    <asp:FileUpload runat="server" ID="FileUpload5" />

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Photos </label>
                                                                                    <asp:CheckBox runat="server" ID="CheckBox23" Checked="true" />
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label><a href="#">123photos.pdf</a></label>
                                                                                    <asp:FileUpload runat="server" ID="FileUpload6" />

                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <!-- /.box-body -->
                                                    <div class="box-footer">
                                                        <asp:Button ID="Button3" runat="server" TabIndex="23" ToolTip="Reset Details" CssClass="btn btn-default" Text="Cancel" />
                                                        <asp:Button ID="Button4" runat="server" TabIndex="24" ToolTip="Add Priority" CssClass="btn btn-info pull-right" Text="Add" />
                                                    </div>
                                                    <!-- /.box-footer -->

                                                </div>
                                            </div>

                                            <div class="tab-pane" id="dcms" runat="server" clientidmode="static">

                                                <div class="form-horizontal">
                                                    <div class="box-body">

                                                        <div class="panel-group" id="accordiondcmnts" role="tablist" aria-multiselectable="true">

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingdownloaddoc">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordiondcmnts" href="#collapsedownloaddoc" aria-expanded="false" aria-controls="collapsedownloaddoc">Download Documnets
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsedownloaddoc" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingdownloaddoc">
                                                                    <div class="panel-body">

                                                                        <div class="form-group">
                                                                            <div class="col-md-4">
                                                                                <div class="col-sm-12">
                                                                                    <label>Invoice</label><br />
                                                                                    <a href="#"><i class="fa fa-file-pdf-o"></i>Open Invoice</a>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Quotation</label><br />
                                                                                    <a href="#"><i class="fa fa-file-pdf-o"></i>Open Quotation</a>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Meter Approval</label><br />
                                                                                    <%-- <a href="#"><i class="fa fa-file-pdf-o"></i> Open Invoice</a>--%>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="col-sm-12">
                                                                                    <label>New Model Panel?</label><br />
                                                                                    <asp:CheckBox runat="server" ID="chknewmodelpanel" />

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>New Model Inv?</label><br />
                                                                                    <asp:CheckBox runat="server" ID="CheckBox25" />

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Pick List</label><br />
                                                                                    <a href="#"><i class="fa fa-hand-o-up"></i>Pick List</a>

                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="col-sm-12">
                                                                                    <label>Meter Photo</label>
                                                                                    <%--<a href="#"><i class="fa fa-file-pdf-o"></i> Open Invoice</a>--%>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Prop Design</label>
                                                                                    <%--<a href="#"><i class="fa fa-file-pdf-o"></i> Open Quotation</a>--%>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>SQ Document</label>
                                                                                    <%-- <a href="#"><i class="fa fa-file-pdf-o"></i> Open Invoice</a>--%>
                                                                                </div>

                                                                            </div>
                                                                        </div>

                                                                    </div>

                                                                </div>

                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headinguploaddoc">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordiondcmnts" href="#collapseuploaddoc" aria-expanded="false" aria-controls="collapseuploaddoc">Upload Documents
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapseuploaddoc" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headinguploaddoc">
                                                                    <div class="panel-body">
                                                                        <div class="form-group">
                                                                            <div class="col-md-4">
                                                                                <div class="col-sm-12">
                                                                                    <label>Signed Paperwork </label>
                                                                                    <asp:CheckBox runat="server" ID="CheckBox24" Checked="true" />
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label><a href="#">signed123.pdf</a></label>
                                                                                    <asp:FileUpload runat="server" ID="FileUpload7" />

                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="col-sm-12">
                                                                                    <label>Invoice Doc </label>
                                                                                    <asp:CheckBox runat="server" ID="CheckBox26" Checked="true" />
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label><a href="#">123invdoc.pdf</a></label>
                                                                                    <asp:FileUpload runat="server" ID="FileUpload8" />

                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="col-sm-12">
                                                                                    <label>Other Documents </label>
                                                                                    <asp:CheckBox runat="server" ID="CheckBox27" Checked="true" />
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label><a href="#">123impdoc.pdf</a></label>
                                                                                    <asp:FileUpload runat="server" ID="FileUpload9" />

                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                </div>

                                                            </div>

                                                        </div>

                                                    </div>
                                                    <!-- /.box-body -->
                                                    <div class="box-footer">
                                                        <asp:Button ID="Button5" runat="server" TabIndex="23" ToolTip="Reset Details" CssClass="btn btn-default" Text="Cancel" />
                                                        <asp:Button ID="Button6" runat="server" TabIndex="24" ToolTip="Add Priority" CssClass="btn btn-info pull-right" Text="Add" />
                                                    </div>
                                                    <!-- /.box-footer -->

                                                </div>
                                            </div>

                                            <div class="tab-pane" id="cnvs" runat="server" clientidmode="static">
                                                <div class="form-horizontal">
                                                    <div class="box-body">
                                                        <div class="form-group">
                                                            <div class="col-md-6">
                                                                <div class="col-sm-12">
                                                                    <label>Note : *</label>
                                                                    <asp:TextBox runat="server" ID="txtNotes" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Project Notes :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox3" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Notes for Installation Department :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox4" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Meter Notes :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox22" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Notes For Installer :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox23" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label style="color: red">Notes from Installer :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox24" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="col-sm-12">
                                                                    <label>Rex Notes :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox25" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Quotation Notes :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox26" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Finance Notes :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox27" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Invoice Notes :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox28" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>STC Notes :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox29" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Freebies1 Comment:</label>

                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Freebies2 Comment:</label>

                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->
                                                    <div class="box-footer">
                                                        <asp:Button ID="Button7" runat="server" TabIndex="23" ToolTip="Reset Details" CssClass="btn btn-default" Text="Cancel" />
                                                        <asp:Button ID="Button8" runat="server" TabIndex="24" ToolTip="Add Priority" CssClass="btn btn-info pull-right" Text="Add" />
                                                    </div>
                                                    <!-- /.box-footer -->

                                                </div>
                                            </div>

                                            <div class="tab-pane" id="prtr" runat="server" clientidmode="static">
                                                <div class="form-horizontal">
                                                    <div class="box-body">
                                                        <table id="example3" class="table table-bordered table-hover">
                                                            <thead>
                                                                <tr>
                                                                    <th>Updated By</th>
                                                                    <th>Updated Date</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <%-- </HeaderTemplate>
                            <ItemTemplate>--%>

                                                                <tr>

                                                                    <td>Martin Smith </td>
                                                                    <td>01/03/2017 19:03:22 </td>
                                                                </tr>
                                                                <tr>

                                                                    <td>Jhon Peter </td>
                                                                    <td>26/02/2017 15:03:22 </td>
                                                                </tr>

                                                                <%-- </ItemTemplate>
                            <FooterTemplate>--%>
                                                            </tbody>
                                                        </table>
                                                    </div>

                                                </div>
                                            </div>

                                           
                                            <div class="tab-pane" id="expen" runat="server" clientidmode="static">
                                                <div class="form-horizontal">
                                                    <div class="box-body">
                                                        <div class="panel-group" id="accordionExpen" role="tablist" aria-multiselectable="true">

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingexpense">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionExpen" href="#collapseexpense" aria-expanded="false" aria-controls="collapseexpense">Expenses
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapseexpense" class="panel-collapse in" role="tabpanel" aria-labelledby="headingexpense">
                                                                    <div class="panel-body">

                                                                        <div class="form-group">
                                                                             <div class="col-md-6">
                                                                        
                                                                            <div class="col-md-12">
                                                                                <label>Expense Type</label>
                                                                                     <asp:DropDownList ID="ddlExpense" runat="server" CssClass="form-control select2" TabIndex="1" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList> 

                                                                            </div> <br /><br />
                                                                              <div class="col-md-6" style="height:20px;">
                                                                                 <label>Expense Date</label>
                                                                                    <div class="input-group date">
                                                                                    <div class="input-group-addon">
                                                                                        <i class="fa fa-calendar"></i>
                                                                                    </div>
                                                                                    <asp:TextBox ID="txtExpenDate" class="form-control pull-right datepicker1" runat="server"></asp:TextBox>
                                                                                </div> 
                                                                                  </div>
                                                                              <div class="col-md-6">
                                                                                <label>Costing</label>
                                                                                <asp:TextBox ID="txtExpenseCosting" runat="server" CssClass="form-control"  onkeypress="if(isNaN(String.fromCharCode(event.keyCode))) return false;"></asp:TextBox>

                                                                            </div>
                                                                         
                                                                                 </div>
                                                                           
                                                                              <div class="col-md-6">
                                                                           
                                                                             <div class="col-sm-12">
                                                                    <label>Description:</label>
                                                                    <asp:TextBox runat="server" ID="txtExpensedescription" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                                  </div>

                                                                        </div>

                                                                       <div class="box-footer">
                                                        <asp:Button ID="btnCancelExpense" runat="server" TabIndex="4" CssClass="btn btn-default" Text="Cancel" OnClick="btnCancelExpenses_Click" />
                                                        <asp:Button ID="btnSaveExpenses" runat="server" TabIndex="5" CssClass="btn btn-info pull-right" Text="Save" OnClick="btnSaveExpenses_Click"/>
                                                    </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="panel panel-default box box-info" >
                                                                <div class="box-header with-border" role="tab" id="timelineexpense">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionExpen" href="#collapsetimeline" aria-expanded="false" aria-controls="collapsetimeline">Timeline
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsetimeline" class="panel-collapse in" role="tabpanel" aria-labelledby="headingexpense">
                                                                  <div class="box-body table-scrollable" >
                                                                   
                                                                     <div class="panel-body" >
                                                                      
                                                                        <div class="form-group">
                                                                            <!-- row -->
                                                                            <div class="row">
                                                                                <div class="col-md-12">
                                                                                    <!-- The time line -->
                                                                                   <ul class="timeline timeline-inverse">
                                                                                    <asp:Repeater ID="rpttimeline" runat="server" OnItemDataBound="rpttimeline_ItemDataBound">
                                                                                        <ItemTemplate>
                                                                                           
                                                                                             <li class="time-label" id="Timelabel" runat="server">
                                                                                                <span class="bg-red"><%#Eval("ExpenseDate","{0:dd MMM, yyyy}")%></span>
                                                                                             </li>
                                                                                             
                                                                                             <li><i class="<%#Eval("Symbol")%> bg-blue"></i>

                                                                                             <div class="timeline-item">
                                                                                              <span class="time"><i class="fa fa-clock-o">&nbsp;</i><%#Eval("Diff")%></span>

                                                                                                <h3 class="timeline-header"><a href="#"><%#Eval("ExpenseName") %></a> Amount <b> <%#Eval("ExpenseCosting") %></b></h3>

                                                                                                   <div class="timeline-body">
                                                                                                      
                                                                                                    <%#Eval("ExpenseDescription") %> by <b><%#Eval("UserName") %></b>
                                                                                                       </div>
    
                                                                                                      </div>
                                                                                            </li>

                                                                                             </ItemTemplate>
                                                                                             <FooterTemplate>
                                                                                                  <li class="time-label" id="EmptyHistory" runat="server" visible="false">
                                                                                                  <span class="bg-red">
                                                                                                    <asp:Label ID="lbltimelinetext" runat="server" Text="No history available.."></asp:Label>
                                                                                                  </span>
                                                                                                 </li>
                                                                                             </FooterTemplate>
                                                                                       </asp:Repeater>
                                                                                    </ul>
                                                                                </div>
                                                                                <!-- /.col -->
                                                                            </div>
                                                                        </div>

                                                                              
                                                                         </div>

                                                                    </div>
                                                                </div>
                                                                    
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


            </section>
            
  
        

            <script>

                function validate() {
                    if (document.getElementById("<%=txtSearch.ClientID%>").value == "") {
                        alert("search field can not be blank!");
                        document.getElementById("<%=txtSearch.ClientID%>").focus();
                        return false;
                    }
                    return true;
                }

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

                    $(".select2").select2({
                        placeholder: "Select",
                        allowClear: true
                    });

                    $('.datepicker').datepicker({
                        autoclose: true,
                    });
                    $('.datepicker1').datepicker({
                        autoclose: true,
                        dateFormat: "MM/dd/yyyy",
                        endDate: new Date(),
                    });

                    $("#btnSaveProjectTeam").click(function () {

                        var lstdata = [];
                        debugger;
                        $('.ProjectTeamTasks').each(function (i, obj) {
                            debugger;
                            var first = $(obj).find("select")[0];
                            var result = $(first).val();

                            lstdata.push(result);
                        });

                        lstdata = JSON.stringify({ 'lstdata': lstdata });

                        $.ajax({
                            type: "POST",
                            url: "projectlist.aspx/SaveProjectTeam",
                            data: lstdata,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (data) {
                                debugger;
                                if (data.d == true) {
                                    alert("Save successfully!!");
                                
                                    $("#projectteam").removeClass("tab-pane");
                                    $("#projectteam").addClass("tab-pane active");
                                    $("#lipt").addClass("active");

                                    $("#sip").removeClass("tab-pane active");
                                    $("#sip").addClass("tab-pane");
                                    $("#lisip").removeClass("active");
                                }
                                else {
                                    alert("Hey..something went wrong try again!!");
                                }

                            },
                            error: function () {

                                alert("Hey..something went wrong please try again!!");
                                location.reload();
                            }
                        });

                    });
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

              <style type="text/css">
        
        .table-scrollable {
            height: 500px;
            width: 100%;
            overflow-y: auto;
            overflow-x: hidden;
            border: 1px solid #dddddd;
            margin: 10px 0 !important;
           
        }

    </style>
         
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



        <Triggers>
            <asp:PostBackTrigger ControlID="btnOpenInvoice" />
         
           <%-- <asp:AsyncPostBackTrigger ControlID="ddlInstaller" EventName="SelectedIndexChanged" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

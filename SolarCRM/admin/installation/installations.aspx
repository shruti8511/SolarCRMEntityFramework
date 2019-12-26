<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="installations.aspx.cs" Inherits="SolarCRM.admin.installation.installations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="content-header">
        <h1>Installation</h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>DashBoard</a></li>
           
            <li class="active">Installations</li>
        </ol>
    </section>

    <section class="content">
        <div class="row">
            <div class="col-md-12">

                <div class="box box-info">
                    <div class="box-header">

                        <div class="form-horizontal">
                            <div class="form-group">

                                <div class="col-sm-3">
                                  <label>  <asp:Literal ID="ltdate" runat="server"></asp:Literal></label>
                                </div>
                                <div class="col-sm-2">

                                    <asp:Button ID="btnpreviousday" runat="server" Visible="false" class="btn btn-info btn-flat" Text=" < " OnClick="btnpreviousday_Click" />

                                    <asp:Button ID="btntoday" runat="server" class="btn btn-info btn-flat" Text="Today" OnClick="btntoday_Click" />

                                    <asp:Button ID="btnnextday" runat="server" Visible="false" class="btn btn-info btn-flat" Text=" > " OnClick="btnnextday_Click" />

                                </div>
                                <div class="col-sm-3">
                                    <span>
                                        <asp:LinkButton ID="btnpreviousweek" runat="server" class="btn btn-info btn-flat" Text="Previous Week" OnClick="btnpreviousweek_Click"> <i class="fa fa-arrow-circle-left"></i></asp:LinkButton>

                                        <a href="#" class="btn btn-info btn-flat">Week</a>

                                        <asp:LinkButton ID="btnnextweek" runat="server" class="btn btn-info btn-flat" Text="Next Week" OnClick="btnnextweek_Click"> <i class="fa fa-arrow-circle-right"></i></asp:LinkButton>

                                    </span>
                                </div>

                                <%--<div class="col-sm-6">

                                    <span>Show 
                            <asp:DropDownList ID="ddlshowentry" Style="width: 70px; height: 30px" runat="server">
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                <asp:ListItem Text="100" Value="100"></asp:ListItem>
                            </asp:DropDownList>
                                        entries
                                    </span>

                                </div>--%>
                                <div class="col-sm-4 pull-right">
                                    <div class="input-group input-group-sm">
                                        <asp:TextBox ID="txtSearch" ClientIDMode="Static" runat="server" placeholder="search keyword" class="form-control"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-info btn-flat" Text="Search" />
                                            <asp:Button ID="btnClear" runat="server" class="btn btn-default" Text="Clear" />
                                        </span>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>

                    <div class="box-body table-scrollable1">

                        <table width="100%" border="1" cellpadding="0" cellspacing="0">
                            <tbody>
                                <tr>
                                    <asp:Repeater ID="RptDays" runat="server" OnItemDataBound="RptDays_ItemDataBound">
                                        <ItemTemplate>
                                            <td valign="top">
                                                <table id="example2" class="table table-bordered table-hover">
                                                    <thead>
                                                        <tr>
                                                            <td colspan="2" style="width: 100%; font-size: 17px">
                                                                <asp:HiddenField ID="hdnDate" runat="server" Value='<%# Eval("CDate")%>' />
                                                                <%# Eval("CDate")%>
                                                                <%# Eval("CDay") %>
                                                            </td>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr class="title">
                                                            <td width="50%">Project
                                                            </td>
                                                            <td width="25%" align="center">Time&nbsp;Bkd
                                                            </td>
                                                        </tr>

                                                    </tbody>
                                                </table>
                                            </td>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tr>
                            </tbody>
                        </table>

                    </div>

                    <!-- /.box-header -->
                    <%--        <div class="box-body table-scrollable1">

                        <asp:Repeater ID="RptDays" runat="server" OnItemDataBound="RptDays_ItemDataBound">
                            <ItemTemplate>

                                <table id="example2" class="table table-bordered table-hover">
                                    <thead>
                                        <tr>
                                           
                                            <th>

                                                <asp:HiddenField ID="hdnDate" runat="server" Value='<%# Eval("CDate")%>' />
                                                <%# Eval("CDate")%>
                                                <%# Eval("CDay") %>
                                                          
                                            </th>

                                        </tr>
                                    </thead>
                                    <tbody>

                                        <tr class="title">
                                            <td style="width: 50%">Project
                                            </td>
                                            <td style="width: 25%; text-align: center">Time&nbsp;Bkd
                                            </td>
                                        </tr>
                                    </tbody>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>--%>
                </div>

            </div>

        </div>
    </section>

    <div class="bodymianbg">
        <div class="row">
            <div class="col-sm-12">
                <div class="searcharea2">
                    <div class="navigation">
                        <div class="today">
                            <%--  <ul>
                                <asp:Button ID="btnpreviousday" runat="server" Visible="false" Text=" < " OnClick="btnpreviousday_Click" />
                                <li>
                                    <asp:Button ID="btntoday" runat="server" Text="Today" OnClick="btntoday_Click" />
                                </li>
                                <asp:Button ID="btnnextday" runat="server" Visible="false" Text=" > " OnClick="btnnextday_Click" />
                            </ul>--%>
                        </div>
                        <div class="navigationmiddle">
                            <%-- <asp:Literal ID="ltdate" runat="server"></asp:Literal>--%>
                        </div>
                        <div class="week">
                            <%--  <ul>
                                <li>
                                    <asp:LinkButton ID="btnpreviousweek" runat="server" Text="Previous Week" OnClick="btnpreviousweek_Click"><</asp:LinkButton>
                                </li>
                                <li>Week</li>
                                <li>
                                    <asp:LinkButton ID="btnnextweek" runat="server" Text="Next Week" OnClick="btnnextweek_Click">></asp:LinkButton>
                                </li>
                            </ul>--%>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>


            </div>
        </div>
    </div>
</asp:Content>

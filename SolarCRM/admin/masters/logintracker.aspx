<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="logintracker.aspx.cs" Inherits="SolarCRM.admin.masters.logintracker" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/PagingUserControl/PagingUserControl.ascx" TagPrefix="uc1" TagName="page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
        <h1>Login Tracker</h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>DashBoard</a></li>
            <li>Masters</li>
            <li class="active">Login Tracker</li>
        </ol>
    </section>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="content-header">
                <div class="col-md-12">
                    <div id="divAlert" runat="server" class="alert alert-danger alert-dismissible" visible="false">
                        <asp:Button ID="btnalert" class="close" runat="server" Text="x" />
                        <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
                    </div>

                    <div id="divSuccess" runat="server" class="alert alert-success alert-dismissible" visible="false">
                        <asp:Button ID="btnSuccess" class="close" runat="server" Text="x" />
                        <asp:Label ID="lblSuccessMsg" runat="server"></asp:Label>
                    </div>

                </div>
            </div>


            <section class="content">
                <div class="row">
                    <div class="col-md-12">

                        <div class="box box-info">
                            <div class="box-header">

                                <div class="form-horizontal">
                                    <div class="form-group">

                                        <div class="col-sm-6">

                                            <span>Show 
                                                    <asp:DropDownList ID="ddlshowentry" Style="width: 70px; height: 30px" runat="server">
                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                                        <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                                        <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                                    </asp:DropDownList>
                                                entries
                                            </span>

                                        </div>
                                        <div class="col-sm-6 pull-right">
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


                            <!-- /.box-header -->
                            <div class="box-body table-scrollable1">

                                <asp:Repeater ID="rptLoginTrack" runat="server">
                                    <HeaderTemplate>
                                        <table id="example2" class="table table-bordered table-hover">
                                            <thead>
                                                <tr>
                                                    <th>Date</th>
                                                    <th>User Name</th>
                                                    <th>IP Address</th>
                                                    <th>LogIn Time</th>
                                                    <th>LogOut Time</th>

                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>

                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("LogInTime",  "{0:dd MMM yyyy}") %>'></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IPAddress") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("LogInTime","{0:H:mm:ss tt}") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblLogOutSesn" runat="server" Text=" ( Session ) " Visible='<%#  Eval("IsSession").ToString()=="True" ?true:false %>'></asp:Label>
                                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("LogOutTime","{0:H:mm:ss tt}") %>'></asp:Label>
                                            </td>

                                        </tr>

                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <div>
                                    <uc1:page ID="pageGrid" runat="server" Visible="true" OnPagerChanged="Pager_Changed"/>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>
            </section>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

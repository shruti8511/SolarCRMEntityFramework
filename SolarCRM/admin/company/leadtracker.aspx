<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="leadtracker.aspx.cs" Inherits="SolarCRM.admin.company.leadtracker" %>

<%@ Register Src="~/PagingUserControl/PagingUserControl.ascx" TagPrefix="uc1" TagName="page" %>
<%@ Register Src="~/PagingUserControl/Paggingctrl.ascx" TagPrefix="uc2" TagName="page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
        <h1>Lead Tracker</h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>DashBoard</a></li>

            <li class="active">Lead Tracker</li>
        </ol>
    </section>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div class="content-header">
                <div class="col-md-12">
                    <div id="divAlert" runat="server" class="alert alert-danger alert-dismissible" visible="false">
                        <asp:Button ID="btnalert" class="close" runat="server" Text="x"  />
                        <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
                    </div>

                    <div id="divSuccess" runat="server" class="alert alert-success alert-dismissible" visible="false">
                        <asp:Button ID="btnSuccess" class="close" runat="server" Text="x"  />
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

                                <asp:Repeater ID="rptLead" runat="server">
                                    <HeaderTemplate>
                                        <table id="example2" class="table table-bordered table-hover">
                                            <thead>
                                                <tr>
                                                    <th>Company Name</th>
                                                    <th>Address</th>
                                                    <th>City</th>
                                                    <th>State</th>                                                    
                                                    <th>Mobile</th>
                                                    <th>CustNotes</th>
                                                    <th>Source</th>
                                                    <th>Lead Date</th>
                                                    <th>Sales Rep</th>                                                  
                                                   <%-- <th>Edit</th>--%>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>

                                        <tr>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("Customer") %>'></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                            </td>
                                            
                                            <td>
                                                <asp:Label ID="lblMan" runat="server" Text='<%#Eval("StreetCity") %>'></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("StreetState") %>'></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("CustMobile") %>'></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("CustNotes") %>'></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("CompanySource") %>'></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("CustEntered" , "{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("EmployeeName") %>'></asp:Label>
                                            </td>

                                           <%-- <td><span>
                                                <asp:LinkButton ID="LinkButton5" runat="server"><i class="fa fa-edit"></i>
                                                </asp:LinkButton>
                                            </span></td>--%>
                                        </tr>

                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>

                                <div>
                                    <uc1:page ID="pageGrid" runat="server" Visible="true" />
                                </div>

                            </div>

                        </div>

                    </div>

                </div>
            </section>

        </ContentTemplate>
       <%-- <Triggers>
            <asp:PostBackTrigger ControlID="btnOpenInvoice" />
        </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>

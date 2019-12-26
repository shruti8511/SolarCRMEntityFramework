<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="contacts.aspx.cs" Inherits="SolarCRM.admin.company.contacts" %>

<%@ Register Src="~/PagingUserControl/PagingUserControl.ascx" TagPrefix="uc1" TagName="page" %>
<%@ Register Src="~/PagingUserControl/Paggingctrl.ascx" TagPrefix="uc2" TagName="page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
        <h1>Contacts List</h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>DashBoard</a></li>
            <li>Project</li>
            <li class="active">Contacts </li>
        </ol>
    </section>

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





                    <div class="box-body table-scrollable1">

                        <asp:Repeater ID="rptContacts" runat="server">
                            <HeaderTemplate>
                                <table id="example2" class="table table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>Name</th>
                                            <th>Company</th>
                                            <th>Address</th>
                                            <th>Contact</th>
                                            <th>Assigned to</th>
                                          <%--  <th>Suburb</th>--%>
                                            <th>P/CD</th>
                                            <th>Lead Type</th>
                                            <%--<th>Project Status</th>--%>
                                            <th>Quote Date</th>
                                            <th>Next FollowUp</th>
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
                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("Customer") %>'></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblMan" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("CustMobile") %>'></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("EmployeeName") %>'></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("StreetPostCode") %>'></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("CustType") %>'></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("QuoteSent" , "{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("LeadFollowUp", "{0:dd/MM/yyyy}") %>'></asp:Label>
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





                    <!-- /.box-header -->
                    <%--<div class="box-body table-scrollable1">

                   
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Company</th>
                                    <th>Address</th>
                                    <th>Contact</th>
                                    <th>Assigned to</th>
                                    <th>Suburb</th>
                                    <th>P/CD</th>
                                    <th>Lead Type</th>
                                    <th>Project Status</th>
                                    <th>Quote Date</th>
                                    <th>Next FollowUp</th>

                                </tr>
                            </thead>
                            <tbody>
                              
                                <tr>

                                    <td>John Fajak </td>
                                    <td>
                                        <span>
                                            <asp:LinkButton ID="lnkdetail" runat="server" ToolTip="Detail">John Fajak
                                            </asp:LinkButton>
                                        </span>
                                    </td>
                                    <td>56, Goodgee Street </td>
                                    <td>1234567890 </td>
                                    <td>Neil Clark </td>
                                    <td>Tuross Head</td>
                                    <td>2537 </td>
                                    <td>Customer </td>
                                    <td style="font-size: 13px">
                                        <asp:Label ID="Label10" runat="server" Width="100px">70825 - Active 70809 - Complete</asp:Label></td>
                                    <td>28 Feb 2017</td>
                                    <td>25 Mar 2017 </td>


                                </tr>

                            
                            </tbody>
                        </table>
                      
                    </div>--%>
                </div>

            </div>

        </div>
    </section>
</asp:Content>

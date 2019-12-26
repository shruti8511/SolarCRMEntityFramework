<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="invoicesissued.aspx.cs" Inherits="SolarCRM.admin.invoice.invoicesissued" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
        <h1>Invoices Issued</h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>DashBoard</a></li>
           
            <li class="active">Invoices Issued</li>
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


                    <!-- /.box-header -->
                    <div class="box-body table-scrollable1">

                        <%--<asp:Repeater ID="rptAllergy" runat="server">
                            <HeaderTemplate>--%>
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>State</th>
                                    <th>Man Qte</th>
                                    <th>Issued</th>
                                    <th>Proj Status</th>
                                    <th>Contact</th>
                                    <th>Tag</th>
                                    <th>Mobile</th>
                                    <th>Installer</th>
                                    <th>Inv#</th>
                                    <th>Installed</th>
                                    <th>Paid Amount</th>
                                    <th>Owing</th>
                                    <th>Total</th>
                                    <th>Surcharge</th>
                                    <th>O/Due</th>
                                    <th>Finance</th>
                                    <th>Date Paid</th>
                                    <th>Inv</th>
                                    <th>Follow Up</th>
                                    <th>Invoices Notes</th>
                                    <th>Installer Notes</th>
                                    <th>Email</th>
                                    <th>Panels</th>
                                    <th>Inverter</th>
                                    <th>Dep Req</th>
                                    <th>Dep Req</th>
                                   
                                </tr>
                            </thead>
                            <tbody>
                                <%-- </HeaderTemplate>
                            <ItemTemplate>--%>

                                <tr>

                                    <td>State Name </td>
                                    <td>ES16165 </td>
                                    <td>21 Nov 2015 </td>
                                    <td>Closed</td>
                                    <td>Paul Andrew Cooper</td>
                                    <td><input type="checkbox" /> </td>
                                    <td>
                                      0415908868
                                    </td>

                                    <td>Mayouf Boucetta </td>
                                    <td> <span>
                                            <asp:LinkButton ID="LinkButton2" runat="server" ToolTip="Edit">52947
                                            </asp:LinkButton>
                                        </span>	 </td>
                                    <td>07 Dec 2015 </td>
                                    <td>8099.00</td>
                                    <td>-100.00 </td>
                                    <td>7999.00 </td>
                                    <td>12.00 </td>
                                    <td> </td>
                                    <td>None</td>
                                    <td>16 Nov 2016 </td>
                                    <td><input type="checkbox" /></td>
                                    <td> </td>
                                    <td>06/12-Zara-Fully paid by EFT and receipt sent to Archi. 04.12-Archi- Customer will pay by EFT on the day of installation.</td>
                                    <td>04.12-Archi- Customer will pay by EFT on the day of installation. 04.12-Archi- This job booked for Mayouf Team B for AM.</td>
                                    <td>sir.duck@hotmail.com</td>
                                    <td>24</td>
                                    <td>SMA STP 6.0TL 3 Phase 2 MPPT</td>
                                    <td>800.00</td>
                                    <td>19 Feb 2017</td>
                                  
                                </tr>

                                <%-- </ItemTemplate>
                            <FooterTemplate>--%>
                            </tbody>
                        </table>
                        <%--  </FooterTemplate>
                        </asp:Repeater>--%>
                    </div>

                </div>

            </div>

        </div>
    </section>
</asp:Content>

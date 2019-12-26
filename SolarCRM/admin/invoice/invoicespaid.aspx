<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="invoicespaid.aspx.cs" Inherits="SolarCRM.admin.invoice.invoicespaid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <section class="content-header">
        <h1>Invoices Paid</h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>DashBoard</a></li>
          
            <li class="active">Invoices Paid</li>
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
                                    <th>Customer</th>
                                    <th>Project</th>
                                    <th>Project Status</th>
                                    <th>Inv #</th>
                                    <th>Date Paid</th>
                                    <th>Inv Total</th>
                                    <th>Dep Req</th>
                                    <th>Amnt Paid</th>
                                    <th>Bal Owing</th>
                                    <th>S/CHG</th>
                                    <th>Paid By</th>
                                    <th>Owing</th>
                                    <th>Verified</th>
                                    <th>Verified By</th>
                                    <th>Payment Notes</th>
                                    <th>Payment For</th>
                                    <th>Invoice Notes</th>
                                    <th></th>
                                  
                                </tr>
                            </thead>
                            <tbody>
                                <%-- </HeaderTemplate>
                            <ItemTemplate>--%>

                                <tr>

                                    <td><span>
                                            <asp:LinkButton ID="LinkButton1" runat="server" ToolTip="Edit">Zayne BREADMORE
                                            </asp:LinkButton>
                                        </span> </td>
                                    <td><span>
                                            <asp:LinkButton ID="LinkButton3" runat="server" ToolTip="Edit">Mansfield-29 Kareen Court 
                                            </asp:LinkButton>
                                        </span></td>
                                    <td>Closed </td>
                                    <td>50770</td>
                                    <td>27-Nov-2015</td>
                                    <td>112.00 </td>
                                    <td>
                                      	0.00
                                    </td>

                                    <td>122.00 </td>
                                    <td>	0.00</td>
                                    <td> </td>
                                    <td>EFT</td>
                                    <td>13 Dec 2016</td>
                                    <td>Neil Clark </td>
                                    <td>Notes</td>
                                    <td>Deposit </td>
                                    <td>06/10-Zara-Customer paid fully,receipt attached to other docs. 01/10-Zara-Customer will do EFT, prior to installation.</td>
                                    <td>Revert </td>
                                   
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

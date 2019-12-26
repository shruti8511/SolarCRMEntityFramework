<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="followups.aspx.cs" Inherits="SolarCRM.admin.view.followups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <section class="content-header">
        <h1>Follow Ups</h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>DashBoard</a></li>
           
            <li class="active">Follow Ups</li>
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
                                    <th>Follow For</th>
                                    <th>Company</th>
                                    <th>Phone</th>
                                    <th>Mobile</th>
                                    <th>NextFollowup Date</th>
                                    <th>Description</th>
                                    <th></th>
                                    <th></th>
                                    <th> Address</th>
                                    <th>Location</th>
                                    <th>Email</th>
                                   
                                </tr>
                            </thead>
                            <tbody>
                                <%-- </HeaderTemplate>
                            <ItemTemplate>--%>

                                <tr>

                                    <td>Neil Clark</td>
                                    <td><span>
                                            <asp:LinkButton ID="LinkButton3" runat="server">Avani Patel
                                            </asp:LinkButton>
                                        </span></td>
                                    <td>1234567890 </td>
                                    <td>9876543210</td>
                                    <td>11 Feb 2017</td>
                                    <td>Call friday, price given </td>
                                    <td><span>
                                            <asp:LinkButton ID="LinkButton1" runat="server">Add FollowUp
                                            </asp:LinkButton>
                                        </span></td>
                                     <td><span>
                                            <asp:LinkButton ID="LinkButton2" runat="server">Close FollowUp
                                            </asp:LinkButton>
                                        </span></td>
                                    <td>3/38 Meehan St</td>
                                    <td>seville , WA - 6112 </td>
                                    <td>abc@xyz.com</td>

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

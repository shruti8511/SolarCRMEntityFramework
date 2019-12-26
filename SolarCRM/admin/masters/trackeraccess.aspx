<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="trackeraccess.aspx.cs" Inherits="SolarCRM.admin.masters.trackeraccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
        <h1>Tracker Access
       <%-- <small>Preview</small>--%>
        </h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a></li>
            <li><a href="#">Master</a></li>
            <li class="active">Tracker Access </li>
        </ol>
    </section>

    <section class="content">
        <div class="row">

            <div class="col-md-5">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Tracker Access</h3>
                    </div>
                    <div class="form-horizontal">
                        <div class="box-body">

                            <div class="form-group">
                                <label class="col-sm-3 control-label">User</label>
                                <div class="col-sm-9">
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
                                <label class="col-sm-3 control-label">Access</label>
                                <div class="col-sm-9">
                                    <asp:ListBox ID="lb1" runat="server" Rows="5" style="width:100%">
                                        <asp:ListItem Value="Bu">Blue</asp:ListItem>
                                        <asp:ListItem Value="Re">Red</asp:ListItem>
                                        <asp:ListItem Value="Gr">Green</asp:ListItem>
                                        <asp:ListItem Value="Pu">Purple</asp:ListItem>
                                        <asp:ListItem Value="Ba">Black</asp:ListItem>
                                    </asp:ListBox>
                                </div>
                            </div>


                        </div>
                    </div>


                    <div class="box-footer">
                        <button type="reset" class="btn btn-default">Reset</button>
                        <button type="submit" class="btn btn-info pull-right">Save</button>
                    </div>

                </div>
            </div>

            <div class="col-md-7">
                <div class="box box-primary">
                    <div class="box-header">
                        <div class="col-md-6">
                            <h3 class="box-title">Manage Tracker Access</h3>
                        </div>
                        <div class="col-md-6 pull-right">

                            <div class="input-group input-group-sm">
                                <asp:TextBox ID="TextBox1" ClientIDMode="Static" runat="server" placeholder="search keyword" class="form-control"></asp:TextBox>
                                <span class="input-group-btn">
                                    <asp:Button ID="Button1" runat="server" class="btn btn-info btn-flat" Text="Search" />
                                    <asp:Button ID="Button2" runat="server" class="btn btn-default" Text="Clear" />
                                </span>
                            </div>
                        </div>


                    </div>
                    <!-- /.box-header -->
                    <div class="box-body table-scrollable1">
                        <table id="Table1" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                   
                                    <th>Employee</th>
                                     <th>Tracker Name</th>
                                    <th></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                   
                                     <td>
                                        Neil Clark</td>
                                    <td>Meter Approval,Finance Tracker,Sales Person Install,D2D commission,Faulty Products,Overseas Delievery,WHS Inv Issued tracker</td>

                                    <td align="center">
                                        <span>
                                            <asp:LinkButton ID="lnkEdit" runat="server" ToolTip="Edit"><i class="fa fa-edit"></i>
                                            </asp:LinkButton>
                                        </span>
                                    </td>

                                    <td align="center">
                                        <span>
                                            <asp:LinkButton ID="LinkButton1" runat="server" ToolTip="Delete"><i class="fa fa-trash-o"></i>
                                            </asp:LinkButton>
                                        </span>
                                    </td>

                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <!-- /.box-body -->
                </div>
                <div id="Div1" style="text-align: center; display: none;">
                    <p>No Record Found</p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

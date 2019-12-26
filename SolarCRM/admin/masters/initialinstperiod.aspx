<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="initialinstperiod.aspx.cs" Inherits="SolarCRM.admin.masters.initialinstperiod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <section class="content-header">
        <h1>Initial Installation Period 
       <%-- <small>Preview</small>--%>
        </h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a></li>
           <li><a href="#">Master</a></li>
            <li class="active">Initial Installation Period  </li>
        </ol>
    </section>

    <section class="content">
        <div class="row">

            <div class="col-md-5">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title"> Initial Installation Period </h3>
                    </div>
                    <div class="form-horizontal">
                        <div class="box-body">

                            <div class="form-group">
                                <label class="col-sm-3 control-label">Initial Installation Period  </label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" ID="txtinitialinstperiod" Enabled="false"></asp:TextBox>
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
                            <h3 class="box-title">ManageInitial Installation Period</h3>
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
                                  
                                    <th>Installation Period	</th>
                                    <th></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                   
                                    <td>28</td>

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

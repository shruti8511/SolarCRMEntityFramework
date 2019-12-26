<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="stockitem.aspx.cs" Inherits="SolarCRM.admin.stock.stockitem" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/PagingUserControl/PagingUserControl.ascx" TagPrefix="uc1" TagName="page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
        <h1>Stock
       <%-- <small>Preview</small>--%>
        </h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a></li>
            <li><a href="#">Stock Item</a></li>

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

                <div class="row">
                    <div class="col-md-12">

                        <div class="box box-primary">
                            <div class="box-header with-border">
                                <h3 class="box-title">Stock</h3>
                            </div>

                            <div class="form-horizontal">
                                <div class="box-body">
                                    <div class="col-md-6">

                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Stock Category :</label>
                                            <div class="col-sm-9">
                                                <asp:DropDownList ID="ddlStockCategory" runat="server" ClientIDMode="Static" CssClass="form-control select2" Style="width: 100%;" OnSelectedIndexChanged="ddlStockCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </div>
                                        </div>



                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Stock Item :</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtStockItem" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Stock Model :</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtStockModel" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                            </div>
                                        </div>



                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Stock Size :</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtStockSize" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                            </div>
                                        </div>


                                        <asp:Panel ID="pnlInverterPahase" runat="server" Visible="false">

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Inverter Phase :</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtInverterPhase" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                                </div>
                                            </div>


                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Inverter Certificate :</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtInverterCert" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                                </div>
                                            </div>

                                        </asp:Panel>

                                    </div>


                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Brand :</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtStockManufacturer" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                            </div>
                                        </div>



                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Stock Series :</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtStockSeries" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="form-group ">
                                            <label class="col-sm-3 control-label">Stock Price :</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtCostPrice" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                            </div>
                                        </div>



                                        <asp:Panel ID="pnlInverterMppt" runat="server" Visible="false">
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">MPPT :</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtMPPT" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                                </div>
                                            </div>
                                        </asp:Panel>


                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Description :</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                </div>
                            </div>


                            <div class="box-footer">
                                <asp:Button CssClass="btn btn-info pull-right" ID="btnAdd" runat="server"
                                    Text="Add" ValidationGroup="company" TabIndex="31" OnClick="btnAdd_Click" />
                                <asp:Button CssClass="btn btn-info pull-right" ID="btnUpdate" runat="server"
                                    Text="Update" Visible="false" ValidationGroup="company" TabIndex="32" />
                                <asp:Button CssClass="btn btn-default" ID="btnReset" runat="server"
                                    CausesValidation="false" Text="Reset" TabIndex="33" OnClick="btnReset_Click" />

                                <asp:Button CssClass="btn btn-default" ID="btnCancel" runat="server" Visible="false" CausesValidation="false" Text="Reset" TabIndex="34" />

                            </div>
                        </div>

                    </div>


                    <div id="divcompanylist">
                        <div class="col-md-12">
                            <div class="box box-primary">
                                <div class="box-header">

                                    <div class="col-md-6">
                                        <h3 class="box-title">Stock List</h3>
                                    </div>

                                    <div class="col-md-6 pull-right">

                                        <div class="input-group input-group-sm">
                                            <asp:TextBox ID="txtSearch" ClientIDMode="Static" runat="server" placeholder="search keyword" class="form-control"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <asp:Button ID="btnSearch" runat="server" class="btn btn-info btn-flat" Text="Search" />
                                                <asp:Button ID="btnClear" runat="server" class="btn btn-default" Text="Clear" />
                                            </span>
                                        </div>
                                    </div>


                                </div>
                                <!-- /.box-header -->
                                <div class="box-body table-scrollable1">
                                    <asp:Repeater ID="rptStockList" runat="server">
                                        <HeaderTemplate>
                                            <table id="example2" class="table table-bordered table-hover">
                                                <thead>
                                                    <tr>
                                                        <th class="text-center">Category</th>
                                                        <th class="text-center">Brand</th>
                                                        <th class="text-center">Item</th>
                                                        <th class="text-center">Series</th>
                                                        <th class="text-center">Model </th>
                                                        <%--  <th class="text-center">Price</th>--%>
                                                        <th class="text-center">Size</th>
                                                        <%--   <th class="text-center">Description </th>--%>
                                                        <th class="text-center">Edit </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>

                                            <tr>
                                                <td>

                                                    <asp:HiddenField ID="hndStockItemID" runat="server" Value='<%#Eval("StockItemID") %>' />
                                                    <asp:Label ID="lblZone" runat="server" Text='<%#Eval("StockCategory") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("StockManufacturer") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("StockItem") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("StockSeries") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("StockModel") %>'></asp:Label></td>
                                                <%-- <td>
                                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("CostPrice") %>'></asp:Label></td>--%>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("StockSize") %>'></asp:Label></td>
                                                <%--<td>
                                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("StockDescription") %>'></asp:Label></td>--%>

                                                <td class="text-center">
                                                    <span>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                                                            CommandArgument='<%# Eval("StockItemID") %>'><i class="fa fa-edit"></i>
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

                </div>
            </section>

        </ContentTemplate>
    </asp:UpdatePanel>






    <%--<asp:ModalPopupExtender ID="ModalPopupExtenderInvPay" runat="server" BackgroundCssClass="modalbackground"
        DropShadow="true" PopupControlID="divAddInvPay" TargetControlID="btnNULLInvPay">
    </asp:ModalPopupExtender>

    <div id="divAddInvPay" class="modalpopup" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" >&times;</button>
                    <h4 class="modal-title">Modal Header</h4>
                </div>
                <div class="modal-body">
                    <p>Some text in the modal.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>
    
    <asp:Button ID="btnNULLInvPay" Style="display: none;" runat="server" />--%>

</asp:Content>

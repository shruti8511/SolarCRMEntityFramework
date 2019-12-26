<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="elecdistributor.aspx.cs" Inherits="SolarCRM.admin.masters.elecdistributor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/PagingUserControl/PagingUserControl.ascx" TagPrefix="uc1" TagName="page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="content-header">
        <h1>Elec Distributor
       <%-- <small>Preview</small>--%>
        </h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a></li>
            <li><a href="#">Master</a></li>
            <li class="active">Elec Distributor </li>
        </ol>
    </section>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div class="content-header">
                <div class="col-md-12">
                    <div id="divAlert" runat="server" class="alert alert-danger alert-dismissible" visible="false">
                        <asp:Button ID="btnalert" class="close" runat="server" Text="x" OnClick="btnalert_Click"/>
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

                    <div class="col-md-5">
                        <div class="box box-primary">
                            <div class="box-header with-border">
                                <h3 class="box-title">Elec Distributor</h3>
                            </div>
                            <div class="form-horizontal">
                                <div class="box-body">


                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Elec Distributor <span class="red">*</span></label>
                                        <div class="col-sm-8">
                                            <asp:HiddenField ID="hdnElecDistributorID" runat="server" ClientIDMode="Static" />
                                            <asp:TextBox ID="txtElecDistributor" ClientIDMode="Static" class="form-control" runat="server" placeholder="Elec Distributor"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvElecDistributor" runat="server" ErrorMessage="* Required" ControlToValidate="txtElecDistributor"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator></span>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Elec Dist ABB <span class="red">*</span></label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txtElecDistABB" ClientIDMode="Static" class="form-control" runat="server" placeholder="Elec Dist ABB"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvElecDistABB" runat="server" ErrorMessage="* Required" ControlToValidate="txtElecDistABB"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator></span>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Address <span class="red">*</span></label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txtAddress" ClientIDMode="Static" class="form-control" runat="server" placeholder="Address"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="* Required" ControlToValidate="txtAddress"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator></span>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Mobile No <span class="red">*</span></label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txtMobileNo" ClientIDMode="Static" class="form-control" runat="server" placeholder="Mobile No"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ErrorMessage="* Required" ControlToValidate="txtMobileNo"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator></span>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Email <span class="red">*</span></label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txtEmail" ClientIDMode="Static" class="form-control" runat="server" placeholder="Email"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="* Required" ControlToValidate="txtEmail"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator></span>
                                        </div>
                                    </div>

                                       <div class="form-group">
                                        <label class="col-sm-4 control-label">State <span class="red">*</span></label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control select2" AppendDataBoundItems="true" TabIndex="2" Style="width: 100%;">
                                                <asp:ListItem Value="" Text="Select State"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvddlState" runat="server" ErrorMessage="* Required"
                                                ControlToValidate="ddlState" ValidationGroup="error"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <div class="col-sm-offset-4 col-sm-10">
                                            <div class="checkbox">
                                                <label>
                                                    <asp:CheckBox ID="chkElecDistAppReq" runat="server" Checked="true" />
                                                    Elec Dist AppReq
                     
                                                </label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="col-sm-offset-4 col-sm-10">
                                            <div class="checkbox">
                                                <label>
                                                    <asp:CheckBox ID="chkActive" runat="server" Checked="true" />
                                                    Is Active?
                     
                                                </label>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>


                            <div class="box-footer">
                                <asp:Button ID="btnReset" class="btn btn-default" runat="server" Text="Reset" OnClick="btnReset_Click" />
                                <asp:Button ID="btnUpdate" Visible="false" runat="server" CssClass="btn btn-info pull-right" Text="Update" OnClick="btnUpdate_Click" ValidationGroup="error" />
                                <asp:Button ID="btnSave" class="btn btn-info pull-right" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="error" />
                            </div>

                        </div>
                    </div>

                    <div class="col-md-7">
                        <div class="box box-primary">
                            <div class="box-header">
                                <div class="col-md-6">
                                    <h3 class="box-title">Manage Elec Distributor</h3>
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
                                <asp:Repeater ID="rptElecDistributor" runat="server" OnItemCommand="rptElecDistributor_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="Table1" class="table table-bordered table-hover">
                                            <thead>
                                                <tr>
                                                    <th class="text-center">Active</th>
                                                    <th class="text-center">Elec Distributor</th>
                                                    <th class="text-center">Elec Dist ABB</th>
                                                    <th class="text-center">Address</th>
                                                    <th class="text-center">Mobile No</th>
                                                    <th class="text-center">Email</th>
                                                       <th class="text-center">State</th>
                                                    <th class="text-center">Elec Dist AppReq</th>
                                                    <th class="text-center">Edit</th>
                                                    <th class="text-center">Delete</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center">
                                                <asp:CheckBox ID="chkStatus" runat="server" Checked='<%# Eval("Active")%>' Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblElecDistributor" runat="server" Text='<%#Eval("ElecDistributor") %>'></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="lblElecDistABB" runat="server" Text='<%#Eval("ElecDistABB") %>'></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile") %>'></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                            </td>
                                              <td>
                                                <asp:Label ID="lblState" runat="server" Text='<%#Eval("State") %>'></asp:Label>
                                            </td>
                                            <td class="text-center">
                                                <asp:CheckBox ID="chkElecDistAppReq" runat="server" Checked='<%# Eval("ElecDistAppReq")%>' Enabled="false" />
                                            </td>

                                            <td class="text-center">
                                                <span>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" ToolTip="Edit" CommandName="Edit"
                                                        CommandArgument='<%# Eval("ElecDistributorID") %>'><i class="fa fa-edit"></i>
                                                    </asp:LinkButton>
                                                </span>
                                            </td>

                                            <td class="text-center">
                                                <span>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" CommandName="Delete"
                                                        CommandArgument='<%# Eval("ElecDistributorID") %>' OnClientClick="return confirm('Are you Want to Remove Elec Distributor?')">
                                                 <i class="fa fa-trash-o"></i></asp:LinkButton>
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
                </div>
            </section>

            <script>
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_pageLoaded(pageLoaded);
                //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
                prm.add_beginRequest(BeginRequestHandler);
                // Raised after an asynchronous postback is finished and control has been returned to the browser.
                prm.add_endRequest(EndRequestHandler);
                function BeginRequestHandler(sender, args) {
                    //Shows the modal popup - the update progress
                    var popup = $find('<%= newmodalPopup.ClientID %>');
                    if (popup != null) {
                        popup.show();
                    }
                }
                function EndRequestHandler(sender, args) {
                    //Hide the modal popup - the update progress
                    var popup = $find('<%= newmodalPopup.ClientID %>');
                    if (popup != null) {
                        popup.hide();
                    }
                    if (args.get_error() != undefined) {
                        args.set_errorHandled(true);
                    }
                }
                function pageLoaded() {
                    //alert($(".search-select").attr("class"));
                    $(".select2").select2({
                        placeholder: "Select",
                        allowClear: true
                    });
                    if ($(".tooltips").length) {
                        $('.tooltips').tooltip();
                    }
                    $(function () {
                        var $progressnote = $('.slideProgressBoard');
                        $('#clickme2').click(function (e) {
                            e.stopPropagation();
                            if ($progressnote.is(":hidden")) {
                                $progressnote.slideDown("slow");
                            } else {
                                $progressnote.slideUp("slow");
                            }
                        }); $('.slideProgressBoard').click(function (e) {
                            e.stopPropagation();
                        });
                        $(document.body).click(function () {
                            if ($progressnote.not(":hidden")) {
                                $progressnote.slideUp("slow");
                            }
                        });
                    });
                }
            </script>

            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
                <ProgressTemplate>
                    <div>
                        <asp:Image ID="imgloading" ImageUrl="~/Content/img/progressbar.gif" ClientIDMode="Static" AlternateText="Processing"
                            runat="server" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>

            <asp:ModalPopupExtender ID="newmodalPopup" runat="server" TargetControlID="UpdateProgress1"
                PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup1" />
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

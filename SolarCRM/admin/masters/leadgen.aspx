<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="leadgen.aspx.cs" Inherits="SolarCRM.admin.masters.leadgen" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/PagingUserControl/PagingUserControl.ascx" TagPrefix="uc1" TagName="page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
        <h1>Lead Gen
       <%-- <small>Preview</small>--%>
        </h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a></li>
            <li><a href="#">Master</a></li>
            <li class="active">Lead Gen</li>
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

                    <div class="col-md-5">
                        <div class="box box-primary">
                            <div class="box-header with-border">
                                <h3 class="box-title">Lead Gen</h3>
                            </div>
                            <div class="form-horizontal">
                                <div class="box-body">

                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Project Manager <span class="red">*</span> </label>
                                        <div class="col-sm-8">
                                            <asp:HiddenField ID="hdnLeadGenID" runat="server" ClientIDMode="Static" />


                                            <asp:DropDownList ID="ddlProjectManager" CssClass="form-control select2" Style="width: 100%;" TabIndex="1" runat="server">
                                                <asp:ListItem Text="Manoj Mistry" Value="1" />
                                                <asp:ListItem Text="Pratik Patel" Value="2" />
                                                <asp:ListItem Text="Piyush Limbani" Value="3" />
                                            </asp:DropDownList>


                                           <%-- <asp:DropDownList ID="ddlProjectManager" runat="server" CssClass="form-control select2" Style="width: 100%;" TabIndex="1"></asp:DropDownList>--%>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvProjectManager" runat="server" ErrorMessage="* Required" ControlToValidate="ddlProjectManager"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator></span>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">First Name <span class="red">*</span> </label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txtFName" ClientIDMode="Static" class="form-control" runat="server" placeholder="First Name"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvFName" runat="server" ErrorMessage="* Required" ControlToValidate="txtFName"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator></span>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Last Name<span class="red">*</span> </label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txtLName" ClientIDMode="Static" class="form-control" runat="server" placeholder="Last Name"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvLName" runat="server" ErrorMessage="* Required" ControlToValidate="txtLName"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator></span>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Name<span class="red">*</span> </label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txtName" ClientIDMode="Static" class="form-control" runat="server" placeholder="Name"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="* Required" ControlToValidate="txtName"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator></span>
                                        </div>
                                    </div>



                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Contact Num<span class="red">*</span> </label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txtContactNum" ClientIDMode="Static" class="form-control" runat="server" placeholder="Contact Num"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvContactNum" runat="server" ErrorMessage="* Required" ControlToValidate="txtContactNum"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator></span>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="col-sm-offset-3 col-sm-10">
                                            <div class="checkbox">
                                                <label>
                                                    <asp:CheckBox ID="chkActive" runat="server" />
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
                                    <h3 class="box-title">Manage Lead Gen</h3>
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
                                <asp:Repeater ID="rptLeadGen" runat="server" OnItemCommand="rptLeadGen_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="Table1" class="table table-bordered table-hover">
                                            <thead>
                                                <tr>
                                                    <th class="text-center">Active</th>
                                                    <th class="text-center">Lead Gen</th>
                                                    <th class="text-center">Contact</th>
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
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                            </td>


                                            <td>
                                                <asp:Label ID="lblContactNum" runat="server" Text='<%#Eval("ContactNum") %>'></asp:Label>
                                            </td>

                                            <td class="text-center">
                                                <span>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                                                        CommandArgument='<%# Eval("LeadGenID") %>'><i class="fa fa-edit"></i>
                                                    </asp:LinkButton>
                                                </span>
                                            </td>

                                            <td class="text-center">
                                                <span>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" CommandName="Delete"
                                                        CommandArgument='<%# Eval("LeadGenID") %>' OnClientClick="return confirm('Are you Want to Remove Source Sub?')">
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

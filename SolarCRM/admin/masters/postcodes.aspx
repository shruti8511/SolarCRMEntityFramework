<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="postcodes.aspx.cs" Inherits="SolarCRM.admin.masters.postcodes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/PagingUserControl/PagingUserControl.ascx" TagPrefix="uc1" TagName="page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
        <h1>Post Codes
       <%-- <small>Preview</small>--%>
        </h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a></li>
            <li><a href="#">Master</a></li>
            <li class="active">Post Codes </li>
        </ol>
    </section>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="content-header">
                <div class="col-md-12">
                    <div id="divAlert" runat="server" class="alert alert-danger alert-dismissible" visible="false">
                        <asp:Button ID="btnalert" CssClass="close" runat="server" Text="x" OnClick="btnalert_Click" />
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
                                <h3 class="box-title">Post Codes</h3>
                            </div>
                            <div class="form-horizontal">
                                <div class="box-body">

                                    <div class="form-group formmargin">
                                        <label class="col-sm-3 control-label">PostCode<span class="red">*</span></label>
                                        <div class="col-sm-9">
                                            <asp:HiddenField ID="hdnPostCodeID" runat="server" ClientIDMode="Static" />
                                            <asp:TextBox ID="txtPostCode" ClientIDMode="Static" class="form-control" runat="server" TabIndex="1" placeholder="Post Code"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvtxtPostCode" runat="server" ErrorMessage="* Required" ControlToValidate="txtPostCode"
                                                    ValidationGroup="postcode"></asp:RequiredFieldValidator></span>
                                        </div>
                                    </div>

                                    <div class="form-group formmargin">
                                        <label class="col-sm-3 control-label">Suburb <span class="red">*</span></label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtSuburb" ClientIDMode="Static" class="form-control" runat="server" TabIndex="2" placeholder="Suburb"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvtxtSuburb" runat="server" ErrorMessage="* Required" ControlToValidate="txtSuburb"
                                                    ValidationGroup="postcode"></asp:RequiredFieldValidator></span>
                                        </div>
                                    </div>

                                    <div class="form-group formmargin">
                                        <label class="col-sm-3 control-label">State <span class="red">*</span></label>
                                        <div class="col-sm-9">
                                            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control select2" AppendDataBoundItems="true" TabIndex="3" Style="width: 100%;">
                                                <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvddlState" runat="server" ErrorMessage="* Required"
                                                ControlToValidate="ddlState" ValidationGroup="postcode"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="form-group formmargin">
                                        <label class="col-sm-3 control-label">Area <span class="red">*</span></label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtArea" ClientIDMode="Static" class="form-control" runat="server" TabIndex="4" placeholder="Area"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvtxtArea" runat="server" ErrorMessage="* Required" ControlToValidate="txtArea"
                                                    ValidationGroup="postcode"></asp:RequiredFieldValidator></span>
                                        </div>
                                    </div>

                                    <div class="form-group formmargin">
                                        <label class="col-sm-3 control-label">AreaType<span class="red">*</span></label>

                                        <div class="col-sm-9">

                                            <asp:RadioButtonList ID="rblArea" runat="server" RepeatDirection="Horizontal" TabIndex="5">
                                                <asp:ListItem Value="1">Metro</asp:ListItem>
                                                <asp:ListItem Value="2">Regional</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="rfvrblArea" runat="server" ErrorMessage="* Required"
                                                ValidationGroup="postcode" ControlToValidate="rblArea"></asp:RequiredFieldValidator>

                                        </div>

                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label">PO Boxes </label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtPOBoxes" ClientIDMode="Static" class="form-control" runat="server" TabIndex="4" placeholder="PO Boxes"></asp:TextBox>

                                        </div>
                                    </div>

                                    <div class="form-group formmargin">
                                        <label class="col-sm-3 control-label">Company Location<span class="red">*</span></label>
                                        <div class="col-sm-9">
                                            <asp:DropDownList ID="ddlCompanyLocation" runat="server" CssClass="form-control select2" AppendDataBoundItems="true" TabIndex="3" Style="width: 100%;">
                                                <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvddlCompanyLocation" runat="server" ErrorMessage="* Required"
                                                ControlToValidate="ddlCompanyLocation" ValidationGroup="postcode"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="col-sm-offset-3 col-sm-10">
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
                                <asp:Button ID="btnUpdate" Visible="false" runat="server" CssClass="btn btn-info pull-right" Text="Update" OnClick="btnUpdate_Click" ValidationGroup="postcode" />
                                <asp:Button ID="btnSave" class="btn btn-info pull-right" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="postcode" />
                            </div>

                        </div>
                    </div>

                    <div class="col-md-7">
                        <div class="box box-primary">
                            <div class="box-header">
                                <div class="col-md-6">
                                    <h3 class="box-title">Manage Post Codes</h3>
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

                                <asp:Repeater ID="rptPostCode" runat="server" OnItemCommand="rptPostCode_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example2" class="table table-bordered table-hover">
                                            <thead>
                                                <tr>
                                                    <th class="text-center">IsActive</th>
                                                    <th class="text-center">Post Code</th>
                                                    <th class="text-center">Suburb</th>
                                                    <th class="text-center">State</th>
                                                    <th class="text-center">Area</th>
                                                    <th class="text-center">Area Type</th>
                                                    <th class="text-center">PO Boxes</th>
                                                    <th class="text-center">CompanyLocation</th>
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
                                            <td> <asp:Label ID="lblCompanySourceSub" runat="server" Text='<%#Eval("PostCode") %>'></asp:Label></td>
                                            <td> <asp:Label ID="Label1" runat="server" Text='<%#Eval("Suburb") %>'></asp:Label></td>
                                            <td> <asp:Label ID="Label2" runat="server" Text='<%#Eval("State") %>'></asp:Label></td>
                                            <td> <asp:Label ID="Label3" runat="server" Text='<%#Eval("Area") %>'></asp:Label></td>
                                            <td> <asp:Label ID="Label4" runat="server" Text='<%#Eval("AreaTypee") %>'></asp:Label></td>
                                            <td> <asp:Label ID="Label5" runat="server" Text='<%#Eval("POBoxes") %>'></asp:Label></td>
                                            <td> <asp:Label ID="Label6" runat="server" Text='<%#Eval("CompanyLocation") %>'></asp:Label></td>

                                            <td class="text-center">
                                                <span>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                                                        CommandArgument='<%# Eval("PostCodeID") %>'><i class="fa fa-edit"></i>
                                                    </asp:LinkButton>
                                                </span>
                                            </td>

                                            <td class="text-center">
                                                <span>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" CommandName="Delete"
                                                        CommandArgument='<%# Eval("PostCodeID") %>' OnClientClick="return confirm('Are you Want to Remove PostCode?')">
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

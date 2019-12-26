<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="lead.aspx.cs" Inherits="SolarCRM.admin.upload.lead" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/PagingUserControl/PagingUserControl.ascx" TagPrefix="uc1" TagName="page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="content-header">
        <h1>Lead
       <%-- <small>Preview</small>--%>
        </h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a></li>
            <li><a href="#">Upload</a></li>
            <li class="active">Lead</li>
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

                    <div id="divPanEmpty" runat="server" class="alert alert-danger alert-dismissible" visible="false">
                        <asp:Button ID="PanEmpty" CssClass="close" runat="server" Text="x" OnClick="PanEmpty_Click" />
                        <asp:Label ID="lblPanEmpty" runat="server"></asp:Label>
                    </div>

                </div>
            </div>

            <section class="content">
                <div class="row">
                   


                   
                        <div class="col-md-12">
                            <div class="box box-primary">
                                <div class="box-header">
                                    <div class="col-md-6 pull-left">
                                          <asp:Button ID="btnAddLead" class="btn btn-info pull-right" runat="server" Text="Add Lead"  OnClick="btnAddLead_Click" />
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
                                    <asp:Repeater ID="rptLead" runat="server">
                                        <HeaderTemplate>
                                            <table id="example2" class="table table-bordered table-hover">
                                                <thead>
                                                    <tr>
                                                        <th class="text-center">Company Name</th>
                                                        <th class="text-center">System</th>
                                                        <th class="text-center">Email</th>
                                                        <th class="text-center">Phone</th>
                                                        <th class="text-center">Mobile</th>
                                                        <th class="text-center">Address</th>
                                                        <th class="text-center">City</th>
                                                        <th class="text-center">State</th>
                                                        <th class="text-center">Dup.</th>
                                                        <th class="text-center">Not Dup.</th>
                                                        <th class="text-center">Notes</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>

                                                    <asp:HiddenField ID="hdnWebDownloadID" runat="server" Value='<%#Eval("WebDownloadID") %>' />
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Customer") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("System") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("ContEmail") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("CustPhone") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("ContMobile") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("Address") %>'></asp:Label></td>

                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("City") %>'></asp:Label></td>

                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("State") %>'></asp:Label></td>

                                                <td>
                                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("Duplicate") %>'></asp:Label></td>

                                                <td>
                                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("NotDuplicate") %>'></asp:Label></td>

                                                <td>
                                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("Notes") %>'></asp:Label></td>

                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>

                                    </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                    <div>
                                        <uc1:page ID="pageGrid" runat="server" Visible="true" OnPagerChanged="Pager_Changed"/>
                                    </div>
                                </div>
                                <!-- /.box-body -->
                            </div>

                        </div>
                       
                     <div class="col-md-12">
                        <div class="col-md-6">
                            <div class="box box-primary">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Upload Lead</h3>
                                </div>
                                <div class="form-horizontal">
                                    <div class="box-body" style="margin-top: 15px;">

                                        <div class="form-group formmargin">
                                            <label class="col-sm-3 control-label">Upload Excel File<span class="red">*</span></label>
                                            <div class="col-sm-9">
                                                <span>
                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FileUpload1"
                                                        ValidationGroup="success" ValidationExpression="^.+(.xls|.XLS|.xlsx|.XLSX)$"
                                                        Display="Dynamic" ErrorMessage=".xls only"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Required"
                                                        ControlToValidate="FileUpload1" Display="Dynamic" ValidationGroup="success"></asp:RequiredFieldValidator>&nbsp;
                                    &nbsp; </span>
                                                <div class="clear">
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="box-footer">
                                    <asp:Button ID="btnReset" class="btn btn-default" runat="server" Text="Reset" />

                                    <asp:Button ID="btnSave" class="btn btn-info pull-right" runat="server" Text="Save" ValidationGroup="success" OnClick="btnSave_Click" />
                                </div>

                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="box box-primary">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Lead</h3>
                                </div>
                                <div class="form-horizontal" style="height: 100px;">
                                    <div class="box-body" style="margin-top: 15px;">
                                        <span>
                                            <asp:HyperLink ID="hypsubscriber" runat="server" NavigateUrl="../../userfiles/LeadFormate/Lead.xlsx"
                                                Target="_blank">Click here</asp:HyperLink>
                                            to download Excel Sheet format. </span>
                                    </div>
                                </div>

                                <%--<div class="box-footer" style="height:15px;">
                                
                            </div>--%>
                            </div>
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

        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>

    </asp:UpdatePanel>

</asp:Content>

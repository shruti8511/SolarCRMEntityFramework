<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Quotation.aspx.cs" Inherits="SolarCRM.admin.invoice.Quotation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Create Quotation
       <%-- <small>Preview</small>--%>
        </h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a></li>
            <li><a href="#">Account</a></li>
            <li class="active">Invoice</li>
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
                <div class="row" id="divcompanylist" runat="server">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-body">
                                <div class="form-group">
                                    <br />
                                    <br />
                                    <label class="col-md-2 control-label">Project Type</label>
                                    <div class="col-md-4">

                                        <div class="col-sm-5">
                                            <asp:CheckBox ID="chkActive" runat="server" Checked="true" OnCheckedChanged="chkActive_CheckedChanged" AutoPostBack="true" Text="Active" />
                                        </div>

                                        <div class="col-sm-5">
                                            <asp:CheckBox ID="chkComplete" runat="server" OnCheckedChanged="chkComplete_CheckedChanged" AutoPostBack="true" Text="Complete" />
                                        </div>
                                        <div class="col-md-3"></div>
                                    </div>

                                    <label class="col-md-2 control-label">Select Project <span class="red">*</span> </label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlProject" runat="server" CssClass="form-control select2" Style="width: 100%;"
                                            OnSelectedIndexChanged="ddlProject_SelectedIndexChanged"
                                            AutoPostBack="true" AppendDataBoundItems="true">
                                            <asp:ListItem Value="">Select</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvddlProject" runat="server" ErrorMessage="* Required"
                                            ControlToValidate="ddlProject" Display="Dynamic" ValidationGroup="selectcompany"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>



                            <div id="divdetails" runat="server" visible="false" class="box-body">
                                <ul class="timeline">
                                    <asp:Repeater ID="rptTaskList" runat="server" OnItemCommand="rptTaskList_ItemCommand" OnItemDataBound="rptTaskList_ItemDataBound">
                                        <ItemTemplate>
                                            <li style="float: left; border: 1px solid #3c8dbc; border-radius: 7px; height: 100%; width: 100%">

                                                <span>

                                                    <div class="col-md-6" style="padding: 5px;">
                                                        <b>
                                                            <h4 style="color: #0fa2da; font-weight: bold;"><%#Eval("CustomerName") %></h4>
                                                            <h5 style="color: orange; font-weight: bold;"><%#Eval("ProjectType") %> </h5>
                                                            Address: </b><%#Eval("InstallAddress") %> , <%#Eval("InstallArea") %>
                                                        <br />
                                                        <%#Eval("InstallCity") %> , <%#Eval("InstallState") %><br />

                                                        <!-- /.info-box-content -->
                                                        <br />

                                                    </div>
                                                    <div class="col-md-6" style="padding: 5px;">
                                                        <h5 style="color: orange; font-weight: bold;">Details </h5>
                                                        <b>Panel Brand:</b>  <%#Eval("PanelBrand") %>
                                                        <br />
                                                        <b>Inverter 1:</b>  <%#Eval("InverterDetails") %>
                                                        <br />
                                                        <b>Inverter 2:</b> <%#Eval("SecondInverterDetails") %><br />
                                                        <b>No Of Panel:</b> <%#Eval("NumberPanelsst") %><br />
                                                        <h5 style="color: Grey; font-weight: bold;"><%#Eval("PanelBrand") %>  <%#Eval("NumberPanelsst") %>  * <%#Eval("SystemCapKWst") %> KW
                                                            <br />
                                                        </h5>
                                                        <div class="form-group">
                                                            <label class="col-sm-4">Quotes </label>
                                                            <div class="col-sm-8">

                                                                <asp:ImageButton ID="btnCreateQuotes" runat="server" ImageUrl="../../Content/img/btn_create_new_quote.png"
                                                                    OnClick="btnCreateQuotes_Click" CausesValidation="false" />

                                                            </div>
                                                        </div>

                                                    </div>

                                                </span>

                                            </li>

                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <li class="time-label" id="EmptyHistory" runat="server" visible="false">
                                                <span class="bg-red">
                                                    <asp:Label ID="lbltimelinetext" runat="server" Text="No history available.."></asp:Label>
                                                </span>
                                            </li>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </ul>

                            </div>

                            <div class="box" id="divQuot" runat="server" visible="false">
                                <div class="box-header">
                                    <h3 class="box-title">
                                    Quotations
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body table-scrollable1">
                                    <asp:Repeater ID="rptQuote" runat="server" OnItemDataBound="rptQuote_ItemDataBound" OnItemCommand="rptQuote_ItemCommand">
                                        <HeaderTemplate>
                                            <table id="Table1" class="table table-bordered table-hover">
                                                <thead>
                                                    <tr>
                                                        <th>Quote Date</th>
                                                        <th>Doc No.</th>
                                                        <th>Document</th>
                                                        <th>Amount</th>
                                                        <th>Status</th>
                                                        <th>Convert To Invoice</th>

                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="ProjectQuoteDate" runat="server" Text='<%#Eval("ProjectQuoteDate", "{0:ddd - dd MMM yyyy}") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="ProjectQuoteDoc" runat="server" Text='<%#Eval("ProjectQuoteDoc") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:HiddenField ID="hndProjectQuoteID" runat="server" Value='<%#Eval("ProjectQuoteID") %>' />
                                                    <asp:HyperLink ID="hypDoc" runat="server" ToolTip="SignedQuote" Target="_blank">
                                                        <asp:Image ID="imgDoc" runat="server" ImageUrl="../../Content/img/icon_document_downalod.png" />
                                                    </asp:HyperLink>

                                                </td>
                                                 <td>
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("TotalQuotePrice") %>'></asp:Label>
                                                </td>
                                                <td>Draft</td>
                                                <td>
                                                    <asp:LinkButton ID="lnkCreateInvoice" runat="server" ToolTip="Create this Quote as Invoice" CommandName="ConvertToInvoice"
                                                        CommandArgument='<%# Eval("ProjectID") %>' text-align="center">Convert To Invoice</>
                                                    </asp:LinkButton>
                                                </td>

                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                        </table>
                                        </FooterTemplate>
                                    </asp:Repeater>

                                </div>
                                <!-- /.box-body -->
                            </div>

                            <%--  <div class="form-group">
                                <div class="col-sm-12">
                                    <asp:Button ID="btnCreateInvoice" runat="server" CssClass="btn btn-info pull-right" Text="Create Invoice" Visible="false" Enabled="false" OnClick="btnCreateInvoice_Click" />
                                    <asp:Button ID="btnOpenInvoice" runat="server" CssClass="btn btn-info pull-right" Text="Open Invoice" Visible="false" OnClick="btnOpenInvoice_Click" />

                                </div>

                            </div>--%>
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

                    $('.datepicker').datepicker({
                        autoclose: true,
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
            <%-- <asp:PostBackTrigger ControlID="btnOpenInvoice" />--%>
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel20" runat="server">
        <ContentTemplate>
            <div id="divQuotDetails" runat="server" clientidmode="Static" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Quotation Details</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="form-group formmargin">
                                    <asp:HiddenField ID="hdnQuoteID" runat="server" />
                                    <asp:HiddenField ID="hdnProjID" runat="server" />
                                    <label class="col-sm-12 control-label" style="padding-left: 25%">
                                        Your selected Quotation Amount is 
                                        <asp:Label ID="lblbasicsystemCost" Text="0" runat="server" ForeColor="#FF6600" Font-Size="Large"></asp:Label>
                                        <br />
                                        Are you sure you want to continue with this payment.

                                    </label>


                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnYes" ClientIDMode="Static" CssClass="btn btn-primary" runat="server" CausesValidation="false" data-dismiss="modal" Text="Yes" OnClick="btnYes_Click" />

                            <asp:Button ID="btnNo" ClientIDMode="Static" CssClass="btn btn-primary" runat="server" CausesValidation="false" data-dismiss="modal" Text="No" OnClick="btnNo_Click" />
                            <%--<input type="button" id="btncloseCurrentMedPopup" class="btn btn-primary" value="Close" />--%>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
        </ContentTemplate>
        <Triggers>

            <asp:PostBackTrigger ControlID="btnYes" />
            <asp:PostBackTrigger ControlID="btnNo" />


        </Triggers>

    </asp:UpdatePanel>

</asp:Content>

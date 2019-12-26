<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="expenses.aspx.cs" Inherits="SolarCRM.admin.masters.expenses" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/PagingUserControl/PagingUserControl.ascx" TagPrefix="uc1" TagName="page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <section class="content-header">
        <h1>Expenses
       <%-- <small>Preview</small>--%>
        </h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a></li>
            <li><a href="#">Master</a></li>
            <li class="active">Expenses</li>
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

                <div class="row" id="divExpenses" runat="server">

                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header with-border">
                                <h3 class="box-title">Expenses</h3>
                               
                            </div>
                            <div class="form-horizontal">
                                <div class="box-body">
                                       <div class="form-group formmargin"><br /><br /></div>
                                    <div class="form-group formmargin">

                                         <div class="col-md-1"></div>
                                        <div class="col-md-2">
                                            <label>Expense Category<span class="red">*</span></label>
                                           
                                        </div>

                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtExpName" runat="server" CssClass="form-control" placeholder="Expense Type" TabIndex="1"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvExpTitle" runat="server" ErrorMessage="* Required" ControlToValidate="txtExpName"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>

                                     
                                    </div>

                                    <div class="form-group">
                                        <div class="col-md-3"></div>
                                        <div class="col-md-4">
                                            <label>Active</label>
                                            <div class="checkbox">
                                                <label>
                                                    <asp:CheckBox ID="chkActive" runat="server" TabIndex="2" />
                                                </label>
                                            </div>
                                        </div>
                                         <div class="col-md-4"></div>
                                    </div>

                                </div>
                            </div>


                            <div class="box-footer">
                                <asp:Button ID="btnReset" class="btn btn-default" runat="server" Text="Reset" TabIndex="3" OnClick="btnReset_Click"/>
                                <%--  <asp:Button ID="btnUpdate" Visible="false" runat="server" CssClass="btn btn-info pull-right" Text="Update" ValidationGroup="error" TabIndex="31" />--%>
                                <asp:Button ID="btnSave" class="btn btn-info pull-right" runat="server" Text="Save" ValidationGroup="error" OnClick="btnSave_Click" TabIndex="4" />
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="box box-primary">
                                    <div class="box-header">
                                        <div class="col-md-6">
                                            <h3 class="box-title">Expenses List</h3>
                                        </div>
                                        <div class="col-md-6 pull-right">

                                            <div class="input-group input-group-sm">
                                                <asp:TextBox ID="txtSearch" ClientIDMode="Static" runat="server" placeholder="search keyword" class="form-control"></asp:TextBox>
                                                <span class="input-group-btn">
                                                    <asp:Button ID="btnSearch" runat="server" class="btn btn-info btn-flat" Text="Search" OnClick="btnSearch_Click" />
                                                    <asp:Button ID="btnClear" runat="server" class="btn btn-default" Text="Clear" OnClick="btnClear_Click"/>
                                                </span>
                                            </div>
                                        </div>


                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body table-scrollable1">
                                        <asp:Repeater ID="rptExpenses" runat="server" OnItemCommand="rptExpenses_ItemCommand">
                                            <HeaderTemplate>
                                                <table id="example2" class="table table-bordered table-hover">
                                                    <thead>
                                                        <tr>
                                                            <th class="text-center">Expense Type</th>
                                                              <th class="text-center">Updated By</th>
                                                            <th class="text-center">Active</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="text-center">
                                                       <asp:Label ID="lblExpenseName" runat="server" Text='<%#Eval("ExpenseName") %>'></asp:Label>
                                                    </td>
                                                      <td>
                                                       <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                                                    </td>
                                                        <td class="text-center">
                                                        <span>
                                                            <asp:Label ID="lblActive" runat="server" ClientIDMode="Static" ToolTip="Active" Visible='<%#Eval("IsActive").ToString()=="True"?true:false %>'><i class="fa fa-check"></i></asp:Label>
                                                            <asp:Label ID="lblnotActive" runat="server" ClientIDMode="Static" ToolTip="InActive" Visible='<%#Eval("IsActive").ToString()=="False"?true:false %>'><i class="fa fa-times"></i></asp:Label>
                                                        </span>
                                                    </td>
                                                   
                                               </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </tbody>
                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>

                                       <%-- <div>
                                            <uc1:page ID="pageGrid" runat="server" Visible="true" OnPagerChanged="pageGrid_PagerChanged"  />
                                        </div>--%>
                                    </div>

                                </div>

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

                    $('.datepicker').datepicker({
                        autoclose: true,
                    });

                    $(".timepicker").timepicker({
                        showInputs: false
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

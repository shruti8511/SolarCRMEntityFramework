<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="dashboard2.aspx.cs" Inherits="SolarCRM.admin.dashboard2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>--%>
     <script>
         debugger;
       
             var heightwindow = $(document).height();
             $('.OrderList').css('height', heightwindow + 'px');
        
       
         //    jQuery.event.add(window, "load", resizeFrame);
         //    jQuery.event.add(window, "resize", resizeFrame);

         //    function resizeFrame() {
         //        var h = $(window).height();
         //        var w = $(window).width();
         //        $("#OrderList").css('height', (h < 768 || w < 1024) ? 500 : 400);
         //    }
      
         //var prm = Sys.WebForms.PageRequestManager.getInstance();
         //prm.add_pageLoaded(pageLoaded);
         ////Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
         //// Raised after an asynchronous postback is finished and control has been returned to the browser.
         //function pageLoaded() {

         //    debugger;
         //    var windowsize = $(window).width();
         //    var totalbox = 4;
         //    var oneboxsize = (parseInt(windowsize) / totalbox);
             
         //    var win_height = $(window).height();
         //    var head_height = $('.main-header').height();
         //    var ftr_height = $('.main-footer').height();
         //    var bdy_height = $('.content-wrapper').height();
         //    var manage_height = parseInt(head_height) + parseInt(ftr_height);
         //    var set_height = parseInt(win_height) - parseInt(manage_height) - parseInt(head_height);
         //    var divsizevalue = set_height + "px";
         //    $(".OrderQty").each(function (index, element) {
         //        $($(".OrderQty")[index]).css('height', divsizevalue);
         //    });
         //}

         //$("#OrderQty").DataTable({
         //    "searching": false,
         //    "sScrollX": windowsize,
         //    "paging": false,
         //    "bPaginate": false,
         //    "bFilter": false,
         //    "bInfo": false,
         //    'aoColumnDefs': [{
         //        'bSortable': false,
         //        'aTargets': ['nosort'],

         //    }]
         //});
            </script>
  

        <div id="frmOrder" method="post" class="form-horizontal">
            <div class="box-body" >
                <div class="col-md-12">

                    <div id="OrderList" class="form-horizontal tblresponsive">
                        <table class="table table-bordered table-bordered" id="OrderQty" style="height:80vh;">
                            <thead>
                                <tr class="form-group">
                                    <th class="nosort col-sm-3" style="background-color: #559ad9; color: white;"><i class="fa fa-pencil-square-o"></i>&nbsp;New</th>
                                    <th class="nosort col-sm-3" style="background-color: #43a9d4; color: white;"><i class="fa fa-calendar"></i>&nbsp;Cold</th>
                                    <th class="nosort col-sm-3" style="background-color: #f6c46e; color: white;"><i class="fa fa-truck"></i>&nbsp;Hot</th>
                                    <th class="nosort col-sm-3" style="background-color: #96ca84; color: white;"><i class="fa fa-file-text-o"></i>&nbsp;Potential</th>

                                </tr>
                            </thead>

                            <tbody>
                                <tr class="form-group" id="trclear">
                                    <td style="background-color: lightgray;">
                                         
                                        <asp:Repeater ID="rptNewList" runat="server" OnItemCommand="rptNewList_ItemCommand" OnItemDataBound="rptNewList_ItemDataBound">
                                            <ItemTemplate>
                                                <div id="TextBoxContainer" class=" box box-widget widget-user-2" style="background: rgba(255,255,255,0.50);">
                                                    <!-- Add the bg color to the header using any of the bg-* classes -->
                                                    <div class="box-header pull-right">
                                                        <asp:LinkButton ID="btnEditNew" runat="server" ToolTip="Edit Type" CommandName="Edit" Text="..." Font-Size="Large" Font-Bold="True"
                                                            CommandArgument='<%# Eval("CustomerID") %>'></asp:LinkButton>
                                                    </div>
                                                    <div class="widget-user-header" style="padding:5px;">
                                                        <b>
                                                            <h5 style="color: #0fa2da; font-weight: bold;"><%#Eval("Customer") %></h5>
                                                        </b>
                                                        <b>Ph No.:</b> <%#Eval("CustMobile") %>
                                                        <br />
                                                        <b>Post Code: </b><%#Eval("StreetPostCode") %>
                                                        <br />
                                                        <b>Ratings: </b><%#Eval("CustRating") %>
                                                        <br />
                                                    </div>
                                                </div>

                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <div style="text-align: center;">
                                            <asp:Button ID="btnAdd" class="btn btn-default btn-circle btn-lg" runat="server" Text="+" OnClick="btnAdd_Click" />

                                        </div>
                                    </td>

                                      <td style="background-color: lightskyblue;">
                                        <asp:Repeater ID="rptColdList" runat="server" OnItemCommand="rptColdList_ItemCommand" OnItemDataBound="rptColdList_ItemDataBound">
                                            <ItemTemplate>
                                                <div class="box box-widget widget-user-2" style="background: rgba(255,255,255,0.50);">
                                                    <!-- Add the bg color to the header using any of the bg-* classes -->
                                                    <div class="box-header pull-right">
                                                        <asp:LinkButton ID="btnEditCold" runat="server" ToolTip="Edit Type" CommandName="Edit" Text="..." Font-Size="Large" Font-Bold="True"
                                                            CommandArgument='<%# Eval("CustomerID") %>'>
                                                        </asp:LinkButton>
                                                    </div>
                                                    <div class="widget-user-header" style="padding:5px;">
                                                        <b>
                                                            <h5 style="color: #0fa2da; font-weight: bold;"><%#Eval("Customer") %></h5>
                                                        </b>
                                                        <b>Ph No.:</b> <%#Eval("CustMobile") %>
                                                        <br />
                                                        <b>Post Code: </b><%#Eval("StreetPostCode") %>
                                                        <br />
                                                        <b>Ratings: </b><%#Eval("CustRating") %>
                                                        <br />
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </td>

                                    <td style="background-color: lightgray;">
                                        <asp:Repeater ID="rptHotList" runat="server" OnItemCommand="rptHotList_ItemCommand" OnItemDataBound="rptHotList_ItemDataBound">
                                            <ItemTemplate>

                                                <div class="box box-widget widget-user-2" style="background: rgba(255,255,255,0.50);">
                                                    <!-- Add the bg color to the header using any of the bg-* classes -->
                                                    <div class="box-header pull-right">
                                                        <asp:LinkButton ID="btnEditHot" runat="server" ToolTip="Edit Type" CommandName="Edit" Text="..." Font-Size="Large" Font-Bold="True"
                                                            CommandArgument='<%# Eval("CustomerID") %>'>
                                                        </asp:LinkButton>
                                                    </div>
                                                     <div class="widget-user-header" style="padding:5px;">
                                                        <b>
                                                            <h5 style="color: #0fa2da; font-weight: bold;"><%#Eval("Customer") %></h5>
                                                        </b>
                                                        <b>Ph No.:</b> <%#Eval("CustMobile") %>
                                                        <br />
                                                        <b>Post Code: </b><%#Eval("StreetPostCode") %>
                                                        <br />
                                                        <b>Ratings: </b><%#Eval("CustRating") %>
                                                        <br />
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </td>
                                    <td style="background-color: lightskyblue;">
                                        <asp:Repeater ID="rptPotentialList" runat="server" OnItemCommand="rptPotentialList_ItemCommand" OnItemDataBound="rptPotentialList_ItemDataBound">
                                            <ItemTemplate>
                                                 
                                                <div class="box box-widget widget-user-2" style="background: rgba(255,255,255,0.50);">
                                                    <!-- Add the bg color to the header using any of the bg-* classes -->
                                                    <div class="box-header pull-right">
                                                        <asp:LinkButton ID="btnEditPotential" runat="server" ToolTip="Edit Type" CommandName="Edit" Text="..." Font-Size="Large" Font-Bold="True"
                                                            CommandArgument='<%# Eval("CustomerID") %>'>...
                                                        </asp:LinkButton>
                                                         <asp:HiddenField ID="hdnCustomerID" runat="server" />
                                                    </div>
                                                     <div class="widget-user-header" style="padding:5px;">
                                                        <b>
                                                            <h5 style="color: #0fa2da; font-weight: bold;"><%#Eval("Customer") %></h5>
                                                        </b>
                                                        <b>Ph No.:</b> <%#Eval("CustMobile") %>
                                                        <br />
                                                        <b>Post Code: </b><%#Eval("StreetPostCode") %>
                                                        <br />
                                                        <b>Ratings: </b><%#Eval("CustRating") %>
                                                        <br />
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <!-- /.box-body -->
            <!-- /.box-footer -->
        </div>


    
    <asp:UpdatePanel ID="UpdatePanel20" runat="server">
        <ContentTemplate>
            <div id="divCustType" runat="server" clientidmode="Static" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Select Lead Type</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="form-group formmargin">
                                          <asp:HiddenField ID="hdnCustomerID" runat="server" />
                                    <label class="col-sm-3 control-label">Lead Type<span class="red">*</span></label>
                                    <div class="col-sm-9">
                                        <asp:DropDownList ID="ddlCustTypeID" runat="server" CssClass="form-control select2" AppendDataBoundItems="true" TabIndex="9" Style="width: 100%;">
                                            <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvddlCustTypeID" runat="server" ErrorMessage="* Required"
                                            ControlToValidate="ddlCustTypeID" ValidationGroup="company"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnUpdate" ClientIDMode="Static" CssClass="btn btn-primary" runat="server" CausesValidation="false" data-dismiss="modal" Text="Update" OnClick="btnUpdate_Click" />

                            <asp:Button ID="btnClosedivCustType" ClientIDMode="Static" CssClass="btn btn-primary" runat="server" CausesValidation="false" data-dismiss="modal" Text="Close" OnClick="btnClosedivCustType_Click" />
                            <%--<input type="button" id="btncloseCurrentMedPopup" class="btn btn-primary" value="Close" />--%>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
        </ContentTemplate>
        <Triggers>
          
            <asp:PostBackTrigger ControlID="btnClosedivCustType" />
               <asp:PostBackTrigger ControlID="btnUpdate" />

        </Triggers>

    </asp:UpdatePanel>


 
  
</asp:Content>

       
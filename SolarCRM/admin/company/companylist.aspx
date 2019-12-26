<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="companylist.aspx.cs" Inherits="SolarCRM.admin.company.companylist" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/PagingUserControl/PagingUserControl.ascx" TagPrefix="uc1" TagName="page" %>
<%@ Register Src="~/PagingUserControl/Paggingctrl.ascx" TagPrefix="uc2" TagName="page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type="text/javascript">
        function checkDate() {
            //debugger;
            var NextFollowupDate = document.getElementById("txtNextFollowUpDate").value;
            var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth() + 1; //January is 0!

            var yyyy = today.getFullYear();
            if (dd < 10) {
                dd = '0' + dd;
            }
            if (mm < 10) {
                mm = '0' + mm;
            }
            var today = mm + '/' + dd + '/' + yyyy;
            //Check if the date selected is less than todays date
            if (NextFollowupDate < today) {
                //show the alert message
                alert("You cannot select a day earlier than today!");
                //set the selected date to todays date in calendar extender control
                //sender._selectedDate = new Date();

                // set the date back to the current date
                //sender._textbox.set_Value(sender._selectedDate.format(sender._format))

            }
        }
    </script>

    <section class="content-header">
        <h1>Company List
       <%-- <small>Preview</small>--%>
        </h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a></li>
            <%-- <li><a href="#">company</a></li>--%>
            <li class="active">Company List</li>
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
                <div class="col-md-2 pull-right">
                    View Mode:<asp:LinkButton ID="lnkview" runat="server" OnClick="lnkview_Click" >Detail</asp:LinkButton>
                </div>
            </div>


            <section class="content">
                <div class="row" id="divcompanylist" runat="server">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header">
                               <%-- <div class="col-md-6 pull-left">
                                    <asp:DropDownList ID="ddlViewMode" runat="server"  CssClass="form-control select2" OnSelectedIndexChanged="ddlViewMode_SelectedIndexChanged" Style="width: 100%;">
                                        <asp:ListItem Value="list" Text="List View">List View</asp:ListItem>
                                        <asp:ListItem Value="content" Text="Content View">Content View</asp:ListItem>
                                    </asp:DropDownList>
                                </div>--%>

                                <div class="col-md-6 pull-right" id="DivSearchBar" runat="server">

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
                            <div class="box-body table-scrollable1" id="contentview" runat="server">
                                <asp:Repeater ID="rptCompanylist" runat="server" OnItemCommand="rptCompanylist_ItemCommand" OnItemDataBound="rptCompanylist_ItemDataBound">
                                    <HeaderTemplate>
                                        <table id="example2" class="table table-bordered table-hover">
                                            <thead>
                                                <tr>
                                                    <th class="text-center">Company Name</th>
                                                    <th class="text-center">Address</th>
                                                    <th class="text-center">Location</th>
                                                    <th class="text-center">Project Type</th>
                                                    <th class="text-center">Customer Type</th>
                                                    <th class="text-center">Phone</th>
                                                    <th class="text-center">Assigned To</th>
                                                    <th class="text-center">Detail</th>
                                                    <%-- <th class="text-center">Edit</th>--%>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>

                                        <tr>
                                            <td>

                                                <asp:HiddenField ID="hndEmployeeID" runat="server" Value='<%#Eval("EmployeeID") %>' />
                                                <asp:HiddenField ID="hdnCustomerID" runat="server" Value='<%#Eval("CustomerID") %>' />

                                                <asp:Label ID="lblZone" runat="server" Text='<%#Eval("Customer") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("StreetAddress") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Location") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("ProjectType") %>'></asp:Label></td>

                                            <td>
                                                <asp:HiddenField ID="hdnCustTypeID" runat="server" Value='<%#Eval("CustTypeID") %>' />
                                                <asp:DropDownList ID="ddlCustTypeID" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" Style="width: 100%;" OnSelectedIndexChanged="ddlCustTypeID_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>

                                                <%-- <asp:DropDownList ID="ddlCustTypeID" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                </asp:DropDownList>--%>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("CustMobile") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("AssignedTo") %>'></asp:Label></td>
                                            <td class="text-center">
                                                <span>
                                                    <asp:LinkButton ID="lnkDetail" runat="server" ToolTip="Detail" CommandName="Detail"
                                                        CommandArgument='<%# Eval("CustomerID") %>'><i class="fa fa-hand-o-right"></i>
                                                    </asp:LinkButton>
                                                </span>
                                            </td>

                                            <%--<td class="text-center">
                                                <span>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                                                        CommandArgument='<%# Eval("CustomerID") %>'><i class="fa fa-edit"></i>
                                                    </asp:LinkButton>
                                                </span>
                                            </td>--%>
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
                <!-- /.row -->
               

                <div class="row" id="divcompanydetails" runat="server" visible="false" clintidmode="static">
                    <div class="col-md-12">
                        <!-- Custom Tabs -->
                        <div class="nav-tabs-custom">
                            <ul class="nav nav-tabs">
                                <li id="lisummary" runat="server" class="active"><a href="#tab_summary" data-toggle="tab">Summary</a></li>
                                <li id="licontact" runat="server"><a href="#tab_contact" data-toggle="tab">Contact</a></li>
                                <li id="liproject" runat="server"><a href="#tab_project" data-toggle="tab">Project</a></li>
                                <li id="lifollowup" runat="server"><a href="#tab_followup" data-toggle="tab">Follow Ups</a></li>
                                <li id="libacktolist" runat="server" class="pull-right">
                                    <asp:LinkButton ID="lnkbacktolist" runat="server" OnClick="lnkbacktolist_Click"><i class="fa fa-arrow-left"></i> Back To List</asp:LinkButton>

                                </li>
                            </ul>
                            <div class="tab-content">

                                <div class="tab-pane active" id="tab_summary" runat="server" clientidmode="static">
                                    <div class="row">
                                        <div class="col-md-12">

                                            <div class="col-md-6">
                                                <div class="box box-primary">
                                                    <div class="box-body table-scrollable1">
                                                        <table id="example3" class="table table-bordered table-hover">
                                                            <tbody>
                                                                <%-- <tr>
                                                                    <td><b>Out Door Employee</b> </td>
                                                                    <td> <asp:Label ID="lblD2DEmployee" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Appointment Date</b> </td>
                                                                    <td> <asp:Label ID="lblD2DAppDate" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Appointment Time</b> </td>
                                                                    <td><asp:Label ID="lblD2DAppTime" runat="server"></asp:Label></td>
                                                                </tr>--%>

                                                                <tr>
                                                                    <td><b>Company</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCustomer" runat="server"></asp:Label>
                                                                        <asp:HiddenField ID="hdnlblCustomerID" runat="server" />
                                                                        <asp:HiddenField ID="hdnlblEmployeeID" runat="server" />
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Company Number</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCompanyNumber" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Name</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblFullName" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Mobile</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblMobile" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Email</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><b>Phone</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPhone" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><b>Alt Phone</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblAltPhone" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><b>Customer Type</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblType" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><b>Source</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblSource" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr id="trSubSource" runat="server" visible="false">
                                                                    <td><b>Sub Source</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblSubSource" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><b>Project Type</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblProjectType" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Notes</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblNotes" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Assign To</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblAssignTo" runat="server"></asp:Label></td>
                                                                </tr>

                                                            </tbody>

                                                        </table>
                                                    </div>
                                                    <!-- /.box-body -->
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="box box-primary">
                                                    <div class="box-body table-scrollable1">
                                                        <table id="example4" class="table table-bordered table-hover">
                                                            <tbody>
                                                                <tr>
                                                                    <td><b>Company Type</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCompanyType" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><b>Street Address</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblStreetAddress" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><b>Street Area</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblStreetArea" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Street City</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblStreetCity" runat="server"></asp:Label></td>
                                                                </tr>


                                                                <tr>
                                                                    <td><b>Street State</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblStreetState" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Street PostCode</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblStreetPostCode" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Postal Address</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPostalAddress" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Postal Area</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPostalArea" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Postal City</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPostalCity" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Postal State</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPostalState" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Postal PostCode</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPostalPostCode" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Area</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblArea" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Country</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCountry" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Website</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblWebsite" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Fax</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblFax" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><b>Cust Rating</b> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCustRating" runat="server"></asp:Label></td>
                                                                </tr>
                                                            </tbody>

                                                        </table>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="tab-pane" id="tab_contact" runat="server" clientidmode="static">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="box box-primary" id="divcontactlist" runat="server" clientidmode="static">
                                                <div class="box-header">
                                                    <div class="col-md-6">
                                                        <asp:LinkButton ID="lnkAddContact" runat="server" OnClick="lnkAddContact_Click"><i class="fa fa-plus-circle"></i> Add Contact</asp:LinkButton>
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
                                                    <asp:Repeater ID="rptContactList" runat="server" OnItemCommand="rptContactList_ItemCommand">
                                                        <HeaderTemplate>
                                                            <table id="example5" class="table table-bordered table-hover">
                                                                <thead>
                                                                    <tr>
                                                                        <th class="text-center">Contact</th>
                                                                        <th class="text-center">Company</th>
                                                                        <th class="text-center">Mobile</th>
                                                                        <th class="text-center">Phone</th>
                                                                        <th class="text-center">Email</th>
                                                                        <th class="text-center">Detail</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>

                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("FullName") %>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("Customer") %>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("ContMobile") %>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("ContPhone") %>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("ContEmail") %>'></asp:Label></td>
                                                                <td class="text-center">
                                                                    <span>
                                                                        <asp:LinkButton ID="lnkDetail" runat="server" ToolTip="Detail" CommandName="Detail"
                                                                            CommandArgument='<%# Eval("ContactID") %>'><i class="fa fa-hand-o-right"></i>
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
                                                </div>
                                                <!-- /.box-body -->
                                            </div>

                                            <div class="box box-primary" id="divaddcontact" runat="server" visible="false" clientidmode="static">
                                                <div class="box-header with-border">
                                                    <div class="col-md-6">
                                                        Add New Contact
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:LinkButton ID="lnkbacktocontactlist" CssClass="pull-right" runat="server" OnClick="lnkbacktocontactlist_Click"><i class="fa fa-arrow-left"></i> Back To Contact List</asp:LinkButton>

                                                    </div>
                                                </div>

                                                <div class="form-horizontal">
                                                    <div class="box-body">

                                                        <div class="col-md-12">
                                                            <div class="form-group formmargin">
                                                                <div class="col-md-4">
                                                                    <label>Salutation</label>
                                                                    <asp:DropDownList runat="server" ID="ddlSalutation" MaxLength="10" CssClass="form-control" TabIndex="1">
                                                                        <asp:ListItem Text="Mr" Value="Mr"></asp:ListItem>
                                                                        <asp:ListItem Text="Mrs" Value="Mrs"></asp:ListItem>
                                                                        <asp:ListItem Text="Miss" Value="Miss"></asp:ListItem>
                                                                        <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>

                                                                <div class="col-md-4">
                                                                    <label>First Name</label>
                                                                    <asp:TextBox ID="txtContFirst" runat="server" MaxLength="40" CssClass="form-control"
                                                                        placeholder="First Name" TabIndex="2"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvtxtContFirst" runat="server" ErrorMessage="* Required"
                                                                        ControlToValidate="txtContFirst" ValidationGroup="contact"></asp:RequiredFieldValidator>
                                                                </div>

                                                                <div class="col-md-4">
                                                                    <label>Last Name</label>
                                                                    <asp:TextBox ID="txtContLast" runat="server" MaxLength="40" CssClass="form-control"
                                                                        placeholder="Last Name" TabIndex="3"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvtxtContLast" runat="server" ErrorMessage="* Required"
                                                                        ControlToValidate="txtContLast" ValidationGroup="contact"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="col-md-12">
                                                            <div class="form-group formmargin">
                                                                <div class="col-md-4">
                                                                    <label>Mobile</label>
                                                                    <asp:TextBox ID="txtContMobile" runat="server" MaxLength="10" CssClass="form-control" placeholder="Mobile" TabIndex="4"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvtxtContMobile" runat="server" ErrorMessage="* Required"
                                                                        ControlToValidate="txtContMobile" ValidationGroup="contact"></asp:RequiredFieldValidator>
                                                                </div>

                                                                <div class="col-md-4">
                                                                    <label>Phone</label>
                                                                    <asp:TextBox ID="txtCustPhone" runat="server" MaxLength="10" CssClass="form-control" placeholder="Phone" TabIndex="5"></asp:TextBox>
                                                                </div>

                                                                <div class="col-md-4">
                                                                    <label>Email</label>
                                                                    <asp:TextBox ID="txtContEmail" runat="server" MaxLength="100" CssClass="form-control" placeholder="Email Address" TabIndex="6"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="regvalEmail" runat="server" ControlToValidate="txtContEmail"
                                                                        ValidationGroup="contact" ErrorMessage=" Enter Valid E-Mail"
                                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> </asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>

                                                        </div>

                                                    </div>

                                                    <div class="box-footer">
                                                        <asp:Button CssClass="btn btn-info pull-right" ID="btnAddContact" runat="server" OnClick="btnAddContact_Click"
                                                            Text="Add" ValidationGroup="contact" TabIndex="7" />

                                                        <input type="reset" class="btn btn-default" value="Reset" tabindex="8" />

                                                    </div>

                                                </div>
                                            </div>

                                            <div class="box box-primary" id="divContactDetails" runat="server" visible="false">

                                                <div class="box-header">
                                                    <div class="col-md-6">
                                                        <h4>
                                                            <asp:Label ID="lblContactDetails" runat="server"></asp:Label></h4>
                                                    </div>

                                                </div>

                                                <div class="nav-tabs-custom">
                                                    <ul class="nav nav-tabs">
                                                        <li id="lidetail" runat="server" class="active"><a href="#tab_detail" data-toggle="tab">Detail</a></li>
                                                        <li id="linotes" runat="server"><a href="#tab_notes" data-toggle="tab">Notes</a></li>
                                                        <li id="lipromo" runat="server"><a href="#tab_promo" data-toggle="tab">Promo</a></li>
                                                        <li id="liinfo" runat="server"><a href="#tab_info" data-toggle="tab">Info</a></li>
                                                    </ul>
                                                    <div class="tab-content">

                                                        <div class="tab-pane active" id="tab_detail" runat="server" clientidmode="static">
                                                            <div class="form-horizontal">
                                                                <div class="box-body">

                                                                    <div class="col-md-12">
                                                                        <div class="form-group formmargin">
                                                                            <div class="col-md-4">
                                                                                <label>Salutation</label>
                                                                                <asp:HiddenField ID="hdnContactID" runat="server" />
                                                                                <asp:DropDownList runat="server" ID="ddlsalu" MaxLength="10" CssClass="form-control" TabIndex="1">
                                                                                    <asp:ListItem Text="Mr" Value="Mr"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mrs" Value="Mrs"></asp:ListItem>
                                                                                    <asp:ListItem Text="Miss" Value="Miss"></asp:ListItem>
                                                                                    <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>

                                                                            <div class="col-md-4">
                                                                                <label>First Name</label>
                                                                                <asp:TextBox ID="txtFname" runat="server" MaxLength="40" CssClass="form-control"
                                                                                    placeholder="First Name" TabIndex="2"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvtxtFname" runat="server" ErrorMessage="* Required"
                                                                                    ControlToValidate="txtFname" ValidationGroup="Updatecontact"></asp:RequiredFieldValidator>
                                                                            </div>

                                                                            <div class="col-md-4">
                                                                                <label>Last Name</label>
                                                                                <asp:TextBox ID="txtLname" runat="server" MaxLength="40" CssClass="form-control"
                                                                                    placeholder="Last Name" TabIndex="3"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvtxtLname" runat="server" ErrorMessage="* Required"
                                                                                    ControlToValidate="txtLname" ValidationGroup="Updatecontact"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                    <div class="col-md-12">
                                                                        <div class="form-group formmargin">
                                                                            <div class="col-md-4">
                                                                                <label>Email</label>
                                                                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" CssClass="form-control" placeholder="Email Address" TabIndex="4"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                                                                    ValidationGroup="Updatecontact" ErrorMessage=" Enter Valid E-Mail"
                                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> </asp:RegularExpressionValidator>
                                                                            </div>

                                                                            <div class="col-md-4">
                                                                                <label>Mobile</label>
                                                                                <asp:TextBox ID="txtMobile" runat="server" MaxLength="10" CssClass="form-control" placeholder="Mobile" TabIndex="5"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvtxtMobile" runat="server" ErrorMessage="* Required"
                                                                                    ControlToValidate="txtMobile" ValidationGroup="Updatecontact"></asp:RequiredFieldValidator>
                                                                            </div>

                                                                            <div class="col-md-4">
                                                                                <label>Phone</label>
                                                                                <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" CssClass="form-control" placeholder="Phone" TabIndex="6"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-12">
                                                                        <div class="form-group">
                                                                            <div class="col-md-4">
                                                                                <label>Home Phone</label>
                                                                                <asp:TextBox ID="txtHomePhone" runat="server" MaxLength="10" CssClass="form-control" placeholder="Home Phone" TabIndex="7"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-md-4">
                                                                                <label>Fax</label>
                                                                                <asp:TextBox ID="txtFax" runat="server" MaxLength="50" CssClass="form-control" placeholder="Fax" TabIndex="8"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-md-4">
                                                                                <label>Site</label>
                                                                                <asp:TextBox ID="txtSite" runat="server" Enabled="false" MaxLength="200" CssClass="form-control" placeholder="Site Address" TabIndex="9"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-12">
                                                                        <div class="form-group">
                                                                            <div class="col-md-4">
                                                                                <label>Address</label>
                                                                                <asp:TextBox ID="txtSiteAddress" runat="server" Enabled="false" MaxLength="200" CssClass="form-control" placeholder="Site Address" TabIndex="9"></asp:TextBox>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <label>Street</label>
                                                                                <asp:TextBox ID="txtSteet" runat="server" MaxLength="200" Enabled="false" CssClass="form-control" placeholder="Street" TabIndex="10"></asp:TextBox>
                                                                            </div>



                                                                            <div class="col-md-4">
                                                                                <label>Sales Rep</label>
                                                                                <asp:DropDownList ID="ddlSalesRep" runat="server" AppendDataBoundItems="true"
                                                                                    CssClass="form-control select2" TabIndex="12" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-12">
                                                                        <div class="form-group">
                                                                            <div class="col-md-4">
                                                                                <label>City</label>
                                                                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" Enabled="false" placeholder="City" TabIndex="11"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-md-4">
                                                                                <label>State</label>
                                                                                <asp:TextBox ID="txtState" runat="server" CssClass="form-control" Enabled="false" placeholder="State" TabIndex="13"></asp:TextBox>
                                                                            </div>



                                                                            <div class="col-md-4">
                                                                                <label>Lead Status</label>
                                                                                <asp:DropDownList ID="ddlContLeadStatusID" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlContLeadStatusID_SelectedIndexChanged"
                                                                                    CssClass="form-control select2" TabIndex="15" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-12">
                                                                        <div class="form-group">

                                                                            <div class="col-md-4">
                                                                                <label>Pincode</label>
                                                                                <asp:TextBox ID="txtPinCode" runat="server" CssClass="form-control" Enabled="false" placeholder="PinCode" TabIndex="14"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-md-1">
                                                                                <label>Send Email</label>
                                                                                <div class="checkbox">
                                                                                    <label>
                                                                                        <asp:CheckBox ID="chksendemail" runat="server" TabIndex="16" />
                                                                                    </label>
                                                                                </div>
                                                                            </div>

                                                                            <div class="col-md-1">
                                                                                <label>Send SMS</label>
                                                                                <div class="checkbox">
                                                                                    <label>
                                                                                        <asp:CheckBox ID="chksendsms" runat="server" TabIndex="17" />
                                                                                    </label>
                                                                                </div>
                                                                            </div>

                                                                            <div class="col-md-1">
                                                                                <label>Sales Active</label>
                                                                                <div class="checkbox">
                                                                                    <label>
                                                                                        <asp:CheckBox ID="chksalesactive" runat="server" TabIndex="18" />
                                                                                    </label>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-1"></div>

                                                                            <div id="divcancelleadstatus" runat="server" visible="false">
                                                                                <div class="col-md-4">
                                                                                    <label>Cancel</label>
                                                                                    <asp:DropDownList ID="ddlCancel" runat="server" CssClass="form-control select2" Style="width: 100%;"
                                                                                        AppendDataBoundItems="true">
                                                                                        <asp:ListItem Value=""></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>



                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!-- /.box-body -->
                                                                <div class="box-footer">
                                                                    <asp:Button CssClass="btn btn-info pull-right" ID="btnUpdateContact" runat="server" OnClick="btnUpdateContact_Click"
                                                                        Text="Save" ValidationGroup="contact" TabIndex="19" />
                                                                    <asp:Button CssClass="btn btn-default" ID="btnCancelContact" runat="server" OnClick="btnCancelContact_Click"
                                                                        Text="Cancel" CausesValidation="false" TabIndex="20" />
                                                                </div>
                                                                <!-- /.box-footer -->

                                                            </div>
                                                        </div>

                                                        <div class="tab-pane" id="tab_notes" runat="server" clientidmode="static">

                                                            <div class="box box-primary" id="divAddNotes" runat="server" visible="false" clientidmode="static">
                                                                <div class="box-header with-border">
                                                                    <div class="col-md-6">
                                                                        Add New Notes
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:LinkButton ID="lnkbacktoNoteslist" CssClass="pull-right" runat="server" OnClick="lnkbacktoNoteslist_Click"><i class="fa fa-arrow-left"></i> Back To Notes List</asp:LinkButton>

                                                                    </div>
                                                                </div>
                                                                <div class="form-horizontal">
                                                                    <div class="box-body">

                                                                        <div class="col-md-6">
                                                                            <div class="form-group">
                                                                                <label class="col-sm-3 control-label">Note </label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:TextBox ID="txtContactNotes" runat="server" TextMode="MultiLine" TabIndex="1" CssClass="form-control"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfvtxtContactNotes" runat="server" ErrorMessage="* Required"
                                                                                        ControlToValidate="txtContactNotes" ValidationGroup="AddContNotes"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                        </div>



                                                                    </div>
                                                                    <!-- /.box-body -->
                                                                    <div class="box-footer">
                                                                        <asp:Button ID="btnCancelContactNotes" runat="server" TabIndex="3" ToolTip="Cancel" CssClass="btn btn-default" Text="Cancel" CausesValidation="false" OnClick="btnCancelContactNotes_Click" />
                                                                        <asp:Button ID="btnAddContactNotes" runat="server" TabIndex="2" ToolTip="Add" CssClass="btn btn-info pull-right" Text="Add" ValidationGroup="AddContNotes" OnClick="btnAddContactNotes_Click" />
                                                                    </div>
                                                                    <!-- /.box-footer -->
                                                                </div>
                                                            </div>

                                                            <div class="box box-primary" id="divNotesList" runat="server" clientidmode="static">
                                                                <div class="box-header">
                                                                    <div class="col-md-6">
                                                                        <asp:LinkButton ID="lnkAddNotes" runat="server" OnClick="lnkAddNotes_Click"><i class="fa fa-plus-circle"></i> Add Contact</asp:LinkButton>
                                                                    </div>
                                                                    <%--  <div class="col-md-6 pull-right">

                                                                        <div class="input-group input-group-sm">
                                                                            <asp:TextBox ID="TextBox19" ClientIDMode="Static" runat="server" placeholder="search keyword" class="form-control"></asp:TextBox>
                                                                            <span class="input-group-btn">
                                                                                <asp:Button ID="Button8" runat="server" class="btn btn-info btn-flat" Text="Search" />
                                                                                <asp:Button ID="Button9" runat="server" class="btn btn-default" Text="Clear" />
                                                                            </span>
                                                                        </div>
                                                                    </div>--%>
                                                                </div>
                                                                <!-- /.box-header -->
                                                                <div class="box-body table-scrollable1">
                                                                    <asp:Repeater ID="rptNotesList" runat="server">
                                                                        <HeaderTemplate>
                                                                            <table id="example7" class="table table-bordered table-hover">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th class="text-center">Date</th>
                                                                                        <th class="text-center">By</th>
                                                                                        <th class="text-center">For</th>
                                                                                        <th class="text-center">Note</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>

                                                                            <tr>
                                                                                <td>

                                                                                    <asp:HiddenField ID="hndContNoteID" runat="server" Value='<%#Eval("ContNoteID") %>' />
                                                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("ContNoteDate", "{0:dd MMM, yyyy}") %>'></asp:Label></td>

                                                                                <td>
                                                                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("NoteSetName") %>'></asp:Label></td>

                                                                                <td>
                                                                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("EmployeeName") %>'></asp:Label></td>

                                                                                <td>
                                                                                    <asp:Label ID="Label12" runat="server" Text='<%#Eval("ContNote") %>'></asp:Label></td>

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

                                                        </div>

                                                        <div class="tab-pane" id="tab_promo" runat="server" clientidmode="static">
                                                            <div class="form-horizontal">
                                                                <div class="box-body">

                                                                    <div class="box box-primary">
                                                                        <div class="box-header">

                                                                            <div class="col-md-6">
                                                                                <h4>There are no items to show in this view </h4>
                                                                                <%-- <div class="input-group input-group-sm">
                                                                                    <asp:TextBox ID="TextBox20" ClientIDMode="Static" runat="server" placeholder="search keyword" class="form-control"></asp:TextBox>
                                                                                    <span class="input-group-btn">
                                                                                        <asp:Button ID="Button10" runat="server" class="btn btn-info btn-flat" Text="Search" />
                                                                                        <asp:Button ID="Button11" runat="server" class="btn btn-default" Text="Clear" />
                                                                                    </span>
                                                                                </div>--%>
                                                                            </div>


                                                                        </div>
                                                                        <!-- /.box-header -->
                                                                        <%--     <div class="box-body table-scrollable1">
                                                                            <table id="Table7" class="table table-bordered table-hover">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>Promo</th>
                                                                                        <th>Notes</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody>

                                                                                    <tr>

                                                                                        <td>Promo</td>
                                                                                        <td>Notes</td>

                                                                                    </tr>
                                                                                </tbody>

                                                                            </table>
                                                                        </div>--%>
                                                                        <!-- /.box-body -->
                                                                    </div>

                                                                </div>
                                                                <!-- /.box-body -->
                                                                <div class="box-footer" style="display: none">
                                                                    <asp:Button ID="btncnclpriority" runat="server" TabIndex="23" ToolTip="Reset Details" CssClass="btn btn-default" Text="Cancel" />
                                                                    <asp:Button ID="btnaddpriority" runat="server" TabIndex="24" ToolTip="Add Priority" CssClass="btn btn-info pull-right" Text="Add" />
                                                                </div>
                                                                <!-- /.box-footer -->

                                                            </div>
                                                        </div>

                                                        <div class="tab-pane" id="tab_info" runat="server" clientidmode="static">
                                                            <div class="form-horizontal">
                                                                <div class="box-body">

                                                                    <div class="form-group">
                                                                        <div class="col-md-4">
                                                                            <label>Entered</label>

                                                                            <asp:TextBox ID="txtContactEntered" runat="server" Enabled="false" placeholder="Entered" CssClass="form-control"></asp:TextBox>
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <label>By</label>
                                                                            <asp:TextBox ID="txtContactEnteredBy" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <label>ContactID</label>
                                                                            <asp:TextBox ID="txtContactID" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                                                        </div>

                                                                    </div>


                                                                    <div class="form-group">
                                                                        <div class="col-md-4">
                                                                            <label>Ref BSB</label>
                                                                            <asp:TextBox ID="txtRefBSB" runat="server" MaxLength="12" placeholder="Ref BSB" CssClass="form-control"></asp:TextBox>

                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <label>Ref Account</label>
                                                                            <asp:TextBox ID="txtRefAccount" runat="server" MaxLength="30" placeholder="Ref Account" CssClass="form-control"></asp:TextBox>
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <label>Note</label>
                                                                            <asp:TextBox ID="txtContNotes" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox></span>
                                                                        </div>
                                                                    </div>



                                                                </div>
                                                                <!-- /.box-body -->
                                                                <div class="box-footer" style="display: none">
                                                                    <asp:Button ID="btnCancelInfo" runat="server" ToolTip="Cancel" CssClass="btn btn-default" Text="Cancel" CausesValidation="false" OnClick="btnCancelInfo_Click" />
                                                                    <asp:Button ID="btnAddInfo" runat="server" ToolTip="Add" CssClass="btn btn-info pull-right" Text="Add" OnClick="btnAddInfo_Click" />
                                                                </div>
                                                                <!-- /.box-footer -->

                                                            </div>
                                                        </div>

                                                    </div>

                                                </div>

                                            </div>

                                        </div>
                                    </div>
                                </div>

                                <div class="tab-pane" id="tab_project" runat="server" clientidmode="static">

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="box box-primary">
                                                <div class="box-header">

                                                    <div class="col-sm-6">
                                                    </div>

                                                    <div class="col-md-6 pull-right">

                                                        <div class="input-group input-group-sm">

                                                            <span class="input-group-btn" style="text-align: right">
                                                                <asp:Button ID="btnAddNewProject" runat="server" class="btn btn-info btn-flat" Text="Add Project" OnClick="btnAddNewProject_Click" />

                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="box box-primary" id="DivAddNewProject" runat="server" clientidmode="static" visible="false">
                                                    <div class="box-header with-border">
                                                        <h3 class="box-title">Add New Project</h3>
                                                    </div>
                                                    <div class="box-body">
                                                        <div class="panel panel-default">

                                                            <div class="form-horizontal">
                                                                <div class="box-body">

                                                                    <div class="form-group">
                                                                        <div class="col-md-4">
                                                                            <label>Project Type <span class="red">*</span></label>
                                                                            <asp:DropDownList ID="ddlProjectTypeID" runat="server" CssClass="form-control select2" Style="width: 100%;"
                                                                                AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvddlProjectTypeID" runat="server" ErrorMessage="* Required"
                                                                                ControlToValidate="ddlProjectTypeID" Display="Dynamic" ValidationGroup="AddProject"></asp:RequiredFieldValidator>
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <label>Project Opened</label>
                                                                            <asp:TextBox ID="txtProjectOpened" runat="server" Enabled="false" class="form-control"></asp:TextBox>
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <label>Sales Rep <span class="red"></span></label>
                                                                            <asp:TextBox ID="txtSalesRep" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>

                                                                            <asp:RequiredFieldValidator ID="rfvtxtSalesRep" runat="server" ErrorMessage="* Required"
                                                                                ControlToValidate="txtSalesRep" Display="Dynamic" ValidationGroup="AddProject"></asp:RequiredFieldValidator>
                                                                        </div>

                                                                    </div>


                                                                    <div class="form-group">
                                                                        <div class="col-md-4">
                                                                            <label>Contact <span class="red">*</span></label>
                                                                            <asp:DropDownList ID="ddlContact" runat="server" CssClass="form-control select2" Style="width: 100%;"
                                                                                AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvddlContact" runat="server" ErrorMessage="* Required"
                                                                                ControlToValidate="ddlContact" Display="Dynamic" ValidationGroup="AddProject"></asp:RequiredFieldValidator>
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <label>Old Project No</label>
                                                                            <asp:TextBox ID="txtOldProjectNumber" runat="server" MaxLength="200" class="form-control"></asp:TextBox>
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <label>Manual Quote No</label>
                                                                            <asp:TextBox ID="txtManualQuoteNumber" runat="server" MaxLength="200" class="form-control"></asp:TextBox>
                                                                        </div>

                                                                    </div>


                                                                    <div class="form-group">
                                                                        <div class="col-md-4">
                                                                            <label>Install Site <span class="red"></span></label>
                                                                            <asp:TextBox ID="txtInstallAddress" Enabled="false" runat="server" MaxLength="100" class="form-control"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvtxtInstallAddress" runat="server" ErrorMessage="* Required"
                                                                                ControlToValidate="txtInstallAddress" Display="Dynamic" ValidationGroup="AddProject"></asp:RequiredFieldValidator>
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <label>Area <span class="red"></span></label>
                                                                            <asp:TextBox ID="txtInstallArea" Enabled="false" runat="server" MaxLength="100" class="form-control"></asp:TextBox>

                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <label>City <span class="red"></span></label>
                                                                            <asp:TextBox ID="txtInstallCity" Enabled="false" runat="server" MaxLength="100" class="form-control"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvtxtInstallCity" runat="server" ErrorMessage="* Required"
                                                                                ControlToValidate="txtInstallCity" Display="Dynamic" ValidationGroup="AddProject"></asp:RequiredFieldValidator>
                                                                        </div>



                                                                    </div>

                                                                    <div class="form-group">
                                                                        <div class="col-md-4">
                                                                            <label>State</label>
                                                                            <asp:TextBox ID="txtInstallState" Enabled="false" runat="server" MaxLength="100" class="form-control"></asp:TextBox>
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <label>Pin Code</label>
                                                                            <asp:TextBox ID="txtInstallPostCode" Enabled="false" runat="server" MaxLength="10"
                                                                                class="form-control"></asp:TextBox>
                                                                        </div>

                                                                    </div>

                                                                    <div class="form-group">
                                                                        <div class="col-md-4">
                                                                            <label>Project Notes</label>
                                                                            <asp:TextBox ID="txtProjectNotes" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <label>Installer Notes</label>
                                                                            <asp:TextBox ID="txtInstallerNotes" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                        </div>

                                                                        <div class="col-md-4">
                                                                            <label>Notes for Installation Department</label>
                                                                            <asp:TextBox ID="txtMeterInstallerNotes" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                        </div>

                                                                    </div>

                                                                </div>
                                                                <!-- /.box-body -->
                                                                <div class="box-footer">
                                                                    <asp:Button ID="btnCancelAddNewProject" runat="server" ToolTip="Cancel" CssClass="btn btn-default" Text="Cancel" CausesValidation="false" OnClick="btnCancelAddNewProject_Click" />
                                                                    <asp:Button ID="btnAddProject" runat="server" ToolTip="Add Project" CssClass="btn btn-info pull-right" ValidationGroup="AddProject" Text="Add" OnClick="btnAddProject_Click" />
                                                                </div>
                                                                <!-- /.box-footer -->

                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>


                                                <!-- /.box-header -->
                                                <div class="box-body table-scrollable1">
                                                    <asp:Repeater ID="rptCompanyProjectsList" runat="server" OnItemCommand="rptCompanyProjectsList_ItemCommand">
                                                        <HeaderTemplate>
                                                            <table id="example6" class="table table-bordered table-hover">
                                                                <thead>
                                                                    <tr>
                                                                        <th class="text-center">Project Number</th>
                                                                        <th class="text-center">Project</th>
                                                                        <th class="text-center">Project Type</th>
                                                                        <th class="text-center">Status</th>
                                                                        <th class="text-center">Updated By</th>
                                                                        <th class="text-center">Detail</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td class="text-center">
                                                                    <asp:Label ID="lblProjectNumber" runat="server" Text='<%#Eval("ProjectNumber") %>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="Label13" runat="server" Text='<%#Eval("ProjectAddress") %>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="Label14" runat="server" Text='<%#Eval("ProjectType") %>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="Label15" runat="server" Text='<%#Eval("ProjectStatus") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label16" runat="server" Text='<%#Eval("UpdateName") %>'></asp:Label></td>
                                                                <td class="text-center">
                                                                    <span>
                                                                        <asp:LinkButton ID="lnkDetail" runat="server" ToolTip="Detail" CommandName="Detail"
                                                                            CommandArgument='<%# Eval("ProjectID") %>'><i class="fa fa-hand-o-right"></i>
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
                                                        <uc2:page ID="pageGrid1" runat="server" Visible="true" OnPagerChanged="Pager_Changed1" />
                                                    </div>
                                                </div>
                                                <!-- /.box-body -->
                                            </div>

                                        </div>
                                    </div>
                                </div>

                                <div class="tab-pane" id="tab_followup" runat="server" clientidmode="static">

                                    <div class="row">
                                        <div class="col-md-12">
                                            <!-- Horizontal Form -->
                                            <div class="box box-primary">
                                                <div class="box-header">

                                                    <div class="col-sm-6">
                                                    </div>

                                                    <div class="col-md-6 pull-right">

                                                        <div class="input-group input-group-sm">

                                                            <span class="input-group-btn" style="text-align: right">
                                                                <asp:Button ID="btnAddNewFollowUp" runat="server" class="btn btn-info btn-flat" Text="Add FollowUp" OnClick="btnAddNewFollowUp_Click" />

                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="box box-primary" id="DivAddNewFollowUp" runat="server" clientidmode="static" visible="false">

                                                    <div class="box-header with-border">
                                                        <h3 class="box-title">Add Follow Up</h3>
                                                    </div>

                                                    <div class="form-horizontal">
                                                        <div class="box-body">

                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <asp:HiddenField ID="hdnCustInfoID" runat="server" />
                                                                    <label class="col-sm-3 control-label">Contact <span class="red">*</span></label>
                                                                    <div class="col-sm-9">
                                                                        <asp:DropDownList ID="ddlContacts" runat="server" CssClass="form-control select2" Style="width: 100%;"
                                                                            AppendDataBoundItems="true">
                                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvddlContacts" runat="server" ErrorMessage="* Required"
                                                                            ControlToValidate="ddlContacts" Display="Dynamic" ValidationGroup="AddFollowup"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label class="col-sm-3 control-label">Follow Up Date  <span class="red">*</span></label>
                                                                    <div class="col-sm-9">
                                                                        <div class="input-group date">
                                                                            <div class="input-group-addon">
                                                                                <i class="fa fa-calendar"></i>
                                                                            </div>
                                                                            <asp:TextBox ID="txtFollowUpDate" class="form-control pull-right datepicker" runat="server" ToolTip="Follow Up Date"></asp:TextBox>

                                                                        </div>
                                                                        <asp:RequiredFieldValidator ID="rfvtxtFollowUpDate" runat="server" ControlToValidate="txtFollowUpDate"
                                                                            ValidationGroup="AddFollowup" ErrorMessage="* Required" Display="Dynamic"> </asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <!-- /.input group -->
                                                                </div>

                                                                <div class="form-group">
                                                                    <label class="col-sm-3 control-label">Next Follow Up Date  <span class="red">*</span></label>
                                                                    <div class="col-sm-9">
                                                                        <div class="input-group date">
                                                                            <div class="input-group-addon">
                                                                                <i class="fa fa-calendar"></i>
                                                                            </div>
                                                                            <asp:TextBox ID="txtNextFollowUpDate" ClientIDMode="Static" class="form-control pull-right datepicker" runat="server" ToolTip="Next Follow Up Date"></asp:TextBox>

                                                                        </div>
                                                                        <asp:RequiredFieldValidator ID="rfvtxtNextFollowUpDate" runat="server" ControlToValidate="txtNextFollowUpDate"
                                                                            ValidationGroup="AddFollowup" ErrorMessage="* Required" Display="Dynamic"> </asp:RequiredFieldValidator>
                                                                        <%--   <asp:CompareValidator ID="cmpNextDate" runat="server" ControlToValidate="txtNextFollowUpDate"
                                                                                ErrorMessage="Next follow up date cannot be less than today's date" Type="Date" Operator="LessThanEqual"
                                                                                ValidationGroup="AddFollowup" Display="Dynamic"></asp:CompareValidator>--%>
                                                                    </div>
                                                                    <!-- /.input group -->
                                                                </div>

                                                            </div>

                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <label class="col-sm-3 control-label">Description<span class="red">*</span></label>
                                                                    <div class="col-sm-9">
                                                                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"
                                                                            CssClass="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfvtxtDescription" runat="server" ErrorMessage="* Required"
                                                                            ValidationGroup="AddFollowup" ControlToValidate="txtDescription" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                        </div>
                                                        <!-- /.box-body -->
                                                        <div class="box-footer">
                                                            <asp:Button ID="btnCancelFollowUP" runat="server" ToolTip="Cancel" CssClass="btn btn-default" Text="Cancel" CausesValidation="false" OnClick="btnCancelFollowUP_Click" />
                                                            <asp:Button ID="btnAddFollowUp" runat="server" ToolTip="Add FollowUp" CssClass="btn btn-info pull-right" ValidationGroup="AddFollowup" Text="Add" OnClientClick="checkDate();" OnClick="btnAddFollowUp_Click" />
                                                            <asp:Button ID="btnUpdateFollowUp" runat="server" CssClass="btn btn-info pull-right" OnClick="btnUpdateFollowUp_Click"
                                                                Text="Update" Visible="false" ValidationGroup="AddFollowup" />
                                                        </div>
                                                        <!-- /.box-footer -->
                                                    </div>
                                                </div>


                                                <%--   <div class="box box-primary">
                                                <div class="box-header">
                                                   
                                                    <div class="col-md-6 pull-right">

                                                        <div class="input-group input-group-sm">
                                                            <asp:TextBox ID="TextBox3" ClientIDMode="Static" runat="server" placeholder="search keyword" class="form-control"></asp:TextBox>
                                                            <span class="input-group-btn">
                                                                <asp:Button ID="Button4" runat="server" class="btn btn-info btn-flat" Text="Search" />
                                                                <asp:Button ID="Button5" runat="server" class="btn btn-default" Text="Clear" />
                                                            </span>
                                                        </div>
                                                    </div>


                                                </div>--%>
                                                <!-- /.box-header -->
                                                <div class="box-body table-scrollable1">
                                                    <asp:Repeater ID="rptFollowUpList" runat="server" OnItemCommand="rptFollowUpList_ItemCommand">
                                                        <HeaderTemplate>
                                                            <table id="example8" class="table table-bordered table-hover">
                                                                <thead>
                                                                    <tr>
                                                                        <th class="text-center">Contact</th>
                                                                        <th class="text-center">Follow Up Date</th>
                                                                        <th class="text-center">Next Follow Up Date</th>
                                                                        <th class="text-center">Description</th>
                                                                        <th class="text-center">Edit</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblProjectNumber" runat="server" Text='<%#Eval("ContactName") %>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="Label17" runat="server" Text='<%#Eval("FollowupDate","{0:dd MMM, yyyy}") %>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="Label18" runat="server" Text='<%#Eval("NextFollowupDate","{0:dd MMM, yyyy}") %>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="Label19" runat="server" Text='<%#Eval("Description") %>'></asp:Label></td>
                                                                <td class="text-center">
                                                                    <span>
                                                                        <asp:LinkButton ID="lnkEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                                                                            CommandArgument='<%# Eval("CustInfoID") %>'><i class="fa fa-edit"></i>
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
                                                </div>
                                                <!-- /.box-body -->
                                                <%--</div>--%>
                                            </div>
                                        </div>
                                        <!-- /.box -->
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

                  <div id="frmOrder" method="post" class="form-horizontal" runat="server" visible="false">
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
                            <h4 class="modal-title">Select Customer Type</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="form-group formmargin">
                                          <asp:HiddenField ID="hdnCustomerID" runat="server" />
                                    <label class="col-sm-3 control-label">CustomerType<span class="red">*</span></label>
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


                <%-- function HideLabel() {
                    var seconds = 5;
                    debugger;
                    setTimeout(function () {
                        document.getElementById("<%=divSuccess.ClientID %>").style.display = "none";
                    }, seconds * 1000);
                };--%>


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

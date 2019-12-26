<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="employee.aspx.cs" Inherits="SolarCRM.admin.masters.employee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/PagingUserControl/PagingUserControl.ascx" TagPrefix="uc1" TagName="page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
        <h1>Employee
       <%-- <small>Preview</small>--%>
        </h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a></li>
            <li><a href="#">Master</a></li>
            <li class="active">Employee</li>
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

                <div class="row" id="divEmployee" runat="server">

                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header with-border">
                                <h3 class="box-title">Employee</h3>
                               
                            </div>
                            <div class="form-horizontal">
                                <div class="box-body">

                                    <div class="form-group formmargin">


                                        <div class="col-md-3">
                                            <label>Title<span class="red">*</span></label>
                                            <asp:TextBox ID="txtEmpTitle" runat="server" CssClass="form-control" placeholder="Title" TabIndex="1"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvEmpTitle" runat="server" ErrorMessage="* Required" ControlToValidate="txtEmpTitle"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>

                                        <div class="col-md-3">
                                            <label>First Name<span class="red">*</span></label>
                                            <asp:TextBox ID="txtEmpFirst" runat="server" CssClass="form-control" placeholder="First Name" TabIndex="2"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvEmpFirst" runat="server" ErrorMessage="* Required" ControlToValidate="txtEmpFirst"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>

                                        <div class="col-md-3">
                                            <label>Last Name<span class="red">*</span></label>
                                            <asp:TextBox ID="txtEmpLast" runat="server" CssClass="form-control" placeholder="Last Name" TabIndex="3"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvEmpLast" runat="server" ErrorMessage="* Required" ControlToValidate="txtEmpLast"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>

                                        <div class="col-md-3">
                                            <label>Nic Name<span class="red">*</span></label>
                                            <asp:TextBox ID="txtEmpNicName" runat="server" CssClass="form-control" placeholder="Nic Name" TabIndex="4"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvEmpNicName" runat="server" ErrorMessage="* Required" ControlToValidate="txtEmpNicName"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>


                                    </div>


                                    <div class="form-group formmargin">

                                        <div class="col-md-3">
                                            <label>Mobile<span class="red">*</span></label>
                                            <asp:TextBox ID="txtEmpMobile" runat="server" CssClass="form-control" placeholder="Mobile" TabIndex="5"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvEmpMobile" runat="server" ErrorMessage="* Required" ControlToValidate="txtEmpMobile"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>

                                        <div class="col-md-3">
                                            <label>Email<span class="red">*</span></label>
                                            <asp:TextBox ID="txtEmpEmail" runat="server" CssClass="form-control" placeholder="Email" TabIndex="6"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvEmpEmail" runat="server" ErrorMessage="* Required" ControlToValidate="txtEmpEmail"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="regexEmail" runat="server" ControlToValidate="txtEmpEmail"
                                                    Display="Dynamic" ErrorMessage=" Enter Valid E-Mail Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                </asp:RegularExpressionValidator>
                                            </span>
                                        </div>

                                        <div class="col-md-3">
                                            <label>Sales Team ID<span class="red">*</span></label>
                                            <asp:DropDownList ID="ddlSalesTeamID" runat="server" CssClass="form-control select2" Style="width: 100%;" TabIndex="7"></asp:DropDownList>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvSalesTeamID" runat="server" ErrorMessage="* Required" ControlToValidate="ddlSalesTeamID"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>

                                        <div class="col-md-3">
                                            <label>Employee Type<span class="red">*</span></label>
                                            <asp:DropDownList ID="ddlEmployeeType" runat="server" CssClass="form-control select2" Style="width: 100%;" TabIndex="8"></asp:DropDownList>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvEmployeeType" runat="server" ErrorMessage="* Required" ControlToValidate="ddlEmployeeType"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>

                                    </div>


                                    <div class="form-group formmargin">

                                        <div class="col-md-3">
                                            <label>Initials<span class="red">*</span></label>
                                            <asp:TextBox ID="txtEmpInitials" runat="server" CssClass="form-control" placeholder="Initials" TabIndex="9"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvEmpInitials" runat="server" ErrorMessage="* Required" ControlToValidate="txtEmpInitials"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>

                                        <div class="col-md-3">
                                            <label>Date Hired</label>
                                            <div class="input-group date">
                                                <div class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </div>
                                                <asp:TextBox ID="txtHireDate" class="form-control pull-right datepicker" runat="server" TabIndex="10" ToolTip="Add Admit Date"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-3">
                                            <label>Employee Status<span class="red">*</span></label>
                                            <asp:DropDownList ID="ddlEmployeeStatusID" runat="server" CssClass="form-control select2" Style="width: 100%;" TabIndex="11"></asp:DropDownList>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvEmployeeStatusID" runat="server" ErrorMessage="* Required" ControlToValidate="ddlEmployeeStatusID"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>

                                        <div class="col-md-3">
                                            <label>Location</label>
                                            <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control select2" Style="width: 100%;" TabIndex="12"></asp:DropDownList>
                                        </div>


                                    </div>


                                    <div class="form-group formmargin">

                                        <div class="col-md-3">
                                            <label>User Name<span class="red">*</span></label>
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="User Name" TabIndex="13"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="* Required" ControlToValidate="txtUserName"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>



                                        <div class="col-md-3">
                                            <label>Password<span class="red">*</span></label>
                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TabIndex="14" TextMode="Password"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="* Required" ControlToValidate="txtPassword"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegExPassword" runat="server" ErrorMessage="Password has to be 5 characters !"
                                                    ControlToValidate="txtPassword" ValidationExpression="^.{5,}$" />
                                            </span>
                                        </div>

                                        <div class="col-md-3">
                                            <label>Confirm Password<span class="red">*</span></label>
                                            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" placeholder="Confirm Password" TabIndex="15" TextMode="Password"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="* Required" ControlToValidate="txtConfirmPassword"
                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="compvalConfirmPassword" runat="server" ControlToCompare="txtPassword"
                                                    ControlToValidate="txtConfirmPassword" ErrorMessage="Password MisMatch" SetFocusOnError="True"
                                                    Display="Dynamic"></asp:CompareValidator>
                                            </span>
                                        </div>

                                        <div class="col-md-3">
                                            <label>Tax File Number</label>
                                            <asp:TextBox ID="txtTaxFileNumber" runat="server" CssClass="form-control" placeholder="Tax File Number" TabIndex="16"></asp:TextBox>
                                        </div>

                                    </div>



                                    <div class="form-group">

                                        <div class="col-md-3">
                                            <label>Emp PAN</label>
                                            <asp:TextBox ID="txtEmpPAN" runat="server" CssClass="form-control" placeholder="Emp PAN" TabIndex="17"></asp:TextBox>
                                        </div>

                                        <div class="col-md-3">
                                            <label>Emp Bank</label>
                                            <asp:TextBox ID="txtEmpBank" runat="server" CssClass="form-control" placeholder="Emp Bank" TabIndex="18"></asp:TextBox>
                                        </div>

                                        <div class="col-md-2">
                                            <label>Start Time</label>

                                            <div class="bootstrap-timepicker">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtStartTime" runat="server" CssClass="form-control timepicker" TabIndex="19"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <label>End Time</label>

                                            <div class="bootstrap-timepicker">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtEndTime" runat="server" CssClass="form-control timepicker" TabIndex="20"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <label>Break Time</label>

                                            <div class="bootstrap-timepicker">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtBreakTime" runat="server" CssClass="form-control timepicker" TabIndex="21"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>



                                    <div class="form-group">

                                        <div class="col-md-2">
                                            <label>Include Lists</label>
                                            <div class="checkbox">
                                                <label>
                                                    <asp:CheckBox ID="chkInclude" runat="server" TabIndex="22" />
                                                </label>
                                            </div>
                                        </div>

                                        <div class="col-md-1">
                                            <label>ActiveEmp</label>
                                            <div class="checkbox">
                                                <label>
                                                    <asp:CheckBox ID="chkActiveEmp" runat="server" TabIndex="23" />
                                                </label>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <label>Team Out Door</label>
                                            <div class="checkbox">
                                                <label>
                                                    <asp:CheckBox ID="chkTeamOutDoor" runat="server" TabIndex="24" />
                                                </label>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <label>Team Closer</label>
                                            <div class="checkbox">
                                                <label>
                                                    <asp:CheckBox ID="chkTeamCloser" runat="server" TabIndex="25" />
                                                </label>
                                            </div>
                                        </div>

                                        <div class="col-md-1">
                                            <label>On Roster</label>
                                            <div class="checkbox">
                                                <label>
                                                    <asp:CheckBox ID="chkOnRoster" runat="server" TabIndex="26" />
                                                </label>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <label>Company Pays Super:</label>
                                            <div class="checkbox">
                                                <label>
                                                    <asp:CheckBox ID="chkPaysOwnSuper" runat="server" TabIndex="27" />
                                                </label>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <label>TDS Payment</label>
                                            <div class="checkbox">
                                                <label>
                                                    <asp:CheckBox ID="chkTDSPayment" runat="server" TabIndex="28" />
                                                </label>
                                            </div>
                                        </div>

                                    </div>



                                    <div class="form-group">

                                        <div class="col-md-3">
                                            <label>Select Role<span class="red">*</span></label>
                                            <asp:ListBox ID="lstRole" class="form-control" runat="server" SelectionMode="Multiple"  OnSelectedIndexChanged="lstRole_SelectedIndexChanged" AutoPostBack="true" TabIndex="29"></asp:ListBox>
                                            <span>
                                                <asp:RequiredFieldValidator ControlToValidate="lstRole" ID="rfvRole"
                                                    runat="server" ErrorMessage="* Required" ValidationGroup="error"></asp:RequiredFieldValidator><small><i> To select multiple
                                                                options please press (CTRL+Click)</i></small>
                                            </span>

                                        </div>

                                        <div class="col-md-3">
                                            <label>Information</label>
                                            <asp:TextBox ID="txtEmpInfo" runat="server" TextMode="MultiLine" class="form-control" placeholder="Notes ..." TabIndex="30"></asp:TextBox>
                                        </div>

                                        <div id="designer" class="col-md-1" runat="server">
                                              <label>Designer</label>
                                            <div class="checkbox" >
                                                <label>
                                                    <asp:CheckBox ID="chkIsDesigner" runat="server" TabIndex="30" />
                                                </label>
                                            </div>
                                            </div>
                                          <div id="electrician" class="col-md-1" runat="server">
                                      
                                             <label>Electrician</label>
                                            <div class="checkbox">
                                                <label>
                                                    <asp:CheckBox ID="chkIsElectrician" runat="server" TabIndex="31" />
                                                </label>
                                            </div>
                                        </div>

                                    </div>


                                </div>
                            </div>


                            <div class="box-footer">
                                <asp:Button ID="btnReset" class="btn btn-default" runat="server" Text="Reset" TabIndex="32" />
                                <%--  <asp:Button ID="btnUpdate" Visible="false" runat="server" CssClass="btn btn-info pull-right" Text="Update" ValidationGroup="error" TabIndex="31" />--%>
                                <asp:Button ID="btnSave" class="btn btn-info pull-right" runat="server" Text="Save" ValidationGroup="error" OnClick="btnSave_Click" TabIndex="31" />
                            </div>

                        </div>


                        <div class="row">
                            <div class="col-md-12">
                                <div class="box box-primary">
                                    <div class="box-header">
                                        <div class="col-md-6">
                                            <h3 class="box-title">Employee List</h3>
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
                                        <asp:Repeater ID="rptEmployee" runat="server" OnItemCommand="rptEmployee_ItemCommand">
                                            <HeaderTemplate>
                                                <table id="example2" class="table table-bordered table-hover">
                                                    <thead>
                                                        <tr>
                                                            <th class="text-center">Employee</th>
                                                            <th class="text-center">Position</th>
                                                            <th class="text-center">Nic Name</th>
                                                            <th class="text-center">Status</th>
                                                            <th class="text-center">Team</th>
                                                            <th class="text-center">Detail</th>
                                                            <th class="text-center">Change Password</th>

                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="text-center">
                                                        <asp:Label ID="lblfullname" runat="server" Text='<%#Eval("fullname") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblJobTitle" runat="server" Text='<%#Eval("JobTitle") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblEmpNicName" runat="server" Text='<%#Eval("EmpNicName") %>'></asp:Label>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="lblemployeestatusname" runat="server" Text='<%#Eval("EmployeeStatus") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSalesTeam" runat="server" Text='<%#Eval("SalesTeam") %>'></asp:Label>
                                                    </td>


                                                    <td class="text-center">
                                                        <span>
                                                            <asp:LinkButton ID="lnkDetail" runat="server" ToolTip="Detail" CommandName="Detail"
                                                                CommandArgument='<%# Eval("EmployeeID") %>'><i class="fa fa-hand-o-right"></i>
                                                            </asp:LinkButton>
                                                        </span>
                                                    </td>

                                                    
                                                    <td class="text-center">
                                                        <span>
                                                            <asp:LinkButton ID="InkResetPass" runat="server" ToolTip="Reset" CommandName="Reset"
                                                                CommandArgument='<%# Eval("EmployeeID") %>'>Reset Password
                                                               <%-- <i class="fa fa-hand-o-right"></i>--%>
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
                                            <uc1:page ID="pageGrid" runat="server" Visible="true"  />
                                        </div>
                                    </div>

                                </div>

                            </div>

                        </div>

                    </div>
                </div>



                <div class="row" id="divEmployeeDetails" runat="server" visible="false">
                    <div class="col-md-12">
                        <div class="box box-primary">

                            <div class="box-header with-border">
                                <h3 class="box-title">Employee Information</h3>
                               <asp:Button ID="btnBack" class="btn btn-info pull-right" runat="server" Text="Back" ValidationGroup="error" OnClick="btnBack_Click"/>
                            </div>


                            <div class="box-body">

                                <div class="nav-tabs-custom">
                                    <ul class="nav nav-tabs">
                                        <li class="active"><a href="#Empdetails" data-toggle="tab">Details</a></li>
                                        <li><a href="#Permissions" data-toggle="tab">Permissions</a></li>
                                        <li><a href="#References" data-toggle="tab">References</a></li>
                                    </ul>
                                    <div class="tab-content">

                                        <div class="tab-pane active" id="Empdetails">
                                            <div class="form-horizontal">
                                                <div class="box-body">

                                                    <div class="form-group formmargin">

                                                        <div class="col-md-3">
                                                            <label>Title<span class="red">*</span></label>

                                                            <asp:HiddenField ID="hdnEmployeeID" runat="server" ClientIDMode="Static" />
                                                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder="Title" TabIndex="33"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ErrorMessage="* Required" ControlToValidate="txtTitle"
                                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <label>First Name<span class="red">*</span></label>
                                                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First Name" TabIndex="34"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="* Required" ControlToValidate="txtFirstName"
                                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <label>Last Name<span class="red">*</span></label>
                                                            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Last Name" TabIndex="35"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="* Required" ControlToValidate="txtLastName"
                                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </div>



                                                        <div class="col-md-3">
                                                            <label>Nic Name<span class="red">*</span></label>
                                                            <asp:TextBox ID="txtNicName" runat="server" CssClass="form-control" placeholder="Nic Name" TabIndex="36"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvNicName" runat="server" ErrorMessage="* Required" ControlToValidate="txtNicName"
                                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </div>



                                                    </div>

                                                    <div class="form-group formmargin">



                                                        <div class="col-md-3">
                                                            <label>Initials<span class="red">*</span></label>
                                                            <asp:TextBox ID="txtInitials" runat="server" CssClass="form-control" placeholder="Initials" TabIndex="37"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvInitials" runat="server" ErrorMessage="* Required" ControlToValidate="txtInitials"
                                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </div>


                                                        <div class="col-md-3">
                                                            <label>Email<span class="red">*</span></label>
                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" TabIndex="38"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="* Required" ControlToValidate="txtEmail"
                                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="regEmail" runat="server" ControlToValidate="txtEmail"
                                                                    Display="Dynamic" ErrorMessage=" Enter Valid E-Mail Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                                </asp:RegularExpressionValidator>
                                                            </span>
                                                        </div>


                                                        <div class="col-md-3">
                                                            <label>Mobile<span class="red">*</span></label>
                                                            <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Mobile" TabIndex="39"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ErrorMessage="* Required" ControlToValidate="txtMobile"
                                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <label>Emp Status<span class="red">*</span></label>
                                                            <asp:DropDownList ID="ddlEmpStatus" runat="server" CssClass="form-control select2" Style="width: 100%;" TabIndex="40"></asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvEmpStatus" runat="server" ErrorMessage="* Required" ControlToValidate="ddlEmpStatus"
                                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </div>

                                                    </div>

                                                    <div class="form-group formmargin">

                                                        <div class="col-md-3">
                                                            <label>Location<span class="red">*</span></label>
                                                            <asp:DropDownList ID="ddlLocationID" runat="server" CssClass="form-control select2" Style="width: 100%;" TabIndex="41"></asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvLocationID" runat="server" ErrorMessage="* Required" ControlToValidate="ddlLocationID"
                                                                    ValidationGroup="error"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </div>


                                                        <div class="col-md-3">
                                                            <label>Date Hired</label>
                                                            <div class="input-group date">
                                                                <div class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
                                                                <asp:TextBox ID="txtDateHired" class="form-control pull-right datepicker" runat="server" TabIndex="42" ToolTip="Add Admit Date"></asp:TextBox>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-3">
                                                            <label>Start Time</label>

                                                            <div class="bootstrap-timepicker">
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="txtSTime" runat="server" CssClass="form-control timepicker" TabIndex="43"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-3">
                                                            <label>End Time</label>

                                                            <div class="bootstrap-timepicker">
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="txtETime" runat="server" CssClass="form-control timepicker" TabIndex="44"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="form-group formmargin">

                                                        <div class="col-md-3">
                                                            <label>Break Time</label>
                                                            <div class="bootstrap-timepicker">
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="txtBTime" runat="server" CssClass="form-control timepicker" TabIndex="45"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-2">
                                                            <label>ActiveEmp</label>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkActive" runat="server" TabIndex="46" />
                                                                </label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-2">
                                                            <label>Include Lists</label>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkIncludeList" runat="server" TabIndex="47" />
                                                                </label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-2">
                                                            <label>On Roster List</label>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkRoster" runat="server" TabIndex="48" />
                                                                </label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <label>Information</label>
                                                            <asp:TextBox ID="txtInfo" runat="server" TextMode="MultiLine" class="form-control" placeholder="Notes ..." TabIndex="49"></asp:TextBox>
                                                        </div>

                                                    </div>

                                                </div>

                                                <div class="box-footer">
                                                    <asp:Button ID="btnUpdateDetails" runat="server" TabIndex="50" CssClass="btn btn-info pull-right" Text="Save" OnClick="btnUpdateDetails_Click" />
                                                    <asp:Button ID="btnCancelDetails" runat="server" TabIndex="51" CssClass="btn btn-default" Text="Cancel" OnClick="btnCancelDetails_Click" />
                                                </div>

                                            </div>
                                        </div>

                                        <div class="tab-pane" id="Permissions">
                                            <div class="form-horizontal">
                                                <div class="box-body">

                                                    <div class="form-group">

                                                        <div class="col-md-2">
                                                            <%--  <label>ActiveEmp</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkAdminPL" runat="server" TabIndex="52" />
                                                                    <b>Admin PL</b>
                                                                </label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-2">
                                                            <%-- <label>Inv Issued PL</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkInvIssuedPL" runat="server" TabIndex="53" />
                                                                    <b>Inv Issued PL</b>
                                                                </label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-2">
                                                            <%-- <label>On Roster List</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkSuperTaxPL" runat="server" TabIndex="54" />
                                                                    <b>Super Tax PL</b>
                                                                </label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <%-- <label>On Roster List</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkExecAccess" runat="server" TabIndex="55" />
                                                                    <b>Executive Access</b>
                                                                </label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-2">
                                                            <%-- <label>On Roster List</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkBookingsPL" runat="server" TabIndex="56" />
                                                                    <b>Bookings PL</b>
                                                                </label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <%-- <label>On Roster List</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkInvPaidPL" runat="server" TabIndex="57" />
                                                                    <b>Invoices Paid PL</b>
                                                                </label>
                                                            </div>
                                                        </div>

                                                    </div>


                                                    <div class="form-group">

                                                        <div class="col-md-2">
                                                            <%--  <label>ActiveEmp</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkWagesPL" runat="server" TabIndex="58" />
                                                                    <b>Wages PL</b>
                                                                </label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-2">
                                                            <%-- <label>Inv Issued PL</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkDeleteAccess" runat="server" TabIndex="59" />
                                                                    <b>Delete Access</b>
                                                                </label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-2">
                                                            <%-- <label>On Roster List</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkCompaniesPL" runat="server" TabIndex="60" />
                                                                    <b>Companies PL</b>
                                                                </label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <%-- <label>On Roster List</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkProjectsPL" runat="server" TabIndex="61" />
                                                                    <b>Projects PL</b>
                                                                </label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-2">
                                                            <%-- <label>On Roster List</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkWholesalePL" runat="server" TabIndex="62" />
                                                                    <b>Wholesale PL</b>
                                                                </label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <%-- <label>On Roster List</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkAdminAccess" runat="server" TabIndex="63" />
                                                                    <b>Edit Access</b>
                                                                </label>
                                                            </div>
                                                        </div>

                                                    </div>


                                                    <div class="form-group">

                                                        <div class="col-md-2">
                                                            <%--  <label>ActiveEmp</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkContactsPL" runat="server" TabIndex="64" />
                                                                    <b>Contacts PL</b>
                                                                </label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-2">
                                                            <%-- <label>Inv Issued PL</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkStockItemsPL" runat="server" TabIndex="65" />
                                                                    <b>Stock Items PL</b>
                                                                </label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-2">
                                                            <%-- <label>On Roster List</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkBillsOwingPL" runat="server" TabIndex="66" />
                                                                    <b>Bills Owing PL</b>
                                                                </label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <%-- <label>On Roster List</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkProjDispAccess" runat="server" TabIndex="67" />
                                                                    <b>Proj Display Access</b>
                                                                </label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-2">
                                                            <%--  <label>ActiveEmp</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkStockOrdersPL" runat="server" TabIndex="68" />
                                                                    <b>Stock Orders PL</b>
                                                                </label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-2">
                                                            <%-- <label>On Roster List</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFollowUpPL" runat="server" TabIndex="69" />
                                                                    <b>Follow Ups PL</b>
                                                                </label>
                                                            </div>
                                                        </div>

                                                    </div>


                                                    <div class="form-group">

                                                        <div class="col-md-2">
                                                            <%-- <label>On Roster List</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkBillsPaidPL" runat="server" TabIndex="70" />
                                                                    <b>Bills Paid PL</b>
                                                                </label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <%-- <label>On Roster List</label>--%>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkManagerAccess" runat="server" TabIndex="71" />
                                                                    <b>Manager Access</b>
                                                                </label>
                                                            </div>
                                                        </div>



                                                    </div>

                                                </div>
                                                <!-- /.box-body -->
                                                <div class="box-footer">
                                                    <asp:Button ID="btnUpdatePermissions" runat="server" TabIndex="72" CssClass="btn btn-info pull-right" Text="Save" OnClick="btnUpdatePermissions_Click" />
                                                    <asp:Button ID="btnCancelPermissions" runat="server" TabIndex="73" CssClass="btn btn-default" Text="Cancel" OnClick="btnCancelPermissions_Click" />
                                                </div>
                                                <!-- /.box-footer -->
                                            </div>
                                        </div>

                                        <div class="tab-pane" id="References">
                                            <div class="form-horizontal">
                                                <div class="box-body">

                                                    <div class="form-group">

                                                        <div class="col-md-3">
                                                            <label>Tax File No</label>
                                                            <asp:TextBox ID="txtTaxFileNo" runat="server" CssClass="form-control" placeholder="Tax File No" TabIndex="74"></asp:TextBox>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <label>Super Fund</label>
                                                            <asp:TextBox ID="txtSuperFund" runat="server" CssClass="form-control" placeholder="Super Fund" TabIndex="75"></asp:TextBox>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <label>Super Account</label>
                                                            <asp:TextBox ID="txtSuperFundAccount" runat="server" CssClass="form-control" placeholder="Super Account" TabIndex="76"></asp:TextBox>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <label>Bank BSB</label>
                                                            <asp:TextBox ID="txtEmpBSB" runat="server" CssClass="form-control" placeholder="Bank BSB" TabIndex="77"></asp:TextBox>
                                                        </div>

                                                    </div>

                                                    <div class="form-group">

                                                        <div class="col-md-3">
                                                            <label>Account</label>
                                                            <asp:TextBox ID="txtEmpBankAcct" runat="server" CssClass="form-control" placeholder="Account" TabIndex="78"></asp:TextBox>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <label>Initial Quota</label>
                                                            <asp:TextBox ID="txtInitialSalesQuota" runat="server" CssClass="form-control" placeholder="Initial Quota" TabIndex="79"></asp:TextBox>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <label>Employee Address</label>
                                                            <asp:TextBox ID="txtEmpAddress" runat="server" CssClass="form-control" placeholder="Employee Address" TabIndex="80"></asp:TextBox>
                                                        </div>



                                                        <div class="col-md-3">
                                                            <label>City</label>
                                                            <asp:TextBox ID="txtEmpCity" runat="server" CssClass="form-control" placeholder="City" TabIndex="81"></asp:TextBox>
                                                        </div>



                                                    </div>

                                                    <div class="form-group">

                                                        <div class="col-md-3">
                                                            <label>State</label>
                                                            <asp:TextBox ID="txtEmpState" runat="server" CssClass="form-control" placeholder="State" TabIndex="82"></asp:TextBox>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <label>Post Code</label>
                                                            <asp:TextBox ID="txtEmpPostCode" runat="server" CssClass="form-control" placeholder="Post Code" TabIndex="83"></asp:TextBox>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Is Sales Rep</label>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkAdminStaff" runat="server" TabIndex="84" />
                                                                </label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Admin Person</label>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkSalesRep" runat="server" TabIndex="85" />
                                                                </label>
                                                            </div>
                                                        </div>



                                                    </div>


                                                </div>
                                                <!-- /.box-body -->
                                                <div class="box-footer">
                                                    <asp:Button ID="btnEmployeeReferences" runat="server" TabIndex="86" CssClass="btn btn-info pull-right" Text="Save" OnClick="btnEmployeeReferences_Click" />
                                                    <asp:Button ID="btnCancelReferences" runat="server" TabIndex="87" CssClass="btn btn-default" Text="Cancel" OnClick="btnCancelReferences_Click" />
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

<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="addcompany.aspx.cs" Inherits="SolarCRM.admin.company.addcompany" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/PagingUserControl/PagingUserControl.ascx" TagPrefix="uc1" TagName="page" %>
<%@ Register Src="~/PagingUserControl/Paggingctrl.ascx" TagPrefix="uc2" TagName="page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script type="text/javascript">
        function SetContextKey() {
            $find('<%=AutoCompleteArea.ClientID%>').set_contextKey($get("<%=ddlState.ClientID %>").value);
        }
        function SetContextKeyforPostal() {
            $find('<%=AutoCompleteExtender1.ClientID%>').set_contextKey($get("<%=ddlPostalState.ClientID %>").value);
        }

    </script>
    <section class="content-header">
        <h1>Lead
       <%-- <small>Preview</small>--%>
        </h1>
        <ol class="breadcrumb">
            <li><a href="<%=SiteURL%>/admin/dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a></li>
            <%-- <li><a href="#">company</a></li>--%>
            <li class="active">company</li>
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

                  <div class="row" id="divcompanydetails" runat="server"  clintidmode="static">
                    <div class="col-md-12">
                         <div class="nav-tabs-custom">

                            <ul class="nav nav-tabs">
                                <li id="liaddcompany" runat="server" class="active"><a href="#tabaddcompany" data-toggle="tab">Add Company</a></li>
                                <li id="liaddproject" runat="server"><a href="#tabaddproject" data-toggle="tab">Add Project</a></li>
                            </ul>
                            <div class="tab-content">

                             <div class="tab-pane active" id="tabaddcompany" runat="server" clientidmode="static">
                             <div class="row">
                        
                              <div class="col-md-12">

                            <div class="form-horizontal">
                                   <div class="box box-primary">
                                <div class="box-body">
                                    
                                    <div class="col-md-6">

                                        <div class="form-group" runat="server">
                                            <label class="col-sm-12 text-center">Add New Company</label>

                                        </div>

                                        <div id="divCustomer" runat="server" visible="false">
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Company :</label>
                                                <div class="col-sm-9">
                                                    <asp:Label ID="lblCustomer" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Address :</label>
                                                <div class="col-sm-9">
                                                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Phone :</label>
                                                <div class="col-sm-9">
                                                    <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Assign To:</label>
                                                <div class="col-sm-9">
                                                    <asp:Label ID="lblAssign" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Customer Entered:</label>
                                                <div class="col-sm-9">
                                                    <asp:Label ID="lblCustomerEntered" runat="server"></asp:Label>
                                                </div>
                                            </div>


                                        </div>

                                        <div class="form-group formmargin" runat="server" id="divMrMs">
                                            <label class="col-sm-3 control-label">Name <span class="red">*</span></label>
                                            <div class="col-sm-3">
                                                <asp:DropDownList runat="server" ID="ddlSalutation" MaxLength="10" CssClass="form-control select2 " TabIndex="1">
                                                    <asp:ListItem Text="Mr" Value="Mr"></asp:ListItem>
                                                    <asp:ListItem Text="Mrs" Value="Mrs"></asp:ListItem>
                                                    <asp:ListItem Text="Miss" Value="Miss"></asp:ListItem>
                                                    <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-6">
                                                <asp:TextBox ID="txtContFirst" runat="server" MaxLength="30" CssClass="form-control"
                                                    placeholder="First Name" TabIndex="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtContFirst" runat="server" ErrorMessage="* Required"
                                                    ControlToValidate="txtContFirst" ValidationGroup="company"></asp:RequiredFieldValidator>
                                            </div>

                                        </div>

                                        <div class="form-group formmargin" runat="server" id="divMrMs1">
                                            <label class="col-sm-3 control-label">Last Name <span class="red">*</span></label>

                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtContLast" runat="server" MaxLength="40" CssClass="form-control"
                                                    placeholder="Last Name" OnTextChanged="txtContLast_TextChanged" AutoPostBack="true" TabIndex="3"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtContLast" runat="server" ErrorMessage="* Required"
                                                    ControlToValidate="txtContLast" ValidationGroup="company"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>


                                        <div class="form-group formmargin" runat="server" id="divCompany">

                                              <asp:HiddenField ID="hdnCustomerID" runat="server" />

                                            <label class="col-sm-3 control-label">Company <span class="red">*</span></label>

                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtCompany" runat="server" MaxLength="100" CssClass="form-control" TabIndex="4"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtCompany" runat="server" ErrorMessage="* Required"
                                                    ControlToValidate="txtCompany" ValidationGroup="company"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>


                                        <div class="form-group" runat="server" id="divMobile">
                                            <label class="col-sm-3 control-label">Mobile</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtContMobile" runat="server" MaxLength="10" CssClass="form-control" AutoPostBack="true"
                                                    OnTextChanged="txtContMobile_TextChanged" TabIndex="5"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="form-group formmargin" runat="server" id="divEmail">
                                            <label class="col-sm-3 control-label">Email</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtContEmail" runat="server" MaxLength="100" CssClass="form-control" AutoPostBack="true"
                                                    OnTextChanged="txtContEmail_TextChanged" TabIndex="6"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="regvalEmail" runat="server" ControlToValidate="txtContEmail"
                                                    ValidationGroup="company" ErrorMessage=" Enter Valid E-Mail Address"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> </asp:RegularExpressionValidator>
                                            </div>
                                        </div>


                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Phone</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtCustPhone" runat="server" AutoPostBack="true" MaxLength="10" CssClass="form-control"
                                                    OnTextChanged="txtCustPhone_TextChanged" TabIndex="7"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Alt Phone</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtCustAltPhone" runat="server" MaxLength="20" CssClass="form-control" TabIndex="8"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group formmargin">
                                            <label class="col-sm-3 control-label">CustomerType<span class="red">*</span></label>
                                            <div class="col-sm-9">
                                                <asp:DropDownList ID="ddlCustTypeID" runat="server" CssClass="form-control select2" AppendDataBoundItems="true" TabIndex="9" Style="width: 100%;">
                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlCustTypeID" runat="server" ErrorMessage="* Required"
                                                    ControlToValidate="ddlCustTypeID" ValidationGroup="company"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Project Type<span class="red">*</span></label>
                                            <div class="col-sm-9">
                                                <asp:DropDownList ID="ddlProjectType" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="form-group formmargin">
                                            <label class="col-sm-3 control-label">CompanySource<span class="red">*</span></label>
                                            <div class="col-sm-9">
                                                <asp:DropDownList ID="ddlCustSourceID" runat="server"
                                                    AutoPostBack="true" CssClass="form-control select2" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlCustSourceID_SelectedIndexChanged" TabIndex="11" Style="width: 100%;">
                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlCustSourceID" runat="server" ErrorMessage="* Required"
                                                    ControlToValidate="ddlCustSourceID" ValidationGroup="company"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>


                                        <div class="form-group" id="sourcesub" runat="server" visible="false">
                                            <label class="col-sm-3 control-label">Source Sub<span class="red">*</span></label>
                                            <div class="col-sm-9">
                                                <asp:DropDownList ID="ddlCustSourceSubID" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlCustSourceSubID_SelectedIndexChanged"
                                                    CssClass="form-control search-select" TabIndex="12">
                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:CompareValidator
                                                    ID="valDDCError"
                                                    runat="server"
                                                    ControlToValidate="ddlCustSourceSubID"
                                                    Operator="NotEqual"
                                                    ValueToCompare="0"
                                                    ErrorMessage="* Required" ValidationGroup="company">
                                                </asp:CompareValidator>
                                            </div>
                                        </div>

                                        <div id="pnlref" runat="server" visible="false">
                                            <div class="form-group formmargin">
                                                <label class="col-sm-3 control-label">Referred By</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtRefBy" runat="server" ValidationGroup="search" placeholder="Referred By Cusomer" CssClass="form-control "></asp:TextBox>
                                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender2" MinimumPrefixLength="2" runat="server"
                                                        UseContextKey="true" TargetControlID="txtRefBy" ServicePath="~/admin/includes/Search.asmx"
                                                        CompletionListCssClass="autocomplete_completionListElement" ServiceMethod="GetCompanyList"
                                                        EnableCaching="false" CompletionInterval="10" CompletionSetCount="20" />

                                                </div>
                                            </div>
                                            <div class="form-group formmargin">
                                                <label class="col-sm-3 control-label">Referred By Project No</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtProjectNumber" runat="server" CssClass="form-control" placeholder="Project Num"></asp:TextBox>

                                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender7" MinimumPrefixLength="2" runat="server"
                                                        UseContextKey="true" TargetControlID="txtProjectNumber" ServicePath="~/Search.asmx"
                                                        CompletionListCssClass="autocomplete_completionListElement" ServiceMethod="GetProjectNumber"
                                                        EnableCaching="false" CompletionInterval="10" CompletionSetCount="20" />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="search"
                                                        ControlToValidate="txtProjectNumber" Display="Dynamic" ErrorMessage="Please enter a number"
                                                        ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="form-group formmargin">
                                                <label class="col-sm-3 control-label">Referral Notes</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtrefnotes" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label">Notes </label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="txtCustNotes" runat="server" TextMode="MultiLine" CssClass="form-control" TabIndex="13"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="box box-info" style="visibility: hidden">
                                                <div class="form-horizontal">
                                                    <div class="box-body">

                                                        <div class="form-group">
                                                            <label class="col-sm-3 control-label">Connected Load </label>

                                                            <div class="col-sm-9">
                                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"
                                                                    placeholder="Last Name"></asp:TextBox>

                                                            </div>
                                                        </div>

                                                        <div class="form-group">
                                                            <label class="col-sm-3 control-label">Terrace Space </label>

                                                            <div class="col-sm-9">
                                                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"
                                                                    placeholder="Last Name"></asp:TextBox>

                                                            </div>
                                                        </div>

                                                        <div class="form-group">
                                                            <label class="col-sm-3 control-label">Monthly Ele. Bill </label>

                                                            <div class="col-sm-9">
                                                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" TabIndex="26">
                                                                    <asp:ListItem Value="1">One</asp:ListItem>
                                                                    <asp:ListItem Value="2">Two</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </div>

                                                        <div class="form-group">
                                                            <label class="col-sm-3 control-label">Amount </label>

                                                            <div class="col-sm-9">
                                                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"
                                                                    placeholder="Last Name"></asp:TextBox>

                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="form-group formmargin">
                                            <label class="col-sm-3 control-label">Area <span class="red">*</span></label>

                                            <div class="col-sm-9">

                                                <asp:RadioButtonList ID="rblArea" runat="server" RepeatDirection="Horizontal" TabIndex="26">
                                                    <asp:ListItem Value="1">Metro</asp:ListItem>
                                                    <asp:ListItem Value="2">Regional</asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:RequiredFieldValidator ID="rfvrblArea" runat="server" ErrorMessage="* Required"
                                                    ValidationGroup="company" ControlToValidate="rblArea"></asp:RequiredFieldValidator>

                                            </div>

                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Country</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtCountry" runat="server" Enabled="false" MaxLength="50" Text="India"
                                                    CssClass="form-control" TabIndex="27"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Website</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtCustWebSiteLink" runat="server" MaxLength="100" CssClass="form-control" TabIndex="28"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Fax</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtCustFax" runat="server" MaxLength="20" CssClass="form-control" TabIndex="29"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Cust Rating</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtCustRating" runat="server" MaxLength="5" CssClass="form-control" TabIndex="30"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                    ValidationGroup="company" ControlToValidate="txtCustRating" Display="Dynamic"
                                                    ErrorMessage="Please enter a number" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-sm-4">
                                                <label>1 = Most Likely To Buy</label>
                                            </div>
                                        </div>


                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group" runat="server">
                                            <label class="col-sm-12 text-center">Add Company Address</label>
                                        </div>
                                        <div class="form-group formmargin">
                                            <label class="col-sm-3 control-label">CompanyType<span class="red">*</span></label>
                                            <div class="col-sm-9">
                                                <asp:DropDownList ID="ddlCompanyType" runat="server" AppendDataBoundItems="true"
                                                    CssClass="form-control select2" TabIndex="14" Style="width: 100%;">
                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlCompanyType" runat="server" ErrorMessage="* Required"
                                                    ControlToValidate="ddlCompanyType" ValidationGroup="company"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group formmargin">
                                            <label class="col-sm-3 control-label">Zone <span class="red">*</span></label>
                                            <div class="col-sm-9">
                                                <asp:DropDownList ID="ddlZone" runat="server" AppendDataBoundItems="true"
                                                    CssClass="form-control select2" TabIndex="15" Style="width: 100%;">
                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlZone" runat="server" ErrorMessage="* Required"
                                                    ControlToValidate="ddlZone" ValidationGroup="company"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>


                                        <div class="form-group formmargin">
                                            <label class="col-sm-3 control-label">SiteAddress<span class="red">*</span></label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtSiteAddress" ClientIDMode="Static" runat="server" CssClass="form-control" TabIndex="16"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtSiteAddress" runat="server" ErrorMessage="* Required"
                                                    ControlToValidate="txtSiteAddress" ValidationGroup="company"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group formmargin">
                                            <label class="col-sm-3 control-label">State <span class="red">*</span></label>
                                            <div class="col-sm-9">
                                                <asp:DropDownList ID="ddlState" runat="server" AppendDataBoundItems="true"
                                                    CssClass="form-control select2" TabIndex="17" Style="width: 100%;">
                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlState" runat="server" ErrorMessage="* Required"
                                                    ControlToValidate="ddlState" ValidationGroup="company"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>


                                        <div class="form-group formmargin">
                                            <label class="col-sm-3 control-label">Area <span class="red">*</span></label>
                                            <div class="col-sm-9">
                                                <asp:HiddenField ID="hdnCompanyLocationID" runat="server" />
                                                <asp:TextBox ID="txtArea" runat="server" CssClass="form-control" AutoPostBack="true" onkeyup="SetContextKey()"
                                                    OnTextChanged="txtArea_TextChanged" MaxLength="50" TabIndex="18"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtArea" runat="server" ErrorMessage="* Required"
                                                    ControlToValidate="txtArea" ValidationGroup="company"></asp:RequiredFieldValidator>
                                                <asp:AutoCompleteExtender ID="AutoCompleteArea" MinimumPrefixLength="4" runat="server"
                                                    UseContextKey="true" TargetControlID="txtArea" ServicePath="~/admin/includes/Search.asmx"
                                                    CompletionListCssClass="autocomplete_completionListElement" ServiceMethod="GetCitiesList"
                                                    EnableCaching="false" CompletionInterval="10" CompletionSetCount="20" />
                                            </div>
                                        </div>


                                        <div class="form-group formmargin">
                                            <label class="col-sm-3 control-label">City <span class="red">*</span></label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtCity" runat="server" MaxLength="10" CssClass="form-control" autocomplete="off"
                                                    TabIndex="19"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtCity" runat="server" ErrorMessage="* Required"
                                                    ControlToValidate="txtCity" ValidationGroup="company"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>


                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Post Code<span class="red">*</span></label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtPostCode" runat="server" MaxLength="10" CssClass="form-control"
                                                    TabIndex="20"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="regtxtPostCode" runat="server" ControlToValidate="txtPostCode"
                                                    ValidationGroup="company" Display="Dynamic" ErrorMessage="Please enter a number"
                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="rfvtxtPostCode" runat="server" ErrorMessage="* Required"
                                                    ValidationGroup="company" ControlToValidate="txtPostCode"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-3 control-label"></label>
                                            <div class="col-sm-9">
                                                <asp:CheckBox ID="chkSameasAbove" runat="server" OnCheckedChanged="chkSameasAbove_CheckedChanged"
                                                    AutoPostBack="true" TabIndex="22" Text="Same as street address" />
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">PostalAddress</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtPostalAddress" runat="server" CssClass="form-control"
                                                    TabIndex="21"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">State</label>
                                            <div class="col-sm-9">
                                                <asp:DropDownList ID="ddlPostalState" runat="server" AppendDataBoundItems="true"
                                                    CssClass="form-control select2" TabIndex="22" Style="width: 100%;">
                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Area</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtPostalArea" runat="server" CssClass="form-control" AutoPostBack="true" onkeyup="SetContextKey()"
                                                    OnTextChanged="txtPostalArea_TextChanged" MaxLength="50" TabIndex="23"></asp:TextBox>

                                                <asp:AutoCompleteExtender ID="AutoCompleteExtender1" MinimumPrefixLength="4" runat="server"
                                                    UseContextKey="true" TargetControlID="txtPostalArea" ServicePath="~/admin/includes/Search.asmx"
                                                    CompletionListCssClass="autocomplete_completionListElement" ServiceMethod="GetCitiesList"
                                                    EnableCaching="false" CompletionInterval="10" CompletionSetCount="20" />
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">City</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtPostalCity" runat="server" CssClass="form-control"
                                                    Enabled="false" TabIndex="24"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Post Code</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtPostalPostCode" runat="server" MaxLength="10" CssClass="form-control"
                                                    Enabled="false" TabIndex="25"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="regtxtPostalPostCode" runat="server" ControlToValidate="txtPostalPostCode"
                                                    ValidationGroup="company" ErrorMessage="Please enter a number"
                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>





                                    </div>

                                </div>
                          
                                 <div class="box-footer">
                                <asp:Button CssClass="btn btn-info pull-right" ID="btnAdd" runat="server" OnClick="btnAdd_Click"
                                    Text="Add" ValidationGroup="company" TabIndex="31" />
                                <asp:Button CssClass="btn btn-info pull-right" ID="btnUpdate" runat="server" OnClick="btnUpdate_Click"
                                    Text="Update" Visible="false" ValidationGroup="company" TabIndex="32" />
                                <asp:Button CssClass="btn btn-default" ID="btnReset" runat="server" OnClick="btnReset_Click"
                                    CausesValidation="false" Text="Reset" TabIndex="33" />

                                <asp:Button CssClass="btn btn-default" ID="btnCancel" runat="server" Visible="false" OnClick="btnCancel_Click" CausesValidation="false" Text="Reset" TabIndex="34" />

                            </div>
                                       </div>
                                </div>
                             <div class="box box-primary">
                                 
                                      <div  id="divcompanylist">
                        <div class="col-md-12">
                         
                                <div class="box-header">

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
                                    <asp:Repeater ID="rptCompanylist" runat="server" OnItemCommand="rptCompanylist_ItemCommand" OnItemDataBound="rptCompanylist_ItemDataBound">
                                        <HeaderTemplate>
                                            <table id="example2" class="table table-bordered table-hover">
                                                <thead>
                                                    <tr>
                                                        <th class="text-center">Company Name</th>
                                                        <th class="text-center">Address</th>
                                                        <th class="text-center">Location</th>
                                                        <th class="text-center">Project Type</th>
                                                        <th class="text-center">Phone</th>
                                                        <th class="text-center">Assigned To</th>
                                                        <th class="text-center">Edit</th>

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
                                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("CustMobile") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("AssignedTo") %>'></asp:Label></td>
                                                <td class="text-center">
                                                    <span>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                                                            CommandArgument='<%# Eval("CustomerID") %>'><i class="fa fa-edit"></i>
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
                        <!-- /.col -->
                    </div>
                             
                                     
                                      <div class="col-md-12">
                        <div id="NameDupCheck" runat="server" clientidmode="Static" class="modal fade">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">

                                        <h4 class="modal-title">The following Location(s) have a
                                        <%--<br />--%>
                                        similar name. Check for Duplicates.</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="box-body table-scrollable1">

                                                    <asp:Repeater ID="rptNameDupCheck" runat="server">
                                                        <HeaderTemplate>
                                                            <table id="example2" class="table table-bordered table-hover">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Contacts</th>
                                                                        <th>Location</th>
                                                                        <th>Mobile</th>
                                                                        <th>Email</th>
                                                                        <th>Assign To</th>

                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>

                                                            <tr>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblContacts" Text='<%#Eval("Contacts") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="Label1" Text='<%#Eval("Locations") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="Label2" Text='<%#Eval("ContMobile") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="Label3" Text='<%#Eval("ContEmail") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="Label4" Text='<%#Eval("AssignedTo") %>'></asp:Label></td>
                                                            </tr>

                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody>
                                            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnDupeName" runat="server" data-dismiss="modal" CssClass="btn btn-primary" Text="Dupe" CausesValidation="false" OnClick="btnDupeName_Click" />
                                        <asp:Button ID="btnNotDupeName" runat="server" data-dismiss="modal" CssClass="btn btn-primary" Text="Not Dupe" CausesValidation="false" OnClick="btnNotDupeName_Click" />

                                    </div>
                                </div>
                                <!-- /.modal-content -->
                            </div>
                            <!-- /.modal-dialog -->
                        </div>
                        <!-- /.modal -->
                    </div>

                                      <div class="col-md-12">
                        <div id="MobileDupCheck" runat="server" clientidmode="Static" class="modal fade">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">

                                        <h4 class="modal-title"><b>There is a Contact in the database already who has this mobile number. This
                                           <%-- <br />--%>
                                            looks like a Duplicate Entry.</b></h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="box-body table-scrollable1">

                                                    <asp:Repeater ID="rptMobileDupCheck" runat="server">
                                                        <HeaderTemplate>
                                                            <table id="example2" class="table table-bordered table-hover">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Contacts</th>
                                                                        <th>Location</th>
                                                                        <th>Mobile</th>
                                                                        <th>Email</th>

                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>

                                                            <tr>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblContacts" Text='<%#Eval("Contacts") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="Label5" Text='<%#Eval("Locations") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="Label6" Text='<%#Eval("ContMobile") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="Label7" Text='<%#Eval("ContEmail") %>'></asp:Label></td>

                                                            </tr>

                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody>
                                            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnDupeMobile" runat="server" data-dismiss="modal" CssClass="btn btn-primary" Text="Dupe" CausesValidation="false" OnClick="btnDupeMobile_Click" />
                                        <asp:Button ID="btnNotDupeMobile" runat="server" data-dismiss="modal" CssClass="btn btn-primary" Text="Not Dupe" CausesValidation="false" OnClick="btnNotDupeMobile_Click" />

                                    </div>
                                </div>
                                <!-- /.modal-content -->
                            </div>
                            <!-- /.modal-dialog -->
                        </div>
                        <!-- /.modal -->
                    </div>

                                      <div class="col-md-12">
                        <div id="PhoneDupCheck" runat="server" clientidmode="Static" class="modal fade">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">

                                        <h4 class="modal-title"><b>There is a Customer in the database already who has this phone number. This
                                           <%-- <br />--%>
                                            looks like a Duplicate Entry.</b></h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="box-body table-scrollable1">

                                                    <asp:Repeater ID="rptphonedupcheck" runat="server">
                                                        <HeaderTemplate>
                                                            <table id="example2" class="table table-bordered table-hover">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Contacts</th>
                                                                        <th>Location</th>
                                                                        <th>Phone</th>
                                                                        <th>Email</th>

                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>

                                                            <tr>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblContacts" Text='<%#Eval("Contacts") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="Label5" Text='<%#Eval("Locations") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="Label6" Text='<%#Eval("ContPhone") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="Label7" Text='<%#Eval("ContEmail") %>'></asp:Label></td>

                                                            </tr>

                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody>
                                            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnDupePhone" runat="server" data-dismiss="modal" CssClass="btn btn-primary" Text="Dupe" CausesValidation="false" OnClick="btnDupePhone_Click" />
                                        <asp:Button ID="btnNoteDupePhone" runat="server" data-dismiss="modal" CssClass="btn btn-primary" Text="Not Dupe" CausesValidation="false" OnClick="btnNoteDupePhone_Click" />

                                    </div>
                                </div>
                                <!-- /.modal-content -->
                            </div>
                            <!-- /.modal-dialog -->
                        </div>
                        <!-- /.modal -->
                    </div>

                                      <div class="col-md-12">
                        <div id="EmailDupCheck" runat="server" clientidmode="Static" class="modal fade">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">

                                        <h4 class="modal-title"><b>There is a Contact in the database already who has this email address. This
                                           <%-- <br />--%>
                                            looks like a Duplicate Entry.</b></h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="box-body table-scrollable1">

                                                    <asp:Repeater ID="rptEmailCheck" runat="server">
                                                        <HeaderTemplate>
                                                            <table id="example2" class="table table-bordered table-hover">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Contacts</th>
                                                                        <th>Location</th>
                                                                        <th>Mobile</th>
                                                                        <th>Email</th>

                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>

                                                            <tr>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblContacts" Text='<%#Eval("Contacts") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="Label5" Text='<%#Eval("Locations") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="Label6" Text='<%#Eval("ContMobile") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="Label7" Text='<%#Eval("ContEmail") %>'></asp:Label></td>

                                                            </tr>

                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody>
                                            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnDupeEmailCheck" runat="server" data-dismiss="modal" CssClass="btn btn-primary" Text="Dupe" CausesValidation="false" OnClick="btnDupeEmailCheck_Click" />
                                        <asp:Button ID="btnNotDupeEmailCheck" runat="server" data-dismiss="modal" CssClass="btn btn-primary" Text="Not Dupe" CausesValidation="false" OnClick="btnNotDupeEmailCheck_Click" />

                                    </div>
                                </div>
                                <!-- /.modal-content -->
                            </div>
                            <!-- /.modal-dialog -->
                        </div>
                        <!-- /.modal -->
                    </div>
                                 </div>
                                  </div>
                                
                            </div>
                          </div>
                          <div class="tab-pane" id="tabaddproject" runat="server" clientidmode="static">
                               <div class="row">
                                     <div class="col-md-12">
                                 <div class="box box-primary">
                                     <div class="box-body">
                                <div class="panel panel-default">
                                    <div class="form-horizontal">
                                        <div class="box-body">
                                            <div class="form-group">
                                                <div class="col-md-4">
                                                      <asp:HiddenField ID="hdnlblCustomerID" runat="server" />
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
                                          <div class="box box-primary">
                                                <div class="box-header">

                                    <div class="col-md-6 pull-right">

                                        <div class="input-group input-group-sm">
                                            <asp:TextBox ID="txtSearch1" ClientIDMode="Static" runat="server" placeholder="search keyword" class="form-control"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <asp:Button ID="btnSeaarch1" runat="server" class="btn btn-info btn-flat" Text="Search" />
                                                <asp:Button ID="btnClear1" runat="server" class="btn btn-default" Text="Clear" />
                                            </span>
                                        </div>
                                    </div>


                                </div>
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

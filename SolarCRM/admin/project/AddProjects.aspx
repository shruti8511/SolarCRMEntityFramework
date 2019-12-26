<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AddProjects.aspx.cs" Inherits="SolarCRM.admin.project.AddProjects" %>

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
            </div>


            <section class="content">
                <div class="row" id="divcompanylist" runat="server">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header">
                                <div class="form-group">
                                    <br />
                                    <br />
                                    <label class="col-md-3 control-label">Project Type</label>
                                    <div class="col-md-3">
                                        <label class="col-md-1 control-label"></label>
                                        <div class="col-sm-9">
                                            <asp:CheckBox ID="ChkPotential" runat="server" Checked="true" OnCheckedChanged="ChkPotential_CheckedChanged" AutoPostBack="true" Text="Potential" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="col-md-1 control-label"></label>
                                        <div class="col-sm-9">
                                            <asp:CheckBox ID="chkHot" runat="server" OnCheckedChanged="chkHot_CheckedChanged" AutoPostBack="true" Text="Hot" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="col-md-1 control-label"></label>
                                        <div class="col-sm-9">
                                            <asp:CheckBox ID="chkCold" runat="server" OnCheckedChanged="chkCold_CheckedChanged" AutoPostBack="true" Text="Cold" />
                                        </div>

                                    </div>
                                    <div class="col-md-6 pull-right">
                                        <div class="input-group input-group-sm">
                                            <span class="input-group-btn" style="text-align: right">
                                                <asp:Button ID="btnAddNewProject" runat="server" class="btn btn-info btn-flat" Text="Add Project" OnClick="btnAddNewProject_Click" />
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Select Company <span class="red">*</span> </label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlCompany" runat="server" CssClass="form-control select2" Style="width: 100%;"
                                            AppendDataBoundItems="true">
                                            <asp:ListItem Value="">Select</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvddlCompany" runat="server" ErrorMessage="* Required"
                                            ControlToValidate="ddlCompany" Display="Dynamic" ValidationGroup="selectcompany"></asp:RequiredFieldValidator>
                                    </div>
                                </div>



                            </div>
                        </div>
                    </div>
                </div>

                <div class="row" id="divcompanydetails" runat="server" visible="false" clintidmode="static">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <asp:HiddenField ID="hdnlblCustomerID" runat="server" />
                            <div id="DivAddNewProject" runat="server" clientidmode="static">
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

                        </div>
                        <!-- /.box-header -->


                    </div>

                </div>

                <div class="row" id="divsalesinput" runat="server" visible="false" clintidmode="static">
                    <div class="col-md-12">
                        <div class="box box-primary">
                             <div id="Div1" runat="server" clientidmode="static">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Project Sales Input</h3>
                                </div>
                                   <div class="form-horizontal">
                                                    <div class="box-body">

                                                        <div class="panel-group" id="accordionsalesip" role="tablist" aria-multiselectable="true">

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingprojdetail">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionsalesip" href="#collapseprojdetail" aria-expanded="false" aria-controls="collapseprojdetail">Project Detail
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapseprojdetail" class="panel-collapse in" role="tabpanel" aria-labelledby="headingprojdetail">
                                                                    <div class="panel-body">

                                                                        <div class="form-group">

                                                                            <div class="col-md-3">
                                                                                <label>Project Type</label>
                                                                                <asp:DropDownList ID="ddlProjectType" runat="server" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <%-- <asp:TextBox ID="TextBox13" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                                                            </div>

                                                                            <div class="col-md-3">
                                                                                <label>Project Mgr</label>
                                                                                <asp:DropDownList ID="ddlProjectMgr" runat="server" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>

                                                                            </div>

                                                                            <div class="col-md-3">
                                                                                <label>Sales Rep.</label>
                                                                                <asp:DropDownList ID="ddlSalesRep" runat="server" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>

                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label>Project Opened</label>
                                                                                <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control"></asp:TextBox>

                                                                            </div>

                                                                        </div>

                                                                        <div class="form-group">

                                                                            <div class="col-md-3">
                                                                                <label>FollowUp Date</label>
                                                                                <div class="input-group date">
                                                                                    <div class="input-group-addon">
                                                                                        <i class="fa fa-calendar"></i>
                                                                                    </div>
                                                                                    <asp:TextBox ID="txtFollowUpDate" class="form-control pull-right datepicker" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="col-md-3">
                                                                                <label>Lead Gen</label>
                                                                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>

                                                                            </div>

                                                                            <div class="col-md-3">
                                                                                <label>Contact</label>
                                                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>

                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label>Manual Quote No.</label>
                                                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>

                                                                            </div>

                                                                        </div>

                                                                        <div class="form-group">

                                                                            <div class="col-md-4">
                                                                                <label>FollowUp</label>
                                                                                <asp:TextBox ID="txtFollowUpNote" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>

                                                                            </div>

                                                                        </div>

                                                                    </div>

                                                                </div>

                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingsalesipproduct">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionsalesip" href="#collapsesalesipproduct" aria-expanded="false" aria-controls="collapsesalesipproduct">Product
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsesalesipproduct" class="panel-collapse in" role="tabpanel" aria-labelledby="headingsalesipproduct">
                                                                    <div class="panel-body">

                                                                        <div class="form-group">


                                                                            <div class="col-md-3">
                                                                                <label>Panel</label>
                                                                                <asp:DropDownList ID="ddlPanel" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>


                                                                            <div class="col-md-1" style="padding: 24px 12px; font-size: 17px">
                                                                                <label></label>
                                                                                <asp:Label runat="server" ID="multiply" Text="X"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-1">
                                                                                <label></label>
                                                                                <asp:TextBox ID="txtNoOfPanels" runat="server" CssClass="form-control" OnTextChanged="txtNoOfPanels_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-md-1">
                                                                                <label></label>
                                                                                <asp:TextBox ID="txtSystemCapacity" runat="server" CssClass="form-control"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-md-1" style="padding: 24px 12px; font-size: 17px">
                                                                                <label></label>
                                                                                <asp:Label runat="server" ID="Label5" Text="KW"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>Inv1</label>
                                                                                <asp:DropDownList ID="ddlInverter1" runat="server" CssClass="form-control select2" TabIndex="10" Style="width: 100%;" OnSelectedIndexChanged="ddlInverter1_SelectedIndexChanged" AutoPostBack="true">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label>Inv2</label>
                                                                                <asp:DropDownList ID="ddlInverter2" runat="server" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>


                                                                        </div>

                                                                        <div class="form-group">

                                                                            <div class="col-md-12">

                                                                                <div class="form-group">
                                                                                    <label class="col-sm-1">Model </label>
                                                                                    <div class="col-sm-2">
                                                                                        <asp:TextBox ID="txtInverterModel" class="form-control" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                    <label class="col-sm-1">Inv Cert </label>
                                                                                    <div class="col-sm-2">
                                                                                        <asp:TextBox ID="txtInverterCert1" class="form-control" runat="server"></asp:TextBox>
                                                                                    </div>

                                                                                    <div class="col-sm-2">
                                                                                        <asp:TextBox ID="txtPerKWCost" class="form-control" runat="server" OnTextChanged="txtPerKWCost_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                    </div>

                                                                                </div>

                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingsystemcosting">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionsalesip" href="#collapsesystemcosting" aria-expanded="false" aria-controls="collapsesystemcosting">System Costing
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsesystemcosting" class="panel-collapse in" role="tabpanel" aria-labelledby="headingsystemcosting">
                                                                    <div class="panel-body">
                                                                        <div class="col-md-6">

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Base System Cost </label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtBasicSystemCost" class="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">
                                                                                    <asp:DropDownList ID="ddlHouseType" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtHouseType" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">
                                                                                    <asp:DropDownList ID="ddlRoofType" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtRoofType" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">
                                                                                    <asp:DropDownList ID="ddlRoofAngle" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtRoofAngle" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">
                                                                                    <asp:DropDownList ID="ddlMeterinst" runat="server" CssClass="form-control select2"
                                                                                        AppendDataBoundItems="true" TabIndex="12">
                                                                                        <asp:ListItem Value="">Meter Installation</asp:ListItem>
                                                                                        <asp:ListItem Value="1">YES</asp:ListItem>
                                                                                        <asp:ListItem Value="2">NO</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtMeterinst" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <%-- <div class="form-group">
                                                                                <label class="col-sm-6">
                                                                                    <asp:DropDownList ID="ddlOther1" runat="server" CssClass="form-control select2"
                                                                                        AppendDataBoundItems="true" TabIndex="12">
                                                                                        <asp:ListItem Value="">Other1</asp:ListItem>
                                                                                        <asp:ListItem Value="5">Asbestos</asp:ListItem>
                                                                                        <asp:ListItem Value="1">Meter Upgrade</asp:ListItem>
                                                                                        <asp:ListItem Value="2">Cherry Picker</asp:ListItem>
                                                                                        <asp:ListItem Value="3">Travel Cost</asp:ListItem>
                                                                                        <asp:ListItem Value="4">Other</asp:ListItem>
                                                                                        <asp:ListItem Value="6">Meter Isolator</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtOtherCost" class="form-control" runat="server" OnTextChanged="txtOtherCost_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                </div>
                                                                            </div>--%>


                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Other Charges</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtOtherCost" class="form-control" runat="server" OnTextChanged="txtOtherCost_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                </div>
                                                                            </div>


                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">GST</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtGST" class="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                                                </div>
                                                                            </div>



                                                                        </div>

                                                                        <div class="col-md-6">

                                                                            <%--  <div class="form-group">
                                                                                <label class="col-sm-6">Other Charges</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtOtherCharges" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>--%>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Special Discount</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtSpecialDiscount" class="form-control" runat="server" OnTextChanged="txtSpecialDiscount_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Total Cost</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtTotalCost" class="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Deposit Require</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtDepositRequired" class="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Balance To Pay</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtBaltoPay" class="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Payment Plan</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="TextBox144" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingmeterdetails">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionsalesip" href="#collapsemeterdetails" aria-expanded="false" aria-controls="collapsemeterdetails">Meter Details
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsemeterdetails" class="panel-collapse in" role="tabpanel" aria-labelledby="headingmeterdetails">
                                                                    <div class="panel-body">

                                                                        <div class="col-md-6">

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Meter Phase 1-2-3 </label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtMeterPhase" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Is System Off-Peak</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:CheckBox ID="chkOffPeak" runat="server"></asp:CheckBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Enough Meter Space</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:CheckBox ID="chkMeterEnoughSpace" runat="server"></asp:CheckBox>

                                                                                </div>
                                                                            </div>

                                                                            <%--  <div class="form-group">
                                                                                <label class="col-sm-6">NMI / Acc No</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="TextBox146" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>--%>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Peak Meter No</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtPeakMeterNumber" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                        </div>

                                                                        <div class="col-md-6">

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Off-Peak Meter No</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtMeterNumber" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Distributor</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:DropDownList ID="ddlElecDistributor" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">Retailer</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:DropDownList ID="ddlElecRetailer" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-6">STC Number</label>
                                                                                <div class="col-sm-6">
                                                                                    <asp:TextBox ID="txtSTCNumber" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingfreebies">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionsalesip" href="#collapsefreebies" aria-expanded="false" aria-controls="collapsefreebies">Freebies / Promo Items
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsefreebies" class="panel-collapse in" role="tabpanel" aria-labelledby="headingfreebies">
                                                                    <div class="panel-body">

                                                                        <div class="col-md-6">

                                                                            <div class="form-group">
                                                                                <label class="col-sm-4">Promo 1 </label>
                                                                                <div class="col-sm-8">
                                                                                    <asp:DropDownList ID="ddlPromoOffer" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-4">Promo 2 </label>
                                                                                <div class="col-sm-8">
                                                                                    <asp:DropDownList ID="ddlPromoOffer2" runat="server" AppendDataBoundItems="true" CssClass="form-control select2" TabIndex="10" Style="width: 100%;">
                                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-4">Quotation Notes </label>
                                                                                <div class="col-sm-8">
                                                                                    <asp:TextBox ID="txtQuotationNotes" class="form-control" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-4">First QuoteSent </label>
                                                                                <div class="col-sm-8">
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtQuoteSent" class="form-control pull-right datepicker" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                            </div>


                                                                        </div>

                                                                        <div class="col-md-6">

                                                                            <div class="form-group">
                                                                                <label class="col-sm-4">Quote Accepted </label>
                                                                                <div class="col-sm-8">
                                                                                    <div class="input-group date">
                                                                                        <div class="input-group-addon">
                                                                                            <i class="fa fa-calendar"></i>
                                                                                        </div>
                                                                                        <asp:TextBox ID="txtQuoteAccepted" class="form-control pull-right datepicker" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-4">Sign Quote Stored</label>
                                                                                <div class="col-sm-8">
                                                                                    <asp:CheckBox runat="server" ID="chkSignedQuote" />
                                                                                    <asp:FileUpload runat="server" ID="FileUpload4" />
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-4">Project Notes </label>
                                                                                <div class="col-sm-8">
                                                                                    <asp:TextBox ID="TextBox2" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-4">Quotes </label>
                                                                                <div class="col-sm-8">

                                                                                    <asp:ImageButton ID="btnCreateQuotes" runat="server" ImageUrl="../../Content/img/btn_create_new_quote.png"
                                                                                        OnClick="btnCreateQuotes_Click" CausesValidation="false" />

                                                                                </div>
                                                                            </div>



                                                                            <div class="box">
                                                                                <div class="box-header">
                                                                                    <h3 class="box-title">
                                                                                    Quotes
                                                                                </div>
                                                                                <!-- /.box-header -->
                                                                                <div class="box-body table-scrollable1">
                                                                                    <asp:Repeater ID="rptQuote" runat="server" OnItemDataBound="rptQuote_ItemDataBound">
                                                                                        <HeaderTemplate>
                                                                                            <table id="Table1" class="table table-bordered table-hover">
                                                                                                <thead>
                                                                                                    <tr>
                                                                                                        <th>Quote Date</th>
                                                                                                        <th>Doc No.</th>
                                                                                                        <th>Document</th>

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

                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingdocument">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionsalesip" href="#collapsedocument" aria-expanded="false" aria-controls="collapsedocument">Documents
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsedocument" class="panel-collapse in" role="tabpanel" aria-labelledby="headingdocument">
                                                                    <div class="panel-body">

                                                                        <div class="form-group">
                                                                            <div class="col-md-3">
                                                                                <label>Meter Photo</label>
                                                                                <asp:CheckBox ID="chkMeterBoxPhotosSaved" runat="server"></asp:CheckBox>

                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label>Electricity Bill</label>
                                                                                <asp:CheckBox ID="chkElecBillSaved" runat="server"></asp:CheckBox>

                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label>Site Map</label>
                                                                                <asp:CheckBox ID="chkSiteMap" runat="server"></asp:CheckBox>

                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label>Payment Receipt</label>
                                                                                <asp:CheckBox ID="chkPaymentReceipt" runat="server"></asp:CheckBox>

                                                                            </div>
                                                                        </div>

                                                                        <div class="form-group">
                                                                            <div class="col-md-3">
                                                                                <label>Meter Approval</label>
                                                                                <asp:CheckBox ID="chkMeterApproval" runat="server"></asp:CheckBox>

                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label>Other Documents</label>
                                                                                <asp:FileUpload ID="FLUPDocuments" runat="server"></asp:FileUpload>

                                                                            </div>

                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>


                                                        </div>

                                                    </div>

                                                    <div class="box-footer">
                                                        <asp:Button ID="btnCancelSalesInout" runat="server" TabIndex="20" CssClass="btn btn-default" Text="Cancel" />
                                                        <asp:Button ID="btnSaveSalesInput" runat="server" TabIndex="21" CssClass="btn btn-info pull-right" Text="Save" OnClick="btnSaveSalesInput_Click" />
                                                    </div>

                                                </div>
                            </div>
                            
                        </div>
                    </div>
                    <!-- /.box-body -->
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

    </asp:UpdatePanel>
</asp:Content>

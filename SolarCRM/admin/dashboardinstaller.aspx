<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="dashboardinstaller.aspx.cs" Inherits="SolarCRM.admin.dashboardinstaller" %>
<%@ Register Src="~/PagingUserControl/PagingUserControl.ascx" TagPrefix="uc1" TagName="page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <section class="content-header">
        <h1>Dashboard
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        </ol>
    </section>

    <section class="content">
          <div class="box box-default">
            <div class="box-header with-border">
              <h3 class="box-title">Projects</h3>

              <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <div class="row">
                <div class="col-md-8">
                    <div class="nav-tabs-custom">
                        <!-- Horizontal Form -->
                                <div class="box-body chart-responsive">
                                    <div class="chart" id="projects-chart" style="height: 300px; position: relative;"></div>
                                </div>
                    </div>
                  <!-- ./chart-responsive -->
                </div>
                <!-- /.col -->
                 
                 <div class="col-md-4">
                  <ul class="chart-legend clearfix">
                     <li><i class="fa fa-circle-o" style="color:#00a65a;"></i>Pending</li>
                    <li><i class="fa fa-circle-o" style="color:#FBBA00;"></i> Completed</li>
                  </ul>
                </div>
                     
                <!-- /.col -->
              </div>
              <!-- /.row -->
            </div>
          
          </div>
     

            <div class="row" id="divprojectlist" runat="server">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header">
                                <div class="col-md-6 pull-left">
                                   <h4> Installer Pending Projects</h4>
                                    </div>
                                <div class="col-md-6 pull-right">

                                    <div class="input-group input-group-sm">
                                        <asp:TextBox ID="txtSearch" ClientIDMode="Static" runat="server" placeholder="search keyword" class="form-control"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-info btn-flat" Text="Search" OnClientClick="return validate()" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btnClear" runat="server" class="btn btn-default" Text="Clear" OnClick="btnClear_Click" />
                                        </span>
                                    </div>
                                </div>


                            </div>
                            <!-- /.box-header -->
                            <div class="box-body table-scrollable1">
                                <asp:Repeater ID="rptProjectlist" runat="server" OnItemCommand="rptProjectlist_ItemCommand" OnItemDataBound="rptProjectlist_ItemDataBound">
                                    <HeaderTemplate>
                                        <table id="example2" class="table table-bordered table-hover">
                                            <thead>
                                                <tr>
                                                    <th>Project No.</th>
                                                    <th>Man#</th>
                                                    <th>Project Type</th>
                                                    <th>Project Status</th>
                                                    <th>Customer</th>
                                                    <th>Contact</th>
                                                    <th>Project Opened</th>
                                                    <th>Location</th>
                                                    <th>Area</th>
                                                    <th>City</th>
                                                    <th>State</th>
                                                    <th>Installer Notes</th>
                                                 <%--   <th>Updated By</th>--%>
                                                    <th>Detail</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>

                                        <tr>
                                            <td>
                                                <asp:HiddenField ID="hdnProjectId" runat="server" Value='<%#Eval("ProjectID") %>' />

                                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("ProjectNumber") %>'></asp:Label></td>

                                            <td>
                                                <asp:Label ID="lblMan" runat="server" Text='<%#Eval("ManualQuoteNumber") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblProjectType" runat="server" Text='<%#Eval("ProjectType") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblProjectStatus" runat="server" Text='<%#Eval("ProjectStatus") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblCustomer" runat="server" Text='<%#Eval("CustomerName") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblContact" runat="server" Text='<%#Eval("ContactNO") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblProjectOpened" runat="server" Text='<%#Eval("ProjectOpened", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("Location") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblArea" runat="server" Text='<%#Eval("InstallArea") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblCity" runat="server" Text='<%#Eval("InstallCity") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblState" runat="server" Text='<%#Eval("InstallState") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblInstallerNotes" runat="server" Text='<%#Eval("InstallerNotes") %>'></asp:Label></td>
                                          <%--  <td>
                                                <asp:Label ID="lblUpdatedby" runat="server" Text='<%#Eval("UpdateBy") %>'></asp:Label></td>
                                          --%>  <td class="text-center">
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
                                    <uc1:page ID="pageGrid" runat="server" Visible="true" OnPagerChanged="Pager_Changed" />
                                </div>
                            </div>
                            <!-- /.box-body -->
                        </div>

                    </div>
                    <!-- /.col -->
                </div>

            <div id="divprojectdetails" runat="server" visible="false" clintidmode="static">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="box box-info">

                                <div class="box-header">
                                    <h4>Installer Pending Projects</h4>
                                </div>

                                <div class="box-body">

                                    <div class="nav-tabs-custom" >
                                        <ul class="nav nav-tabs" >
                                           <li id="lidcms" class ="active"><a href="#dcms" data-toggle="tab">Documents</a></li>
                                            <li id="licnvs"><a href="#cnvs" data-toggle="tab">Conversation</a></li>
                                      
                                        </ul>
                                        <div class="tab-content">
                                            <div class="tab-pane active" id="dcms" >

                                                <div class="form-horizontal">
                                                    <div class="box-body">

                                                        <div class="panel-group" id="accordiondcmnts" role="tablist" aria-multiselectable="true">

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headingdownloaddoc">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordiondcmnts" href="#collapsedownloaddoc" aria-expanded="false" aria-controls="collapsedownloaddoc">Download Documnets
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapsedownloaddoc" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingdownloaddoc">
                                                                    <div class="panel-body">

                                                                        <div class="form-group">
                                                                            <div class="col-md-4">
                                                                                <div class="col-sm-12">
                                                                                    <label>Invoice</label><br />
                                                                                    <a href="#"><i class="fa fa-file-pdf-o"></i>Open Invoice</a>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Quotation</label><br />
                                                                                    <a href="#"><i class="fa fa-file-pdf-o"></i>Open Quotation</a>

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Meter Approval</label><br />
                                                                                    <%-- <a href="#"><i class="fa fa-file-pdf-o"></i> Open Invoice</a>--%>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="col-sm-12">
                                                                                    <label>New Model Panel?</label><br />
                                                                                    <asp:CheckBox runat="server" ID="chknewmodelpanel" />

                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>New Model Inv?</label><br />
                                                                                    <asp:CheckBox runat="server" ID="CheckBox25" />

                                                                                </div>

                                                                                <div class="col-sm-12">
                                                                                    <label>Pick List</label><br />
                                                                                    <a href="#"><i class="fa fa-hand-o-up"></i>Pick List</a>

                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="col-sm-12">
                                                                                    <label>Meter Photo</label>
                                                                                    <%--<a href="#"><i class="fa fa-file-pdf-o"></i> Open Invoice</a>--%>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>Prop Design</label>
                                                                                    <%--<a href="#"><i class="fa fa-file-pdf-o"></i> Open Quotation</a>--%>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label>SQ Document</label>
                                                                                    <%-- <a href="#"><i class="fa fa-file-pdf-o"></i> Open Invoice</a>--%>
                                                                                </div>

                                                                            </div>
                                                                        </div>

                                                                    </div>

                                                                </div>

                                                            </div>

                                                            <div class="panel panel-default box box-info">
                                                                <div class="box-header with-border" role="tab" id="headinguploaddoc">
                                                                    <h4 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordiondcmnts" href="#collapseuploaddoc" aria-expanded="false" aria-controls="collapseuploaddoc">Upload Documents
                                                                        </a>
                                                                    </h4>
                                                                </div>
                                                                <div id="collapseuploaddoc" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headinguploaddoc">
                                                                    <div class="panel-body">
                                                                        <div class="form-group">
                                                                            <div class="col-md-4">
                                                                                <div class="col-sm-12">
                                                                                    <label>Signed Paperwork </label>
                                                                                    <asp:CheckBox runat="server" ID="CheckBox24" Checked="true" />
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label><a href="#">signed123.pdf</a></label>
                                                                                    <asp:FileUpload runat="server" ID="FileUpload7" />

                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="col-sm-12">
                                                                                    <label>Invoice Doc </label>
                                                                                    <asp:CheckBox runat="server" ID="CheckBox26" Checked="true" />
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label><a href="#">123invdoc.pdf</a></label>
                                                                                    <asp:FileUpload runat="server" ID="FileUpload8" />

                                                                                </div>

                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="col-sm-12">
                                                                                    <label>Other Documents </label>
                                                                                    <asp:CheckBox runat="server" ID="CheckBox27" Checked="true" />
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <label><a href="#">123impdoc.pdf</a></label>
                                                                                    <asp:FileUpload runat="server" ID="FileUpload9" />

                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                </div>

                                                            </div>

                                                        </div>

                                                    </div>
                                                    <!-- /.box-body -->
                                                    <div class="box-footer">
                                                        <asp:Button ID="Button5" runat="server" TabIndex="23" ToolTip="Reset Details" CssClass="btn btn-default" Text="Cancel" />
                                                        <asp:Button ID="Button6" runat="server" TabIndex="24" ToolTip="Add Priority" CssClass="btn btn-info pull-right" Text="Add" />
                                                    </div>
                                                    <!-- /.box-footer -->

                                                </div>
                                            </div>

                                            <div class="tab-pane" id="cnvs" >
                                                <div class="form-horizontal">
                                                    <div class="box-body">
                                                        <div class="form-group">
                                                            <div class="col-md-6">
                                                                <div class="col-sm-12">
                                                                    <label>Note : *</label>
                                                                    <asp:TextBox runat="server" ID="txtNotes" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Project Notes :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox3" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Notes for Installation Department :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox4" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Meter Notes :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox22" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Notes For Installer :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox23" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label style="color: red">Notes from Installer :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox24" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="col-sm-12">
                                                                    <label>Rex Notes :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox25" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Quotation Notes :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox26" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Finance Notes :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox27" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Invoice Notes :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox28" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>STC Notes :</label>
                                                                    <asp:TextBox runat="server" ID="TextBox29" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Freebies1 Comment:</label>

                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <label>Freebies2 Comment:</label>

                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->
                                                    <div class="box-footer">
                                                        <asp:Button ID="Button7" runat="server" TabIndex="23" ToolTip="Reset Details" CssClass="btn btn-default" Text="Cancel" />
                                                        <asp:Button ID="Button8" runat="server" TabIndex="24" ToolTip="Add Priority" CssClass="btn btn-info pull-right" Text="Add" />
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
                </div>
   


    </section>

    <script src="<%=SiteURL%>/plugins/jQuery/jQuery-2.2.0.min.js"></script>
    <script>
        $(function () {
            debugger;
            var Completed = "";
            var Pending = "";
            var Total = "";
            $.ajax({
                type: 'POST',
                url: 'dashboardinstaller.aspx/GetPiechartData',
                data: {},
                dataType: 'json',
                async: false,
                contentType: "application/json; charset=utf-8",

                success: function (data) {
                    // data = result.d;

                    "use strict";
                    Completed = data.d.Complete;
                    Pending = data.d.OnHold;
                    Total = data.d.Total;
                    //DONUT CHART
                    var donut = new Morris.Donut({
                        element: 'projects-chart',
                        resize: true,
                        colors: ["#00a65a", "#FBBA00"],
                        data: [
                           { label: "Pending", value: Pending },
                           { label: "Completed", value: Completed },
                        ],
                        hideHover: 'auto'
                    });

                    // set lbltotal = total
                  
                },
                error: function (xhr, status, error) {
                    alert(error);
                }
            });

        });


    </script>
</asp:Content>

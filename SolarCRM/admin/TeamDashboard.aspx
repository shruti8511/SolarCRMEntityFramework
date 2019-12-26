<%@ Page Title="" Language="C#" MasterPageFile="~/admin/SiteMaster.Master" AutoEventWireup="true" CodeBehind="TeamDashboard.aspx.cs" Inherits="SolarCRM.TeamDashboard" %>

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

        <div class="panel panel-default box box-info">
            <div class="box-header with-border" role="tab" id="timelineexpense">
                <h4 class="panel-title">
                    <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordionExpen" href="#collapsetimeline" aria-expanded="false" aria-controls="collapsetimeline">Projects
                    </a>
                </h4>
            </div>
            <div id="collapsetimeline" class="panel-collapse in" role="tabpanel" aria-labelledby="headingexpense">
                <div class="box-body table-scrollable">

                    <div class="panel-body">

                        <div class="form-group">
                            <!-- row -->
                            <div class="row">
                                <div class="col-md-12">
                                    <!-- The time line -->
                                    <ul class="timeline">
                                        <asp:Repeater ID="rptTaskList" runat="server" OnItemCommand="rptTaskList_ItemCommand" OnItemDataBound="rptTaskList_ItemDataBound">
                                            <ItemTemplate>
                                                <li style="float:left; border:1px solid #3c8dbc; border-radius:7px; height:200px;width:32%">
                                                   
                                                     <span>
                                                       
                                                          <div style="padding:5px;">
                                                         <b><h4 style="color:#0fa2da; font-weight:bold;"> <%#Eval("CustomerName") %></h4>
                                                           <h5 style="color:orange; font-weight:bold;"> <%#Eval("ProjectType") %> </h5>
                                                           Address: </b> <%#Eval("InstallAddress") %> , <%#Eval("InstallArea") %> <br />
                                                                    <%#Eval("InstallCity") %> , <%#Eval("InstallState") %><br />
                                                            <b>Notes: </b> <%#Eval("InstallerNotes") %>  <br />

                                                           Task:<%#Eval("Task") %> 
                                                        
                                                        <!-- /.info-box-content --><br />
                                                              <div class="pull-right" style="padding-top:30px; text-align:center;">
                                                    <asp:LinkButton ID="lnkDetail" runat="server" ToolTip="Assign" CommandName="Assign" 
                                                        CommandArgument='<%# Eval("ProjectID") %>' ForeColor="White" text-align="center" BackColor="#0FA2DA" Height="20px" Width="60px">Assign</>
                                                    </asp:LinkButton>
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
                                <!-- /.col -->
                            </div>
                        </div>


                    </div>

                </div>
            </div>

        </div>


    </section>
</asp:Content>

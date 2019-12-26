<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="headerprofile.ascx.cs" Inherits="SolarCRM.admin.includes.headerprofile" %>

<li class="dropdown user user-menu">
    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
        <%--<img src="../Content/img/user2-160x160.jpg" class="user-image" alt="User Image">--%>
        <span class="hidden-xs">
            <asp:Label ID="lblusername" runat="server"></asp:Label></span>
    </a>
    <ul class="dropdown-menu">

        <li class="user-header">
            <img src="../../Content/img/user2-160x160.jpg" class="img-circle" alt="User Image">
            <p>
                <asp:Label ID="lblusername1" runat="server"></asp:Label>
            </p>
        </li>

        <li class="user-footer">
            <div class="pull-left">
                <a href="#" class="btn btn-default btn-flat">Profile</a>
            </div>
            <div class="pull-right">
                 <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="Log out" CssClass="btn btn-default btn-flat"
                OnLoggedOut="LoginStatus1_LoggedOut" LogoutAction="Redirect" />
            </div>
        </li>
    </ul>
</li>


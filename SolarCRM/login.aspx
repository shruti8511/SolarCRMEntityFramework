<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SolarCRM.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <title>SolarCRM | Log in</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
    <!-- Bootstrap 3.3.6 -->
    <link rel="stylesheet" href="../bootstrap/css/bootstrap.min.css"/>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css"/>
    <!-- Theme style -->
    <link rel="stylesheet" href="../Content/css/AdminLTE.min.css"/>
    <!-- iCheck -->
    <link rel="stylesheet" href="../plugins/iCheck/square/blue.css"/>
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server" enctype="multipart/form-data">
        <asp:Panel ID="PanError" runat="server" CssClass="failure" Visible="false">
            <i class="icon-remove-sign"></i>
            <asp:Label ID="lblError" runat="server" Text="Your login session has been expired. Please contact your Administrartor."></asp:Label>
        </asp:Panel>

        <asp:Login ID="login1" runat="server" DestinationPageUrl="~/admin/dashboard.aspx"
            OnLoggedIn="Login1_LoggedIn" DisplayRememberMe="true" Width="100%">
            <LayoutTemplate>
                <asp:Panel ID="pan" runat="server" DefaultButton="LoginButton">
                    <div class="login-box">
                        <div class="login-logo">
                           <%-- <a href="#"><b>Solar</b> CRM</a>
                              <img src="../../content/img/logo_new.png" alt="brunchy" style="height:100px;width:150px;" />--%>
                             <img src="../../content/img/logo_new.png"/>
                        </div>
                        <!-- /.login-logo -->

                        <div class="login-box-body">
                            <p class="login-box-msg">Login to start your session</p>

                             <div class="form-group has-feedback" style="color:red">
                               <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </div>

                            <div class="form-group has-feedback">
                                <asp:TextBox ID="UserName" runat="server" class="form-control" placeholder="Email"></asp:TextBox>                               
                                <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                            </div>
                            <div class="form-group has-feedback">
                                <asp:TextBox ID="Password" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>                              
                                <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                            </div>
                            <div class="row">
                                <div class="col-xs-8">

                                    <div class="checkbox icheck">
                                        <label>
                                            <asp:CheckBox ID="RememberMe" runat="server" /> Remember Me
                                 
                                        </label>
                                    </div>
                                </div>
                              
                                <div class="col-xs-4">
                                    <%--<button type="submit" class="btn btn-primary btn-block btn-flat">Sign In</button>--%>
                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" class="btn btn-primary btn-block btn-flat"
                                        Text="Login" ValidationGroup="Login1" OnClientClick="return confirm('It will Logout you from other devices and browsers, Are you sure to Login and Continue?')" />
                                </div>
                               
                            </div>


                            <!-- /.social-auth-links -->
                            <%--  <a href="#">I forgot my password</a><br>
               <a href="register.html" class="text-center">Register a new membership</a>--%>
                        </div>

                        <!-- /.login-box-body -->
                    </div>
                </asp:Panel>
            </LayoutTemplate>
        </asp:Login>
       
    </form>

    <!-- /.login-box -->
   <%--  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>--%>
    <!-- jQuery 2.2.0 -->
    <script src="../plugins/jQuery/jQuery-2.2.0.min.js"></script>
    <!-- Bootstrap 3.3.6 -->
    <script src="../bootstrap/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="../plugins/iCheck/icheck.min.js"></script>

    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
    </script>
</body>
</html>

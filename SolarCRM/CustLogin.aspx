<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustLogin.aspx.cs" Inherits="SolarCRM.CustLogin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html lang="en" >

<head runat="server">
    <script src="../bootstrap/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../bootstrap/js/Float.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".Validators").Float();
        });
    </script>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Karmanta - Bootstrap 3 Responsive Admin Template">
    <meta name="author" content="GeeksLabs">
    <meta name="keyword" content="Karmanta, Dashboard, Admin, Template, Theme, Bootstrap, Responsive, Retina, Minimal">
    <link rel="shortcut icon" href="img/favicon.png">

    <%--<title>Login Page 2 | Karmanta - Bootstrap 3 Responsive Admin Template</title>--%>
      <link rel="stylesheet" href="../bootstrap/css/bootstrap.min.css"/>
    <!-- Bootstrap CSS -->
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- bootstrap theme -->
    <link href="../bootstrap/css/bootstrap-theme.css" rel="stylesheet">
    <!--external css-->
    <!-- font icon -->
    <link href="../bootstrap/css/elegant-icons-style.css" rel="stylesheet" />
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <!-- Custom styles -->
    <link href="../bootstrap/css/style.css" rel="stylesheet">
    <link href="../bootstrap/css/style-responsive.css" rel="stylesheet" />
</head>

<body class="login-img3-body" style="background-color:darkgrey">
     <div class="container">

        <form class="login-form" id="form1" runat="server">
            <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
            <div class="login-wrap">
                <p class="login-img"> <img src="../../content/img/logo_new.png"/></p>
                <p style="font-weight: bold; text-align: center; color: #1e73be;">Please log in to check your Solar PV system installation progress</p>
                <div class="input-group" style="margin-top: 10px;">
                    <span class="input-group-addon"><i class="icon_profile"></i></span>
                    <asp:TextBox ID="txtProjNum" CssClass="form-control" runat="server"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="twe" runat="server" TargetControlID="txtProjNum" WatermarkText="Quotation / Order No"></cc1:TextBoxWatermarkExtender>

                   
                </div>
                <span style="margin-top:3px;">
                    <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtProjNum" CssClass="Validators"
                        Display="Dynamic" style="color: red;display: inline;position: absolute;top: 369px;left: 643px;background-color: white;"  ForeColor="Red" ErrorMessage="Enter Project Number"></asp:RequiredFieldValidator>
                </span>
                <div class="input-group">
                    <span class="input-group-addon"><i class="icon_key_alt"></i></span>

                    <asp:TextBox ID="txtPCode" CssClass="form-control" runat="server"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="twe2" runat="server" TargetControlID="txtPCode" WatermarkText="Post Code"></cc1:TextBoxWatermarkExtender>

                </div>
                <span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtPCode" CssClass="Validators"
                        Display="Dynamic" style="color: red;display: inline;position: absolute;top: 369px;left: 643px;background-color: white;" ErrorMessage="Enter Post Code"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server"  ForeColor="Red" CssClass="Validators"
                        Display="Dynamic" style="color: red;display: inline;position: absolute;top: 369px;left: 643px;background-color: white;" Operator="DataTypeCheck" Type="Integer"
                        ControlToValidate="txtPCode" ErrorMessage="Value must be a whole number" /></span>
               
                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-lg btn-block loginbtn" Text="Login" OnClick="btnLogin_Click" />
                 </div>
        </form>

    </div>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title>3GB HSRP</title>

    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="" />
    <link href="../../css2?family=Montserrat:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="assets/css/vendors/font-awesome.css" />
    <!-- ico-font-->
    <link rel="stylesheet" type="text/css" href="assets/css/vendors/icofont.css" />
    <!-- Themify icon-->
    <link rel="stylesheet" type="text/css" href="assets/css/vendors/themify.css" />
    <!-- Flag icon-->
    <link rel="stylesheet" type="text/css" href="assets/css/vendors/flag-icon.css" />
    <!-- Feather icon-->
    <link rel="stylesheet" type="text/css" href="assets/css/vendors/feather-icon.css" />
    <!-- Bootstrap css-->
    <link rel="stylesheet" type="text/css" href="assets/css/vendors/bootstrap.css" />
    <!-- App css-->
    <link rel="stylesheet" type="text/css" href="assets/css/style.css" />
    <link id="color" rel="stylesheet" href="assets/css/color-1.css" media="screen" />
    <!-- Responsive css-->
    <link rel="stylesheet" type="text/css" href="assets/css/responsive.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid p-0">
                <div class="row m-0">
                    <div class="col-12 p-0">
                        <div class="login-card">
                            <div>
                                <div>
                                    <a class="logo" href="#">
                                        <h3>3GB - HSRP </h3>
                                    </a>
                                </div>
                                <div class="login-main">
                                    <div class="theme-form">
                                        <h4 class="text-center">Sign in to account</h4>
                                        <p class="text-center">Enter your User Name & Password to login</p>
                                        <div class="form-group">
                                            <label class="col-form-label">Username</label>
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="User Name"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-form-label">Password</label>
                                            <div class="form-input position-relative">
                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-form-label">Role</label>
                                            <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-select">
                                                <asp:ListItem>Dealer</asp:ListItem>
                                                <asp:ListItem>Admin</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group mb-0">


                                            <div class="text-end mt-3">
                                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                <asp:LinkButton ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-block w-100" OnClick="btnLogin_Click" />
                                            </div>
                                        </div>


                                        <%--  <p class="mt-4 mb-0 text-center">Don't have account?<a class="ms-2" href="sign-up.html">Create Account</a></p>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- latest jquery-->
                <script src="assets/js/jquery-3.6.0.min.js"></script>
                <!-- Bootstrap js-->
                <script src="assets/js/bootstrap/bootstrap.bundle.min.js"></script>
                <!-- feather icon js-->
                <script src="assets/js/icons/feather-icon/feather.min.js"></script>
                <script src="assets/js/icons/feather-icon/feather-icon.js"></script>
                <!-- scrollbar js-->
                <!-- Sidebar jquery-->
                <script src="assets/js/config.js"></script>
                <!-- Template js-->
                <script src="assets/js/script.js"></script>
                <!-- login js-->
            </div>
        </div>
    </form>
</body>
</html>

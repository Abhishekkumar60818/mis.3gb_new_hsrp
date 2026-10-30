<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="OrderBooking.aspx.cs" Inherits="seller_OrderBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .rbl input[type="radio"] {
            margin-left: 20px;
            margin-right: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scrpt" runat="server"></asp:ScriptManager>
    <link href="../css2.css" rel="stylesheet" />
    <!-- Feather icon-->

    <div class="page-wrapper compact-wrapper" id="pageWrapper">
        <div class="modal fade" id="Updatemodal">
            <div class="modal-dialog modal-lg modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="myLargeModalLabel">Error</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12 col-sm-12">
                                <div class="form-group">

                                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>

                    </div>
                </div>
            </div>
        </div>
        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Order Booking</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="default.aspx"><i data-feather="home"></i></a></li>

                                <li class="breadcrumb-item active">Order Booking</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header pb-0">

                        <div class="pd-20 bg-white border-radius-4 box-shadow mb-30">
                            <div class="clearfix">
                                <div class="pull-left">
                                    <h4 class="text-blue">Sales</h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>Vehicle No.</label>
                                        <asp:TextBox ID="txtVehicle" runat="server" CssClass="form-control" placeholder="Enter Vehicle No." required></asp:TextBox>
                                        <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtVehicle" ForeColor="Red"
                                            ValidationExpression="[a-zA-Z]{2}[a-zA-Z0-9]{0,6}[0-9]{3}$" ErrorMessage="*Valid characters: Alphabets and Numbers only, Without Space" />--%>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>Chasis No. (Last Five character)</label>
                                        <asp:TextBox ID="txtChasisNo" runat="server" CssClass="form-control" placeholder="Enter Chasis No." MaxLength="5" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>Engine No. (Last Five character)</label>
                                        <asp:TextBox ID="txtEngineNo" runat="server" CssClass="form-control" placeholder="Enter Engine No." MaxLength="5" required></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                               
                                <div class="col-md-12 col-sm-12">
                                    <div class="form-group" style="margin-top: 23px;">
                                        <asp:Label ID="lblErrormsg" runat="server" ForeColor="Red"></asp:Label>
                                        <asp:Label ID="lblVaahanDetails" runat="server" ></asp:Label>
                                        <asp:Button ID="btnVahaancheck" runat="server" CssClass="btn btn-primary" Text="Vaahan Check" OnClick="btnVahaancheck_Click"></asp:Button>
                                    </div>
                                </div>
                            </div>
                            <asp:Panel ID="pnlDetails" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-4 col-sm-12">
                                                <div class="form-group">
                                                    <label>Name</label>
                                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Name" required></asp:TextBox>
                                                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtName" ForeColor="Red"
                                                    ValidationExpression="[a-zA-Z0-9\s]*$" ErrorMessage="*Valid characters: Alphabets and Numbers Only" />--%>
                                                </div>
                                            </div>

                                            <div class="col-md-4 col-sm-12">
                                                <div class="form-group">
                                                    <label>Contact No.</label>
                                                    <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control" placeholder="Enter Contact No." MaxLength="13" type="Number"></asp:TextBox>
                                                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="red"
                                                    ControlToValidate="txtContactNo" ErrorMessage="* Enter Valid Mobile No."
                                                    ValidationExpression="[56789][0-9]{9,12}"></asp:RegularExpressionValidator>--%>
                                                </div>
                                            </div>
                                            <div class="col-md-4 col-sm-12">
                                                <div class="form-group">
                                                    <label>State</label>
                                                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem disabled="disabled" Selected="selected" Value="">Select State</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <%-- <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> --%>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">

                                            <div class="col-md-4 col-sm-12">
                                                <div class="form-group">
                                                    <label>City</label>
                                                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-select" required>
                                                        <asp:ListItem disabled="disabled" Selected="selected" Value="">Select City</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-4 col-sm-12">
                                                <div class="form-group">
                                                    <label>Vehicle Type</label>
                                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-select">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-4 col-sm-12">
                                                <div class="form-group">
                                                    <label>Fuel Type</label>
                                                    <asp:Label ID="ddlFuelType" runat="server" CssClass="form-control">
                                                    </asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="row">
                                    <div class="col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <label>Class Type</label>
                                            <asp:DropDownList ID="ddlClassType" runat="server" CssClass="form-select">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <label>Order Type</label>
                                            <asp:DropDownList ID="ddlOrderType" runat="server" CssClass="form-select">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <label>Date of Registration</label>
                                            <asp:Label ID="txtRegistrationDate" runat="server" CssClass="form-control" placeholder="Select Registration Date"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <label>Date Of Manufacture</label>
                                            <input type="month" id="txtManufactureDate" name="start" class="form-control" runat="server" />
                                            <%--<asp:TextBox ID="txtManufactureDate" runat="server" CssClass="form-control" type="Date" placeholder="Select Manufacture Date" required></asp:TextBox>--%>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <label>TLP Print</label>
                                            <asp:RadioButtonList ID="chklstTLP" runat="server" CssClass="form-control rbl" RepeatDirection="Horizontal" Width="100%">
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <label>RC Copy</label>
                                            <%--<div class="input-group control-dark">--%>
                                            <asp:FileUpload ID="upldImg" runat="server" accept=".png,.jpg,.jpeg,.PNG,.JPG,.JPEG" />
                                            <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                                                ControlToValidate="upldImg" ForeColor="Red"
                                                ErrorMessage="* Only image allowed"
                                                ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Pp][Nn][Gg])|.*\.([Jj][Pp][Ee][Gg])$)">  
                                            </asp:RegularExpressionValidator>
                                            <%--</div>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="text-align: center; margin-bottom: 15px;">


                                    <div class="col-md-12 col-sm-12">
                                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                        <asp:Button ID="btnSubmit" runat="server" Text="Book Order" CssClass="btn btn-primary lnkSave" OnClick="btnSubmit_Click" />
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

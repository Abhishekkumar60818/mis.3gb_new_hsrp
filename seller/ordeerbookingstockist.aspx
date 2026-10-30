<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="ordeerbookingstockist.aspx.cs" Inherits="seller_ordeerbookingstockist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .rbl input[type="radio"] {
            margin-left: 20px;
            margin-right: 1px;
        }

        .multiselect-container {
            min-width: 220px !important;
            max-height: 300px !important;
            overflow: scroll !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scrpt" runat="server"></asp:ScriptManager>
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
                            <h3>Booking</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="default.aspx"><i data-feather="home"></i></a></li>
                                
                                <li class="breadcrumb-item active">Booking</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header pb-0">

                        <div class="min-height-200px">
                            <div class="page-header">
                                <div class="row">
                                    <div class="col-md-12 col-sm-12">
                                        <div class="title">
                                            <%--<h4>Sales</h4>--%>
                                        </div>
                                        <nav aria-label="breadcrumb" role="navigation">
                                            <ol class="breadcrumb">
                                                <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>
                                                <li class="breadcrumb-item active" aria-current="page">Booking</li>
                                            </ol>
                                        </nav>
                                    </div>

                                </div>
                            </div>
                            <div class="pd-20 bg-white border-radius-4 box-shadow mb-30">
                                <div class="clearfix">
                                    <div class="pull-left">
                                        <h4 class="text-blue">Sales</h4>
                                        <%--<p class="mb-30 font-14">All bootstrap element classies</p>--%>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Name</label>
                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Name" required></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtName" ForeColor="Red"
                                                ValidationExpression="[a-zA-Z0-9\s]*$" ErrorMessage="*Valid characters: Alphabets and Numbers Only" />
                                        </div>
                                    </div>

                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Contact No.</label>
                                            <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>--%>
                                            <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control" placeholder="Enter Contact No." MaxLength="13" type="Number"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="red"
                                                ControlToValidate="txtContactNo" ErrorMessage="* Enter Valid Mobile No."
                                                ValidationExpression="[56789][0-9]{9,12}"></asp:RegularExpressionValidator>
                                            <%--</ContentTemplate>
                                </asp:UpdatePanel>--%>
                                        </div>
                                    </div>

                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-6 col-sm-12">
                                                <div class="form-group">
                                                    <label>State</label>
                                                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    <%-- <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> --%>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-12">
                                                <div class="form-group">
                                                    <label>City</label>
                                                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Vehicle No.</label>
                                            <asp:TextBox ID="txtVehicle" runat="server" CssClass="form-control" placeholder="Enter Vehicle No." required></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtVehicle" ForeColor="Red"
                                                ValidationExpression="[a-zA-Z]{2}[a-zA-Z0-9]{0,6}[0-9]{3}$" ErrorMessage="*Valid characters: Alphabets and Numbers only, Without Space" />
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Chasis No.</label>
                                            <asp:TextBox ID="txtChasisNo" runat="server" CssClass="form-control" placeholder="Enter Chasis No." required></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Engine No.</label>
                                            <asp:TextBox ID="txtEngineNo" runat="server" CssClass="form-control" placeholder="Enter Engine No." required></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Vehicle Type</label>
                                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Model</label>
                                            <asp:TextBox ID="txtModel" runat="server" CssClass="form-control" placeholder="Enter Model" required></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Fuel Type</label>
                                            <asp:DropDownList ID="ddlFuelType" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Class Type</label>
                                            <asp:DropDownList ID="ddlClassType" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Order Type</label>
                                            <asp:DropDownList ID="ddlOrderType" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Date of Registration</label>
                                            <asp:TextBox ID="txtRegistrationDate" runat="server" CssClass="form-control" type="Date" placeholder="Select Registration Date" required></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Date Of Manufacture</label>
                                            <asp:TextBox ID="txtManufactureDate" runat="server" CssClass="form-control" type="Date" placeholder="Select Manufacture Date" required></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
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
                                            <label>Select Laser No.</label>
                                            <br />
                                            <asp:ListBox ID="lstDealer" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                        </div>
                                    </div>
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">RC Copy</div>
                                            <div class="input-group control-dark">
                                                <asp:FileUpload ID="upldImg" runat="server" CssClass="form-control" accept=".png,.jpg,.jpeg,.PNG,.JPG,.JPEG" required />
                                                <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                                                    ControlToValidate="upldImg" ForeColor="Red"
                                                    ErrorMessage="* Only image allowed"
                                                    ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Pp][Nn][Gg])|.*\.([Jj][Pp][Ee][Gg])$)">  
                                                </asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="text-align: center;">
                                    <div class="col-md-5 col-sm-12"></div>

                                    <div class="col-md-2 col-sm-12">
                                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                        <asp:Button ID="btnSubmit" runat="server" Text="Book Order" CssClass="btn btn-primary lnkSave" OnClick="btnSubmit_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

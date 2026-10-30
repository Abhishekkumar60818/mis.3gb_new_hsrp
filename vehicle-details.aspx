<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="vehicle-details.aspx.cs" Inherits="vehicle_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .rbl input[type="radio"] {
            margin-left: 20px;
            margin-right: 1px;
        }
        .mybold{
            font-weight:bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scrpt" runat="server"></asp:ScriptManager>
    <link href="../css2.css" rel="stylesheet" />
    <!-- Feather icon-->
    <div class="page-wrapper compact-wrapper" id="pageWrapper">
        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Vehicle Details</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="default.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item active">Vehicle Details</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header pb-0">

                        <div class="pd-20 bg-white border-radius-4 box-shadow mb-30">
                            <div class="row">
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Order Date :-
                                            <asp:Label ID="lblOrderDate" runat="server" CssClass="mybold"></asp:Label></label>

                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Order Type :-
                                            <asp:Label ID="lblOrderType" runat="server" CssClass="mybold"></asp:Label></label>

                                    </div>
                                </div>

                            </div>
                            <div class="clearfix">
                                <div class="pull-left">
                                    <h6 class="text-blue">Owner Details</h6>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Name :-
                                            <asp:Label ID="lblOwnerName" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Mobile No. :-
                                            <asp:Label ID="lblMobileNumber" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Email Id :-
                                            <asp:Label ID="lblEmail" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Address :-
                <asp:Label ID="lblAddress" runat="server" CssClass="mybold"></asp:Label ></label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            City :-
                <asp:Label ID="lblCity" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            State :-
                <asp:Label ID="lblState" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix">
                                <div class="pull-left">
                                    <h6 class="text-blue">Vehicle Details</h6>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Reg. No. :-
                                            <asp:Label ID="lblRegNumber" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Chasis No. :-
                                            <asp:Label ID="lblChasisNumber" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Eng. No. :-
                                            <asp:Label ID="lblEngineNumber" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Bharat Stage :-
                <asp:Label ID="lblBharatStage" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Registration Date :-
                <asp:Label ID="lblRegistrationDate" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Fuel Type :-
                <asp:Label ID="lblFuelType" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Maker :-
                                            <asp:Label ID="lblMaker" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Vehicle Type :-
                                            <asp:Label ID="lblVehicleType" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Vehicle Category :-
                                            <asp:Label ID="lblVehicleCategory" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Front Laser No. :-
                <asp:Label ID="lblFrontLaserNo" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Rear Laser No. :-
                <asp:Label ID="lblRearLaserNo" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>

                            </div>
                            <div class="clearfix">
                                <div class="pull-left">
                                    <h6 class="text-blue">Replacement</h6>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            FIR/LR No. :-
                                            <asp:Label ID="lblFirLRNo" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            FIR Date :-
                                            <asp:Label ID="lblFIRDate" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Police Station :-
                                            <asp:Label ID="lblPoliceStation" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Reason for replacement :-
                 <asp:Label ID="lblReasonforreplacement" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>
                                            Replacement :-
                 <asp:Label ID="lblReplacement" runat="server" CssClass="mybold"></asp:Label></label>
                                    </div>
                                </div>

                            </div>
                            <div class="clearfix">
                                <div class="pull-left">
                                    <h6 class="text-blue">Documents</h6>
                                </div>
                            </div>

                            <asp:Repeater ID="rptrUser" runat="server">
                                <ItemTemplate>
                                    <div class="row">
                                        <asp:PlaceHolder ID="PlaceHolder409" runat="server" Visible='<%#!string.IsNullOrEmpty( Eval("frontlaserphoto").ToString())  %>'>
                                            <div class="col-md-4 col-sm-12">
                                                <div class="form-group">
                                                    <a href='https://3gbhsrp.com/vehicleimages/<%#Eval("frontlaserphoto") %>' target="_blank">Front Laser No. Photo</a>
                                                </div>
                                            </div>
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%#!string.IsNullOrEmpty( Eval("rearlaserphoto").ToString())  %>'>
                                            <div class="col-md-4 col-sm-12">
                                                <div class="form-group">
                                                    <a href='https://3gbhsrp.com/vehicleimages/<%#Eval("rearlaserphoto") %>' target="_blank">Rear Laser No. Photo</a>
                                                </div>
                                            </div>
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible='<%#!string.IsNullOrEmpty( Eval("uploadrc").ToString())  %>'>
                                            <div class="col-md-4 col-sm-12">
                                                <div class="form-group">
                                                    <a href='https://3gbhsrp.com/vehicleimages/<%#Eval("uploadrc") %>' target="_blank">RC Photo</a>
                                                </div>
                                            </div>
                                        </asp:PlaceHolder>
                                    </div>
                                    <div class="row">

                                        <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible='<%#!string.IsNullOrEmpty( Eval("frontplatephoto").ToString())  %>'>
                                            <div class="col-md-4 col-sm-12">
                                                <div class="form-group">
                                                    <a href='https://3gbhsrp.com/vehicleimages/<%#Eval("frontplatephoto") %>' target="_blank">Front Plate Photo</a>
                                                </div>
                                            </div>
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder ID="PlaceHolder4" runat="server" Visible='<%#!string.IsNullOrEmpty( Eval("rearplatephoto").ToString())  %>'>
                                            <div class="col-md-4 col-sm-12">
                                                <div class="form-group">
                                                    <a href='https://3gbhsrp.com/vehicleimages/<%#Eval("rearplatephoto") %>' target="_blank">Rear Plate Photo</a>
                                                </div>
                                            </div>
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder ID="PlaceHolder5" runat="server" Visible='<%#!string.IsNullOrEmpty( Eval("fircopy").ToString())  %>'>
                                            <div class="col-md-4 col-sm-12">
                                                <div class="form-group">
                                                    <a href='https://3gbhsrp.com/vehicleimages/<%#Eval("fircopy") %>' target="_blank">FIR Copy</a>
                                                </div>
                                            </div>
                                        </asp:PlaceHolder>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>









                            <%--   <div class="clearfix">
                                <div class="pull-left">
                                    <h6 class="text-blue">New Laser No.</h6>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>Front Laser No.</label>
                                        <asp:TextBox ID="txtFrontLaserNo" runat="server" CssClass="form-control" placeholder="Enter Chasis No." MaxLength="5"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtFrontLaserNo"
                                            Display="Dynamic" ForeColor="Red" ErrorMessage="* enter valid laser number" ValidationExpression="[A-Za-z]{2}[0-9]{10}"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>Rear Laser No.</label>
                                        <asp:TextBox ID="txtRearLaserNo" runat="server" CssClass="form-control" placeholder="Enter Engine No." MaxLength="5"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtRearLaserNo"
                                            Display="Dynamic" ForeColor="Red" ErrorMessage="* enter valid laser number" ValidationExpression="[A-Za-z]{2}[0-9]{10}"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                            </div>--%>


                            <%--<div class="row" style="text-align: center; margin-bottom: 15px;">
                                <div class="col-md-12 col-sm-12">
                                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Book Order" CssClass="btn btn-primary lnkSave" />
                                </div>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="vahaan-update.aspx.cs" Inherits="vahaan_update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-body-wrapper">
        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Vahaan Update</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dasboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Vahaan Update</li>

                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Container-fluid starts-->
            <div class="container-fluid form-validate">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card">

                            <div class="card-body">
                                <div class="needs-validation" novalidate="">
                                    <div class="row g-3">
                                        <div class="col-md-4">
                                            <label class="form-label" for="validationCustom01">Vehicle No</label>
                                            <asp:TextBox ID="txtRegNo" runat="server" CssClass="form-control" placeholder="Enter Vehicle No"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label class="form-label" for="validationCustom02">Engine No.</label>
                                            <asp:TextBox ID="txtEngine" runat="server" CssClass="form-control" placeholder="Enter Engine No. Last 5 Digit"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4 mb-3">
                                            <label class="form-label" for="validationCustomUsername">Chasis No.</label>
                                            <div class="input-group left-radius">

                                                <asp:TextBox ID="txtChasis" runat="server" CssClass="form-control" placeholder="Enter Chasis No. Last 5 digit"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row g-3">
                                        <div class="col-md-4">
                                            <label class="form-label" for="validationCustom01">Front laser No.</label>
                                            <asp:TextBox ID="txtFrntLaser" runat="server" CssClass="form-control" placeholder="Enter Front laser No."></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label class="form-label" for="validationCustom02">Rear laser No.</label>
                                            <asp:TextBox ID="txtRearLaser" runat="server" CssClass="form-control" placeholder="Enter Rear laser No."></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label class="form-label" for="validationCustom02">Select Type</label>
                                            <asp:DropDownList ID="ddlFlag" runat="server" CssClass="form-control">
                                            <asp:ListItem>New Both HSRP</asp:ListItem>
                                            <asp:ListItem>Duplicate Both HSRP</asp:ListItem>
                                            <asp:ListItem>Duplicate Front HSRP</asp:ListItem>
                                            <asp:ListItem>Duplicate Rear HSRP</asp:ListItem>
                                            <asp:ListItem>Old Both HSRP</asp:ListItem>
                                        </asp:DropDownList>
                                        </div>

                                    </div>
                                    <div class="row g-3">
                                        <div class="col-md-12">
                                            <asp:Label ID="lblMSg" runat="server"></asp:Label>
                                        </div>


                                    </div>
                                    <br />
                                    <br />
                                     <asp:Button ID="btnVahaanCheck" runat="server" Text="Vahaan Check" CssClass="btn btn-info" OnClick="btnVahaanCheck_Click" />
                                                &nbsp<asp:Button ID="btnUploadVahaan" runat="server" Text="Upload Vahaan" CssClass="btn btn-info" OnClick="btnUploadVahaan_Click" />
                                                &nbsp;<a href="vahaan-update.aspx" class="btn btn-dark">Reset</a>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <!-- Container-fluid Ends-->
        </div>
    </div>
</asp:Content>


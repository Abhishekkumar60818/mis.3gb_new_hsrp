<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="stock-transfer.aspx.cs" Inherits="stock_transfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-body-wrapper">
        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Stock Transfer</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dasboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Stock Transfer</li>

                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Container-fluid starts-->
            <div class="container-fluid form-validate">
                <div class="row">
                    <div class="col-sm-12">
                        <div id="pnlView" runat="server">
                            <div class="card">
                                <div class="card-body">
                                    <div class="needs-validation" novalidate="">
                                        <div class="row g-3">
                                            <div class="col-md-4">
                                                <label class="form-label">Embossing/Dealer</label>
                                                <asp:DropDownList ID="ddlStockist" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                            <div class="col-md-4">
                                                <label class="form-label" for="validationCustom02">Size</label>
                                                <asp:DropDownList ID="ddlSize" runat="server" CssClass="form-control"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="Select Size" ControlToValidate="ddlSize" ErrorMessage="* Select" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-4 mb-3">
                                                <label class="form-label" for="validationCustomUsername">Class</label>
                                                <div class="input-group left-radius">

                                                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="Select Class" ControlToValidate="ddlClass" ErrorMessage="* Select" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row g-3">
                                            <div class="col-md-4">
                                                <label class="form-label" for="validationCustom01">From</label>
                                                <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control" placeholder="Enter From Laser No" required></asp:TextBox>
                                                <asp:RegularExpressionValidator ControlToValidate="txtFrom" ID="RegularExpressionValidator2"
                                                    runat="server" ErrorMessage="Enter Laser No." ForeColor="Red" ValidationExpression="^[A-Z0-9_.]+$" />
                                            </div>
                                            <div class="col-md-4">
                                                <label class="form-label" for="validationCustom02">To</label>
                                                <asp:TextBox ID="txtTo" runat="server" CssClass="form-control" placeholder="Enter To Laser No" required></asp:TextBox>
                                                <asp:RegularExpressionValidator ControlToValidate="txtTo" ID="RegularExpressionValidator3"
                                                    runat="server" ErrorMessage="Enter Laser No." ForeColor="Red" ValidationExpression="^[A-Z0-9_.]+$" />
                                            </div>

                                        </div>

                                        <div class="form-label">
                                            &nbsp;
                                                <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Button ID="btnTransfer" runat="server" Text="Transfer" CssClass="btn btn-info" OnClick="btnTransfer_Click" />
                                            &nbsp;<a href="stock-transfer.aspx" class="btn btn-dark">Refresh</a>
                                        </div>
                                    </div>
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


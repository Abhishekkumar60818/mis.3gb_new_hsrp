<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="add.aspx.cs" Inherits="add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-body-wrapper">
        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Add Stock</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dasboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Add stock</li>

                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Container-fluid starts-->
            <div class="container-fluid form-validate">
                <div class="row">
                    <div class="col-sm-12">
                                    <div id="pnlAdd" runat="server">

                        <div class="card">

                            <div class="card-body">
                                <div class="needs-validation" novalidate="">
                                    <div class="row g-3">
                                        <div class="col-md-4">
                                            <label class="form-label" for="validationCustom01">Select Size</label>
                                            <div class="input-group control-dark">
                                                <asp:DropDownList ID="ddlSize" runat="server" CssClass="form-control"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Please Select Size" ForeColor="Red"
                                                    ControlToValidate="ddlSize" InitialValue="Select Size"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <label class="form-label" for="validationCustom02">Select Class</label>
                                            <div class="input-group control-dark">
                                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Please Select Class" ForeColor="Red"
                                                    ControlToValidate="ddlClass" InitialValue="Select Class"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-md-4 mb-3">
                                            <label class="form-label" for="validationCustomUsername">Quantity</label>
                                            <div class="input-group left-radius">

                                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" placeholder="Enter Quantity" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                  <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                            <asp:Button ID="btnSubmit" runat="server" Text="Generate" CssClass="btn btn-info" OnClick="btnSubmit_Click" />
                                            &nbsp;<a href="add.aspx" class="btn btn-dark">Refresh</a>
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


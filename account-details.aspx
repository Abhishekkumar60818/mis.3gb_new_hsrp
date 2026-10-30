<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="account-details.aspx.cs" Inherits="account_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-body-wrapper">
        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Account Details</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dasboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Account Details</li>

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
                                            <label class="form-label" for="validationCustom01">Select Dealer</label>
                                            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-4">
                                            <label class="form-label" for="validationCustom02">Account Name</label>
                                            <asp:TextBox ID="txtAccountName" runat="server" CssClass="form-control" placeholder="Enter Account Name"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4 mb-3">
                                            <label class="form-label" for="validationCustomUsername">Account No</label>
                                            <div class="input-group left-radius">

                                                <asp:TextBox ID="txtAccountNo" runat="server" CssClass="form-control" placeholder="Enter Account No"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row ">
                                        <div class="col-md-4">
                                            <label class="form-label" for="validationCustom01">Bank Name</label>
                                            <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control" placeholder="Enter Bank Name"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label class="form-label" for="validationCustom02">IFSC Code</label>
                                            <asp:TextBox ID="txtIFSCCode" runat="server" CssClass="form-control" placeholder="Enter IFSC Code"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label class="form-label" for="validationCustom01">Branch Code</label>
                                            <asp:TextBox ID="txtBranchCode" runat="server" CssClass="form-control" placeholder="Enter Branch Code"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        
                                        <div class="col-md-4">
                                            <label class="form-label" for="validationCustom02">Branch Name</label>
                                            <asp:TextBox ID="txtBranchName" runat="server" CssClass="form-control" placeholder="Enter Branch Name"></asp:TextBox>
                                        </div>
                                             <div class="col-md-4">
                                            <label class="form-label" for="validationCustom01">Account Type</label>
                                            <asp:TextBox ID="txtAccountType" runat="server" CssClass="form-control" placeholder="Enter Account Type"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label class="form-label" for="validationCustom02">PAN NO.</label>
                                            <asp:TextBox ID="txtPanNo" runat="server" CssClass="form-control" placeholder="Enter PAN No."></asp:TextBox>
                                        </div>
                                    </div>
                                  

                                    <div class="row gutters">
                                        <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                            <div class="mb-3">
                                                <div class="form-label">
                                                    &nbsp;
                                               <asp:Label ID="lblId" Visible="false" runat="server"></asp:Label>
                                                </div>
                                                <div>

                                                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                                                </div>
                                            </div>
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


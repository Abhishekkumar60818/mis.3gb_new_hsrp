<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="accountdetails.aspx.cs" Inherits="accountdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-wrapper compact-wrapper" id="pageWrapper">

        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Account Details</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="default.aspx"><i data-feather="home"></i></a></li>
                                
                                <li class="breadcrumb-item active">Account Details</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header pb-0">

                        <asp:Panel ID="pnlAdd" runat="server">
                            <div class="pd-20 bg-white border-radius-4 box-shadow mb-30">
                                <div class="clearfix">
                                    <div class="pull-left">
                                        <h4 class="text-blue">Add Account Details</h4>
                                        <%--<p class="mb-30 font-14">All bootstrap element classies</p>--%>
                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Select Distributor</label>
                                            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Account Name</label>
                                            <asp:TextBox ID="txtAccountName" runat="server" CssClass="form-control" placeholder="Enter Account Name"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Account No</label>
                                            <asp:TextBox ID="txtAccountNo" runat="server" CssClass="form-control" placeholder="Enter Account No"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Bank Name</label>
                                            <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control" placeholder="Enter Bank Name"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>IFSC Code</label>
                                            <asp:TextBox ID="txtIFSCCode" runat="server" CssClass="form-control" placeholder="Enter IFSC Code"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Branch Code</label>
                                            <asp:TextBox ID="txtBranchCode" runat="server" CssClass="form-control" placeholder="Enter Branch Code"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Branch Name</label>
                                            <asp:TextBox ID="txtBranchName" runat="server" CssClass="form-control" placeholder="Enter Branch Name"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Account Type</label>
                                            <asp:TextBox ID="txtAccountType" runat="server" CssClass="form-control" placeholder="Enter Account Type"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>PAN No.</label>
                                            <asp:TextBox ID="txtPanNo" runat="server" CssClass="form-control" placeholder="Enter PAN No."></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group" style="display: none">
                                            <asp:Label ID="lblId" runat="server"></asp:Label>
                                            <%--<label>Account Type</label>
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Enter Account Type"></asp:TextBox>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="text-align: center;">
                                    <div class="col-sm-12">
                                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                        <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                                        <%--<button class="btn btn-primary" type="submit">Save changes</button>--%>
                                        <%-- <button class="btn btn-primary">Reset</button>--%>
                                    </div>
                                </div>

                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

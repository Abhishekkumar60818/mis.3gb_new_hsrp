<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="BankDetails.aspx.cs" Inherits="seller_BankDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <div class="page-wrapper compact-wrapper" id="pageWrapper">

        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Bank Details</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="default.aspx"><i data-feather="home"></i></a></li>
                                
                                <li class="breadcrumb-item active">Bank Details</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-sm-12">
                <asp:Panel ID="pnlView" runat="server">

                    <div class="card">
                        <div class="card-header pb-0">
                           <div class="row" style="text-align: center!important">

                         <%--       <div class="col-md-3"></div>--%>
                                <div class="col-md-12" >
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Company Name :- <asp:Label ID="lblAName" runat="server" Font-Bold="true"></asp:Label></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Bank Name :- <asp:Label ID="lblBankName" runat="server" Font-Bold="true"></asp:Label></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Account No. :- <asp:Label ID="lblAccountNo" runat="server" Font-Bold="true"></asp:Label></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>IFSC Code :- <asp:Label ID="lblIFSC" runat="server" Font-Bold="true"></asp:Label></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Branch Code :- <asp:Label ID="lblBranchCode" runat="server" Font-Bold="true"></asp:Label></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Branch Name :- <asp:Label ID="lblBranchName" runat="server" Font-Bold="true"></asp:Label></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Type of Account :- <asp:Label ID="lblAtype" runat="server" Font-Bold="true"></asp:Label></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>PAN No. :- <asp:Label ID="lblPanNo" runat="server" Font-Bold="true"></asp:Label></label>
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="col-md-3"></div>--%>
                            </div>
                        </div>
                       
                    </div>
                </asp:Panel>
            </div>

        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="OnlinePayment.aspx.cs" Inherits="seller_OnlinePayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                            <h3>Online Payment</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="default.aspx"><i data-feather="home"></i></a></li>

                                <li class="breadcrumb-item active">Online Payment</li>
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
                                    <h4 class="text-blue"></h4>
                                    <%--<p class="mb-30 font-14">All bootstrap element classies</p>--%>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-md-3 col-sm-12"></div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="col-md-12 col-sm-12">
                                        <div class="form-group">
                                            <label>Amount</label>
                                            <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" placeholder="Enter Amount" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12">
                                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="col-md-12 col-sm-12" style="text-align:center">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Deposit" CssClass="btn btn-primary lnkSave" OnClick="btnSubmit_Click" />
                                    </div>
                                </div>
                                <div class="col-md-3 col-sm-12"></div>

                            </div>
                            <br />
                            <br />

                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>

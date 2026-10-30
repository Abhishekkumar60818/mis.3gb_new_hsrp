<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="seller_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-body-wrapper">
        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Dashboard</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Dashboard</li>

                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Container-fluid starts-->
            <div class="container-fluid dashboard-2">
                <div class="row">
                    <div class="col-xl-9 col-md-12 box-col-100 xl-100">
                        <div class="row">
                            <div class="col-lg-3 col-md-6 box-col-3">
                                <div class="card profit-card">
                                    <div class="card-header pb-0">
                                        <div class="d-flex justify-content-between">
                                            <div class="flex-grow-1">
                                                <p class="square-after f-w-600 header-text-primary">Generated Orders<i class="fa fa-circle"> </i></p>
                                                <h4><asp:Label ID="lblGeneratedOrder" runat="server"></asp:Label></h4>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-body">

                                        <div class="right-side icon-right-success">
                                            <i class="fa fa-stack-exchange"></i>
                                            <div class="shap-block">
                                                <div class="rounded-shap animate-bg-secondary"><i></i><i></i></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-6 box-col-3">
                                <div class="card visitor-card">
                                    <div class="card-header pb-0">
                                        <div class="d-flex justify-content-between">
                                            <div class="flex-grow-1">
                                                <p class="square-after f-w-600 header-text-info">Rejected Order<i class="fa fa-circle"> </i></p>
                                                <h4><asp:Label ID="lblRejectedOrder" runat="server"></asp:Label></h4>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-body">

                                        <div class="right-side icon-right-success">
                                           <i class="fa fa-handshake-o"></i>
                                            <div class="shap-block">
                                                <div class="rounded-shap animate-bg-secondary"><i></i><i></i></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-12 box-col-3">
                                <div class="card sell-card">
                                    <div class="card-header pb-0">
                                        <div class="d-flex justify-content-between">
                                            <div class="flex-grow-1">
                                                <p class="square-after f-w-600 header-text-success">Completed Orders<i class="fa fa-circle"> </i></p>
                                                <h4><asp:Label ID="lblCompletedOrder" runat="server"></asp:Label></h4>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-body">

                                        <div class="right-side icon-right-success">
                                           <i class="fa fa-list-alt"></i>
                                            <div class="shap-block">
                                                <div class="rounded-shap animate-bg-secondary"><i></i><i></i></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-12 box-col-3">
                                <div class="card sell-card">
                                    <div class="card-header pb-0">
                                        <div class="d-flex justify-content-between">
                                            <div class="flex-grow-1">
                                                <p class="square-after f-w-600 header-text-success">Total Orders<i class="fa fa-circle"> </i></p>
                                                <h4><asp:Label ID="lblTotalOrders" runat="server"></asp:Label></h4>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-body">

                                        <div class="right-side icon-right-success">
                                            <i class="fa fa-podcast"></i>
                                            <div class="shap-block">
                                                <div class="rounded-shap animate-bg-secondary"><i></i><i></i></div>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="stock-dealer-wise.aspx.cs" Inherits="stock_dealer_wise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css2.css" rel="stylesheet" />
    <!-- Feather icon-->

    <div class="page-wrapper compact-wrapper" id="pageWrapper">

        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h5>Stock Dealer Wise Report</h5>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Stock Dealer Wise Report</li>

                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div id="pnlStockistwise" runat="server">
                    <div class="card">
                        <div class="card-header pb-0">
                        </div>
                        <div class="card-body">
                            <div class="table-responsive theme-scrollbar">
                                <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                    <table class="display dataTable no-footer" id="basic-1" role="grid" aria-describedby="basic-1_info">
                                        <thead>
                                            <tr role="row">
                                                <th class="sorting_asc" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" style="width: auto;">#</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" style="width: auto;">Dealer Name</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: 98.9531px;">Current Stock</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptrDealer" runat="server" OnItemCommand="rptrDealer_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="table-plus"><%# Container.ItemIndex +1 %></td>
                                                        <td><%#Eval("name") %></td>
                                                        <td>
                                                            <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="btn btn-dark remove-from-cart mybtns" Text='<%#Eval("Stocks") %>' CommandArgument='<%#Eval("id") %>' CommandName="edit"></asp:LinkButton>
                                                        </td>

                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>


                                        </tbody>
                                    </table>
                                    <%-- <div class="dataTables_info" id="basic-1_info" role="status" aria-live="polite">Showing 1 to 10 of 14 entries</div>
                               <div class="dataTables_paginate paging_simple_numbers" id="basic-1_paginate"><a class="paginate_button previous disabled" aria-controls="basic-1" data-dt-idx="0" tabindex="0" id="basic-1_previous">Previous</a><span><a class="paginate_button current" aria-controls="basic-1" data-dt-idx="1" tabindex="0">1</a><a class="paginate_button " aria-controls="basic-1" data-dt-idx="2" tabindex="0">2</a></span><a class="paginate_button next" aria-controls="basic-1" data-dt-idx="3" tabindex="0" id="basic-1_next">Next</a></div>   </div>
                                    --%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="pnlView" runat="server">

                    <div class="card">
                        <h5>
                            <asp:Label ID="lblDistributorName" runat="server"></asp:Label></h5>
                        <div class="card-header pb-0">
                            <div class="row gutters" style="margin-bottom: 5px; margin-top: 10px;">
                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                    <div class="mb-3">
                                        <div class="form-label">200X100(Tranport)</div>
                                        <div class="input-group control-dark">
                                            <asp:Label ID="lbl200X45Transport" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                    <div class="mb-3">
                                        <div class="form-label">200X100(Non-Tranport)</div>
                                        <div class="input-group control-dark">
                                            <asp:Label ID="lbl200X45NONTransport" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                    <div class="mb-3">
                                        <div class="form-label">
                                            <label class="form-label">285X45(Tranport)</label>
                                        </div>
                                        <div class="input-group control-dark">
                                            <asp:Label ID="lbl285X45Transport" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                    <div class="mb-3">
                                        <div class="form-label">
                                            <label class="form-label">285X45(Non-Tranport)</label>
                                        </div>
                                        <div class="input-group control-dark">
                                            <asp:Label ID="lbl285X45NONTransport" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="row gutters" style="margin-bottom: 10px; margin-top: 5px;">
                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                    <div class="mb-3">
                                        <div class="form-label">340X200(Tranport)</div>
                                        <div class="input-group control-dark">
                                            <asp:Label ID="lbl340X200Transport" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                    <div class="mb-3">
                                        <div class="form-label">340X200(Non-Tranport)</div>
                                        <div class="input-group control-dark">
                                            <asp:Label ID="lbl340X200NONTransport" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                    <div class="mb-3">
                                        <div class="form-label">
                                            <label class="form-label">500X120(Tranport)</label>
                                        </div>
                                        <div class="input-group control-dark">
                                            <asp:Label ID="lbl500X120Transport" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                    <div class="mb-3">
                                        <div class="form-label">
                                            <label class="form-label">500X120(Non-Tranport)</label>
                                        </div>
                                        <div class="input-group control-dark">
                                            <asp:Label ID="lbl500X120NONTransport" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive theme-scrollbar">
                                <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                    <table class="display dataTable no-footer" id="basic-1" role="grid" aria-describedby="basic-1_info">
                                        <thead>
                                            <tr role="row">
                                                <th class="sorting_asc" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" style="width: auto;">#</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" style="width: auto;">Laser No.</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto;">Class</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto;">Size</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptrUser" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="table-plus">
                                                            <%# Container.ItemIndex +1 %>
                                                        </td>
                                                        <td><%#Eval("laserno") %></td>
                                                        <td><%#Eval("type") %></td>
                                                        <td><%#Eval("sizes") %></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>


                                        </tbody>
                                    </table>
                                    <%-- <div class="dataTables_info" id="basic-1_info" role="status" aria-live="polite">Showing 1 to 10 of 14 entries</div>
                               <div class="dataTables_paginate paging_simple_numbers" id="basic-1_paginate"><a class="paginate_button previous disabled" aria-controls="basic-1" data-dt-idx="0" tabindex="0" id="basic-1_previous">Previous</a><span><a class="paginate_button current" aria-controls="basic-1" data-dt-idx="1" tabindex="0">1</a><a class="paginate_button " aria-controls="basic-1" data-dt-idx="2" tabindex="0">2</a></span><a class="paginate_button next" aria-controls="basic-1" data-dt-idx="3" tabindex="0" id="basic-1_next">Next</a></div>   </div>
                                    --%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


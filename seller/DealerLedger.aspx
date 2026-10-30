<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="DealerLedger.aspx.cs" Inherits="seller_DealerLedger" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-wrapper compact-wrapper" id="pageWrapper">

        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Dealer Ledger</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="default.aspx"><i data-feather="home"></i></a></li>
                                
                                <li class="breadcrumb-item active">Dealer Ledger</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-sm-12">
                <asp:Panel ID="pnlView" runat="server">

                    <div class="card">
                        <div class="card-header pb-0">
                            <div class="mb-3" style="text-align: right">
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive theme-scrollbar">
                                <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                    <table class="display dataTable no-footer" id="basic-1" role="grid" aria-describedby="basic-1_info">
                                        <thead>
                                            <tr style="background: #01455f; color: #fff;">
                                                <th colspan="4">
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <asp:Label ID="lblDR" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <asp:Label ID="lblCR" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <asp:Label ID="lblBalance" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </th>
                                            </tr>
                                            <tr role="row">
                                                <th>#</th>
                                                <th>Date</th>
                                                <th>Description</th>
                                                
                                                <th>DR</th>
                                                <th>CR</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptrUser" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="table-plus"><%# Container.ItemIndex +1 %></td>
                                                        <td><%# Eval("date", "{0:dd-MM-yyyy}") %></td>
                                                        <td><%#Eval("transactionno") %> , <%#Eval("mode") %></td>
                                                        <td><%#Eval("dr") %></td>
                                                        <td><%#Eval("cr") %></td>
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
                </asp:Panel>
            </div>

        </div>
    </div>
</asp:Content>

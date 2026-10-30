<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="sledger.aspx.cs" Inherits="seller_sledger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-wrapper compact-wrapper" id="pageWrapper">

        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Party Ledger</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="default.aspx"><i data-feather="home"></i></a></li>
                                
                                <li class="breadcrumb-item active">Party Ledger</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-sm-12">
                <asp:Panel ID="pnlparty" runat="server">

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
                                            <tr role="row">
                                                <th class="sorting_asc" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" style="width: auto;">Party Name</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" style="width: auto">DR</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto">CR</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Balance</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptrParty" runat="server" OnItemCommand="rptrParty_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>

                                                        <td class="table-plus">
                                                            <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Blue" Font-Bold="true" Text='<%# Eval("name") %>' CommandArgument='<%#Eval("id") %>'></asp:LinkButton></td>
                                                        <td>
                                                            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%#Eval("dr").ToString() !=""  %>'>
                                                                <%#Eval("dr") %>
                                                            </asp:PlaceHolder>
                                                            <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible='<%#Eval("dr").ToString() ==""  %>'>0
                                                            </asp:PlaceHolder>
                                                        </td>
                                                        <td>
                                                            <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible='<%#Eval("cr").ToString() !=""  %>'>
                                                                <%#Eval("cr") %>
                                                            </asp:PlaceHolder>
                                                            <asp:PlaceHolder ID="PlaceHolder4" runat="server" Visible='<%#Eval("cr").ToString() ==""  %>'>0
                                                            </asp:PlaceHolder>
                                                        </td>
                                                        <td>
                                                            <asp:PlaceHolder ID="PlaceHolder5" runat="server" Visible='<%#Eval("balance").ToString() !=""  %>'>
                                                                <%#Eval("balance") %>
                                                            </asp:PlaceHolder>
                                                            <asp:PlaceHolder ID="PlaceHolder6" runat="server" Visible='<%#Eval("balance").ToString() ==""  %>'>0
                                                            </asp:PlaceHolder>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>

                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlLedger" runat="server">
                    <div class="card">
                        <div class="card-header pb-0">
                            <div class="mb-3" style="text-align: right">
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive theme-scrollbar">
                                <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                    <table class="data-table stripe hover  nowrap dataTable no-footer dtr-inline">
                                        <thead>
                                            <tr style="background: #01455f; color: #fff;">
                                                <th colspan="5">
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
                                            <tr>
                                                <th class="sorting_asc" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" style="width: auto;">Date</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" style="width: auto">Payment Details</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto">DR</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">CR</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Remark</th>

                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptrUser" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="table-plus"><%# Eval("date", "{0:dd/MM/yyyy}") %></td>
                                                        <td><%#Eval("transactionno") %> , <%#Eval("mode") %></td>
                                                        <td><%#Eval("dr") %></td>
                                                        <td><%#Eval("cr") %></td>
                                                        <td><%#Eval("remark") %></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            </div>
                        </div>
                </asp:Panel>

            </div>
        </div>
    </div>


 
</asp:Content>

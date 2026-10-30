<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="party-ledger.aspx.cs" Inherits="party_ledger" %>

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
                            <h3>Party-Ledger</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Party-Ledger</li>

                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div id="pnlLedger" runat="server">
                    <div class="card">
                        <div class="card-header pb-0">
                            <div class="row gutters">
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
                        </div>
                        <div class="card-body">
                            <div class="table-responsive theme-scrollbar">
                                <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                    <table class="display dataTable no-footer" id="basic-1" role="grid" aria-describedby="basic-1_info">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>Date</th>
                                                <th>Payment Details</th>
                                                <th>DR</th>
                                                <th>CR</th>
                                                <th>Remark</th>

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
                </div>
                <div id="pnlparty" runat="server">

                    <div class="row gutters">
                        <div class="colxxl-12 col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                            <div class="card gradient-dark-grey">
                                <div class="card-body">
                                    <div class="table-responsive">
                                        <table class="display dataTable no-footer" id="basic-1" role="grid" aria-describedby="basic-1_info">
                                            <thead>
                                                <tr>
                                                    <th>Party Name</th>
                                                    <th>DR</th>
                                                    <th>CR</th>
                                                    <th>Balance</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rptrParty" runat="server" OnItemCommand="rptrParty_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td class="table-plus">
                                                                <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="#34b5c2" Font-Bold="true" Text='<%# Eval("name") %>' CommandArgument='<%#Eval("id") %>'></asp:LinkButton></td>
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
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="sstock.aspx.cs" Inherits="seller_sstock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/2.1.8/css/dataTables.dataTables.css">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/3.2.0/css/buttons.dataTables.css">
    <style>
        /* Basic reset */
     
        /* Table styling */
        .styled-table {
            width: 100%;
            border-collapse: collapse;
            margin: 25px 0;
            font-size: 0.9em;
            min-width: 400px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
            border-radius: 5px;
            overflow: hidden;
        }
        
        .styled-table thead tr {
            background-color: #009879;
            color: #ffffff;
            text-align: left;
            font-weight: bold;
        }
        
        .styled-table th,
        .styled-table td {
            padding: 12px 15px;
        }
        
        .styled-table tbody tr {
            border-bottom: 1px solid #dddddd;
        }
        
        .styled-table tbody tr:nth-of-type(even) {
            background-color: #f3f3f3;
        }
        
        .styled-table tbody tr:last-of-type {
            border-bottom: 2px solid #009879;
        }
        
        .styled-table tbody tr:hover {
            background-color: #e0f7fa;
            color: #009879;
            font-weight: bold;
        }
        
        /* Caption styling */
        .styled-table caption {
            font-size: 1.2em;
            margin-bottom: 10px;
            font-weight: bold;
            color: #333;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-wrapper compact-wrapper" id="pageWrapper">

        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Stock View</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="default.aspx"><i data-feather="home"></i></a></li>

                                <li class="breadcrumb-item active">Stock View</li>
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
                            <%-- Database search filters the full dealer stock, not only this page. --%>
                            <div class="row g-2 mb-3 align-items-end">
                                <div class="col-md-4">
                                    <label class="form-label">Search</label>
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Laser No / Registration No / Size / Class / Dealer"></asp:TextBox>
                                </div>
                                <div class="col-md-8 d-flex gap-2">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" />
                                </div>
                            </div>
                            <div class="table-responsive theme-scrollbar">
                                <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                    <table id="dealerStockGrid" class="styled-table" style="width: 100%">
                                        <thead>
                                            <tr role="row">
                                                <th class="sorting_asc" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" style="width: auto;">Laser No.</th>

                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto">Size</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" style="width: auto">Classx</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Sold Status</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Registration</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptrUser" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="table-plus"><%#Eval("laserno") %></td>

                                                        <td><%#Eval("sizes") %></td>
                                                        <td><%#Eval("type") %></td>
                                                        <td><%#Eval("soldstatus") %></td>
                                                        <td><%#Eval("RegistrationNo") %></td>
                                                        <%--<td><%# Eval("date", "{0:dd/MM/yyyy}") %></td>--%>
                                                        <%--<td>
                                                            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%#Eval("sstatus").ToString() =="0"  %>'>
                                                                <label style="color: green;"><%=SessionVeriables.SessionEmail%></label>
                                                            </asp:PlaceHolder>
                                                            <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible='<%#Eval("sstatus").ToString() =="1"  %>'>
                                                                <label style="color: red;">Sold-Out</label>
                                                            </asp:PlaceHolder>

                                                        </td>--%>
                                                        <%-- <td>
                                                    <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="fa fa-edit" Text=" Edit" CommandArgument='<%#Eval("id") %>' CommandName="edit"></asp:LinkButton>
                                                    <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible='<%#Eval("status").ToString() =="1"  %>'>
                                                        <asp:LinkButton ID="lnkRemove" runat="server" CssClass="fa fa-remove" Text=" Block" CommandArgument='<%#Eval("id") %>' CommandName="delete"></asp:LinkButton>
                                                    </asp:PlaceHolder>
                                                    <asp:PlaceHolder ID="PlaceHolder4" runat="server" Visible='<%#Eval("status").ToString() =="0"  %>'>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="fa fa-check" Text=" UnBlock" CommandArgument='<%#Eval("id") %>' CommandName="unblock"></asp:LinkButton>
                                                    </asp:PlaceHolder>
                                                </td>--%>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                    <asp:Repeater ID="rptPager" runat="server">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                                OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>

        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.7.1.js"></script>
    <script src="https://cdn.datatables.net/2.1.8/js/dataTables.js"></script>
    <script src="https://cdn.datatables.net/buttons/3.2.0/js/dataTables.buttons.js"></script>
    <script src="https://cdn.datatables.net/buttons/3.2.0/js/buttons.dataTables.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.10.1/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.2.7/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.2.7/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/3.2.0/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/3.2.0/js/buttons.print.min.js"></script>
    <script>
        // Server-side pagination/search are active, so disable DataTables
        // paging/searching. It would otherwise filter only the loaded page.
        new DataTable('#dealerStockGrid', {
            paging: false,
            searching: false,
            info: false,
            ordering: false,
            layout: {
                topStart: {
                    buttons: ['csv', 'excel', 'pdf', 'print']
                }
            }
        });
    </script>
</asp:Content>

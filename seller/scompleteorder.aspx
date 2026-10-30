<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="scompleteorder.aspx.cs" Inherits="seller_scompleteorder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .multiselect-container {
            max-height: 300px !important;
            overflow: scroll !important;
            min-width: 220px !important;
        }
        .pager-btn { min-width: 38px; }
        .pager-active { background:#0d6efd !important; color:#fff !important; border-color:#0d6efd !important; }
    </style>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/2.1.8/css/dataTables.dataTables.css">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/3.2.0/css/buttons.dataTables.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page-wrapper compact-wrapper" id="pageWrapper">

        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>View Order</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="default.aspx"><i data-feather="home"></i></a></li>

                                <li class="breadcrumb-item active">View Order</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header pb-0">
                        <div class="mb-3" style="text-align: right">
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row g-2 mb-3 align-items-end">
                            <div class="col-md-2">
                                <label class="form-label">From Date</label>
                                <asp:TextBox ID="txtFromDate" runat="server" type="Date" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label class="form-label">To Date</label>
                                <asp:TextBox ID="txtToDate" runat="server" type="Date" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <label class="form-label">Search</label>
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Reg No / Chassis / Engine / City / Dealer"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label class="form-label">Page Size</label>
                                <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="20" Selected="True">20</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3 d-flex gap-2">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" />
                            </div>
                        </div>

                        <div class="table-responsive theme-scrollbar">
                            <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                               <table id="scompleteGrid" class="display nowrap" style="width: 100%">
                                    <thead>
                                        <tr role="row">
                                            <th>Order Date</th>
                                            <th>Dealer Name</th>
                                            <th>City Name</th>
                                            <th>Registration No.</th>
                                            <th>Chassis No.</th>
                                            <th>Engine No.</th>
                                            <th>Vehicle Type</th>
                                            <th>Vehicle Category</th>
                                            <th>Fuel Type</th>
                                            <th>Front Laser No</th>
                                            <th>Rear Laser No</th>
                                            <th>Date of Registration</th>
                                            <th>TLP</th>
                                            <th>Receipt</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptrUser" runat="server" OnItemCommand="rptrUser_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="table-plus"><%# Eval("orderdate", "{0:dd/MM/yyyy}") %></td>
                                                    <td><%#Eval("DName") %></td>
                                                    <td><%#Eval("city") %></td>
                                                    <td><%#Eval("registrationno") %></td>
                                                    <td><%#Eval("chasisno") %></td>
                                                    <td><%#Eval("engineno") %></td>
                                                    <td><%#Eval("vehicletype") %></td>
                                                    <td><%#Eval("classtype") %></td>
                                                    <td><%#Eval("fueltype") %></td>
                                                    <td><%#Eval("frontlaser") %></td>
                                                    <td><%#Eval("rearlaser") %></td>
                                                    <td><%# Eval("registrationdate", "{0:dd/MM/yyyy}") %></td>
                                                    <td>
                                                        <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible='<%#Eval("tlp").ToString() =="Yes"  %>'>
                                                            <a href='../pdf/tlpprint.aspx?id=<%#Eval("id") %>' class="fa fa-print" style="font-size:10px;" target="_blank">Print TLP</a>
                                                        </asp:PlaceHolder>
                                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%#Eval("tlp").ToString() =="No"  %>'>
                                                            <label style="color: red; font-weight: bold">NA</label>
                                                        </asp:PlaceHolder>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="10px" CssClass="fa fa-download" Text=" Invoice" CommandArgument='<%#Eval("id") %>' CommandName="download"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                                
                            </div>
                        </div>

                        <div class="d-flex flex-wrap justify-content-between align-items-center mt-3 gap-2">
                            <div>
                                <asp:Label ID="lblPagerInfo" runat="server" CssClass="text-muted small"></asp:Label>
                                <asp:Label ID="lblPageInfo" runat="server" CssClass="text-muted small ms-2"></asp:Label>
                            </div>
                            <div class="d-flex align-items-center gap-1 flex-wrap">
                                <asp:LinkButton ID="lnkFirst" runat="server" CssClass="btn btn-outline-primary btn-sm pager-btn" Text="&laquo; First" OnClick="lnkFirst_Click"></asp:LinkButton>
                                <asp:LinkButton ID="lnkPrev" runat="server" CssClass="btn btn-outline-primary btn-sm pager-btn" Text="&lsaquo; Prev" OnClick="lnkPrev_Click"></asp:LinkButton>
                                <asp:Repeater ID="rptPager" runat="server" OnItemCommand="rptPager_ItemCommand">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkPage" runat="server" CommandName="Page" CommandArgument='<%# Container.DataItem %>'
                                            CssClass='<%# (Container.DataItem.ToString() == ViewState["CurrentPage"].ToString()) ? "btn btn-primary btn-sm pager-btn pager-active" : "btn btn-outline-primary btn-sm pager-btn" %>'
                                            Text='<%# Container.DataItem %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:LinkButton ID="lnkNext" runat="server" CssClass="btn btn-outline-primary btn-sm pager-btn" Text="Next &rsaquo;" OnClick="lnkNext_Click"></asp:LinkButton>
                                <asp:LinkButton ID="lnkLast" runat="server" CssClass="btn btn-outline-primary btn-sm pager-btn" Text="Last &raquo;" OnClick="lnkLast_Click"></asp:LinkButton>
                            </div>
                        </div>

                    </div>
                </div>
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
        new DataTable('#scompleteGrid', {
            paging: false,
            searching: false,
            info: false,
            ordering: false,
            layout: { topStart: { buttons: ['csv', 'excel', 'pdf', 'print'] } }
        });
    </script>
</asp:Content>

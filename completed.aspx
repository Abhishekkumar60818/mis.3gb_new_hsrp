<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="completed.aspx.cs" Inherits="completed" %>

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
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $(".modelClose").click(function () {
                $('#Updatemodal').modal('hide');
            });
        });
    </script>

    <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scrpt" runat="server"></asp:ScriptManager>

    <link href="css2.css" rel="stylesheet" />
    <!-- Feather icon-->

    <div class="page-wrapper compact-wrapper" id="pageWrapper">

        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Completed</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Completed</li>

                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="card">

                    <div class="card-body">
                        <%-- DB Pagination + Filters --%>
                        <div class="row g-2 mb-3 align-items-end">
                            <div class="col-md-2">
                                <label class="form-label">From Date</label>
                                <asp:TextBox ID="txtStDate" runat="server" type="Date" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label class="form-label">To Date</label>
                                <asp:TextBox ID="txtEndDate" runat="server" type="Date" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <label class="form-label">Search</label>
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Reg No / Chassis / Engine / Dealer"></asp:TextBox>
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
                                <asp:Button ID="btnSubmit" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSubmit_Click"></asp:Button>
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click"></asp:Button>
                            </div>
                        </div>
                        <div class="table-responsive theme-scrollbar">
                            <div id="completedGrid_wrapper" class="dataTables_wrapper no-footer">
                                <table class="display dataTable no-footer" id="completedGrid" role="grid" aria-describedby="completedGrid_info">
                                    <thead>
                                        <tr role="row">
                                            <th>Date</th>
                                            <th>Dealer Name</th>
                                            <th>Embossing Centre</th>
                                            <th>Name</th>
                                            <th>Registration No.</th>
                                            <th>Chassis No.</th>
                                            <th>Engine No.</th>
                                            <th>Vehicle Type</th>
                                            <th>Front Laser No</th>
                                            <th>Rear Laser No</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <asp:Repeater ID="rptrUser" runat="server" OnItemCommand="rptrUser_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="table-plus"><%# Eval("orderdate", "{0:dd/MM/yyyy}") %></td>
                                                    <td><%#Eval("DName") %></td>
                                                    <td><%#Eval("ems") %></td>
                                                    <td><%#Eval("name") %></td>
                                                    <td><%#Eval("registrationno") %></td>
                                                    <td><%#Eval("chasisno") %></td>
													<td><%#Eval("engineno") %></td>
                                                    <td><%#Eval("vehicletype") %></td>
                                                    <td><%#Eval("frontlaser") %></td>
                                                    <td><%#Eval("rearlaser") %></td>
                                                    <td>
                                                        <button style="display: none;" id="btnShowPopup" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
                                                            Launch static backdrop modal
                                                        </button>
                                                        <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="btn btn-primary btnnew" Font-Size="10px" Width="120" Text="Free Laser" CommandArgument='<%#Eval("id") %>' CommandName="edit"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                        <%-- Server-side pagination --%>
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
            <div class="main-container">
                <div class="pd-ltr-20 customscroll customscroll-10-p height-100-p xs-pd-20-10">
                    <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-dialog modal-lg modal-dialog-centered">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title" id="myLargeModalLabel">Confirmation</h4>
                                        <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblLastICCid" runat="server" Visible="false"></asp:Label>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                        <div class="row">
                                            <div class="col-md-6 col-sm-12">
                                                <div class="form-group">
                                                    <label>Registration</label>
                                                    <asp:Label ID="lblRegistration" runat="server" CssClass="form-control"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-12">
                                                <div class="form-group">
                                                    <label>Front Laser No.</label>
                                                    <asp:Label ID="lblFrontLaserNumber" runat="server" CssClass="form-control"></asp:Label>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-md-6 col-sm-12">
                                                <div class="form-group">
                                                    <label>Rear Laser No.</label>
                                                    <asp:Label ID="lblRearLaser" runat="server" CssClass="form-control"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12">
                                                    <div class="form-group">
                                                        <label>Remark</label>
                                                        <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvRemark" runat="server" ControlToValidate="txtRemark" ValidationGroup="FreeLaser" ErrorMessage="Remark is required." CssClass="text-danger small" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        <asp:Label ID="lblRemarkError" runat="server" CssClass="text-danger small"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>


                                    </div>
                                    <div class="modal-footer">

                                        <asp:Button ID="btnupdate" Text="Confirm" CssClass="btn btn-primary" runat="server" OnClick="btnupdate_Click" ValidationGroup="FreeLaser" />

                                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>

                                    </div>
                                </div>
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
        // Server-side pagination is active: disable DataTables paging/searching
        // so the search box queries the whole database instead of this page.
        new DataTable('#completedGrid', {
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

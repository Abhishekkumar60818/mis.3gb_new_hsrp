<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="payment-confirmation.aspx.cs" Inherits="payment_confirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    <link href="css2.css" rel="stylesheet" />
    <!-- Feather icon-->

    <div class="page-wrapper compact-wrapper" id="pageWrapper">

        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h5>Party Payment Confirmation </h5>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Party Payment Confirmation</li>

                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div id="pnlView" runat="server">

                    <div class="card">
                        <div class="card-header pb-0">
                        </div>
                        <div class="card-body">
                            <div class="table-responsive theme-scrollbar">
                                <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                    <table class="display dataTable no-footer" id="basic-1" role="grid" aria-describedby="basic-1_info">
                                        <thead>
                                            <tr role="row">
                                                <th class="sorting_asc" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" style="width: auto;">Date</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" style="width: auto;">Name</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto;">Amount</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Age: activate to sort column ascending" style="width: auto;">Payment Details</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending" style="width: auto;">Screenshot</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>

                                            <asp:Repeater ID="rptrUser" runat="server" OnItemCommand="rptrUser_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="table-plus"><%# Eval("date", "{0:dd/MM/yyyy}") %></td>
                                                        <td><%#Eval("name") %></td>
                                                        <td><%#Eval("amount") %></td>
                                                        <td><%#Eval("transactionno") %> , <%#Eval("mode") %></td>
                                                        <td><a href='seller/Img/<%#Eval("photo") %>' download>Download</a></td>
                                                        <td>
                                                            <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="btn btn-success btnnew" Text=" Confirm" CommandArgument='<%#Eval("id") %>' CommandName="edit"></asp:LinkButton></td>
                                                        <button style="display: none;" id="btnShowPopup" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
                                                            Launch static backdrop modal
                                                        </button>
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
            <div class="main-container">
                <div class="pd-ltr-20 customscroll customscroll-10-p height-100-p xs-pd-20-10">
                    <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-dialog modal-lg modal-dialog-centered">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title" id="myLargeModalLabel">Payment Confirmation</h4>
                                        <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblLastICCid" runat="server" Visible="false"></asp:Label>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                        <div class="row">
                                            <div class="col-md-6 col-sm-12">
                                                <div class="form-group">
                                                    <label>Date</label>
                                                    <asp:Label ID="lblDate" runat="server" CssClass="form-control"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-12">
                                                <div class="form-group">
                                                    <label>Dealer Name</label>
                                                    <asp:Label ID="lblDealerName" runat="server" CssClass="form-control"></asp:Label>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-md-6 col-sm-12">
                                                <div class="form-group">
                                                    <label>Amount</label>
                                                    <asp:Label ID="lblAmount" runat="server" CssClass="form-control"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-12">
                                                <div class="form-group">
                                                    <label>Details</label>
                                                    <asp:Label ID="lblDetails" runat="server" CssClass="form-control"></asp:Label>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12">
                                                <div class="form-group">
                                                    <label>Remark</label>
                                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control" required></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="modal-footer">

                                        <asp:Button ID="btnupdate" Text="Confirm" CssClass="btn btn-primary" runat="server" OnClick="btnupdate_Click" />
                                        <asp:Button ID="btnCancel" Text="Decline" CssClass="btn btn-danger" runat="server" OnClick="btnCancel_Click" />
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
</asp:Content>


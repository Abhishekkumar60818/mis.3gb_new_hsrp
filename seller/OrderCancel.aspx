<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="OrderCancel.aspx.cs" Inherits="seller_OrderCancel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                            <h3>Order Cancel</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="default.aspx"><i data-feather="home"></i></a></li>

                                <li class="breadcrumb-item active">Order Cancel</li>
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
                        <div class="table-responsive theme-scrollbar">
                            <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                <table id="exampless" class="display nowrap" style="width: 100%">
                                    <thead>
                                        <tr role="row">
                                            <th>Order Date</th>
                                            <th>Customer Name</th>
                                            <%--<th>Contact No.</th>--%>
                                            <th>City Name</th>

                                            <th>Registration Number</th>
                                            <th>Chassis Number</th>
                                            <th>Engine Number</th>
                                            <th>Vehicle Type</th>
                                            <th>Vehicle Class</th>
                                            <th>Fuel Type</th>
                                            <th>Receipt</th>

                                            <%-- <th>Order Type</th>
                                                <th>Date of Registration</th>
                                                <th>Date of Manufacture</th>--%>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptrUser" runat="server" OnItemCommand="rptrUser_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="table-plus"><%# Eval("orderdate", "{0:dd/MM/yyyy}") %></td>
                                                    <td><%#Eval("name") %></td>
                                                    <%--<td><%#Eval("contactno") %></td>--%>
                                                    <td><%#Eval("city") %></td>
                                                    <td><%#Eval("registrationno") %></td>
                                                    <td><%#Eval("chasisno") %></td>
                                                    <td><%#Eval("engineno") %></td>
                                                    <td><%#Eval("vehicletype") %></td>
                                                    <td><%#Eval("classtype") %></td>
                                                    <td><%#Eval("fueltype") %></td>
                                                    <td>
                                                        <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible='<%#Eval("npid").ToString() =="1"  %>'>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="10px" CssClass="fa fa-download" Text=" Invoice" CommandArgument='<%#Eval("id") %>' CommandName="download"></asp:LinkButton>
                                                        </asp:PlaceHolder>
                                                        <asp:PlaceHolder ID="PlaceHolder4" runat="server" Visible='<%#Eval("npid").ToString() =="0"  %>'>
                                                            <label style="color: red; font-weight: bold">NA</label>
                                                        </asp:PlaceHolder>
                                                    </td>
                                                    <%-- <td><%#Eval("ordertype") %></td>
                                                <td><%# Eval("registrationdate", "{0:dd/MM/yyyy}") %></td>
                                                <td><%# Eval("manufacturedate", "{0:dd/MM/yyyy}") %></td>--%>
                                                    <%--<td><asp:LinkButton ID="lnkRemove" runat="server" CssClass="fa fa-remove btn btn-danger" Text=" Cancel Order" CommandArgument='<%#Eval("id") %>' CommandName="delete"></asp:LinkButton></td>--%>
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
        new DataTable('#exampless', {
            layout: {
                topStart: {
                    buttons: ['csv', 'excel', 'pdf', 'print']
                }
            }
        });
    </script>
</asp:Content>

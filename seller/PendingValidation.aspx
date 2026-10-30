<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="PendingValidation.aspx.cs" Inherits="seller_PendingValidation" %>

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

                                <li class="breadcrumb-item active">Vahan Update</li>
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
                                <table id="example" class="display nowrap" style="width: 100%">
                                    <thead>
                                        <tr role="row">
                                            <th>Date</th>
                                            <th>Name</th>
                                            <th>Contact No.</th>
                                            <th>Registration No.</th>
                                            <th>Vehicle Type</th>
                                            <th>Vahaan Status</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptrUser" runat="server" OnItemCommand="rptrUser_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="table-plus"><%# Eval("orderdate", "{0:dd/MM/yyyy}") %></td>
                                                    <td><%#Eval("name") %></td>
                                                    <td><%#Eval("contactno") %></td>
                                                    <%--<td><%#Eval("city") %></td>
                                                <td><%#Eval("state") %></td>--%>
                                                    <td><%#Eval("registrationno") %></td>
                                                    <%--<td><%#Eval("chasisno") %></td>
                                                <td><%#Eval("engineno") %></td>--%>
                                                    <td><%#Eval("vehicletype") %></td>
                                                    <td><%#Eval("vupdate") %></td>
                                                    <%--<td><%#Eval("model") %></td>
                                                <td><%#Eval("fueltype") %></td>
                                                <td><%#Eval("classtype") %></td>
                                                <td><%#Eval("ordertype") %></td>
                                                <td><%# Eval("registrationdate", "{0:dd/MM/yyyy}") %></td>
                                                <td><%# Eval("manufacturedate", "{0:dd/MM/yyyy}") %></td>--%>
                                                    <%--  <td>
                                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%#Eval("status").ToString() =="1"  %>'>
                                                        <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible='<%#Eval("npid").ToString() =="0"  %>'>
                                                            <label style="color: red;">Pending</label>
                                                        </asp:PlaceHolder>
                                                        <asp:PlaceHolder ID="PlaceHolder4" runat="server" Visible='<%#Eval("npid").ToString() !="0"  %>'>
                                                            <label style="color: green;">Completed</label>
                                                        </asp:PlaceHolder>
                                                    </asp:PlaceHolder>
                                                    <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible='<%#Eval("status").ToString() =="0"  %>'>
                                                        <label style="color: red;">Cancelled</label>
                                                    </asp:PlaceHolder>
                                                </td>--%>
                                                    <td>
                                                        <button style="display: none;" id="btnShowPopup" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
                                                            Launch static backdrop modal
                                                        </button>
                                                        <asp:PlaceHolder ID="PlaceHolder409" runat="server" Visible='<%#Eval("npid").ToString() !="0"  %>'>

                                                            <asp:LinkButton ID="lnkUpdate" runat="server" Font-Size="9px" CssClass="fa fa-download" Text=" Update Vahaan" CommandArgument='<%#Eval("id") %>' CommandName="edit"></asp:LinkButton>
                                                        </asp:PlaceHolder>

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
            <div class="main-container">
                <div class="pd-ltr-20 customscroll customscroll-10-p height-100-p xs-pd-20-10">
                    <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-dialog modal-lg modal-dialog-centered">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title" id="myLargeModalLabel">Vahaan Status</h4>
                                        <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblLastICCid" runat="server" Visible="false"></asp:Label>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12">
                                                <div class="form-group">

                                                    <asp:Label ID="lblRemark" runat="server" CssClass="form-control"></asp:Label>
                                                </div>
                                            </div>

                                        </div>



                                    </div>
                                    <div class="modal-footer">

                                        <asp:Button ID="btnupdate" Text="Close" CssClass="btn btn-primary" runat="server" OnClick="btnupdate_Click" />



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
        new DataTable('#example', {
            layout: {
                topStart: {
                    buttons: ['csv', 'excel', 'pdf', 'print']
                }
            }
        });
    </script>
</asp:Content>

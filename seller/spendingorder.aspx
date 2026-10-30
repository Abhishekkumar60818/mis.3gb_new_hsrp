<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="spendingorder.aspx.cs" Inherits="seller_spendingorder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .multiselect-container {
            max-height: 300px !important;
            overflow: scroll !important;
            min-width: 220px !important;
        }
    </style>
    <script type="text/javascript">
        function ShowPopup() {
            $("#Updatemodal").click();
        }
    </script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/2.1.8/css/dataTables.dataTables.css">
<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/3.2.0/css/buttons.dataTables.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scrpt" runat="server"></asp:ScriptManager>

    <div class="page-wrapper compact-wrapper" id="pageWrapper">

        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-dialog modal-lg modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myLargeModalLabel">Laser Details Update</h4>
                            <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblLastICCid" runat="server" Visible="false"></asp:Label>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>Vehicle No.</label>
                                        <asp:Label ID="lblVehicleNo" runat="server" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>Chassis No.</label>
                                        <asp:Label ID="lblChassisNo" runat="server" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>Engine No.</label>
                                        <asp:Label ID="lblEngneNo" runat="server" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>Front Laser No.</label>

                                        <asp:TextBox ID="txtFrontLaserNo" onkeydown="return (event.keyCode!=13);" runat="server" CssClass="form-control" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12">
                                    <div class="form-group">
                                        <label>Rear Laser No.</label>
                                        <br />
                                        <asp:TextBox ID="txtRearLaserNo" onkeydown="return (event.keyCode!=13);" runat="server" CssClass="form-control" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <label class="form-label" for="validationCustom02">Select Type</label>
                                    <asp:DropDownList ID="ddlFlag" runat="server" CssClass="form-control">
                                        <asp:ListItem>New Both HSRP</asp:ListItem>
                                        <asp:ListItem>Duplicate Both HSRP</asp:ListItem>
                                        <asp:ListItem>Duplicate Front HSRP</asp:ListItem>
                                        <asp:ListItem>Duplicate Rear HSRP</asp:ListItem>
                                        <asp:ListItem>Old Both HSRP</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>


                        </div>
                        <div class="modal-footer">

                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                            <asp:Button ID="btnupdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnupdate_Click" />
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>

                        </div>
                    </div>
                </div>
            </div>
        </div>

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
                        <div class="table-responsive theme-scrollbar">
                            <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                <table id="example" class="display nowrap" style="width: 100%">
                                    <thead>
                                        <tr role="row">
                                            <th class="sorting_asc" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" style="width: auto;">Order Date</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Dealer Name</th>
                                            <%--<th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" style="width: auto">Name</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto">Contact No.</th>--%>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto">City Name</th>
                                            <%--<th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto">State</th>--%>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Registration No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Chassis No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Engine No.</th>

                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Vehicle Type</th>
                                            <%--                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Model</th>
                                            --%>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Class Type</th>
                                            <%--<th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Order Type</th>--%>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Fuel Type</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Date of Registration</th>
                                            <%--
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Date Of Manufacture</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">TLP Print</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Order Status</th>--%>


                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptrUser" runat="server" OnItemCommand="rptrUser_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="table-plus"><%# Eval("orderdate", "{0:dd/MM/yyyy}") %></td>
                                                    <td><%#Eval("DName") %></td>
                                                    <%-- <td><%#Eval("name") %></td>
                                                    <td><%#Eval("contactno") %></td>--%>
                                                    <td><%#Eval("city") %></td>
                                                    <%--<td><%#Eval("state") %></td>--%>
                                                    <td><%#Eval("registrationno") %></td>
                                                    <td><%#Eval("chasisno") %></td>
                                                    <td><%#Eval("engineno") %></td>
                                                    <td><%#Eval("vehicletype") %></td>
                                                    <%--<td><%#Eval("model") %></td>
                                                    --%>
                                                    <td><%#Eval("classtype") %></td>
                                                    <%--<td><%#Eval("ordertype") %></td>--%>
                                                    <td><%#Eval("fueltype") %></td>
                                                    <td><%# Eval("registrationdate", "{0:dd/MM/yyyy}") %></td>
                                                    <%--
                                                    <td><%# Eval("manufacturedate", "{0:dd/MM/yyyy}") %></td>
                                                    <td><%#Eval("tlp") %></td>
                                                    <td>
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

                                                        <asp:LinkButton ID="lnkUpdate" Font-Size="10px" runat="server" CssClass="fa fa-edit" Text=" Update Plate" CommandArgument='<%#Eval("id") %>' CommandName="edit"></asp:LinkButton>
                                                        <button id="Updatemodal" style="display: none" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
                                                            Launch static backdrop modal
                                                        </button>
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

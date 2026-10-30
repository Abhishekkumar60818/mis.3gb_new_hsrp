<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="Payconfirm.aspx.cs" Inherits="seller_Payconfirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="page-wrapper compact-wrapper" id="pageWrapper">
         <div class="modal fade" id="Updatemodal">
                <div class="modal-dialog modal-lg modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myLargeModalLabel">Payment Confirmation</h4>
                            <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblLastICCid" runat="server" Visible="false"></asp:Label>
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
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
                            <asp:Button ID="btnCancel" Text="Decline" CssClass="btn btn-primary" runat="server" OnClick="btnCancel_Click" />
                            <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>

                        </div>
                    </div>
                </div>
            </div>
        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Online Completed Order</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="default.aspx"><i data-feather="home"></i></a></li>
                                
                                <li class="breadcrumb-item active">Online Completed Order</li>
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
                                <table class="display dataTable no-footer" id="basic-1" role="grid" aria-describedby="basic-1_info">
                                    <thead>
                                        <tr role="row">
                                            <th class="sorting_asc" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" style="width: auto;">Id</th>
                                            <th class="sorting_asc" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" style="width: auto;">Vehicle</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" style="width: auto">Manufacturer</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto">State</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto">Class</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto">Fuel</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto">Bharat Stage</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Registration Date</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Registration No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Chassis No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Engine No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Owner Name</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Contact No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Email</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">GST No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">State</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">City</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Billing Address</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Shipping Address</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Rate</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Courier Charges</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">GST</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Net Amount</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Order Status</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Order Date</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">RC Copy</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Frame</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto">Action</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptrUser" runat="server" OnItemCommand="rptrUser_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="table-plus">
                                                <%#Eval("id") %>
                                            </td>
                                            <%--                                            <td >
                                                   </td>--%>
                                            <td><%#Eval("vehicle") %></td>
                                            <td><%#Eval("manufacturer") %></td>
                                            <td><%#Eval("state") %></td>
                                            <td><%#Eval("classs") %></td>
                                            <td><%#Eval("fuel") %></td>
                                            <td><%#Eval("bharatstage") %></td>
                                            <td><%# Eval("registrationdate", "{0:dd/MM/yyyy}") %></td>
                                            <td><%#Eval("registrationno") %></td>
                                            <td><%#Eval("chasisno") %></td>
                                            <td><%#Eval("engineno") %></td>
                                            <td><%#Eval("ownername") %></td>
                                            <td><%#Eval("contactno") %></td>
                                            <td><%#Eval("email") %></td>
                                            <td><%#Eval("gstno") %></td>
                                            <td><%#Eval("states") %></td>
                                            <td><%#Eval("city") %></td>
                                            <td><%#Eval("address") %></td>
                                            <td><%#Eval("Address2") %></td>
                                            <td><%#Eval("rate") %></td>
                                            <td><%#Eval("couriercharages") %></td>
                                            <td><%#Eval("gst") %></td>
                                            <td><%#Eval("netamount") %></td>
                                            <td><%#Eval("orderstatus") %></td>
                                            <td><%# Eval("date", "{0:dd/MM/yyyy}") %></td>
                                            <td>
                                                <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible='<%#Eval("imgpath").ToString() !=""  %>'>
                                                    <a href='http://www.bookhsrponline.com/RC/<%#Eval("imgpath") %>' target="_blank" download="RCCopy"><i class="fa fa-download"></i>Download</a>
                                                </asp:PlaceHolder>
                                                <asp:PlaceHolder ID="PlaceHolder4" runat="server" Visible='<%#Eval("imgpath").ToString() ==""  %>'>
                                                    <label style="color: red;">NA</label>
                                                </asp:PlaceHolder>
                                            </td>
                                            <%--<td><%#Eval("dealer") %></td>--%>
											<td><%#Eval("frame") %></td>
                                            <td>
                                                <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="fa fa-edit" Text=" Update Plate" CommandArgument='<%#Eval("id") %>' CommandName="edit"></asp:LinkButton>
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
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="online-order.aspx.cs" Inherits="online_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            var today = new Date();
            var month = ('0' + (today.getMonth() + 1)).slice(-2);
            var day = ('0' + today.getDate()).slice(-2);
            var year = today.getFullYear();
            var date = year + '-' + month + '-' + day;
            $('[id*=txtStDate]').attr('max', date);
            $('[id*=txtEndDate]').attr('max', date);
            //$('[id*=txtDates]').attr('min', date);
            //$('[id*=txtCallBackDates]').attr('max', date);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <link href="css2.css" rel="stylesheet" />
    <!-- Feather icon-->

    <div class="page-wrapper compact-wrapper" id="pageWrapper">

        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Online Order</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Online Order</li>
                               
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                            <div id="pnlView" runat="server">

                <div class="card">
                    <div class="card-header pb-0">
                     <div class="row gutters" style="margin-bottom: 10px;">
                                    <%-- <div class="col-md-1"></div>--%>
                                    <div class="col-md-2">
                                        <div class="input-group control-dark">
                                            <asp:TextBox ID="txtStDate" runat="server" type="Date" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="input-group control-dark">
                                            <asp:TextBox ID="txtEndDate" runat="server" type="Date" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="input-group control-dark">
                                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass='form-control'>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="input-group control-dark">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSubmit_Click"></asp:Button>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="input-group control-dark">
                                            <asp:Button ID="btnImport" runat="server" Text="Excel Download" CssClass="btn btn-primary" OnClick="btnImport_Click"></asp:Button>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive theme-scrollbar">
                            <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                <table class="display dataTable no-footer" id="basic-1" role="grid" aria-describedby="basic-1_info">
                                    <thead>
                                        <tr role="row">
                                            <th class="sorting_asc" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" style="width: auto;">Order No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" style="width: auto;">Vehicle</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto;">Manufacturer</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Age: activate to sort column ascending" style="width: auto;">State</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending" style="width: auto;">Class</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" style="width: auto;">Fuel</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Bharat Stage</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Registration No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Chasis No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Engine No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Owner Name</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Contact No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Email</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">GST No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">State</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">City</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Billing Address</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Shipping Address</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Rate</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Courier Charges</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">GST</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Net Amount</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Order Status</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Order Date</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">RC Copy</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Embossing Name</th>
                                        </tr>
                                    </thead>
                                    <tbody>
  <asp:Repeater ID="rptrUser" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="table-plus"><%#Eval("id") %></td>
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
                                                                <a href='http://www.bookhsrponline.com/RC/<%#Eval("imgpath") %>' target="_blank" download="RCCopy" style="color: #35a9b4"><i class="fa fa-download"></i>Download</a>
                                                            </asp:PlaceHolder>
                                                            <asp:PlaceHolder ID="PlaceHolder4" runat="server" Visible='<%#Eval("imgpath").ToString() ==""  %>'>
                                                                <label style="color: red;">NA</label>
                                                            </asp:PlaceHolder>
                                                        </td>
                                                        <td><%#Eval("dealer") %></td>
                                                        <%--<td>
                                                            <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="btn btn-danger btnnew" Text=" cancel Order" CommandArgument='<%#Eval("id") %>' CommandName="edit"></asp:LinkButton>
                                                        </td>--%>
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
    </div>
</asp:Content>


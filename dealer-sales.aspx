<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="dealer-sales.aspx.cs" Inherits="dealer_sales" %>

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
                            <h3>Dealer sales</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Dealer sales</li>

                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div id="pnlView" runat="server">

                    <div class="card">
                        <div class="card-header pb-0">
                            <div class="row gutters">

                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="Select State" ControlToValidate="ddlStockist" ErrorMessage="* Select" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlStockist" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="Select Embossing" ControlToValidate="ddlStockist" ErrorMessage="* Select" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtStDate" runat="server" type="Date" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtEndDate" runat="server" type="Date" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSubmit_Click"></asp:Button>
                                </div>


                            </div>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive theme-scrollbar">
                                <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                    <table class="display dataTable no-footer" id="basic-1" role="grid" aria-describedby="basic-1_info">
                                        <thead>
                                            <tr role="row">
                                                <th class="sorting_asc" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" style="width: auto;">Date</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" style="width: auto;">Name</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto;">Contact No.</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Age: activate to sort column ascending" style="width: auto;">City</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending" style="width: auto;">State</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" style="width: auto;">Registration No.</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Chassis No.</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Engine No.</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Vehicle Type</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Model</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Fuel Type</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Class Type</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Order Type</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Date of Registration</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Date Of Manufacture</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Dealer Name</th>
                                            </tr>
                                        </thead>
                                        <tbody>

                                           <asp:Repeater ID="rptrUser" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="table-plus"><%# Eval("orderdate", "{0:dd/MM/yyyy}") %></td>
                                                        <td><%#Eval("name") %></td>
                                                        <td><%#Eval("contactno") %></td>
                                                        <td><%#Eval("city") %></td>
                                                        <td><%#Eval("state") %></td>
                                                        <td><%#Eval("registrationno") %></td>
                                                        <td><%#Eval("chasisno") %></td>
                                                        <td><%#Eval("engineno") %></td>
                                                        <td><%#Eval("vehicletype") %></td>
                                                        <td><%#Eval("model") %></td>
                                                        <td><%#Eval("fueltype") %></td>
                                                        <td><%#Eval("classtype") %></td>
                                                        <td><%#Eval("ordertype") %></td>
                                                        <td><%# Eval("registrationdate", "{0:dd/MM/yyyy}") %></td>
                                                        <td><%# Eval("manufacturedate", "{0:dd/MM/yyyy}") %></td>
                                                        <%--<td>
                                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%#Eval("status").ToString() =="1"  %>'>
                                                        <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible='<%#Eval("npid").ToString() =="0"  %>'>
                                                            <label style="color: red;">Pending</label>
                                                        </asp:PlaceHolder>
                                                        <asp:PlaceHolder ID="PlaceHolder4" runat="server" Visible='<%#Eval("npid").ToString() !="1"  %>'>
                                                            <label style="color: green;">Completed</label>
                                                        </asp:PlaceHolder>
                                                    </asp:PlaceHolder>
                                                    <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible='<%#Eval("status").ToString() =="0"  %>'>
                                                        <label style="color: red;">Cancelled</label>
                                                    </asp:PlaceHolder>
                                                </td>--%>
                                                        <td><%#Eval("DName") %></td>
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


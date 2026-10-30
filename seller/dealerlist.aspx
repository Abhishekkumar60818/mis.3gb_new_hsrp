<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="dealerlist.aspx.cs" Inherits="seller_dealerlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                            <h3>Dealers</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Dealers</li>

                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
              
                <div id="pnlView" runat="server">
                    <div class="card">
                       
                        <div class="card-body">
                            <div class="table-responsive ">
                                <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                    <table class="display dataTable no-footer" id="basic-1" role="grid" aria-describedby="basic-1_info">
                                        <thead>
                                            <tr role="row">
                                                <th>#</th>
                                                <th>Dealer Name</th>
                                                <th>GST No.</th>
                                                <th>Contact No.</th>
                                                <th>City</th>
                                                <th>State</th>
                                                <th>User Name</th>
                                                <th>Password</th>
                                                <th>Contact Person</th>
                                                <th>Designation</th>
                                                <th>Embossing Centre</th>
                                                <th>OEM</th>
                                                <%--                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Type</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Embossing Name</th>--%>
                                                <th>Status</th>
                                              
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptrUser" runat="server" >
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="table-plus"><%# Container.ItemIndex +1 %></td>
                                                        <td><%#Eval("name") %></td>

                                                        <td><%#Eval("GSTNo") %></td>
                                                        <td><%#Eval("contactno") %></td>
                                                        <td><%#Eval("city") %></td>
                                                        <td><%#Eval("state") %></td>
                                                        <td><%#Eval("username") %></td>
                                                        <td><%#Eval("pass") %></td>
                                                        <td><%#Eval("contactperson") %></td>
                                                        <td><%#Eval("designation") %></td>
                                                        <td><%#Eval("Stockists") %></td>
                                                        <td><%#Eval("OEM") %></td>
                                                        <%--<td><%#Eval("DType") %></td>--%>
                                                        <%-- <td><%# Eval("date", "{0:dd/MM/yyyy}") %></td>--%>
                                                        <%--<td><%#Eval("Stockists") %></td>--%>
                                                        <%--<td>
                                                            <asp:PlaceHolder ID="PlaceHolder5" runat="server" Visible='<%#Eval("Stockists").ToString() ==""  %>'>
                                                                <label style="color: green;">Company</label>
                                                            </asp:PlaceHolder>
                                                            <asp:PlaceHolder ID="PlaceHolder6" runat="server" Visible='<%#Eval("Stockists").ToString() !=""  %>'>
                                                                <label style="color: #35aeba;"><%#Eval("Stockists") %></label>
                                                            </asp:PlaceHolder>

                                                        </td>--%>
                                                        <td>
                                                            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%#Eval("status").ToString() =="1"  %>'>
                                                                <label style="color: green;">Active</label>
                                                            </asp:PlaceHolder>
                                                            <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible='<%#Eval("status").ToString() =="0"  %>'>
                                                                <label style="color: red;">Blocked</label>
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




            </div>
        </div>
    </div>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="stock-state-wise.aspx.cs" Inherits="stock_state_wise" %>

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
                            <h5>Stock State Wise Report</h5>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Stock State Wise Report</li>

                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="row gutters">
                    <div class="col-md-1"></div>
                    <%--<div class="col-md-2">
                    <label>State</label>
                </div>--%>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="Select State" ControlToValidate="ddlState" ErrorMessage="* Select" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="btn btn-primary" OnClick="btnSearch_Click"></asp:Button>

                    </div>

                </div>
                <div id="pnlStockistwise" runat="server">

                    <div class="card">
                        <div class="card-header pb-0">
                        </div>
                        <div class="card-body">
                            <div class="table-responsive theme-scrollbar">
                                <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                    <table class="display dataTable no-footer" id="basic-1" role="grid" aria-describedby="basic-1_info">
                                        <thead>
                                            <tr role="row">
                                                <th class="sorting_asc" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" style="width: auto;">#</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" style="width: auto;">Dealer Name</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto;">Current Stock</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Age: activate to sort column ascending" style="width: auto;">Age</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptrDealer" runat="server" OnItemCommand="rptrDealer_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="table-plus"><%# Container.ItemIndex +1 %></td>
                                                        <td><%#Eval("name") %></td>
                                                        <td>
                                                            <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="btn btn-dark remove-from-cart mybtns" Text='<%#Eval("Stocks") %>' CommandArgument='<%#Eval("id") %>' CommandName="edit"></asp:LinkButton>
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
                <div id="pnlView" runat="server">
                <div class="row gutters">
                    <div class="colxxl-12 col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                        <div class="card gradient-dark-grey">
                            <div class="card-body">
                                <h5><asp:Label ID="lblDistributorName" runat="server"></asp:Label></h5>
                                <div class="table-responsive">
                                    <table id="example" class="table table-striped table-bordered nowrap m-0" style="width: 100%">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>Laser No.</th>
                                                <th>Class</th>
                                                <th>Size</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptrUser" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="table-plus">
                                                            <%# Container.ItemIndex +1 %>
                                                        </td>
                                                        <td><%#Eval("laserno") %></td>
                                                        <td><%#Eval("type") %></td>
                                                        <td><%#Eval("sizes") %></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                    </table>
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


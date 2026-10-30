<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="fuel-type.aspx.cs" Inherits="fuel_type" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page-wrapper compact-wrapper" id="pageWrapper">

        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Fuel Type</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Fuel Type</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                 <div id="pnlAdd" runat="server">
                <div class="row gutters">

                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                        <div class="card card gradient-dark-grey">
                            <div class="card-body">
                                <div class="row gutters">
                                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">Fuel Type</div>
                                            <div class="input-group control-dark">
                                                <asp:TextBox ID="txtStateName" runat="server" CssClass="form-control" placeholder="Enter Fuel Type"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">
                                                &nbsp;
                                                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                            </div>
                                            <div>
                                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-info" OnClick="btnSubmit_Click" />
                                                &nbsp;<a href="fuel-type.aspx" class="btn btn-dark">Back</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>



                </div>
            </div>
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
                                            <th class="sorting_asc" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" style="width: 126.625px;">Fuel Type</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" style="width: 207.75px;">Status</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: 98.9531px;">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        
                                            <asp:Repeater ID="rptrUser" runat="server" OnItemCommand="rptrUser_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="table-plus"><%#Eval("type") %></td>
                                                        <%--<td><%#Eval("name") %></td>--%>
                                                        <td>
                                                            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%#Eval("status").ToString() =="1"  %>'>
                                                                <label style="color: green;">Active</label>
                                                            </asp:PlaceHolder>
                                                            <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible='<%#Eval("status").ToString() =="0"  %>'>
                                                                <label style="color: red;">Blocked</label>
                                                            </asp:PlaceHolder>

                                                        </td>
                                                        <td>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-success btnnew" Text=" Edit" CommandArgument='<%#Eval("id") %>' CommandName="edit"></asp:LinkButton>
                                                            <asp:PlaceHolder ID="PlaceHolder5" runat="server" Visible='<%#Eval("status").ToString() =="1"  %>'>
                                                                <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-warning btnnew" Text=" Block" CommandArgument='<%#Eval("id") %>' CommandName="delete"></asp:LinkButton>
                                                            </asp:PlaceHolder>
                                                            <asp:PlaceHolder ID="PlaceHolder6" runat="server" Visible='<%#Eval("status").ToString() =="0"  %>'>
                                                                <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btn btn-danger btnnew" Text=" UnBlock" CommandArgument='<%#Eval("id") %>' CommandName="unblock"></asp:LinkButton>
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
                 <div id="pnlUpdate" runat="server">
                <div class="row gutters">

                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                        <div class="card card gradient-dark-grey">
                            <div class="card-body">
                                <div class="row gutters">
                                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div style="display: none;">
                                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                            </div>
                                            <div class="form-label">Fuel Type</div>
                                            <div class="input-group control-dark">
                                                <asp:TextBox ID="utxtStateName" runat="server" CssClass="form-control" placeholder="Enter Fuel Type"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">
                                                &nbsp;
                                                <asp:Label ID="lblUpdateError" runat="server"></asp:Label>
                                                <div style="display: none;">
                                                    <asp:Label ID="lblId" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div>
                                                <asp:Button ID="btnUpdate" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                                                &nbsp;<a href="fuel-type.aspx" class="btn btn-dark">Back</a>
                                            </div>
                                        </div>
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


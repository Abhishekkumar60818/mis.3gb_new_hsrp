<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="rate-chart.aspx.cs" Inherits="rate_chart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page-wrapper compact-wrapper" id="pageWrapper">

        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Rate Chart</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Rate Chart</li>
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
                                        <div class="col-md-3 col-sm-12">
                                            <div class="form-group">
                                                <div class="form-label">No. Of Plate</div>
                                                <div class="input-group control-dark">
                                                    <asp:TextBox ID="txtManufacturerCompany" runat="server" type="Number" CssClass="form-control" placeholder="Enter No. Of Plate"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12">
                                            <div class="form-group">
                                                <div class="form-label">Type</div>
                                                <div class="input-group control-dark">
                                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-select"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    
                                        <div class="col-md-3 col-sm-12">
                                            <div class="form-group">
                                                <div class="form-label">Vehicle Class</div>
                                                <div class="input-group control-dark">
                                                    <asp:DropDownList ID="ddlVehicleClass" runat="server" CssClass="form-select"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12">
                                            <div class="form-group">

                                                <div class="form-label">Vehicle Type</div>
                                                <div class="input-group control-dark">
                                                    <asp:DropDownList ID="ddlVehicleType" runat="server" CssClass="form-select"></asp:DropDownList>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row gutters">
                                        <div class="col-md-4 col-sm-12">
                                            <div class="form-group">
                                                <label class="form-label">Rate</label>
                                                <div class="input-group control-dark">
                                                    <asp:TextBox ID="txtRate" runat="server" CssClass="form-control" placeholder="Enter Rate"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 col-sm-12">
                                            <div class="form-group">
                                                <label class="form-label">Other Amount</label>
                                                <div class="input-group control-dark">
                                                    <asp:TextBox ID="txtOtherAmount" runat="server" CssClass="form-control" placeholder="Enter Other Amount"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 col-sm-12">
                                            <div class="form-group">
                                                <label class="form-label">Select Dealer</label>
                                                <div class="input-group control-dark">
                                                    <asp:DropDownList ID="ddlDelaer" runat="server" CssClass="form-select"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row gutters">
                                        <div class="col-md-12 col-sm-12">
                                            <div class="form-group" style="padding-top: 1.9rem;">
                                                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-info" OnClick="btnSubmit_Click" />
                                                &nbsp;<a href="rate-chart.aspx" class="btn btn-dark">Back</a>
                                            </div>
                                        </div>

                                    </div>

                                </div>
                            </div>
                        </div>



                    </div>
                </div>
                <asp:Panel ID="pnlView" runat="server">

                    <div class="card">
                        <div class="card-header pb-0">
                        </div>
                        <div class="card-body">
                            <div class="table-responsive theme-scrollbar">
                                <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                    <div class="row gutters">
                                        <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        </div>
                                        <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        </div>
                                        <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                            <div class="mb-3" style="text-align: right">
                                                <asp:LinkButton ID="lnkbtnAdd" runat="server" Text="+ Add" OnClick="lnkbtnAdd_Click" CssClass="btn btn-primary btn-sm scroll-click"></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    <table class="display dataTable no-footer" id="basic-1" role="grid" aria-describedby="basic-1_info">
                                        <thead>
                                            <tr role="row">
                                                <th>#</th>
                                                <th>Dealer Name</th>
                                                <th>Type</th>
                                                <th>Vehicle Class</th>
                                                <th>Vehicle Type</th>
                                                <th>No. Of Plate</th>
                                                <th>Rate</th>
                                                <th>Other</th>
                                                <th>Tax</th>
                                                <th>Net Amount</th>
                                                <th>Status</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptrUser" runat="server" OnItemCommand="rptrUser_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="table-plus"><%# Container.ItemIndex +1 %></td>
                                                        <td><%#Eval("name") %></td>
                                                        <td><%#Eval("type") %></td>
                                                        <td><%#Eval("vehicleclass") %></td>
                                                        <td><%#Eval("vehicletype") %></td>
                                                        <td><%#Eval("manu_company") %></td>
                                                        <td><%#Eval("rate") %></td>
                                                        <td><%#Eval("other") %></td>
                                                        <td><%#Eval("tax") %></td>
                                                        <td><%#Eval("netamount") %></td>
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
                </asp:Panel>
                <div id="pnlUpdate" runat="server">
                    <div class="row gutters">

                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                            <div class="card card gradient-dark-grey">
                                <div class="card-body">
                                    <div class="row gutters">
                                        <div class="col-md-4 col-sm-12">
                                            <div class="form-group">
                                                <div class="form-label">No. Of Plate</div>
                                                <div class="input-group control-dark">
                                                    <asp:Label ID="lblDealerName" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 col-sm-12">
                                            <div class="form-group">
                                                <div class="form-label">No. Of Plate</div>
                                                <div class="input-group control-dark">
                                                    <asp:TextBox ID="etxtManufacturerCompany" runat="server" type="Number" CssClass="form-control" placeholder="Enter No. Of Plate"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 col-sm-12">
                                            <div class="form-group">
                                                <div class="form-label">Type</div>
                                                <div class="input-group control-dark">
                                                    <asp:DropDownList ID="eddlType" runat="server" CssClass="form-select"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row gutters">
                                        <div class="col-md-3 col-sm-12">
                                            <div class="form-group">
                                                <div class="form-label">Vehicle Class</div>
                                                <div class="input-group control-dark">
                                                    <asp:DropDownList ID="eddlVehicleClass" runat="server" CssClass="form-select"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12">
                                            <div class="form-group">

                                                <div class="form-label">Vehicle Type</div>
                                                <div class="input-group control-dark">
                                                    <asp:DropDownList ID="eddlVehicleType" runat="server" CssClass="form-select"></asp:DropDownList>

                                                </div>
                                            </div>
                                        </div>
                                    
                                        <div class="col-md-3 col-sm-12">
                                            <div class="form-group">
                                                <label class="form-label">Rate</label>
                                                <div class="input-group control-dark">
                                                    <asp:TextBox ID="etxtRate" runat="server" CssClass="form-control" placeholder="Enter Rate"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12">
                                            <div class="form-group">
                                                <label class="form-label">Other Amount</label>
                                                <div class="input-group control-dark">
                                                    <asp:TextBox ID="etxtOtherAmount" runat="server" CssClass="form-control" placeholder="Enter Other Amount"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row gutters">

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
                                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-info" OnClick="btnUpdate_Click" />
                                                    &nbsp;<a href="rate-chart.aspx" class="btn btn-dark">Back</a>
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
    </div>

</asp:Content>


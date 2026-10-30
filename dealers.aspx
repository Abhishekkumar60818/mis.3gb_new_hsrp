<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="dealers.aspx.cs" Inherits="dealers" %>

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
                <div id="pnlAdd" runat="server">
                    <div class="row gutters">

                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                            <div class="card card gradient-dark-grey">
                                <div class="card-body">
                                    <asp:UpdatePanel ID="updt" runat="server">
                                        <ContentTemplate>
                                            <div class="row gutters">
                                                <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Dealer Name</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Dealer Name" required></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Contact No.</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control" placeholder="Enter Contact No."></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Email</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row gutters">
                                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Delivery Address</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="txtDeliveryAddress" runat="server" CssClass="form-control" placeholder="Enter Delivery Address"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Registered Address</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Registered Address"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">State</div>
                                                        <div class="input-group control-dark">
                                                            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">City</div>
                                                        <div class="input-group control-dark">
                                                            <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-select"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row gutters">
                                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Pin Code</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="txtPinCode" runat="server" CssClass="form-control" placeholder="Enter Pin Code" required></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">User Name</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter User Name" required></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Password</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" required></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">GST No.</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="txtGSTNo" runat="server" CssClass="form-control" placeholder="Enter GST No."></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row gutters">
                                                <div class="col-xl-3 col-lg-3 col-md-3 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">OEM</div>
                                                        <div class="input-group control-dark">
                                                            <asp:DropDownList ID="ddlOEM" runat="server" CssClass="form-select">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-3 col-lg-3 col-md-3 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">assign embossing centre</div>
                                                        <div class="input-group control-dark">
                                                            <asp:DropDownList ID="ddlStockists" runat="server" CssClass="form-select" Enabled="false"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-3 col-lg-3 col-md-3 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Contact Person</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="txtContactPerson" runat="server" CssClass="form-control" placeholder="Contact Person"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-3 col-lg-3 col-md-3 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Designation</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control" placeholder="Designation"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row gutters">

                                                <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">
                                                            &nbsp;
                                              <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                                        </div>
                                                        <div>
                                                            <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-info" OnClick="btnSubmit_Click" />
                                                            &nbsp;<a href="dealers.aspx" class="btn btn-dark">Back</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

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
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <div class="row gutters">
                                                <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Dealer Name</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="utxtName" runat="server" CssClass="form-control" placeholder="Enter Embossing/Dealer Name" required></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Contact No.</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="utxtContactNo" runat="server" CssClass="form-control" placeholder="Enter Contact No."></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Email</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="utxtEmail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row gutters">
                                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Delivery Address</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="utxtDeliveryAddress" runat="server" CssClass="form-control" placeholder="Enter Delivery Address"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Registered Address</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="utxtAddress" runat="server" CssClass="form-control" placeholder="Enter Address"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">State</div>
                                                        <div class="input-group control-dark">
                                                            <asp:DropDownList ID="uddlState" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="uddlState_SelectedIndexChanged"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">City</div>
                                                        <div class="input-group control-dark">
                                                            <asp:DropDownList ID="uddlCity" runat="server" CssClass="form-select"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row gutters">
                                                <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Pin Code</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" placeholder="Enter Pin Code" required></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-3 col-lg-3 col-md-3 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">assign embossing centre</div>
                                                        <div class="input-group control-dark">
                                                            <asp:DropDownList ID="eddlStockists" runat="server" CssClass="form-select"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-3 col-lg-3 col-md-3 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">OEM</div>
                                                        <div class="input-group control-dark">
                                                            <asp:DropDownList ID="eddlOEM" runat="server" CssClass="form-select">

                                                                <%-- <asp:ListItem>Dealer</asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-3 col-lg-3 col-md-3 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">GST No.</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="etxtGSTNo" runat="server" CssClass="form-control" placeholder="Enter GST No."></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="row gutters">

                                                <div class="col-xl-4 col-lg-4 col-md-4 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Password</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="utxtPassword" runat="server" CssClass="form-control" placeholder="Enter GST No."></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-4 col-lg-4 col-md-4 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Contact Person</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="utxtContactPerson" runat="server" CssClass="form-control" placeholder="Contact Person"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-4 col-lg-4 col-md-4 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">Designation</div>
                                                        <div class="input-group control-dark">
                                                            <asp:TextBox ID="utxtDesignation" runat="server" CssClass="form-control" placeholder="Designation"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row gutters">

                                                <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                                    <div class="mb-3">
                                                        <div class="form-label">
                                                            &nbsp;
                                             <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                                            <div style="display: none;">
                                                                <asp:Label ID="lblId" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div>
                                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-info" OnClick="btnUpdate_Click" />
                                                            &nbsp;<a href="dealers.aspx" class="btn btn-dark">Back</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>
                <div id="pnlView" runat="server">
                    <div class="card">
                        <div class="card-header pb-0">
                            <div class="mb-3" style="text-align: right">
                                <asp:LinkButton ID="lnkbtnAdd" runat="server" Text="+ Add" OnClick="lnkbtnAdd_Click" CssClass="btn btn-dark"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive ">
                                <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                    <table class="display dataTable no-footer" id="basic-1" role="grid" aria-describedby="basic-1_info">
                                        <thead>
                                            <tr role="row">
                                                <th>#</th>
                                                <th>OEM</th>
                                                <th>Embossing Centre</th>

                                                <th>Dealer Name</th>
                                                <th>GST No.</th>

                                                <th>City</th>
                                                <th>State</th>
                                                <th>User Name</th>
                                                <th>Password</th>
                                                <th>Contact Person</th>
                                                <th>Designation</th>
                                                <th>Contact No.</th>

                                                <%--                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Type</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Embossing Name</th>--%>
                                                <th>Status</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptrUser" runat="server" OnItemCommand="rptrUser_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="table-plus"><%# Container.ItemIndex +1 %></td>
                                                        <td><%#Eval("OEM") %></td>
                                                        <td><%#Eval("Stockists") %></td>

                                                        <td><%#Eval("name") %></td>

                                                        <td><%#Eval("GSTNo") %></td>

                                                        <td><%#Eval("city") %></td>
                                                        <td><%#Eval("state") %></td>
                                                        <td><%#Eval("username") %></td>
                                                        <td><%#Eval("pass") %></td>
                                                        <td><%#Eval("contactperson") %></td>
                                                        <td><%#Eval("designation") %></td>
                                                        <td><%#Eval("contactno") %></td>

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
                                                        <td style="display: flex;">
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-success btnnew" Text=" Edit" CommandArgument='<%#Eval("id") %>' CommandName="edit"></asp:LinkButton>
                                                            <asp:PlaceHolder ID="PlaceHolder7" runat="server" Visible='<%#Eval("status").ToString() =="1"  %>'>
                                                                <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-warning btnnew" Text=" Block" CommandArgument='<%#Eval("id") %>' CommandName="delete"></asp:LinkButton>
                                                            </asp:PlaceHolder>
                                                            <asp:PlaceHolder ID="PlaceHolder8" runat="server" Visible='<%#Eval("status").ToString() =="0"  %>'>
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




            </div>
        </div>
    </div>
</asp:Content>

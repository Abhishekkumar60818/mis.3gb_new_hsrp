<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="rto-dto.aspx.cs" Inherits="rto_dto" %>

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
                            <h3>Rto/Dto</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Rto/Dto</li>

                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                            <div id="pnlView" runat="server">

                <div class="card">
                    <div class="card-header pb-0">
                        <div class="mb-3" style="text-align: right">
                            <asp:LinkButton ID="lnkbtnAdd" runat="server" Text="+ Add" OnClick="lnkbtnAdd_Click" CssClass="btn btn-primary btn-sm scroll-click"></asp:LinkButton>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive theme-scrollbar">
                            <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                <table class="display dataTable no-footer" id="basic-1" role="grid" aria-describedby="basic-1_info">
                                    <thead>
                                        <tr role="row">
                                            <th class="sorting_asc" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" style="width: auto;">Id</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" style="width: auto;">RTO Code</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto;">City</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width: auto;">State</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Age: activate to sort column ascending" style="width: auto;">UserName</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending" style="width: auto;">Password</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" style="width: auto;">Status</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Action: activate to sort column ascending" style="width: auto;">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <asp:Repeater ID="rptrUser" runat="server" OnItemCommand="rptrUser_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="table-plus"><%#Eval("id") %></td>
                                                    <td><%#Eval("rtocode") %></td>
                                                    <td><%#Eval("city") %></td>
                                                    <td><%#Eval("state") %></td>
                                                    <td><%#Eval("username") %></td>
                                                    <td><%#Eval("passwords") %></td>
                                                    <td>
                                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%#Eval("status").ToString() =="1"  %>'>
                                                            <label style="color: green;">Active</label>
                                                        </asp:PlaceHolder>
                                                        <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible='<%#Eval("status").ToString() =="0"  %>'>
                                                            <label style="color: red;">Blocked</label>
                                                        </asp:PlaceHolder>
                                                    </td>
                                                    <td style="display:flex;">
                                                        <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="btn btn-success btnnew" Text=" Edit" CommandArgument='<%#Eval("id") %>' CommandName="edit"></asp:LinkButton>
                                                        <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible='<%#Eval("status").ToString() =="1"  %>'>
                                                            <asp:LinkButton ID="lnkRemove" runat="server" CssClass="btn btn-warning btnnew" Text=" Block" CommandArgument='<%#Eval("id") %>' CommandName="delete"></asp:LinkButton>
                                                        </asp:PlaceHolder>
                                                        <asp:PlaceHolder ID="PlaceHolder4" runat="server" Visible='<%#Eval("status").ToString() =="0"  %>'>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-danger btnnew" Text=" UnBlock" CommandArgument='<%#Eval("id") %>' CommandName="unblock"></asp:LinkButton>
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
            <div id="pnlAdd" runat="server">
                <div class="row gutters">

                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                        <div class="card card gradient-dark-grey">
                            <div class="card-body">
                                <div class="row gutters">
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">User Name</div>
                                            <div class="input-group control-dark">
                                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter User Name" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">Password</div>
                                            <div class="input-group control-dark">
                                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row gutters">
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">City</div>
                                            <div class="input-group control-dark">
                                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">RTO Code</div>
                                            <div class="input-group control-dark">
                                                <asp:TextBox ID="txtRTOCode" runat="server" CssClass="form-control" placeholder="Enter RTO Code" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">State</div>
                                            <div class="input-group control-dark">
                                                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row gutters">
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                            <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                                            
                                                &nbsp;<a href="rto-dto.aspx" class="btn btn-dark">Back</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>



                </div>
            </div>




            <div id="pnlUpdate" runat="server">
                <div class="row gutters">
                      <div style="display: none;">
                            <asp:Label ID="lblId" runat="server"></asp:Label>
                       </div>
                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                        <div class="card card gradient-dark-grey">
                            <div class="card-body">
                                <div class="row gutters">
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">User Name</div>
                                            <div class="input-group control-dark">
                                                <asp:TextBox ID="etxtUserName" runat="server" CssClass="form-control" placeholder="Enter User Name" required></asp:TextBox>
                                            </div>
                                    
                                        </div>
                                    </div>
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">Password</div>
                                            <div class="input-group control-dark">
                                                <asp:TextBox ID="etxtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row gutters">
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">State</div>
                                            <div class="input-group control-dark">
                                                <asp:DropDownList ID="eddlState" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="uddlState_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">City</div>
                                            <div class="input-group control-dark">
                                                <asp:DropDownList ID="eddlCity" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">RTO Code</div>
                                            <div class="input-group control-dark">
                                                <asp:TextBox ID="etxtRTOCode" runat="server" CssClass="form-control" placeholder="Enter RTO Code" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row gutters">
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                            <asp:Button ID="btnUpdate" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                                            
                                                <a href="rto-dto.aspx" class="btn btn-dark">Back</a>
                                             
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


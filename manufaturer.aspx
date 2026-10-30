<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="manufaturer.aspx.cs" Inherits="manufaturer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page-wrapper compact-wrapper" id="pageWrapper">

        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Manufacturer</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Manufacturer</li>
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
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">Manufacturer Name</div>
                                            <div class="input-group control-dark">
                                                <asp:TextBox ID="txtManufacturerName" runat="server" CssClass="form-control" placeholder="Enter Manufacturer Name"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">Select Vehicle Type</div>
                                            <div class="input-group control-dark">
                                                <asp:DropDownList ID="ddlVehicleType" runat="server" CssClass="form-control">
                                                    <asp:ListItem>Select Type</asp:ListItem>
                                                    <asp:ListItem>Motorcycle</asp:ListItem>
                                                    <asp:ListItem>Scooter</asp:ListItem>
                                                    <asp:ListItem>Three Wheeler</asp:ListItem>
                                                    <asp:ListItem>Four Wheeler</asp:ListItem>
                                                    <asp:ListItem>Heavy Moter</asp:ListItem>
                                                    <asp:ListItem>Other Commercial</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">
                                                &nbsp;
                                               <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                            </div>
                                            <div>
                                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-info" OnClick="btnSubmit_Click" />
                                                &nbsp;<a href="manufaturer.aspx" class="btn btn-dark">Back</a>
                                            </div>
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

                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                        <div class="card card gradient-dark-grey">
                            <div class="card-body">
                                <div class="row gutters">
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">Manufacturer Name</div>
                                            <div class="input-group control-dark">
                                                <asp:TextBox ID="utxtManufacturerName" runat="server" CssClass="form-control" placeholder="Enter Manufacturer Name"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div style="display: none;">
                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                            </div>
                                            <div class="form-label">Select Vehicle Type</div>
                                            <div class="input-group control-dark">
                                                <asp:DropDownList ID="uddlVehicleType" runat="server" CssClass="form-control">
                                                    <asp:ListItem>Select Type</asp:ListItem>
                                                    <asp:ListItem>Motorcycle</asp:ListItem>
                                                    <asp:ListItem>Scooter</asp:ListItem>
                                                    <asp:ListItem>Three Wheeler</asp:ListItem>
                                                    <asp:ListItem>Four Wheeler</asp:ListItem>
                                                    <asp:ListItem>Heavy Moter</asp:ListItem>
                                                    <asp:ListItem>Other Commercial</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12">
                                        <div class="mb-3">
                                            <div class="form-label">
                                                &nbsp;<div style="display: none;">
                                                    <asp:Label ID="lblId" runat="server"></asp:Label>
                                                </div>
                                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                            </div>
                                            <div>
                                                 <asp:Button ID="btnUpdate" runat="server" Text="Save" CssClass="btn btn-info" OnClick="btnUpdate_Click" />
                                                &nbsp;<a href="manufaturer.aspx" class="btn btn-dark">Back</a>
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
                                            <th class="sorting_asc" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" style="width:auto">Id</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" style="width:auto">Vehicle Type </th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending" style="width:auto">Manufacturer</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Age: activate to sort column ascending" style="width:auto">Status</th>
                                            <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending" style="width:auto">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                                    <asp:Repeater ID="rptrUser" runat="server" OnItemCommand="rptrUser_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("id") %></td>
                                                        <td><%#Eval("vtype") %></td>
                                                        <td><%#Eval("manufacture") %></td>
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
                               
                            </div>
                        </div>
                    </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>


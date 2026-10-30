<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="view" %>

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
                            <h3>Stock View</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Stock View</li>

                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div id="pnlView" runat="server">

                    <div class="card">
                        <div class="card-header pb-0">
                            <asp:UpdatePanel ID="updt" runat="server">
                                <ContentTemplate>
                                    <div class="row gutters">
                                        <div class="col-md-6">
                                            <label class="form-label">Select Row</label>
                                            <div class="input-group control-dark">
                                                <asp:DropDownList ID="ddlPageQuantity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageQuantity_SelectedIndexChanged">
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>50</asp:ListItem>
                                                    <asp:ListItem>100</asp:ListItem>
                                                    <asp:ListItem>250</asp:ListItem>
                                                    <asp:ListItem>500</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-3">
                                            <div class="input-group control-dark">
                                                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged" placeholder="Enter Laser No."></asp:TextBox>
                                            </div>
                                        </div>
                                        </div>
                                   
                                    <div class="card-body">
                                        <div class="table-responsive theme-scrollbar">
                                            <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                                <table class="display dataTable no-footer" role="grid" aria-describedby="basic-1_info">
                                                    <thead>
                                                        <tr role="row">
                                                            <th>#</th>
                                                            <th>Laser No.</th>
                                                            <th>Size</th>
                                                            <th>Class</th>
                                                            <th>Sold Status</th>
                                                            <th>Vehicle No</th>
                                                            <th>Status</th>
                                                            <%--                                                        <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Age: activate to sort column ascending" style="width: auto;">Sold Status</th>
                                                        <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending" style="width: auto;">Print</th>--%>
                                                            <th>Action</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Repeater ID="rptrUser" runat="server" OnItemCommand="rptrUser_ItemCommand">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td class="table-plus"><%# Container.ItemIndex +1 %></td>
                                                                    <td><%#Eval("laserno") %></td>
                                                                    <%-- <td><%# Eval("date", "{0:dd/MM/yyyy}") %></td>--%>
                                                                    <td><%#Eval("sizes") %></td>
                                                                    <td><%#Eval("classs") %></td>
                                                                    <td><%#Eval("soldstatus") %>-(<%#Eval("dealer") %>)</td>
                                                                    <td><%#Eval("RegistrationNo") %></td>
                                                                    <td><%#Eval("vahan") %></td>
                                                                    <%-- <td>
                                                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%#Eval("sstatus").ToString() =="0"  %>'>
                                                                        <label style="color: green;">In-Stock</label>
                                                                    </asp:PlaceHolder>
                                                                    <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible='<%#Eval("sstatus").ToString() =="1"  %>'>
                                                                        <label style="color: red;">Sold-Out</label>
                                                                    </asp:PlaceHolder>

                                                                </td>--%>
                                                                    <%--<td><a href='printsticker.aspx?id=<%#Eval("laserno") %>' target="_blank" class="fa fa-print">Print Barcode</a></td>--%>
                                                                    <td>

                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="fa fa-edit" Text=" Edit" CommandArgument='<%#Eval("id") %>' CommandName="edit"></asp:LinkButton>

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
                                            <div class="row gutters" style="width: 100%; margin-left: 15px; margin-right: 15px;">
                                                <div style="width: 33.33%; text-align: left; float: left;">
                                                    <asp:LinkButton ID="lnkPrevious" runat="server" OnClick="lnkPrevious_Click" CssClass="fa fa-arrow-circle-left" Text=" Previous"></asp:LinkButton>
                                                </div>
                                                <div style="width: 33.33%; text-align: center; float: left;">
                                                    <asp:Label ID="Label2" runat="server" Text="Page "></asp:Label>
                                                    <asp:Label ID="lblPage" Text="1" runat="server"></asp:Label>
                                                    <asp:Label ID="Label1" runat="server" Text=" from "></asp:Label>
                                                    <asp:Label ID="lblPageCount" runat="server"></asp:Label>
                                                </div>
                                                <div style="width: 33.33%; text-align: right; float: left;">
                                                    <asp:LinkButton ID="lnkNext" runat="server" OnClick="lnkNext_Click" CssClass="fa fa-arrow-circle-right" Text=" Next"></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>

                            </asp:UpdatePanel>
                            <div class="row gutters">
                                <div class="col-md-12" style="text-align: right; margin-bottom: 15px;">
                                    <asp:Button ID="btnDownload" runat="server" Text="Download Excel" CssClass="btn btn-primary" OnClick="btnDownload_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


            </div>
            <div id="pnlEdit" runat="server">

                <div class="row gutters">
                    <div class="colxxl-12 col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                        <div class="card gradient-dark-grey">
                            <div class="card-body">

                                <div class="row gutters">
                                    <div class="col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <div class="form-label">Select Size</div>
                                            <div class="input-group control-dark">
                                                <asp:DropDownList ID="ddlSize" runat="server" CssClass="form-control"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Please Select Size" ForeColor="Red"
                                                    ControlToValidate="ddlSize" InitialValue="Select Size"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <div class="form-label">Select Class</div>
                                            <div class="input-group control-dark">
                                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Please Select Class" ForeColor="Red"
                                                    ControlToValidate="ddlClass" InitialValue="Select Class"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <div class="form-label">Quantity</div>
                                            <div class="input-group control-dark">
                                                <asp:Label ID="lblLaserNo" runat="server" CssClass="form-control"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row gutters">
                                    <div class="col-md-12 col-sm-12">
                                        <div class="form-group" style="padding-top: 1.9rem;">
                                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-info" OnClick="btnUpdate_Click" />
                                            &nbsp;<a href="view.aspx" class="btn btn-dark">Back</a>
                                            <asp:Label ID="lblIds" runat="server" Visible="false"></asp:Label>
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


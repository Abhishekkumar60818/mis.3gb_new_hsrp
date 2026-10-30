<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="completed-high-security-registration-plate-with-colour-sticker.aspx.cs" Inherits="seller_completed_high_security_registration_plate_with_colour_sticker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .multiselect-container {
            max-height: 300px !important;
            overflow: scroll !important;
            min-width: 220px !important;
        }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $(".modelClose").click(function () {
                $('#Updatemodal').modal('hide');
            });
        });
    </script>
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
                            <h3>Completed</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Completed High Security Registration Plate With Colour Sticker</li>

                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="card">
                    <asp:Panel ID="pnlAdd" runat="server">
                        <div class="card-body">
                            <div class="row gutters" style="margin-bottom: 10px;">
                                <div class="col-md-2"></div>
                                <div class="col-md-3">
                                    <div class="input-group control-dark">
                                        <asp:TextBox ID="txtStDate" runat="server" type="Date" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="input-group control-dark">
                                        <asp:TextBox ID="txtEndDate" runat="server" type="Date" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="input-group control-dark">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSubmit_Click"></asp:Button>
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive theme-scrollbar">
                                <div id="basic-1_wrapper" class="dataTables_wrapper no-footer">
                                    <table class="display dataTable no-footer" id="basic-1" role="grid" aria-describedby="basic-1_info">
                                        <thead>
                                            <tr role="row">
                                                <th class="sorting_asc" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" style="width: auto;">Date</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" style="width: auto;">Dealer Name</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" style="width: auto;">Embossing Centre</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" style="width: auto;">Name</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" style="width: auto;">Registration No.</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" style="width: auto;">Chassis No.</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" style="width: auto;">Engine No.</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" style="width: auto;">Vehicle Type</th>
                                                
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" style="width: auto;">Front Laser Number</th>
                                                <th class="sorting" tabindex="0" aria-controls="basic-1" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" style="width: auto;">Rear Laser Number</th>
                                            </tr>
                                        </thead>
                                        <tbody>

                                            <asp:Repeater ID="rptrUser" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="table-plus"><%# Eval("orderdaate", "{0:dd/MM/yyyy}") %></td>
                                                        <td><%#Eval("DName") %></td>
                                                        <td>
                                                            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%#string.IsNullOrEmpty(Eval("ems").ToString())  %>'>
                                                                <%#Eval("DName") %>
                                                            </asp:PlaceHolder>
                                                            <asp:PlaceHolder ID="PlaceHolder4" runat="server" Visible='<%#!string.IsNullOrEmpty(Eval("ems").ToString())  %>'>
                                                                <%#Eval("ems") %>
                                                            </asp:PlaceHolder>
                                                        </td>
                                                        <td><%#Eval("ownername") %></td>
                                                        <td><%#Eval("registrationnumber") %></td>
                                                        <td><%#Eval("chasisnumber") %></td>
                                                        <td><%#Eval("enginenumber") %></td>
                                                        <td><%#Eval("vehicletype") %></td>
                                                        <td><%#Eval("flaserno") %></td>
<td><%#Eval("rleaserno") %></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>

                                </div>
                            </div>
                        </div>
                    </asp:Panel>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
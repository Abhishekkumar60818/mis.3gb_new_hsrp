<%@ Page Title="" Language="C#" MasterPageFile="~/seller/SellerMaster.master" AutoEventWireup="true" CodeFile="completed-online-order.aspx.cs" Inherits="seller_completed_online_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .multiselect-container {
            max-height: 300px !important;
            overflow: scroll !important;
            min-width: 220px !important;
        }
        .mybtn{
            font-weight:bold;
            font-size:15px;
        }
    </style>
    <script type="text/javascript">
        function ShowPopup() {
            $("#Updatemodal").click();
        }
    </script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/2.1.8/css/dataTables.dataTables.css">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/3.2.0/css/buttons.dataTables.css">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/3.2.0/css/buttons.dataTables.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scrpt" runat="server"></asp:ScriptManager>
    <link href="css2.css" rel="stylesheet" />
    <!-- Feather icon-->
    <div class="page-wrapper compact-wrapper" id="pageWrapper">
        <div class="page-body">









            <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-dialog modal-lg modal-dialog-centered">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title" id="myLargeModalLabel">Laser Details Update</h4>
                                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblLastICCid" runat="server" Visible="false"></asp:Label>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <label>Vehicle No.</label><br />
                                            <asp:Label ID="lblVehicleNo" runat="server" ></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <label>Chassis No.</label><br />
                                            <asp:Label ID="lblChassisNo" runat="server" ></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <label>Engine No.</label><br />
                                            <asp:Label ID="lblEngneNo" runat="server" ></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Front Laser No.</label>

                                            <asp:TextBox ID="txtFrontLaserNo" onkeydown="return (event.keyCode!=13);" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label>Rear Laser No.</label>
                                            <br />
                                            <asp:TextBox ID="txtRearLaserNo" onkeydown="return (event.keyCode!=13);" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>


                            </div>
                            <div class="modal-footer">

                                <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                <asp:Button ID="btnupdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnupdate_Click" />
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>

                            </div>
                        </div>
                    </div>
                </div>
            </div>







            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Pending</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Pending High Security Registration Plate For Electric Vehicle</li>

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

                                                <th>Date</th>
                                                <th>Order Type</th>
                                                <th>Dealer Name</th>
                                                <th>Embossing Centre</th>
                                                <th>Name</th>
                                                <th>Registration No.</th>
                                                <th>Chassis No.</th>
                                                <th>Engine No.</th>
                                                <th>Vehicle Type</th>
                                                <th>Front Laser No.</th>
                                                <th>Rear Laser No.</th>
                                                <th>Vaahan Status</th>
                                                <th>Order Details</th>
                                                <th>Update Vaahan</th>
                                            </tr>
                                        </thead>
                                        <tbody>

                                            <asp:Repeater ID="rptrUser" runat="server" OnItemCommand="rptrUser_ItemCommand">
                                                <itemtemplate>
                                                    <tr>
                                                        <td class="table-plus"><%# Eval("orderdaate", "{0:dd/MM/yyyy}") %></td>
                                                        <td><%#Eval("ordertype") %></td>
                                                        <td><%#Eval("DName") %></td>
                                                        <td>
                                                            <asp:PlaceHolder ID="PlaceHolder5" runat="server" Visible='<%#string.IsNullOrEmpty(Eval("ems").ToString())  %>'>
                                                                <%#Eval("DName") %>
                                                            </asp:PlaceHolder>
                                                            <asp:PlaceHolder ID="PlaceHolder6" runat="server" Visible='<%#!string.IsNullOrEmpty(Eval("ems").ToString())  %>'>
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
                                                        <td><%#Eval("vupdate") %></td>
                                                        <td>
                                                           <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="12px"  CssClass="mybtn" Text=" View Details" CommandArgument='<%#Eval("id") %>' CommandName="view"></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <button style="display: none;" id="Updatemodal" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
                                                                Launch static backdrop modal
                                                            </button>
                                                            <asp:PlaceHolder ID="PlaceHolder409" runat="server" Visible='<%#Eval("npid").ToString() =="1"  %>'>

                                                                <asp:LinkButton ID="lnkUpdate" runat="server" Font-Size="12px"  CssClass="mybtn" Text=" Update Vaahan" CommandArgument='<%#Eval("id") %>' CommandName="edit"></asp:LinkButton>
                                                            </asp:PlaceHolder>

                                                        </td>
                                                    </tr>
                                                </itemtemplate>
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
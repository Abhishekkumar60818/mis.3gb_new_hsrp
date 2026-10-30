<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="printsticker.aspx.cs" Inherits="printsticker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">  
        function PrintDiv() {
            var divContents = document.getElementById("printdivcontent").innerHTML;
            var printWindow = window.open('', '', 'height=200,width=400');
            printWindow.document.write('<html><head><title>Print DIV Content</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(divContents);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.print();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-wrapper compact-wrapper" id="pageWrapper">

        <div class="page-body">
            <div class="container-fluid">
                <div class="page-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>Print</h3>
                        </div>
                        <div class="col-sm-6">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx"><i data-feather="home"></i></a></li>
                                <li class="breadcrumb-item">Print</li>

                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">

                <div class="card">
                    <div style="display: none" class="card-header pb-0">
                        <div class="row gutters">
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:Panel ID="pnlView" runat="server">
                            <div class="pd-20 bg-white border-radius-4 box-shadow mb-30">

                                <div class="row">
                                    <div class="col-md-6">

                                        <div id="printdivcontent">
                                            <asp:Image ID="imgBarcode" runat="server" />

                                        </div>


                                    </div>
                                    <div class="col-md-6">
                                        <input type="button" class="btn btn-success fa fa-print" onclick="PrintDiv();" value="Print" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tlpprint.aspx.cs" Inherits="pdf_tlpprint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <%--    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.3.4/jspdf.min.js"></script>--%>
    <script type="text/javascript">
        function printDiv() {
            var printContents = document.getElementById("printableArea").innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            //document.body.innerHTML = originalContents;
            //var options = {};
            //var pdf = new jsPDF('p', 'pt', 'a4');
            //pdf.addHTML($("#printableArea"), 15, 15, options, function () {
            //    pdf.save('pageContent.pdf');
            //});
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="printableArea">
            <div class="container">
                <div class="row">



                    <table border="0" style="width: 100%;">
                        <tr>
                            <td colspan="2" style="line-height: 20px; text-align: right;">
                                <h5 style="font-weight: bold; line-height: 10px; font-size: 18.8976px;text-align: center;">TRANSPORT DEPARTMENT</h5>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="line-height: 20px;">
                                <h5 style="font-weight: bold; line-height: 10px; text-align: center; font-size: 18.8976px;">GOVT. OF <asp:Label ID="lblState" runat="server"></asp:Label></h5>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="line-height: 25px;">
                                <h5 style="font-weight: bold; line-height: 10px; text-align: center; font-size: 37.7952755906px;"><asp:Label ID="lblVehicleNo" runat="server"></asp:Label></h5>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="line-height: 25px;">
                                <h5 style="font-weight: bold; line-height: 10px; font-size: 9.44881889765px;text-align: center;"><asp:Label ID="lblLaserNo" runat="server"></asp:Label></h5>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="line-height: 20px;">
                                <h5 style="font-weight: bold; line-height: 10px; font-size: 37.7952755906px; text-align: center;"><asp:Label ID="lblYear" runat="server"></asp:Label></h5>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="line-height: 0px;">
                                <h5 style="font-weight: bold; line-height: 5px;">&nbsp</h5>
                            </td>
                        </tr>
                    </table>

                </div>
            </div>
        </div>
        <%--<input type="button" onclick="printDiv('printableArea')" value="Print" class="btn btn-primary" />--%>
    </form>
</body>
</html>

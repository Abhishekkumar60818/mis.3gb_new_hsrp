<%@ Page Language="C#" AutoEventWireup="true" CodeFile="print.aspx.cs" Inherits="pdf_print" EnableEventValidation="false" %>

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
    function printDiv(divName) {
     var printContents = document.getElementById(divName).innerHTML;
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
                <asp:Repeater ID="rptrPrint" runat="server">
                    <ItemTemplate>
                        <div class="col-md-6">
                            <asp:Image ID="imgBarcode" runat="server" ImageUrl='<%#Eval("imgpaths") %>' Width="100%" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
            </div>
        <input type="button" onclick="printDiv('printableArea')" value="Print" class="btn btn-primary" />
        <%--<input type="button"  value="download" id="cmd" class="btn btn-primary" />--%>
        <%--<asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />--%>
    </form>
</body>
</html>

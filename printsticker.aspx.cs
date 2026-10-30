using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class printsticker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getprint();
    }

    private void getprint()
    {
        string barCode = Request.QueryString["id"];

        //using (Bitmap bitMap = new Bitmap(barCode.Length * 24, 80))
        //{
        //    using (Graphics graphics = Graphics.FromImage(bitMap))
        //    {
        //        Font oFont = new Font("IDAutomationHC39M Free Version", 16);
        //        PointF point = new PointF(2f, 2f);
        //        SolidBrush blackBrush = new SolidBrush(Color.Black);
        //        SolidBrush whiteBrush = new SolidBrush(Color.White);
        //        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
        //        graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
        //    }
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        bitMap.Save(ms, ImageFormat.Png);
        //        imgBarcode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
        //        imgBarcode.Visible = true;
        //    }

        //}
        // imgmy.Src = "https://barcode.tec-it.com/barcode.ashx?data=TD0000021076&code=Code128&multiplebarcodes=false&translate-esc=true&unit=Fit&dpi=96&imagetype=Gif&rotation=0&color=%23000000&bgcolor=%23ffffff&codepage=Default&qunit=Mm&quiet=0&hidehrt=False";
        imgBarcode.ImageUrl = "https://barcode.tec-it.com/barcode.ashx?data=" + barCode + "&code=Code128&multiplebarcodes=false&translate-esc=true&unit=Fit&dpi=96&imagetype=Gif&rotation=0&color=%23000000&bgcolor=%23ffffff&codepage=Default&qunit=Mm&quiet=0&hidehrt=False";
    }
}
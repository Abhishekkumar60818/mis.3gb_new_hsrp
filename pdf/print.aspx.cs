using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;


public partial class pdf_print : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        generateSticker(int.Parse(Request.QueryString["val"].ToString()));
    }

    private void generateSticker(int v)
    {
        DataTable dtFinal = new DataTable();
        dtFinal.Columns.Add(new DataColumn("imgpaths", typeof(string)));
        StockData sss = new StockData();
        DataSet dsStock = sss.getDetails("select * from stock where id>="+ int.Parse(Request.QueryString["minId"].ToString())+" limit "+v);
        for (int i = 0; i <dsStock.Tables[0].Rows.Count; i++)
        {
            StockData sd = new StockData(int.Parse(dsStock.Tables[0].Rows[i]["id"].ToString()));

            string barCode = sd.laserno;
            using (Bitmap bitMap = new Bitmap(barCode.Length * 30, 90))
            {
                using (Graphics graphics = Graphics.FromImage(bitMap))
                {
                    Font oFont = new Font("IDAutomationHC39M Free Version", 16);
                    PointF point = new PointF(2f, 8f);
                    SolidBrush blackBrush = new SolidBrush(Color.Black);
                    SolidBrush whiteBrush = new SolidBrush(Color.White);
                    graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                    graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, ImageFormat.Png);
                    // imgBarcode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    // imgBarcode.Visible = true;
                    DataRow drinfo1 = null;
                    drinfo1 = dtFinal.NewRow();
                    //Create Row for each columns
                    drinfo1 = dtFinal.NewRow();
                    drinfo1["imgpaths"] = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    dtFinal.Rows.Add(drinfo1);
                }
            }
        }
        rptrPrint.DataSource = dtFinal;
        rptrPrint.DataBind();

        
    }

    //protected void btnExport_Click(object sender, EventArgs e)
    //{
    //    Response.ContentType = "application/pdf";
    //    Response.AddHeader("content-disposition", "attachment;filename=print.pdf");
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    StringWriter sw = new StringWriter();
    //    HtmlTextWriter hw = new HtmlTextWriter(sw);
    //    this.Page.RenderControl(hw);
    //    StringReader sr = new StringReader(sw.ToString());
    //    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10f, 10f, 100f, 0f);
    //    iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
    //    iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //    pdfDoc.Open();
    //    htmlparser.Parse(sr);
    //    pdfDoc.Close();
    //    Response.Write(pdfDoc);
    //    Response.End();
    //}
}
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class seller_ViewOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.tlp,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,(select laserno from stock where id=(select itemid from selleritem where headerid=s.id LIMIT 0,1)) as frontlaser,(select laserno from stock where id=(select itemid from selleritem where headerid=s.id LIMIT 1,1)) as rearlaser from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id and s.ext2=" + SessionVeriables.UserId);
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
            msg = msg.Replace("\r", string.Empty);
            msg = msg.Replace("\n", string.Empty);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = '" + msg.Trim() + "';$('#alert-modal').modal('show');});</script>", false);
        }
    }

    protected void rptrUser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //Response.Redirect("");
        try
        {
            int ids = int.Parse(e.CommandArgument.ToString());
            SellerSalesData sd = new SellerSalesData(ids);
            DataSet ds = sd.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.tlp,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,d.email,d.contactno as emcontact,d.address,(select laserno from stock where id=(select itemid from selleritem where headerid=s.id LIMIT 0,1)) as frontlaser,(select laserno from stock where id=(select itemid from selleritem where headerid=s.id LIMIT 1,1)) as rearlaser from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id and s.id=" + ids);
            string htmlbody = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("../pdf/invoice.html"));

            //htmlbody = htmlbody.Replace("__Date__", sd.date.ToString("dd-MM-yyyy"));
            htmlbody = htmlbody.Replace("__CentreName__", ds.Tables[0].Rows[0]["DName"].ToString());
            htmlbody = htmlbody.Replace("__CentreAddress__", ds.Tables[0].Rows[0]["address"].ToString());
            htmlbody = htmlbody.Replace("__CentreEmailId__", ds.Tables[0].Rows[0]["email"].ToString());
            htmlbody = htmlbody.Replace("__CentreContact__", ds.Tables[0].Rows[0]["emcontact"].ToString());
            htmlbody = htmlbody.Replace("__OwnerName__", ds.Tables[0].Rows[0]["name"].ToString());
            htmlbody = htmlbody.Replace("__State__", ds.Tables[0].Rows[0]["state"].ToString());
            htmlbody = htmlbody.Replace("__ContactNumber__", ds.Tables[0].Rows[0]["contactno"].ToString());
            htmlbody = htmlbody.Replace("__REGISTRATIONNUMBER__", ds.Tables[0].Rows[0]["registrationno"].ToString());
            htmlbody = htmlbody.Replace("__CHASSISNUMBER__", ds.Tables[0].Rows[0]["chasisno"].ToString());
            htmlbody = htmlbody.Replace("__ENGINENUMBER__", ds.Tables[0].Rows[0]["engineno"].ToString());
            htmlbody = htmlbody.Replace("__FUEL__", ds.Tables[0].Rows[0]["fueltype"].ToString());
            htmlbody = htmlbody.Replace("__VEHICLETYPE__", ds.Tables[0].Rows[0]["vehicletype"].ToString());
            htmlbody = htmlbody.Replace("__VehicleClass__", ds.Tables[0].Rows[0]["classtype"].ToString());
            htmlbody = htmlbody.Replace("__REGISTRATIONDATE__", (DateTime.Parse(ds.Tables[0].Rows[0]["registrationdate"].ToString())).ToString("dd-MM-yyyy"));
            htmlbody = htmlbody.Replace("__FrontLaserNumber__", ds.Tables[0].Rows[0]["frontlaser"].ToString());
            htmlbody = htmlbody.Replace("__RearLaserNumber__", ds.Tables[0].Rows[0]["rearlaser"].ToString());
            htmlbody = htmlbody.Replace("__TLPStatus__", ds.Tables[0].Rows[0]["tlp"].ToString());

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            StringBuilder sb = new StringBuilder(htmlbody);
            StringReader sr = new StringReader(sb.ToString());
            Document pdfDoc = new Document(PageSize.LETTER, 25f, 25f, 25f, 25f);
            // Document pdfg=new Document(PageSize.LETTER,)
            pdfDoc.SetMargins(35f, 15f, 5f, 5f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            //iTextSharp.text.Image watermark = iTextSharp.text.Image.GetInstance("http://admin.bookmyhsrp.co.in/pdf/hd.png");
            //watermark.SetAbsolutePosition(25, 720);
            //pdfDoc.Add(watermark);

            //iTextSharp.text.Image watermark1 = iTextSharp.text.Image.GetInstance("http://admin.bookmyhsrp.co.in/pdf/sign.png");
            //watermark1.SetAbsolutePosition(460, 220);
            //pdfDoc.Add(watermark1);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode("Order Date : " + (DateTime.Parse(ds.Tables[0].Rows[0]["orderdate"].ToString())).ToString("dd-MM-yyyy") + ",Vehicle Registration No.:" + ds.Tables[0].Rows[0]["registrationno"].ToString() + ",Engine No.:" + ds.Tables[0].Rows[0]["engineno"].ToString() + ",Chassis No:" + ds.Tables[0].Rows[0]["chasisno"].ToString() + ",Customer Name:" + ds.Tables[0].Rows[0]["name"].ToString() + ",Laser No. Front : " + ds.Tables[0].Rows[0]["frontlaser"].ToString() + ",Laser No Rear : " + ds.Tables[0].Rows[0]["rearlaser"].ToString(), QRCodeGenerator.ECCLevel.Q);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 100;
            imgBarCode.Width = 100;
            imgBarCode.BorderWidth = 4;
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    string base64 = Convert.ToBase64String(byteImage);
                    byte[] imagebytes = Convert.FromBase64String(base64);
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagebytes);
                    iTextSharp.text.Image watermarkQR = iTextSharp.text.Image.GetInstance(image);
                    watermarkQR.ScaleAbsoluteHeight(130);
                    watermarkQR.ScaleAbsoluteWidth(130);
                    watermarkQR.SetAbsolutePosition(430, 610);
                    // watermarkQR.Width = 200;
                    pdfDoc.Add(watermarkQR);
                }
            }
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + ds.Tables[0].Rows[0]["registrationno"].ToString() + "_Invoice.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
        catch
        {

        }
    }
}
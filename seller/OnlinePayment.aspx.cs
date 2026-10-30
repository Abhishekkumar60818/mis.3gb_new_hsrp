using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class seller_OnlinePayment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(SessionVeriables.UserId.ToString()) && SessionVeriables.UserId.ToString() != "" && SessionVeriables.UserId.ToString() != "0" && SessionVeriables.UserId.ToString() != null)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);
            DateTime ddtime = now;
            LedgerData ld = new LedgerData();
            ld.did = SessionVeriables.UserId;
            ld.amount = double.Parse(txtAmount.Text);
            ld.mode = "Online By Payment Gateway";
            ld.ptype = "deposit";
            ld.date = ddtime;
            ld.approval = 0;
            ld.transactionno = "";
            ld.photo = "";
            ld.remark = "";

            ld.Save();
            LedgerData ldr=new LedgerData(SessionVeriables.UserId, ddtime.ToString("yyyy-MM-dd"));
            postData(ldr.id, ldr.amount);
            //Response.Redirect("DealerLedger.aspx");
        }
        else
        {
            Response.Redirect("OnlinePayment.aspx");
        }
    }
    private void postData(int orderid, double amount)
    {
        try
        {
            DistibutorData ad = new DistibutorData(int.Parse(SessionVeriables.UserId.ToString()));
            CityDetails details = new CityDetails(int.Parse(ad.city));
            StateDetails st=new StateDetails(int.Parse(ad.state));
            //string BillingAddress = txtbillinghouse.Text + "," + txtbillingarea.Text + "," + txtbillingmark.Text + "," + txtbillingstate.Text;
            // string shippingAddress = txtshippinghouse.Text + "," + txtshippingarea.Text + "," + txtshippingmark.Text + "," + txtshppingstate.Text;
            string mid = WebConfigurationManager.AppSettings["merchantid"];
            string redirect_url = WebConfigurationManager.AppSettings["redirect_url"];
            string cancel_url = WebConfigurationManager.AppSettings["cancel_url"];
            OnlineOrderData oodd = new OnlineOrderData(orderid);
            NameValueCollection collections = new NameValueCollection();
            collections.Add("merchant_id", mid);
            collections.Add("order_id", orderid.ToString());
            collections.Add("amount", ((amount*2/100)+ amount).ToString());
            collections.Add("currency", "INR");
            collections.Add("redirect_url", redirect_url);
            collections.Add("cancel_url", cancel_url);
            collections.Add("billing_name", ad.name);
            collections.Add("billing_city", details.city);
            collections.Add("billing_state", st.name);
            collections.Add("billing_address",ad.address);
            collections.Add("billing_country", "India");
            collections.Add("billing_tel", ad.contactno);
            collections.Add("billing_email", ad.email);
            collections.Add("billing_city", st.name);
            collections.Add("billing_zip", ad.zipcode);
            string remoteUrl = "ccavRequestHandler.aspx";

            string html = "<html><head>";
            html += "</head><body onload='document.forms[0].submit()'>";
            html += string.Format("<form name='customerData' method='POST' action='{0}'>", remoteUrl);
            foreach (string key in collections.Keys)
            {
                html += string.Format("<input name='{0}' type='text' value='{1}'>", key, collections[key]);
            }
            html += "</form></body></html>";
            Response.Clear();
            Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1");
            Response.HeaderEncoding = Encoding.GetEncoding("ISO-8859-1");
            Response.Charset = "ISO-8859-1";
            Response.Write(html);
            Response.End();
        }
        catch (Exception ex)
        { }
    }
}
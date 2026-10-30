using CCA.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class seller_thankyou : System.Web.UI.Page
{
    public int vno;

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            string wkey = WebConfigurationManager.AppSettings["workingkey"];
            string workingKey = wkey;//put in the 32bit alpha numeric key in the quotes provided here
            CCACrypto ccaCrypto = new CCACrypto();
            string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
            NameValueCollection Params = new NameValueCollection();
            string[] segments = encResponse.Split('&');
            foreach (string seg in segments)
            {
                string[] parts = seg.Split('=');
                if (parts.Length > 0)
                {
                    string Key = parts[0].Trim();
                    string Value = parts[1].Trim();
                    Params.Add(Key, Value);
                }
            }

            if (Params["order_status"] == "Success")
            {

                //LedgerData ohdata = new LedgerData(int.Parse(Params["order_id"]));
                LedgerData od = new LedgerData();
                od.remark = "success";
                od.Approve(int.Parse(Params["order_id"]));
                lblheading.Text = "Thanks for Payment!!";
                lblOrder.Text = "Your Payment is successfully. for further update we should inform to you";
                imgOrder.Src = "../assets/order-confirmed.png";
            }
            else
            {

                // OnlineOrderData ohdata = new OnlineOrderData(int.Parse(Params["order_id"]));
                LedgerData od = new LedgerData();
                od.remark = "Payment failed";
                od.ApprovePending(int.Parse(Params["order_id"]));
                lblheading.Text = "Payment Failed!!";
                lblOrder.Text = "Your Payment is failed. kindly Payment again";
                imgOrder.Src = "../assets/order-failed.png";
            }


        }
    }
    public string EnryptString(string strEncrypted)
    {
        byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
        string encrypted = Convert.ToBase64String(b);
        return encrypted;
    }
}
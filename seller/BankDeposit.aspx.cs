using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class seller_BankDeposit : System.Web.UI.Page
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
            string abc = "";
            if (flupdt.HasFile)
            {
                string tcode = now.ToString("dd-MM-yyyy HH:mm:ss");
                tcode = tcode.Replace(':', '-');
                FileInfo photoaa = new FileInfo(flupdt.FileName);
                string extp = photoaa.Extension.ToLower();
                flupdt.SaveAs(HttpContext.Current.Server.MapPath("~/seller/Img/" + tcode + "_Screenshot" + extp));
                //bd.upaadharcard = tcode + "_Aadhar" + ext;
                abc= tcode + "_Screenshot" + extp;
            }
            LedgerData ld = new LedgerData();
            ld.did = SessionVeriables.UserId;
            ld.amount = double.Parse(txtAmount.Text);
            ld.mode = ddlPaymentMode.SelectedItem.ToString();
            ld.ptype = "deposit";
            ld.date = DateTime.Parse(txtDate.Text);
            ld.approval = 0;
            ld.transactionno = txtpaymentDetails.Text;
            ld.photo = abc;
            ld.remark = "";

            ld.Save();
            Response.Redirect("DealerLedger.aspx");
        }
        else
        {
            Response.Redirect("BankDeposit.aspx");
        }
    }
}
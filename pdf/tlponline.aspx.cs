using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pdf_tlponline : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        generateSticker(int.Parse(Request.QueryString["id"].ToString()));
    }

    private void generateSticker(int v)
    {
        SellerSalesData sd = new SellerSalesData(v);
        DataSet ds = sd.getDetails("SELECT o.registrationno,o.state,(YEAR(o.registrationdate)) as yr,o.registrationdate,o.frontlaserno,o.rearlaserno FROM onlineorder o WHERE o.id=" + v);
        lblState.Text = ds.Tables[0].Rows[0]["state"].ToString();
        lblVehicleNo.Text = ds.Tables[0].Rows[0]["registrationno"].ToString();
        lblYear.Text = (DateTime.Parse(ds.Tables[0].Rows[0]["registrationdate"].ToString())).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
        string lno = "";
        lno += ds.Tables[0].Rows[0]["frontlaserno"].ToString() + "-" + ds.Tables[0].Rows[0]["rearlaserno"].ToString();
        // lno = lno.Remove(lno.Length - 1, 1);
        lblLaserNo.Text = lno;
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyFun1", "window.print();", true);
    }
}
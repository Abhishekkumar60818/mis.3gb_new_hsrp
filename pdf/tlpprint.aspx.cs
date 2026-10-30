using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pdf_tlpprint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        generateSticker(int.Parse(Request.QueryString["id"].ToString()));
    }

    private void generateSticker(int v)
    {
        SellerSalesData sd = new SellerSalesData(v);
        DataSet ds = sd.getDetails("select s.registrationno,s.state,(YEAR(s.registrationdate)) as yr,s.registrationdate,st.laserno from sellersales s join selleritem si on si.headerid=s.id join stock st on st.id=si.itemid where s.id=" + v);
        lblState.Text = ds.Tables[0].Rows[0]["state"].ToString();
        lblVehicleNo.Text = ds.Tables[0].Rows[0]["registrationno"].ToString();
        lblYear.Text = (DateTime.Parse(ds.Tables[0].Rows[0]["registrationdate"].ToString())).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
        //laserno
        //rptr.DataSource = ds;
        //rptr.DataBind();
        string lno = "";
        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
        {
            lno += ds.Tables[0].Rows[i]["laserno"].ToString() + "-";
        }
        lno = lno.Remove(lno.Length - 1, 1);
        lblLaserNo.Text = lno;
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyFun1", "window.print();", true);
    }
}
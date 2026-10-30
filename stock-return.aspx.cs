using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class stock_return : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                pnlView.Visible = true;
                AdminLoginData ad = new AdminLoginData();
                DataSet DsStockist = ad.getDetails("SELECT d.id,CONCAT(d.name, ',', (select city from city where id=d.city)) as name FROM distibutor d WHERE d.status=1 and  (d.DType='Embossing' or d.DType='Stockists Cum Dealer') order by name");
                ddlStockist.DataSource = DsStockist;
                ddlStockist.DataTextField = "name";
                ddlStockist.DataValueField = "id";
                ddlStockist.DataBind();
                ddlStockist.Items.Insert(0, "Select Embossing");
                ddlStockist.SelectedIndex = 0;
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

    protected void ddlStockist_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            pnlView.Visible = true;
            AdminLoginData ad = new AdminLoginData();
            DataSet ds = ad.getDetails("select s.id,si.sid as laserid,s.rateid,sh.date,s.laserno,si.sstatus,size.sizes,v.type from stock s join salesitem si join saleheader sh join size join vehicleclass v where size.id=s.sizeid and v.id=s.classid and sh.status=1 and sh.did=" + int.Parse(ddlStockist.SelectedValue.ToString()) + " and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0");
            rptrUser.DataSource = ds;
            rptrUser.DataBind();

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
            msg = msg.Replace("\r", string.Empty);
            msg = msg.Replace("\n", string.Empty);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = '" + msg.Trim() + "';$('#alert-modal').modal('show');});</script>", false);
        }
    }

    protected void btnTransferReturn_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptrUser.Items.Count; i++)
        {
            HtmlInputCheckBox MyCheckBox = new HtmlInputCheckBox();
            MyCheckBox = (HtmlInputCheckBox)rptrUser.Items[i].FindControl("chk");
            if (MyCheckBox.Checked)
            {
                //hider = int.Parse(MyCheckBox.Value);
                AdminLoginData ad = new AdminLoginData();
                ad.getDetails("update salesitem set status=0 WHERE sid=" + int.Parse(MyCheckBox.Value));
                ad.getDetails("update stock set sstatus=0 where id=" + int.Parse(MyCheckBox.Value));
            }
        }
        Response.Redirect("stock-return.aspx");
    }
}
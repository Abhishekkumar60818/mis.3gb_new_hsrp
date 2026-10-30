using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class stock_dealer_wise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                pnlView.Visible = false;
                pnlStockistwise.Visible = true;
                AdminLoginData ad = new AdminLoginData();
                DataSet DsStockist = ad.getDetails("SELECT d.id,CONCAT(d.name, ',', (select city from city where id=d.city)) as name,(select count(s.id) from stock s join salesitem si join saleheader sh join size join vehicleclass v where size.id=s.sizeid and v.id=s.classid and sh.status=1 and sh.did=d.id and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0) as Stocks FROM distibutor d WHERE d.status=1 order by name");
                rptrDealer.DataSource = DsStockist;
                rptrDealer.DataBind();
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

            pnlView.Visible = false;
            pnlStockistwise.Visible = true;
            AdminLoginData ad = new AdminLoginData();
            //DataSet ds = ad.getDetails("select s.id,si.sid as laserid,s.rateid,sh.date,s.laserno,si.sstatus,size.sizes,v.type from stock s join salesitem si join saleheader sh join size join vehicleclass v where size.id=s.sizeid and v.id=s.classid and sh.status=1 and sh.did=" + int.Parse(ddlStockist.SelectedValue.ToString()) + " and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0");
            //if (ds.Tables[0].R
            //ows.Count > 0)
            //{
            //    rptrUser.DataSource = ds;
            //    rptrUser.DataBind();
            //}
            //else
            //{
            //    rptrUser.DataSource = null;
            //    rptrUser.DataBind();
            //}

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
            msg = msg.Replace("\r", string.Empty);
            msg = msg.Replace("\n", string.Empty);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = '" + msg.Trim() + "';$('#alert-modal').modal('show');});</script>", false);
        }
    }

    //protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        pnlView.Visible = false;
    //        pnlStockistwise.Visible = true;
    //        AdminLoginData ad = new AdminLoginData();
    //        DataSet DsStockist = ad.getDetails("SELECT d.id,CONCAT(d.name, ',', (select city from city where id=d.city)) as name,(select count(s.id) from stock s join salesitem si join saleheader sh join size join vehicleclass v where size.id=s.sizeid and v.id=s.classid and sh.status=1 and sh.did=d.id and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0) as Stocks FROM distibutor d WHERE d.status=1  and d.state=" + int.Parse(ddlState.SelectedValue.ToString()) + " order by name");
    //        //ddlStockist.DataSource = DsStockist;
    //        //ddlStockist.DataTextField = "name";
    //        //ddlStockist.DataValueField = "id";
    //        //ddlStockist.DataBind();
    //        //ddlStockist.Items.Insert(0, "Select Stockist");
    //        //ddlStockist.SelectedIndex = 0;



    //        rptrDealer.DataSource = DsStockist;
    //        rptrDealer.DataBind();

    //    }
    //    catch (Exception ex)
    //    {
    //        string msg = ex.Message;
    //        msg = msg.Replace("\r", string.Empty);
    //        msg = msg.Replace("\n", string.Empty);
    //        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = '" + msg.Trim() + "';$('#alert-modal').modal('show');});</script>", false);
    //    }
    //}

    protected void rptrDealer_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        pnlView.Visible = true;
        pnlStockistwise.Visible = false;
        int ids = int.Parse(e.CommandArgument.ToString());
        DistibutorData dd = new DistibutorData(ids);
        lblDistributorName.Text = dd.name;
        AdminLoginData ad = new AdminLoginData();
        DataSet ds = ad.getDetails("select s.id,si.sid as laserid,s.rateid,sh.date,s.laserno,si.sstatus,size.sizes,v.type from stock s join salesitem si join saleheader sh join size join vehicleclass v where size.id=s.sizeid and v.id=s.classid and sh.status=1 and sh.did=" + ids + " and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rptrUser.DataSource = ds;
            rptrUser.DataBind();
        }
        else
        {
            rptrUser.DataSource = null;
            rptrUser.DataBind();
        }
        DataSet dsCount = ad.getDetails("select (select count(size.sizes) from stock s join salesitem si join saleheader sh join size join vehicleclass v where size.id=s.sizeid and v.id=s.classid and sh.status=1 and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0 and size.id=2 and v.id=1 and sh.did=" + ids + ") as T200X100,(select count(size.sizes) from stock s join salesitem si join saleheader sh join size join vehicleclass v where size.id=s.sizeid and v.id=s.classid and sh.status=1 and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0 and size.id=2 and v.id=2 and sh.did=" + ids + ") as NT200X100,(select count(size.sizes) from stock s join salesitem si join saleheader sh join size join vehicleclass v where size.id=s.sizeid and v.id=s.classid and sh.status=1 and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0 and size.id=1 and v.id=1 and sh.did=" + ids + ") as T285X45,(select count(size.sizes) from stock s join salesitem si join saleheader sh join size join vehicleclass v where size.id=s.sizeid and v.id=s.classid and sh.status=1 and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0 and size.id=1 and v.id=2 and sh.did=" + ids + ") as NT285X45,(select count(size.sizes) from stock s join salesitem si join saleheader sh join size join vehicleclass v where size.id=s.sizeid and v.id=s.classid and sh.status=1 and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0 and size.id=4 and v.id=1 and sh.did=" + ids + ") as T340X200,(select count(size.sizes) from stock s join salesitem si join saleheader sh join size join vehicleclass v where size.id=s.sizeid and v.id=s.classid and sh.status=1 and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0 and size.id=4 and v.id=2 and sh.did=" + ids + ") as NT340X200,(select count(size.sizes) from stock s join salesitem si join saleheader sh join size join vehicleclass v where size.id=s.sizeid and v.id=s.classid and sh.status=1 and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0 and size.id=3 and v.id=1 and sh.did=" + ids + ") as T500X120,(select count(size.sizes) from stock s join salesitem si join saleheader sh join size join vehicleclass v where size.id=s.sizeid and v.id=s.classid and sh.status=1 and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0 and size.id=3 and v.id=2 and sh.did=" + ids + ") as NT500X120");
        lbl200X45Transport.Text = dsCount.Tables[0].Rows[0]["T200X100"].ToString();
        lbl200X45NONTransport.Text = dsCount.Tables[0].Rows[0]["NT200X100"].ToString();
        lbl285X45Transport.Text = dsCount.Tables[0].Rows[0]["T285X45"].ToString();
        lbl285X45NONTransport.Text = dsCount.Tables[0].Rows[0]["NT285X45"].ToString();
        lbl340X200Transport.Text = dsCount.Tables[0].Rows[0]["T340X200"].ToString();
        lbl340X200NONTransport.Text = dsCount.Tables[0].Rows[0]["NT340X200"].ToString();
        lbl500X120Transport.Text = dsCount.Tables[0].Rows[0]["T500X120"].ToString();
        lbl500X120NONTransport.Text = dsCount.Tables[0].Rows[0]["NT500X120"].ToString();
    }

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        pnlView.Visible = false;
    //        pnlStockistwise.Visible = true;
    //        AdminLoginData ad = new AdminLoginData();
    //        DataSet DsStockist = ad.getDetails("SELECT d.id,CONCAT(d.name, ',', (select city from city where id=d.city)) as name,(select count(s.id) from stock s join salesitem si join saleheader sh join size join vehicleclass v where size.id=s.sizeid and v.id=s.classid and sh.status=1 and sh.did=d.id and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0) as Stocks FROM distibutor d WHERE d.status=1  and d.state=" + int.Parse(ddlState.SelectedValue.ToString()) + " order by name");
    //        //ddlStockist.DataSource = DsStockist;
    //        //ddlStockist.DataTextField = "name";
    //        //ddlStockist.DataValueField = "id";
    //        //ddlStockist.DataBind();
    //        //ddlStockist.Items.Insert(0, "Select Stockist");
    //        //ddlStockist.SelectedIndex = 0;



    //        rptrDealer.DataSource = DsStockist;
    //        rptrDealer.DataBind();

    //    }
    //    catch (Exception ex)
    //    {
    //        string msg = ex.Message;
    //        msg = msg.Replace("\r", string.Empty);
    //        msg = msg.Replace("\n", string.Empty);
    //        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = '" + msg.Trim() + "';$('#alert-modal').modal('show');});</script>", false);
    //    }
    //}
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class stock_state_wise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                pnlView.Visible = false;
                AdminLoginData ad = new AdminLoginData();
                //DataSet DsStockist = ad.getDetails("SELECT d.id,CONCAT(d.name, ',', (select city from city where id=d.city)) as name FROM distibutor d WHERE d.status=1 and  (d.DType='Stockists' or d.DType='Stockists Cum Dealer') order by name");
                //ddlStockist.DataSource = DsStockist;
                //ddlStockist.DataTextField = "name";
                //ddlStockist.DataValueField = "id";
                //ddlStockist.DataBind();
                //ddlStockist.Items.Insert(0, "Select Stockist");
                //ddlStockist.SelectedIndex = 0;


                DataSet DsState = ad.getDetails("SELECT id,name FROM state  WHERE status=1 order by name");
                ddlState.DataSource = DsState;
                ddlState.DataTextField = "name";
                ddlState.DataValueField = "id";
                ddlState.DataBind();
                ddlState.Items.Insert(0, "Select State");
                ddlState.SelectedIndex = 0;
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

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            pnlView.Visible = false;
            pnlStockistwise.Visible = true;
            AdminLoginData ad = new AdminLoginData();
            DataSet DsStockist = ad.getDetails("SELECT d.id,CONCAT(d.name, ',', (select city from city where id=d.city)) as name,(select count(s.id) from stock s join salesitem si join saleheader sh join size join vehicleclass v where size.id=s.sizeid and v.id=s.classid and sh.status=1 and sh.did=d.id and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0) as Stocks FROM distibutor d WHERE d.status=1  and d.state=" + int.Parse(ddlState.SelectedValue.ToString()) + " order by name");
            //ddlStockist.DataSource = DsStockist;
            //ddlStockist.DataTextField = "name";
            //ddlStockist.DataValueField = "id";
            //ddlStockist.DataBind();
            //ddlStockist.Items.Insert(0, "Select Stockist");
            //ddlStockist.SelectedIndex = 0;



            rptrDealer.DataSource = DsStockist;
            rptrDealer.DataBind();

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
            msg = msg.Replace("\r", string.Empty);
            msg = msg.Replace("\n", string.Empty);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = '" + msg.Trim() + "';$('#alert-modal').modal('show');});</script>", false);
        }
    }

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
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {

            pnlView.Visible = false;
            pnlStockistwise.Visible = true;
            AdminLoginData ad = new AdminLoginData();
            DataSet DsStockist = ad.getDetails("SELECT d.id,CONCAT(d.name, ',', (select city from city where id=d.city)) as name,(select count(s.id) from stock s join salesitem si join saleheader sh join size join vehicleclass v where size.id=s.sizeid and v.id=s.classid and sh.status=1 and sh.did=d.id and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0) as Stocks FROM distibutor d WHERE d.status=1  and d.state=" + int.Parse(ddlState.SelectedValue.ToString()) + " order by name");
            //ddlStockist.DataSource = DsStockist;
            //ddlStockist.DataTextField = "name";
            //ddlStockist.DataValueField = "id";
            //ddlStockist.DataBind();
            //ddlStockist.Items.Insert(0, "Select Stockist");
            //ddlStockist.SelectedIndex = 0;



            rptrDealer.DataSource = DsStockist;
            rptrDealer.DataBind();

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
            msg = msg.Replace("\r", string.Empty);
            msg = msg.Replace("\n", string.Empty);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = '" + msg.Trim() + "';$('#alert-modal').modal('show');});</script>", false);
        }
    }
}
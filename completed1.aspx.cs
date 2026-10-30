using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class completed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,(select name from distibutor where id=d.extra) as ems,(select laserno from stock where id=(select itemid from selleritem where headerid=s.id LIMIT 0,1)) as frontlaser,(select laserno from stock where id=(select itemid from selleritem where headerid=s.id LIMIT 1,1)) as rearlaser from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id");
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtStDate.Text != "" && txtEndDate.Text != "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,(select name from distibutor where id=d.extra) as ems from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id and  (s.orderdate between '" + txtStDate.Text + "' and '" + txtEndDate.Text + "')");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text == "" && txtEndDate.Text == "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,(select name from distibutor where id=d.extra) as ems from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id ");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text != "" && txtEndDate.Text == "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,(select name from distibutor where id=d.extra) as ems from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id  and s.orderdate >= '" + txtStDate.Text + "'");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text == "" && txtEndDate.Text != "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,(select name from distibutor where id=d.extra) as ems from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id and  s.orderdate <= '" + txtEndDate.Text + "'");
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
        int ids = int.Parse(e.CommandArgument.ToString());
        string comm = e.CommandName;
        lblId.Text = ids.ToString();
        AdminLoginData ad = new AdminLoginData();
        DataSet ds = ad.getDetails("select s.id,(select id from selleritem where headerid=s.id LIMIT 0,1) as frontlaser,(select id from selleritem where headerid=s.id LIMIT 1,1) as rearlaser from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id and s.id=" + ids);
        SellerItemData adItem = new SellerItemData(int.Parse(ds.Tables[0].Rows[0]["frontlaser"].ToString()));
        SellerItemData rearItem = new SellerItemData(int.Parse(ds.Tables[0].Rows[0]["rearlaser"].ToString()));
        StockData sd = new StockData(adItem.itemid);
        StockData sd1 = new StockData(rearItem.itemid);
        SellerSalesData sd2 = new SellerSalesData(adItem.headerid);
        //LedgerData sd = new LedgerData(ids);
        lblRegistration.Text = sd2.registrationno;
        lblFrontLaserNumber.Text = sd.laserno;
        lblRearLaser.Text = sd1.laserno;
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);

    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        int ids = int.Parse(lblId.Text);
        AdminLoginData ad = new AdminLoginData();
        DataSet ds = ad.getDetails("select s.id,(select id from selleritem where headerid=s.id LIMIT 0,1) as frontlaser,(select id from selleritem where headerid=s.id LIMIT 1,1) as rearlaser from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id and s.id=" + ids);

        SellerItemData adItem = new SellerItemData(int.Parse(ds.Tables[0].Rows[0]["frontlaser"].ToString()));
        SellerItemData rearItem = new SellerItemData(int.Parse(ds.Tables[0].Rows[0]["rearlaser"].ToString()));

        ad.getDetails("delete from selleritem where id=" + ds.Tables[0].Rows[0]["frontlaser"].ToString());
        ad.getDetails("delete from selleritem where id=" + ds.Tables[0].Rows[0]["rearlaser"].ToString());
        ad.getDetails("update salesitem set sstatus=0,remark='"+ txtRemark.Text + "' where sid=" + adItem.itemid);
        ad.getDetails("update salesitem set sstatus=0,remark='"+ txtRemark.Text + "' where sid=" + rearItem.itemid);
        ad.getDetails("update sellersales set npid=0 where id=" + ds.Tables[0].Rows[0]["id"].ToString());
        Response.Redirect("completed.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dealer_sales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //AdminLoginData ad = new AdminLoginData();
                //DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id and s.ext2=0");
                //rptrUser.DataSource = ds;
                //rptrUser.DataBind();
                AdminLoginData ad = new AdminLoginData();
                DataSet DsStockist = ad.getDetails("SELECT d.id,CONCAT(d.name, ',', (select city from city where id=d.city)) as name FROM distibutor d WHERE d.status=1 and  (d.DType='Embossing' or d.DType='Embossing Cum Dealer') order by name");
                ddlStockist.DataSource = DsStockist;
                ddlStockist.DataTextField = "name";
                ddlStockist.DataValueField = "id";
                ddlStockist.DataBind();
                ddlStockist.Items.Insert(0, "Select Embossing");
                ddlStockist.SelectedIndex = 0;


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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string qs = "";
            if (int.Parse(ddlStockist.SelectedValue.ToString()) > 0)
            {
                qs = " and d.id=" + int.Parse(ddlStockist.SelectedValue.ToString());
            }

            if (txtStDate.Text != "" && txtEndDate.Text != "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id and s.ext2=0 and (s.orderdate between '" + txtStDate.Text + "' and '" + txtEndDate.Text + "')" + qs);
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text == "" && txtEndDate.Text == "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id and s.ext2=0" + qs);
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text != "" && txtEndDate.Text == "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id and s.ext2=0 and s.orderdate >= '" + txtStDate.Text + "'" + qs);
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text == "" && txtEndDate.Text != "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id and s.ext2=0 and s.orderdate <= '" + txtEndDate.Text + "'" + qs);
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
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            pnlView.Visible = true;
            AdminLoginData ad = new AdminLoginData();
            DataSet DsStockist = ad.getDetails("SELECT d.id,CONCAT(d.name, ',', (select city from city where id=d.city)) as name FROM distibutor d WHERE d.status=1 and  (d.DType='Embossing' or d.DType='Stockists Cum Dealer') and d.state=" + int.Parse(ddlState.SelectedValue.ToString()) + " order by name");
            ddlStockist.DataSource = DsStockist;
            ddlStockist.DataTextField = "name";
            ddlStockist.DataValueField = "id";
            ddlStockist.DataBind();
            ddlStockist.Items.Insert(0, "Select Embossing");
            ddlStockist.SelectedIndex = 0;



            rptrUser.DataSource = null;
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

}
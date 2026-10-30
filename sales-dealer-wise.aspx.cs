using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sales_dealer_wise : System.Web.UI.Page
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
                //AdminLoginData ad = new AdminLoginData();
                //DataSet DsStockist = ad.getDetails("SELECT d.id,CONCAT(d.name, ',', (select city from city where id=d.city)) as name FROM distibutor d WHERE d.status=1 and  (d.DType='Stockists' or d.DType='Stockists Cum Dealer') order by name");
                //ddlStockist.DataSource = DsStockist;
                //ddlStockist.DataTextField = "name";
                //ddlStockist.DataValueField = "id";
                //ddlStockist.DataBind();
                //ddlStockist.Items.Insert(0, "Select Stockist");
                //ddlStockist.SelectedIndex = 0;

                pnlView.Visible = false;
                pnlStockistwise.Visible = true;
                AdminLoginData ad = new AdminLoginData();
                DataSet DsStockist = ad.getDetails("SELECT d.id,CONCAT(d.name, ',', (select city from city where id=d.city)) as name,(select count(s.id) from sellersales s  where s.status=1 and s.npid=1 and s.sellerid=d.id ) as totalFitement FROM distibutor d WHERE d.status=1 order by name");
                rptrDealer.DataSource = DsStockist;
                rptrDealer.DataBind();
                //DataSet DsState = ad.getDetails("SELECT id,name FROM state  WHERE status=1 order by name");
                //ddlState.DataSource = DsState;
                //ddlState.DataTextField = "name";
                //ddlState.DataValueField = "id";
                //ddlState.DataBind();
                //ddlState.Items.Insert(0, "Select State");
                //ddlState.SelectedIndex = 0;
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
                pnlView.Visible = false;
                pnlStockistwise.Visible = true;
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("SELECT d.id,CONCAT(d.name, ',', (select city from city where id=d.city)) as name,(select count(s.id) from sellersales s  where s.status=1 and s.npid=1 and s.sellerid=d.id and (s.orderdate between '" + txtStDate.Text + "' and '" + txtEndDate.Text + "')) as totalFitement FROM distibutor d WHERE d.status=1  order by name");
                rptrDealer.DataSource = ds;
                rptrDealer.DataBind();
            }
            else if (txtStDate.Text == "" && txtEndDate.Text == "")
            {
                pnlView.Visible = false;
                pnlStockistwise.Visible = true;
                AdminLoginData ad = new AdminLoginData();
                DataSet DsStockist = ad.getDetails("SELECT d.id,CONCAT(d.name, ',', (select city from city where id=d.city)) as name,(select count(s.id) from sellersales s  where s.status=1 and s.npid=1 and s.sellerid=d.id ) as totalFitement FROM distibutor d WHERE d.status=1  order by name");
                rptrDealer.DataSource = DsStockist;
                rptrDealer.DataBind();
            }
            else if (txtStDate.Text != "" && txtEndDate.Text == "")
            {
                pnlView.Visible = false;
                pnlStockistwise.Visible = true;
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("SELECT d.id,CONCAT(d.name, ',', (select city from city where id=d.city)) as name,(select count(s.id) from sellersales s  where s.status=1 and s.npid=1 and s.sellerid=d.id and s.orderdate >= '" + txtStDate.Text + "') as totalFitement FROM distibutor d WHERE d.status=1  order by name");
                rptrDealer.DataSource = ds;
                rptrDealer.DataBind();
            }
            else if (txtStDate.Text == "" && txtEndDate.Text != "")
            {
                pnlView.Visible = false;
                pnlStockistwise.Visible = true;
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("SELECT d.id,CONCAT(d.name, ',', (select city from city where id=d.city)) as name,(select count(s.id) from sellersales s  where s.status=1 and s.npid=1 and s.sellerid=d.id and s.orderdate <= '" + txtEndDate.Text + "') as totalFitement FROM distibutor d WHERE d.status=1  order by name");
                rptrDealer.DataSource = ds;
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

    private void getExcel(DataSet ds)
    {
        DataTable dt = ds.Tables[0];
        using (XLWorkbook wb = new XLWorkbook())
        {
            wb.Worksheets.Add(dt);

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=Online-Order.xlsx");
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
    }



    protected void rptrDealer_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int ids = int.Parse(e.CommandArgument.ToString());
        string qs = "";
        //if (int.Parse(ddlStockist.SelectedValue.ToString()) > 0)
        //{
        qs = " and d.id=" + ids;
        //}
        pnlView.Visible = true;
        pnlStockistwise.Visible = false;
        if (txtStDate.Text != "" && txtEndDate.Text != "")
        {
            AdminLoginData ad = new AdminLoginData();
            DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id  and (s.orderdate between '" + txtStDate.Text + "' and '" + txtEndDate.Text + "')" + qs);
            rptrUser.DataSource = ds;
            rptrUser.DataBind();
        }
        else if (txtStDate.Text == "" && txtEndDate.Text == "")
        {
            AdminLoginData ad = new AdminLoginData();
            DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id " + qs);
            rptrUser.DataSource = ds;
            rptrUser.DataBind();
        }
        else if (txtStDate.Text != "" && txtEndDate.Text == "")
        {
            AdminLoginData ad = new AdminLoginData();
            DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id  and s.orderdate >= '" + txtStDate.Text + "'" + qs);
            rptrUser.DataSource = ds;
            rptrUser.DataBind();
        }
        else if (txtStDate.Text == "" && txtEndDate.Text != "")
        {
            AdminLoginData ad = new AdminLoginData();
            DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id  and s.orderdate <= '" + txtEndDate.Text + "'" + qs);
            rptrUser.DataSource = ds;
            rptrUser.DataBind();
        }
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {

    }
}
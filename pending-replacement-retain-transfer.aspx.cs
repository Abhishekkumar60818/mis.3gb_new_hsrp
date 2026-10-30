using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pending_replacement_retain_transfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.ownername,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,d.name as DName,(select name from distibutor where id=d.extra) as ems from onlinesales s join distibutor d on d.id=s.fitmentcentre where s.status=1 and s.paymentstatus='Success' and s.npid=0 and s.ordertype in ('replacement both plate','replacement front only','replacement rear only') and s.ispending=1");
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
                DataSet ds = ad.getDetails("select s.id,s.ownername,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,d.name as DName,(select name from distibutor where id=d.extra) as ems from onlinesales s join distibutor d on d.id=s.fitmentcentre where s.status=1 and s.paymentstatus='Success' and s.npid=0 and s.ordertype in ('replacement both plate','replacement front only','replacement rear only') and s.ispending=1 and  (date_format(str_to_date(s.orderdaate, '%d-%m-%Y'), '%Y-%m-%d') between '" + txtStDate.Text + "' and '" + txtEndDate.Text + "')");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text == "" && txtEndDate.Text == "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.ownername,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,d.name as DName,(select name from distibutor where id=d.extra) as ems from onlinesales s join distibutor d on d.id=s.fitmentcentre where s.status=1 and s.paymentstatus='Success' and s.npid=0 and s.ordertype in ('replacement both plate','replacement front only','replacement rear only') and s.ispending=1");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text != "" && txtEndDate.Text == "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.ownername,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,d.name as DName,(select name from distibutor where id=d.extra) as ems from onlinesales s join distibutor d on d.id=s.fitmentcentre where s.status=1 and s.paymentstatus='Success' and s.npid=0 and s.ispending=1 and s.ordertype in ('replacement both plate','replacement front only','replacement rear only') and date_format(str_to_date(s.orderdaate, '%d-%m-%Y'), '%Y-%m-%d') >= '" + txtStDate.Text + "'");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text == "" && txtEndDate.Text != "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.ownername,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,d.name as DName,(select name from distibutor where id=d.extra) as ems from onlinesales s join distibutor d on d.id=s.fitmentcentre where s.status=1 and s.paymentstatus='Success' and s.npid=0 and s.ispending=1 and s.ordertype in ('replacement both plate','replacement front only','replacement rear only') and  date_format(str_to_date(s.orderdaate, '%d-%m-%Y'), '%Y-%m-%d') <= '" + txtEndDate.Text + "'");
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
}
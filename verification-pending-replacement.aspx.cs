using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class verification_pending_replacement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.state,s.registrationnumber,s.chasisnumber,s.enginenumber,s.bharatstage,s.vehicleregistrationbate,s.fueltype,s.maker,s.vehicletype,s.vehiclecategory,s.vehiclecategory1,s.ownername,s.emailid,s.mobilenumber,s.billingaddress,s.city,s.fitmentcentre,s.status,s.orderdaate,s.paymentstatus,s.amount,s.frontlaserno,s.rearlaserno,s.orderstatus,s.ordertype,s.fir_lr_no,s.firdate,s.reasonforreplacement,s.replacement,s.policestationname,s.frontlaserphoto,s.rearlaserphoto,s.fircopy,s.uploadrc,s.frontplatephoto,s.rearplatephoto,s.gst,s.netanount,s.npid,s.fitmentdate,s.flaserno,s.rleaserno,s.ispending,d.name as DName,(select name from distibutor where id=d.extra) as ems from onlinesales s join distibutor d on d.id=s.fitmentcentre where s.status=1 and s.npid=0 and s.paymentstatus='Success' and s.ordertype in ('replacement both plate','replacement front only','replacement rear only') and s.ispending=0 ");
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
                DataSet ds = ad.getDetails("select s.id,s.state,s.registrationnumber,s.chasisnumber,s.enginenumber,s.bharatstage,s.vehicleregistrationbate,s.fueltype,s.maker,s.vehicletype,s.vehiclecategory,s.vehiclecategory1,s.ownername,s.emailid,s.mobilenumber,s.billingaddress,s.city,s.fitmentcentre,s.status,s.orderdaate,s.paymentstatus,s.amount,s.frontlaserno,s.rearlaserno,s.orderstatus,s.ordertype,s.fir_lr_no,s.firdate,s.reasonforreplacement,s.replacement,s.policestationname,s.frontlaserphoto,s.rearlaserphoto,s.fircopy,s.uploadrc,s.frontplatephoto,s.rearplatephoto,s.gst,s.netanount,s.npid,s.fitmentdate,s.flaserno,s.rleaserno,s.ispending,d.name as DName,(select name from distibutor where id=d.extra) as ems from onlinesales s join distibutor d on d.id=s.fitmentcentre where s.status=1 and s.npid=0 and s.paymentstatus='Success' and s.ordertype in ('replacement both plate','replacement front only','replacement rear only') and s.ispending=0 and  (date_format(str_to_date(s.orderdaate, '%d-%m-%Y'), '%Y-%m-%d') between '" + txtStDate.Text + "' and '" + txtEndDate.Text + "')");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text == "" && txtEndDate.Text == "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.state,s.registrationnumber,s.chasisnumber,s.enginenumber,s.bharatstage,s.vehicleregistrationbate,s.fueltype,s.maker,s.vehicletype,s.vehiclecategory,s.vehiclecategory1,s.ownername,s.emailid,s.mobilenumber,s.billingaddress,s.city,s.fitmentcentre,s.status,s.orderdaate,s.paymentstatus,s.amount,s.frontlaserno,s.rearlaserno,s.orderstatus,s.ordertype,s.fir_lr_no,s.firdate,s.reasonforreplacement,s.replacement,s.policestationname,s.frontlaserphoto,s.rearlaserphoto,s.fircopy,s.uploadrc,s.frontplatephoto,s.rearplatephoto,s.gst,s.netanount,s.npid,s.fitmentdate,s.flaserno,s.rleaserno,s.ispending,d.name as DName,(select name from distibutor where id=d.extra) as ems from onlinesales s join distibutor d on d.id=s.fitmentcentre where s.status=1 and s.npid=0 and s.paymentstatus='Success' and s.ordertype in ('replacement both plate','replacement front only','replacement rear only') and s.ispending=0");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text != "" && txtEndDate.Text == "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.state,s.registrationnumber,s.chasisnumber,s.enginenumber,s.bharatstage,s.vehicleregistrationbate,s.fueltype,s.maker,s.vehicletype,s.vehiclecategory,s.vehiclecategory1,s.ownername,s.emailid,s.mobilenumber,s.billingaddress,s.city,s.fitmentcentre,s.status,s.orderdaate,s.paymentstatus,s.amount,s.frontlaserno,s.rearlaserno,s.orderstatus,s.ordertype,s.fir_lr_no,s.firdate,s.reasonforreplacement,s.replacement,s.policestationname,s.frontlaserphoto,s.rearlaserphoto,s.fircopy,s.uploadrc,s.frontplatephoto,s.rearplatephoto,s.gst,s.netanount,s.npid,s.fitmentdate,s.flaserno,s.rleaserno,s.ispending,d.name as DName,(select name from distibutor where id=d.extra) as ems from onlinesales s join distibutor d on d.id=s.fitmentcentre where s.status=1 and s.npid=0 and s.paymentstatus='Success' and s.ordertype in ('replacement both plate','replacement front only','replacement rear only') and s.ispending=0 and date_format(str_to_date(s.orderdaate, '%d-%m-%Y'), '%Y-%m-%d') >= '" + txtStDate.Text + "'");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text == "" && txtEndDate.Text != "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.state,s.registrationnumber,s.chasisnumber,s.enginenumber,s.bharatstage,s.vehicleregistrationbate,s.fueltype,s.maker,s.vehicletype,s.vehiclecategory,s.vehiclecategory1,s.ownername,s.emailid,s.mobilenumber,s.billingaddress,s.city,s.fitmentcentre,s.status,s.orderdaate,s.paymentstatus,s.amount,s.frontlaserno,s.rearlaserno,s.orderstatus,s.ordertype,s.fir_lr_no,s.firdate,s.reasonforreplacement,s.replacement,s.policestationname,s.frontlaserphoto,s.rearlaserphoto,s.fircopy,s.uploadrc,s.frontplatephoto,s.rearplatephoto,s.gst,s.netanount,s.npid,s.fitmentdate,s.flaserno,s.rleaserno,s.ispending,d.name as DName,(select name from distibutor where id=d.extra) as ems from onlinesales s join distibutor d on d.id=s.fitmentcentre where s.status=1 and s.npid=0 and s.paymentstatus='Success' and s.ordertype in ('replacement both plate','replacement front only','replacement rear only') and s.ispending=0 and  date_format(str_to_date(s.orderdaate, '%d-%m-%Y'), '%Y-%m-%d') <= '" + txtEndDate.Text + "'");
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
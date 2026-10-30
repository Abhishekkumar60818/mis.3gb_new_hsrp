using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class online_order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    if (!IsPostBack)
        //    {
        //        AdminLoginData ad = new AdminLoginData();
        //        DataSet ds = ad.getDetails("SELECT o.id,o.imgpath,o.vehicle,o.manufacturer,o.state,o.classs,o.fuel,o.bharatstage,o.registrationdate,o.registrationno,o.chasisno,o.engineno,o.ownername,o.contactno,o.email,o.gstno,o.states,o.city,o.address,o.Address2,o.rate,o.couriercharages,o.gst,o.netamount,o.orderstatus,o.date,(select name from distibutor where id=o.dealerid) as dealer FROM onlineorder o WHERE o.orderstatus='success' and o.bookingstatus='pending' and o.status=1");
        //        rptrUser.DataSource = ds;
        //        rptrUser.DataBind();
        //    }
        //}
        //catch (Exception ex)
        //{
        //    string msg = ex.Message;
        //    msg = msg.Replace("\r", string.Empty);
        //    msg = msg.Replace("\n", string.Empty);
        //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = '" + msg.Trim() + "';$('#alert-modal').modal('show');});</script>", false);
        //}
        if (!IsPostBack)
        {
            StateDetails st = new StateDetails();
            DataSet ds = st.getDetails("SELECT cate FROM rateonline WHERE status=1 order by cate");
            //DataSet ds = st.getDetails("select * from state where status=1 and id<>9 order by name");
            //and id in(8,25,10,23,27)
            ddlCategory.DataSource = ds;
            ddlCategory.DataTextField = "cate";
            ddlCategory.DataValueField = "cate";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, "Select All");
            ddlCategory.SelectedIndex = 0;
        }
    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string catfilter = "";
            if (ddlCategory.SelectedItem.ToString() != "Select All")
            {
                catfilter = " and o.vehicle='" + ddlCategory.SelectedItem.ToString() + "'";
            }
            if (txtStDate.Text != "" && txtEndDate.Text != "")
            {
                lblError.Text = "";
                if (Convert.ToDateTime(txtStDate.Text) <= Convert.ToDateTime(txtEndDate.Text))
                {
                    lblError.Text = "";
                    if (txtStDate.Text != "" && txtEndDate.Text != "")
                    {
                        AdminLoginData ad = new AdminLoginData();
                        DataSet ds = ad.getDetails("SELECT o.id,o.imgpath,o.vehicle,o.manufacturer,o.state,o.classs,o.fuel,o.bharatstage,o.registrationdate,o.registrationno,o.chasisno,o.engineno,o.ownername,o.contactno,o.email,o.gstno,o.states,o.city,o.address,o.Address2,o.rate,o.couriercharages,o.gst,o.netamount,o.orderstatus,o.date,(select name from distibutor where id=o.dealerid) as dealer FROM onlineorder o WHERE o.orderstatus in('success','completed') and o.status=1 and (o.date between '" + txtStDate.Text + "' and '" + txtEndDate.Text + "') " + catfilter);
                        rptrUser.DataSource = ds;
                        rptrUser.DataBind();
                    }
                    else if (txtStDate.Text == "" && txtEndDate.Text == "")
                    {
                        AdminLoginData ad = new AdminLoginData();
                        DataSet ds = ad.getDetails("SELECT o.id,o.imgpath,o.vehicle,o.manufacturer,o.state,o.classs,o.fuel,o.bharatstage,o.registrationdate,o.registrationno,o.chasisno,o.engineno,o.ownername,o.contactno,o.email,o.gstno,o.states,o.city,o.address,o.Address2,o.rate,o.couriercharages,o.gst,o.netamount,o.orderstatus,o.date,(select name from distibutor where id=o.dealerid) as dealer FROM onlineorder o WHERE o.orderstatus in('success','completed') and o.status=1" + catfilter);
                        rptrUser.DataSource = ds;
                        rptrUser.DataBind();
                    }
                    else if (txtStDate.Text != "" && txtEndDate.Text == "")
                    {
                        AdminLoginData ad = new AdminLoginData();
                        DataSet ds = ad.getDetails("SELECT o.id,o.imgpath,o.vehicle,o.manufacturer,o.state,o.classs,o.fuel,o.bharatstage,o.registrationdate,o.registrationno,o.chasisno,o.engineno,o.ownername,o.contactno,o.email,o.gstno,o.states,o.city,o.address,o.Address2,o.rate,o.couriercharages,o.gst,o.netamount,o.orderstatus,o.date,(select name from distibutor where id=o.dealerid) as dealer FROM onlineorder o WHERE o.orderstatus in('success','completed') and o.status=1 and (o.date >= '" + (DateTime.Parse(txtStDate.Text)).ToString("yyyy-MM-dd") + " 00:00' )" + catfilter);
                        rptrUser.DataSource = ds;
                        rptrUser.DataBind();
                    }
                    else if (txtStDate.Text == "" && txtEndDate.Text != "")
                    {
                        AdminLoginData ad = new AdminLoginData();
                        DataSet ds = ad.getDetails("SELECT o.id,o.imgpath,o.vehicle,o.manufacturer,o.state,o.classs,o.fuel,o.bharatstage,o.registrationdate,o.registrationno,o.chasisno,o.engineno,o.ownername,o.contactno,o.email,o.gstno,o.states,o.city,o.address,o.Address2,o.rate,o.couriercharages,o.gst,o.netamount,o.orderstatus,o.date,(select name from distibutor where id=o.dealerid) as dealer FROM onlineorder o WHERE o.orderstatus in('success','completed') and o.status=1 and (o.date <= '" + txtEndDate.Text + "')" + catfilter);
                        rptrUser.DataSource = ds;
                        rptrUser.DataBind();
                    }
                }
                else
                {
                    lblError.Text = "* Start Date must be less then End Date";
                }
            }

            else
            {
                lblError.Text = "* Select Start Date and End Date";
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

    protected void btnImport_Click(object sender, EventArgs e)
    {
        try
        {
            string catfilter = "";
            if (ddlCategory.SelectedItem.ToString() != "Select All")
            {
                catfilter = " and o.vehicle='" + ddlCategory.SelectedItem.ToString() + "'";
            }
            if (txtStDate.Text != "" && txtEndDate.Text != "")
            {
                lblError.Text = "";
                if (Convert.ToDateTime(txtStDate.Text) <= Convert.ToDateTime(txtEndDate.Text))
                {
                    lblError.Text = "";
                    if (txtStDate.Text != "" && txtEndDate.Text != "")
                    {
                        AdminLoginData ad = new AdminLoginData();
                        DataSet ds = ad.getDetails("SELECT o.id,o.vehicle,o.manufacturer,o.state,o.classs,o.fuel,o.bharatstage,o.registrationdate,o.registrationno,o.chasisno,o.engineno,o.ownername,o.contactno,o.email,o.gstno,o.states,o.city,o.address,o.Address2,o.rate,o.couriercharages,o.gst,o.netamount,o.orderstatus,o.date,(select name from distibutor where id=o.dealerid) as dealer FROM onlineorder o WHERE o.orderstatus in('success','completed') and o.status=1 and (o.date between '" + txtStDate.Text + "' and '" + txtEndDate.Text + "')" + catfilter);
                        getExcel(ds);
                    }
                    else if (txtStDate.Text == "" && txtEndDate.Text == "")
                    {
                        AdminLoginData ad = new AdminLoginData();
                        DataSet ds = ad.getDetails("SELECT o.id,o.vehicle,o.manufacturer,o.state,o.classs,o.fuel,o.bharatstage,o.registrationdate,o.registrationno,o.chasisno,o.engineno,o.ownername,o.contactno,o.email,o.gstno,o.states,o.city,o.address,o.Address2,o.rate,o.couriercharages,o.gst,o.netamount,o.orderstatus,o.date,(select name from distibutor where id=o.dealerid) as dealer FROM onlineorder o WHERE o.orderstatus in('success','completed') and o.status=1" + catfilter);
                        getExcel(ds);
                    }
                    else if (txtStDate.Text != "" && txtEndDate.Text == "")
                    {
                        AdminLoginData ad = new AdminLoginData();
                        DataSet ds = ad.getDetails("SELECT o.id,o.vehicle,o.manufacturer,o.state,o.classs,o.fuel,o.bharatstage,o.registrationdate,o.registrationno,o.chasisno,o.engineno,o.ownername,o.contactno,o.email,o.gstno,o.states,o.city,o.address,o.Address2,o.rate,o.couriercharages,o.gst,o.netamount,o.orderstatus,o.date,(select name from distibutor where id=o.dealerid) as dealer FROM onlineorder o WHERE o.orderstatus in('success','completed') and o.status=1 and (o.date >= '" + (DateTime.Parse(txtStDate.Text)).ToString("yyyy-MM-dd") + " 00:00' )" + catfilter);
                        getExcel(ds);
                    }
                    else if (txtStDate.Text == "" && txtEndDate.Text != "")
                    {
                        AdminLoginData ad = new AdminLoginData();
                        DataSet ds = ad.getDetails("SELECT o.id,o.vehicle,o.manufacturer,o.state,o.classs,o.fuel,o.bharatstage,o.registrationdate,o.registrationno,o.chasisno,o.engineno,o.ownername,o.contactno,o.email,o.gstno,o.states,o.city,o.address,o.Address2,o.rate,o.couriercharages,o.gst,o.netamount,o.orderstatus,o.date,(select name from distibutor where id=o.dealerid) as dealer FROM onlineorder o WHERE o.orderstatus in('success','completed') and o.status=1 and (o.date <= '" + txtEndDate.Text + "')" + catfilter);
                        getExcel(ds);
                    }
                }
                else
                {
                    lblError.Text = "* Start Date must be less then End Date";
                }
            }
            else
            {
                lblError.Text = "* Select Start Date and End Date";
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
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class rate_chart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //AdminLoginData ad = new AdminLoginData();
        //DataSet ds = ad.getDetails("select * from ratechart where status=1 and ext=" + SessionVeriables.UserId);
        //rptrUser.DataSource = ds;
        //rptrUser.DataBind();
        try
        {
            if (!IsPostBack)
            {
                pnlAdd.Visible = false;
                pnlUpdate.Visible = false;
                pnlView.Visible = true;
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select r.id,r.manu_company,r.type,r.sizefront,r.sizeback,r.vehicleclass,r.vehicletype,r.rate,r.tax,r.other,r.netamount,r.status,r.ext,d.name from ratechart r join distibutor d on d.id=r.ext order by d.name");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();


                DataSet ds1 = ad.getDetails("select * from vehicleclass where status=1 order by type");
                ddlVehicleClass.DataSource = ds1;
                ddlVehicleClass.DataTextField = "type";
                ddlVehicleClass.DataValueField = "id";
                ddlVehicleClass.DataBind();
                ddlVehicleClass.Items.Insert(0, "Select Class");
                ddlVehicleClass.SelectedIndex = 0;

                eddlVehicleClass.DataSource = ds1;
                eddlVehicleClass.DataTextField = "type";
                eddlVehicleClass.DataValueField = "id";
                eddlVehicleClass.DataBind();
                eddlVehicleClass.Items.Insert(0, "Select Class");
                eddlVehicleClass.SelectedIndex = 0;

                DataSet dsType = ad.getDetails("select * from vehicletype where status=1 order by type");
                ddlVehicleType.DataSource = dsType;
                ddlVehicleType.DataTextField = "type";
                ddlVehicleType.DataValueField = "id";
                ddlVehicleType.DataBind();
                ddlVehicleType.Items.Insert(0, "Select Type");
                ddlVehicleType.SelectedIndex = 0;

                eddlVehicleType.DataSource = dsType;
                eddlVehicleType.DataTextField = "type";
                eddlVehicleType.DataValueField = "id";
                eddlVehicleType.DataBind();
                eddlVehicleType.Items.Insert(0, "Select Type");
                eddlVehicleType.SelectedIndex = 0;


                DataSet dsTy = ad.getDetails("SELECT o.id,o.type FROM ordertype o where o.status=1 order by o.type");
                ddlType.DataSource = dsTy;
                ddlType.DataTextField = "type";
                ddlType.DataValueField = "id";
                ddlType.DataBind();
                eddlType.DataSource = dsTy;
                eddlType.DataTextField = "type";
                eddlType.DataValueField = "id";
                eddlType.DataBind();
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
            if (txtRate.Text != "")
            {
                RateChartData ad = new RateChartData();
                ad.manu_company = txtManufacturerCompany.Text;
                ad.type = ddlType.SelectedItem.ToString();
                ad.vehicleclass = ddlVehicleClass.SelectedItem.ToString();
                ad.vehicletype = ddlVehicleType.SelectedItem.ToString();
                ad.rate = txtRate.Text;
                ad.tax = (((double.Parse(txtRate.Text) + double.Parse(txtOtherAmount.Text)) * 18) / 100).ToString();
                ad.other = txtOtherAmount.Text;
                ad.ext = int.Parse(ddlDelaer.SelectedValue.ToString());
                ad.netamount = (double.Parse(txtRate.Text) + double.Parse(txtOtherAmount.Text) + ((double.Parse(txtRate.Text) + double.Parse(txtOtherAmount.Text)) * 18) / 100).ToString();
                ad.Save();
                txtManufacturerCompany.Text = "";
                Response.Redirect("rate-chart.aspx");
            }
            else
            {
                lblMsg.Text = "* Enter Rate";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (etxtRate.Text != "")
            {
                RateChartData ad = new RateChartData();
                ad.manu_company = etxtManufacturerCompany.Text;
                ad.type = eddlType.SelectedItem.ToString();
                ad.vehicleclass = eddlVehicleClass.SelectedItem.ToString();
                ad.vehicletype = eddlVehicleType.SelectedItem.ToString();
                ad.rate = etxtRate.Text;
                ad.tax = (((double.Parse(etxtRate.Text) + double.Parse(etxtOtherAmount.Text)) * 18) / 100).ToString();
                ad.other = etxtOtherAmount.Text;
                ad.netamount = (double.Parse(etxtRate.Text) + double.Parse(etxtOtherAmount.Text) + ((double.Parse(etxtRate.Text) + double.Parse(etxtOtherAmount.Text)) * 18) / 100).ToString();
                ad.update(int.Parse(lblId.Text));
                Response.Redirect("rate-chart.aspx");
            }
            else
            {
                lblUpdateError.Text = "* Enter State Name";
                lblUpdateError.ForeColor = System.Drawing.Color.Red;
                lblUpdateError.Font.Bold = true;
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
        try
        {
            int ids = int.Parse(e.CommandArgument.ToString());
            string comm = e.CommandName;
            lblId.Text = ids.ToString();
            if (comm == "edit")
            {
                RateChartData ad = new RateChartData(ids);
                etxtManufacturerCompany.Text = ad.manu_company;
                eddlVehicleClass.ClearSelection();
                eddlVehicleClass.Items.FindByText(ad.vehicleclass).Selected = true;
                eddlVehicleType.ClearSelection();
                eddlVehicleType.Items.FindByText(ad.vehicletype).Selected = true;

                eddlType.ClearSelection();
                eddlType.Items.FindByText(ad.type).Selected = true;
                etxtRate.Text = ad.rate;
                etxtOtherAmount.Text = ad.other;
                DistibutorData dd = new DistibutorData(ad.ext);
                lblDealerName.Text = dd.name;
                pnlAdd.Visible = false;
                pnlUpdate.Visible = true;
                pnlView.Visible = false;
            }
            else if (comm == "delete")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("update ratechart set status=0 where id=" + ids);
                Response.Redirect("rate-chart.aspx");
            }
            else if (comm == "unblock")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("update ratechart set status=1 where id=" + ids);
                Response.Redirect("rate-chart.aspx");
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
    protected void lnkbtnAdd_Click(object sender, EventArgs e)
    {
        pnlAdd.Visible = true;
        pnlUpdate.Visible = false;
        pnlView.Visible = false;
        AdminLoginData ad = new AdminLoginData();
        DataSet ds1 = ad.getDetails("SELECT d.id,d.name FROM distibutor d WHERE d.status=1 order by d.name");
        ddlDelaer.DataSource = ds1;
        ddlDelaer.DataTextField = "name";
        ddlDelaer.DataValueField = "id";
        ddlDelaer.DataBind();
        ddlDelaer.Items.Insert(0, "Select Dealer");
        ddlDelaer.SelectedIndex = 0;
    }
}
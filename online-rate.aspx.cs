using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class online_rate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                pnlAdd.Visible = false;
                pnlUpdate.Visible = false;
                pnlView.Visible = true;
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select r.id,r.cate,r.amount,r.state,r.gst,r.netamount,r.status,s.name from rateonline r join state s on s.id=r.state");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
                DataSet dscat = ad.getDetails("select id,type as vtype from vehicletype where status=1 order by vtype");
                ddlVehicleClass.DataSource = dscat;
                ddlVehicleClass.DataTextField = "vtype";
                ddlVehicleClass.DataValueField = "id";
                ddlVehicleClass.DataBind();
                ddlVehicleClass.Items.Insert(0, "---Select category---");
                ddlVehicleClass.SelectedIndex = 0;

                uddlVehicleClass.DataSource = dscat;
                uddlVehicleClass.DataTextField = "vtype";
                uddlVehicleClass.DataValueField = "id";
                uddlVehicleClass.DataBind();
                uddlVehicleClass.Items.Insert(0, "---Select category---");
                uddlVehicleClass.SelectedIndex = 0;

                DataSet dsState = ad.getDetails("SELECT s.id,s.name FROM state s WHERE s.status=1 order by s.name");
                ddlState.DataSource = dsState;
                ddlState.DataTextField = "name";
                ddlState.DataValueField = "id";
                ddlState.DataBind();
                ddlState.Items.Insert(0, "---Select State---");
                ddlState.SelectedIndex = 0;

                uddlState.DataSource = dsState;
                uddlState.DataTextField = "name";
                uddlState.DataValueField = "id";
                uddlState.DataBind();
                uddlState.Items.Insert(0, "---Select State---");
                uddlState.SelectedIndex = 0;
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
            RateOnlineData ad1 = new RateOnlineData(ddlVehicleClass.SelectedItem.ToString(), int.Parse(ddlState.SelectedValue.ToString()));
            if (!ad1.HasValue)
            {
                RateOnlineData ad = new RateOnlineData();
                ad.cate = ddlVehicleClass.SelectedItem.ToString();
                ad.amount = double.Parse(txtAmount.Text);
                //    ad.couriercharge = double.Parse(txtCourierCharges.Text);
                ad.state = int.Parse(ddlState.SelectedValue.ToString());
                ad.gst = (((double.Parse(txtAmount.Text)) * 18) / 100);
                ad.netamount = (double.Parse(txtAmount.Text) + ((double.Parse(txtAmount.Text)) * 18) / 100);
                ad.Save();
                Response.Redirect("online-rate.aspx");
            }
            else
            {
                lblMsg.Text = "* Enter Category Rate Already Exist";
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
            RateOnlineData ad = new RateOnlineData();
            ad.cate = uddlVehicleClass.SelectedItem.ToString();
            ad.amount = double.Parse(utxtAmount.Text);
            //      ad.couriercharge = double.Parse(utxtCourierCharges.Text);
            ad.state = int.Parse(uddlState.SelectedValue.ToString());
            ad.gst = (((double.Parse(utxtAmount.Text)) * 18) / 100);
            ad.netamount = (double.Parse(utxtAmount.Text) + ((double.Parse(utxtAmount.Text)) * 18) / 100);
            ad.update(int.Parse(lblId.Text));
            Response.Redirect("online-rate.aspx");
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
                RateOnlineData ad = new RateOnlineData(ids);
                utxtAmount.Text = ad.amount.ToString();
                uddlVehicleClass.ClearSelection();
                uddlVehicleClass.Items.FindByText(ad.cate).Selected = true;
                StateDetails sd = new StateDetails(ad.state);
                uddlState.ClearSelection();
                uddlState.Items.FindByText(sd.name).Selected = true;
                //     utxtCourierCharges.Text = ad.couriercharge.ToString();
                pnlAdd.Visible = false;
                pnlUpdate.Visible = true;
                pnlView.Visible = false;
            }
            else if (comm == "delete")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("update rateonline set status=0 where id=" + ids);
                Response.Redirect("online-rate.aspx");
            }
            else if (comm == "unblock")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("update rateonline set status=1 where id=" + ids);
                Response.Redirect("online-rate.aspx");
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
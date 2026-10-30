using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frame_rate : System.Web.UI.Page
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
                DataSet ds = ad.getDetails("SELECT f.id,f.amount,f.vid,f.status FROM frames f  WHERE f.status=1");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();

                //DataSet ds1 = ad.getDetails("select * from vehicletype where status=1");
                //ddlVehicleType.DataSource = ds1;
                //ddlVehicleType.DataTextField = "type";
                //ddlVehicleType.DataValueField = "id";
                //ddlVehicleType.DataBind();
                //ddlVehicleType.Items.Insert(0, "Select State");
                //ddlVehicleType.SelectedIndex = 0;
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
            if (double.Parse(txtAmount.Text) > 0)
            {

                FrameData ald = new FrameData(ddlVehicleType.SelectedItem.ToString());
                if (!ald.HasValue)
                {
                    FrameData ad = new FrameData();
                    ad.vid = ddlVehicleType.SelectedItem.ToString();
                    ad.amount = double.Parse(txtAmount.Text);
                    ad.Save();
                    txtAmount.Text = "";
                    Response.Redirect("frame-rate.aspx");
                }
                else
                {
                    lblMsg.Text = "* Frame Rate already exist";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Font.Bold = true;
                }
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

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtAmount.Text = "";
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (double.Parse(etxtAmount.Text) > 0)
            {
                FrameData ad = new FrameData();
                ad.amount = double.Parse(etxtAmount.Text);
                ad.update(int.Parse(lblId.Text));
                Response.Redirect("frame-rate.aspx");
            }
            else
            {
                lblUpdateError.Text = "* Enter Frame Rate";
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

    protected void btnResetupdate_Click(object sender, EventArgs e)
    {
        etxtAmount.Text = "";
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
                FrameData ad = new FrameData(ids);
                //VehicleTypeData vd = new VehicleTypeData(ad.vid);
                etxtAmount.Text = ad.amount.ToString();
                lblVehicleType.Text = ad.vid;
                pnlAdd.Visible = false;
                pnlUpdate.Visible = true;
                pnlView.Visible = false;
            }
            else if (comm == "delete")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("update frames set status=0 where id=" + ids);
                Response.Redirect("frame-rate.aspx");
            }
            else if (comm == "unblock")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("update frames set status=1 where id=" + ids);
                Response.Redirect("frame-rate.aspx");
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
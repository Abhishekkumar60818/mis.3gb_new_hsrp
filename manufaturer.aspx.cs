using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manufaturer : System.Web.UI.Page
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
                CityDetails ad = new CityDetails();
                DataSet ds = ad.getDetails("select * from manufacturer");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
                //CityDetails msdata = new CityDetails();
                //DataSet ds1 = msdata.getDetails("select * from vehicletype order by type");
                //ddlVehicleType.DataSource = ds1;
                //ddlVehicleType.DataTextField = "type";
                //ddlVehicleType.DataValueField = "id";
                //ddlVehicleType.DataBind();
                //ddlVehicleType.Items.Insert(0, "Select Type");
                //ddlVehicleType.SelectedIndex = 0;

                //uddlVehicleType.DataSource = ds1;
                //uddlVehicleType.DataTextField = "type";
                //uddlVehicleType.DataValueField = "id";
                //uddlVehicleType.DataBind();
                //uddlVehicleType.Items.Insert(0, "Select Type");
                //uddlVehicleType.SelectedIndex = 0;
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
            if (txtManufacturerName.Text != "")
            {
                if (ddlVehicleType.SelectedItem.ToString() != "Select Type")
                {
                    ManufacturerData ald = new ManufacturerData(txtManufacturerName.Text, ddlVehicleType.SelectedItem.ToString());
                    if (!ald.HasValue)
                    {
                        ManufacturerData ad = new ManufacturerData();
                        ad.manufacture = txtManufacturerName.Text;
                        ad.vtype = ddlVehicleType.SelectedItem.ToString();
                        ad.Save();

                        txtManufacturerName.Text = "";
                        ddlVehicleType.SelectedIndex = 0;
                        Response.Redirect("manufaturer.aspx");
                    }
                    else
                    {
                        lblMsg.Text = "* Manufacturer Already Exist";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Font.Bold = true;
                    }
                }
                else
                {
                    lblMsg.Text = "* Select Type";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Font.Bold = true;
                }
            }
            else
            {
                lblMsg.Text = "* Enter Manufacturer Name";
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
        try
        {
            ddlVehicleType.SelectedIndex = 0;
            txtManufacturerName.Text = "";
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
            if (utxtManufacturerName.Text != "")
            {
                if (uddlVehicleType.SelectedItem.ToString() != "Select Type")
                {
                    ManufacturerData ad = new ManufacturerData();
                    ad.manufacture = utxtManufacturerName.Text;
                    ad.vtype = uddlVehicleType.SelectedItem.ToString();
                    ad.update(int.Parse(lblId.Text));
                    Response.Redirect("manufaturer.aspx");
                }
                else
                {
                    Label1.Text = "* Select Type";
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Font.Bold = true;
                }
            }
            else
            {
                Label1.Text = "* Enter Manufacturer Name";
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Font.Bold = true;
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
        try
        {
            uddlVehicleType.SelectedIndex = 0;
            utxtManufacturerName.Text = "";
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
        try
        {
            pnlAdd.Visible = true;
            pnlUpdate.Visible = false;
            pnlView.Visible = false;
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
                ManufacturerData ad = new ManufacturerData(ids);

                utxtManufacturerName.Text = ad.manufacture;
                uddlVehicleType.ClearSelection();
                uddlVehicleType.Items.FindByText(ad.vtype).Selected = true;
                pnlAdd.Visible = false;
                pnlUpdate.Visible = true;
                pnlView.Visible = false;
            }
            else if (comm == "delete")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("update manufacturer set status=0 where id=" + ids);
                Response.Redirect("manufaturer.aspx");
            }
            else if (comm == "unblock")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("update manufacturer set status=1 where id=" + ids);
                Response.Redirect("manufaturer.aspx");
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
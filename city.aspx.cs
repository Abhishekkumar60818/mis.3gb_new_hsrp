using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class city : System.Web.UI.Page
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
                DataSet ds = ad.getDetails("select * from city");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
                CityDetails msdata = new CityDetails();
                DataSet ds1 = msdata.getDetails("select * from state order by name");
                ddlState.DataSource = ds1;
                ddlState.DataTextField = "name";
                ddlState.DataValueField = "id";
                ddlState.DataBind();
                ddlState.Items.Insert(0, "Select State");
                ddlState.SelectedIndex = 0;

                uddlState.DataSource = ds1;
                uddlState.DataTextField = "name";
                uddlState.DataValueField = "id";
                uddlState.DataBind();
                uddlState.Items.Insert(0, "Select State");
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
            if (txtCityName.Text != "")
            {
                if (ddlState.SelectedItem.ToString() != "Select State")
                {
                    CityDetails ald = new CityDetails(txtCityName.Text, ddlState.SelectedItem.ToString());
                    if (!ald.HasValue)
                    {
                        CityDetails ad = new CityDetails();
                        ad.city = txtCityName.Text;
                        ad.state = ddlState.SelectedItem.ToString();
                        ad.Save();

                        txtCityName.Text = "";
                        ddlState.SelectedIndex = 0;
                        Response.Redirect("City.aspx");
                    }
                    else
                    {
                        lblMsg.Text = "* City Already Exist";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Font.Bold = true;
                    }
                }
                else
                {
                    lblMsg.Text = "* Select State";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Font.Bold = true;
                }
            }
            else
            {
                lblMsg.Text = "* Enter City Name";
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
            ddlState.SelectedIndex = 0;
            txtCityName.Text = "";
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
            if (utxtCityName.Text != "")
            {
                if (uddlState.SelectedItem.ToString() != "Select State")
                {
                    CityDetails ad = new CityDetails();
                    ad.city = utxtCityName.Text;
                    ad.state = uddlState.SelectedItem.ToString();
                    ad.update(int.Parse(lblId.Text));
                    Response.Redirect("City.aspx");
                }
                else
                {
                    Label1.Text = "* Select State";
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Font.Bold = true;
                }
            }
            else
            {
                Label1.Text = "* Enter City Name";
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
            uddlState.SelectedIndex = 0;
            utxtCityName.Text = "";
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
                CityDetails ad = new CityDetails(ids);

                utxtCityName.Text = ad.city;
                uddlState.ClearSelection();
                uddlState.Items.FindByText(ad.state).Selected = true;
                pnlAdd.Visible = false;
                pnlUpdate.Visible = true;
                pnlView.Visible = false;
            }
            else if (comm == "delete")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("update city set status=0 where id=" + ids);
                Response.Redirect("city.aspx");
            }
            else if (comm == "unblock")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("update city set status=1 where id=" + ids);
                Response.Redirect("city.aspx");
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
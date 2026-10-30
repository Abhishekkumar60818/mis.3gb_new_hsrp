using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class rto_dto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                pnlAdd.Visible = false;
                pnlUpdate.Visible = false;
                pnlView.Visible = true;
                DistibutorData ad = new DistibutorData();
                DataSet ds = ad.getDetails("select * from rto");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();

                DataSet ds1 = ad.getDetails("SELECT * FROM state WHERE status=1 order by name");
                ddlState.DataSource = ds1;
                ddlState.DataTextField = "name";
                ddlState.DataValueField = "id";
                ddlState.DataBind();
                ddlState.Items.Insert(0, "Select State");
                ddlState.SelectedIndex = 0;

                eddlState.DataSource = ds1;
                eddlState.DataTextField = "name";
                eddlState.DataValueField = "id";
                eddlState.DataBind();
                eddlState.Items.Insert(0, "Select State");
                eddlState.SelectedIndex = 0;

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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            RTOData ald = new RTOData(txtUserName.Text);
            if (!ald.HasValue)
            {
                RTOData ad = new RTOData();
                ad.username = txtUserName.Text;
                ad.passwords = txtPassword.Text;
                ad.rtocode = txtRTOCode.Text;
                ad.state = ddlState.SelectedItem.ToString();
                ad.city = ddlCity.SelectedItem.ToString();
                ad.Save();
                Response.Redirect("rto-dto.aspx");
            }
            else
            {
                lblMsg.Text = "* User Name already exist";
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

            RTOData ad = new RTOData();
            ad.username = etxtUserName.Text;
            ad.passwords = etxtPassword.Text;
            ad.rtocode = (etxtRTOCode.Text);
            ad.state = eddlState.SelectedItem.ToString();
            ad.city = eddlCity.SelectedItem.ToString();
            ad.updateadmin(int.Parse(lblId.Text));
            Response.Redirect("rto-dto.aspx");
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
                RTOData ad = new RTOData(ids);
                //DataSet DsStockist = ad.getDetails("SELECT * FROM distibutor WHERE status=1 and extra=0 and DType='Stockists' order by name");


                etxtUserName.Text = ad.username;
                etxtPassword.Text = ad.passwords;
                etxtRTOCode.Text = ad.rtocode;
                eddlState.ClearSelection();
                eddlState.Items.FindByText(ad.state).Selected = true;
                DataSet ds1 = ad.getDetails("SELECT * FROM city WHERE status=1 and state='" + ad.state + "'");
                eddlCity.DataSource = ds1;
                eddlCity.DataTextField = "city";
                eddlCity.DataValueField = "id";
                eddlCity.DataBind();
                eddlCity.ClearSelection();
                eddlCity.Items.FindByText(ad.city).Selected = true;
                pnlAdd.Visible = false;
                pnlUpdate.Visible = true;
                pnlView.Visible = false;
            }
            else if (comm == "delete")
            {
                DistibutorData ad = new DistibutorData();
                DataSet ds = ad.getDetails("update rto set status=0 where id=" + ids);
                Response.Redirect("rto-dto.aspx");
            }
            else if (comm == "unblock")
            {
                DistibutorData ad = new DistibutorData();
                DataSet ds = ad.getDetails("update rto set status=1 where id=" + ids);
                Response.Redirect("rto-dto.aspx");
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
            if (ddlState.SelectedItem.ToString() != "Select State")
            {
                DistibutorData ad = new DistibutorData();
                DataSet ds1 = ad.getDetails("SELECT * FROM city WHERE status=1 and state='" + ddlState.SelectedItem.ToString() + "'  order by city");
                ddlCity.DataSource = ds1;
                ddlCity.DataTextField = "city";
                ddlCity.DataValueField = "id";
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, "Select City");
                ddlCity.SelectedIndex = 0;
            }
            else
            {
                lblMsg.Text = "* Select State First";
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

    protected void uddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (eddlState.SelectedItem.ToString() != "Select State")
            {
                DistibutorData ad = new DistibutorData();
                DataSet ds1 = ad.getDetails("SELECT * FROM city WHERE status=1 and state='" + eddlState.SelectedItem.ToString() + "' order by city");
                eddlCity.DataSource = ds1;
                eddlCity.DataTextField = "city";
                eddlCity.DataValueField = "id";
                eddlCity.DataBind();
                eddlCity.Items.Insert(0, "Select City");
                eddlCity.SelectedIndex = 0;
            }
            else
            {
                Label1.Text = "* Select State First";
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
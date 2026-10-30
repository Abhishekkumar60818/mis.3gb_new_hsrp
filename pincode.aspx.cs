using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pincode : System.Web.UI.Page
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
                DataSet ds = ad.getDetails("SELECT p.id,p.pincode,c.city,p.status FROM pincode p join city c on c.id=p.cityid WHERE p.status=1 and c.status=1");
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

            PinCodeData ad = new PinCodeData();
            ad.cityid = int.Parse(txtCityName.SelectedValue.ToString());
            ad.pincode = int.Parse(txtPIncCode.Text);
            ad.Save();

            Response.Redirect("pincode.aspx");

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
                PinCodeData ad = new PinCodeData(ids);
                CityDetails ccd = new CityDetails(ad.cityid);
                //utxtCityName.Text = ad.city;
                getUpdateState(ccd.state);
                utxtCityName.ClearSelection();
                utxtCityName.Items.FindByText(ccd.city).Selected = true;
                uddlState.ClearSelection();
                uddlState.Items.FindByText(ccd.state).Selected = true;
                etxtPinCode.Text = ad.pincode.ToString();
                pnlAdd.Visible = false;
                pnlUpdate.Visible = true;
                pnlView.Visible = false;
            }
            else if (comm == "delete")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("update pincode set status=0 where id=" + ids);
                Response.Redirect("pincode.aspx");
            }
            else if (comm == "unblock")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("update pincode set status=1 where id=" + ids);
                Response.Redirect("pincode.aspx");
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

    private void getUpdateState(string st)
    {
        if (st != "Select State")
        {
            CityDetails msdata = new CityDetails();
            DataSet ds1 = msdata.getDetails("SELECT * FROM city WHERE status=1 and state='" + st + "' order by city");
            utxtCityName.DataSource = ds1;
            utxtCityName.DataTextField = "city";
            utxtCityName.DataValueField = "id";
            utxtCityName.DataBind();
            utxtCityName.Items.Insert(0, "Select City");
            utxtCityName.SelectedIndex = 0;
        }
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedItem.ToString() != "Select State")
        {
            CityDetails msdata = new CityDetails();
            DataSet ds1 = msdata.getDetails("SELECT * FROM city WHERE status=1 and state='" + ddlState.SelectedItem.ToString() + "' order by city");
            txtCityName.DataSource = ds1;
            txtCityName.DataTextField = "city";
            txtCityName.DataValueField = "id";
            txtCityName.DataBind();
            txtCityName.Items.Insert(0, "Select City");
            txtCityName.SelectedIndex = 0;
        }
    }

    protected void uddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        getUpdateState(uddlState.SelectedItem.ToString());
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user : System.Web.UI.Page
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
                DataSet ds = ad.getDetails("select * from adminlogin");
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
            if (txtUserName.Text != "")
            {
                if (txtPassword.Text != "")
                {
                    AdminLoginData ald = new AdminLoginData(txtUserName.Text);
                    if (!ald.HasValue)
                    {
                        var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);
                        //DateTime dt = DateTime.ParseExact(now.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        //  string dddate = dt.ToString("yyyy-MM-dd");
                        AdminLoginData ad = new AdminLoginData();
                        ad.username = txtUserName.Text;
                        ad.pass = txtPassword.Text;
                        ad.role = ddlRole.SelectedValue.ToString();
                        ad.date = now.ToString("yyyy-MM-dd");
                        ad.Save();
                        txtPassword.Text = "";
                        txtUserName.Text = "";
                        ddlRole.SelectedIndex = 0;
                        Response.Redirect("User.aspx");
                    }
                    else
                    {
                        lblMsg.Text = "* User Already Exist";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Font.Bold = true;
                    }
                }
                else
                {
                    lblMsg.Text = "* Enter Password";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Font.Bold = true;
                }
            }
            else
            {
                lblMsg.Text = "* Enter User Name";
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
        ddlRole.SelectedIndex = 0;
        txtPassword.Text = "";
        txtUserName.Text = "";
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (utxtPassword.Text != "" && utxtUserName.Text != "")
            {
                AdminLoginData ad = new AdminLoginData();
                ad.username = utxtUserName.Text;
                ad.pass = utxtPassword.Text;
                ad.role = uddlRole.SelectedValue.ToString();
                ad.update(int.Parse(lblId.Text));
                Response.Redirect("User.aspx");
            }
            else
            {
                Label1.Text = "* Enter User Name & Password";
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
        uddlRole.SelectedIndex = 0;
        utxtPassword.Text = "";
        utxtUserName.Text = "";
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
                AdminLoginData ad = new AdminLoginData(ids);
                utxtPassword.Text = ad.pass;
                utxtUserName.Text = ad.username;
                uddlRole.ClearSelection();
                uddlRole.Items.FindByText(ad.role).Selected = true;
                pnlAdd.Visible = false;
                pnlUpdate.Visible = true;
                pnlView.Visible = false;
            }
            else if (comm == "delete")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("update adminlogin set status=0 where id=" + ids);
                Response.Redirect("User.aspx");
            }
            else if (comm == "unblock")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("update adminlogin set status=1 where id=" + ids);
                Response.Redirect("User.aspx");
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
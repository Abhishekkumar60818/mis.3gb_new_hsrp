using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class size_master : System.Web.UI.Page
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
                DataSet ds = ad.getDetails("select * from size");
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
            if (txtStateName.Text != "")
            {

                SizeMasterData ald = new SizeMasterData(txtStateName.Text);
                if (!ald.HasValue)
                {
                    SizeMasterData ad = new SizeMasterData();
                    ad.sizes = txtStateName.Text;
                    ad.Save();
                    txtStateName.Text = "";
                    Response.Redirect("size-master.aspx");
                }
                else
                {
                    lblMsg.Text = "* Size already exist";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Font.Bold = true;
                }
            }
            else
            {
                lblMsg.Text = "* Enter Size";
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
        txtStateName.Text = "";
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (utxtStateName.Text != "")
            {
                SizeMasterData ad = new SizeMasterData();
                ad.sizes = utxtStateName.Text;
                ad.update(int.Parse(lblId.Text));
                Response.Redirect("size-master.aspx");
            }
            else
            {
                lblUpdateError.Text = "* Enter Size";
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
        utxtStateName.Text = "";
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
                SizeMasterData ad = new SizeMasterData(ids);
                utxtStateName.Text = ad.sizes;
                pnlAdd.Visible = false;
                pnlUpdate.Visible = true;
                pnlView.Visible = false;
            }
            else if (comm == "delete")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("update size set status=0 where id=" + ids);
                Response.Redirect("size-master.aspx");
            }
            else if (comm == "unblock")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("update size set status=1 where id=" + ids);
                Response.Redirect("size-master.aspx");
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
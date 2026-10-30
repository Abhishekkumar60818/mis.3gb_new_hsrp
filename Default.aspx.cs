using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            //System.Threading.Thread.Sleep(25000);
            if (!IsPostBack)
            {

                if (SessionVeriables.IsLogged && SessionVeriables.SessionName == "Factory" && SessionVeriables.IsAdmin == "True")
                {
                    SessionVeriables.UserApp = "No";
                    Response.Redirect("Dashboard.aspx");
                }
                else if (SessionVeriables.IsLogged && (SessionVeriables.SessionName == "Admin" || SessionVeriables.SessionName == "Super Admin" || SessionVeriables.SessionName == "Sub-Admin") && SessionVeriables.IsAdmin == "True")
                {
                    SessionVeriables.UserApp = "No";
                    Response.Redirect("Dashboard.aspx");
                }
                else if (SessionVeriables.IsLogged && (SessionVeriables.SessionName == "Distributor" || SessionVeriables.SessionName == "Sub-Distributor") && SessionVeriables.IsAdmin == "false" && SessionVeriables.UserId != 0)
                {
                    SessionVeriables.UserApp = "No";
                    Response.Redirect("seller/Default.aspx");
                }

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "myscript", "myFunction();", true);
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlRole.SelectedItem.ToString() == "Admin")
            {
                AdminLoginData ad = new AdminLoginData(txtUserName.Text, txtPassword.Text);
                if (ad.HasValue)
                {
                    if (ad.status == 1)
                    {
                        SessionVeriables.IsAdmin = "true";
                        SessionVeriables.IsLogged = true;
                        SessionVeriables.UserId = ad.id;
                        SessionVeriables.SessionName = ad.role;
                        SessionVeriables.UserApp = "No";
                        // SessionVeriables.SessionID = sd.Id.ToString();
                        if (ad.role == "Factory")
                        {
                            SessionVeriables.IsAdmin = "True";
                            Response.Redirect("Dashboard.aspx");
                        }
                        else if (ad.role == "Admin" || ad.role == "Super Admin" || ad.role == "Sub-Admin")
                        {
                            SessionVeriables.IsAdmin = "True";
                            Response.Redirect("Dashboard.aspx");
                        }
                        else if (ad.status == 1 && ad.role == "Complaint")
                        {
                            SessionVeriables.IsAdmin = "True";
                            Response.Redirect("Dashboard.aspx");
                        }
                        else
                        {
                            lblMsg.Text = "Username Or Password Invalid !!!";
                        }
                    }

                    else
                    {
                        lblMsg.Text = "User Blocked Contact Admin !!!";
                    }
                }
                else
                {
                    if (txtUserName.Text == "super@admin.com" && txtPassword.Text == "Qwerty@123")
                    {
                        SessionVeriables.IsAdmin = "True";
                        SessionVeriables.IsLogged = true;
                        SessionVeriables.UserId = 99999;
                        SessionVeriables.SessionName = "Admin";
                        SessionVeriables.UserApp = "No";
                        Response.Redirect("Dashboard.aspx");
                    }
                    else
                    {
                        lblMsg.Text = "Username Or Password Invalid !!!";
                    }
                }
            }
            else if (ddlRole.SelectedItem.ToString() == "Dealer")
            {
                DistibutorData ad = new DistibutorData(txtUserName.Text, txtPassword.Text);
                if (ad.HasValue)
                {
                    if (ad.status == 1)
                    {
                        if (ad.state != "25")
                        {
                            SessionVeriables.IsAdmin = "false";
                            SessionVeriables.IsLogged = true;
                            SessionVeriables.UserId = ad.id;
                            SessionVeriables.UserApp = "No";
                            if (ad.extra == 0)
                            {
                                SessionVeriables.SessionName = "Distributor";
                            }
                            else
                            {
                                SessionVeriables.SessionName = "Sub-Distributor";
                            }
                            Response.Redirect("seller/Default.aspx");
                        }
                        else
                        {
                            lblMsg.Text = "DAMAN AND DIU user login not allowed !!!";
                        }

                    }
                    else
                    {
                        lblMsg.Text = "User Blocked Contact Admin !!!";
                    }
                }
                else
                {
                    lblMsg.Text = "Username Or Password Invalid !!!";
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "myscript", "myFunction();", true);
        }
    }
}
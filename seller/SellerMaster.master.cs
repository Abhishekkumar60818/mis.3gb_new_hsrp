using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class seller_SellerMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //	System.Threading.Thread.Sleep(25000);
        if (!IsPostBack)
        {
            try
            {
                if (SessionVeriables.IsLogged && SessionVeriables.SessionName == "Factory" && SessionVeriables.IsAdmin == "True")
                {
                    Response.Redirect("factory/Default.aspx");
                }
                else if (SessionVeriables.IsLogged && (SessionVeriables.SessionName == "Admin" || SessionVeriables.SessionName == "Super Admin" || SessionVeriables.SessionName == "Sub-Admin") && SessionVeriables.IsAdmin == "True")
                {
                    Response.Redirect("../Dashboard.aspx");
                }
                else if (SessionVeriables.IsLogged && (SessionVeriables.SessionName == "Distributor" || SessionVeriables.SessionName == "Sub-Distributor") && SessionVeriables.IsAdmin == "false" && SessionVeriables.UserId != 0)
                {
                    // Response.Redirect("Distributor/Default.aspx");
                }
                else if (!SessionVeriables.IsLogged)
                {
                    Response.Redirect("../Default.aspx");
                }
                //else
                //{
                //    Response.Redirect("Default.aspx");
                //}
                DistibutorData ad = new DistibutorData(int.Parse(SessionVeriables.UserId.ToString()));
                lblUserName.Text = ad.name;
                SessionVeriables.SessionEmail = ad.name;
                if (ad.DType == "Embossing")
                {
                    plcDealer.Visible = true;
                    plchldrDealer.Visible = false;
                    plcOEM.Visible = false;
                }
                else if (ad.DType == "OEM")
                {
                    plcOEM.Visible = true;
                    plcDealer.Visible = false;
                    plchldrDealer.Visible = false;
                }
                else
                {
                    plcDealer.Visible = false;
                    plcOEM.Visible = false;
                    plchldrDealer.Visible = true;
                }
                //if (ad.id == 3)
                //{
                //    plcGodawari.Visible = true;
                //}
                //else
                //{
                    plcGodawari.Visible = false;
                //}
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
}

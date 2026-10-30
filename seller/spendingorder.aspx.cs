using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class seller_spendingorder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,s.tlp from sellersales s join distibutor d where s.status=1 and s.npid=0 and s.sellerid=d.id and s.sellerid in(SELECT d.id FROM distibutor d WHERE d.status=1 and (d.id=" + SessionVeriables.UserId + " or d.extra=" + SessionVeriables.UserId + ")) and s.npid=0");
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

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string front = txtFrontLaserNo.Text.Trim();
        string rear = txtRearLaserNo.Text.Trim();

        if (front == "" && rear == "")
        {
            lblError.Text = "Enter at least one Laser No.";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            return;
        }
        if (front != "" && rear != "" && front == rear)
        {
            lblError.Text = "Front and Rear laser cannot be same";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            return;
        }

        int headerId;
        if (!int.TryParse(lblId.Text, out headerId))
        {
            lblError.Text = "Invalid order id";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            return;
        }

        // flag mapping
        string vflag = "";
        if (ddlFlag.SelectedItem != null)
        {
            switch (ddlFlag.SelectedItem.ToString())
            {
                case "New Both HSRP": vflag = "NB"; break;
                case "Duplicate Both HSRP": vflag = "DB"; break;
                case "Duplicate Front HSRP": vflag = "DF"; break;
                case "Duplicate Rear HSRP": vflag = "DR"; break;
                case "Old Both HSRP": vflag = "OB"; break;
                default: vflag = ""; break;
            }
        }

        Connection conn = new Connection();
        MySqlTransaction trans = null;
        try
        {
            conn.StartTrans(ref trans);

            // helper to process single laser inside transaction
            Func<string, int> processLaser = (laserno) =>
            {
                var p = new List<MySqlParameter>();
                p.Add(new MySqlParameter("@laserno", laserno));
                p.Add(new MySqlParameter("@did", SessionVeriables.UserId));
                DataSet ds = conn.GetDataset("SELECT si.id, s.id AS stockid, s.laserno FROM stock s JOIN salesitem si ON si.sid=s.id JOIN saleheader sh ON sh.id=si.hid WHERE sh.status=1 AND sh.did=@did AND si.status=1 AND si.sstatus=0 AND s.laserno=@laserno LIMIT 1", p, trans);
                if (ds.Tables[0].Rows.Count == 0) return -1;
                int salesItemId = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
                int stockId = Convert.ToInt32(ds.Tables[0].Rows[0]["stockid"]);

                var p2 = new List<MySqlParameter>();
                p2.Add(new MySqlParameter("@headerid", headerId));
                p2.Add(new MySqlParameter("@itemid", stockId));
                conn.ExecStatement("INSERT INTO selleritem(headerid,itemid) VALUES(@headerid,@itemid)", p2, trans);

                var p3 = new List<MySqlParameter>();
                p3.Add(new MySqlParameter("@sstatus", 1));
                p3.Add(new MySqlParameter("@id", salesItemId));
                conn.ExecStatement("UPDATE salesitem SET sstatus=@sstatus WHERE id=@id", p3, trans);
                return salesItemId;
            };

            if (front != "" && rear != "")
            {
                int f = processLaser(front);
                if (f == -1) { trans.Rollback(); lblError.Text = "Front laser no. not exist in dealer stock"; ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true); return; }
                int r = processLaser(rear);
                if (r == -1) { trans.Rollback(); lblError.Text = "Rear laser no. not exist in dealer stock"; ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true); return; }

                var pu = new List<MySqlParameter>();
                pu.Add(new MySqlParameter("@odtype", vflag));
                pu.Add(new MySqlParameter("@id", headerId));
                conn.ExecStatement("UPDATE sellersales SET npid=1, odtype=@odtype WHERE id=@id", pu, trans);
            }
            else if (front != "")
            {
                int f = processLaser(front);
                if (f == -1) { trans.Rollback(); lblError.Text = "Front laser no. not exist in dealer stock"; ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true); return; }
                var pu = new List<MySqlParameter>();
                pu.Add(new MySqlParameter("@id", headerId));
                conn.ExecStatement("UPDATE sellersales SET npid=1 WHERE id=@id", pu, trans);
            }
            else // rear only
            {
                int r = processLaser(rear);
                if (r == -1) { trans.Rollback(); lblError.Text = "Rear laser no. not exist in dealer stock"; ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true); return; }
                var pu = new List<MySqlParameter>();
                pu.Add(new MySqlParameter("@id", headerId));
                conn.ExecStatement("UPDATE sellersales SET npid=1 WHERE id=@id", pu, trans);
            }

            trans.Commit();
            getDatare();
            ScriptManager.RegisterStartupScript(Page, GetType(), "Whatever", "window.open('../pdf/tlpprint.aspx?id=" + headerId + "','_blank')", true);
        }
        catch (Exception ex)
        {
            try { trans.Rollback(); } catch { }
            string msg = ex.Message.Replace("'", "").Replace("\r", "").Replace("\n", "");
            // MySql timeout -> show friendly
            if (msg.Contains("Timeout") || msg.Contains("Unable to read"))
                lblError.Text = "DB timeout - please retry. If persists, contact admin.";
            else
                lblError.Text = "Update failed: " + msg;
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
        }
        finally
        {
            conn.Dispose();
        }
    }

    private void getDatare()
    {
        AdminLoginData ad = new AdminLoginData();
        DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,s.tlp from sellersales s join distibutor d where s.status=1 and s.npid=0 and s.sellerid=d.id and s.sellerid in(SELECT d.id FROM distibutor d WHERE d.status=1 and (d.id=" + SessionVeriables.UserId + " or d.extra=" + SessionVeriables.UserId + ")) and s.npid=0");
        rptrUser.DataSource = ds;
        rptrUser.DataBind();
    }

    protected void rptrUser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        txtRearLaserNo.Text = "";
        txtFrontLaserNo.Text = "";
        int ids = int.Parse(e.CommandArgument.ToString());
        string comm = e.CommandName;
        lblId.Text = ids.ToString();
        SellerSalesData sd = new SellerSalesData(ids);
        lblChassisNo.Text = sd.chasisno;
        lblEngneNo.Text = sd.engineno;
        lblVehicleNo.Text = sd.registrationno;
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
    }

    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
    }
}

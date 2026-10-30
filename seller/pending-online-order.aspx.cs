using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class seller_pending_online_order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                AdminLoginData ad = new AdminLoginData();
                //DataSet ds = ad.getDetails("select s.id,s.ownername,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,d.name as DName,(select name from distibutor where id=d.extra) as ems from onlinesales s join distibutor d on d.id=s.fitmentcentre where s.status=1 and s.paymentstatus='Success' and s.npid=0 and s.ordertype='high security registration plate for electric vehicle'");
                DataSet ds = ad.getDetails("select s.id,s.ownername,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,(select name from distibutor where id=s.fitmentcentre) as DName,(select name from distibutor where id=s.emsid) as ems from onlinesales s  where s.status=1 and s.paymentstatus='Success' and s.npid=0  and (s.fitmentcentre=" + SessionVeriables.UserId + " or s.emsid=" + SessionVeriables.UserId + ")");
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
    protected void rptrUser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        txtRearLaserNo.Text = "";
        txtFrontLaserNo.Text = "";
        int ids = int.Parse(e.CommandArgument.ToString());
        string comm = e.CommandName;
        lblId.Text = ids.ToString();
        if (comm == "edit")
        {
            OnlineOrderData sd = new OnlineOrderData(ids);
            lblChassisNo.Text = sd.chasisnumber;
            lblEngneNo.Text = sd.enginenumber;
            lblVehicleNo.Text = sd.registrationnumber;
            //DataSet ds1 = sd.getDetails("select si.id,s.id as stockid,s.rateid,sh.date,s.laserno,si.sstatus from stock s join salesitem si join saleheader sh where sh.status=1 and sh.did=" + SessionVeriables.UserId + " and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0");
            //lstDealer.DataSource = ds1;
            //lstDealer.DataTextField = "laserno";
            //lstDealer.DataValueField = "id";
            //lstDealer.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
        }
        if (comm == "view")
        {
            Response.Redirect("vehicle-details.aspx?id=" + ids);
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        //foreach (ListItem item in lstDealer.Items)
        //{
        //    if (item.Selected)
        //    {
        OnlineOrderData chkO = new OnlineOrderData(int.Parse(lblId.Text));
        if (chkO.ordertype != "only colour sticker")
        {
            if (txtRearLaserNo.Text != "" && txtFrontLaserNo.Text != "")
            {
                StockData st = new StockData(txtFrontLaserNo.Text);
                DataSet dsF = st.getDetails("select si.id,s.id as stockid,s.rateid,sh.date,s.laserno,si.sstatus from stock s join salesitem si join saleheader sh where sh.status=1 and sh.did=" + SessionVeriables.UserId + " and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0 and s.laserno='" + txtFrontLaserNo.Text + "'");
                if (dsF.Tables[0].Rows.Count > 0)
                {
                    DataSet dsR = st.getDetails("select si.id,s.id as stockid,s.rateid,sh.date,s.laserno,si.sstatus from stock s join salesitem si join saleheader sh where sh.status=1 and sh.did=" + SessionVeriables.UserId + " and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0 and s.laserno='" + txtRearLaserNo.Text + "'");
                    if (dsR.Tables[0].Rows.Count > 0)
                    {
                        //SaleItemData sitem = new SaleItemData(int.Parse(dsF.Tables[0].Rows[0]["id"].ToString()));
                        OnlineOrderData si = new OnlineOrderData();
                        si.frontlaserno = txtFrontLaserNo.Text;
                        si.rearlaserno = txtRearLaserNo.Text;
                        si.updateLaserBoth(int.Parse(lblId.Text));

                        SaleItemData sd = new SaleItemData();
                        sd.sstatus = 1;
                        sd.updateSold(int.Parse(dsF.Tables[0].Rows[0]["id"].ToString()));

                        SaleItemData sdR = new SaleItemData();
                        sdR.sstatus = 1;
                        sdR.updateSold(int.Parse(dsR.Tables[0].Rows[0]["id"].ToString()));

                        si.getDetails("update onlinesales set npid=1 where id=" + lblId.Text);

                        getDatare();
                        //ScriptManager.RegisterStartupScript(Page, GetType(), "Whatever", "window.open('../pdf/tlpprint.aspx?id=" + int.Parse(lblId.Text) + "','_blank')", true);
                    }
                    else
                    {
                        lblError.Text = "Rear laser no. not exist in dealer stock";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);

                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
                    }
                }
                else
                {
                    lblError.Text = "Front laser no. not exist in dealer stock";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);

                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
                }

            }
            else if (txtRearLaserNo.Text == "" && txtFrontLaserNo.Text != "")
            {
                StockData st = new StockData(txtFrontLaserNo.Text);
                DataSet dsF = st.getDetails("select si.id,s.id as stockid,s.rateid,sh.date,s.laserno,si.sstatus from stock s join salesitem si join saleheader sh where sh.status=1 and sh.did=" + SessionVeriables.UserId + " and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0 and s.laserno='" + txtFrontLaserNo.Text + "'");
                if (dsF.Tables[0].Rows.Count > 0)
                {
                    OnlineOrderData si = new OnlineOrderData();
                    si.frontlaserno = txtFrontLaserNo.Text;
                    //si.rearlaserno = txtRearLaserNo.Text;
                    si.updateLaserFront(int.Parse(lblId.Text));
                    SaleItemData sd = new SaleItemData();
                    sd.sstatus = 1;
                    sd.updateSold(int.Parse(dsF.Tables[0].Rows[0]["id"].ToString()));

                    si.getDetails("update onlinesales set npid=1 where id=" + lblId.Text);
                    getDatare();
                    //ScriptManager.RegisterStartupScript(Page, GetType(), "Whatever", "window.open('../pdf/tlpprint.aspx?id=" + int.Parse(lblId.Text) + "','_blank')", true);

                }
                else
                {
                    lblError.Text = "Front laser no. not exist in dealer stock";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);

                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
                }
            }
            else if (txtRearLaserNo.Text != "" && txtFrontLaserNo.Text == "")
            {
                StockData st = new StockData(txtFrontLaserNo.Text);

                DataSet dsR = st.getDetails("select si.id,s.id as stockid,s.rateid,sh.date,s.laserno,si.sstatus from stock s join salesitem si join saleheader sh where sh.status=1 and sh.did=" + SessionVeriables.UserId + " and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0 and s.laserno='" + txtRearLaserNo.Text + "'");
                if (dsR.Tables[0].Rows.Count > 0)
                {
                    OnlineOrderData si = new OnlineOrderData();
                    //si.frontlaserno = txtFrontLaserNo.Text;
                    si.rearlaserno = txtRearLaserNo.Text;
                    si.updateLaserRear(int.Parse(lblId.Text));
                    SaleItemData sdR = new SaleItemData();
                    sdR.sstatus = 1;
                    sdR.updateSold(int.Parse(dsR.Tables[0].Rows[0]["id"].ToString()));



                    si.getDetails("update onlinesales set npid=1 where id=" + lblId.Text);
                    getDatare();
                    //ScriptManager.RegisterStartupScript(Page, GetType(), "Whatever", "window.open('../pdf/tlpprint.aspx?id=" + int.Parse(lblId.Text) + "','_blank')", true);
                }
                else
                {
                    lblError.Text = "Rear laser no. not exist in dealer stock";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);

                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
                }

            }

        }
        else
        {
            OnlineOrderData si = new OnlineOrderData();
            si.getDetails("update onlinesales set npid=1 where id=" + lblId.Text);
            getDatare();
        }


        //     Response.Redirect("spendingorder.aspx");
    }
    private void getDatare()
    {
        AdminLoginData ad = new AdminLoginData();
        DataSet ds = ad.getDetails("select s.id,s.ownername,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,(select name from distibutor where id=s.fitmentcentre) as DName,(select name from distibutor where id=s.emsid) as ems from onlinesales s  where s.status=1 and s.paymentstatus='Success' and s.npid=0  and (s.fitmentcentre=" + SessionVeriables.UserId + " or s.emsid=" + SessionVeriables.UserId + ")");
        rptrUser.DataSource = ds;
        rptrUser.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtStDate.Text != "" && txtEndDate.Text != "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.ownername,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,(select name from distibutor where id=s.fitmentcentre) as DName,(select name from distibutor where id=s.emsid) as ems from onlinesales s  where s.status=1 and s.paymentstatus='Success' and s.npid=0  and (s.fitmentcentre=" + SessionVeriables.UserId + " or s.emsid=" + SessionVeriables.UserId + ") and  (date_format(str_to_date(s.orderdaate, '%d-%m-%Y'), '%Y-%m-%d') between '" + txtStDate.Text + "' and '" + txtEndDate.Text + "')");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text == "" && txtEndDate.Text == "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.ownername,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,(select name from distibutor where id=s.fitmentcentre) as DName,(select name from distibutor where id=s.emsid) as ems from onlinesales s  where s.status=1 and s.paymentstatus='Success' and s.npid=0  and (s.fitmentcentre=" + SessionVeriables.UserId + " or s.emsid=" + SessionVeriables.UserId + ")");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text != "" && txtEndDate.Text == "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.ownername,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,(select name from distibutor where id=s.fitmentcentre) as DName,(select name from distibutor where id=s.emsid) as ems from onlinesales s  where s.status=1 and s.paymentstatus='Success' and s.npid=0  and (s.fitmentcentre=" + SessionVeriables.UserId + " or s.emsid=" + SessionVeriables.UserId + ") and date_format(str_to_date(s.orderdaate, '%d-%m-%Y'), '%Y-%m-%d') >= '" + txtStDate.Text + "'");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text == "" && txtEndDate.Text != "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.ownername,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,(select name from distibutor where id=s.fitmentcentre) as DName,(select name from distibutor where id=s.emsid) as ems from onlinesales s  where s.status=1 and s.paymentstatus='Success' and s.npid=0  and (s.fitmentcentre=" + SessionVeriables.UserId + " or s.emsid=" + SessionVeriables.UserId + ") and  date_format(str_to_date(s.orderdaate, '%d-%m-%Y'), '%Y-%m-%d') <= '" + txtEndDate.Text + "'");
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
}
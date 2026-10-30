using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pending : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlAdd.Visible = true;
        pnlEdit.Visible = false;
        try
        {
            if (!IsPostBack)
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,(select name from distibutor where id=d.extra) as ems from sellersales s join distibutor d where s.status=1 and s.npid=0 and s.sellerid=d.id ");
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
        if (!IsPostBack)
        {
            AdminLoginData ad = new AdminLoginData();
            DataSet ds = ad.getDetails("select d.id,d.name,d.city,d.state,(SELECT (sum(CASE WHEN ptype ='deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id) as dr,(SELECT (sum(CASE WHEN ptype <>'deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id) as cr,((SELECT (sum(CASE WHEN ptype ='deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id)-(SELECT (sum(CASE WHEN ptype <>'deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id)) as balance from distibutor d where d.status=1 and d.id=" + SessionVeriables.UserId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][6].ToString() != "")
                {
                    if (double.Parse(ds.Tables[0].Rows[0][6].ToString()) > 0)
                    {

                        StateDetails msdata = new StateDetails();
                        DataSet dsState = msdata.getDetails("select * from state where status=1  order by name");
                        ddlState.DataSource = dsState;
                        ddlState.DataTextField = "name";
                        ddlState.DataValueField = "id";
                        ddlState.DataBind();
                        ddlState.Items.Insert(0, "Select State");
                        ddlState.SelectedIndex = 0;


                        DataSet dsVehicleType = msdata.getDetails("select * from vehicletype where status=1 order by type");
                        ddlType.DataSource = dsVehicleType;
                        ddlType.DataTextField = "type";
                        ddlType.DataValueField = "id";
                        ddlType.DataBind();
                        ddlType.Items.Insert(0, "Select Type");
                        ddlType.SelectedIndex = 0;

                        DataSet dsFuelType = msdata.getDetails("select * from fueltype where status=1 order by type");
                        ddlFuelType.DataSource = dsFuelType;
                        ddlFuelType.DataTextField = "type";
                        ddlFuelType.DataValueField = "id";
                        ddlFuelType.DataBind();
                        ddlFuelType.Items.Insert(0, "Select Fuel Type");
                        ddlFuelType.SelectedIndex = 0;

                        DataSet dsClassType = msdata.getDetails("select * from vehicleclass where status=1 order by type");
                        ddlClassType.DataSource = dsClassType;
                        ddlClassType.DataTextField = "type";
                        ddlClassType.DataValueField = "id";
                        ddlClassType.DataBind();
                        ddlClassType.Items.Insert(0, "Select Vehicle Class");
                        ddlClassType.SelectedIndex = 0;

                        DataSet dsOrderType = msdata.getDetails("select * from ordertype where status=1 order by type");
                        ddlOrderType.DataSource = dsOrderType;
                        ddlOrderType.DataTextField = "type";
                        ddlOrderType.DataValueField = "id";
                        ddlOrderType.DataBind();
                        ddlOrderType.Items.Insert(0, "Select Order Type");
                        ddlOrderType.SelectedIndex = 0;
                    }
                    else
                    {
                        lblError.Text = "Insufficient Funds In Accounts. You Are not able to place order.";
                        btnSubmit.Enabled = false;
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
                    }
                }
                else
                {
                    lblError.Text = "Insufficient Funds In Accounts. You Are not able to place order.";
                    btnSubmit.Enabled = false;
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
                }
            }
            else
            {
                lblError.Text = "Insufficient Funds In Accounts. You Are not able to place order.";
                btnSubmit.Enabled = false;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
            }
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        foreach (ListItem item in lstDealer.Items)
        {
            if (item.Selected)
            {
                SellerItemData si = new SellerItemData();
                si.headerid = int.Parse(lblId.Text);
                si.itemid = int.Parse(item.Value);
                si.Save();

                StockData sd = new StockData();
                sd.SoldOut(int.Parse(item.Value));
                si.getDetails("update sellersales set npid=1 where id=" + lblId.Text);
            }
        }
        Response.Redirect("penddingorder.aspx");
    }

    protected void rptrUser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int ids = int.Parse(e.CommandArgument.ToString());
        string comm = e.CommandName;
        lblId.Text = ids.ToString();
        if (comm == "edit")
        {
            lblId.Text = ids.ToString();
            pnlAdd.Visible = false;
            pnlEdit.Visible = true;
            SellerSalesData sd = new SellerSalesData(ids);

            txtVehicle.Text = sd.registrationno;
            txtChasisNo.Text = sd.chasisno;
            txtEngineNo.Text = sd.engineno;
            txtName.Text = sd.name;
            txtContactNo.Text = sd.contactno;
			
			 DataSet dsState = sd.getDetails("select * from state where status=1  order by name");
 ddlState.DataSource = dsState;
 ddlState.DataTextField = "name";
 ddlState.DataValueField = "id";
 ddlState.DataBind();
 ddlState.Items.Insert(0, "Select State");
 ddlState.SelectedIndex = 0;

DataSet dsVehicleType = sd.getDetails("select * from vehicletype where status=1 order by type");
ddlType.DataSource = dsVehicleType;
ddlType.DataTextField = "type";
ddlType.DataValueField = "id";
ddlType.DataBind();
ddlType.Items.Insert(0, "Select Type");
ddlType.SelectedIndex = 0;
DataSet dsFuelType = sd.getDetails("select * from fueltype where status=1 order by type");
ddlFuelType.DataSource = dsFuelType;
ddlFuelType.DataTextField = "type";
ddlFuelType.DataValueField = "id";
ddlFuelType.DataBind();
ddlFuelType.Items.Insert(0, "Select Fuel Type");
ddlFuelType.SelectedIndex = 0;

DataSet dsClassType = sd.getDetails("select * from vehicleclass where status=1 order by type");
ddlClassType.DataSource = dsClassType;
ddlClassType.DataTextField = "type";
ddlClassType.DataValueField = "id";
ddlClassType.DataBind();
ddlClassType.Items.Insert(0, "Select Vehicle Class");
ddlClassType.SelectedIndex = 0;

DataSet dsOrderType = sd.getDetails("select * from ordertype where status=1 order by type");
ddlOrderType.DataSource = dsOrderType;
ddlOrderType.DataTextField = "type";
ddlOrderType.DataValueField = "id";
ddlOrderType.DataBind();
ddlOrderType.Items.Insert(0, "Select Order Type");
ddlOrderType.SelectedIndex = 0;
            ddlState.ClearSelection();
ddlState.Items.FindByText(sd.state).Selected = true;

            DataSet ds1 = sd.getDetails("select * from city where status=1 and state='" + sd.state + "' order by city");
            ddlCity.DataSource = ds1;
            ddlCity.DataTextField = "city";
            ddlCity.DataValueField = "id";
            ddlCity.DataBind();



            ddlCity.ClearSelection();
            ddlCity.Items.FindByText(sd.city).Selected = true;
            ddlType.ClearSelection();
            ddlType.Items.FindByText(sd.vehicletype).Selected = true;
            ddlFuelType.ClearSelection();
            ddlFuelType.Items.FindByText(sd.fueltype).Selected = true;
            ddlClassType.ClearSelection();
            ddlClassType.Items.FindByText(sd.classtype).Selected = true;
            ddlOrderType.ClearSelection();
            ddlOrderType.Items.FindByText(sd.ordertype).Selected = true;
            txtManufactureDate.Value = sd.manufacturedate.ToString();
            txtRegistrationDate.Text = sd.registrationdate.ToString();
            sd.sellerid = SessionVeriables.UserId;
            chklstTLP.Text = sd.tlp.ToString();
            //DataSet ds1 = sd.getDetails("select * from stock where status=1 and sstatus=0 ");
            //lstDealer.DataSource = ds1;
            //lstDealer.DataTextField = "laserno";
            //lstDealer.DataValueField = "id";
            //lstDealer.DataBind();
            //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);


        }
        else if (comm == "cancel")
        {
            SellerSalesData bd = new SellerSalesData();
            bd.BlockUser(ids);
            Response.Redirect("pending.aspx");
        }


    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
       
        SellerSalesData sd = new SellerSalesData();
        sd.registrationno = txtVehicle.Text;
        sd.name = txtName.Text;
        sd.chasisno = txtChasisNo.Text;
        sd.contactno = txtContactNo.Text;
        sd.state = ddlState.SelectedItem.ToString();
        sd.city = ddlCity.SelectedItem.ToString();
        sd.registrationno = txtVehicle.Text.ToUpper();
        sd.chasisno = txtChasisNo.Text;
        sd.engineno = txtEngineNo.Text;
        sd.vehicletype = ddlType.SelectedItem.ToString();
        sd.fueltype = ddlFuelType.SelectedItem.ToString();
        sd.classtype = ddlClassType.SelectedItem.ToString();
        sd.ordertype = ddlOrderType.SelectedItem.ToString();
        sd.registrationdate = DateTime.Parse(txtRegistrationDate.Text);
        string mfgInput2 = txtManufactureDate.Value != null ? txtManufactureDate.Value.Trim() : "";
        string mfgFormatted2;
        if (!TryParseManufactureDate(mfgInput2, out mfgFormatted2))
        {
            lblMsg.Text = "Invalid Date Of Manufacture. Use YYYY-MM (e.g., 2015-05) or YYYY (e.g., 2015)";
            return;
        }
        sd.manufacturedate = mfgFormatted2;
        //sd.sellerid = SessionVeriables.UserId;
        sd.update(int.Parse(lblId.Text));
        pnlAdd.Visible = true;
        pnlEdit.Visible = false;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtStDate.Text != "" && txtEndDate.Text != "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,(select name from distibutor where id=d.extra) as ems from sellersales s join distibutor d where s.status=1 and s.npid=0 and s.sellerid=d.id and  (s.orderdate between '" + txtStDate.Text + "' and '" + txtEndDate.Text + "')");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text == "" && txtEndDate.Text == "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,(select name from distibutor where id=d.extra) as ems from sellersales s join distibutor d where s.status=1 and s.npid=0 and s.sellerid=d.id ");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text != "" && txtEndDate.Text == "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,(select name from distibutor where id=d.extra) as ems from sellersales s join distibutor d where s.status=1 and s.npid=0 and s.sellerid=d.id  and s.orderdate >= '" + txtStDate.Text + "'");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text == "" && txtEndDate.Text != "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,(select name from distibutor where id=d.extra) as ems from sellersales s join distibutor d where s.status=1 and s.npid=0 and s.sellerid=d.id and  s.orderdate <= '" + txtEndDate.Text + "'");
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
    private bool TryParseManufactureDate(string input, out string formatted)
    {
        formatted = null;
        if (string.IsNullOrWhiteSpace(input)) return false;
        input = input.Trim();
        if (Regex.IsMatch(input, @"^\d{4}$"))
        {
            int y; if (int.TryParse(input, out y) && y >= 1900 && y <= 2100) { formatted = string.Format("01-{0}", y); return true; }
            return false;
        }
        DateTime dt;
        string[] formats = new[] { "yyyy-MM", "yyyy-M", "MM-yyyy", "M-yyyy", "yyyy/MM", "MM/yyyy", "MMM yyyy", "MMM-yyyy", "yyyy-MM-dd", "yyyy/MM/dd" };
        if (DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
        {
            formatted = dt.ToString("MM-yyyy");
            return true;
        }
        if (DateTime.TryParse(input, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
        {
            formatted = dt.ToString("MM-yyyy");
            return true;
        }
        return false;
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            StateDetails msdata = new StateDetails();
            DataSet ds1 = msdata.getDetails("select * from city where status=1 and state='" + ddlState.SelectedItem.ToString() + "' order by city");
            ddlCity.DataSource = ds1;
            ddlCity.DataTextField = "city";
            ddlCity.DataValueField = "id";
            ddlCity.DataBind();
            //ddlCity.Items.Insert(0, "Select City");
            //ddlCity.SelectedIndex = 0;
            ddlCity.Focus();
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
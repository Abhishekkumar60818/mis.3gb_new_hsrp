using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class seller_ordeerbookingstockist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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

            DataSet ds1 = msdata.getDetails("select si.id,s.id as stockid,s.rateid,sh.date,s.laserno,si.sstatus from stock s join salesitem si join saleheader sh where sh.status=1 and sh.did=" + SessionVeriables.UserId + " and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0");
            lstDealer.DataSource = ds1;
            lstDealer.DataTextField = "laserno";
            lstDealer.DataValueField = "id";
            lstDealer.DataBind();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (SessionVeriables.UserId > 0)
            {
                SellerSalesData ssd = new SellerSalesData(txtVehicle.Text);
                if (!ssd.HasValue)
                {
                    int counter = 0;
                    foreach (ListItem item in lstDealer.Items)
                    {
                        if (item.Selected)
                        {
                            counter = counter + 1;
                        }
                    }
                    if (counter == 0)
                    {
                        lblError.Text = "Select Laser No First !!!";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
                    }
                    else if (counter <= 2)
                    {
                        StateDetails msdata = new StateDetails();
                        DataSet dsRate = msdata.getDetails("SELECT * FROM ratechart WHERE type='" + ddlOrderType.SelectedItem.ToString() + "' and vehicleclass='" + ddlClassType.SelectedItem.ToString() + "' and vehicletype='" + ddlType.SelectedItem.ToString() + "' and status=1 and ext="+ int.Parse(SessionVeriables.UserId.ToString()));
                        if (dsRate.Tables[0].Rows.Count > 0)
                        {

                            string tcode = txtVehicle.Text.ToUpper() + "fitment1" + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();
                            tcode = tcode.Replace(':', '-');
                            FileInfo photo = new FileInfo(upldImg.FileName);
                            string ext = photo.Extension;
                            ImgReSize rmg = new ImgReSize();
                            // upldImg1.SaveAs(HttpContext.Current.Server.MapPath("~/img/" + upldImg1.FileName));
                            rmg.GenerateThumbnails(0.5, upldImg.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/seller/Img/" + tcode + ext), 800, 600);
                            // sd.img1 = tcode + ext;

                            DistibutorData dd = new DistibutorData(int.Parse(SessionVeriables.UserId.ToString()));
                            SellerSalesData sd = new SellerSalesData();
                            sd.orderdate = DateTime.Today.AddHours(12).AddMinutes(30);
                            sd.name = txtName.Text;
                            sd.rc = tcode + ext;
                            sd.contactno = txtContactNo.Text;
                            sd.state = ddlState.SelectedItem.ToString();
                            sd.city = ddlCity.SelectedItem.ToString();
                            sd.registrationno = txtVehicle.Text.ToUpper();
                            sd.chasisno = txtChasisNo.Text;
                            sd.engineno = txtEngineNo.Text;
                            sd.vehicletype = ddlType.SelectedItem.ToString();
                           // sd.model = txtModel.Text;
                            sd.fueltype = ddlFuelType.SelectedItem.ToString();
                            sd.classtype = ddlClassType.SelectedItem.ToString();
                            sd.ordertype = ddlOrderType.SelectedItem.ToString();
                            sd.registrationdate = DateTime.Parse(txtRegistrationDate.Text);
                            sd.manufacturedate = (txtManufactureDate.Text);
                            sd.sellerid = SessionVeriables.UserId;
                            sd.ext2 = dd.extra;
                            sd.tlp = chklstTLP.SelectedItem.ToString();
                            sd.Save();
                            SellerSalesData sdTemp = new SellerSalesData(txtName.Text, txtContactNo.Text, txtVehicle.Text, txtChasisNo.Text, txtEngineNo.Text);
                            foreach (ListItem item in lstDealer.Items)
                            {
                                if (item.Selected)
                                {
                                    SaleItemData sitem = new SaleItemData(int.Parse(item.Value));
                                    SellerItemData si = new SellerItemData();
                                    si.headerid = sdTemp.id;
                                    si.itemid = sitem.sid;
                                    si.Save();
                                    SaleItemData sdU = new SaleItemData();
                                    sdU.sstatus = 1;
                                    sdU.updateSold(int.Parse(item.Value));
                                    si.getDetails("update sellersales set npid=1 where id=" + sdTemp.id);
                                }
                            }
                            Response.Redirect("ordeerbookingstockist.aspx");
                        }
                        else
                        {
                            lblError.Text = "Rate Chart Not Created For this Order, Contact Admin (1800-12012-6001)";
                            btnSubmit.Enabled = false;
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
                        }
                    }
                    else
                    {
                        lblError.Text = "Laser No. Not More Then 2 !!!";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
                    }
                }
                else
                {
                    lblMsg.Text = "Vehicle order already in pending";
                }
            }
            else
            {
                Response.Redirect("ordeerbookingstockist.aspx");
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
            StateDetails msdata = new StateDetails();
            DataSet ds1 = msdata.getDetails("select * from city where status=1 and state='" + ddlState.SelectedItem.ToString() + "' order by city");
            ddlCity.DataSource = ds1;
            ddlCity.DataTextField = "city";
            ddlCity.DataValueField = "id";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, "Select City");
            ddlCity.SelectedIndex = 0;
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
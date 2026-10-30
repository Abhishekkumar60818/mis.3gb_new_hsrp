using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class seller_OrderBooking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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

                        btnSubmit.Visible = false;
                        pnlDetails.Visible = false;
                        DataSet dsVehicleType = msdata.getDetails("select * from vehicletype where status=1 order by type");
                        ddlType.DataSource = dsVehicleType;
                        ddlType.DataTextField = "type";
                        ddlType.DataValueField = "id";
                        ddlType.DataBind();
                        ddlType.Items.Insert(0, "Select Type");
                        ddlType.SelectedIndex = 0;

                        //DataSet dsFuelType = msdata.getDetails("select * from fueltype where status=1 order by type");
                        //ddlFuelType.DataSource = dsFuelType;
                        //ddlFuelType.DataTextField = "type";
                        //ddlFuelType.DataValueField = "id";
                        //ddlFuelType.DataBind();
                        //ddlFuelType.Items.Insert(0, "Select Fuel Type");
                        //ddlFuelType.SelectedIndex = 0;

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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (SessionVeriables.UserId > 0)
            {
                SellerSalesData ssd = new SellerSalesData(txtVehicle.Text);
                if (!ssd.HasValue)
                {
                    StateDetails msdata = new StateDetails();
                    DataSet dsRate = msdata.getDetails("SELECT * FROM ratechart WHERE type='" + ddlOrderType.SelectedItem.ToString() + "' and vehicleclass='" + ddlClassType.SelectedItem.ToString() + "' and vehicletype='" + ddlType.SelectedItem.ToString() + "' and status=1 and ext=" + int.Parse(SessionVeriables.UserId.ToString()));
                    if (dsRate.Tables[0].Rows.Count >= 0)
                    {
                        DataSet dsBalance = msdata.getDetails("select d.id,d.name,d.city,d.state,(SELECT (sum(CASE WHEN ptype ='deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id) as dr,(SELECT (sum(CASE WHEN ptype <>'deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id) as cr,((SELECT (sum(CASE WHEN ptype ='deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id)-(SELECT (sum(CASE WHEN ptype <>'deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id)) as balance from distibutor d where d.status=1 and d.id=" + SessionVeriables.UserId);
                        if (dsBalance.Tables[0].Rows.Count > 0)
                        {
                            if (dsBalance.Tables[0].Rows[0][6].ToString() != "")
                            {
                                if (dsRate.Tables[0].Rows.Count > 0)
                                {
                                    if (double.Parse(dsBalance.Tables[0].Rows[0][6].ToString()) >= double.Parse(dsRate.Tables[0].Rows[0]["netamount"].ToString()))
                                    {
                                        string abc = "";
                                        if (upldImg.HasFile)
                                        {
                                            string tcode = txtVehicle.Text.ToUpper() + "fitment1" + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();
                                            tcode = tcode.Replace(':', '-');
                                            FileInfo photo = new FileInfo(upldImg.FileName);
                                            string ext = photo.Extension;
                                            ImgReSize rmg = new ImgReSize();
                                            // upldImg1.SaveAs(HttpContext.Current.Server.MapPath("~/img/" + upldImg1.FileName));
                                            rmg.GenerateThumbnails(0.5, upldImg.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/seller/Img/" + tcode + ext), 800, 600);
                                            // sd.img1 = tcode + ext;
                                            abc = tcode + ext;
                                        }
                                        DistibutorData dd = new DistibutorData(int.Parse(SessionVeriables.UserId.ToString()));
                                        SellerSalesData sd = new SellerSalesData();
                                        sd.orderdate = DateTime.Today.AddHours(12).AddMinutes(30);
                                        sd.name = txtName.Text;
                                        sd.rc = abc ;
                                        sd.contactno = txtContactNo.Text;
                                        sd.state = ddlState.SelectedItem.ToString();
                                        sd.city = ddlCity.SelectedItem.ToString();
                                        sd.registrationno = txtVehicle.Text.ToUpper();
                                        sd.chasisno = txtChasisNo.Text;
                                        sd.engineno = txtEngineNo.Text;
                                        sd.vehicletype = ddlType.SelectedItem.ToString();
                                        //sd.model = txtModel.Text;
                                        sd.fueltype = ddlFuelType.Text;
                                        sd.classtype = ddlClassType.SelectedItem.ToString();
                                        sd.ordertype = ddlOrderType.SelectedItem.ToString();
                                        sd.registrationdate = DateTime.Parse(txtRegistrationDate.Text);
                                        string mfgInput = txtManufactureDate.Value != null ? txtManufactureDate.Value.Trim() : "";
                                        string mfgFormatted;
                                        if (!TryParseManufactureDate(mfgInput, out mfgFormatted))
                                        {
                                            lblMsg.Text = "Invalid Date Of Manufacture. Use YYYY-MM (e.g., 2015-05) or YYYY (e.g., 2015)";
                                            return;
                                        }
                                        sd.manufacturedate = mfgFormatted;
                                        sd.sellerid = SessionVeriables.UserId;
                                        sd.ext2 = dd.extra;
                                        sd.tlp = chklstTLP.SelectedItem.ToString();
                                        sd.Save();

                                        LedgerData ld = new LedgerData();
                                        ld.did = SessionVeriables.UserId;
                                        ld.amount = double.Parse(dsRate.Tables[0].Rows[0]["netamount"].ToString());
                                        ld.mode = "Order Booking";
                                        ld.ptype = "credit";
                                        ld.date = DateTime.Today.AddHours(12).AddMinutes(30);
                                        ld.approval = 1;
                                        ld.transactionno = "Plate Amount deducted for Vehicle No. " + txtVehicle.Text;
                                        ld.remark = "Order";
                                        ld.Save();
                                        Response.Redirect("OrderBooking.aspx");
                                    }

                                    else
                                    {
                                        lblMsg.Text = "Insufficient Funds In Accounts. You Are not able to place order. Available Balance is " + dsBalance.Tables[0].Rows[0][6].ToString() + " Rs. and Required Balance is " + dsRate.Tables[0].Rows[0]["netamount"].ToString() + " Rs.";
                                        btnSubmit.Enabled = false;
                                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
                                    }
                                }
                                else
                                {
                                    lblMsg.Text = "Rate List Not Available,Contact To Admin";
                                    btnSubmit.Enabled = false;
                                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
                                }
                            }
                            else
                            {
                                lblMsg.Text = "Insufficient Funds In Accounts. You Are not able to place order.";
                                btnSubmit.Enabled = false;
                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
                            }
                        }
                        else
                        {
                            lblMsg.Text = "Insufficient Funds In Accounts. You Are not able to place order.";
                            btnSubmit.Enabled = false;
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Rate Chart Not Created For this Order, Contact Admin (1800-12012-6001)";
                        btnSubmit.Enabled = false;
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
                
                Response.Redirect("OrderBooking.aspx");
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
            lblMsg.Text = msg;
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

    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string apiUrl11 = "https://vahan.parivahan.gov.in/hsrpws/webresources/hsrpwebservice/getHsrpVehicleDetails/";
            object input11 = new
            {
                regnNO = txtVehicle.Text,
                chasisNo = txtChasisNo.Text,
                userId = "3gbtech2023",
                engineNo = txtEngineNo.Text

            };

            var request = WebRequest.Create(apiUrl11);

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            request.ContentType = "application/json";
            request.Method = "GET";

            var type = request.GetType();
            var currentMethod = type.GetProperty("CurrentMethod", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(request);

            var methodType = currentMethod.GetType();
            methodType.GetField("ContentBodyNotAllowed", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(currentMethod, false);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(input11));
            }
            string abd = "";
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            if (responseStream != null)
            {
                var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                var resultEntity = myStreamReader.ReadToEnd();
                myStreamReader.ReadToEnd();
                // lbl1.Text = resultEntity;

                abd = DecryptData(resultEntity, "3GbTech@20238h"); ;

            }
            responseStream.Close();
            response.Close();
            VaahanResultData r = Newtonsoft.Json.JsonConvert.DeserializeObject<VaahanResultData>(abd);

            if (r.message == "Vehicle details available in Vahan")
            {
                btnSubmit.Visible = true;
                ddlFuelType.Text = r.fuel;
                txtRegistrationDate.Text=r.regnDate;
            }
            else
            {
                lblError.Visible = true;
                btnSubmit.Visible=false;
                lblError.Text = "* " + r.message;
            }

        }
        catch (Exception ex)
        {
        }

    }
    string DecryptData(string EncryptedText, string Encryptionkey)
    {
        RijndaelManaged objrij = new RijndaelManaged();
        objrij.Mode = CipherMode.CBC;
        objrij.Padding = PaddingMode.PKCS7;
        objrij.KeySize = 0x80;
        objrij.BlockSize = 0x80;
        byte[] encryptedTextByte = Convert.FromBase64String(EncryptedText);
        byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);
        byte[] EncryptionkeyBytes = new byte[0x10];
        int len = passBytes.Length;
        if (len > EncryptionkeyBytes.Length)
        {
            len = EncryptionkeyBytes.Length;
        }
        Array.Copy(passBytes, EncryptionkeyBytes, len);
        objrij.Key = EncryptionkeyBytes;
        objrij.IV = EncryptionkeyBytes;
        //objrij.Padding = PaddingMode.Zeros;
        byte[] TextByte = objrij.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);
        return Encoding.UTF8.GetString(TextByte);  //it will return readable string
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

    protected void btnVahaancheck_Click(object sender, EventArgs e)
    {
        try
        {
            string apiUrl11 = "https://vahan.parivahan.gov.in/hsrpws/webresources/hsrpwebservice/getHsrpVehicleDetails/";
            object input11 = new
            {
                regnNO = txtVehicle.Text,
                chasisNo = txtChasisNo.Text,
                userId = "3gbtech2023",
                engineNo = txtEngineNo.Text

            };

            var request = WebRequest.Create(apiUrl11);

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            request.ContentType = "application/json";
            request.Method = "GET";

            var type = request.GetType();
            var currentMethod = type.GetProperty("CurrentMethod", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(request);

            var methodType = currentMethod.GetType();
            methodType.GetField("ContentBodyNotAllowed", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(currentMethod, false);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(input11));
            }
            string abd = "";
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            if (responseStream != null)
            {
                var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                var resultEntity = myStreamReader.ReadToEnd();
                myStreamReader.ReadToEnd();
                // lbl1.Text = resultEntity;

                abd = DecryptData(resultEntity, "3GbTech@20238h"); ;

            }
            responseStream.Close();
            response.Close();
            VaahanResultData r = Newtonsoft.Json.JsonConvert.DeserializeObject<VaahanResultData>(abd);

            if (r.message == "Vehicle details available in Vahan")
            {
                btnSubmit.Visible = true;
                pnlDetails.Visible = true;
                ddlFuelType.Text = r.fuel;
                txtRegistrationDate.Text = r.regnDate;
                btnVahaancheck.Visible = false;
               // lblErrormsg.Text =  r.message;
               // lblErrormsg.ForeColor= System.Drawing.Color.Black;
                lblVaahanDetails.Text = "Bharat Stage :- " + r.norms + ", Registration Date :- " + r.regnDate + ", Fuel Type :- " + r.fuel + ", Maker :- " + r.maker + ", Vehicle Type :- " + r.vchType + ", Vehicle Category :- " + r.vchCatg + ", Front Laser No. :- " + r.hsrpFrontLaserCode + ", Rear Laser No. :- " + r.hsrpRearLaserCode;
            }
            else
            {
                lblError.Visible = true;
                btnSubmit.Visible = false;
                lblErrormsg.Text = "* " + r.message;
            }

        }
        catch (Exception ex)
        {
        }
    }
}
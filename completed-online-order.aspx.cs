using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class completed_online_order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                AdminLoginData ad = new AdminLoginData();
                //DataSet ds = ad.getDetails("select s.id,s.ownername,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,d.name as DName,(select name from distibutor where id=d.extra) as ems from onlinesales s join distibutor d on d.id=s.fitmentcentre where s.status=1 and s.paymentstatus='Success' and s.npid=0 and s.ordertype='high security registration plate for electric vehicle'");
                DataSet ds = ad.getDetails("select s.id,s.vupdate,s.ownername,s.flaserno,s.rleaserno,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,(select name from distibutor where id=s.fitmentcentre) as DName,(select name from distibutor where id=s.emsid) as ems from onlinesales s  where s.status=1 and s.paymentstatus='Success' and s.npid=1 and s.vupdate!='Pending' ");
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
        try
        {

            txtRearLaserNo.Text = "";
            txtFrontLaserNo.Text = "";
            int ids = int.Parse(e.CommandArgument.ToString());
            string comm = e.CommandName;
            lblId.Text = ids.ToString();
            if (comm == "edit")
            {
                //OnlineOrderData sd = new OnlineOrderData(ids);
                //lblChassisNo.Text = sd.chasisnumber;
                //lblEngneNo.Text = sd.enginenumber;
                //lblVehicleNo.Text = sd.registrationnumber;
                ////DataSet ds1 = sd.getDetails("select si.id,s.id as stockid,s.rateid,sh.date,s.laserno,si.sstatus from stock s join salesitem si join saleheader sh where sh.status=1 and sh.did=" + SessionVeriables.UserId + " and si.hid=sh.id and si.status=1 and s.id=si.sid and si.sstatus=0");
                ////lstDealer.DataSource = ds1;
                ////lstDealer.DataTextField = "laserno";
                ////lstDealer.DataValueField = "id";
                ////lstDealer.DataBind();
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
                OnlineOrderData chkO = new OnlineOrderData(int.Parse(lblId.Text));
                if (chkO.ordertype != "only colour sticker")
                {
                    string apiUrl11 = "https://vahan.parivahan.gov.in/hsrpws/webresources/hsrpwebservice/hsrpEntry/";
                    object input11 = new
                    {
                        regnNO = chkO.registrationnumber,
                        chasisNo = chkO.chasisnumber.Substring(chkO.chasisnumber.Length - 5),
                        userId = "3gbtech2023",
                        engineNo = chkO.enginenumber.Substring(chkO.chasisnumber.Length - 5)

                    };
                    var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                    var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);
                    deviceinfo writePlayer = new deviceinfo()
                    {
                        userId = "3gbtech2023",

                        dobjListHsrp = new List<dobjListHsrpLst>
             {
                 new dobjListHsrpLst()
                 {
                     regnNO = chkO.registrationnumber,
                     chasisNo = chkO.chasisnumber.Substring(chkO.chasisnumber.Length - 5),
                     flag = chkO.orderflag,
                     fixationDate = now.ToString("dd-MM-yyyy"),
                     rearLaserCode = chkO.flaserno,
                     frontLaserCode = chkO.rleaserno,
                 },
             }

                    };

                    var request = WebRequest.Create(apiUrl11);

                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                    request.ContentType = "application/json";
                    request.Method = "POST";

                    var type = request.GetType();
                    var currentMethod = type.GetProperty("CurrentMethod", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(request);

                    var methodType = currentMethod.GetType();
                    methodType.GetField("ContentBodyNotAllowed", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(currentMethod, false);

                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(JsonConvert.SerializeObject(writePlayer));
                    }

                    var response = request.GetResponse();
                    var responseStream = response.GetResponseStream();
                    string rrr = "";
                    if (responseStream != null)
                    {
                        var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                        var resultEntity = myStreamReader.ReadToEnd();
                        myStreamReader.ReadToEnd();
                        // lbl1.Text = resultEntity;

                        //  lblUpdateStatus.Text = DecryptData(resultEntity, "3GbTech@20238h"); ;
                        // sdu.updateVahaan(ids, DecryptData(resultEntity, "3GbTech@20238h"));
                        // rrr = DecryptData(resultEntity, "3GbTech@20238h");

                        OnlineOrderData si = new OnlineOrderData();
                        si.getDetails("update onlinesales set vupdate='" + DecryptData(resultEntity, "3GbTech@20238h") + "' where id=" + lblId.Text);
                        getDatare();
                    }
                    responseStream.Close();
                    response.Close();
                }
                else
                {
                    OnlineOrderData si = new OnlineOrderData();
                    si.getDetails("update onlinesales set vupdate='Sticker Updated' where id=" + lblId.Text);
                    getDatare();
                }
            }
            if (comm == "view")
            {
                Response.Redirect("vehicle-details.aspx?id=" + ids);
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {



        //     Response.Redirect("spendingorder.aspx");
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
    [System.Serializable]
    public class deviceinfo
    {
        public string userId;

        public List<dobjListHsrpLst> dobjListHsrp;
    }
    [System.Serializable]
    public class dobjListHsrpLst
    {

        public string regnNO;
        public string frontLaserCode;
        public string rearLaserCode;
        public string fixationDate;
        public string flag;
        public string chasisNo;

    }
    private void getDatare()
    {
        AdminLoginData ad = new AdminLoginData();
        DataSet ds = ad.getDetails("select s.id,s.ownername,s.flaserno,s.rleaserno,s.vupdate,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,(select name from distibutor where id=s.fitmentcentre) as DName,(select name from distibutor where id=s.emsid) as ems from onlinesales s  where s.status=1 and s.paymentstatus='Success' and s.npid=1 and s.vupdate!='Pending'");
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
                DataSet ds = ad.getDetails("select s.id,s.ownername,s.flaserno,s.rleaserno,s.vupdate,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,(select name from distibutor where id=s.fitmentcentre) as DName,(select name from distibutor where id=s.emsid) as ems from onlinesales s  where s.status=1 and s.paymentstatus='Success' and s.npid=1 and s.vupdate!='Pending'  and  (date_format(str_to_date(s.orderdaate, '%d-%m-%Y'), '%Y-%m-%d') between '" + txtStDate.Text + "' and '" + txtEndDate.Text + "')");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text == "" && txtEndDate.Text == "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.ownername,s.flaserno,s.rleaserno,s.vupdate,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,(select name from distibutor where id=s.fitmentcentre) as DName,(select name from distibutor where id=s.emsid) as ems from onlinesales s  where s.status=1 and s.paymentstatus='Success' and s.npid=1 and s.vupdate!='Pending'");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text != "" && txtEndDate.Text == "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.ownername,s.flaserno,s.rleaserno,s.vupdate,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,(select name from distibutor where id=s.fitmentcentre) as DName,(select name from distibutor where id=s.emsid) as ems from onlinesales s  where s.status=1 and s.paymentstatus='Success' and s.npid=1 and s.vupdate!='Pending' and date_format(str_to_date(s.orderdaate, '%d-%m-%Y'), '%Y-%m-%d') >= '" + txtStDate.Text + "'");
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
            else if (txtStDate.Text == "" && txtEndDate.Text != "")
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select s.id,s.ownername,s.flaserno,s.rleaserno,s.vupdate,s.mobilenumber,s.state,s.city,s.registrationnumber,s.chasisnumber,s.enginenumber,s.vehicletype,s.vehiclecategory,s.vehicleregistrationbate,s.fueltype,s.ordertype,s.maker,s.fitmentcentre,s.npid,s.status,s.vehiclecategory,s.orderdaate,(select name from distibutor where id=s.fitmentcentre) as DName,(select name from distibutor where id=s.emsid) as ems from onlinesales s  where s.status=1 and s.paymentstatus='Success' and s.npid=1 and s.vupdate!='Pending' and  date_format(str_to_date(s.orderdaate, '%d-%m-%Y'), '%Y-%m-%d') <= '" + txtEndDate.Text + "'");
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
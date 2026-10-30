using Newtonsoft.Json;
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

public partial class seller_ValidationSynced : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (SessionVeriables.UserId > 0)
            {
                if (!IsPostBack)
                {

                    AdminLoginData ad = new AdminLoginData();
                    DataSet ds = ad.getDetails("select * from sellersales s where s.npid=1 and s.vupdate<>'Pending' and s.sellerid in(SELECT d.id FROM distibutor d WHERE d.status=1  and (d.id=" + SessionVeriables.UserId + " or d.extra=" + SessionVeriables.UserId + "))");
                    rptrUser.DataSource = ds;
                    rptrUser.DataBind();
                }
            }
            else
            {
                Response.Redirect("../Logout.aspx");
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
            
            int ids = int.Parse(e.CommandArgument.ToString());
            lblIds.Text = ids.ToString();
            string comm =e.CommandName.ToString();
            if (comm == "update")
            {
                SellerSalesData sd = new SellerSalesData(ids);
                SellerItemData sdi = new SellerItemData(sd.id, 1);
                DistibutorData dpd = new DistibutorData(sd.sellerid);
                StateDetails sta = new StateDetails(int.Parse(dpd.state));
                CityDetails cit = new CityDetails(int.Parse(dpd.city));
                StockData st = new StockData(sdi.itemid);
                StockData stp = new StockData(sdi.itemid2);
                SellerSalesData sdu = new SellerSalesData();


                string apiUrl11 = "https://vahan.parivahan.gov.in/hsrpws/webresources/hsrpwebservice/hsrpEntry/";
                object input11 = new
                {
                    regnNO = sd.registrationno,
                    chasisNo = sd.chasisno.Substring(sd.chasisno.Length - 5),
                    userId = "3gbtech2023",
                    engineNo = sd.engineno.Substring(sd.engineno.Length - 5)

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
                     regnNO = sd.registrationno,
                     chasisNo = sd.chasisno.Substring(sd.chasisno.Length - 5),
                     flag = sd.odtype,
                     fixationDate = now.ToString("dd-MM-yyyy"),
                     rearLaserCode = stp.laserno,
                     frontLaserCode = st.laserno,
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
                    sdu.updateVahaan(ids, DecryptData(resultEntity, "3GbTech@20238h"));
                    rrr = DecryptData(resultEntity, "3GbTech@20238h");
                }
                responseStream.Close();
                response.Close();
                // Response.Redirect("ValidationSynced.aspx");
                lblRemark.Text = rrr;

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert();", true);
            }
            else
            {
                SellerSalesData sd = new SellerSalesData(ids);
                lblChassisNo.Text = sd.chasisno;
                lblEngneNo.Text = sd.engineno;
                lblVehicleNo.Text = sd.registrationno;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup1();", true);
            }
        }
        catch (Exception ex)
        {
            lblRemark.Text = ex.Message;

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert();", true);
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
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("ValidationSynced.aspx");
    }

    protected void btnUpdateFlag_Click(object sender, EventArgs e)
    {
        try
        {
            string vflag = "";
            if (ddlFlag.SelectedItem.ToString() == "New Both HSRP")
            {
                vflag = "NB";
            }
            else if (ddlFlag.SelectedItem.ToString() == "Duplicate Both HSRP")
            {
                vflag = "DB";
            }
            else if (ddlFlag.SelectedItem.ToString() == "Duplicate Front HSRP")
            {
                vflag = "DF";
            }
            else if (ddlFlag.SelectedItem.ToString() == "Duplicate Rear HSRP")
            {
                vflag = "DR";
            }
            else if (ddlFlag.SelectedItem.ToString() == "Old Both HSRP")
            {
                vflag = "OB";
            }

            SellerItemData si = new SellerItemData();
            si.getDetails("update sellersales set odtype='" + vflag + "'   where id=" + lblIds.Text);

        }
        catch { }
    }
}
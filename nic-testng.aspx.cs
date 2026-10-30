using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class nic_testng : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnVahaanCheck_Click(object sender, EventArgs e)
    {
        try
        {


            string apiUrl11 = "https://staging.parivahan.gov.in/hsrpws/webresources/hsrpwebservice/getHsrpVehicleDetails/";
            object input11 = new
            {
                regnNO = txtRegNo.Text,
                chasisNo = txtChasis.Text,
                userId = "3gbtech2023",
                engineNo = txtEngine.Text

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

            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            if (responseStream != null)
            {
                var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                var resultEntity = myStreamReader.ReadToEnd();
                myStreamReader.ReadToEnd();
                // lbl1.Text = resultEntity;

                lblMSg.Text = DecryptData(resultEntity, "3GbTech@20238h"); ;

            }
            responseStream.Close();
            response.Close();
        }
        catch (Exception ex)
        { }
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

    protected void btnUploadVahaan_Click(object sender, EventArgs e)
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
            string apiUrl11 = "https://staging.parivahan.gov.in/hsrpws/webresources/hsrpwebservice/hsrpEntry/";
            object input11 = new
            {
                regnNO = txtRegNo.Text,
                chasisNo = txtChasis.Text,
                userId = "3gbtech2023",
                engineNo = txtEngine.Text

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
                     regnNO = txtRegNo.Text,
                     chasisNo = txtChasis.Text,
                     flag = vflag,
                     fixationDate = now.ToString("dd-MM-yyyy"),
                     rearLaserCode = txtRearLaser.Text,
                     frontLaserCode = txtFrntLaser.Text,
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
            if (responseStream != null)
            {
                var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                var resultEntity = myStreamReader.ReadToEnd();
                myStreamReader.ReadToEnd();
                // lbl1.Text = resultEntity;

                lblMSg.Text = DecryptData(resultEntity, "3GbTech@20238h"); ;

            }
            responseStream.Close();
            response.Close();
        }
        catch (Exception ex)
        {

        }
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
}
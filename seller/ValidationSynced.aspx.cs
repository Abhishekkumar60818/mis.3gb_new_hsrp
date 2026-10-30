using Newtonsoft.Json;
using MySql.Data.MySqlClient;
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
    private int DefaultPageSize = 20;
    private int CurrentPage
    {
        get { return ViewState["CurrentPage"] != null ? (int)ViewState["CurrentPage"] : 1; }
        set { ViewState["CurrentPage"] = value; }
    }
    private int PageSize
    {
        get { return ViewState["PageSize"] != null ? (int)ViewState["PageSize"] : DefaultPageSize; }
        set { ViewState["PageSize"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (SessionVeriables.UserId > 0)
            {
                if (!IsPostBack)
                {
                    CurrentPage = 1;
                    PageSize = 20;
                    if (ddlPageSize != null) ddlPageSize.SelectedValue = "20";
                    BindData();
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

    private string Escape(string input)
    {
        if (string.IsNullOrEmpty(input)) return "";
        return input.Replace("'", "''").Trim();
    }

    private string BuildWhereClause(List<MySqlParameter> parameters)
    {
        string where = "s.npid=1 and s.vupdate<>'Pending' and exists (select 1 from distibutor d where d.status=1 and d.id=s.sellerid and (d.id=@userId or d.extra=@userId))";
        parameters.Add(new MySqlParameter("@userId", SessionVeriables.UserId));

        DateTime fromDate;
        if (DateTime.TryParse(txtFromDate != null ? txtFromDate.Text.Trim() : "", out fromDate))
        {
            parameters.Add(new MySqlParameter("@fromDate", fromDate.Date));
            where += " and s.orderdate >= @fromDate";
        }

        DateTime toDate;
        if (DateTime.TryParse(txtToDate != null ? txtToDate.Text.Trim() : "", out toDate))
        {
            parameters.Add(new MySqlParameter("@toDate", toDate.Date));
            where += " and s.orderdate <= @toDate";
        }

        string search = txtSearch != null ? txtSearch.Text.Trim() : "";
        if (!string.IsNullOrEmpty(search))
        {
            if (search.Length > 100)
            {
                search = search.Substring(0, 100);
            }

            parameters.Add(new MySqlParameter("@search", "%" + search + "%"));
            where += " and (s.registrationno like @search or s.chasisno like @search or s.engineno like @search or s.name like @search or s.contactno like @search or s.vehicletype like @search or s.vupdate like @search)";
        }

        if (ddlVupdateFilter != null && !string.IsNullOrEmpty(ddlVupdateFilter.SelectedValue) && ddlVupdateFilter.SelectedValue != "All")
        {
            parameters.Add(new MySqlParameter("@vupdate", ddlVupdateFilter.SelectedValue));
            where += " and s.vupdate=@vupdate";
        }

        return where;
    }

    private int GetPageSize()
    {
        if (ddlPageSize != null && !string.IsNullOrEmpty(ddlPageSize.SelectedValue))
        {
            int ps;
            if (int.TryParse(ddlPageSize.SelectedValue, out ps) && ps >= 1 && ps <= 100)
            {
                return ps;
            }
        }
        return PageSize;
    }

    private void BindData()
    {
        AdminLoginData ad = new AdminLoginData();
        List<MySqlParameter> countParameters = new List<MySqlParameter>();
        string countWhere = BuildWhereClause(countParameters);
        string countSql = "select count(*) as cnt from sellersales s where " + countWhere;
        DataSet dsCnt = ad.getDetails(countSql, countParameters);
        int totalRecords = 0;
        if (dsCnt.Tables.Count > 0 && dsCnt.Tables[0].Rows.Count > 0)
            totalRecords = Convert.ToInt32(dsCnt.Tables[0].Rows[0]["cnt"]);
        ViewState["TotalRecords"] = totalRecords;
        int pageSize = GetPageSize();
        PageSize = pageSize;
        int totalPages = totalRecords == 0 ? 1 : (int)Math.Ceiling((double)totalRecords / pageSize);
        ViewState["TotalPages"] = totalPages;
        if (CurrentPage > totalPages) CurrentPage = totalPages;
        if (CurrentPage < 1) CurrentPage = 1;
        int offset = (CurrentPage - 1) * pageSize;

        List<MySqlParameter> dataParameters = new List<MySqlParameter>();
        string dataWhere = BuildWhereClause(dataParameters);
        string dataSql = "select s.id,s.orderdate,s.name,s.contactno,s.registrationno,s.vehicletype,s.vupdate,s.npid from sellersales s where " + dataWhere + " order by s.id desc LIMIT " + offset + "," + pageSize;
        DataSet ds = ad.getDetails(dataSql, dataParameters);
        rptrUser.DataSource = ds;
        rptrUser.DataBind();
        PopulatePager(totalRecords, pageSize, totalPages, offset, ds.Tables[0].Rows.Count);
    }

    private void PopulatePager(int totalRecords, int pageSize, int totalPages, int offset, int currentCount)
    {
        if (lblPagerInfo != null)
        {
            if (totalRecords == 0) lblPagerInfo.Text = "No records found";
            else lblPagerInfo.Text = "Showing " + (offset + 1) + " to " + (offset + currentCount) + " of " + totalRecords + " entries";
        }
        if (lblPageInfo != null) lblPageInfo.Text = "Page " + CurrentPage + " of " + totalPages;
        if (rptPager != null)
        {
            var pages = new List<int>();
            int start = Math.Max(1, CurrentPage - 2);
            int end = Math.Min(totalPages, CurrentPage + 2);
            if (end - start < 4)
            {
                if (start == 1) end = Math.Min(totalPages, start + 4);
                else if (end == totalPages) start = Math.Max(1, end - 4);
            }
            for (int i = start; i <= end; i++) pages.Add(i);
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }
        if (lnkPrev != null) lnkPrev.Enabled = CurrentPage > 1;
        if (lnkNext != null) lnkNext.Enabled = CurrentPage < totalPages;
        if (lnkFirst != null) lnkFirst.Enabled = CurrentPage > 1;
        if (lnkLast != null) lnkLast.Enabled = CurrentPage < totalPages;
    }

    protected void btnSearch_Click(object sender, EventArgs e) { CurrentPage = 1; BindData(); }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        if (txtSearch != null) txtSearch.Text = "";
        if (txtFromDate != null) txtFromDate.Text = "";
        if (txtToDate != null) txtToDate.Text = "";
        if (ddlVupdateFilter != null) ddlVupdateFilter.SelectedIndex = 0;
        if (ddlPageSize != null) ddlPageSize.SelectedValue = "20";
        PageSize = 20; CurrentPage = 1; BindData();
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e) { CurrentPage = 1; BindData(); }
    protected void ddlVupdateFilter_SelectedIndexChanged(object sender, EventArgs e) { CurrentPage = 1; BindData(); }
    protected void rptPager_ItemCommand(object source, RepeaterCommandEventArgs e) { if (e.CommandName == "Page") { CurrentPage = Convert.ToInt32(e.CommandArgument); BindData(); } }
    protected void lnkPrev_Click(object sender, EventArgs e) { if (CurrentPage > 1) CurrentPage--; BindData(); }
    protected void lnkNext_Click(object sender, EventArgs e) { int tp = ViewState["TotalPages"] != null ? (int)ViewState["TotalPages"] : 1; if (CurrentPage < tp) CurrentPage++; BindData(); }
    protected void lnkFirst_Click(object sender, EventArgs e) { CurrentPage = 1; BindData(); }
    protected void lnkLast_Click(object sender, EventArgs e) { int tp = ViewState["TotalPages"] != null ? (int)ViewState["TotalPages"] : 1; CurrentPage = tp; BindData(); }
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
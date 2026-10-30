using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class seller_scompleteorder : System.Web.UI.Page
{
    private int DefaultPageSize = 20;

    private int CurrentPage
    {
        get { return ViewState["CurrentPage"] != null ? (int)ViewState["CurrentPage"] : 1; }
        set { ViewState["CurrentPage"] = value; }
    }

    private int PageSize
    {
        get
        {
            if (ViewState["PageSize"] != null) return (int)ViewState["PageSize"];
            return DefaultPageSize;
        }
        set { ViewState["PageSize"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                CurrentPage = 1;
                PageSize = 20;
                if (ddlPageSize != null) ddlPageSize.SelectedValue = "20";
                BindData();
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

    // One grouped lookup replaces the two correlated selleritem/stock lookups that
    // were previously executed for every completed order. Front is the first
    // seller item and rear is the second seller item, matching LIMIT 0,1/1,1.
    private const string LaserJoin = @"
        LEFT JOIN (
            SELECT headerid,
                CAST(SUBSTRING_INDEX(GROUP_CONCAT(itemid ORDER BY id SEPARATOR ','), ',', 1) AS UNSIGNED) AS front_stock_id,
                CASE WHEN COUNT(*) > 1 THEN
                    CAST(SUBSTRING_INDEX(SUBSTRING_INDEX(GROUP_CONCAT(itemid ORDER BY id SEPARATOR ','), ',', 2), ',', -1) AS UNSIGNED)
                END AS rear_stock_id
            FROM selleritem
            GROUP BY headerid
        ) li ON li.headerid = s.id
        LEFT JOIN stock fst ON fst.id = li.front_stock_id
        LEFT JOIN stock rst ON rst.id = li.rear_stock_id";

    private string BuildWhereClause(List<MySqlParameter> parameters)
    {
        string baseWhere = "s.status=1 and s.npid=1 and s.sellerid=d.id and s.ext2=@userId";
        parameters.Add(new MySqlParameter("@userId", SessionVeriables.UserId));

        DateTime fromDate;
        if (DateTime.TryParse(txtFromDate != null ? txtFromDate.Text.Trim() : "", out fromDate))
        {
            parameters.Add(new MySqlParameter("@fromDate", fromDate.Date));
            baseWhere += " and s.orderdate >= @fromDate";
        }

        DateTime toDate;
        if (DateTime.TryParse(txtToDate != null ? txtToDate.Text.Trim() : "", out toDate))
        {
            parameters.Add(new MySqlParameter("@toDate", toDate.Date));
            baseWhere += " and s.orderdate <= @toDate";
        }

        string search = txtSearch != null ? txtSearch.Text.Trim() : "";
        if (!string.IsNullOrEmpty(search))
        {
            if (search.Length > 100)
            {
                search = search.Substring(0, 100);
            }

            parameters.Add(new MySqlParameter("@search", "%" + search + "%"));
            baseWhere += " and (s.registrationno like @search or s.chasisno like @search or s.engineno like @search or s.city like @search or s.vehicletype like @search or s.classtype like @search or d.name like @search or s.name like @search or fst.laserno like @search or rst.laserno like @search)";
        }

        return baseWhere;
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
        string countSql = "select count(*) as cnt from sellersales s join distibutor d on d.id = s.sellerid " + LaserJoin + " where " + countWhere;
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
        string dataSql = "select s.id,s.name,s.contactno,s.state,s.city,s.tlp,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,fst.laserno as frontlaser,rst.laserno as rearlaser from sellersales s join distibutor d on d.id = s.sellerid " + LaserJoin + " where " + dataWhere + " order by s.id desc LIMIT " + offset + "," + pageSize;
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
        if (lblPageInfo != null) lblPageInfo.Text = "Page " + CurrentPage + " of " + totalPages;
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
        if (ddlPageSize != null) ddlPageSize.SelectedValue = "20";
        PageSize = 20; CurrentPage = 1; BindData();
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e) { CurrentPage = 1; BindData(); }
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
            SellerSalesData sd = new SellerSalesData(ids);
            DataSet ds = sd.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.tlp,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,d.email,d.contactno as emcontact,d.address,(select laserno from stock where id=(select itemid from selleritem where headerid=s.id LIMIT 0,1)) as frontlaser,(select laserno from stock where id=(select itemid from selleritem where headerid=s.id LIMIT 1,1)) as rearlaser from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id and s.id=" + ids);
            string htmlbody = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("../pdf/invoice.html"));
            htmlbody = htmlbody.Replace("__CentreName__", ds.Tables[0].Rows[0]["DName"].ToString());
            htmlbody = htmlbody.Replace("__CentreAddress__", ds.Tables[0].Rows[0]["address"].ToString());
            htmlbody = htmlbody.Replace("__CentreEmailId__", ds.Tables[0].Rows[0]["email"].ToString());
            htmlbody = htmlbody.Replace("__CentreContact__", ds.Tables[0].Rows[0]["emcontact"].ToString());
            htmlbody = htmlbody.Replace("__OwnerName__", ds.Tables[0].Rows[0]["name"].ToString());
            htmlbody = htmlbody.Replace("__State__", ds.Tables[0].Rows[0]["state"].ToString());
            htmlbody = htmlbody.Replace("__ContactNumber__", ds.Tables[0].Rows[0]["contactno"].ToString());
            htmlbody = htmlbody.Replace("__REGISTRATIONNUMBER__", ds.Tables[0].Rows[0]["registrationno"].ToString());
            htmlbody = htmlbody.Replace("__CHASSISNUMBER__", ds.Tables[0].Rows[0]["chasisno"].ToString());
            htmlbody = htmlbody.Replace("__ENGINENUMBER__", ds.Tables[0].Rows[0]["engineno"].ToString());
            htmlbody = htmlbody.Replace("__FUEL__", ds.Tables[0].Rows[0]["fueltype"].ToString());
            htmlbody = htmlbody.Replace("__VEHICLETYPE__", ds.Tables[0].Rows[0]["vehicletype"].ToString());
            htmlbody = htmlbody.Replace("__VehicleClass__", ds.Tables[0].Rows[0]["classtype"].ToString());
            htmlbody = htmlbody.Replace("__REGISTRATIONDATE__", (DateTime.Parse(ds.Tables[0].Rows[0]["registrationdate"].ToString())).ToString("dd-MM-yyyy"));
            htmlbody = htmlbody.Replace("__FrontLaserNumber__", ds.Tables[0].Rows[0]["frontlaser"].ToString());
            htmlbody = htmlbody.Replace("__RearLaserNumber__", ds.Tables[0].Rows[0]["rearlaser"].ToString());
            htmlbody = htmlbody.Replace("__TLPStatus__", ds.Tables[0].Rows[0]["tlp"].ToString());
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            StringBuilder sb = new StringBuilder(htmlbody);
            StringReader sr = new StringReader(sb.ToString());
            Document pdfDoc = new Document(iTextSharp.text.PageSize.LETTER, 25f, 25f, 25f, 25f);
            pdfDoc.SetMargins(35f, 15f, 5f, 5f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode("Order Date : "+ (DateTime.Parse(ds.Tables[0].Rows[0]["orderdate"].ToString())).ToString("dd-MM-yyyy") + ",Vehicle Registration No.:" + ds.Tables[0].Rows[0]["registrationno"].ToString() + ",Engine No.:" + ds.Tables[0].Rows[0]["engineno"].ToString() + ",Chassis No:" + ds.Tables[0].Rows[0]["chasisno"].ToString() + ",Customer Name:" + ds.Tables[0].Rows[0]["name"].ToString() + ",Laser No. Front : " + ds.Tables[0].Rows[0]["frontlaser"].ToString() + ",Laser No Rear : " + ds.Tables[0].Rows[0]["rearlaser"].ToString(), QRCodeGenerator.ECCLevel.Q);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 100; imgBarCode.Width = 100; imgBarCode.BorderWidth = 4;
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            using (MemoryStream ms = new MemoryStream()) { bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png); byte[] byteImage = ms.ToArray(); imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage); string base64 = Convert.ToBase64String(byteImage); byte[] imagebytes = Convert.FromBase64String(base64); iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagebytes); iTextSharp.text.Image watermarkQR = iTextSharp.text.Image.GetInstance(image); watermarkQR.ScaleAbsoluteHeight(130); watermarkQR.ScaleAbsoluteWidth(130); watermarkQR.SetAbsolutePosition(430, 610); pdfDoc.Add(watermarkQR); }
            htmlparser.Parse(sr); pdfDoc.Close(); Response.ContentType = "application/pdf"; Response.AddHeader("content-disposition", "attachment;filename=" + ds.Tables[0].Rows[0]["registrationno"].ToString() + "_Invoice.pdf"); Response.Cache.SetCacheability(HttpCacheability.NoCache); Response.Write(pdfDoc); Response.End();
        } catch { }
    }
}

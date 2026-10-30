using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class completed : System.Web.UI.Page
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
        string where = "s.status=1 and s.npid=1 and s.sellerid=d.id";
        DateTime fromDate;
        if (DateTime.TryParse(txtStDate != null ? txtStDate.Text.Trim() : "", out fromDate))
        {
            parameters.Add(new MySqlParameter("@fromDate", fromDate.Date));
            where += " and s.orderdate >= @fromDate";
        }

        DateTime toDate;
        if (DateTime.TryParse(txtEndDate != null ? txtEndDate.Text.Trim() : "", out toDate))
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
            where += " and (s.registrationno like @search or s.chasisno like @search or s.engineno like @search or s.name like @search or d.name like @search or s.vehicletype like @search or fst.laserno like @search or rst.laserno like @search)";
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
        string dataSql = "select s.id,s.orderdate,d.name as DName,(select name from distibutor where id=d.extra) as ems,s.name,s.registrationno,s.chasisno,s.engineno,s.vehicletype,fst.laserno as frontlaser,rst.laserno as rearlaser from sellersales s join distibutor d on d.id = s.sellerid " + LaserJoin + " where " + dataWhere + " order by s.id desc LIMIT " + offset + "," + pageSize;
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Keep backward compat - treat as search with date filters
        CurrentPage = 1;
        BindData();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        BindData();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        if (txtStDate != null) txtStDate.Text = "";
        if (txtEndDate != null) txtEndDate.Text = "";
        if (txtSearch != null) txtSearch.Text = "";
        if (ddlPageSize != null) ddlPageSize.SelectedValue = "20";
        PageSize = 20;
        CurrentPage = 1;
        BindData();
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        CurrentPage = 1;
        BindData();
    }

    protected void rptPager_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Page")
        {
            CurrentPage = Convert.ToInt32(e.CommandArgument);
            BindData();
        }
    }

    protected void lnkPrev_Click(object sender, EventArgs e) { if (CurrentPage > 1) CurrentPage--; BindData(); }
    protected void lnkNext_Click(object sender, EventArgs e) { int tp = ViewState["TotalPages"] != null ? (int)ViewState["TotalPages"] : 1; if (CurrentPage < tp) CurrentPage++; BindData(); }
    protected void lnkFirst_Click(object sender, EventArgs e) { CurrentPage = 1; BindData(); }
    protected void lnkLast_Click(object sender, EventArgs e) { int tp = ViewState["TotalPages"] != null ? (int)ViewState["TotalPages"] : 1; CurrentPage = tp; BindData(); }

    protected void rptrUser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int ids = int.Parse(e.CommandArgument.ToString());
        string comm = e.CommandName;
        lblId.Text = ids.ToString();
        AdminLoginData ad = new AdminLoginData();
        DataSet ds = ad.getDetails("select s.id,(select id from selleritem where headerid=s.id LIMIT 0,1) as frontlaser,(select id from selleritem where headerid=s.id LIMIT 1,1) as rearlaser from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id and s.id=" + ids);
        SellerItemData adItem = new SellerItemData(int.Parse(ds.Tables[0].Rows[0]["frontlaser"].ToString()));
        SellerItemData rearItem = new SellerItemData(int.Parse(ds.Tables[0].Rows[0]["rearlaser"].ToString()));
        StockData sd = new StockData(adItem.itemid);
        StockData sd1 = new StockData(rearItem.itemid);
        SellerSalesData sd2 = new SellerSalesData(adItem.headerid);
        lblRegistration.Text = sd2.registrationno;
        lblFrontLaserNumber.Text = sd.laserno;
        lblRearLaser.Text = sd1.laserno;
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);

    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        int ids = int.Parse(lblId.Text);
        string remark = txtRemark != null ? txtRemark.Text.Trim() : "";
        if (string.IsNullOrEmpty(remark))
        {
            if (lblRemarkError != null) lblRemarkError.Text = "Remark is required.";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            return;
        }
        if (lblRemarkError != null) lblRemarkError.Text = string.Empty;
        AdminLoginData ad = new AdminLoginData();
        DataSet ds = ad.getDetails("select s.id,(select id from selleritem where headerid=s.id LIMIT 0,1) as frontlaser,(select id from selleritem where headerid=s.id LIMIT 1,1) as rearlaser from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id and s.id=" + ids);

        SellerItemData adItem = new SellerItemData(int.Parse(ds.Tables[0].Rows[0]["frontlaser"].ToString()));
        SellerItemData rearItem = new SellerItemData(int.Parse(ds.Tables[0].Rows[0]["rearlaser"].ToString()));

        ad.getDetails("delete from selleritem where id=" + ds.Tables[0].Rows[0]["frontlaser"].ToString());
        ad.getDetails("delete from selleritem where id=" + ds.Tables[0].Rows[0]["rearlaser"].ToString());
        ad.getDetails("update salesitem set sstatus=0,remark='"+ Escape(remark) + "' where sid=" + adItem.itemid);
        ad.getDetails("update salesitem set sstatus=0,remark='"+ Escape(remark) + "' where sid=" + rearItem.itemid);
        ad.getDetails("update sellersales set npid=0 where id=" + ds.Tables[0].Rows[0]["id"].ToString());
        Response.Redirect("completed.aspx");
    }
}

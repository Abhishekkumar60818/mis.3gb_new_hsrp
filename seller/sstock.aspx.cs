using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class seller_sstock : System.Web.UI.Page
{
    private int PageSize = 10;
    private int CurrentPage
    {
        get { return ViewState["CurrentPage"] != null ? (int)ViewState["CurrentPage"] : 1; }
        set { ViewState["CurrentPage"] = value; }
    }
    private string CurrentSearch
    {
        get { return ViewState["CurrentSearch"] != null ? (string)ViewState["CurrentSearch"] : ""; }
        set { ViewState["CurrentSearch"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                pnlView.Visible = true;
                CurrentPage = 1;
                CurrentSearch = "";
                this.GetCustomersPageWise(1);
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
    private static string EscapeProcedureString(string value)
    {
        if (string.IsNullOrEmpty(value)) return "";
        return value.Replace("\\", "\\\\").Replace("'", "\\'").Trim();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CurrentSearch = txtSearch != null ? txtSearch.Text.Trim() : "";
        CurrentPage = 1;
        this.GetCustomersPageWise(1);
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        if (txtSearch != null) txtSearch.Text = "";
        CurrentSearch = "";
        CurrentPage = 1;
        this.GetCustomersPageWise(1);
    }
    private void GetCustomersPageWise(int pageIndex)
    {
        if (pageIndex < 1) pageIndex = 1;
        CurrentPage = pageIndex;
        string search = CurrentSearch;
        if (search.Length > 100)
        {
            search = search.Substring(0, 100);
            CurrentSearch = search;
        }


        AdminLoginData ad = new AdminLoginData();
        //DataSet ds = ad.getDetails("select s.id,s.name,s.contactno,s.state,s.city,s.tlp,s.registrationno,s.chasisno,s.engineno,s.vehicletype,s.model,s.registrationdate,s.fueltype,s.ordertype,s.manufacturedate,s.sellerid,s.npid,s.status,s.classtype,s.orderdate,d.name as DName,(select laserno from stock where id=(select itemid from selleritem where headerid=s.id LIMIT 0,1)) as frontlaser,(select laserno from stock where id=(select itemid from selleritem where headerid=s.id LIMIT 1,1)) as rearlaser from sellersales s join distibutor d where s.status=1 and s.npid=1 and s.sellerid=d.id and s.ext2=" + SessionVeriables.UserId);
        DataSet ds = ad.getDetails("CALL `GetDealerStocksFiltered`(" + pageIndex + ", " + PageSize + ", " + SessionVeriables.UserId + ", '" + EscapeProcedureString(search) + "')");
        if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
        {
            rptrUser.DataSource = null;
            rptrUser.DataBind();
            this.PopulatePager(0, pageIndex);
            return;
        }
        rptrUser.DataSource = ds;
        rptrUser.DataBind();
        int recordCount = Convert.ToInt32(ds.Tables[0].Rows[0]["rowcounts"].ToString());
        this.PopulatePager(recordCount, pageIndex);
    }
    private void PopulatePager(int recordCount, int currentPage)
    {
        List<ListItem> pages = new List<ListItem>();
        int startIndex, endIndex;
        int pagerSpan = 5;

        //Calculate the Start and End Index of pages to be displayed.
        double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
        endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
        if (currentPage > pagerSpan % 2)
        {
            if (currentPage == 2)
            {
                endIndex = 5;
            }
            else
            {
                endIndex = currentPage + 2;
            }
        }
        else
        {
            endIndex = (pagerSpan - currentPage) + 1;
        }

        if (endIndex - (pagerSpan - 1) > startIndex)
        {
            startIndex = endIndex - (pagerSpan - 1);
        }

        if (endIndex > pageCount)
        {
            endIndex = pageCount;
            startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
        }

        //Add the First Page Button.
        if (currentPage > 1)
        {
            pages.Add(new ListItem("First", "1"));
        }

        //Add the Previous Button.
        if (currentPage > 1)
        {
            pages.Add(new ListItem("<<", (currentPage - 1).ToString()));
        }

        for (int i = startIndex; i <= endIndex; i++)
        {
            pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
        }

        //Add the Next Button.
        if (currentPage < pageCount)
        {
            pages.Add(new ListItem(">>", (currentPage + 1).ToString()));
        }

        //Add the Last Button.
        if (currentPage != pageCount)
        {
            pages.Add(new ListItem("Last", pageCount.ToString()));
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }

    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetCustomersPageWise(pageIndex);
    }
}
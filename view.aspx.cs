using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class view : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                pnlView.Visible = true;
                pnlEdit.Visible = false;
                lblPage.Text = "1";
                BindStock();
            }
        }
        catch (Exception ex)
        {
            ShowStockError(ex.Message);
        }
    }

    private int GetStockPage()
    {
        int page;
        if (!int.TryParse(lblPage.Text, out page) || page < 1)
        {
            page = 1;
            lblPage.Text = "1";
        }
        return page;
    }

    private int GetStockPageSize()
    {
        int pageSize;
        if (!int.TryParse(ddlPageQuantity.SelectedValue, out pageSize) || pageSize < 1 || pageSize > 500)
        {
            pageSize = 10;
        }
        return pageSize;
    }

    private string GetStockSearch()
    {
        string search = txtSearch != null ? txtSearch.Text.Trim() : "";
        if (search.Length > 100)
        {
            search = search.Substring(0, 100);
        }
        return search;
    }

    private void BindStock()
    {
        pnlView.Visible = true;
        AdminLoginData ad = new AdminLoginData();
        List<MySqlParameter> parameters = new List<MySqlParameter>();
        parameters.Add(new MySqlParameter("@pageIndex", GetStockPage()));
        parameters.Add(new MySqlParameter("@pageSize", GetStockPageSize()));
        parameters.Add(new MySqlParameter("@search", GetStockSearch()));
        DataSet ds = ad.getDetails("CALL GetPlateFiltered(@pageIndex, @pageSize, @search)", parameters);

        if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
        {
            rptrUser.DataSource = null;
            rptrUser.DataBind();
            lblPageCount.Text = "0";
            return;
        }

        int totalPages = Convert.ToInt32(ds.Tables[0].Rows[0]["total_pages"]);
        lblPageCount.Text = totalPages.ToString();
        if (ds.Tables.Count < 2 || ds.Tables[1].Rows.Count == 0)
        {
            rptrUser.DataSource = null;
            rptrUser.DataBind();
            return;
        }

        rptrUser.DataSource = ds.Tables[1];
        rptrUser.DataBind();
    }

    private void ShowStockError(string message)
    {
        if (string.IsNullOrEmpty(message)) return;
        string msg = message.Replace("\r", string.Empty).Replace("\n", string.Empty);
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = '" + msg.Trim() + "';$('#alert-modal').modal('show');});</script>", false);
    }

    protected void ddlPageQuantity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblPage.Text = "1";
            BindStock();
        }
        catch (Exception ex)
        {
            ShowStockError(ex.Message);
        }
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblPage.Text = "1";
            BindStock();
        }
        catch (Exception ex)
        {
            ShowStockError(ex.Message);
        }
    }

    protected void lnkPrevious_Click(object sender, EventArgs e)
    {
        try
        {
            int page = GetStockPage();
            if (page > 1)
            {
                lblPage.Text = (page - 1).ToString();
            }
            BindStock();
        }
        catch (Exception ex)
        {
            ShowStockError(ex.Message);
        }
    }

    protected void lnkNext_Click(object sender, EventArgs e)
    {
        try
        {
            int page = GetStockPage();
            int totalPages;
            if (!int.TryParse(lblPageCount.Text, out totalPages) || totalPages < 1)
            {
                totalPages = page;
            }
            if (page < totalPages)
            {
                lblPage.Text = (page + 1).ToString();
            }
            BindStock();
        }
        catch (Exception ex)
        {
            ShowStockError(ex.Message);
        }
    }

    protected void rptrUser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            int ids = int.Parse(e.CommandArgument.ToString());
            lblIds.Text = ids.ToString();
            pnlView.Visible = false;
            pnlEdit.Visible = true;
            CityDetails msdata = new CityDetails();
            DataSet ds1 = msdata.getDetails("select * from size where status=1 order by sizes");
            ddlSize.DataSource = ds1;
            ddlSize.DataTextField = "sizes";
            ddlSize.DataValueField = "id";
            ddlSize.DataBind();
            //ddlSize.Items.Insert(0, "Select Size");
            //ddlSize.SelectedIndex = 0;

            DataSet dsClass = msdata.getDetails("select * from vehicleclass where status=1 order by type");
            ddlClass.DataSource = dsClass;
            ddlClass.DataTextField = "type";
            ddlClass.DataValueField = "id";
            ddlClass.DataBind();
            //ddlClass.Items.Insert(0, "Select Class");
            //ddlClass.SelectedIndex = 0;
            StockData sd = new StockData(ids);
            lblLaserNo.Text = sd.laserno;
            SizeMasterData sm = new SizeMasterData(sd.sizeid);
            ddlSize.ClearSelection();
            ddlSize.Items.FindByText(sm.sizes).Selected = true;

            VehicleClassData vc = new VehicleClassData(sd.classid);
            ddlClass.ClearSelection();
            ddlClass.Items.FindByText(vc.type).Selected = true;

        }
        catch (Exception ex)
        { }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        StockData sd = new StockData();
        sd.classid = int.Parse(ddlClass.SelectedValue.ToString());
        sd.sizeid = int.Parse(ddlSize.SelectedValue.ToString());
        sd.update(int.Parse(lblIds.Text));
        Response.Redirect("view.aspx");
    }
    protected void getExcel(DataSet ds)
    {
        ClosedXML.Excel.XLWorkbook wbook = new ClosedXML.Excel.XLWorkbook();
        wbook.Worksheets.Add(ds.Tables[0], "Sheet1");
        // Prepare the response
        HttpResponse httpResponse = Response;
        httpResponse.Clear();
        httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //Provide you file name here
        httpResponse.AddHeader("content-disposition", "attachment;filename=\"Stock_Data.xlsx\"");
        // Flush the workbook to the Response.OutputStream
        using (MemoryStream memoryStream = new MemoryStream())
        {
            wbook.SaveAs(memoryStream);
            memoryStream.WriteTo(httpResponse.OutputStream);
            memoryStream.Close();

            httpResponse.End();
        }

    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            AdminLoginData ad = new AdminLoginData();
            DataSet ds = ad.getDetails("select s.laserno,s.date,ss.sizes as sizes,v.type as classs,s.sstatus , CEILING((SELECT COUNT(id) FROM stock)/10) AS total,(case when (select sic.sstatus from stock sc join salesitem sic join saleheader shc   where shc.status=1  and sic.hid=shc.id and sic.status=1 and sc.id=sic.sid and sc.laserno=s.laserno order by sic.id desc limit 1)>0 then '02' else '01' end) as soldstatus,(case when (select shz.registrationno from stock sz join selleritem siz on siz.itemid=sz.id join sellersales shz on shz.id=siz.headerid where sz.laserno=s.laserno order by siz.id desc limit 1)<>'' then (select sha.registrationno from stock sa join selleritem sia on sia.itemid=sa.id join sellersales sha on sha.id=sia.headerid where sa.laserno=s.laserno order by sia.id desc limit 1) else 'Not Used' end ) as RegistrationNo,(select shz.vupdate from stock sz join selleritem siz on siz.itemid=sz.id join sellersales shz on shz.id=siz.headerid where sz.laserno=s.laserno order by siz.id desc limit 1) as vahan FROM stock s join size ss join vehicleclass v WHERE ss.id=s.sizeid and v.id=s.classid and s.status=1");
            getExcel(ds);
        }
        catch (Exception ex) { }
    }
}
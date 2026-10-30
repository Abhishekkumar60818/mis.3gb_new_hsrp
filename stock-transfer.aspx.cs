using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class stock_transfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                pnlView.Visible = true;
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select * from stock where status=1 and sstatus=0");
                //  rptrUser.DataSource = ds;
                //  rptrUser.DataBind();

                DataSet DsStockist = ad.getDetails("SELECT d.id,CONCAT(d.name, ',', (select city from city where id=d.city)) as name FROM distibutor d WHERE d.status=1 and d.DType='Embossing' order by name");
                ddlStockist.DataSource = DsStockist;
                ddlStockist.DataTextField = "name";
                ddlStockist.DataValueField = "id";
                ddlStockist.DataBind();
               // ddlStockist.Items.Insert(0, "Select Embossing");
                ddlStockist.SelectedIndex = 0;

                DataSet DsSize = ad.getDetails("select * from size WHERE status=1 order by sizes");
                ddlSize.DataSource = DsSize;
                ddlSize.DataTextField = "sizes";
                ddlSize.DataValueField = "id";
                ddlSize.DataBind();
                ddlSize.Items.Insert(0, "Select Size");
                ddlSize.SelectedIndex = 0;

                DataSet DsClass = ad.getDetails("select * from vehicleclass WHERE status=1 order by type");
                ddlClass.DataSource = DsClass;
                ddlClass.DataTextField = "type";
                ddlClass.DataValueField = "id";
                ddlClass.DataBind();
                ddlClass.Items.Insert(0, "Select Class");
                ddlClass.SelectedIndex = 0;
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

    protected void btnTransfer_Click(object sender, EventArgs e)
    {
        string from = (txtFrom.Text.Replace("CE", ""));
        string to = (txtTo.Text.Replace("CE", ""));
        int qty = int.Parse(to) - int.Parse(from);
        StockData sc = new StockData();
        DataSet dsStockCount = sc.getDetails("SELECT s.id,s.laserno,s.date,ss.sizes as sizes,v.type as classs,s.sstatus FROM stock s join size ss join vehicleclass v WHERE ss.id=s.sizeid and v.id=s.classid and s.status=1 and ss.id=" + int.Parse(ddlSize.SelectedValue.ToString()) + " and v.id=" + int.Parse(ddlClass.SelectedValue.ToString()) + " and s.sstatus=0");
        if (dsStockCount.Tables[0].Rows.Count > 0)
        {

            if (dsStockCount.Tables[0].Rows.Count >= qty)
            {
                int flag = 1;
                string laser = "";
                for (int i = 0; i < qty; i++)
                {
                    string fromL = (txtFrom.Text.Replace("CE", ""));
                    string lNo = "";

                    lNo = fromL.Remove(0, 2);


                    string lids = (int.Parse(lNo) + i).ToString();
                    int ccount = lids.Length;
                    ccount = 10 - ccount;
                    lids = "";
                    for (int q = 0; q < ccount; q++)
                    {
                        lids += "0";
                    }
                    lids += (int.Parse(from) + i).ToString();
                    string lsrn = "CE" + lids;
                    StockData stk = new StockData(lsrn);
                    if (!stk.HasValue)
                    {
                        flag = 0;
                        laser += lsrn + ",";
                    }
                    else
                    {
                        if (stk.sstatus == 1)
                        {
                            flag = 0;
                            laser += lsrn + ",";
                        }
                    }
                }

                string abs = "0";
                // string GSt = ((double.Parse(abs) * 18) / 100).ToString();
                // string withGst = (double.Parse(abs) + double.Parse(GSt)).ToString();
                // DataSet dsBalance = sc.getDetails("select d.id,d.name,d.city,d.state,(SELECT (sum(CASE WHEN ptype ='deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id) as dr,(SELECT (sum(CASE WHEN ptype <>'deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id) as cr,((SELECT (sum(CASE WHEN ptype ='deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id)-(SELECT (sum(CASE WHEN ptype <>'deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id)) as balance from distibutor d where d.status=1 and d.id=" + int.Parse(ddlStockist.SelectedValue.ToString()));
                //if (dsBalance.Tables[0].Rows.Count > 0)
                //{
                //if (dsBalance.Tables[0].Rows[0][6].ToString() != "")
                //{
                //if (double.Parse(dsBalance.Tables[0].Rows[0][6].ToString()) >= double.Parse(withGst))
                //{
                if (flag == 1)
                {
                    var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                    var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);
                    SaleHeaderData sd = new SaleHeaderData();
                    sd.did = int.Parse(ddlStockist.SelectedValue.ToString());
                    sd.qty = qty;
                    sd.date = now;
                    int ds = sd.Save();
                    // DataSet dsChild = sc.getDetails("SELECT s.id,s.laserno,s.date,ss.sizes as sizes,v.type as classs,s.sstatus FROM stock s join size ss join vehicleclass v WHERE ss.id=s.sizeid and v.id=s.classid and s.status=1 and ss.id=" + int.Parse(ddlSize.SelectedValue.ToString()) + " and v.id=" + int.Parse(ddlClass.SelectedValue.ToString()) + " and s.sstatus=0 order by s.laserno limit " + qty + "");
                    for (int i = 0; i < qty + 1; i++)
                    {
                        string fromL = (txtFrom.Text.Replace("CE", ""));
                        string lNo = "";

                        lNo = fromL.Remove(0, 2);


                        string lids = (int.Parse(lNo) + i).ToString();
                        int ccount = lids.Length;
                        ccount = 10 - ccount;
                        lids = "";
                        for (int q = 0; q < ccount; q++)
                        {
                            lids += "0";
                        }
                        lids += (int.Parse(from) + i).ToString();
                        string lsrn = "CE" + lids;
                        StockData stk = new StockData(lsrn);
                        SaleItemData si = new SaleItemData();
                        si.hid = ds;
                        si.sid = stk.id;
                        si.Save();
                        StockData sstock = new StockData();
                        sstock.SoldOut(stk.id);
                    }
                    //LedgerData ld = new LedgerData();
                    //ld.did = int.Parse(ddlStockist.SelectedValue.ToString());
                    //ld.amount = double.Parse(withGst);
                    //ld.mode = "Embossing Bulk Booking";
                    //ld.ptype = "credit";
                    //ld.date = DateTime.Today;
                    //ld.approval = 1;
                    //ld.transactionno = "Plate Amount deducted for Bulk Order " + ddlStockist.SelectedItem.ToString();
                    //ld.remark = "Order";
                    //ld.Save();
                    lblError.Text = "";
                    Response.Redirect("stock-transfer.aspx");
                }
                else
                {
                    lblError.Text = "Laser No Already Transfered " + laser;
                }
                //}
                //else
                //{
                //    lblError.Text = "Insufficient Funds In Accounts. You Are not able to place order. Available Balance is " + dsBalance.Tables[0].Rows[0][6].ToString() + " Rs. and Required Balance is " + abs + " Rs.";
                //}
                //}
                //else
                //{
                //    lblError.Text = "Insufficient Funds In Accounts. You Are not able to place order.";
                //}
                //}
                //else
                //{
                //    lblError.Text = "Insufficient Funds In Accounts. You Are not able to place order.";
                //}
            }
            else
            {
                lblError.Text = "* Available stock is less then quantity, Available Stock is " + dsStockCount.Tables[0].Rows.Count;
            }
        }
        else
        {
            lblError.Text = "* Stock Not Available";
            // btnTransfer.Enabled = false;
            // ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
        }
        //int hider = 0;
        //int co = 0;
        //for (int i = 0; i < rptrUser.Items.Count; i++)
        //{
        //    HtmlInputCheckBox MyCheckBox = new HtmlInputCheckBox();
        //    MyCheckBox = (HtmlInputCheckBox)rptrUser.Items[i].FindControl("chk");
        //    if (MyCheckBox.Checked)
        //    {
        //        hider += 1;//int.Parse(MyCheckBox.Value);
        //        co = 1;
        //    }
        //}
        //if (co > 0)
        //{
        //    string abs = (hider * double.Parse(txtRate.Text)).ToString();
        //    string GSt = ((double.Parse(abs)*18)/100).ToString();
        //    string withGst = (double.Parse(abs) + double.Parse(GSt)).ToString();
        //    StateDetails msdata = new StateDetails();
        //    DataSet dsBalance = msdata.getDetails("select d.id,d.name,d.city,d.state,(SELECT (sum(CASE WHEN ptype ='deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id) as dr,(SELECT (sum(CASE WHEN ptype <>'deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id) as cr,((SELECT (sum(CASE WHEN ptype ='deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id)-(SELECT (sum(CASE WHEN ptype <>'deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id)) as balance from distibutor d where d.status=1 and d.id=" + int.Parse(ddlStockist.SelectedValue.ToString()));
        //    if (dsBalance.Tables[0].Rows.Count > 0)
        //    {
        //        if (dsBalance.Tables[0].Rows[0][6].ToString() != "")
        //        {
        //            if (double.Parse(dsBalance.Tables[0].Rows[0][6].ToString()) >= double.Parse(withGst))
        //            {
        //                SaleHeaderData sd = new SaleHeaderData();
        //                sd.did = int.Parse(ddlStockist.SelectedValue.ToString());
        //                sd.qty = hider;
        //                sd.date = DateTime.Today;
        //                DataSet ds = sd.Save();

        //                for (int i = 0; i < rptrUser.Items.Count; i++)
        //                {
        //                    HtmlInputCheckBox MyCheckBox = new HtmlInputCheckBox();
        //                    MyCheckBox = (HtmlInputCheckBox)rptrUser.Items[i].FindControl("chk");
        //                    if (MyCheckBox.Checked)
        //                    {
        //                        SaleItemData si = new SaleItemData();
        //                        si.hid = int.Parse(ds.Tables[0].Rows[0][0].ToString());
        //                        si.sid = int.Parse(MyCheckBox.Value);
        //                        si.Save();
        //                        StockData sstock = new StockData();
        //                        sstock.SoldOut(int.Parse(MyCheckBox.Value));
        //                    }
        //                }
        //                LedgerData ld = new LedgerData();
        //                ld.did = int.Parse(ddlStockist.SelectedValue.ToString());
        //                ld.amount = double.Parse(withGst);
        //                ld.mode = "Stockist Bulk Booking";
        //                ld.ptype = "credit";
        //                ld.date = DateTime.Today;
        //                ld.approval = 1;
        //                ld.transactionno = "Plate Amount deducted for Bulk Order " + ddlStockist.SelectedItem.ToString();
        //                ld.remark = "Order";
        //                ld.Save();
        //                lblError.Text = "";
        //                Response.Redirect("stock-transfer.aspx");
        //            }
        //            else
        //            {
        //                lblError.Text = "Insufficient Funds In Accounts. You Are not able to place order. Available Balance is " + dsBalance.Tables[0].Rows[0][6].ToString() + " Rs. and Required Balance is " + abs + " Rs.";
        //                btnTransfer.Enabled = false;
        //                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
        //            }
        //        }
        //        else
        //        {
        //            lblError.Text = "Insufficient Funds In Accounts. You Are not able to place order.";
        //            btnTransfer.Enabled = false;
        //            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
        //        }
        //    }
        //    else
        //    {
        //        lblError.Text = "Insufficient Funds In Accounts. You Are not able to place order.";
        //        btnTransfer.Enabled = false;
        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() {  document.getElementById('lableid').innerHTML = 'Hi Do you want to update';$('#Updatemodal').modal('show');});</script>", false);
        //    }
        //}
        //else
        //{
        //    lblError.Text = "Select Item From Stock";
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                CityDetails msdata = new CityDetails();
                DataSet ds1 = msdata.getDetails("select * from size where status=1 order by sizes");
                ddlSize.DataSource = ds1;
                ddlSize.DataTextField = "sizes";
                ddlSize.DataValueField = "id";
                ddlSize.DataBind();
                ddlSize.Items.Insert(0, "Select Size");
                ddlSize.SelectedIndex = 0;

                DataSet dsClass = msdata.getDetails("select * from vehicleclass where status=1 order by type");
                ddlClass.DataSource = dsClass;
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (int.Parse(txtQuantity.Text) > 0)
            {
                //StateDetails ad = new StateDetails();
                //ad.name = txtStateName.Text;
                //ad.Save();
                //txtQuantity.Text = "";
                StockData sd1 = new StockData(1, 1);
                for (int i = 0; i < int.Parse(txtQuantity.Text); i++)
                {
                    StockData sd = new StockData(1, 1);
                    string lNo = "";
                    if (sd.HasValue)
                    {
                        lNo = sd.laserno.Remove(0, 2);
                    }
                    else
                    {
                        lNo = "0";
                    }

                    string lids = (int.Parse(lNo) + 1).ToString();
                    int ccount = lids.Length;
                    ccount = 10 - ccount;
                    lids = "";
                    for (int q = 0; q < ccount; q++)
                    {
                        lids += "0";
                    }
                    lids += (sd.id + 1).ToString();
                    StockData sdr = new StockData();
                    sdr.laserno = "CE" + lids;
                    sdr.classid = int.Parse(ddlClass.SelectedValue.ToString());
                    sdr.sizeid = int.Parse(ddlSize.SelectedValue.ToString());
                    sdr.date = DateTime.Today.AddHours(12).AddMinutes(30);
                    sdr.Save();
                }
                Response.Write("<script>window.open ('pdf/print.aspx?val=" + txtQuantity.Text + "&minId=" + (sd1.id + 1).ToString() + "','_blank');</script>");
                // Response.Redirect("StockView.aspx");
            }
            else
            {
                lblMsg.Text = "* Enter Quantity";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
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
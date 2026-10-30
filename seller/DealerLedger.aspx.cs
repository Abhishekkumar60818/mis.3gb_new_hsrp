using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class seller_DealerLedger : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("SELECT date, mode,remark,transactionno,(CASE WHEN ptype ='deposit' THEN amount ELSE 0 END) as dr,(CASE WHEN ptype <>'deposit' THEN amount ELSE 0 END) as cr FROM ledger where approval=1 and status=1 and (did="+ SessionVeriables.UserId + ") order by id desc");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    rptrUser.DataSource = ds;
                    rptrUser.DataBind();
                    lblDR.Text = "Dr Total : " + (ds.Tables[0].Compute("sum(dr)", "")).ToString() + " Rs.";
                    lblCR.Text = "Cr Total : " + (ds.Tables[0].Compute("sum(cr)", "")).ToString() + " Rs.";
                    lblBalance.Text = "Balance : " + (double.Parse((ds.Tables[0].Compute("sum(dr)", "")).ToString()) - double.Parse((ds.Tables[0].Compute("sum(cr)", "")).ToString())).ToString() + " Rs.";
                }
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
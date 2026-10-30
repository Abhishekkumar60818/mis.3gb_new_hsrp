using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class seller_sledger : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnlLedger.Visible = false;
            pnlparty.Visible = true;
            AdminLoginData ad = new AdminLoginData();
            DataSet ds = ad.getDetails("select d.id,d.name,d.city,d.state,(SELECT (sum(CASE WHEN ptype ='deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id) as dr,(SELECT (sum(CASE WHEN ptype <>'deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id) as cr,((SELECT (sum(CASE WHEN ptype ='deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id)-(SELECT (sum(CASE WHEN ptype <>'deposit' THEN amount ELSE 0 END)) FROM ledger where approval=1 and status=1 and did=d.id)) as balance from distibutor d where d.status=1 and d.extra="+SessionVeriables.UserId);
            rptrParty.DataSource = ds;
            rptrParty.DataBind();
        }
    }

    protected void rptrParty_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int ids = int.Parse(e.CommandArgument.ToString());
        pnlLedger.Visible = true;
        pnlparty.Visible = false;
        AdminLoginData ad = new AdminLoginData();
        DataSet ds = ad.getDetails("SELECT date, mode,remark,transactionno,(CASE WHEN ptype ='deposit' THEN amount ELSE 0 END) as dr,(CASE WHEN ptype <>'deposit' THEN amount ELSE 0 END) as cr FROM ledger where approval=1 and status=1 and (did=" + ids + ")");
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
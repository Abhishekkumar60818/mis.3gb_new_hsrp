using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class online_transaction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                AdminLoginData ad = new AdminLoginData();
                DataSet ds = ad.getDetails("select l.id,l.amount,l.photo,l.mode,l.ptype,l.date,l.remark,l.transactionno,d.name,d.city from ledger l join distibutor d where l.did=d.id and l.approval=1 and l.status=1 and d.status=1 and l.mode='Online By Payment Gateway'");
                //DataSet ds = ad.getDetails("select l.id,l.amount,l.mode,l.ptype,l.date,l.remark,l.transactionno,d.name,d.city from ledger l join distibutor d where l.did=d.id and l.approval=0 and l.status=1 and d.status=1 and d.extra=0");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    rptrUser.DataSource = ds;
                    rptrUser.DataBind();
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
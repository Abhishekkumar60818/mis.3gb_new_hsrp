using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class seller_dealerlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            DistibutorData ad = new DistibutorData();
            DataSet ds = ad.getDetails("Select s.id,s.name,s.designation,s.contactperson,s.deliveryaddress,s.contactno,s.email,s.address,s.username,s.GSTNo,s.DType,s.status,s.date,(select city from city where id=s.city) as city,(select name from state where id=s.state) as state,s.password as pass,(SELECT name from distibutor where id=s.extra) as Stockists,(SELECT name from distibutor where id=s.oemid) as OEM,s.code from distibutor s where s.DType='Dealer' and s.oemid="+SessionVeriables.UserId);
            rptrUser.DataSource = ds;
            rptrUser.DataBind();

          
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
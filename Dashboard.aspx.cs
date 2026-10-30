using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminLoginData ad = new AdminLoginData();
        DataSet ds = ad.getDetails("select (SELECT count(id) FROM sellersales WHERE npid=0 and status=1) as pending,(SELECT count(id) FROM sellersales WHERE status=0) as cancelled,(SELECT count(id) FROM sellersales WHERE npid=1 and status=1) as Completed,(SELECT count(id) FROM sellersales ) as Total");

        lblRejectedOrder.Text = ds.Tables[0].Rows[0]["cancelled"].ToString();
        lblCompletedOrder.Text = ds.Tables[0].Rows[0]["Completed"].ToString();
        lblGeneratedOrder.Text = ds.Tables[0].Rows[0]["pending"].ToString();
        lblTotalOrders.Text = ds.Tables[0].Rows[0]["Total"].ToString();
    }
}
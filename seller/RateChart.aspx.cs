using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class seller_RateChart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminLoginData ad = new AdminLoginData();
        DataSet ds = ad.getDetails("select * from ratechart where status=1 and ext="+SessionVeriables.UserId);
        rptrUser.DataSource = ds;
        rptrUser.DataBind();
    }
}
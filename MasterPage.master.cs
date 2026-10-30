using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
if (!SessionVeriables.IsLogged && (SessionVeriables.SessionName != "Admin" || SessionVeriables.SessionName != "Super Admin" || SessionVeriables.SessionName != "Sub-Admin") && SessionVeriables.IsAdmin != "True")
{
   // SessionVeriables.UserApp = "No";
    Response.Redirect("default.aspx");
}
    }
}

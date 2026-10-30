using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class seller_BankDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // int ids = ;
        //DistibutorData dd = new DistibutorData(SessionVeriables.UserId);
        BankDetails bd = new BankDetails(SessionVeriables.UserId, "fdfd");
        lblAccountNo.Text = bd.ano;
        lblAName.Text = bd.anane;
        lblBankName.Text = bd.bname;
        lblBranchCode.Text = bd.branchcode;
        lblBranchName.Text = bd.branchname;
        lblIFSC.Text = bd.ifsc;
        lblPanNo.Text = bd.panno;
        lblAtype.Text = bd.atype;
    }
}
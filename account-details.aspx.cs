using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class account_details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CityDetails msdata = new CityDetails();
            DataSet ds1 = msdata.getDetails("SELECT id,name FROM distibutor WHERE status=1 and DType='Dealer' order by name");
            //DataSet ds1 = msdata.getDetails("SELECT id,name FROM distibutor WHERE status=1 and extra=0 and DType='Embossing' order by name");
            ddlState.DataSource = ds1;
            ddlState.DataTextField = "name";
            ddlState.DataValueField = "id";
            ddlState.DataBind();
            ddlState.Items.Insert(0, "Select dealer");
            ddlState.SelectedIndex = 0;

            //BankDetails bd = new BankDetails(0, "dfd");
            //if (bd.HasValue)
            //{
            //    btnSubmit.Visible = false;
            //    btnUpdate.Visible = true;
            //    txtAccountName.Text = bd.anane;
            //    txtAccountNo.Text = bd.ano;
            //    txtAccountType.Text = bd.atype;
            //    txtBankName.Text = bd.bname;
            //    txtBranchCode.Text = bd.branchcode;
            //    txtBranchName.Text = bd.branchname;
            //    txtIFSCCode.Text = bd.ifsc;
            //    txtPanNo.Text = bd.panno;
            //    lblId.Text = bd.id.ToString();
            //}
            //else
            //{
              btnSubmit.Visible = false;
                btnUpdate.Visible = false;
            //}
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlState.SelectedItem.ToString() != "Select dealer")
        {
            BankDetails bd = new BankDetails();
            bd.anane = txtAccountName.Text;
            bd.ano = txtAccountNo.Text;
            bd.atype = txtAccountType.Text;
            bd.bname = txtBankName.Text;
            bd.branchcode = txtBranchCode.Text;
            bd.branchname = txtBranchName.Text;
            bd.ifsc = txtIFSCCode.Text;
            bd.panno = txtPanNo.Text;
            //if (ddlState.SelectedItem.ToString() == "Select Delaer")
            //{
            //    bd.did = 0;
            //}
            //else
            //{
            bd.did = int.Parse(ddlState.SelectedValue.ToString());
            // }
            bd.Save();
            Response.Redirect("account-details.aspx");
        }
    }



    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        BankDetails bd = new BankDetails();
        bd.anane = txtAccountName.Text;
        bd.ano = txtAccountNo.Text;
        bd.atype = txtAccountType.Text;
        bd.bname = txtBankName.Text;
        bd.branchcode = txtBranchCode.Text;
        bd.branchname = txtBranchName.Text;
        bd.ifsc = txtIFSCCode.Text;
        bd.panno = txtPanNo.Text;
        //if (ddlState.SelectedItem.ToString() == "Company")
        //{
        //    bd.did = 0;
        //}
        //else
        //{
        //    bd.did = int.Parse(ddlState.SelectedValue.ToString());
        //}
        bd.update(int.Parse(lblId.Text));
        Response.Redirect("account-details.aspx");
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedItem.ToString() == "Select dealer")
        {
            //BankDetails bd = new BankDetails(0, "dfd");
            //if (bd.HasValue)
            //{
            //    btnSubmit.Visible = false;
            //    btnUpdate.Visible = true;
            //    txtAccountName.Text = bd.anane;
            //    txtAccountNo.Text = bd.ano;
            //    txtAccountType.Text = bd.atype;
            //    txtBankName.Text = bd.bname;
            //    txtBranchCode.Text = bd.branchcode;
            //    txtBranchName.Text = bd.branchname;
            //    txtIFSCCode.Text = bd.ifsc;
            //    txtPanNo.Text = bd.panno;
            //    lblId.Text = bd.id.ToString();
            //}
            //else
            //{
            //    btnSubmit.Visible = true;
            //    btnUpdate.Visible = false;
            //    txtAccountName.Text = "";
            //    txtAccountNo.Text = "";
            //    txtAccountType.Text = "";
            //    txtBankName.Text = "";
            //    txtBranchCode.Text = "";
            //    txtBranchName.Text = "";
            //    txtIFSCCode.Text = "";
            //    txtPanNo.Text = "";
            //}
        }
        else
        {
            BankDetails bd = new BankDetails(int.Parse(ddlState.SelectedValue.ToString()), "dfd");
            if (bd.HasValue)
            {
                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
                txtAccountName.Text = bd.anane;
                txtAccountNo.Text = bd.ano;
                txtAccountType.Text = bd.atype;
                txtBankName.Text = bd.bname;
                txtBranchCode.Text = bd.branchcode;
                txtBranchName.Text = bd.branchname;
                txtIFSCCode.Text = bd.ifsc;
                txtPanNo.Text = bd.panno;
                lblId.Text = bd.id.ToString();

            }
            else
            {
                btnSubmit.Visible = true;
                btnUpdate.Visible = false;

                txtAccountName.Text = "";
                txtAccountNo.Text = "";
                txtAccountType.Text = "";
                txtBankName.Text = "";
                txtBranchCode.Text = "";
                txtBranchName.Text = "";
                txtIFSCCode.Text = "";
                txtPanNo.Text = "";

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vehicle_details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!IsPostBack))
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                OnlineOrderData od = new OnlineOrderData(int.Parse(Request.QueryString["id"]));
                lblOrderDate.Text = od.orderdaate;
                lblOrderType.Text = od.ordertype;
                lblOwnerName.Text = od.ownername;
                lblMobileNumber.Text = od.mobilenumber;
                lblEmail.Text = od.emailid;
                lblAddress.Text = od.billingaddress;
                lblCity.Text = od.city;
                lblState.Text = od.state;
                lblRegNumber.Text = od.registrationnumber;
                lblChasisNumber.Text = od.chasisnumber;
                lblEngineNumber.Text = od.enginenumber;
                lblBharatStage.Text = od.bharatstage;
                lblRegistrationDate.Text = od.vehicleregistrationbate;
                lblFuelType.Text = od.fueltype;
                lblMaker.Text = od.maker;
                lblVehicleType.Text = od.vehicletype;
                lblVehicleCategory.Text = od.vehiclecategory + ", " + od.vehiclecategory1;
                lblFrontLaserNo.Text = od.frontlaserno;
                lblRearLaserNo.Text = od.rearlaserno;
                lblFirLRNo.Text = od.fir_lr_no;
                lblFIRDate.Text = od.firdate;
                lblPoliceStation.Text = od.policestationname;
                lblReasonforreplacement.Text = od.reasonforreplacement;
                lblReplacement.Text = od.replacement;

                DataSet ds = od.getDetails("SELECT o.frontlaserphoto,o.frontplatephoto,o.rearlaserphoto,o.rearplatephoto,o.fircopy,o.uploadrc FROM onlinesales o WHERE o.id=" + int.Parse(Request.QueryString["id"]));
                rptrUser.DataSource = ds;
                rptrUser.DataBind();
            }
        }

    }
}
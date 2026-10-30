using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OnlineOrderData
/// </summary>
public class OnlineOrderData
{
    public OnlineOrderData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public OnlineOrderData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from onlinesales where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                state = ds.Tables[0].Rows[0]["state"].ToString();
                registrationnumber = ds.Tables[0].Rows[0]["registrationnumber"].ToString();
                chasisnumber = ds.Tables[0].Rows[0]["chasisnumber"].ToString();
                enginenumber = ds.Tables[0].Rows[0]["enginenumber"].ToString();
                bharatstage = ds.Tables[0].Rows[0]["bharatstage"].ToString();
                vehicleregistrationbate = ds.Tables[0].Rows[0]["vehicleregistrationbate"].ToString();
                fueltype = ds.Tables[0].Rows[0]["fueltype"].ToString();
                maker = ds.Tables[0].Rows[0]["maker"].ToString();
                vehicletype = ds.Tables[0].Rows[0]["vehicletype"].ToString();
                vehiclecategory = ds.Tables[0].Rows[0]["vehiclecategory"].ToString();
                vehiclecategory1 = ds.Tables[0].Rows[0]["vehiclecategory1"].ToString();
                ownername = ds.Tables[0].Rows[0]["ownername"].ToString();
                emailid = ds.Tables[0].Rows[0]["emailid"].ToString();
                mobilenumber = ds.Tables[0].Rows[0]["mobilenumber"].ToString();
                billingaddress = ds.Tables[0].Rows[0]["billingaddress"].ToString();
                city = ds.Tables[0].Rows[0]["city"].ToString();
                fitmentcentre = int.Parse(ds.Tables[0].Rows[0]["fitmentcentre"].ToString());
                fitmentcentre = int.Parse(ds.Tables[0].Rows[0]["fitmentcentre"].ToString());
                orderdaate = ds.Tables[0].Rows[0]["orderdaate"].ToString();
                paymentstatus = ds.Tables[0].Rows[0]["paymentstatus"].ToString();
                amount = double.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
                frontlaserno = ds.Tables[0].Rows[0]["frontlaserno"].ToString();
                rearlaserno = ds.Tables[0].Rows[0]["rearlaserno"].ToString();
                orderstatus = ds.Tables[0].Rows[0]["orderstatus"].ToString();
                ordertype = ds.Tables[0].Rows[0]["ordertype"].ToString();
                fir_lr_no = ds.Tables[0].Rows[0]["fir_lr_no"].ToString();
                firdate = ds.Tables[0].Rows[0]["firdate"].ToString();
                reasonforreplacement = ds.Tables[0].Rows[0]["reasonforreplacement"].ToString();
                replacement = ds.Tables[0].Rows[0]["replacement"].ToString();
                policestationname = ds.Tables[0].Rows[0]["policestationname"].ToString();
                frontlaserphoto = ds.Tables[0].Rows[0]["frontlaserphoto"].ToString();
                rearlaserphoto = ds.Tables[0].Rows[0]["rearlaserphoto"].ToString();
                fircopy = ds.Tables[0].Rows[0]["fircopy"].ToString();
                uploadrc = ds.Tables[0].Rows[0]["uploadrc"].ToString();
                frontplatephoto = ds.Tables[0].Rows[0]["frontplatephoto"].ToString();
                rearplatephoto = ds.Tables[0].Rows[0]["rearplatephoto"].ToString();
                rleaserno = ds.Tables[0].Rows[0]["rleaserno"].ToString();
                flaserno = ds.Tables[0].Rows[0]["flaserno"].ToString();
                gst = double.Parse(ds.Tables[0].Rows[0]["gst"].ToString());
                netanount = double.Parse(ds.Tables[0].Rows[0]["netanount"].ToString());
                npid = int.Parse(ds.Tables[0].Rows[0]["npid"].ToString());
                fitmentdate = ds.Tables[0].Rows[0]["fitmentdate"].ToString();
                emsid = int.Parse(ds.Tables[0].Rows[0]["emsid"].ToString());
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }

    public OnlineOrderData(string names, string mobile, string vehicleno)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@ownername", names));
        param.Add(new MySqlParameter("@mobilenumber", mobile));
        param.Add(new MySqlParameter("@registrationnumber", vehicleno));

        using (DataSet ds = connect.GetDataset("select * from onlinesales where ownername=@ownername and mobilenumber=@mobilenumber and registrationnumber=@registrationnumber and status=1 order by id desc limit 1 ", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                state = ds.Tables[0].Rows[0]["state"].ToString();
                registrationnumber = ds.Tables[0].Rows[0]["registrationnumber"].ToString();
                chasisnumber = ds.Tables[0].Rows[0]["chasisnumber"].ToString();
                enginenumber = ds.Tables[0].Rows[0]["enginenumber"].ToString();
                bharatstage = ds.Tables[0].Rows[0]["bharatstage"].ToString();
                vehicleregistrationbate = ds.Tables[0].Rows[0]["vehicleregistrationbate"].ToString();
                fueltype = ds.Tables[0].Rows[0]["fueltype"].ToString();
                maker = ds.Tables[0].Rows[0]["maker"].ToString();
                vehicletype = ds.Tables[0].Rows[0]["vehicletype"].ToString();
                vehiclecategory = ds.Tables[0].Rows[0]["vehiclecategory"].ToString();
                vehiclecategory1 = ds.Tables[0].Rows[0]["vehiclecategory1"].ToString();
                ownername = ds.Tables[0].Rows[0]["ownername"].ToString();
                emailid = ds.Tables[0].Rows[0]["emailid"].ToString();
                mobilenumber = ds.Tables[0].Rows[0]["mobilenumber"].ToString();
                billingaddress = ds.Tables[0].Rows[0]["billingaddress"].ToString();
                city = ds.Tables[0].Rows[0]["city"].ToString();
                fitmentcentre = int.Parse(ds.Tables[0].Rows[0]["fitmentcentre"].ToString());
                fitmentcentre = int.Parse(ds.Tables[0].Rows[0]["fitmentcentre"].ToString());
                orderdaate = ds.Tables[0].Rows[0]["orderdaate"].ToString();
                paymentstatus = ds.Tables[0].Rows[0]["paymentstatus"].ToString();
                amount = double.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
                frontlaserno = ds.Tables[0].Rows[0]["frontlaserno"].ToString();
                rearlaserno = ds.Tables[0].Rows[0]["rearlaserno"].ToString();
                orderstatus = ds.Tables[0].Rows[0]["orderstatus"].ToString();
                ordertype = ds.Tables[0].Rows[0]["ordertype"].ToString();
                fir_lr_no = ds.Tables[0].Rows[0]["fir_lr_no"].ToString();
                firdate = ds.Tables[0].Rows[0]["firdate"].ToString();
                reasonforreplacement = ds.Tables[0].Rows[0]["reasonforreplacement"].ToString();
                replacement = ds.Tables[0].Rows[0]["replacement"].ToString();
                policestationname = ds.Tables[0].Rows[0]["policestationname"].ToString();
                frontlaserphoto = ds.Tables[0].Rows[0]["frontlaserphoto"].ToString();
                rearlaserphoto = ds.Tables[0].Rows[0]["rearlaserphoto"].ToString();
                fircopy = ds.Tables[0].Rows[0]["fircopy"].ToString();
                uploadrc = ds.Tables[0].Rows[0]["uploadrc"].ToString();
                frontplatephoto = ds.Tables[0].Rows[0]["frontplatephoto"].ToString();
                rearplatephoto = ds.Tables[0].Rows[0]["rearplatephoto"].ToString();
                fitmentdate = ds.Tables[0].Rows[0]["fitmentdate"].ToString();
                rleaserno = ds.Tables[0].Rows[0]["rleaserno"].ToString();
                flaserno = ds.Tables[0].Rows[0]["flaserno"].ToString();
                gst = double.Parse(ds.Tables[0].Rows[0]["gst"].ToString());
                netanount = double.Parse(ds.Tables[0].Rows[0]["netanount"].ToString());
                npid = int.Parse(ds.Tables[0].Rows[0]["npid"].ToString());
                emsid = int.Parse(ds.Tables[0].Rows[0]["emsid"].ToString());

            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public void updateLaserBoth(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@frontlaserno", frontlaserno));
        param.Add(new MySqlParameter("@rearlaserno", rearlaserno));
        param.Add(new MySqlParameter("@orderstatus", "Completed"));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE onlinesales SET orderstatus=@orderstatus,rearlaserno=@rearlaserno,frontlaserno=@frontlaserno WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void updateLaserFront(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@frontlaserno", frontlaserno));
        param.Add(new MySqlParameter("@orderstatus", "Completed"));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE onlinesales SET orderstatus=@orderstatus,frontlaserno=@frontlaserno WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void updateLaserRear(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@rearlaserno", rearlaserno));
        param.Add(new MySqlParameter("@orderstatus", "Completed"));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE onlinesales SET orderstatus=@orderstatus,rearlaserno=@rearlaserno WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void updateOrderStatus(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@orderstatus", orderstatus));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE onlinesales SET orderstatus=@orderstatus WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void updateBookingStatus(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@paymentstatus", paymentstatus));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE onlinesales SET paymentstatus=@paymentstatus WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void updateadmin()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@paymentstatus", paymentstatus));
        param.Add(new MySqlParameter("@orderstatus", orderstatus));
        param.Add(new MySqlParameter("@status", status));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE onlinesales SET paymentstatus=@paymentstatus,orderstatus=@orderstatus,status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void Block(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 0));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE onlinesales SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UnBlock(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 1));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE onlinesales SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void SaveWithColorSticker()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@state", state));
        param.Add(new MySqlParameter("@registrationnumber", registrationnumber));
        param.Add(new MySqlParameter("@chasisnumber", chasisnumber));
        param.Add(new MySqlParameter("@enginenumber", enginenumber));
        param.Add(new MySqlParameter("@bharatstage", bharatstage));
        param.Add(new MySqlParameter("@vehicleregistrationbate", vehicleregistrationbate));
        param.Add(new MySqlParameter("@fueltype", fueltype));
        param.Add(new MySqlParameter("@maker", maker));
        param.Add(new MySqlParameter("@vehicletype", vehicletype));
        param.Add(new MySqlParameter("@vehiclecategory", vehiclecategory));
        param.Add(new MySqlParameter("@vehiclecategory1", vehiclecategory1));
        param.Add(new MySqlParameter("@ownername", ownername));
        param.Add(new MySqlParameter("@emailid", emailid));
        param.Add(new MySqlParameter("@mobilenumber", mobilenumber));
        param.Add(new MySqlParameter("@billingaddress", billingaddress));
        param.Add(new MySqlParameter("@city", city));
        param.Add(new MySqlParameter("@fitmentcentre", fitmentcentre));
        param.Add(new MySqlParameter("@orderdaate", orderdaate));
        param.Add(new MySqlParameter("@paymentstatus", "Pending"));
        param.Add(new MySqlParameter("@amount", amount));
        param.Add(new MySqlParameter("@gst", gst));
        param.Add(new MySqlParameter("@netanount", netanount));
        param.Add(new MySqlParameter("@fitmentdate", fitmentdate));
        param.Add(new MySqlParameter("@emsid", emsid));
        param.Add(new MySqlParameter("@orderflag", "NB"));
        //param.Add(new MySqlParameter("@npid", 0));
        param.Add(new MySqlParameter("@ordertype", "high security registration plate with colour sticker"));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO onlinesales(state,registrationnumber,chasisnumber,enginenumber,bharatstage,vehicleregistrationbate,fueltype,maker,vehicletype,vehiclecategory,vehiclecategory1,ownername,emailid,mobilenumber,billingaddress,city,fitmentcentre,orderdaate,paymentstatus,amount,gst,netanount,ordertype,fitmentdate,emsid,orderflag) VALUES(@state,@registrationnumber,@chasisnumber,@enginenumber,@bharatstage,@vehicleregistrationbate,@fueltype,@maker,@vehicletype,@vehiclecategory,@vehiclecategory1,@ownername,@emailid,@mobilenumber,@billingaddress,@city,@fitmentcentre,@orderdaate,@paymentstatus,@amount,@gst,@netanount,@ordertype,@fitmentdate,@emsid,@orderflag)", param);
        connect.Dispose();
        connect = null;
    }
    public void SaveForElectricVehicle()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@state", state));
        param.Add(new MySqlParameter("@registrationnumber", registrationnumber));
        param.Add(new MySqlParameter("@chasisnumber", chasisnumber));
        param.Add(new MySqlParameter("@enginenumber", enginenumber));
        param.Add(new MySqlParameter("@bharatstage", bharatstage));
        param.Add(new MySqlParameter("@vehicleregistrationbate", vehicleregistrationbate));
        param.Add(new MySqlParameter("@fueltype", fueltype));
        param.Add(new MySqlParameter("@maker", maker));
        param.Add(new MySqlParameter("@vehicletype", vehicletype));
        param.Add(new MySqlParameter("@vehiclecategory", vehiclecategory));
        param.Add(new MySqlParameter("@vehiclecategory1", vehiclecategory1));
        param.Add(new MySqlParameter("@ownername", ownername));
        param.Add(new MySqlParameter("@emailid", emailid));
        param.Add(new MySqlParameter("@mobilenumber", mobilenumber));
        param.Add(new MySqlParameter("@billingaddress", billingaddress));
        param.Add(new MySqlParameter("@city", city));
        param.Add(new MySqlParameter("@fitmentcentre", fitmentcentre));
        param.Add(new MySqlParameter("@orderdaate", orderdaate));
        param.Add(new MySqlParameter("@paymentstatus", "Pending"));
        param.Add(new MySqlParameter("@orderflag", "NB"));
        param.Add(new MySqlParameter("@amount", amount));
        param.Add(new MySqlParameter("@gst", gst));
        param.Add(new MySqlParameter("@netanount", netanount));
        param.Add(new MySqlParameter("@fitmentdate", fitmentdate));
        param.Add(new MySqlParameter("@emsid", emsid));
        param.Add(new MySqlParameter("@ordertype", "high security registration plate for electric vehicle"));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO onlinesales(state,registrationnumber,chasisnumber,enginenumber,bharatstage,vehicleregistrationbate,fueltype,maker,vehicletype,vehiclecategory,vehiclecategory1,ownername,emailid,mobilenumber,billingaddress,city,fitmentcentre,orderdaate,paymentstatus,amount,gst,netanount,ordertype,fitmentdate,emsid,orderflag) VALUES(@state,@registrationnumber,@chasisnumber,@enginenumber,@bharatstage,@vehicleregistrationbate,@fueltype,@maker,@vehicletype,@vehiclecategory,@vehiclecategory1,@ownername,@emailid,@mobilenumber,@billingaddress,@city,@fitmentcentre,@orderdaate,@paymentstatus,@amount,@gst,@netanount,@ordertype,@fitmentdate,@emsid,@orderflag)", param);
        connect.Dispose();
        connect = null;
    }
    public void SaveForTractorTrailer()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@state", state));
        param.Add(new MySqlParameter("@registrationnumber", registrationnumber));
        param.Add(new MySqlParameter("@chasisnumber", chasisnumber));
        param.Add(new MySqlParameter("@enginenumber", enginenumber));
        param.Add(new MySqlParameter("@bharatstage", bharatstage));
        param.Add(new MySqlParameter("@vehicleregistrationbate", vehicleregistrationbate));
        param.Add(new MySqlParameter("@fueltype", fueltype));
        param.Add(new MySqlParameter("@maker", maker));
        param.Add(new MySqlParameter("@vehicletype", vehicletype));
        param.Add(new MySqlParameter("@vehiclecategory", vehiclecategory));
        param.Add(new MySqlParameter("@vehiclecategory1", vehiclecategory1));
        param.Add(new MySqlParameter("@ownername", ownername));
        param.Add(new MySqlParameter("@emailid", emailid));
        param.Add(new MySqlParameter("@mobilenumber", mobilenumber));
        param.Add(new MySqlParameter("@billingaddress", billingaddress));
        param.Add(new MySqlParameter("@city", city));
        param.Add(new MySqlParameter("@fitmentcentre", fitmentcentre));
        param.Add(new MySqlParameter("@orderdaate", orderdaate));
        param.Add(new MySqlParameter("@paymentstatus", "Pending"));
        param.Add(new MySqlParameter("@amount", amount));
        param.Add(new MySqlParameter("@gst", gst));
        param.Add(new MySqlParameter("@netanount", netanount));
        param.Add(new MySqlParameter("@fitmentdate", fitmentdate));
        param.Add(new MySqlParameter("@emsid", emsid));
        param.Add(new MySqlParameter("@orderflag", "NB"));
        // param.Add(new MySqlParameter("@npid", 0));
        param.Add(new MySqlParameter("@ordertype", "high security registration plate for tractor trailer"));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO onlinesales(state,registrationnumber,chasisnumber,enginenumber,bharatstage,vehicleregistrationbate,fueltype,maker,vehicletype,vehiclecategory,vehiclecategory1,ownername,emailid,mobilenumber,billingaddress,city,fitmentcentre,orderdaate,paymentstatus,amount,gst,netanount,ordertype,fitmentdate,emsid,orderflag) VALUES(@state,@registrationnumber,@chasisnumber,@enginenumber,@bharatstage,@vehicleregistrationbate,@fueltype,@maker,@vehicletype,@vehiclecategory,@vehiclecategory1,@ownername,@emailid,@mobilenumber,@billingaddress,@city,@fitmentcentre,@orderdaate,@paymentstatus,@amount,@gst,@netanount,@ordertype,@fitmentdate,@emsid,@orderflag)", param);
        connect.Dispose();
        connect = null;
    }
    public void SaveForoOnlyColourSticker()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@state", state));
        param.Add(new MySqlParameter("@registrationnumber", registrationnumber));
        param.Add(new MySqlParameter("@chasisnumber", chasisnumber));
        param.Add(new MySqlParameter("@enginenumber", enginenumber));
        param.Add(new MySqlParameter("@bharatstage", bharatstage));
        param.Add(new MySqlParameter("@vehicleregistrationbate", vehicleregistrationbate));
        param.Add(new MySqlParameter("@fueltype", fueltype));
        param.Add(new MySqlParameter("@maker", maker));
        param.Add(new MySqlParameter("@vehicletype", vehicletype));
        param.Add(new MySqlParameter("@vehiclecategory", vehiclecategory));
        param.Add(new MySqlParameter("@vehiclecategory1", vehiclecategory1));
        param.Add(new MySqlParameter("@ownername", ownername));
        param.Add(new MySqlParameter("@emailid", emailid));
        param.Add(new MySqlParameter("@mobilenumber", mobilenumber));
        param.Add(new MySqlParameter("@billingaddress", billingaddress));
        param.Add(new MySqlParameter("@city", city));
        param.Add(new MySqlParameter("@fitmentcentre", fitmentcentre));
        param.Add(new MySqlParameter("@orderdaate", orderdaate));
        param.Add(new MySqlParameter("@paymentstatus", "Pending"));
        param.Add(new MySqlParameter("@amount", amount));
        param.Add(new MySqlParameter("@gst", gst));
        param.Add(new MySqlParameter("@netanount", netanount));
        //param.Add(new MySqlParameter("@npid", 0));
        param.Add(new MySqlParameter("@ordertype", "only colour sticker"));

        param.Add(new MySqlParameter("@frontlaserno", frontlaserno));
        param.Add(new MySqlParameter("@rearlaserno", rearlaserno));
        param.Add(new MySqlParameter("@frontlaserphoto", frontlaserphoto));
        param.Add(new MySqlParameter("@rearlaserphoto", rearlaserphoto));
        param.Add(new MySqlParameter("@frontplatephoto", frontplatephoto));
        param.Add(new MySqlParameter("@rearplatephoto", rearplatephoto));
        param.Add(new MySqlParameter("@fitmentdate", fitmentdate));
        param.Add(new MySqlParameter("@emsid", emsid));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO onlinesales(state,registrationnumber,chasisnumber,enginenumber,bharatstage,vehicleregistrationbate,fueltype,maker,vehicletype,vehiclecategory,vehiclecategory1,ownername,emailid,mobilenumber,billingaddress,city,fitmentcentre,orderdaate,paymentstatus,amount,gst,netanount,ordertype,frontlaserno,rearlaserno,frontlaserphoto,rearlaserphoto,frontplatephoto,rearplatephoto,fitmentdate,emsid) VALUES(@state,@registrationnumber,@chasisnumber,@enginenumber,@bharatstage,@vehicleregistrationbate,@fueltype,@maker,@vehicletype,@vehiclecategory,@vehiclecategory1,@ownername,@emailid,@mobilenumber,@billingaddress,@city,@fitmentcentre,@orderdaate,@paymentstatus,@amount,@gst,@netanount,@ordertype,@frontlaserno,@rearlaserno,@frontlaserphoto,@rearlaserphoto,@frontplatephoto,@rearplatephoto,@fitmentdate,@emsid)", param);
        connect.Dispose();
        connect = null;
    }
    public void SaveForReplacementBoth()
    {
        // 
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@state", state));
        param.Add(new MySqlParameter("@registrationnumber", registrationnumber));
        param.Add(new MySqlParameter("@chasisnumber", chasisnumber));
        param.Add(new MySqlParameter("@enginenumber", enginenumber));
        param.Add(new MySqlParameter("@bharatstage", bharatstage));
        param.Add(new MySqlParameter("@vehicleregistrationbate", vehicleregistrationbate));
        param.Add(new MySqlParameter("@fueltype", fueltype));
        param.Add(new MySqlParameter("@maker", maker));
        param.Add(new MySqlParameter("@vehicletype", vehicletype));
        param.Add(new MySqlParameter("@vehiclecategory", vehiclecategory));
        param.Add(new MySqlParameter("@vehiclecategory1", vehiclecategory1));
        param.Add(new MySqlParameter("@ownername", ownername));
        param.Add(new MySqlParameter("@emailid", emailid));
        param.Add(new MySqlParameter("@mobilenumber", mobilenumber));
        param.Add(new MySqlParameter("@billingaddress", billingaddress));
        param.Add(new MySqlParameter("@city", city));
        param.Add(new MySqlParameter("@fitmentcentre", fitmentcentre));
        param.Add(new MySqlParameter("@orderdaate", orderdaate));
        param.Add(new MySqlParameter("@paymentstatus", "Pending"));
        param.Add(new MySqlParameter("@amount", amount));
        param.Add(new MySqlParameter("@gst", gst));
        param.Add(new MySqlParameter("@netanount", netanount));
        param.Add(new MySqlParameter("@reasonforreplacement", reasonforreplacement));
        param.Add(new MySqlParameter("@replacement", replacement));
        param.Add(new MySqlParameter("@fir_lr_no", fir_lr_no));
        param.Add(new MySqlParameter("@firdate", firdate));
        param.Add(new MySqlParameter("@policestationname", policestationname));
        param.Add(new MySqlParameter("@fircopy", fircopy));
        param.Add(new MySqlParameter("@uploadrc", uploadrc));
        param.Add(new MySqlParameter("@fitmentdate", fitmentdate));
        param.Add(new MySqlParameter("@emsid", emsid));
        param.Add(new MySqlParameter("@orderflag", "DB"));
        //param.Add(new MySqlParameter("@npid", 0));
        param.Add(new MySqlParameter("@ordertype", "replacement both plate"));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO onlinesales(state,registrationnumber,chasisnumber,enginenumber,bharatstage,vehicleregistrationbate,fueltype,maker,vehicletype,vehiclecategory,vehiclecategory1,ownername,emailid,mobilenumber,billingaddress,city,fitmentcentre,orderdaate,paymentstatus,amount,gst,netanount,ordertype,reasonforreplacement,replacement,fir_lr_no,firdate,policestationname,fircopy,uploadrc,fitmentdate,emsid,orderflag) VALUES(@state,@registrationnumber,@chasisnumber,@enginenumber,@bharatstage,@vehicleregistrationbate,@fueltype,@maker,@vehicletype,@vehiclecategory,@vehiclecategory1,@ownername,@emailid,@mobilenumber,@billingaddress,@city,@fitmentcentre,@orderdaate,@paymentstatus,@amount,@gst,@netanount,@ordertype,@reasonforreplacement,@replacement,@fir_lr_no,@firdate,@policestationname,@fircopy,@uploadrc,@fitmentdate,@emsid,@orderflag)", param);
        connect.Dispose();
        connect = null;
    }
    public void SaveForReplacementFront()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@state", state));
        param.Add(new MySqlParameter("@registrationnumber", registrationnumber));
        param.Add(new MySqlParameter("@chasisnumber", chasisnumber));
        param.Add(new MySqlParameter("@enginenumber", enginenumber));
        param.Add(new MySqlParameter("@bharatstage", bharatstage));
        param.Add(new MySqlParameter("@vehicleregistrationbate", vehicleregistrationbate));
        param.Add(new MySqlParameter("@fueltype", fueltype));
        param.Add(new MySqlParameter("@maker", maker));
        param.Add(new MySqlParameter("@vehicletype", vehicletype));
        param.Add(new MySqlParameter("@vehiclecategory", vehiclecategory));
        param.Add(new MySqlParameter("@vehiclecategory1", vehiclecategory1));
        param.Add(new MySqlParameter("@ownername", ownername));
        param.Add(new MySqlParameter("@emailid", emailid));
        param.Add(new MySqlParameter("@mobilenumber", mobilenumber));
        param.Add(new MySqlParameter("@billingaddress", billingaddress));
        param.Add(new MySqlParameter("@city", city));
        param.Add(new MySqlParameter("@fitmentcentre", fitmentcentre));
        param.Add(new MySqlParameter("@orderdaate", orderdaate));
        param.Add(new MySqlParameter("@paymentstatus", "Pending"));
        param.Add(new MySqlParameter("@amount", amount));
        param.Add(new MySqlParameter("@gst", gst));
        param.Add(new MySqlParameter("@netanount", netanount));
        param.Add(new MySqlParameter("@reasonforreplacement", reasonforreplacement));
        param.Add(new MySqlParameter("@replacement", replacement));
        param.Add(new MySqlParameter("@fir_lr_no", fir_lr_no));
        param.Add(new MySqlParameter("@firdate", firdate));
        param.Add(new MySqlParameter("@policestationname", policestationname));
        param.Add(new MySqlParameter("@fircopy", fircopy));
        param.Add(new MySqlParameter("@uploadrc", uploadrc));
        param.Add(new MySqlParameter("@rearlaserno", rearlaserno));
        param.Add(new MySqlParameter("@rearplatephoto", rearplatephoto));
        param.Add(new MySqlParameter("@fitmentdate", fitmentdate));
        param.Add(new MySqlParameter("@emsid", emsid));
        param.Add(new MySqlParameter("@orderflag", "DF"));
        //param.Add(new MySqlParameter("@npid", 0));
        param.Add(new MySqlParameter("@ordertype", "replacement front only"));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO onlinesales(state,registrationnumber,chasisnumber,enginenumber,bharatstage,vehicleregistrationbate,fueltype,maker,vehicletype,vehiclecategory,vehiclecategory1,ownername,emailid,mobilenumber,billingaddress,city,fitmentcentre,orderdaate,paymentstatus,amount,gst,netanount,ordertype,reasonforreplacement,replacement,fir_lr_no,firdate,policestationname,fircopy,uploadrc,rearlaserno,rearplatephoto,fitmentdate,emsid,orderflag) VALUES(@state,@registrationnumber,@chasisnumber,@enginenumber,@bharatstage,@vehicleregistrationbate,@fueltype,@maker,@vehicletype,@vehiclecategory,@vehiclecategory1,@ownername,@emailid,@mobilenumber,@billingaddress,@city,@fitmentcentre,@orderdaate,@paymentstatus,@amount,@gst,@netanount,@ordertype,@reasonforreplacement,@replacement,@fir_lr_no,@firdate,@policestationname,@fircopy,@uploadrc,@rearlaserno,@rearplatephoto,@fitmentdate,@emsid,@orderflag)", param);
        connect.Dispose();
        connect = null;
    }
    public void SaveForReplacementRear()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@state", state));
        param.Add(new MySqlParameter("@registrationnumber", registrationnumber));
        param.Add(new MySqlParameter("@chasisnumber", chasisnumber));
        param.Add(new MySqlParameter("@enginenumber", enginenumber));
        param.Add(new MySqlParameter("@bharatstage", bharatstage));
        param.Add(new MySqlParameter("@vehicleregistrationbate", vehicleregistrationbate));
        param.Add(new MySqlParameter("@fueltype", fueltype));
        param.Add(new MySqlParameter("@maker", maker));
        param.Add(new MySqlParameter("@vehicletype", vehicletype));
        param.Add(new MySqlParameter("@vehiclecategory", vehiclecategory));
        param.Add(new MySqlParameter("@vehiclecategory1", vehiclecategory1));
        param.Add(new MySqlParameter("@ownername", ownername));
        param.Add(new MySqlParameter("@emailid", emailid));
        param.Add(new MySqlParameter("@mobilenumber", mobilenumber));
        param.Add(new MySqlParameter("@billingaddress", billingaddress));
        param.Add(new MySqlParameter("@city", city));
        param.Add(new MySqlParameter("@fitmentcentre", fitmentcentre));
        param.Add(new MySqlParameter("@orderdaate", orderdaate));
        param.Add(new MySqlParameter("@paymentstatus", "Pending"));
        param.Add(new MySqlParameter("@amount", amount));
        param.Add(new MySqlParameter("@gst", gst));
        param.Add(new MySqlParameter("@netanount", netanount));
        param.Add(new MySqlParameter("@reasonforreplacement", reasonforreplacement));
        param.Add(new MySqlParameter("@replacement", replacement));
        param.Add(new MySqlParameter("@fir_lr_no", fir_lr_no));
        param.Add(new MySqlParameter("@firdate", firdate));
        param.Add(new MySqlParameter("@policestationname", policestationname));
        param.Add(new MySqlParameter("@fircopy", fircopy));
        param.Add(new MySqlParameter("@uploadrc", uploadrc));
        param.Add(new MySqlParameter("@frontlaserno", frontlaserno));
        param.Add(new MySqlParameter("@frontplatephoto", frontplatephoto));
        param.Add(new MySqlParameter("@fitmentdate", fitmentdate));
        param.Add(new MySqlParameter("@emsid", emsid));
        param.Add(new MySqlParameter("@orderflag", "DR"));
        // param.Add(new MySqlParameter("@npid", 0));
        param.Add(new MySqlParameter("@ordertype", "replacement rear only"));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO onlinesales(state,registrationnumber,chasisnumber,enginenumber,bharatstage,vehicleregistrationbate,fueltype,maker,vehicletype,vehiclecategory,vehiclecategory1,ownername,emailid,mobilenumber,billingaddress,city,fitmentcentre,orderdaate,paymentstatus,amount,gst,netanount,ordertype,reasonforreplacement,replacement,fir_lr_no,firdate,policestationname,fircopy,uploadrc,frontlaserno,frontplatephoto,fitmentdate,emsid,orderflag) VALUES(@state,@registrationnumber,@chasisnumber,@enginenumber,@bharatstage,@vehicleregistrationbate,@fueltype,@maker,@vehicletype,@vehiclecategory,@vehiclecategory1,@ownername,@emailid,@mobilenumber,@billingaddress,@city,@fitmentcentre,@orderdaate,@paymentstatus,@amount,@gst,@netanount,@ordertype,@reasonforreplacement,@replacement,@fir_lr_no,@firdate,@policestationname,@fircopy,@uploadrc,@frontlaserno,@frontplatephoto,@fitmentdate,@emsid,@orderflag)", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getDetails(String query)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();

        DataSet ds = connect.GetDataset(query);
        return ds;
    }


    public int id { get; set; }
    public int status { get; set; }
    public string state { get; set; }
    public string registrationnumber { get; set; }
    public string chasisnumber { get; set; }
    public string enginenumber { get; set; }
    public string bharatstage { get; set; }
    public string vehicleregistrationbate { get; set; }
    public string fueltype { get; set; }
    public string maker { get; set; }
    public string vehicletype { get; set; }
    public string vehiclecategory { get; set; }
    public string orderflag { get; set; }
    public string vehiclecategory1 { get; set; }
    public string ownername { get; set; }
    public string emailid { get; set; }
    public string mobilenumber { get; set; }
    public string billingaddress { get; set; }
    public string city { get; set; }
    public int fitmentcentre { get; set; }
    public string orderdaate { get; set; }
    public string paymentstatus { get; set; }
    public double amount { get; set; }
    public string frontlaserno { get; set; }
    public string rearlaserno { get; set; }
    public string orderstatus { get; set; }
    public string ordertype { get; set; }
    public string fir_lr_no { get; set; }
    public string firdate { get; set; }
    public string fitmentdate { get; set; }
    public string reasonforreplacement { get; set; }
    public string replacement { get; set; }
    public string policestationname { get; set; }
    public string frontlaserphoto { get; set; }
    public string rearlaserphoto { get; set; }
    public string fircopy { get; set; }
    public string uploadrc { get; set; }
    public string frontplatephoto { get; set; }
    public string rearplatephoto { get; set; }
    public string rleaserno { get; set; }
    public string flaserno { get; set; }
    public double gst { get; set; }
    public double netanount { get; set; }
    public int npid { get; set; }
    public int emsid { get; set; }

    public bool HasValue { get; set; }
}
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DistibutorData
/// </summary>
public class DistibutorData
{
    public DistibutorData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DistibutorData(int ids)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        using (DataSet ds = connect.GetDataset("select * from distibutor where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                name = ds.Tables[0].Rows[0]["name"].ToString();
                contactno = ds.Tables[0].Rows[0]["contactno"].ToString();
                email = (ds.Tables[0].Rows[0]["email"].ToString());
                address = (ds.Tables[0].Rows[0]["address"].ToString());
                city = ds.Tables[0].Rows[0]["city"].ToString();
                state = ds.Tables[0].Rows[0]["state"].ToString();
                username = (ds.Tables[0].Rows[0]["username"].ToString());
                password = (ds.Tables[0].Rows[0]["password"].ToString());
                date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                extra = int.Parse(ds.Tables[0].Rows[0]["extra"].ToString());
                DType = (ds.Tables[0].Rows[0]["DType"].ToString());
                GSTNo = (ds.Tables[0].Rows[0]["GSTNo"].ToString());
                // code = (ds.Tables[0].Rows[0]["code"].ToString());
                oemid = int.Parse(ds.Tables[0].Rows[0]["oemid"].ToString());
                contactperson = (ds.Tables[0].Rows[0]["contactperson"].ToString());
                designation = (ds.Tables[0].Rows[0]["designation"].ToString());
                deliveryaddress = (ds.Tables[0].Rows[0]["deliveryaddress"].ToString());
                zipcode = (ds.Tables[0].Rows[0]["zipcode"].ToString());
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public DistibutorData(string usernames)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@username", usernames));
        using (DataSet ds = connect.GetDataset("select * from distibutor where username=@username", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                name = ds.Tables[0].Rows[0]["name"].ToString();
                contactno = ds.Tables[0].Rows[0]["contactno"].ToString();
                email = (ds.Tables[0].Rows[0]["email"].ToString());
                address = (ds.Tables[0].Rows[0]["address"].ToString());
                city = ds.Tables[0].Rows[0]["city"].ToString();
                state = ds.Tables[0].Rows[0]["state"].ToString();
                username = (ds.Tables[0].Rows[0]["username"].ToString());
                password = (ds.Tables[0].Rows[0]["password"].ToString());
                date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                extra = int.Parse(ds.Tables[0].Rows[0]["extra"].ToString());
                DType = (ds.Tables[0].Rows[0]["DType"].ToString());
                GSTNo = (ds.Tables[0].Rows[0]["GSTNo"].ToString());
                //code = (ds.Tables[0].Rows[0]["code"].ToString());
                oemid = int.Parse(ds.Tables[0].Rows[0]["oemid"].ToString());
                contactperson = (ds.Tables[0].Rows[0]["contactperson"].ToString());
                designation = (ds.Tables[0].Rows[0]["designation"].ToString());
                deliveryaddress = (ds.Tables[0].Rows[0]["deliveryaddress"].ToString());
                zipcode = (ds.Tables[0].Rows[0]["zipcode"].ToString());
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public DistibutorData(string usernames, string password)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@username", usernames));
        param.Add(new MySqlParameter("@password", password));
        using (DataSet ds = connect.GetDataset("select * from distibutor where username=@username and password=@password", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                name = ds.Tables[0].Rows[0]["name"].ToString();
                contactno = ds.Tables[0].Rows[0]["contactno"].ToString();
                email = (ds.Tables[0].Rows[0]["email"].ToString());
                address = (ds.Tables[0].Rows[0]["address"].ToString());
                city = ds.Tables[0].Rows[0]["city"].ToString();
                state = ds.Tables[0].Rows[0]["state"].ToString();
                username = (ds.Tables[0].Rows[0]["username"].ToString());
                password = (ds.Tables[0].Rows[0]["password"].ToString());
                date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                extra = int.Parse(ds.Tables[0].Rows[0]["extra"].ToString());
                oemid = int.Parse(ds.Tables[0].Rows[0]["oemid"].ToString());
                DType = (ds.Tables[0].Rows[0]["DType"].ToString());
                GSTNo = (ds.Tables[0].Rows[0]["GSTNo"].ToString());
                contactperson = (ds.Tables[0].Rows[0]["contactperson"].ToString());
                designation = (ds.Tables[0].Rows[0]["designation"].ToString());
                deliveryaddress = (ds.Tables[0].Rows[0]["deliveryaddress"].ToString());
                zipcode = (ds.Tables[0].Rows[0]["zipcode"].ToString());
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public void update(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@name", name));
        param.Add(new MySqlParameter("@contactno", contactno));
        param.Add(new MySqlParameter("@email", email));
        param.Add(new MySqlParameter("@address", address));
        param.Add(new MySqlParameter("@state", state));
        param.Add(new MySqlParameter("@city", city));
        param.Add(new MySqlParameter("@DType", DType));
        param.Add(new MySqlParameter("@GSTNo", GSTNo));
        param.Add(new MySqlParameter("@designation", designation));
        param.Add(new MySqlParameter("@contactperson", contactperson));
        param.Add(new MySqlParameter("@deliveryaddress", deliveryaddress));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE distibutor SET deliveryaddress=@deliveryaddress,contactperson=@contactperson,designation=@designation,name=@name,contactno=@contactno,email=@email,address=@address,state=@state,city=@city,DType=@DType,GSTNo=@GSTNo WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void BlockUser(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 0));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE distibutor SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UnBlockUser(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 1));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE distibutor SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void updateadmin(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@name", name));
        param.Add(new MySqlParameter("@contactno", contactno));
        param.Add(new MySqlParameter("@email", email));
        param.Add(new MySqlParameter("@address", address));
        param.Add(new MySqlParameter("@state", state));
        param.Add(new MySqlParameter("@city", city));
        param.Add(new MySqlParameter("@DType", DType));
        param.Add(new MySqlParameter("@GSTNo", GSTNo));
        param.Add(new MySqlParameter("@extra", extra));
        param.Add(new MySqlParameter("@password", password));
        param.Add(new MySqlParameter("@designation", designation));
        param.Add(new MySqlParameter("@contactperson", contactperson));
        param.Add(new MySqlParameter("@deliveryaddress", deliveryaddress));
        
        param.Add(new MySqlParameter("@zipcode", zipcode));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE distibutor SET zipcode=@zipcode,deliveryaddress=@deliveryaddress,contactperson=@contactperson,designation=@designation,name=@name,password=@password,extra=@extra,contactno=@contactno,email=@email,address=@address,state=@state,city=@city,DType=@DType,GSTNo=@GSTNo WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void updateDealer(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@name", name));
        param.Add(new MySqlParameter("@contactno", contactno));
        param.Add(new MySqlParameter("@email", email));
        param.Add(new MySqlParameter("@address", address));
        param.Add(new MySqlParameter("@state", state));
        param.Add(new MySqlParameter("@city", city));
        param.Add(new MySqlParameter("@DType", DType));
        param.Add(new MySqlParameter("@GSTNo", GSTNo));
        param.Add(new MySqlParameter("@extra", extra));
        param.Add(new MySqlParameter("@password", password));
        param.Add(new MySqlParameter("@designation", designation));
        param.Add(new MySqlParameter("@contactperson", contactperson));
        param.Add(new MySqlParameter("@deliveryaddress", deliveryaddress));
        param.Add(new MySqlParameter("@oemid", oemid));
        param.Add(new MySqlParameter("@zipcode", zipcode));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE distibutor SET zipcode=@zipcode,oemid=@oemid,deliveryaddress=@deliveryaddress,contactperson=@contactperson,designation=@designation,name=@name,password=@password,extra=@extra,contactno=@contactno,email=@email,address=@address,state=@state,city=@city,DType=@DType,GSTNo=@GSTNo WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@name", name));
        param.Add(new MySqlParameter("@contactno", contactno));
        param.Add(new MySqlParameter("@email", email));
        param.Add(new MySqlParameter("@address", address));
        param.Add(new MySqlParameter("@state", state));
        param.Add(new MySqlParameter("@city", city));
        param.Add(new MySqlParameter("@username", username));
        param.Add(new MySqlParameter("@password", password));
        param.Add(new MySqlParameter("@date", date));
        param.Add(new MySqlParameter("@extra", extra));
        param.Add(new MySqlParameter("@DType", DType));
        param.Add(new MySqlParameter("@GSTNo", GSTNo));
        param.Add(new MySqlParameter("@designation", designation));
        param.Add(new MySqlParameter("@contactperson", contactperson));
        param.Add(new MySqlParameter("@deliveryaddress", deliveryaddress));
        param.Add(new MySqlParameter("@oemid", oemid));
        param.Add(new MySqlParameter("@zipcode", zipcode));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO distibutor(name,contactno,email,address,state,city,username,password,date,extra,DType,GSTNo,designation,contactperson,deliveryaddress,oemid,zipcode) VALUES(@name,@contactno,@email,@address,@state,@city,@username,@password,@date,@extra,@DType,@GSTNo,@designation,@contactperson,@deliveryaddress,@oemid,@zipcode)", param);
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
    public string name { get; set; }
    public string contactno { get; set; }
    public string email { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public DateTime date { get; set; }
    public string GSTNo { get; set; }
    public string DType { get; set; }
    public string contactperson { get; set; }
    public string designation { get; set; }
    public string deliveryaddress { get; set; }
    public string zipcode { get; set; }
    public int status { get; set; }
    public int extra { get; set; }
    public int oemid { get; set; }
    public bool HasValue { get; set; }
}
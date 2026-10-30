using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PinCodeData
/// </summary>
public class PinCodeData
{
    public PinCodeData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public PinCodeData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from pincode where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                cityid = int.Parse(ds.Tables[0].Rows[0]["cityid"].ToString());
                pincode = int.Parse(ds.Tables[0].Rows[0]["pincode"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
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
        param.Add(new MySqlParameter("@pincode", pincode));
        param.Add(new MySqlParameter("@cityid", cityid));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE pincode SET cityid=@cityid,pincode=@pincode WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@pincode", pincode));
        param.Add(new MySqlParameter("@cityid", cityid));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO pincode(pincode,cityid) VALUES(@pincode,@cityid)", param);
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
    public int pincode { get; set; }
    public int cityid { get; set; }
    public int status { get; set; }
    public bool HasValue { get; set; }
}
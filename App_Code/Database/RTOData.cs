using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RTOData
/// </summary>
public class RTOData
{
    public RTOData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public RTOData(int ids)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        using (DataSet ds = connect.GetDataset("select * from rto where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                username = ds.Tables[0].Rows[0]["username"].ToString();
                passwords = ds.Tables[0].Rows[0]["passwords"].ToString();
                rtocode = (ds.Tables[0].Rows[0]["rtocode"].ToString());
                city = ds.Tables[0].Rows[0]["city"].ToString();
                state = ds.Tables[0].Rows[0]["state"].ToString();
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
    public RTOData(string usernames)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@username", usernames));
        using (DataSet ds = connect.GetDataset("select * from rto where username=@username", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                username = ds.Tables[0].Rows[0]["username"].ToString();
                passwords = ds.Tables[0].Rows[0]["passwords"].ToString();
                rtocode = (ds.Tables[0].Rows[0]["rtocode"].ToString());
                city = ds.Tables[0].Rows[0]["city"].ToString();
                state = ds.Tables[0].Rows[0]["state"].ToString();
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
    public RTOData(string usernames, string password)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@username", usernames));
        param.Add(new MySqlParameter("@password", password));
        using (DataSet ds = connect.GetDataset("select * from rto where username=@username and passwords=@password", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                username = ds.Tables[0].Rows[0]["username"].ToString();
                passwords = ds.Tables[0].Rows[0]["passwords"].ToString();
                rtocode = (ds.Tables[0].Rows[0]["rtocode"].ToString());
                city = ds.Tables[0].Rows[0]["city"].ToString();
                state = ds.Tables[0].Rows[0]["state"].ToString();
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
    public void BlockUser(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 0));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE rto SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UnBlockUser(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 1));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE rto SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void updateadmin(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@username", username));
        param.Add(new MySqlParameter("@passwords", passwords));
        param.Add(new MySqlParameter("@rtocode", rtocode));
        param.Add(new MySqlParameter("@state", state));
        param.Add(new MySqlParameter("@city", city));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE rto SET username=@username,passwords=@passwords,rtocode=@rtocode,state=@state,city=@city WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@username", username));
        param.Add(new MySqlParameter("@passwords", passwords));
        param.Add(new MySqlParameter("@rtocode", rtocode));
        param.Add(new MySqlParameter("@state", state));
        param.Add(new MySqlParameter("@city", city));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO rto(username,passwords,rtocode,state,city) VALUES(@username,@passwords,@rtocode,@state,@city)", param);
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
    public string username { get; set; }
    public string passwords { get; set; }
    public string rtocode { get; set; }
    public string state { get; set; }
    public string city { get; set; }
    public int status { get; set; }
    public bool HasValue { get; set; }
}
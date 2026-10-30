using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminLoginData
/// </summary>
public class AdminLoginData
{
    public AdminLoginData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public AdminLoginData(int ids)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        using (DataSet ds = connect.GetDataset("select * from adminlogin where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                username = ds.Tables[0].Rows[0]["username"].ToString();
                pass = ds.Tables[0].Rows[0]["pass"].ToString();
                role = ds.Tables[0].Rows[0]["role"].ToString();
                date = ds.Tables[0].Rows[0]["date"].ToString();
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
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
    public AdminLoginData(string username, string password)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@username", username));
        param.Add(new MySqlParameter("@pass", password));
        using (DataSet ds = connect.GetDataset("select * from adminlogin where username=@username and pass=@pass", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                username = ds.Tables[0].Rows[0]["username"].ToString();
                pass = ds.Tables[0].Rows[0]["pass"].ToString();
                role = ds.Tables[0].Rows[0]["role"].ToString();
                date = ds.Tables[0].Rows[0]["date"].ToString();
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
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
    public AdminLoginData(string username)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@username", username));
        using (DataSet ds = connect.GetDataset("select * from adminlogin where username=@username", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                username = ds.Tables[0].Rows[0]["username"].ToString();
                pass = ds.Tables[0].Rows[0]["pass"].ToString();
                role = ds.Tables[0].Rows[0]["role"].ToString();
                date = ds.Tables[0].Rows[0]["date"].ToString();
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
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
    public void updatePass(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@pass", pass));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE adminlogin SET pass=@pass where id="+ids, param);
        connect.Dispose();
        connect = null;

    }
    public void updateRole(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@role", role));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE adminlogin SET role=@role where id=" + ids, param);
        connect.Dispose();
        connect = null;

    }
    public void update(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@role", role));
        param.Add(new MySqlParameter("@username", username));
        param.Add(new MySqlParameter("@pass", pass));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE adminlogin SET role=@role,username=@username,pass=@pass where id=" + ids, param);
        connect.Dispose();
        connect = null;

    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@username", username));
        param.Add(new MySqlParameter("@pass", pass));
        param.Add(new MySqlParameter("@role", role));
        param.Add(new MySqlParameter("@date", date));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO adminlogin(username,pass,role,date) VALUES(@username,@pass,@role,@date)", param);
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
    public DataSet getDetails(String query, List<MySqlParameter> param)
    {
        Connection connect = new Connection();
        DataSet ds = connect.GetDataset(query, param);
        return ds;
    }
    public int id { get; set; }
    public int status { get; set; }
    public string username { get; set; }
    public string pass { get; set; }
    public string role { get; set; }
    public string date { get; set; }
    public bool HasValue { get; set; }
}
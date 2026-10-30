using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AccountData
/// </summary>
public class AccountData
{
    public AccountData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public AccountData(int ids)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        using (DataSet ds = connect.GetDataset("select * from account where id=@id and status=1", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                name = (ds.Tables[0].Rows[0]["name"].ToString());
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
    public AccountData(string names)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@name", names));
        using (DataSet ds = connect.GetDataset("select * from account where name=@name  and status=1", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                name = (ds.Tables[0].Rows[0]["name"].ToString());
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
        param.Add(new MySqlParameter("@name", name));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE account SET name=@name WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void Block(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE account SET status=0 WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UnBlock(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE account SET status=1 WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@name", name));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO account(name) VALUES(@name)", param);
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
    // public int rateid { get; set; }
    public int status { get; set; }
    public bool HasValue { get; set; }
}
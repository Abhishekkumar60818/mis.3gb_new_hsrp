using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityDetails
/// </summary>
public class CityDetails
{
    public CityDetails()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public CityDetails(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from city where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
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
    public CityDetails(string citys,string states)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@city", citys));
        param.Add(new MySqlParameter("@state", states));
        using (DataSet ds = connect.GetDataset("select * from city where city=@city and state=@state", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
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
    public void update(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@city", city));
        param.Add(new MySqlParameter("@state", state));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE city SET city=@city,state=@state WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@city", city));
        param.Add(new MySqlParameter("@state", state));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO city(city,state) VALUES(@city,@state)", param);
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
    public string city { get; set; }
    public string state { get; set; }
    public int status { get; set; }
    public bool HasValue { get; set; }
}
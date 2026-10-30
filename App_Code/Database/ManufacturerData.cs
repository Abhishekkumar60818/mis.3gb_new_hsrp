using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ManufacturerData
/// </summary>
public class ManufacturerData
{
    public ManufacturerData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public ManufacturerData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from manufacturer where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                manufacture = ds.Tables[0].Rows[0]["manufacture"].ToString();
                vtype = ds.Tables[0].Rows[0]["vtype"].ToString();
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
    public ManufacturerData(string manufactures, string vtypes)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@manufacture", manufactures));
        param.Add(new MySqlParameter("@vtype", vtypes));
        using (DataSet ds = connect.GetDataset("select * from manufacturer where manufacture=@manufacture and vtype=@vtype", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                manufacture = ds.Tables[0].Rows[0]["manufacture"].ToString();
                vtype = ds.Tables[0].Rows[0]["vtype"].ToString();
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
        param.Add(new MySqlParameter("@manufacture", manufacture));
        param.Add(new MySqlParameter("@vtype", vtype));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE manufacturer SET manufacture=@manufacture,vtype=@vtype WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@manufacture", manufacture));
        param.Add(new MySqlParameter("@vtype", vtype));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO manufacturer(manufacture,vtype) VALUES(@manufacture,@vtype)", param);
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
    public string manufacture { get; set; }
    public string vtype { get; set; }
    public int status { get; set; }
    public bool HasValue { get; set; }
}
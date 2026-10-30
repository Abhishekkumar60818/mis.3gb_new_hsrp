using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for RateOnlineReplacementData
/// </summary>
public class RateOnlineReplacementData
{
    public RateOnlineReplacementData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public RateOnlineReplacementData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from rateonlinereplacement where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                cate = ds.Tables[0].Rows[0]["cate"].ToString();
                amount = double.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
                state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                gst = double.Parse(ds.Tables[0].Rows[0]["gst"].ToString());
                netamount = double.Parse(ds.Tables[0].Rows[0]["netamount"].ToString());
                otype = ds.Tables[0].Rows[0]["otype"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public RateOnlineReplacementData(string cate1, int states,string ordertype)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@cate", cate1));
        param.Add(new MySqlParameter("@state", states));
        param.Add(new MySqlParameter("@otype", ordertype));
        using (DataSet ds = connect.GetDataset("select * from rateonlinereplacement where cate=@cate and state=@state and otype=@otype and status=1", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                cate = ds.Tables[0].Rows[0]["cate"].ToString();
                otype = ds.Tables[0].Rows[0]["otype"].ToString();
                amount = double.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
                state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                gst = double.Parse(ds.Tables[0].Rows[0]["gst"].ToString());
                netamount = double.Parse(ds.Tables[0].Rows[0]["netamount"].ToString());
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
        param.Add(new MySqlParameter("@cate", cate));
        param.Add(new MySqlParameter("@amount", amount));
        param.Add(new MySqlParameter("@state", state));
        param.Add(new MySqlParameter("@gst", gst));
        param.Add(new MySqlParameter("@netamount", netamount));
        param.Add(new MySqlParameter("@otype", otype));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE rateonlinereplacement SET cate=@cate,amount=@amount,state=@state,gst=@gst,netamount=@netamount,otype=@otype WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void Block(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 0));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE rateonlinereplacement SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UnBlock(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 1));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE rateonlinereplacement SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@cate", cate));
        param.Add(new MySqlParameter("@amount", amount));
        param.Add(new MySqlParameter("@state", state));
        param.Add(new MySqlParameter("@gst", gst));
        param.Add(new MySqlParameter("@netamount", netamount));
        param.Add(new MySqlParameter("@otype", otype));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO rateonlinereplacement(cate,amount,state,gst,netamount,otype) VALUES(@cate,@amount,@state,@gst,@netamount,@otype)", param);
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
    public string cate { get; set; }
    public string otype { get; set; }
    public double amount { get; set; }
    public int state { get; set; }
    public double gst { get; set; }
    public double netamount { get; set; }
    public bool HasValue { get; set; }
}
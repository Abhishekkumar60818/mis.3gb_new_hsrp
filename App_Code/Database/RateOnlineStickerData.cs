using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for RateOnlineStickerData
/// </summary>
public class RateOnlineStickerData
{
    public RateOnlineStickerData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public RateOnlineStickerData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from rateonlinesticker where id=@id", param))
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
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public RateOnlineStickerData(string cate1, int states)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@cate", cate1));
        param.Add(new MySqlParameter("@state", states));
        using (DataSet ds = connect.GetDataset("select * from rateonlinesticker where cate=@cate and state=@state and status=1", param))
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
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE rateonlinesticker SET cate=@cate,amount=@amount,state=@state,gst=@gst,netamount=@netamount WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void Block(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 0));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE rateonlinesticker SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UnBlock(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 1));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE rateonlinesticker SET status=@status WHERE id=@id", param);
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
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO rateonlinesticker(cate,amount,state,gst,netamount) VALUES(@cate,@amount,@state,@gst,@netamount)", param);
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
    public double amount { get; set; }
    public int state { get; set; }
    public double gst { get; set; }
    public double netamount { get; set; }
    public bool HasValue { get; set; }
}
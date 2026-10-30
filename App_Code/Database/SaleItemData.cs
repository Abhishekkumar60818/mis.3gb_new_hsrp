using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SaleItemData
/// </summary>
public class SaleItemData
{
    public SaleItemData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public SaleItemData(int ids)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        using (DataSet ds = connect.GetDataset("select * from salesitem where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                hid = int.Parse(ds.Tables[0].Rows[0]["hid"].ToString());
                sid = int.Parse(ds.Tables[0].Rows[0]["sid"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                sstatus = int.Parse(ds.Tables[0].Rows[0]["sstatus"].ToString());
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public SaleItemData(int ids,int aa)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@sid", ids));
        using (DataSet ds = connect.GetDataset("select * from salesitem where sid=@sid", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                hid = int.Parse(ds.Tables[0].Rows[0]["hid"].ToString());
                sid = int.Parse(ds.Tables[0].Rows[0]["sid"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                sstatus = int.Parse(ds.Tables[0].Rows[0]["sstatus"].ToString());
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public void updatestatus(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", status));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE salesitem SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void updateSold(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@sstatus", sstatus));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE salesitem SET sstatus=@sstatus WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@sid", sid));
        param.Add(new MySqlParameter("@hid", hid));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO salesitem(hid,sid) VALUES(@hid,@sid)", param);
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
    public int hid { get; set; }
    public int sid { get; set; }
    public int status { get; set; }
    public int sstatus { get; set; }
    public bool HasValue { get; set; }
}
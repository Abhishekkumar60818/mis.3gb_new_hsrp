using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StockData
/// </summary>
public class StockData
{
    public StockData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public StockData(int ids)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        using (DataSet ds = connect.GetDataset("select * from stock where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
              //  rateid = int.Parse(ds.Tables[0].Rows[0]["rateid"].ToString());
                laserno = ds.Tables[0].Rows[0]["laserno"].ToString();
                date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                sstatus = int.Parse(ds.Tables[0].Rows[0]["sstatus"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                sizeid = int.Parse(ds.Tables[0].Rows[0]["sizeid"].ToString());
                classid = int.Parse(ds.Tables[0].Rows[0]["classid"].ToString());
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public StockData(int ids,int ads)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        using (DataSet ds = connect.GetDataset("select * from stock  order by id desc limit 1"))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                //  rateid = int.Parse(ds.Tables[0].Rows[0]["rateid"].ToString());
                laserno = ds.Tables[0].Rows[0]["laserno"].ToString();
                date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                sstatus = int.Parse(ds.Tables[0].Rows[0]["sstatus"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                sizeid = int.Parse(ds.Tables[0].Rows[0]["sizeid"].ToString());
                classid = int.Parse(ds.Tables[0].Rows[0]["classid"].ToString());
            }
            else
            {
                id = 0;
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public StockData(string laserNos)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@laserno", laserNos));
        using (DataSet ds = connect.GetDataset("select * from stock where laserno=@laserno", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
               // rateid =int.Parse( ds.Tables[0].Rows[0]["rateid"].ToString());
                laserno = ds.Tables[0].Rows[0]["laserno"].ToString();
                date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                sstatus = int.Parse(ds.Tables[0].Rows[0]["sstatus"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                sizeid = int.Parse(ds.Tables[0].Rows[0]["sizeid"].ToString());
                classid = int.Parse(ds.Tables[0].Rows[0]["classid"].ToString());
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public void SoldOut(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@sstatus", 1));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE stock SET sstatus=@sstatus WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void Block(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 0));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE stock SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UnBlock(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 1));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE stock SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void updateadmin(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
      //  param.Add(new MySqlParameter("@rateid", rateid));
        param.Add(new MySqlParameter("@date", date));
        param.Add(new MySqlParameter("@laserno", laserno));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE stock SET date=@date,laserno=@laserno WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void update(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@sizeid", sizeid));
        param.Add(new MySqlParameter("@classid", classid));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE stock SET classid=@classid,sizeid=@sizeid WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
      //  param.Add(new MySqlParameter("@rateid", rateid));
        param.Add(new MySqlParameter("@date", date));
        param.Add(new MySqlParameter("@laserno", laserno));
        param.Add(new MySqlParameter("@sizeid", sizeid));
        param.Add(new MySqlParameter("@classid", classid));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO stock(date,laserno,sizeid,classid) VALUES(@date,@laserno,@sizeid,@classid)", param);
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
    public DateTime date { get; set; }
    public int sstatus { get; set; }
   // public int rateid { get; set; }
    public int status { get; set; }
    public string laserno { get; set; }
    public int sizeid { get; set; }
    public int classid { get; set; }
    public bool HasValue { get; set; }
}
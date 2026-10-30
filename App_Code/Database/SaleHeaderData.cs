using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SaleHeaderData
/// </summary>
public class SaleHeaderData
{
    public SaleHeaderData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public SaleHeaderData(int ids)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        using (DataSet ds = connect.GetDataset("select * from saleheader where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                did = int.Parse(ds.Tables[0].Rows[0]["did"].ToString());
                qty = int.Parse(ds.Tables[0].Rows[0]["qty"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public SaleHeaderData(int dids, int qtys,DateTime dates)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@did", dids));
        param.Add(new MySqlParameter("@qty", qtys));
        param.Add(new MySqlParameter("@date", dates.ToString("yyyy-MM-dd")));
        using (DataSet ds = connect.GetDataset("select * from saleheader where did=@did and qty=@qty and date=@date and status=1", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                did = int.Parse(ds.Tables[0].Rows[0]["did"].ToString());
                qty = int.Parse(ds.Tables[0].Rows[0]["qty"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
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
        param.Add(new MySqlParameter("@did", did));
        param.Add(new MySqlParameter("@qty", qty));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE saleheader SET qty=@qty,did=@did WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public int Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@date", date));
        param.Add(new MySqlParameter("@did", did));
        param.Add(new MySqlParameter("@qty", qty));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO saleheader(did,qty,date) VALUES(@did,@qty,@date)", param);
        SaleHeaderData sd = new SaleHeaderData(did, qty, date);
        DataSet ds = connect.GetDataset("select (auto_increment-1) as lastId from information_schema.tables where table_name = 'saleheader' and table_schema = 'bookhsrp'");
       // DataSet ds = connect.GetDataset("select LAST_INSERT_ID()");
        connect.Dispose();
        connect = null;
        return sd.id;
    }
    public DataSet getDetails(String query)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        DataSet ds = connect.GetDataset(query);
        return ds;
    }
    public int id { get; set; }
    public int did { get; set; }
    public int qty { get; set; }
    public int status { get; set; }
    public DateTime date { get; set; }
    public bool HasValue { get; set; }
}
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RateChartData
/// </summary>
public class RateChartData
{
    public RateChartData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public RateChartData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from ratechart where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                ext = int.Parse(ds.Tables[0].Rows[0]["ext"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                manu_company = ds.Tables[0].Rows[0]["manu_company"].ToString();
                type = ds.Tables[0].Rows[0]["type"].ToString();
                sizeback = ds.Tables[0].Rows[0]["sizeback"].ToString();
                sizefront = ds.Tables[0].Rows[0]["sizefront"].ToString();
                vehicleclass = ds.Tables[0].Rows[0]["vehicleclass"].ToString();
                vehicletype = ds.Tables[0].Rows[0]["vehicletype"].ToString();
                rate = ds.Tables[0].Rows[0]["rate"].ToString();
                tax = ds.Tables[0].Rows[0]["tax"].ToString();
                other = ds.Tables[0].Rows[0]["other"].ToString();
                netamount = ds.Tables[0].Rows[0]["netamount"].ToString();
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
        param.Add(new MySqlParameter("@manu_company", manu_company));
        param.Add(new MySqlParameter("@type", type));
       // param.Add(new MySqlParameter("@sizefront", sizefront));
       // param.Add(new MySqlParameter("@sizeback", sizeback));
        param.Add(new MySqlParameter("@vehicleclass", vehicleclass));
        param.Add(new MySqlParameter("@vehicletype", vehicletype));
        param.Add(new MySqlParameter("@rate", rate));
        param.Add(new MySqlParameter("@tax", tax));
        param.Add(new MySqlParameter("@other", other));
        param.Add(new MySqlParameter("@netamount", netamount));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE ratechart SET manu_company=@manu_company,type=@type,vehicleclass=@vehicleclass,vehicletype=@vehicletype,rate=@rate,tax=@tax,other=@other,netamount=@netamount WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void Block(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 0));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE ratechart SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UnBlock(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 1));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE ratechart SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@manu_company", manu_company));
        param.Add(new MySqlParameter("@type", type));
        //param.Add(new MySqlParameter("@sizefront", sizefront));
        //param.Add(new MySqlParameter("@sizeback", sizeback));
        param.Add(new MySqlParameter("@vehicleclass", vehicleclass));
        param.Add(new MySqlParameter("@vehicletype", vehicletype));
        param.Add(new MySqlParameter("@rate", rate));
        param.Add(new MySqlParameter("@tax", tax));
        param.Add(new MySqlParameter("@other", other));
        param.Add(new MySqlParameter("@netamount", netamount));
        param.Add(new MySqlParameter("@ext", ext));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO ratechart(manu_company,type,vehicleclass,vehicletype,rate,tax,other,netamount,ext) VALUES(@manu_company,@type,@vehicleclass,@vehicletype,@rate,@tax,@other,@netamount,@ext)", param);
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
    public int ext { get; set; }
    public string manu_company { get; set; }
    public string type { get; set; }
    public string sizefront { get; set; }
    public string sizeback { get; set; }
    public string vehicleclass { get; set; }
    public string vehicletype { get; set; }
    public string rate { get; set; }
    public string tax { get; set; }
    public string other { get; set; }
    public string netamount { get; set; }
    public bool HasValue { get; set; }
}
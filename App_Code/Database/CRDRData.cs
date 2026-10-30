using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CRDRData
/// </summary>
public class CRDRData
{
    public CRDRData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public CRDRData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from crdr where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                cid = int.Parse(ds.Tables[0].Rows[0]["cid"].ToString());
                crid = int.Parse(ds.Tables[0].Rows[0]["crid"].ToString());
                drid = int.Parse(ds.Tables[0].Rows[0]["drid"].ToString());
                amount = double.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
                date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                narration = ds.Tables[0].Rows[0]["narration"].ToString();
                classs = ds.Tables[0].Rows[0]["classs"].ToString();

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
        param.Add(new MySqlParameter("@cid", cid));
        param.Add(new MySqlParameter("@crid", crid));
        param.Add(new MySqlParameter("@drid", drid));
        param.Add(new MySqlParameter("@amount", amount));
        //param.Add(new MySqlParameter("@date", date));
        param.Add(new MySqlParameter("@narration", narration));
        param.Add(new MySqlParameter("@classs", classs));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE crdr SET cid=@cid,crid=@crid,drid=@drid,amount=@amount,narration=@narration,classs=@classs WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@cid", cid));
        param.Add(new MySqlParameter("@crid", crid));
        param.Add(new MySqlParameter("@drid", drid));
        param.Add(new MySqlParameter("@amount", amount));
        param.Add(new MySqlParameter("@date", date));
        param.Add(new MySqlParameter("@narration", narration));
        param.Add(new MySqlParameter("@classs", classs));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO crdr(cid,crid,drid,amount,date,narration,classs) VALUES(@cid,@crid,@drid,@amount,@date,@narration,@classs)", param);
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
    public int cid { get; set; }
    public int crid { get; set; }
    public int drid { get; set; }
    public int status { get; set; }
    public double amount { get; set; }
    public DateTime date { get; set; }
    public string narration { get; set; }
    public string classs { get; set; }
    public bool HasValue { get; set; }
}
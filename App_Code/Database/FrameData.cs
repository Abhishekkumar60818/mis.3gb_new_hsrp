using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FrameData
/// </summary>
public class FrameData
{
    public FrameData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public FrameData(int ids)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        using (DataSet ds = connect.GetDataset("select * from frames where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                vid = (ds.Tables[0].Rows[0]["vid"].ToString());
                amount = double.Parse(ds.Tables[0].Rows[0]["amount"].ToString());

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
    public FrameData(string vids)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@vid", vids));
        using (DataSet ds = connect.GetDataset("select * from frames where vid=@vid and status=1", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                vid = (ds.Tables[0].Rows[0]["vid"].ToString());
                amount = double.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
                
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

    public void BlockUser(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 0));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE frames SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UnBlockUser(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 1));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE frames SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void update(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@amount", amount));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE frames SET amount=@amount WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@vid", vid));
        param.Add(new MySqlParameter("@amount", amount));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO frames(vid,amount) VALUES(@vid,@amount)", param);
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
    public string vid { get; set; }
    public double amount { get; set; }
    public int status { get; set; }
    public bool HasValue { get; set; }
}
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateDetails
/// </summary>
public class StateDetails
{
    public StateDetails()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public StateDetails(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from state where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                name = ds.Tables[0].Rows[0]["name"].ToString();
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                Courier_Charge = int.Parse(ds.Tables[0].Rows[0]["Courier_Charge"].ToString());
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public StateDetails(string sName)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@name", sName));
        using (DataSet ds = connect.GetDataset("select * from state where name=@name", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                name = ds.Tables[0].Rows[0]["name"].ToString();
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                Courier_Charge = int.Parse(ds.Tables[0].Rows[0]["Courier_Charge"].ToString());
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
        param.Add(new MySqlParameter("@name", name));
        param.Add(new MySqlParameter("@Courier_Charge", Courier_Charge));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE state SET name=@name,Courier_Charge=@Courier_Charge WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@name", name));
        param.Add(new MySqlParameter("@Courier_Charge", Courier_Charge));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO state(name,Courier_Charge) VALUES(@name,@Courier_Charge)", param);
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
    public int Courier_Charge { get; set; }
    public string name { get; set; }
    public int status { get; set; }

    public bool HasValue { get; set; }
}
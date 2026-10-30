using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EnquiryData
/// </summary>
public class EnquiryData
{
    public EnquiryData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public EnquiryData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from enquery where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                name = ds.Tables[0].Rows[0]["name"].ToString();
                mobileno = ds.Tables[0].Rows[0]["mobileno"].ToString();
                email = ds.Tables[0].Rows[0]["email"].ToString();
                message = ds.Tables[0].Rows[0]["message"].ToString();
                state = ds.Tables[0].Rows[0]["state"].ToString();
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
  
    public void Save()
    {
        var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@name", name));
        param.Add(new MySqlParameter("@mobileno", mobileno));
        param.Add(new MySqlParameter("@email", email));
        param.Add(new MySqlParameter("@message", message));
        param.Add(new MySqlParameter("@date", now));
        
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO enquery(name,mobileno,email,message,date) VALUES(@name,@mobileno,@email,@message,@date)", param);
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
    public string name { get; set; }
    public string mobileno { get; set; }
    public string email { get; set; }
    public string message { get; set; }
    public string state { get; set; }
    public DateTime date { get; set; }
    public int status { get; set; }
    public bool HasValue { get; set; }
}
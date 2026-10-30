using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BankDetails
/// </summary>
public class BankDetails
{
    public BankDetails()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public BankDetails(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from bankdetails where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                did = int.Parse(ds.Tables[0].Rows[0]["did"].ToString());
                anane = ds.Tables[0].Rows[0]["anane"].ToString();
                ano = ds.Tables[0].Rows[0]["ano"].ToString();
                bname = ds.Tables[0].Rows[0]["bname"].ToString();
                ifsc = ds.Tables[0].Rows[0]["ifsc"].ToString();
                branchcode = ds.Tables[0].Rows[0]["branchcode"].ToString();
                branchname = ds.Tables[0].Rows[0]["branchname"].ToString();
                atype = ds.Tables[0].Rows[0]["atype"].ToString();
                panno = ds.Tables[0].Rows[0]["panno"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public BankDetails(int ids,string searchbudealer)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@did", ids));
        using (DataSet ds = connect.GetDataset("select * from bankdetails where did=@did and status=1", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                did = int.Parse(ds.Tables[0].Rows[0]["did"].ToString());
                anane = ds.Tables[0].Rows[0]["anane"].ToString();
                ano = ds.Tables[0].Rows[0]["ano"].ToString();
                bname = ds.Tables[0].Rows[0]["bname"].ToString();
                ifsc = ds.Tables[0].Rows[0]["ifsc"].ToString();
                branchcode = ds.Tables[0].Rows[0]["branchcode"].ToString();
                branchname = ds.Tables[0].Rows[0]["branchname"].ToString();
                atype = ds.Tables[0].Rows[0]["atype"].ToString();
                panno = ds.Tables[0].Rows[0]["panno"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public BankDetails(string sName)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@name", sName));
        using (DataSet ds = connect.GetDataset("select * from bankdetails where name=@name", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                did = int.Parse(ds.Tables[0].Rows[0]["did"].ToString());
                anane = ds.Tables[0].Rows[0]["anane"].ToString();
                ano = ds.Tables[0].Rows[0]["ano"].ToString();
                bname = ds.Tables[0].Rows[0]["bname"].ToString();
                ifsc = ds.Tables[0].Rows[0]["ifsc"].ToString();
                branchcode = ds.Tables[0].Rows[0]["branchcode"].ToString();
                branchname = ds.Tables[0].Rows[0]["branchname"].ToString();
                atype = ds.Tables[0].Rows[0]["atype"].ToString();
                panno = ds.Tables[0].Rows[0]["panno"].ToString();
                
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
        param.Add(new MySqlParameter("@anane", anane));
        param.Add(new MySqlParameter("@ano", ano));
        param.Add(new MySqlParameter("@bname", bname));
        param.Add(new MySqlParameter("@ifsc", ifsc));
        param.Add(new MySqlParameter("@branchcode", branchcode));
        param.Add(new MySqlParameter("@branchname", branchname));
        param.Add(new MySqlParameter("@atype", atype));
        param.Add(new MySqlParameter("@panno", panno));
       // param.Add(new MySqlParameter("@did", did));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE bankdetails SET anane=@anane,ano=@ano,bname=@bname,ifsc=@ifsc,branchcode=@branchcode,branchname=@branchname,atype=@atype,panno=@panno WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@anane", anane));
        param.Add(new MySqlParameter("@ano", ano));
        param.Add(new MySqlParameter("@bname", bname));
        param.Add(new MySqlParameter("@ifsc", ifsc));
        param.Add(new MySqlParameter("@branchcode", branchcode));
        param.Add(new MySqlParameter("@branchname", branchname));
        param.Add(new MySqlParameter("@atype", atype));
        param.Add(new MySqlParameter("@panno", panno));
        param.Add(new MySqlParameter("@did", did));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO bankdetails(anane,ano,bname,ifsc,branchcode,branchname,atype,panno,did) VALUES(@anane,@ano,@bname,@ifsc,@branchcode,@branchname,@atype,@panno,@did)", param);
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
    public int did { get; set; }
    public int ext { get; set; }
    public string anane { get; set; }
    public string ano { get; set; }
    public string bname { get; set; }
    public string ifsc { get; set; }
    public string branchcode { get; set; }
    public string branchname { get; set; }
    public string atype { get; set; }
    public string panno { get; set; }

    public bool HasValue { get; set; }
}
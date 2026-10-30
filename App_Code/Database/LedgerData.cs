using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LedgerData
/// </summary>
public class LedgerData
{
    public LedgerData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public LedgerData(int ids)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        using (DataSet ds = connect.GetDataset("select * from ledger where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                did = int.Parse(ds.Tables[0].Rows[0]["did"].ToString());
                approval = int.Parse(ds.Tables[0].Rows[0]["approval"].ToString());
                mode = ds.Tables[0].Rows[0]["mode"].ToString();
                ptype = ds.Tables[0].Rows[0]["ptype"].ToString();
                remark = ds.Tables[0].Rows[0]["remark"].ToString();
                transactionno = ds.Tables[0].Rows[0]["transactionno"].ToString();
                amount = double.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
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
    public LedgerData(int ids,string dd)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@did", ids));
        param.Add(new MySqlParameter("@date", dd));
        using (DataSet ds = connect.GetDataset("select * from ledger where did=@did and date=@date and mode ='Online By Payment Gateway' order by id desc limit 1", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                did = int.Parse(ds.Tables[0].Rows[0]["did"].ToString());
                approval = int.Parse(ds.Tables[0].Rows[0]["approval"].ToString());
                mode = ds.Tables[0].Rows[0]["mode"].ToString();
                ptype = ds.Tables[0].Rows[0]["ptype"].ToString();
                remark = ds.Tables[0].Rows[0]["remark"].ToString();
                transactionno = ds.Tables[0].Rows[0]["transactionno"].ToString();
                amount = double.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
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
    public void Approve(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@approval", 1));
        param.Add(new MySqlParameter("@remark", remark));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE ledger SET approval=@approval,remark=@remark WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void ApprovePending(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@remark", remark));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE ledger SET remark=@remark WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void Cancel(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 0));
        param.Add(new MySqlParameter("@remark", remark));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE ledger SET status=@status,remark=@remark WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void Block(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 0));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE ledger SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UnBlock(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@status", 1));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE ledger SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void update(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@did", did));
        param.Add(new MySqlParameter("@amount", amount));
        param.Add(new MySqlParameter("@mode", mode));
        param.Add(new MySqlParameter("@ptype", ptype));
        param.Add(new MySqlParameter("@date", date));
        param.Add(new MySqlParameter("@approval", approval));
        param.Add(new MySqlParameter("@transactionno", transactionno));
        param.Add(new MySqlParameter("@remark", remark));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE ledger SET did=@did,amount=@amount,mode=@mode,ptype=@ptype,date=@date,approval=@approval,transactionno=@transactionno,remark=@remark WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@did", did));
        param.Add(new MySqlParameter("@amount", amount));
        param.Add(new MySqlParameter("@mode", mode));
        param.Add(new MySqlParameter("@ptype", ptype));
        param.Add(new MySqlParameter("@date", date));
        param.Add(new MySqlParameter("@approval", approval));
        param.Add(new MySqlParameter("@transactionno", transactionno));
        param.Add(new MySqlParameter("@remark", remark));
        param.Add(new MySqlParameter("@photo", photo));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO ledger(did,amount,mode,ptype,date,approval,transactionno,remark,photo) VALUES(@did,@amount,@mode,@ptype,@date,@approval,@transactionno,@remark,@photo)", param);
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
    public int did { get; set; }
    public int approval { get; set; }
    public int status { get; set; }
    public double amount { get; set; }
    public DateTime date { get; set; }
    public string mode { get; set; }
    public string ptype { get; set; }
    public string remark { get; set; }
    public string transactionno { get; set; }
    public string photo { get; set; }
    public bool HasValue { get; set; }
}
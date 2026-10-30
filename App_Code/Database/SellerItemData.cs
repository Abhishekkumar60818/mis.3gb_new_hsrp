using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SellerItemData
/// </summary>
public class SellerItemData
{
    public SellerItemData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public SellerItemData(int ids)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        using (DataSet ds = connect.GetDataset("select * from selleritem where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                headerid = int.Parse(ds.Tables[0].Rows[0]["headerid"].ToString());
                itemid = int.Parse(ds.Tables[0].Rows[0]["itemid"].ToString());
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public SellerItemData(int ids,int ip)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@headerid", ids));
        using (DataSet ds = connect.GetDataset("select * from selleritem where headerid=@headerid", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                headerid = int.Parse(ds.Tables[0].Rows[0]["headerid"].ToString());
                itemid = int.Parse(ds.Tables[0].Rows[0]["itemid"].ToString());
                if(ds.Tables[0].Rows.Count>1)
                {
                    itemid2= int.Parse(ds.Tables[0].Rows[1]["itemid"].ToString());
                }
                else
                {
                    itemid2 = 0;
                }
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
        param.Add(new MySqlParameter("@headerid", headerid));
        param.Add(new MySqlParameter("@itemid", itemid));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE selleritem SET itemid=@itemid,headerid=@headerid WHERE id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        //  param.Add(new MySqlParameter("@rateid", rateid));
        param.Add(new MySqlParameter("@headerid", headerid));
        param.Add(new MySqlParameter("@itemid", itemid));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO selleritem(headerid,itemid) VALUES(@headerid,@itemid)", param);
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
    public int headerid { get; set; }
     public int itemid2 { get; set; }
    public int itemid { get; set; }
    public bool HasValue { get; set; }
}
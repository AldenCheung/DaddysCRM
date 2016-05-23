using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaddysCRM.Model;

namespace DaddysCRM.DAL
{
    public class PurchaseRecordDAL
    {
        protected String dbstr = System.Configuration.ConfigurationSettings.AppSettings["connectionstring"];
        //按年份查询
        public DataSet Query(int year,int cusID)
        {
            OleDbConnection connection = new OleDbConnection(dbstr);

            connection.Open();

            String sqlstr = string.Format(@"select a.*,b.CustomerName,b.Telephone,b.Address from 购买记录 a 
left join 通讯录 b on a.CustomerID=b.ID  where 1=1");
            if (year>0)
            {
                sqlstr += string.Format(@" and BuyYear={0}", year);
            }
            if(cusID>0)
            {
                sqlstr += string.Format(@" and CustomerID={0}",cusID);
            }
            OleDbCommand command = new OleDbCommand(sqlstr, connection);
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = command;
            DataSet ds = new DataSet();
            adp.Fill(ds, "购买记录");

            return ds;
        }

        public void Save(PurchaseRecord entity)
        {
            OleDbConnection connection = new OleDbConnection(dbstr);

            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.CommandText = string.Format(@"insert into 购买记录 (Goods,[Count],Price,BuyYear,BuyDate,CustomerId,GoodsID,
            
            PayStatus,TotalPrice) values('{0}',{1},{2},{3},?,{4},{5},{6},{7})", entity.Goods, entity.Count, entity.Price, entity.BuyYear,
           entity.CustomerID,entity.GoodsID,entity.PayStatus,entity.TotalPrice);

            OleDbParameter param = new OleDbParameter("?", OleDbType.DBDate);
            param.Value = entity.BuyDate;
            command.Parameters.Add(param);
         
            command.Connection = connection;
            command.ExecuteNonQuery();

            connection.Close();

        }
    }
}

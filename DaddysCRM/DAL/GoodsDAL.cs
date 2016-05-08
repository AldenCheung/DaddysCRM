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
    public class GoodsDAL
    {
        protected String dbstr = System.Configuration.ConfigurationSettings.AppSettings["connectionstring"];

        public void Save(Goods entity)
        {
            OleDbConnection connection = new OleDbConnection(dbstr);

            connection.Open();

            OleDbCommand command = new OleDbCommand();
            if (entity.ID > 0)
            {
                //更新
                command.CommandText = string.Format("update 商品 set GoodsName='{0}',Price={1},Unit='{2}',Remark='{3}' where ID={4} ", entity.GoodsName, entity.Price, entity.Unit,entity.Remark, entity.ID);
            }
            else
            {
                //插入
                command.CommandText = string.Format("insert into 商品 (GoodsName,Price,Unit,Remark) values('{0}','{1}','{2}','{3}')", entity.GoodsName, entity.Price, entity.Unit,entity.Remark);
            }
            command.Connection = connection;
            command.ExecuteNonQuery();

            connection.Close();

        }

        //按姓名模糊查询
        public DataSet Query(string Name)
        {
            OleDbConnection connection = new OleDbConnection(dbstr);

            connection.Open();

            String sqlstr = string.Format(@"select ID, GoodsName,Price,Unit,Remark from 商品 where 1=1");
            if (!string.IsNullOrEmpty(Name))
            {
                sqlstr += string.Format(@" and GoodsName like '%{0}%'", Name);
            }
            OleDbCommand command = new OleDbCommand(sqlstr, connection);
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = command;
            DataSet ds = new DataSet();
            adp.Fill(ds, "商品");

            return ds;
        }
    }
}

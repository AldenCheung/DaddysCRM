using DaddysCRM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaddysCRM.DAL
{
    public class CustomerDAL
    {
        protected String dbstr = System.Configuration.ConfigurationSettings.AppSettings["connectionstring"];
       
        //根据主键精确查询
        public Customer Get(int id)
        {
            OleDbConnection connection = new OleDbConnection(dbstr);

            connection.Open();

            String sqlstr = string.Format(@"select ID, CustomerName,Telephone,Address from 通讯录 where 1=1");
            if (id > 0)
            {
                sqlstr += string.Format(@" and ID={0}", id);
            }
            OleDbParameter parameter = new OleDbParameter("?",OleDbType.Integer);
            
            OleDbCommand command = new OleDbCommand(sqlstr, connection);
            //command.Parameters.Add(parameter);
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = command;
            DataSet ds = new DataSet();
            int count = adp.Fill(ds, "通讯录");
            if (count > 0)
            {
                #region 转化dataset为对象
                Customer cus = new Customer();
                cus.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                cus.CustomerName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                cus.Telephone = ds.Tables[0].Rows[0]["Telephone"].ToString();
                cus.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                #endregion

                return cus;
            }

            return null;

        }

        public void Delete(int id)
        {
            OleDbConnection connection = new OleDbConnection(dbstr);

            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.CommandText = string.Format("delete from 通讯录 where ID={0}", id);
            command.Connection = connection;

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void Save(Customer entity)
        {
            OleDbConnection connection = new OleDbConnection(dbstr);

            connection.Open();

            OleDbCommand command = new OleDbCommand();
            if (entity.ID > 0)
            {
                //更新
                command.CommandText = string.Format("update 通讯录 set CustomerName='{0}',Telephone='{1}',Address='{2}' where ID={3} ", entity.CustomerName, entity.Telephone, entity.Address, entity.ID);
            }
            else
            {
                //插入
                command.CommandText = string.Format("insert into 通讯录 (CustomerName,Telephone,Address,CreateTime) values('{0}','{1}','{2}',?)", entity.CustomerName, entity.Telephone, entity.Address);
                
                OleDbParameter param = new OleDbParameter("?",OleDbType.DBDate);
                param.Value = DateTime.Now;
                command.Parameters.Add(param);
            }
            command.Connection = connection;
            command.ExecuteNonQuery();

            connection.Close();

        }

        //按姓名模糊查询
        public DataSet Query(string cusName)
        {
            OleDbConnection connection = new OleDbConnection(dbstr);

            connection.Open();

            String sqlstr = string.Format(@"select ID, CustomerName,Telephone,Address from 通讯录 where 1=1");
            if (!string.IsNullOrEmpty(cusName))
            {
                sqlstr += string.Format(@" and CustomerName like '%{0}%'", cusName);
            }
            OleDbCommand command = new OleDbCommand(sqlstr, connection);
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = command;
            DataSet ds = new DataSet();
            adp.Fill(ds, "通讯录");

            return ds;
        }
    }
}

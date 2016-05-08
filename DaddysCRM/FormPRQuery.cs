using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DaddysCRM.DAL;

namespace WindowsFormsApplication1
{
    public partial class FormPRQuery : Form
    {
        PurchaseRecordDAL _purchaseDAL = new PurchaseRecordDAL();
        CustomerDAL _customerDAL = new CustomerDAL();
        public FormPRQuery()
        {
            InitializeComponent();
        }
        public FormPRQuery(int Year,int cusID)
        {
            InitializeComponent();
            LoadData(Year, cusID);
        }

        private void LoadData(int cusID,int Year=0)
        {
            if (cusID > 0)
            {
                this.labelname.Text= _customerDAL.Get(cusID).CustomerName;
                this.labeltel.Text = _customerDAL.Get(cusID).Telephone;
                this.labeladdress.Text = _customerDAL.Get(cusID).Address;
                
                if (Year == 0)
                {
                    Year = DateTime.Now.Year;
                }

                DataSet ds=_purchaseDAL.Query(Year,cusID);
                ds.Tables[0].Columns.Add("PayStatusName", typeof(System.String));
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["PayStatus"] != DBNull.Value)
                    {
                        if (Convert.ToInt32(dr["PayStatus"]) == 0)
                            dr["PayStatusName"] = "赊账";
                        else
                            if (Convert.ToInt32(dr["PayStatus"]) == 1)
                                dr["PayStatusName"] = "已结清";
                    }
                    else
                    {
                        dr["PayStatusName"] = string.Empty;
                    }
                }
                this.bindingSource1.DataSource =ds.Tables[0] ;
            }
        }
    }
}

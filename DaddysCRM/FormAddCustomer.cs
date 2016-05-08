using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DaddysCRM.DAL;
using DaddysCRM.Model;

namespace WindowsFormsApplication1
{
    public partial class FormAddCustomer : Form
    {
        public int cusID = 0;
        public Customer customer;
 
        public delegate void ReFreshDelegate();
        public FormCustomerManager form1;

        public FormAddCustomer()
        {
            InitializeComponent();
        }

        public FormAddCustomer(FormCustomerManager form)
        {
            InitializeComponent();
            form1 = form;
        }

        public FormAddCustomer(int id,FormCustomerManager form)
        {
            InitializeComponent();
            LoadData(id);
            this.button1.Text = "保存";
            this.Text = "修改客户";
            form1 = form;
        }
        
        //重载构造函数
        public FormAddCustomer(int id)
        {
            InitializeComponent();
            LoadData(id);
            this.button1.Text = "保存";
            this.Text = "修改客户";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Customer cus = null;
                if (!string.IsNullOrEmpty(this.txtID.Text))
                {
                    cus = new CustomerDAL().Get(Convert.ToInt32(this.txtID.Text));
                }
                else
                {
                    cus = new Customer();
                }
                cus.CustomerName = this.txtName.Text;
                cus.Telephone = this.txtTelephone.Text;
                cus.Address = this.txtAddress.Text;       
                                 
                new CustomerDAL().Save(cus);
                
                MessageBox.Show("保存成功");
                
                this.form1.LoadData();

                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadData(int id)
        {
            Customer cus = new CustomerDAL().Get(id);
            this.txtName.Text = cus.CustomerName;
            this.txtTelephone.Text = cus.Telephone;
            this.txtID.Text = cus.ID.ToString();
            this.txtAddress.Text = cus.Address;
        }
        
        
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormAddCustomer_Load(object sender, EventArgs e)
        {

        }


    }
}

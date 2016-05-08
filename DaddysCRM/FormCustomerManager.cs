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

namespace WindowsFormsApplication1
{
    public partial class FormCustomerManager : Form
    {
        CustomerDAL _customerDAL = new CustomerDAL();
        public FormCustomerManager()
        {
            InitializeComponent();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // InitializeComponent();
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAddCustomer form = new FormAddCustomer(this);

            form.Show();
        }

        public void LoadData()
        {
            DataSet ds = _customerDAL.Query(this.textBox1.Text);

            bindingSource1.DataSource = ds.Tables[0];

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedCusID = Convert.ToInt32(this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["ID"].Value);

            switch (e.ColumnIndex)
            {
                case 4: if (selectedCusID > 0)
                    {
                        FormAddCustomer fac = new FormAddCustomer(selectedCusID, this);
                        fac.cusID = selectedCusID;

                        fac.Show();
                    };
                    break;
                case 5: if (selectedCusID > 0)
                    {
                        FormAddPurchaseRecord far = new FormAddPurchaseRecord(selectedCusID);

                        far.Show();
                    };
                    break;
                case 1: FormPRQuery fpr = new FormPRQuery(selectedCusID, DateTime.Now.Year);
                    fpr.Show();
                    break;
            }
          
        }
        //删除客户
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int selectedCusID = Convert.ToInt32(this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells["ID"].Value);

                _customerDAL.Delete(selectedCusID);

                //MessageBox.Show("删除成功!","提示");

                LoadData();
            }
            else
            {
                return;
            }         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = string.Empty;
            LoadData();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

    }
}

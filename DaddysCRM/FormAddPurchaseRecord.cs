using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DaddysCRM.DAL;
using DaddysCRM.Model;

namespace WindowsFormsApplication1
{
    public partial class FormAddPurchaseRecord : Form
    {
        public int cusID = 0;
        CustomerDAL _customerDAL = new CustomerDAL();
        PurchaseRecordDAL _purchaseDAL = new PurchaseRecordDAL();
        FormCustomerManager form1;

        public FormAddPurchaseRecord()
        {
            InitializeComponent();
            this.txtGoods.ReadOnly = true;
        }

        public FormAddPurchaseRecord(int id)
        {
            InitializeComponent();
            this.txtGoods.ReadOnly = true;
            LoadCusInfo(id);
        }

        public FormAddPurchaseRecord(int id,FormCustomerManager form)
        {
            InitializeComponent();
            this.txtGoods.ReadOnly = true;
            LoadCusInfo(id);
            form1 = form;
        }

        public void LoadCusInfo(int id)
        {
            Customer cus = _customerDAL.Get(id);
            if (cus != null)
            {
                cusID = cus.ID;
                this.label2.Text = cus.CustomerName;
                this.label4.Text = cus.Telephone;
                this.label6.Text = cus.Address;
            }
        }

        private void FormAddPurchaseRecord_Load(object sender, EventArgs e)
        {

        }

        private void txtGoods_Click(object sender,EventArgs e)
        {
            FormGoodsManager goodsForm = new FormGoodsManager(this);
            
           
            goodsForm.Show();
        }

        public void LoadGoodsInfo(Goods goods)
        {
            this.txtGoods.Text = goods.GoodsName;
            this.txtPrice.Text = goods.Price.ToString();
            this.txtUnit.Text = goods.Unit;
            this.txtGoodsID.Text = goods.ID.ToString();
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtGoods.Text) 
                && this.cusID > 0
                && (this.radioButton1.Checked || this.radioButton2.Checked))
            {
                try
                {
                    PurchaseRecord pr = new PurchaseRecord();

                    pr.GoodsID = Convert.ToInt32(this.txtGoodsID.Text);

                    pr.BuyDate = Convert.ToDateTime(this.dateTimePicker1.Text);
                    pr.BuyYear = pr.BuyDate.Year;
                    pr.Count = Convert.ToDouble(this.txtCount.Text);
                    pr.CustomerID = this.cusID;
                    pr.Goods = this.txtGoods.Text;
                    pr.Price = Convert.ToDouble(this.txtPrice.Text);
                    pr.TotalPrice = Convert.ToDouble(this.txtTotalPrice.Text);

                    if (this.radioButton1.Checked)
                        pr.PayStatus = 1;
                    else if (this.radioButton2.Checked)
                        pr.PayStatus = 0;

                    _purchaseDAL.Save(pr);
                    MessageBox.Show("保存成功");
                }
                catch
                {
                    MessageBox.Show("保存失败");
                }
                finally
                {
                    CleanForm();
                }
            }
        }

        private void CleanForm()
        {
            this.txtGoods.Text = string.Empty;
            this.txtPrice.Text = string.Empty;
            this.txtUnit.Text = string.Empty;
            this.txtGoodsID.Text = string.Empty;
            this.txtCount.Text = string.Empty;
        }

        private void txtCount_TextChange(object sender,EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCount.Text))
                this.txtTotalPrice.Text = (Convert.ToDouble(this.txtCount.Text) * Convert.ToDouble(this.txtPrice.Text)).ToString();
            else
                this.txtTotalPrice.Text = "0";
        }
    }
}

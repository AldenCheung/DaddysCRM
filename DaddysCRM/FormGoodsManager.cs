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
using DaddysCRM.Model;

namespace WindowsFormsApplication1
{
    public partial class FormGoodsManager : Form
    {
        #region 属性成员
        public Goods SelectedGoods;
        public FormAddPurchaseRecord FormApr;
        private GoodsDAL _goodsDAL = new GoodsDAL();
        
        #endregion
        public FormGoodsManager()
        {
            InitializeComponent();
            this.button1.Visible = false;
            LoadData();
        }

        //重载构造函数
        public FormGoodsManager(FormAddPurchaseRecord frm)
        {
            InitializeComponent();
            this.btnDelete.Visible = false;
            LoadData();
           
            FormApr = frm;           
        }

        public void LoadData()
        {       
            DataSet ds = _goodsDAL.Query(string.Empty);

            bindingSource1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAddGoods fag = new FormAddGoods(this);

            fag.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //选择按钮单击事件
        private void button1_Click(object sender, EventArgs e)
        {
            SelectedGoods = new Goods();
            SelectedGoods.ID = this.dataGridView1.CurrentRow.Cells[0].Value == null ? 0 : Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
            SelectedGoods.GoodsName = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            SelectedGoods.Price = Convert.ToDouble(this.dataGridView1.CurrentRow.Cells[2].Value);
            SelectedGoods.Unit = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

            if (SelectedGoods.ID > 0)

                FormApr.LoadGoodsInfo(SelectedGoods);
            else
                return;

            this.Dispose();
        }
    }
}

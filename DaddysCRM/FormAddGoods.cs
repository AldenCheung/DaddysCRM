using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DaddysCRM.Model;
using DaddysCRM.DAL;

namespace WindowsFormsApplication1
{
    public partial class FormAddGoods : Form
    {
        GoodsDAL _goodsDAL = new GoodsDAL();
        FormGoodsManager fgm;
        public FormAddGoods()
        {
            InitializeComponent();
        }
        public FormAddGoods(FormGoodsManager frm)
        {
            InitializeComponent();
            fgm = frm;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Goods goods = new Goods()
                {
                    GoodsName = this.textBox1.Text,
                    Price = Convert.ToDouble(this.textBox2.Text),
                    Unit = this.textBox3.Text,
                    Remark = this.textBox4.Text,
                    ID = string.IsNullOrEmpty(this.textBox5.Text) ? 0 : Convert.ToInt32(this.textBox5.Text)
                };

                _goodsDAL.Save(goods);

                MessageBox.Show("保存成功");
                this.Dispose();
                fgm.LoadData();
            }
            catch
            {
                MessageBox.Show("保存失败");
            }
            
       
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

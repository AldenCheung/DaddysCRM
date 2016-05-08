using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormTreeFrame : Form
    {
        public FormTreeFrame()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Form frm = null;
            switch (Convert.ToInt32(this.treeView1.SelectedNode.Tag))
            {
                case 2: frm = new FormGoodsManager(); break;
                default: frm = new FormCustomerManager(); break;             
            }
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm);

            frm.Show();


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}

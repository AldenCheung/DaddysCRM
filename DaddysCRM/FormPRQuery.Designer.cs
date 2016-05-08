namespace DaddysCRM
{
    partial class FormPRQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Goods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.listBoxYear = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labeladdress = new System.Windows.Forms.Label();
            this.labelname = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labeltel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Goods,
            this.Count,
            this.TotalPrice,
            this.PurchaseDate,
            this.PayStatus});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(2, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(422, 300);
            this.dataGridView1.TabIndex = 0;
            // 
            // Goods
            // 
            this.Goods.DataPropertyName = "Goods";
            this.Goods.HeaderText = "购买商品";
            this.Goods.Name = "Goods";
            this.Goods.ReadOnly = true;
            // 
            // Count
            // 
            this.Count.DataPropertyName = "Count";
            this.Count.HeaderText = "数量";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.Width = 40;
            // 
            // TotalPrice
            // 
            this.TotalPrice.DataPropertyName = "TotalPrice";
            this.TotalPrice.HeaderText = "总价";
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            this.TotalPrice.Width = 60;
            // 
            // PurchaseDate
            // 
            this.PurchaseDate.DataPropertyName = "BuyDate";
            this.PurchaseDate.HeaderText = "购买日期";
            this.PurchaseDate.Name = "PurchaseDate";
            this.PurchaseDate.ReadOnly = true;
            // 
            // PayStatus
            // 
            this.PayStatus.DataPropertyName = "PayStatusName";
            this.PayStatus.HeaderText = "是否结清";
            this.PayStatus.Name = "PayStatus";
            this.PayStatus.ReadOnly = true;
            this.PayStatus.Width = 80;
            // 
            // listBoxYear
            // 
            this.listBoxYear.FormattingEnabled = true;
            this.listBoxYear.ItemHeight = 12;
            this.listBoxYear.Items.AddRange(new object[] {
            "2014",
            "2015",
            "2016"});
            this.listBoxYear.Location = new System.Drawing.Point(312, 51);
            this.listBoxYear.Name = "listBoxYear";
            this.listBoxYear.Size = new System.Drawing.Size(112, 16);
            this.listBoxYear.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "年份";
            // 
            // labeladdress
            // 
            this.labeladdress.AutoSize = true;
            this.labeladdress.Location = new System.Drawing.Point(73, 50);
            this.labeladdress.Name = "labeladdress";
            this.labeladdress.Size = new System.Drawing.Size(29, 12);
            this.labeladdress.TabIndex = 19;
            this.labeladdress.Text = "住址";
            // 
            // labelname
            // 
            this.labelname.AutoSize = true;
            this.labelname.Location = new System.Drawing.Point(76, 11);
            this.labelname.Name = "labelname";
            this.labelname.Size = new System.Drawing.Size(29, 12);
            this.labelname.TabIndex = 18;
            this.labelname.Text = "姓名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "住址";
            // 
            // labeltel
            // 
            this.labeltel.AutoSize = true;
            this.labeltel.Location = new System.Drawing.Point(222, 11);
            this.labeltel.Name = "labeltel";
            this.labeltel.Size = new System.Drawing.Size(29, 12);
            this.labeltel.TabIndex = 16;
            this.labeltel.Text = "电话";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "电话";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "姓名";
            // 
            // FormPRQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 383);
            this.Controls.Add(this.listBoxYear);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labeladdress);
            this.Controls.Add(this.labelname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labeltel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormPRQuery";
            this.Text = "购买记录";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Goods;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayStatus;
        private System.Windows.Forms.ListBox listBoxYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labeladdress;
        private System.Windows.Forms.Label labelname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labeltel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
    }
}
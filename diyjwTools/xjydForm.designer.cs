namespace diyjwTools
{
    partial class xjydForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearData = new System.Windows.Forms.Button();
            this.btnXJYDprocess = new System.Windows.Forms.Button();
            this.btnImpData = new System.Windows.Forms.Button();
            this.CmbYdyy = new System.Windows.Forms.ComboBox();
            this.CmbYdlx = new System.Windows.Forms.ComboBox();
            this.lbYdyy = new System.Windows.Forms.Label();
            this.lbYdlx = new System.Windows.Forms.Label();
            this.txbYdrq = new System.Windows.Forms.TextBox();
            this.lbYdrq = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearData);
            this.groupBox1.Controls.Add(this.btnXJYDprocess);
            this.groupBox1.Controls.Add(this.btnImpData);
            this.groupBox1.Controls.Add(this.CmbYdyy);
            this.groupBox1.Controls.Add(this.CmbYdlx);
            this.groupBox1.Controls.Add(this.lbYdyy);
            this.groupBox1.Controls.Add(this.lbYdlx);
            this.groupBox1.Controls.Add(this.txbYdrq);
            this.groupBox1.Controls.Add(this.lbYdrq);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "处理设置";
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(136, 68);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(115, 23);
            this.btnClearData.TabIndex = 9;
            this.btnClearData.Text = "清空待处理数据";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.BtnClearData_Click);
            // 
            // btnXJYDprocess
            // 
            this.btnXJYDprocess.Location = new System.Drawing.Point(522, 68);
            this.btnXJYDprocess.Name = "btnXJYDprocess";
            this.btnXJYDprocess.Size = new System.Drawing.Size(115, 23);
            this.btnXJYDprocess.TabIndex = 8;
            this.btnXJYDprocess.Text = "开始处理数据";
            this.btnXJYDprocess.UseVisualStyleBackColor = true;
            this.btnXJYDprocess.Click += new System.EventHandler(this.BtnXJYDprocess_Click);
            // 
            // btnImpData
            // 
            this.btnImpData.Location = new System.Drawing.Point(327, 68);
            this.btnImpData.Name = "btnImpData";
            this.btnImpData.Size = new System.Drawing.Size(115, 23);
            this.btnImpData.TabIndex = 7;
            this.btnImpData.Text = "导入待处理数据";
            this.btnImpData.UseVisualStyleBackColor = true;
            this.btnImpData.Click += new System.EventHandler(this.BtnImpData_Click);
            // 
            // CmbYdyy
            // 
            this.CmbYdyy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYdyy.FormattingEnabled = true;
            this.CmbYdyy.Location = new System.Drawing.Point(578, 28);
            this.CmbYdyy.Name = "CmbYdyy";
            this.CmbYdyy.Size = new System.Drawing.Size(121, 20);
            this.CmbYdyy.TabIndex = 6;
            // 
            // CmbYdlx
            // 
            this.CmbYdlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYdlx.FormattingEnabled = true;
            this.CmbYdlx.Location = new System.Drawing.Point(338, 28);
            this.CmbYdlx.Name = "CmbYdlx";
            this.CmbYdlx.Size = new System.Drawing.Size(121, 20);
            this.CmbYdlx.TabIndex = 5;
            // 
            // lbYdyy
            // 
            this.lbYdyy.AutoSize = true;
            this.lbYdyy.Location = new System.Drawing.Point(507, 31);
            this.lbYdyy.Name = "lbYdyy";
            this.lbYdyy.Size = new System.Drawing.Size(65, 12);
            this.lbYdyy.TabIndex = 4;
            this.lbYdyy.Text = "异动原因：";
            // 
            // lbYdlx
            // 
            this.lbYdlx.AutoSize = true;
            this.lbYdlx.Location = new System.Drawing.Point(267, 31);
            this.lbYdlx.Name = "lbYdlx";
            this.lbYdlx.Size = new System.Drawing.Size(65, 12);
            this.lbYdlx.TabIndex = 2;
            this.lbYdlx.Text = "异动类型：";
            // 
            // txbYdrq
            // 
            this.txbYdrq.Location = new System.Drawing.Point(102, 28);
            this.txbYdrq.Name = "txbYdrq";
            this.txbYdrq.Size = new System.Drawing.Size(121, 21);
            this.txbYdrq.TabIndex = 1;
            // 
            // lbYdrq
            // 
            this.lbYdrq.AutoSize = true;
            this.lbYdrq.Location = new System.Drawing.Point(31, 31);
            this.lbYdrq.Name = "lbYdrq";
            this.lbYdrq.Size = new System.Drawing.Size(65, 12);
            this.lbYdrq.TabIndex = 0;
            this.lbYdrq.Text = "异动日期：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(800, 346);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // xjydForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "xjydForm";
            this.Text = "学籍异动批量处理";
            this.Load += new System.EventHandler(this.XjydForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbYdrq;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.Button btnXJYDprocess;
        private System.Windows.Forms.Button btnImpData;
        private System.Windows.Forms.ComboBox CmbYdyy;
        private System.Windows.Forms.ComboBox CmbYdlx;
        private System.Windows.Forms.Label lbYdyy;
        private System.Windows.Forms.Label lbYdlx;
        private System.Windows.Forms.TextBox txbYdrq;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
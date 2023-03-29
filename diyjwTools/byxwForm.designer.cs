namespace diyjwTools
{
    partial class byxwForm
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
            this.Lbsm = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.Lbsm);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "批量修改学籍中毕业学位信息";
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(148, 49);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(115, 23);
            this.btnClearData.TabIndex = 12;
            this.btnClearData.Text = "清空待处理数据";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.BtnClearData_Click);
            // 
            // btnXJYDprocess
            // 
            this.btnXJYDprocess.Location = new System.Drawing.Point(534, 49);
            this.btnXJYDprocess.Name = "btnXJYDprocess";
            this.btnXJYDprocess.Size = new System.Drawing.Size(115, 23);
            this.btnXJYDprocess.TabIndex = 11;
            this.btnXJYDprocess.Text = "开始处理数据";
            this.btnXJYDprocess.UseVisualStyleBackColor = true;
            this.btnXJYDprocess.Click += new System.EventHandler(this.BtnXJYDprocess_Click);
            // 
            // btnImpData
            // 
            this.btnImpData.Location = new System.Drawing.Point(339, 49);
            this.btnImpData.Name = "btnImpData";
            this.btnImpData.Size = new System.Drawing.Size(115, 23);
            this.btnImpData.TabIndex = 10;
            this.btnImpData.Text = "导入待处理数据";
            this.btnImpData.UseVisualStyleBackColor = true;
            this.btnImpData.Click += new System.EventHandler(this.BtnImpData_Click);
            // 
            // Lbsm
            // 
            this.Lbsm.AutoSize = true;
            this.Lbsm.Location = new System.Drawing.Point(25, 21);
            this.Lbsm.Name = "Lbsm";
            this.Lbsm.Size = new System.Drawing.Size(713, 12);
            this.Lbsm.TabIndex = 0;
            this.Lbsm.Text = "说明：本模块只更新学籍信息中的学位、毕业类型、毕业证书编号、毕业日期、学位证书编号、离校日期、授予学位时间和学生证号。";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(800, 364);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // byxwForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "byxwForm";
            this.Text = "byxwForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Lbsm;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.Button btnXJYDprocess;
        private System.Windows.Forms.Button btnImpData;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
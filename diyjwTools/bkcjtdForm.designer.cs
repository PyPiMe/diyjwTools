namespace diyjwTools
{
    partial class bkcjtdForm
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
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxbZXJXJHH = new System.Windows.Forms.TextBox();
            this.BtnqueryData = new System.Windows.Forms.Button();
            this.BtnHandleData = new System.Windows.Forms.Button();
            this.TxbKSSJ = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 94);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowTemplate.Height = 23;
            this.DataGridView1.Size = new System.Drawing.Size(800, 356);
            this.DataGridView1.TabIndex = 3;
            this.DataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DataGridView1_RowPostPaint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxbZXJXJHH);
            this.groupBox1.Controls.Add(this.BtnqueryData);
            this.groupBox1.Controls.Add(this.BtnHandleData);
            this.groupBox1.Controls.Add(this.TxbKSSJ);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 94);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "处理设置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(33, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "特别说明：请先将补考成绩导入历年成绩库！";
            // 
            // TxbZXJXJHH
            // 
            this.TxbZXJXJHH.Location = new System.Drawing.Point(176, 54);
            this.TxbZXJXJHH.Name = "TxbZXJXJHH";
            this.TxbZXJXJHH.Size = new System.Drawing.Size(121, 21);
            this.TxbZXJXJHH.TabIndex = 8;
            // 
            // BtnqueryData
            // 
            this.BtnqueryData.Location = new System.Drawing.Point(640, 23);
            this.BtnqueryData.Name = "BtnqueryData";
            this.BtnqueryData.Size = new System.Drawing.Size(120, 23);
            this.BtnqueryData.TabIndex = 7;
            this.BtnqueryData.Text = "查询待处理数据";
            this.BtnqueryData.UseVisualStyleBackColor = true;
            this.BtnqueryData.Click += new System.EventHandler(this.BtnqueryData_Click);
            // 
            // BtnHandleData
            // 
            this.BtnHandleData.Location = new System.Drawing.Point(640, 57);
            this.BtnHandleData.Name = "BtnHandleData";
            this.BtnHandleData.Size = new System.Drawing.Size(120, 23);
            this.BtnHandleData.TabIndex = 5;
            this.BtnHandleData.Text = "开始处理数据";
            this.BtnHandleData.UseVisualStyleBackColor = true;
            this.BtnHandleData.Click += new System.EventHandler(this.BtnHandleData_Click);
            // 
            // TxbKSSJ
            // 
            this.TxbKSSJ.Location = new System.Drawing.Point(479, 52);
            this.TxbKSSJ.Name = "TxbKSSJ";
            this.TxbKSSJ.Size = new System.Drawing.Size(121, 21);
            this.TxbKSSJ.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "补考成绩考试时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "补考成绩所属学年学期：";
            // 
            // bkcjtdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "bkcjtdForm";
            this.Text = "同步补考数据替代课程号";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnqueryData;
        private System.Windows.Forms.Button BtnHandleData;
        private System.Windows.Forms.TextBox TxbKSSJ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxbZXJXJHH;
        private System.Windows.Forms.Label label3;
    }
}
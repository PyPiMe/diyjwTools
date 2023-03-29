namespace diyjwTools
{
    partial class DbConfigForm
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
            this.LbServiceID = new System.Windows.Forms.Label();
            this.LbInstanceID = new System.Windows.Forms.Label();
            this.LbDbPwd = new System.Windows.Forms.Label();
            this.TxbDbPwd = new System.Windows.Forms.TextBox();
            this.BtnTestConn = new System.Windows.Forms.Button();
            this.BtnSaveConfig = new System.Windows.Forms.Button();
            this.LbTips = new System.Windows.Forms.Label();
            this.TxbInstanceID = new System.Windows.Forms.TextBox();
            this.TxbServiceID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbServiceID
            // 
            this.LbServiceID.AutoSize = true;
            this.LbServiceID.Location = new System.Drawing.Point(73, 22);
            this.LbServiceID.Name = "LbServiceID";
            this.LbServiceID.Size = new System.Drawing.Size(53, 12);
            this.LbServiceID.TabIndex = 0;
            this.LbServiceID.Text = "服务名：";
            // 
            // LbInstanceID
            // 
            this.LbInstanceID.AutoSize = true;
            this.LbInstanceID.Location = new System.Drawing.Point(73, 61);
            this.LbInstanceID.Name = "LbInstanceID";
            this.LbInstanceID.Size = new System.Drawing.Size(53, 12);
            this.LbInstanceID.TabIndex = 1;
            this.LbInstanceID.Text = "实例名：";
            // 
            // LbDbPwd
            // 
            this.LbDbPwd.AutoSize = true;
            this.LbDbPwd.Location = new System.Drawing.Point(73, 101);
            this.LbDbPwd.Name = "LbDbPwd";
            this.LbDbPwd.Size = new System.Drawing.Size(53, 12);
            this.LbDbPwd.TabIndex = 2;
            this.LbDbPwd.Text = "密  码：";
            // 
            // TxbDbPwd
            // 
            this.TxbDbPwd.Location = new System.Drawing.Point(132, 98);
            this.TxbDbPwd.Name = "TxbDbPwd";
            this.TxbDbPwd.Size = new System.Drawing.Size(100, 21);
            this.TxbDbPwd.TabIndex = 5;
            this.TxbDbPwd.UseSystemPasswordChar = true;
            // 
            // BtnTestConn
            // 
            this.BtnTestConn.Location = new System.Drawing.Point(52, 141);
            this.BtnTestConn.Name = "BtnTestConn";
            this.BtnTestConn.Size = new System.Drawing.Size(75, 23);
            this.BtnTestConn.TabIndex = 6;
            this.BtnTestConn.Text = "测试链接";
            this.BtnTestConn.UseVisualStyleBackColor = true;
            this.BtnTestConn.Click += new System.EventHandler(this.BtnTestConn_Click);
            // 
            // BtnSaveConfig
            // 
            this.BtnSaveConfig.Location = new System.Drawing.Point(175, 141);
            this.BtnSaveConfig.Name = "BtnSaveConfig";
            this.BtnSaveConfig.Size = new System.Drawing.Size(75, 23);
            this.BtnSaveConfig.TabIndex = 7;
            this.BtnSaveConfig.Text = "保存链接";
            this.BtnSaveConfig.UseVisualStyleBackColor = true;
            this.BtnSaveConfig.Click += new System.EventHandler(this.BtnSaveConfig_Click);
            // 
            // LbTips
            // 
            this.LbTips.AutoSize = true;
            this.LbTips.Location = new System.Drawing.Point(52, 179);
            this.LbTips.Name = "LbTips";
            this.LbTips.Size = new System.Drawing.Size(197, 12);
            this.LbTips.TabIndex = 8;
            this.LbTips.Text = "提示：数据库连接信息将加密保存！";
            // 
            // TxbInstanceID
            // 
            this.TxbInstanceID.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TxbInstanceID.Location = new System.Drawing.Point(132, 58);
            this.TxbInstanceID.Name = "TxbInstanceID";
            this.TxbInstanceID.Size = new System.Drawing.Size(100, 21);
            this.TxbInstanceID.TabIndex = 4;
            this.TxbInstanceID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbInstanceID_KeyPress);
            // 
            // TxbServiceID
            // 
            this.TxbServiceID.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TxbServiceID.Location = new System.Drawing.Point(132, 19);
            this.TxbServiceID.Name = "TxbServiceID";
            this.TxbServiceID.Size = new System.Drawing.Size(100, 21);
            this.TxbServiceID.TabIndex = 3;
            this.TxbServiceID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbServiceID_KeyPress);
            // 
            // DbConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 212);
            this.Controls.Add(this.LbServiceID);
            this.Controls.Add(this.LbTips);
            this.Controls.Add(this.BtnTestConn);
            this.Controls.Add(this.BtnSaveConfig);
            this.Controls.Add(this.TxbServiceID);
            this.Controls.Add(this.TxbDbPwd);
            this.Controls.Add(this.LbInstanceID);
            this.Controls.Add(this.TxbInstanceID);
            this.Controls.Add(this.LbDbPwd);
            this.Name = "DbConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库连接设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbServiceID;
        private System.Windows.Forms.Label LbInstanceID;
        private System.Windows.Forms.Label LbDbPwd;
        private System.Windows.Forms.TextBox TxbDbPwd;
        private System.Windows.Forms.Button BtnTestConn;
        private System.Windows.Forms.Button BtnSaveConfig;
        private System.Windows.Forms.Label LbTips;
        private System.Windows.Forms.TextBox TxbInstanceID;
        private System.Windows.Forms.TextBox TxbServiceID;
    }
}
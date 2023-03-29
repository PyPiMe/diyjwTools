namespace diyjwTools
{
    partial class MDIForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DbConfigMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExAppToolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xjydMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xjbyxwMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DbToolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bkcjtdMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ksToolStripMenuItem,
            this.ExAppToolsMenuItem,
            this.DbToolsMenuItem,
            this.helpMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ksToolStripMenuItem
            // 
            this.ksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DbConfigMenuItem,
            this.exitMenuItem});
            this.ksToolStripMenuItem.Name = "ksToolStripMenuItem";
            this.ksToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.ksToolStripMenuItem.Text = "开始(&F)";
            // 
            // DbConfigMenuItem
            // 
            this.DbConfigMenuItem.Name = "DbConfigMenuItem";
            this.DbConfigMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DbConfigMenuItem.Text = "数据库连接设置(&C)";
            this.DbConfigMenuItem.Click += new System.EventHandler(this.DbConfigMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitMenuItem.Text = "退出(&E)";
            this.exitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // ExAppToolsMenuItem
            // 
            this.ExAppToolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kchMenuItem,
            this.xjydMenuItem,
            this.xjbyxwMenuItem});
            this.ExAppToolsMenuItem.Name = "ExAppToolsMenuItem";
            this.ExAppToolsMenuItem.Size = new System.Drawing.Size(83, 21);
            this.ExAppToolsMenuItem.Text = "应用工具(&T)";
            // 
            // kchMenuItem
            // 
            this.kchMenuItem.Name = "kchMenuItem";
            this.kchMenuItem.Size = new System.Drawing.Size(196, 22);
            this.kchMenuItem.Text = "课程号更改";
            this.kchMenuItem.Click += new System.EventHandler(this.KchMenuItem_Click);
            // 
            // xjydMenuItem
            // 
            this.xjydMenuItem.Name = "xjydMenuItem";
            this.xjydMenuItem.Size = new System.Drawing.Size(196, 22);
            this.xjydMenuItem.Text = "批量学籍异动";
            this.xjydMenuItem.Click += new System.EventHandler(this.XjydMenuItem_Click);
            // 
            // xjbyxwMenuItem
            // 
            this.xjbyxwMenuItem.Name = "xjbyxwMenuItem";
            this.xjbyxwMenuItem.Size = new System.Drawing.Size(196, 22);
            this.xjbyxwMenuItem.Text = "学籍毕业学位信息更改";
            this.xjbyxwMenuItem.Click += new System.EventHandler(this.XjbyxwMenuItem_Click);
            // 
            // DbToolsMenuItem
            // 
            this.DbToolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bkcjtdMenuItem});
            this.DbToolsMenuItem.Name = "DbToolsMenuItem";
            this.DbToolsMenuItem.Size = new System.Drawing.Size(97, 21);
            this.DbToolsMenuItem.Text = "数据库工具(&D)";
            // 
            // bkcjtdMenuItem
            // 
            this.bkcjtdMenuItem.Name = "bkcjtdMenuItem";
            this.bkcjtdMenuItem.Size = new System.Drawing.Size(196, 22);
            this.bkcjtdMenuItem.Text = "补考数据替代课程同步";
            this.bkcjtdMenuItem.Click += new System.EventHandler(this.bkcjtdMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(61, 21);
            this.helpMenuItem.Text = "帮助(&H)";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutMenuItem.Text = "关于(&A)";
            this.aboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel1.Text = "就绪";
            // 
            // MDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "diyjwTools";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem ksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExAppToolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xjydMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xjbyxwMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem DbConfigMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DbToolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bkcjtdMenuItem;
    }
}


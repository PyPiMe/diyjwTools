using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diyjwTools
{
    public partial class MDIForm : Form
    {
        public MDIForm()
        {
            InitializeComponent();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutForm = new AboutBox();
            aboutForm.Show();
        }

        private void KchMenuItem_Click(object sender, EventArgs e)
        {
            Form kchForm1 = new kchForm
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            kchForm1.Show();
        }

        private void XjydMenuItem_Click(object sender, EventArgs e)
        {
            Form xjydForm1 = new xjydForm
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            xjydForm1.Show();
        }

        private void XjbyxwMenuItem_Click(object sender, EventArgs e)
        {
            Form byxwForm1 = new byxwForm
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            byxwForm1.Show();
        }

        private void DbConfigMenuItem_Click(object sender, EventArgs e)
        {
            Form DbConfigForm1 = new DbConfigForm();
            //{
            //    MdiParent = this,
            //    WindowState = FormWindowState.Maximized
            //};
            DbConfigForm1.Show();
        }

        private void bkcjtdMenuItem_Click(object sender, EventArgs e)
        {
            Form bkcjtdForm1 = new bkcjtdForm
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            bkcjtdForm1.Show();
        }
    }
}

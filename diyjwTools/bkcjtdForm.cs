using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using diyjwToolsClassLibrary;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace diyjwTools
{
    public partial class bkcjtdForm : Form
    {
        public bkcjtdForm()
        {
            InitializeComponent();
        }
        //定义
        private diyjwToolsClassLibrary.Utilities myUtilities = new diyjwToolsClassLibrary.Utilities();


        //查询待处理数据并显示
        private void BtnqueryData_Click(object sender, EventArgs e)
        {
            string zxjxjhh = TxbZXJXJHH.Text.Trim();
            string kssj = TxbKSSJ.Text.Trim();
            string checkcjstr = "select count(*) from  xs_kccjb a where a.xh || a.kch in (select b.xh || b.kch from cj_lrcjb b where b.tdkch is not null) and a.zxjxjhh = '" + zxjxjhh + "' and a.kssj='" + kssj + "'";
            if (myUtilities.GetOracleCount(checkcjstr) == 0)
            {
                MessageBox.Show("未查询到需要更改的数据！请检查“补考数据所属学年学期”和“补考数据考试时间”是否正确！", "提示");
            }
            else
            {
                string cjDataListStr = "select a.zxjxjhh, a.xh, a.kch, a.kxh, a.kssj, a.tdkch from  xs_kccjb a where a.xh || a.kch in (select b.xh || b.kch from cj_lrcjb b where b.tdkch is not null) and a.zxjxjhh = '" + zxjxjhh + "' and a.kssj='" + kssj + "'";
                DataGridView1.DataSource = myUtilities.GetOracleDataSet(cjDataListStr); // dataset
            }
        }

        private void BtnHandleData_Click(object sender, EventArgs e)
        {

        }

        //显示DataGridView的行号      
        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                                                e.RowBounds.Location.Y,
                                                dgv.RowHeadersWidth - 4,
                                                e.RowBounds.Height);


            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                                    dgv.RowHeadersDefaultCellStyle.Font,
                                    rectangle,
                                    dgv.RowHeadersDefaultCellStyle.ForeColor,
                                    TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }





        //
    }
}

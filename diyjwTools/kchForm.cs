using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using diyjwToolsClassLibrary;

namespace diyjwTools
{
    public partial class kchForm : Form
    {
        public kchForm()
        {
            InitializeComponent();
        }

        //定义
        private diyjwToolsClassLibrary.Utilities myUtilities = new diyjwToolsClassLibrary.Utilities();
        private string markNowPast = string.Empty;
        private DataSet dsImportData = new DataSet();
        //private DataSet dsNull = new DataSet();

        private void BtnHandleData_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("请先导入数据！", "提示");
                return;
            }
            string bz = txbBz.Text + "username更改";
            if (radioButton1.Checked)
            {
                markNowPast = "cj_lrcjb";
            }
            if (radioButton2.Checked)
            {
                markNowPast = "xs_kccjb";
            }
            if (markNowPast == null || markNowPast == string.Empty)
            {
                MessageBox.Show("请先选择所属成绩库！", "提示");
                return;
            }

            ToolStripStatusLabel statusStrip = ((MDIForm)(this.MdiParent)).toolStripStatusLabel1;
            if (MessageBox.Show("检查下参数设置，确认执行请点击OK？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    //循环得到Grid中的数据，逐条进行处理
                    for (int i = 0; i < dsImportData.Tables[0].Rows.Count; i++)
                    {
                        //当前数据行号
                        int curentDataRowNumber = i + 1;
                        //获取数据
                        string zxjxjhh = dataGridView1[0, i].Value.ToString().Trim();
                        string xh = dataGridView1[1, i].Value.ToString().Trim();
                        string kssj = dataGridView1[2, i].Value.ToString().Trim();
                        string kch = dataGridView1[3, i].Value.ToString().Trim();
                        string kcm = dataGridView1[4, i].Value.ToString().Trim();
                        string tdkch = dataGridView1[5, i].Value.ToString().Trim();
                        string tdkcm = dataGridView1[6, i].Value.ToString().Trim();
                        if (kch == tdkch)
                        {
                            MessageBox.Show("数据处理中断！数据中的第=" + curentDataRowNumber + "=行课程号和替代课程号相同！", "提示");
                            break;
                        }
                        //检查课程号和替代课程号
                        string checksql_kch = "select kcm from code_kcb where kch='" + kch + "'";
                        string checksql_tdkch = "select kcm from code_kcb where kch='" + tdkch + "'";
                        //string checksql_ytdkch = "select nvl(tdkch,'null')  from xs_kccjb where xh='" + xh + "' and kch='" + kch + "' and kssj='" + kssj + "'";
                        if (myUtilities.GetOracleStr(checksql_kch) != kcm || myUtilities.GetOracleStr(checksql_tdkch) != tdkcm)
                        {
                            MessageBox.Show("数据处理中断！数据中的第=" + curentDataRowNumber + "=行课程号或替代课程号不存在！", "提示");
                            break;
                        }
                        //检查对应数据是否存在，并处理数据。
                        string countDataStr = "select count(*) from " + markNowPast + " where xh='" + xh + "' and kch='" + kch + "'";
                        string updataDataStr = "update " + markNowPast + " set tdkch='" + tdkch + "',bz2='" + bz + "' where xh='" + xh + "' and kch='" + kch + "'";
                        if (myUtilities.GetOracleCount(countDataStr) == 0)
                        {
                            MessageBox.Show("数据处理中断！数据中的第=" + curentDataRowNumber + "=行数据在所选成绩库中不存在！", "提示");
                            break;
                        }
                        try
                        {
                            myUtilities.ExeOracleSql(updataDataStr);
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show("更新数据时发生错误：" + ex.Message, "提示");
                        }

                    }
                    //显示提示，并更新状态栏
                    MessageBox.Show("处理完成！", "提示");
                    statusStrip.Text = "处理完成！";

                }
                catch (System.Exception ex)
                {
                    string rollbackStr = "rollback";
                    myUtilities.ExeOracleSql(rollbackStr);
                    MessageBox.Show("更新数据时发生错误：" + ex.Message, "提示");
                }
                //清空导入的待处理数据框
                while (this.dataGridView1.Rows.Count != 0)
                {
                    this.dataGridView1.Rows.RemoveAt(0);
                }
            }
        }

        private void BtnImpData_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                //注意这里写路径时要用c:\\而不是c:/
                openFileDialog.InitialDirectory = "D:\\My Documents\\Folder1";
                openFileDialog.Filter = "Excel文件|*.xls;*.xlsx";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //获取文件名（包括文件所在位置的路径）
                    string strFilePath;
                    strFilePath = openFileDialog.FileName;
                    //MessageBox.Show(strFilePath);
                    dsImportData = myUtilities.ExcelToDS(strFilePath);
                    //dataGrid1.DataSource = myds;
                    //dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = dsImportData; // dataset
                    dataGridView1.DataMember = "table1"; // table name you need to show
                    ToolStripStatusLabel statusStrip = ((MDIForm)(this.MdiParent)).toolStripStatusLabel1;
                    statusStrip.Text = "导入Excel成功！";
                    markNowPast = "xs_kccjb";
                }                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("导入数据时发生错误：" + ex.Message, "提示");
            }
        }

        private void BtnClearData_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("没有可清空的数据！" , "提示");
            }
            else
            {
                while (this.dataGridView1.Rows.Count != 0)
                {
                    this.dataGridView1.Rows.RemoveAt(0);
                }
                ToolStripStatusLabel statusStrip = ((MDIForm)(this.MdiParent)).toolStripStatusLabel1;
                statusStrip.Text = "已清空数据";
                MessageBox.Show("已清空数据！" , "提示");
            }            
        }

        //显示DataGridView的行号
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

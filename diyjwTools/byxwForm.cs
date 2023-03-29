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
    public partial class byxwForm : Form
    {
        public byxwForm()
        {
            InitializeComponent();
        }

        //定义
        private diyjwToolsClassLibrary.Utilities myUtilities = new diyjwToolsClassLibrary.Utilities();
        private DataSet dsImportData = new DataSet();
        private DataSet dsNull = new DataSet();

        private void BtnClearData_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("没有可清空的数据！", "提示");
            }
            else
            {
                while (this.dataGridView1.Rows.Count != 0)
                {
                    this.dataGridView1.Rows.RemoveAt(0);
                }
                ToolStripStatusLabel statusStrip = ((MDIForm)(this.MdiParent)).toolStripStatusLabel1;
                statusStrip.Text = "已清空数据";
                MessageBox.Show("已清空数据！", "提示");
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
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("导入数据时发生错误：" + ex.Message, "提示");
            }
        }

        private void BtnXJYDprocess_Click(object sender, EventArgs e)
        {
            //select xwdm,xwm from code_xwb;
            //select bylxdm,bylxmc from code_bylxb;
            //点击确定再继续执行，否则中断
            if (MessageBox.Show("确认执行请点击OK？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }
            //检查导入的数据有效性
            for (int i = 0; i < dsImportData.Tables[0].Rows.Count; i++)
            {
                //学号0、姓名1、毕业类型2、毕业证书编号3、毕业证发证日期-毕业日期4、学位5、学位证编号6、授予学位时间7、离校时间8、学生证号-届次9
                //学号
                string xh = dataGridView1[0, i].Value.ToString().Trim();
                //姓名
                string xm = dataGridView1[1, i].Value.ToString().Trim();
                //毕业类型
                string bylxmc = dataGridView1[2, i].Value.ToString().Trim();
                //学位
                string xwmc = dataGridView1[5, i].Value.ToString().Trim();



                //校验学号和姓名
                string checksql_xh = "select xm from xs_xjb where xh='" + xh + "'";
                //当前数据行数
                int DataRowNumber = i + 1;
                if (myUtilities.GetOracleStr(checksql_xh) != xm)
                {
                    MessageBox.Show("数据校验失败！数据中的第=" + DataRowNumber + "=行学号和姓名不符！", "错误");
                    break;
                }
                //导入数据中“毕业类型”字段不为空，检验毕业类型
                if (bylxmc != string.Empty)
                {
                    string checksql_bylxmc = "select count(*) from code_bylxb where bylxmc='" + bylxmc + "'";
                    if (myUtilities.GetOracleCount(checksql_bylxmc) != 1)
                    {
                        MessageBox.Show("数据校验失败！数据中的第=" + DataRowNumber + "=行毕业类型在系统中不存在！", "错误");
                        break;
                    }
                    break;
                }
                //校验导入数据中“学位”字段不为空，检验学位
                if (xwmc != string.Empty)
                {
                    //    MessageBox.Show("数据校验失败！数据中的第=" + DataRowNumber + "=行“学位”字段为空！", "错误");
                    //    break;
                    //}
                    string checksql_xwmc = "select count(*) from code_xwb where xwm='" + xwmc + "'";
                    if (myUtilities.GetOracleCount(checksql_xwmc) != 1)
                    {
                        MessageBox.Show("数据校验失败！数据中的第=" + DataRowNumber + "=行学位名称在系统中不存在！", "错误");
                        break;
                    }
                    break;
                }
            }
            //循环处理数据
            for (int i = 0; i < dsImportData.Tables[0].Rows.Count; i++)
            {
                //学号0、姓名1、毕业类型2、毕业证书编号3、毕业证发证日期-毕业日期4、学位5、学位证编号6、授予学位时间7、离校时间8、学生证号-届次9、学籍状态10
                //学号
                string xh = dataGridView1[0, i].Value.ToString().Trim();
                //姓名
                string xm = dataGridView1[1, i].Value.ToString().Trim();
                //毕业类型
                string bylxmc = dataGridView1[2, i].Value.ToString().Trim();
                //毕业证书编号
                string byzsbh = dataGridView1[3, i].Value.ToString().Trim();
                //毕业证发证日期-毕业日期
                string byrq = dataGridView1[4, i].Value.ToString().Trim();
                //学位名称
                string xwmc = dataGridView1[5, i].Value.ToString().Trim();
                //学位证编号
                string xwzsbh = dataGridView1[6, i].Value.ToString().Trim();
                //授予学位时间
                string syxwrq = dataGridView1[7, i].Value.ToString().Trim();
                //离校时间
                string lxrq = dataGridView1[8, i].Value.ToString().Trim();
                //学生证号-届次
                string xsjc = dataGridView1[9, i].Value.ToString().Trim();
                //学籍状态
                //毕业离校代码22
                //结业离校代码21
                string xjzt = dataGridView1[10, i].Value.ToString().Trim();

                //毕业类型代码
                string bylxdm = string.Empty;
                //学位代码
                string xwdm = string.Empty;
                //更新毕业类型sql
                string bylxdm_updata_sql = string.Empty;
                //更新毕业证书编号sql
                string byzsbh_update_sql = string.Empty;
                //更新业证发证日期-毕业日期sql
                string byrq_update_sql = string.Empty;
                //更新学位代码sql
                string xwdm_update_sql = string.Empty;
                //更新学位证编号sql
                string xwzsbh_update_sql = string.Empty;
                //更新授予学位时间sql
                string syxwrq_update_sql = string.Empty;
                //更新离校时间sql
                string lxrq_update_sql = string.Empty;
                //更新学生证号-届次编号sql
                string xsjc_update_sql = string.Empty;
                //更新学籍状态代码sql
                string xjzt_update_sql = string.Empty;

                //循环执行，每行数据都执行一次sql。
                //循环结束后，统一提交。
                try
                {
                    //获取毕业类型代码并更新
                    if (bylxmc != string.Empty)
                    {
                        string bylxdm_sql = "select bylxdm from code_bylxb where bylxmc='" + bylxmc + "'";
                        bylxdm = myUtilities.GetOracleStr(bylxdm_sql);
                        bylxdm_updata_sql = "update xs_xjb set bylxdm='" + bylxdm + "' where xh='" + xh + "'";
                        myUtilities.ExeOracleSql(bylxdm_updata_sql);
                    }
                    //更新毕业证书编号
                    if (byzsbh != string.Empty)
                    {
                        byzsbh_update_sql = "update xs_xjb set byzsbh='" + byzsbh + "' where xh='" + xh + "'";
                        myUtilities.ExeOracleSql(byzsbh_update_sql);
                    }
                    //更新业证发证日期-毕业日期
                    if (byrq != string.Empty)
                    {
                        byrq_update_sql = "update xs_xjb set byrq='" + byrq + "' where xh='" + xh + "'";
                        myUtilities.ExeOracleSql(byrq_update_sql);
                    }
                    //获取学位代码并更新
                    if (xwmc != string.Empty)
                    {
                        string xwdm_sql = "select xwdm from code_xwb where xwm='" + xwmc + "'";
                        xwdm = myUtilities.GetOracleStr(xwdm_sql);
                        xwdm_update_sql = "update xs_xjb set xwdm='" + xwdm + "' where xh='" + xh + "'";
                        myUtilities.ExeOracleSql(xwdm_update_sql);
                    }
                    //更新学位证编号
                    if (xwzsbh != string.Empty)
                    {
                        xwzsbh_update_sql = "update xs_xjb set xwzsbh='" + xwzsbh + "' where xh='" + xh + "'";
                        myUtilities.ExeOracleSql(xwzsbh_update_sql);
                    }
                    //更新授予学位时间
                    if (syxwrq != string.Empty)
                    {
                        syxwrq_update_sql = "update xs_xjb set syxwsj='" + syxwrq + "' where xh='" + xh + "'";
                        myUtilities.ExeOracleSql(syxwrq_update_sql);
                    }
                    //更新毕业证书编号
                    if (lxrq != string.Empty)
                    {
                        lxrq_update_sql = "update xs_xjb set lxrq='" + lxrq + "' where xh='" + xh + "'";
                        myUtilities.ExeOracleSql(lxrq_update_sql);
                    }
                    //更新毕业届次
                    if (xsjc != string.Empty)
                    {
                        xsjc_update_sql = "update xs_xjb set xszh='" + xsjc + "' where xh='" + xh + "'";
                        myUtilities.ExeOracleSql(xsjc_update_sql);
                    }
                    //更新学籍状态代码
                    if (xjzt != string.Empty)
                    {
                        xjzt_update_sql = "update xs_xjb set XJZTDM='" + xjzt + "' where xh='" + xh + "'";
                        myUtilities.ExeOracleSql(xjzt_update_sql);
                    }
                }
                catch (System.Exception ex)
                {
                    string rollbackStr = "rollback";
                    myUtilities.ExeOracleSql(rollbackStr);
                    MessageBox.Show("更新数据时发生错误：" + ex.Message, "提示");
                    break;
                }
                //
            }
            //
            //统一提交
            try
            {
                string commitStr = "commit";
                myUtilities.ExeOracleSql(commitStr);
                MessageBox.Show("处理完成！", "提示");
                ToolStripStatusLabel statusStrip = ((MDIForm)(this.MdiParent)).toolStripStatusLabel1;
                statusStrip.Text = "毕业学位信息批量处理完毕！";
                while (this.dataGridView1.Rows.Count != 0)
                {
                    this.dataGridView1.Rows.RemoveAt(0);
                }
            }
            catch (System.Exception ex)
            {
                string rollbackStr = "rollback";
                myUtilities.ExeOracleSql(rollbackStr);
                MessageBox.Show("更新数据时发生错误：" + ex.Message, "提示");
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
    }
}

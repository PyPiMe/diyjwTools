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
    public partial class xjydForm : Form
    {
        public xjydForm()
        {
            InitializeComponent();
        }

        //定义
        private diyjwToolsClassLibrary.Utilities myUtilities = new diyjwToolsClassLibrary.Utilities();
        private DataSet dsImportData = new DataSet();
        //private DataSet dsNull = new DataSet();

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

        // ------------------数据说明----------------------------------------------
        // select * from code_bjb;//班级 bjh,bm,xsh,zyh
        // select * from code_ydlb;//异动类别  yddm,ydlb
        // select * from code_ydyyb;//异动原因   ydyydm,ydyysm
        // 学籍表
        // select * from xs_xjb where xh='201309020222';
        // 读取字段：xsh,zyh,zyfxh,njdm,bjh,ydf(是/否),yjbyrq,xjztdm,sfyxj,sfygjxj,xzlxdm
        // 修改字段：xsh,zyh,zyfxh,njdm,bjh,ydf,xjztdm,sfyxj,sfygjxj
        // 学籍异动表
        // select * from xs_xjydb where xh='201731083411'
        // ydrq,yddm,ydyydm
        // 异动前 ynjdm,yxsh,yzyh,yzyfxh,ybjh,yyjbyrq,yxjztdm,yxqh,ysfyxj,ysfygjxj,yxzlxdm
        // 异动后 ydhnjdm,ydhxsh,ydhzyh,ydhzyfxh,ydhbjh,ydhyjbyrq,ydhxqh,ydhsfyxj,ydhsfygjxj
        // 学期学分券异动表，凡是需要重新计算学分券的学籍异动，需要写该表
        // select * from xfsf_xqxfq_yd
        // 字段：zxjxjhh,xh,ydlx,ydsj,czr,czsj(20150902152256),czip,czmac(D8-97-BA-85-8E-94),cjbj(0)
        // 获取当前zxjxjhh
        // select PARAM_VALUE from sys_param where PARAM_ID='当前执行教学计划号';
        // 学籍异动代码——
        // 保留学籍：19
        // 转专业：22
        // 转班：34
        // 降级：8
        // 跳级：9
        // -------------------------------------------------------------------------
        private void BtnXJYDprocess_Click(object sender, EventArgs e)
        {
            //检查是否已导入数据
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("请先导入数据！", "提示");
                return;
            }
            //检查异动日期
            if (txbYdrq.Text == string.Empty)
            {
                MessageBox.Show("异动日期不能为空！", "提示");
                return;
            }
            //检查异动类型
            if (CmbYdlx.SelectedValue.ToString() == "000")
            {
                MessageBox.Show("请选择异动类型！", "提示");
                return;
            }
            //检查异动原因
            if (CmbYdyy.SelectedValue.ToString() == "000")
            {
                MessageBox.Show("请选择异动原因！", "提示");
                return;
            }
            //点击确定再继续执行，否则中断
            if (MessageBox.Show("检查下参数设置，确认执行请点击OK？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }
            //检查导入的数据有效性
            //for (int i = 0; i < dsImportData.Tables[0].Rows.Count; i++)
            //{
            //    //学号
            //    string xh = dataGridView1[0, i].Value.ToString().Trim();
            //    //姓名
            //    string xm = dataGridView1[1, i].Value.ToString().Trim();
            //    //异动后年级
            //    string ydh_njdm = dataGridView1[2, i].Value.ToString().Trim();
            //    //异动后班级名
            //    string ydh_bjm = dataGridView1[3, i].Value.ToString().Trim();
            //    //异动后方向名
            //    string ydh_fxm = dataGridView1[4, i].Value.ToString().Trim();
            //    //异动后学籍状态名
            //    string ydh_xjztm = dataGridView1[5, i].Value.ToString().Trim();                
            //}
            //MessageBox.Show("test！" + tt ,"提示");

            //获取当前学年学期代码
            string zxjxjhh_sql = "select PARAM_VALUE from sys_param where PARAM_ID='当前执行教学计划号'";
            string zxjxjhh = myUtilities.GetOracleStr(zxjxjhh_sql);
            //获取异动类型代码
            string ydlxdm = CmbYdlx.SelectedValue.ToString();
            //获取异动时间
            string ydrq = txbYdrq.Text;
            //获取异动原因代码
            string ydyydm = CmbYdyy.SelectedValue.ToString();
            //学籍表sql
            string update_xjb_sql = string.Empty;
            //学籍异动表sql
            string inert_xjydb_sql = string.Empty;
            //学期学分券异动表sql
            string insert_xfqydb_sql = string.Empty;

            //循环处理数据
            for (int i = 0; i < dsImportData.Tables[0].Rows.Count; i++)
            {
                //学号
                string xh = dataGridView1[0, i].Value.ToString().Trim();
                //姓名
                string xm = dataGridView1[1, i].Value.ToString().Trim();
                //异动后年级
                string ydh_njdm = dataGridView1[2, i].Value.ToString().Trim();
                //异动后班级名
                string ydh_bjm = dataGridView1[3, i].Value.ToString().Trim();
                //异动后方向名
                string ydh_fxm = dataGridView1[4, i].Value.ToString().Trim();
                //异动后学籍状态名
                string ydh_xjztm = dataGridView1[5, i].Value.ToString().Trim();
                //备注，对于批量异动，此备注更新“异动文号”字段
                string ydwh = dataGridView1[6, i].Value.ToString().Trim();

                //去掉字符前后的空格
                xh = xh.Trim();
                xm = xm.Trim();
                ydh_fxm = ydh_fxm.Trim();
                //ydh_njdm = ydh_njdm.Trim();
                ydh_bjm = ydh_bjm.Trim();
                ydh_xjztm = ydh_xjztm.Trim();

                //获取需写入的数据项的值
                //原年级
                string xj_njdm = string.Empty;
                //原学院代码
                string xj_xsh = string.Empty;
                //原专业代码
                string xj_zyh = string.Empty;
                //原专业方向代码
                string xj_zyfxh = string.Empty;
                //原班级代码
                string xj_bjh = string.Empty;
                //原预计毕业日期
                string xj_yjbyrq = string.Empty;
                //原学籍状态代码
                string xj_xjztdm = string.Empty;
                //原校区代码
                string xj_xqh = string.Empty;
                //原是否有学籍
                string xj_sfyxj = string.Empty;
                //原是否有国家学籍
                string xj_sfygjxj = string.Empty;
                //原学制类型代码
                string xj_xzlxdm = string.Empty;
                //异动后专业方向代码
                string ydh_zyfxh = string.Empty;
                //异动后班级代码
                string ydh_bjh = string.Empty;
                //异动后学院代码
                string ydh_xsh = string.Empty;
                //异动后专业代码
                string ydh_zyh = string.Empty;
                //本机IPv4地址
                string myIPv4 = string.Empty;
                //本机MAC地址
                string myMac = string.Empty;
                //获取IP和MAC
                myUtilities.GetActiveIpAndMac(out myMac, out myIPv4);
                //异动后预计毕业日期
                string ydh_yjbyrq = string.Empty;

                //原学籍信息sql
                string xj_info_sql = "select njdm,xsh,zyh,zyfxh,bjh,yjbyrq,xjztdm,xqh,sfyxj,sfygjxj,xzlxdm from xs_xjb where xh='" + xh + "'";
                OracleDataReader xjDataReader = myUtilities.DbReader(xj_info_sql);
                while (xjDataReader.Read())
                {
                    xj_njdm = xjDataReader["njdm"].ToString();
                    xj_xsh = xjDataReader["xsh"].ToString();
                    xj_zyh = xjDataReader["zyh"].ToString();
                    xj_zyfxh = xjDataReader["zyfxh"].ToString();
                    xj_bjh = xjDataReader["bjh"].ToString();
                    xj_yjbyrq = xjDataReader["yjbyrq"].ToString();
                    xj_xjztdm = xjDataReader["xjztdm"].ToString();
                    xj_xqh = xjDataReader["xqh"].ToString();
                    xj_sfyxj = xjDataReader["sfyxj"].ToString();
                    xj_sfygjxj = xjDataReader["sfygjxj"].ToString();
                    xj_xzlxdm = xjDataReader["xzlxdm"].ToString();
                }
                xjDataReader.Close();

                //检查导入的数据有效性
                //数据当前行数
                int DataRowNumber = i + 1;
                //校验学号和姓名，不同异动都需要校验
                string checksql_xh = "select xm from xs_xjb where xh='" + xh + "'";
                if (myUtilities.GetOracleStr(checksql_xh) != xm)
                {
                    MessageBox.Show("数据校验失败！数据中的第=" + DataRowNumber + "=行学号和姓名不符！", "提示");
                    break;
                }
                //导入数据中“异动后专业方向名”字段不为空，检验现专业方向
                if (ydh_fxm != string.Empty)
                {
                    string checksql_xzyfx = "select count(*) from code_zyfxb where zyfxm='" + ydh_fxm + "'";
                    if (myUtilities.GetOracleCount(checksql_xzyfx) == 0)
                    {
                        MessageBox.Show("数据校验失败！数据中的第=" + DataRowNumber + "=行现专业方向在系统中不存在！", "提示");
                        break;
                    }
                }
                //导入数据中“异动后年级”字段不为空，检验现年级
                if (ydh_njdm != string.Empty)
                {
                    string checksql_xnjdm = "select count(*) from code_njb where njdm='" + ydh_njdm + "'";
                    if (myUtilities.GetOracleCount(checksql_xnjdm) == 0)
                    {
                        MessageBox.Show("数据校验失败！数据中的第=" + DataRowNumber + "=行现年级在系统中不存在！", "提示");
                        break;
                    }
                }
                //导入数据中“异动后班名”字段不为空，检验现班名
                if (ydh_bjm != string.Empty)
                {
                    string checksql_xbjm = "select count(*) from code_bjb where bm='" + ydh_bjm + "'";
                    if (myUtilities.GetOracleCount(checksql_xbjm) == 0)
                    {
                        MessageBox.Show("数据校验失败！数据中的第=" + DataRowNumber + "=行现班名在系统中不存在！", "提示");
                        break;
                    }
                }
                //导入数据中“异动后学籍状态名”字段不为空，检验学籍状态名
                if (ydh_xjztm != string.Empty)
                {
                    string countsql_xjztm = "select count(*) from code_xjztb where xjztsm='" + ydh_xjztm + "'";
                    if (myUtilities.GetOracleCount(countsql_xjztm) == 0)
                    {
                        MessageBox.Show("数据校验失败！数据中的第=" + DataRowNumber + "=行学籍状态名在系统中不存在！", "提示");
                        break;
                    }
                }

                //异动后bjh,xsh,zyh的sql
                if (ydh_bjm != string.Empty)
                {
                    string ydh_xj_info_sql = "select rxnj,bjh,xsh,zyh from code_bjb where bm='" + ydh_bjm + "'";
                    OracleDataReader myDataReader = myUtilities.DbReader(ydh_xj_info_sql);
                    while (myDataReader.Read())
                    {
                        ydh_njdm = myDataReader["rxnj"].ToString();
                        ydh_bjh = myDataReader["bjh"].ToString();
                        ydh_xsh = myDataReader["xsh"].ToString();
                        ydh_zyh = myDataReader["zyh"].ToString();                    
                    }
                    myDataReader.Close();
                }

                //异动后专业方向代码sql
                if (ydh_fxm != string.Empty)
                {
                    string ydh_zyfxh_sql = "select zyfxh from code_zyfxb where zyfxm='" + ydh_fxm + "' and xsh='" + ydh_xsh + "' and zyh='" + ydh_zyh + "'";
                    ydh_zyfxh = myUtilities.GetOracleStr(ydh_zyfxh_sql);
                }

                //获取当前学籍状态名
                string checksql_xjztm = "select xjztdm from code_xjztb where xjztsm='" + ydh_xjztm + "'";
                //根据学籍异动不同类型进行处理
                switch (ydlxdm)
                {
                    //保留学籍：sfyxj-否，sfygjxj-是，xjztdm-18
                    case "19":                        
                        if (myUtilities.GetOracleStr(checksql_xjztm) != "18")
                        {
                            MessageBox.Show("数据校验失败！数据中的第=" + DataRowNumber + "=行学籍状态已经是“保留学籍”！", "提示");
                            break;
                        }
                        else
                        {
                            update_xjb_sql = "update xs_xjb set ydf='是',sfyxj='否',sfygjxj='是',xjztdm='18' where xh='" + xh + "'";
                            inert_xjydb_sql = "insert into xs_xjydb(xh,ydrq,yddm,ydwh,ydyydm,ynjdm,yxsh,yzyh,yzyfxh,ybjh,yyjbyrq,yxjztdm,yxqh,ysfyxj,ysfygjxj,yxzlxdm,ydhnjdm,ydhxsh,ydhzyh,ydhzyfxh,ydhbjh,ydhyjbyrq,ydhxqh,ydhsfyxj,ydhsfygjxj) values ('" + xh + "','" + ydrq + "','" + ydlxdm + "','" + ydwh + "','" + ydyydm + "','" + xj_njdm + "','" + xj_xsh + "','" + xj_zyh + "','" + xj_zyfxh + "','" + xj_bjh + "','" + xj_yjbyrq + "','" + xj_xjztdm + "','" + xj_xqh + "','" + xj_sfyxj + "','" + xj_sfygjxj + "','" + xj_xzlxdm + "','" + xj_njdm + "','" + xj_xsh + "','" + xj_zyh + "','" + xj_zyfxh + "','" + xj_bjh + "','" + xj_yjbyrq + "','" + xj_xqh + "','" + xj_sfyxj + "','" + xj_sfygjxj + "')";
                        }
                        
                        break;
                    //转专业：
                    //xjb —— xsh,zyh,zyfxh,bjh
                    case "22":
                        if (ydh_njdm != string.Empty)
                        {
                            //对于没有异动后年级的，默认预计毕业日期不变。
                            //但是对于需要变更年级的，理论上应该是“异动后年级+4”计算出毕业年份
                            //然后预计毕业日期应该是“毕业年份连接0630”
                            int bynf = Convert.ToInt32(ydh_njdm) + 4;
                            ydh_yjbyrq = bynf  + "0630";
                        }
                        else
                        {
                            ydh_yjbyrq = xj_yjbyrq;
                        }
                        if (ydh_fxm != string.Empty)
                        {
                            update_xjb_sql = "update xs_xjb set ydf='是',xsh='" + ydh_xsh + "',zyh='" + ydh_zyh + "',zyfxh='" + ydh_zyfxh + "',bjh='" + ydh_bjh + "',njdm='"+ ydh_njdm  + "',yjbyrq='" + ydh_yjbyrq + "' where xh='" + xh + "'";
                            inert_xjydb_sql = "insert into xs_xjydb(xh,ydrq,yddm,ydwh,ydyydm,ynjdm,yxsh,yzyh,yzyfxh,ybjh,yyjbyrq,yxjztdm,yxqh,ysfyxj,ysfygjxj,yxzlxdm,ydhnjdm,ydhxsh,ydhzyh,ydhzyfxh,ydhbjh,ydhyjbyrq,ydhxqh,ydhsfyxj,ydhsfygjxj) values ('" + xh + "','" + ydrq + "','" + ydlxdm + "','" + ydwh + "','" + ydyydm + "','" + xj_njdm + "','" + xj_xsh + "','" + xj_zyh + "','" + xj_zyfxh + "','" + xj_bjh + "','" + xj_yjbyrq + "','" + xj_xjztdm + "','" + xj_xqh + "','" + xj_sfyxj + "','" + xj_sfygjxj + "','" + xj_xzlxdm + "','" + ydh_njdm + "','" + ydh_xsh + "','" + ydh_zyh + "','" + ydh_zyfxh + "','" + ydh_bjh + "','" + ydh_yjbyrq + "','" + xj_xqh + "','" + xj_sfyxj + "','" + xj_sfygjxj + "')";
                        }
                        else
                        {
                            update_xjb_sql = "update xs_xjb set ydf='是',xsh='" + ydh_xsh + "',zyh='" + ydh_zyh + "',zyfxh='',bjh='" + ydh_bjh + "',njdm='" + ydh_njdm + "',yjbyrq='" + ydh_yjbyrq + "' where xh='" + xh + "'";
                            inert_xjydb_sql = "insert into xs_xjydb(xh,ydrq,yddm,ydwh,ydyydm,ynjdm,yxsh,yzyh,yzyfxh,ybjh,yyjbyrq,yxjztdm,yxqh,ysfyxj,ysfygjxj,yxzlxdm,ydhnjdm,ydhxsh,ydhzyh,ydhzyfxh,ydhbjh,ydhyjbyrq,ydhxqh,ydhsfyxj,ydhsfygjxj) values ('" + xh + "','" + ydrq + "','" + ydlxdm + "','" + ydwh + "','" + ydyydm + "','" + xj_njdm + "','" + xj_xsh + "','" + xj_zyh + "','" + xj_zyfxh + "','" + xj_bjh + "','" + xj_yjbyrq + "','" + xj_xjztdm + "','" + xj_xqh + "','" + xj_sfyxj + "','" + xj_sfygjxj + "','" + xj_xzlxdm + "','" + ydh_njdm + "','" + ydh_xsh + "','" + ydh_zyh + "','','" + ydh_bjh + "','" + ydh_yjbyrq + "','" + xj_xqh + "','" + xj_sfyxj + "','" + xj_sfygjxj + "')";
                        }
                        string czsj = string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
                        insert_xfqydb_sql = "insert into xfsf_xqxfq_yd(zxjxjhh,xh,ydlx,ydsj,czr,czsj,czip,czmac,clbj) values ('" + zxjxjhh + "','" + xh + "','" + ydlxdm + "','" + ydrq + "','root','" + czsj + "','" + myIPv4 + "','" + myMac + "',0)";
                        break;
                    //转班
                    case "34":
                        goto case "22";
                    //break;
                    //降级
                    case "8":
                        goto case "22";
                    //break;
                    //跳级
                    case "9":
                        goto case "22";
                    //break;
                    //放弃入学资格
                    case "5":
                        if (myUtilities.GetOracleStr(checksql_xjztm) != "20")
                        {
                            MessageBox.Show("数据校验失败！数据中的第=" + DataRowNumber + "=行学籍状态已经是“放弃入学资格”！", "提示");
                            break;
                        }
                        else
                        {
                            update_xjb_sql = "update xs_xjb set ydf='是',sfyxj='否',sfygjxj='否',xjztdm='20' where xh='" + xh + "'";
                            inert_xjydb_sql = "insert into xs_xjydb(xh,ydrq,yddm,ydwh,ydyydm,ynjdm,yxsh,yzyh,yzyfxh,ybjh,yyjbyrq,yxjztdm,yxqh,ysfyxj,ysfygjxj,yxzlxdm,ydhnjdm,ydhxsh,ydhzyh,ydhzyfxh,ydhbjh,ydhyjbyrq,ydhxqh,ydhsfyxj,ydhsfygjxj) values ('" + xh + "','" + ydrq + "','" + ydlxdm + "','" + ydwh + "','" + ydyydm + "','" + xj_njdm + "','" + xj_xsh + "','" + xj_zyh + "','" + xj_zyfxh + "','" + xj_bjh + "','" + xj_yjbyrq + "','" + xj_xjztdm + "','" + xj_xqh + "','" + xj_sfyxj + "','" + xj_sfygjxj + "','" + xj_xzlxdm + "','" + xj_njdm + "','" + xj_xsh + "','" + xj_zyh + "','" + xj_zyfxh + "','" + xj_bjh + "','" + xj_yjbyrq + "','" + xj_xqh + "','否','否')";
                        }
                        break;
                    default:
                        MessageBox.Show("未定义的异动类型！", "提示");
                        break;
                }

                //循环执行，每行数据都执行一次sql。
                //循环结束后，统一提交。
                try
                {
                    if (insert_xfqydb_sql == string.Empty)
                    {
                        myUtilities.ExeOracleSql(update_xjb_sql);
                        myUtilities.ExeOracleSql(inert_xjydb_sql);
                    }
                    else
                    {
                        myUtilities.ExeOracleSql(update_xjb_sql);
                        myUtilities.ExeOracleSql(inert_xjydb_sql);
                        myUtilities.ExeOracleSql(insert_xfqydb_sql);
                    }
                }
                catch (System.Exception ex)
                {
                    string rollbackStr = "rollback";
                    myUtilities.ExeOracleSql(rollbackStr);
                    MessageBox.Show("更新数据时发生错误：" + ex.Message, "提示");
                }

            }

            //统一提交
            try
            {
                string commitStr = "commit";
                myUtilities.ExeOracleSql(commitStr);
                ToolStripStatusLabel statusStrip = ((MDIForm)(this.MdiParent)).toolStripStatusLabel1;
                statusStrip.Text = "数据更新完毕";
                MessageBox.Show("数据更新完毕！" , "提示");
                //清空导入的待处理数据框
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

        private void XjydForm_Load(object sender, EventArgs e)
        {
            try
            {
                 //只支持：转专业，转班，降级，跳级，保留学籍
                string ydlbstr = "select '000' as yddm, '----请选择----' as ydlb  from code_ydlb union select yddm, ydlb from code_ydlb where yddm='22' or yddm='34' or yddm='8' or yddm='9' or yddm='19' or yddm='5'";
                //DataSet ydlbds = myUtilities.GetOracleDataSet(ydlbstr);
                CmbYdlx.DisplayMember = "YDLB";
                CmbYdlx.ValueMember = "YDDM";
                CmbYdlx.DataSource = myUtilities.GetOracleDataSet(ydlbstr).Tables[0];
                CmbYdlx.SelectedValue = "000";

                string ydyystr = "select '000' as ydyydm, '----请选择----' as ydyysm from code_ydlb union select ydyydm,ydyysm from code_ydyyb";
                //DataSet ydyyds = myUtilities.GetOracleDataSet(ydyystr);
                CmbYdyy.DisplayMember = "YDYYSM";
                CmbYdyy.ValueMember = "YDYYDM";
                CmbYdyy.DataSource = myUtilities.GetOracleDataSet(ydyystr).Tables[0];
                CmbYdyy.SelectedValue = "000";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("界面载入出错：" + ex.Message, "提示");
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

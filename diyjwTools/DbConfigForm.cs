using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace diyjwTools
{
    public partial class DbConfigForm : Form
    {
        public DbConfigForm()
        {
            InitializeComponent();
        }

        //定义
        private diyjwToolsClassLibrary.Utilities myUtilities = new diyjwToolsClassLibrary.Utilities();
        private string oracleConfig = string.Empty;
        private bool IsCanConnectioned = false;

        private void BtnTestConn_Click(object sender, EventArgs e)
        {
            //string oracleConfig = "Data Source=jwrac;User Id=newjw;Password=qrUqi-4wp|2QNmO;";
            //TxbServiceID
            //TxbInstanceID
            //TxbDbPwd
            oracleConfig = "Data Source=" + TxbServiceID.Text + ";User Id=" + TxbInstanceID.Text + ";Password=" + TxbDbPwd.Text + ";";
            ConnectionTest(oracleConfig);
        }

        private void BtnSaveConfig_Click(object sender, EventArgs e)
        {
            //ToolStripStatusLabel statusStrip = ((MDIForm)(this.MdiParent)).toolStripStatusLabel1;
            if (IsCanConnectioned)
            {
                string userKey = myUtilities.Encrypt(oracleConfig);
                myUtilities.SaveConfig(userKey, "ServiceID");
                //statusStrip.Text = "保存配置成功！";                
                if (MessageBox.Show("保存配置成功，点击“确认”将关闭该窗口", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //Form[] formsList = Application.OpenForms.Cast<Form>().Where(x => x.Name == "diyjwTools").ToArray();
                    //foreach (Form openForm in formsList)
                    //{
                    //    openForm.Close();
                    //}
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("请先点击“测试链接”按钮进行测试！", "提示");
            }
        }

        //服务名字段限制只能输入数字和字母，退格键
        private void TxbServiceID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
                || (e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //实例名字段限制只能输入数字和字母，退格键
        private void TxbInstanceID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
                || (e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
		/// 测试连接数据库是否成功
		/// </summary>
		/// <returns></returns>
		private void ConnectionTest(string OracleConnectionString)
        {
            //ToolStripStatusLabel statusStrip = ((MDIForm)(this.MdiParent)).toolStripStatusLabel1;
            //获取数据库连接字符串
            //ConnectionString = ConnectionInfo.ConnectionString();
            //创建连接对象
            OracleConnection myOracleConnection = new OracleConnection(OracleConnectionString);
            //ConnectionTimeout 在.net 1.x 可以设置 在.net 2.0后是只读属性，则需要在连接字符串设置
            //如：server=.;uid=sa;pwd=;database=PMIS;Integrated Security=SSPI; Connection Timeout=30
            //mySqlConnection.ConnectionTimeout = 1;//设置连接超时的时间
            try
            {
                //Open DataBase
                //打开数据库
                myOracleConnection.Open();
                IsCanConnectioned = true;
            }
            catch
            {
                //Can not Open DataBase
                //打开不成功 则连接不成功
                IsCanConnectioned = false;
            }
            finally
            {
                //Close DataBase
                //关闭数据库连接
                myOracleConnection.Close();
            }
            //mySqlConnection   is   a   SqlConnection   object
            if (IsCanConnectioned)
            {
                //statusStrip.Text = "测试成功！";
                MessageBox.Show("数据库连接测试成功！请点击“保存链接”按钮！", "提示");
            }
            else
            {
                //statusStrip.Text = "数据库连接不成功！";
                MessageBox.Show("数据库连接不成功！", "错误");                
            }
        }
        //
    }
}

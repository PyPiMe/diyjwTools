using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Management;
using System.IO;
using System.Data;
using System.Data.OleDb;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Net;
using System.Net.NetworkInformation;
using Excel = Microsoft.Office.Interop.Excel;
using System.Security.Cryptography;
using System.Xml;
using System.Configuration;

namespace diyjwToolsClassLibrary
{
    public class Utilities
    {
        public Utilities()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 获取当前激活网络的MAC地址、IPv4地址、IPv6地址
        /// 此方法获取的MAC地址格式为XX-XX-XX-XX-XX-XX，IP地址格式为XXX.XXX.XXX.XXX
        /// 使用此方法需添加引用：System.Net.NetworkInformation
        /// 用法如下——
        /// string mac;
        /// string ipv4;
        /// string ipv6;
        /// NetworkHelper.GetActiveIpAndMac(out mac, out ipv4, out ipv6);
        /// Console.WriteLine("mac:" + mac);
        /// Console.WriteLine("ipv4:" + ipv4);
        /// Console.WriteLine("ipv6:" + ipv6);
        /// </summary>
        /// <param name="mac">网卡物理地址</param>
        /// <param name="ipv4">IPv4地址</param>
        /// <param name="ipv6">IPv6地址</param>
        public void GetActiveIpAndMac(out string mac, out string ipv4)
        {
            mac = string.Empty;
            ipv4 = string.Empty;
            //ipv6 = string.Empty;

            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                UnicastIPAddressInformationCollection allAddress = adapterProperties.UnicastAddresses;
                if (allAddress.Count > 0)
                {
                    if (adapter.OperationalStatus == OperationalStatus.Up)
                    {
                        mac = adapter.GetPhysicalAddress().ToString();
                        foreach (UnicastIPAddressInformation addr in allAddress)
                        {
                            if (addr.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                ipv4 = addr.Address.ToString();
                            }
                            //if (addr.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                            //{
                            //    ipv6 = addr.Address.ToString();
                            //}
                        }

                        //if (string.IsNullOrWhiteSpace(mac) || (string.IsNullOrWhiteSpace(ipv4) && string.IsNullOrWhiteSpace(ipv6)))
                        if (string.IsNullOrWhiteSpace(mac) || string.IsNullOrWhiteSpace(ipv4))
                        {
                            mac = string.Empty;
                            ipv4 = string.Empty;
                            //ipv6 = string.Empty;
                            continue;
                        }
                        else
                        {
                            if (mac.Length == 12)
                            {
                                mac = string.Format("{0}-{1}-{2}-{3}-{4}-{5}",
                                    mac.Substring(0, 2), mac.Substring(2, 2), mac.Substring(4, 2),
                                    mac.Substring(6, 2), mac.Substring(8, 2), mac.Substring(10, 2));
                            }
                            break;
                        }
                    }
                }
            }
        }

        //Oracle 链接字符串
        private string OracleDbPath()
        {
            string oracleConfig = Decrypt(ConfigurationManager.AppSettings["ServiceID"]);            
            return oracleConfig;
        }

        private static string OracleConnectionString
        {
            get
            {
                Utilities OracleConnectionString = new Utilities();
                return OracleConnectionString.OracleDbPath();
            }
        }

        public int GetOracleCount(string Sql)
        {
            OracleConnection myConnection = new OracleConnection(Utilities.OracleConnectionString);
            OracleCommand myCommand = new OracleCommand(Sql, myConnection);
            myConnection.Open();
            OracleDataReader result = myCommand.ExecuteReader();
            int i = 0;
            while (result.Read())
            {
                i = result.GetInt32(0);
            }
            result.Close();
            myCommand.Dispose();
            myConnection.Close();
            return i;
        }

        public string GetOracleStr(string Sql)
        {
            OracleConnection myConnection = new OracleConnection(Utilities.OracleConnectionString);
            OracleCommand myCommand = new OracleCommand(Sql, myConnection);
            myConnection.Open();
            OracleDataReader result = myCommand.ExecuteReader();
            string mystr = string.Empty;
            while (result.Read())
            {
                mystr = result.GetString(0);
            }
            result.Close();
            myCommand.Dispose();
            myConnection.Close();
            return mystr;
        }

        public void ExeOracleSql(string Sql)
        {
            OracleConnection myConnection = new OracleConnection(Utilities.OracleConnectionString);
            OracleCommand myCommand = new OracleCommand(Sql, myConnection);
            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Dispose();
                myConnection.Close();
            }
            catch (System.Exception ex)
            {
                myConnection.Close();
                MessageBox.Show("更新数据时发生错误：" + ex.Message, "提示");
            }
        }


        public DataSet GetOracleDataSet(string Sql)
        {
            OracleConnection myConnection = new OracleConnection(Utilities.OracleConnectionString);
            DataSet ds = new DataSet();
            try
            {
                OracleDataAdapter myDataAdapter = new OracleDataAdapter(Sql, myConnection);
                myDataAdapter.Fill(ds);
            }
            catch (System.Exception ex)
            {
                myConnection.Close();
                MessageBox.Show("填充数据出错：" + ex.Message, "提示");
            }
            return ds;
        }

        public OracleDataReader DbReader(string strsql)
        {
            OracleConnection myConnection = new OracleConnection(Utilities.OracleConnectionString);
            OracleCommand myCommand = new OracleCommand(strsql, myConnection);
            myConnection.Open();
            return myCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
		/// 读取Excel文档
		/// </summary>
		/// <param name="Path">文件名称</param>
		/// <returns>返回一个数据集</returns>
		public DataSet ExcelToDS(string Path)
        {
            if (!File.Exists(Path))
            {
                MessageBox.Show("所选文件不存在！", "提示");
                return null;
            }
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Path + ";" + "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
            OleDbConnection conn = new OleDbConnection(strConn);
            string strExcel = String.Empty;
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            try
            {
                conn.Open();
                strExcel = "select * from [sheet1$]";
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                ds = new DataSet();
                myCommand.Fill(ds, "table1");
            }
            catch (OleDbException Err_My)
            {
                //statusBar1.Text = Err_My.Message.ToString();
                MessageBox.Show(Err_My.Message, "提示");
            }
            return ds;
        }
        //

        #region 加密解密
        /// <summary>
        /// 定义加密Key
        /// 加密密钥,要求为8位
        /// </summary>
        static readonly string encryptKey = "dummy";

        #region 加密字符串
        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>返回加密后的字符串</returns>
        public string Encrypt(string str)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();  //实例化加/解密类对象 
            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥,截取前8位
            byte[] data = Encoding.Unicode.GetBytes(str);//定义字节数组，用来存储要加密的字符串
            MemoryStream MStream = new MemoryStream();//实例化内存流对象    
                                                      //使用内存流实例化加密流对象 
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);
            CStream.Write(data, 0, data.Length);  //向加密流中写入数据    
            CStream.FlushFinalBlock();             //释放加密流    
            return Convert.ToBase64String(MStream.ToArray());//返回加密后的字符串
        }
        #endregion

        #region 解密字符串
        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="str">要解密的字符串</param>
        /// <returns>返回解密后的字符串</returns>
        public string Decrypt(string str)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();  //实例化加/解密类对象  
            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥,截取前8位 
            byte[] data = Convert.FromBase64String(str);//定义字节数组，用来存储要解密的字符串
            MemoryStream MStream = new MemoryStream();//实例化内存流对象    
                                                      //使用内存流实例化解密流对象     
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);
            CStream.Write(data, 0, data.Length);      //向解密流中写入数据   
            CStream.FlushFinalBlock();              //释放解密流    
            return Encoding.Unicode.GetString(MStream.ToArray());      //返回解密后的字符串
        }
        #endregion

        #endregion

        #region  保存App.config修改的设置
        /// <summary>
        /// 方法保存修改的设置
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="strKey"></param>
        /// 用法——
        /// SaveConfig("strValue","strKey");
        /// 如：SaveConfig("WWW-8CB7FB23DD4","Server");
        public void SaveConfig(string strValue, string strKey)
        {
            XmlDocument doc = new XmlDocument();
            //获得配置文件的全路径
            string strFileName = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            doc.Load(strFileName);
            //找出名称为“add”的所有元素
            XmlNodeList nodes = doc.GetElementsByTagName("add");
            for (int i = 0; i < nodes.Count; i++)
            {
                //获得将当前元素的key属性
                XmlAttribute att = nodes[i].Attributes["key"];
                //根据元素的第一个属性来判断当前的元素是不是目标元素
                if (att.Value == strKey)
                {
                    //对目标元素中的第二个属性赋值
                    att = nodes[i].Attributes["value"];
                    att.Value = strValue;
                    break;
                }
            }
            //保存上面的修改
            doc.Save(strFileName);
        }
        #endregion

        ///
    }
}

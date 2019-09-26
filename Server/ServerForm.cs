using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using Packet;
using ExcelDataReader;
//using Microsoft.Office.Interop.Excel;

namespace server
{
    public partial class ServerForm : Form
    {
        private string label1 = null;

        public Thread m_thServer = null;
        TcpListener m_listener;
        public ServerThread[] serverThreads = new ServerThread[10];
        public TcpClient[] hClient = new TcpClient[10];
        bool m_bStop;
        int index = 0;

        public ServerForm()
        {
            InitializeComponent();

            DirectoryInfo di = new DirectoryInfo(SendClass.filepath);
            if (!di.Exists)
                di.Create();

            for (int i = 0; i < 10; i++)
                serverThreads[i] = new ServerThread(this);

            this.m_thServer = new Thread(new ThreadStart(ServerStart));
            this.m_thServer.Start();
        }

        public void ServerStart()
        {
            m_listener = new TcpListener(IPAddress.Any, 7674);
            m_listener.Start();

            m_bStop = true;

            while (m_bStop)
            {
                TcpClient hClient = m_listener.AcceptTcpClient();
                
                if (hClient.Connected)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (!serverThreads[i].m_bConnect)
                        {
                            index = i; break;
                        }
                    }
                    serverThreads[index].m_bConnect = true;
                    serverThreads[index].m_Stream = hClient.GetStream();
                    serverThreads[index].m_Read = new StreamReader(serverThreads[index].m_Stream);
                    serverThreads[index].m_Write = new StreamWriter(serverThreads[index].m_Stream);
                    serverThreads[index].m_bRead = new BinaryReader(serverThreads[index].m_Stream);
                    serverThreads[index].m_bWrite = new BinaryWriter(serverThreads[index].m_Stream);

                    serverThreads[index].m_thReader = new Thread(new ThreadStart(serverThreads[index].Receive));
                    serverThreads[index].m_thReader.Start();
                }
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        public void setLabel(string label)
        {
            this.label1 = label;
            lab_ID.Text = label;
        }

        private void 보기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                if (serverThreads[i].m_bConnect)
                    serverThreads[i].m_thReader.Abort();
            m_listener.Stop();
            Application.Exit();
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                notifyIcon1.Visible = true;
                this.Hide();
                e.Cancel = true;
            }
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xls)|*.xls";
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                string filepath = openFileDialog.FileName;
                
                FileStream stream = File.Open(filepath, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(stream);
                DataSet1.TradeDataTable tradeRows = SendClass.GetTradeRows();
                DataSet result = excelReader.AsDataSet();
                for(int i = 1; i < result.Tables[0].Rows.Count; i++)
                {
                    DataRow dataRow = tradeRows.NewRow();
                    dataRow[0] = result.Tables[0].Rows[i][1];
                    string transaction = result.Tables[0].Rows[i][2].ToString();
                    
                    dataRow[1] = new DateTime(int.Parse(transaction.Substring(0,4)),
                        int.Parse(transaction.Substring(5,2)), int.Parse(transaction.Substring(8,2)));
                    string deadline = result.Tables[0].Rows[i][3].ToString();
                    dataRow[2] = new DateTime(int.Parse(deadline.Substring(0, 4)),
                        int.Parse(deadline.Substring(5, 2)), int.Parse(deadline.Substring(8, 2)));
                    dataRow[3] = result.Tables[0].Rows[i][5];
                    dataRow[4] = result.Tables[0].Rows[i][6];
                    dataRow[5] = result.Tables[0].Rows[i][7];
                    dataRow[6] = result.Tables[0].Rows[i][8];
                    dataRow[7] = result.Tables[0].Rows[i][9];
                    dataRow[8] = int.Parse(result.Tables[0].Rows[i][10].ToString());
                    dataRow[9] = int.Parse(result.Tables[0].Rows[i][11].ToString());
                    dataRow[10] = result.Tables[0].Rows[i][12];
                    string inspection = result.Tables[0].Rows[i][13].ToString();
                    if (inspection.Length > 0)
                        dataRow[11] = new DateTime(int.Parse(inspection.Substring(0, 4)),
                            int.Parse(inspection.Substring(5, 2)), int.Parse(inspection.Substring(8, 2)));
                    else
                        dataRow[11] = new DateTime();
                    string bill = result.Tables[0].Rows[i][14].ToString();
                    if (bill.Length > 0)
                        dataRow[12] = new DateTime(int.Parse(bill.Substring(0, 4)),
                            int.Parse(bill.Substring(5, 2)), int.Parse(bill.Substring(8, 2)));
                    else
                        dataRow[12] = new DateTime();
                    dataRow[13] = new DateTime();
                    dataRow[14] = result.Tables[0].Rows[i][15];
                    dataRow[15] = int.Parse(result.Tables[0].Rows[i][0].ToString());
                    tradeRows.Rows.Add(dataRow);
                }
                tradeRows.WriteXml(SendClass.filepath + "trade_data.xml");
            }
        }
    }

    public class ServerThread
    {
        private ServerForm serverForm;

        public BinaryFormatter bf = new BinaryFormatter();
        public NetworkStream m_Stream;
        public StreamReader m_Read;
        public StreamWriter m_Write;
        public BinaryWriter m_bWrite;
        public BinaryReader m_bRead;
        public MemoryStream ms;
        public bool m_bConnect = false;
        public Thread m_thReader = null;

        private byte[] sendBuffer;
        private byte[] readBuffer;

        private Trade trade;
        private User user;
        DirectoryInfo dir;

        public ServerThread(ServerForm serverForm)
        {
            this.serverForm = serverForm;
        }

        public void Receive()
        {
            string Request;
            while (m_bConnect)
            {
                Request = m_Read.ReadLine();
                if (Request.Equals("View"))
                {
                    try
                    {
                        DataRow[] dataRows = SendClass.getAllRows();
                        int num = dataRows.Length;
                        m_Write.WriteLine("View");
                        m_Write.WriteLine(num.ToString());

                        Trade[] trades = new Trade[num];

                        for (int i = 0; i < num; i++)
                        {
                            if (trades[i] == null)
                                trades[i] = new Trade();
                            trades[i].category = dataRows[i][0].ToString();
                            trades[i].transaction = (DateTime)dataRows[i][1];
                            trades[i].deadline = (DateTime)dataRows[i][2];
                            trades[i].orderer = dataRows[i][3].ToString();
                            trades[i].demander = dataRows[i][4].ToString();
                            trades[i].contents = dataRows[i][5].ToString();
                            trades[i].product = dataRows[i][6].ToString();
                            trades[i].OS = dataRows[i][7].ToString();
                            trades[i].quantity = int.Parse(dataRows[i][8].ToString());
                            trades[i].price = int.Parse(dataRows[i][9].ToString());
                            trades[i].manager = dataRows[i][10].ToString();
                            trades[i].inspection = (DateTime)dataRows[i][11];
                            trades[i].bill = (DateTime)dataRows[i][12];
                            trades[i].modify = (DateTime)dataRows[i][13];
                            trades[i].registrar = dataRows[i][14].ToString();
                            trades[i].number = (int)dataRows[i][15];
                        }
                        MemoryStream ms = new MemoryStream();
                        bf.Serialize(ms, trades);
                        sendBuffer = ms.ToArray();
                        m_Write.WriteLine(sendBuffer.Length.ToString());
                        m_Write.Flush();
                        Send();
                    }
                    catch (Exception e)
                    {
                        serverForm.Invoke(new System.Action(delegate ()
                        {
                            MessageBox.Show(e.ToString(), "Exception occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                }
                if (Request.Equals("Import"))
                {
                    trade = new Trade();
                    int size = int.Parse(m_Read.ReadLine());
                    readBuffer = new byte[size];
                    m_bRead.Read(readBuffer, 0, size);

                    try
                    {
                        MemoryStream ms = new MemoryStream(readBuffer);
                        ms.Position = 0;
                        trade = (Trade)bf.Deserialize(ms);
                        SendClass.importTrade(this.trade);
                    }
                    catch (Exception e)
                    {
                        serverForm.Invoke(new System.Action(delegate ()
                        {
                            MessageBox.Show(e.ToString(), "Exception occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                }
                else if (Request.Equals("Login"))
                {
                    user = new User();
                    try
                    {
                        DataSet1.UserDataTable userRows = new DataSet1.UserDataTable();
                        try
                        {
                            userRows.ReadXml(SendClass.filepath + "user_data.xml");
                        }
                        catch (FileNotFoundException)
                        {
                            userRows.WriteXml(SendClass.filepath + "user_data.xml");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString(), "Exception occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        user.id = m_Read.ReadLine();
                        user.password = m_Read.ReadLine();

                        string query = "id=\'" + user.id + "\' AND password=\'" + user.password + "\'";
                        DataRow[] dataRow = userRows.Select(query);

                        if (dataRow.Length == 0)
                        {
                            m_Write.WriteLine("None");
                            m_Write.Flush();
                        }
                        else
                        {
                            m_Write.WriteLine("Login");
                            m_Write.WriteLine(dataRow[0][0].ToString());
                            m_Write.Flush();
                        }
                    }
                    catch (Exception e)
                    {
                        serverForm.Invoke(new System.Action(delegate ()
                        {
                            MessageBox.Show(e.ToString(), "Exception occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                }
                else if (Request.Equals("Modify"))
                {
                    try
                    {
                        int number = int.Parse(m_Read.ReadLine());
                        string inspect = m_Read.ReadLine();
                        string bill = m_Read.ReadLine();
                        DateTime date_inspect = new DateTime(int.Parse(inspect.Substring(0, 4)), int.Parse(inspect.Substring(5, 2))
                            , int.Parse(inspect.Substring(8, 2)));
                        DateTime date_bill = new DateTime(int.Parse(bill.Substring(0, 4)), int.Parse(bill.Substring(5, 2))
                            , int.Parse(bill.Substring(8, 2)));

                        SendClass.Modify(number, date_inspect, date_bill);
                    }
                    catch(Exception e)
                    {
                        serverForm.Invoke(new System.Action(delegate
                        {
                            MessageBox.Show(e.ToString(), "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                }
                else if (Request.Equals("Resource"))
                {
                    int number = int.Parse(m_Read.ReadLine());
                    dir = new DirectoryInfo(SendClass.filepath + '/' + number.ToString());
                    if (!dir.Exists)
                        dir.Create();
                    FileInfo[] fileInfos = dir.GetFiles();

                    int filenum = fileInfos.Length;
                    m_Write.WriteLine("Resource");
                    m_Write.WriteLine(filenum.ToString());
                    for (int i = 0; i < fileInfos.Length; i++)
                        m_Write.WriteLine(fileInfos[i].Name);
                    m_Write.Flush();
                }
                else if (Request.Equals("Delete"))
                {
                    int number = int.Parse(m_Read.ReadLine());
                    SendClass.Delete(number);
                }
                else if (Request.Equals("DeleteFile"))
                {
                    int number = int.Parse(m_Read.ReadLine());
                    string name = m_Read.ReadLine();
                    string path = SendClass.filepath + number.ToString() + '/' + name;

                    FileInfo file = new FileInfo(path);
                    file.Delete();
                }
                else if (Request.Equals("Upload"))
                {
                    int number = int.Parse(m_Read.ReadLine());
                    string name = m_Read.ReadLine();
                    string path = SendClass.filepath + number.ToString() + '/' + name;
                    int size = int.Parse(m_Read.ReadLine());
                    readBuffer = new byte[size];
                    m_bRead.Read(readBuffer, 0, size);

                    FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                    fileStream.Write(readBuffer, 0, size);
                    fileStream.Close();
                }
                else if (Request.Equals("Download"))
                {
                    string path = m_Read.ReadLine();
                    try
                    {
                        FileInfo fileInfo = new FileInfo(SendClass.filepath + path);
                        FileStream fileStream = new FileStream(SendClass.filepath + path, FileMode.Open, FileAccess.Read);

                        BinaryReader br = new BinaryReader(fileStream);
                        sendBuffer = br.ReadBytes((int)fileInfo.Length);

                        m_Write.WriteLine("Download");
                        m_Write.WriteLine(fileInfo.Length.ToString());
                        m_Write.Flush();

                        m_bWrite.Write(sendBuffer);
                        m_bWrite.Flush();
                        fileStream.Close();
                    }
                    catch(Exception e)
                    {
                        serverForm.Invoke(new Action(delegate
                        {
                            MessageBox.Show(e.ToString());
                        }));
                    }
                }
                else if (Request.Equals("Disconnect"))
                    break;
            }
            m_bConnect = false;
        }

        public void Send()
        {
            this.m_bWrite.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_bWrite.Flush();

            sendBuffer = null;
        }
    }


    public class SendClass {
        public static string filepath = "C:/Users/" + (System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1] + "/SimpleERP/";

        public static DataSet1.TradeDataTable GetTradeRows()
        {
            DataSet1.TradeDataTable tradeRows = new DataSet1.TradeDataTable();
            try
            {
                tradeRows.ReadXml(filepath + "trade_data.xml");
            }
            catch (FileNotFoundException)
            {
                tradeRows.WriteXml(filepath + "trade_data.xml");
            }
            catch (Exception)
            {
                return null;
            }
            return tradeRows;
        }
        public static DataRow[] getAllRows()
        {
            DataSet1.TradeDataTable tradeRows = GetTradeRows();
            return tradeRows.Select();
        }

        public static void Modify(int number, DateTime ins, DateTime bill)
        {
            DataSet1.TradeDataTable tradeRows = GetTradeRows();
            DataRow[] dataRows = tradeRows.Select();
            int i;
            for(i = 0; i < dataRows.Length; i++)
            {
                if ((int)dataRows[i][15] == number)
                    break;
            }
            tradeRows.Rows[i][11] = ins;
            tradeRows.Rows[i][12] = bill;
            tradeRows.Rows[i][13] = DateTime.Now;
            tradeRows.AcceptChanges();
            tradeRows.WriteXml(filepath + "trade_data.xml");
        }

        public static void Delete(int number)
        {
            DataSet1.TradeDataTable tradeRows = GetTradeRows();
            DataRow[] dataRows = tradeRows.Select();
            int i;
            for (i = 0; i < dataRows.Length; i++)
            {
                if ((int)dataRows[i][15] == number)
                    break;
            }
            tradeRows.Rows[i].Delete();
            tradeRows.AcceptChanges();
            tradeRows.WriteXml(filepath + "trade_data.xml");
        }

        public static void importTrade(Trade trade)
        {
            DataSet1.TradeDataTable tradeRows = GetTradeRows();
            DataRow[] dataRows = tradeRows.Select();
            int number = 0;
            if (dataRows.Length > 0)
            {
                int size = dataRows.Length;
                for (int i = 0; i < size; i++)
                {
                    if ((int)dataRows[i][15] > number)
                        number = (int)dataRows[i][15];
                }
                number++;
            }
            DataRow dataRow = tradeRows.NewRow();
            dataRow[0] = trade.category;
            dataRow[1] = trade.transaction;
            dataRow[2] = trade.deadline;
            dataRow[3] = trade.orderer;
            dataRow[4] = trade.demander;
            dataRow[5] = trade.contents;
            dataRow[6] = trade.product;
            dataRow[7] = trade.OS;
            dataRow[8] = trade.quantity;
            dataRow[9] = trade.price;
            dataRow[10] = trade.manager;
            dataRow[11] = trade.inspection;
            dataRow[12] = trade.bill;
            dataRow[13] = trade.modify;
            dataRow[14] = trade.registrar;
            dataRow[15] = number;
            tradeRows.Rows.Add(dataRow);
            tradeRows.WriteXml(filepath + "trade_data.xml");

            DirectoryInfo di = new DirectoryInfo(filepath + '/' + dataRow[15].ToString());
            if (!di.Exists)
                di.Create();
            else
            {
                di.Delete(true);
                di.Create();
            }

            return;
        }
    }
}
using System;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Packet;

namespace Client
{
    public partial class ClientForm : Form
    {
        BinaryFormatter bf = new BinaryFormatter();
        NetworkStream m_Stream;
        TcpClient m_Client;
        StreamReader m_Read;
        StreamWriter m_Write;
        BinaryWriter m_bWrite;
        BinaryReader m_bRead;
        private byte[] sendBuffer;
        private byte[] readBuffer;
        private Thread m_thReader;
        bool m_bConnect;
        public static string ip;

        public User user;

        ViewForm viewForm;
        ResourceDialog resource;

        public ClientForm()
        {
            InitializeComponent();
            viewForm = new ViewForm(this);
            viewForm.TopLevel = false;
            viewForm.Show();
            splitContainer1.Panel2.Controls.Add(viewForm);

            IPForm iPForm = new IPForm();
            DialogResult dialogResult = iPForm.ShowDialog();

            Connect();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            ImportForm importForm = new ImportForm(this);
            importForm.TopLevel = false;
            importForm.Show();
            splitContainer1.Panel2.Controls.Add(importForm);
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            viewForm = new ViewForm(this);
            viewForm.TopLevel = false;
            viewForm.Show();
            splitContainer1.Panel2.Controls.Add(viewForm);

            m_Write.WriteLine("View");
            m_Write.Flush();
        }

        public void Click_View()
        {
            btnView.PerformClick();
        }

        public void Connect()
        {
            m_Client = new TcpClient();
            try
            {
                m_Client.Connect(IPAddress.Parse(ip), 7674);
            }
            catch
            {
                MessageBox.Show("서버 IP주소를 확인하세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_bConnect = false;
                Application.Exit();
            }
            m_bConnect = true;

            m_Stream = m_Client.GetStream();

            m_Read = new StreamReader(m_Stream);
            m_Write = new StreamWriter(m_Stream);
            m_bRead = new BinaryReader(m_Stream);
            m_bWrite = new BinaryWriter(m_Stream);

            LoginForm loginForm = new LoginForm(this);
            DialogResult result = loginForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                m_thReader = new Thread(new ThreadStart(Receive));
                m_thReader.Start();
            }
        }

        private void Receive()
        {
            m_Write.WriteLine("View");
            m_Write.Flush();
            string receive;
            while (m_bConnect)
            {
                receive = m_Read.ReadLine();
                if (receive.Equals("View"))
                {
                    try
                    {
                        int num = int.Parse(m_Read.ReadLine());
                        int size = int.Parse(m_Read.ReadLine());

                        readBuffer = new byte[size];

                        Trade[] trades = new Trade[num];
                        m_bRead.Read(readBuffer, 0, size);
                        MemoryStream ms = new MemoryStream(readBuffer);
                        ms.Position = 0;
                        trades = (Trade[])bf.Deserialize(ms);
                        for (int i = 0; i < num; i++)
                            viewForm.AddRow(trades[i]);

                        readBuffer = null;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
                else if (receive.Equals("Resource"))
                {
                    int num = int.Parse(m_Read.ReadLine());
                    string[] files = new string[num];
                    for(int i = 0; i< num; i++)
                        files[i] = m_Read.ReadLine();
                    resource.ResourceUpdate(files);
                }
                else if (receive.Equals("Download"))
                {
                    string path = null;
                    int size = int.Parse(m_Read.ReadLine());
                    readBuffer = new byte[size];
                    m_bRead.Read(readBuffer, 0, size);
                    this.Invoke(new Action(delegate
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.CreatePrompt = true;
                        saveFileDialog.OverwritePrompt = true;
                        saveFileDialog.InitialDirectory = "./";
                        DialogResult dialogResult = saveFileDialog.ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            path = saveFileDialog.FileName;
                            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                            fileStream.Write(readBuffer, 0, size);
                            fileStream.Close();
                        }
                    }));
                }
            }
        }

        public void Login(User user)
        {
            try
            {
                m_Write.WriteLine("Login");
                m_Write.Flush();

                m_Write.WriteLine(user.id);
                m_Write.WriteLine(user.password);
                m_Write.Flush();

                string req = m_Read.ReadLine();
                this.user = new User();
                if (req.Equals("Login"))
                    this.user.name = m_Read.ReadLine();
                else if (req.Equals("None"))
                {
                    MessageBox.Show("아이디와 패스워드를 확인해주세요.");
                    Application.Exit();
                }

                label1.Text = "Login : " + this.user.name;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Upload(int number, string path)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(path);
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

                BinaryReader br = new BinaryReader(fileStream);
                sendBuffer = br.ReadBytes((int)fileInfo.Length);

                m_Write.WriteLine("Upload");
                m_Write.WriteLine(number.ToString());
                m_Write.WriteLine(fileInfo.Name);
                m_Write.WriteLine(fileInfo.Length.ToString());
                m_Write.Flush();

                m_bWrite.Write(sendBuffer);
                m_bWrite.Flush();
                fileStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void DeleteFile(int number, string name)
        {
            m_Write.WriteLine("DeleteFile");
            m_Write.WriteLine(number.ToString());
            m_Write.WriteLine(name);
            m_Write.Flush();
        }

        public void Resource(int number, ResourceDialog resource)
        {
            this.resource = resource;
            m_Write.WriteLine("Resource");
            m_Write.WriteLine(number.ToString());
            m_Write.Flush();
        }

        public void Download(int number, string name)
        {
            m_Write.WriteLine("Download");
            m_Write.WriteLine(number.ToString() + '/' + name);
            m_Write.Flush();
        }

        public void Import(Trade trade)
        {
            try
            {
                m_Write.WriteLine("Import");

                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, trade);
                sendBuffer = ms.ToArray();
                int size = sendBuffer.Length;
                m_Write.WriteLine(size.ToString());
                m_Write.Flush();
                Send();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Modify(string number, DateTime inspect, DateTime bill)
        {
            try
            {
                m_Write.WriteLine("Modify");
                m_Write.WriteLine(number);
                m_Write.WriteLine(inspect.ToString());
                m_Write.WriteLine(bill.ToString());
                m_Write.Flush();
            }
            catch(Exception e)
            {
                this.Invoke(new Action(delegate
                {
                    MessageBox.Show(e.ToString(), "Exception occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_Write.WriteLine("Disconnect");
            m_Write.Flush();
            m_Stream.Close();
            m_Client.Close();
        }

        public void Delete(string number)
        {
            try
            {
                m_Write.WriteLine("Delete");
                m_Write.WriteLine(number);
                m_Write.Flush();
            }
            catch(Exception e)
            {
                this.Invoke(new Action(delegate
                {
                    MessageBox.Show(e.ToString(), "Exception occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        public void Send()
        {
            this.m_bWrite.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_bWrite.Flush();

            sendBuffer = new byte[1024 * 4];
        }
    }
}

using System;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Packet;

namespace Client
{
    public partial class LoginForm : Form
    {
        ClientForm clientForm;
        public LoginForm(ClientForm clientForm)
        {
            InitializeComponent();
            this.clientForm = clientForm;
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                user.id = txt_ID.Text;
                user.password = txt_Pass.Text;
                clientForm.Login(user);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Txt_Pass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                try
                {
                    User user = new User();
                    user.id = txt_ID.Text;
                    user.password = txt_Pass.Text;
                    clientForm.Login(user);

                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString(), "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

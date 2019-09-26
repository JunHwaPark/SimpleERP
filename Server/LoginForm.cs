using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class LoginForm : Form
    {
        ServerForm form1;
        DataSet1.UserDataTable userRows = new DataSet1.UserDataTable();

        public LoginForm(ServerForm form1)
        {
            InitializeComponent();

            this.form1 = form1;
            try
            {
                userRows.ReadXml("user_data.xml");
            }
            catch (System.IO.FileNotFoundException)
            {
                userRows.WriteXml("user_data.xml");
            }
            catch (Exception e)
            {
                label1.Text = e.ToString();
            }
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Txt_Pass_KeyDown(object sender, KeyEventArgs e)
        {
            if(Keys.Enter == e.KeyCode)
                Login();
        }

        private void Login()
        {
            string query = "id=\'" + txt_ID.Text + "\' AND password=\'" + txt_Pass.Text + "\'";
            DataRow[] dataRow = userRows.Select(query);
            if (dataRow.Length == 0)
                label3.Text = "일치하는 사용자가 없습니다.";
            else
            {
                form1.setLabel(dataRow[0][0].ToString());
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}

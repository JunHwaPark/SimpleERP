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
    public partial class RegisterForm : Form
    {
        DataSet1.UserDataTable userRows = new DataSet1.UserDataTable();
        public RegisterForm()
        {
            InitializeComponent();

            try
            {
                userRows.ReadXml(SendClass.filepath + "user_data.xml");
            }
            catch (System.IO.FileNotFoundException)
            {
                userRows.WriteXml(SendClass.filepath + "user_data.xml");
            }
            catch (Exception e)
            {
                label1.Text = e.ToString();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Register();
        }

        private void TxtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
                Register();
        }

        private void Register()
        {
            if (txtPass.Text.Equals(txtConf.Text))
            {
                DataRow dataRow = userRows.NewRow();
                dataRow[0] = txtName.Text;
                dataRow[1] = txtID.Text;
                dataRow[2] = txtPass.Text;
                userRows.Rows.Add(dataRow);
                userRows.WriteXml(SendClass.filepath + "user_data.xml");
                this.DialogResult = DialogResult.OK;
            }
            else
                label5.Text = "비밀번호가 일치하지 않습니다.";
        }
    }
}

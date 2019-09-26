using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ResourceDialog : Form
    {
        ClientForm clientForm;
        int number;
        public string[] files = null;
        public ResourceDialog(ClientForm clientForm, int number)
        {
            InitializeComponent();

            this.clientForm = clientForm;
            this.number = number;
            label1.Text = this.number.ToString();
            this.clientForm.Resource(this.number, this);
        }

        public void ResourceUpdate(string[] files)
        {
            this.files = files;
            for(int i = 0; i< this.files.Length; i++)
                listView1.Items.Add(this.files[i]);
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
            {
                MessageBox.Show("다운로드할 파일을 1개 선택해주세요.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clientForm.Download(this.number, listView1.SelectedItems[0].SubItems[0].Text);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                clientForm.Upload(this.number, path);
                MessageBox.Show("업로드 되었습니다.");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
            {
                MessageBox.Show("다운로드할 파일을 1개 선택해주세요.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clientForm.DeleteFile(this.number, listView1.SelectedItems[0].SubItems[0].Text);
            MessageBox.Show("삭제되었습니다.");
        }
    }
}

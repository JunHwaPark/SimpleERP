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
    public partial class ModifyDialog : Form
    {
        ClientForm client;
        ListViewItem item;
        public ModifyDialog(ClientForm client, ListViewItem item)
        {
            InitializeComponent();
            this.client = client;
            if (item != null)
            {
                this.item = item;
                listView.Items.Add(this.item);

                string inspect = item.SubItems[13].Text;
                string bill = item.SubItems[14].Text;

                if (inspect.Length > 0)
                    this.dateInspect.Value = new DateTime(int.Parse(inspect.Substring(0, 4)), int.Parse(inspect.Substring(5, 2))
    , int.Parse(inspect.Substring(8, 2)));
                if (bill.Length > 0)
                    this.dateBillPaper.Value = new DateTime(int.Parse(bill.Substring(0, 4)), int.Parse(bill.Substring(5, 2))
    , int.Parse(bill.Substring(8, 2)));
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (dateBillPaper.Enabled)
                this.client.Modify(item.SubItems[0].Text, dateInspect.Value, dateBillPaper.Value);
            else
                this.client.Modify(item.SubItems[0].Text, dateInspect.Value, new DateTime());
            MessageBox.Show("변경이 완료되었습니다.");
            this.DialogResult = DialogResult.OK;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.client.Delete(item.SubItems[0].Text);
            MessageBox.Show("삭제가 완료되었습니다.");
            this.DialogResult = DialogResult.OK;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                dateBillPaper.Enabled = true;
            else
                dateBillPaper.Enabled = false;
        }
    }
}

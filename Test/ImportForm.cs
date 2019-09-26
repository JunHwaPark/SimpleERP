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
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using Packet;

namespace Client
{
    public partial class ImportForm : Form
    {
        ClientForm clientForm;
        public ImportForm(ClientForm clientForm)
        {
            InitializeComponent();
            this.clientForm = clientForm;
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            Trade trade = new Trade();
            trade.category = comCategory.Text;
            trade.transaction = dateTransaction.Value;
            trade.deadline = dateDeadline.Value;
            trade.orderer = txtOrderer.Text;
            trade.demander = txtDemander.Text;
            trade.contents = txtContents.Text;
            trade.product = comProduct.Text;
            trade.OS = comOS.Text;
            trade.quantity = int.Parse(txtQuantity.Text);
            trade.price = int.Parse(txtPrice.Text);
            trade.manager = comManager.Text;
            trade.modify = DateTime.Now;
            trade.registrar = clientForm.user.name;

            try
            {
                clientForm.Import(trade);
                MessageBox.Show("입력되었습니다.", "alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString(), "Exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.clientForm.Click_View();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.clientForm.Click_View();
        }
    }
}

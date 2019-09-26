using System;
using System.Collections;
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
    public partial class ViewForm : Form
    {
        ListViewItem item;
        ClientForm clientForm;
        public ViewForm(ClientForm clientForm)
        {
            InitializeComponent();
            this.clientForm = clientForm;
            listView.Items.Clear();
            listView.ListViewItemSorter = new ListViewItemComparer(2);
        }

        public int sortCompare(string s1, string s2)
        {
            if (int.Parse(s1) > int.Parse(s2))
                return 1;
            else
                return -1;
        }

        public void AddRow(Trade trade)
        {
            item = new ListViewItem(new string[listView.Columns.Count]);
            for (int i = 0; i < listView.Columns.Count; i++)
                item.SubItems[i].Name = listView.Columns[i].Name;

            TimeSpan timeSpan = DateTime.Now - trade.deadline;

            item.SubItems[0].Text = trade.number.ToString();
            item.SubItems[1].Text = trade.category;
            item.SubItems[2].Text = trade.transaction.ToString().Substring(0,10);
            item.SubItems[3].Text = trade.deadline.ToString().Substring(0, 10);
            //item.SubItems[4].Text = "-" + timeSpan.Days.ToString();
            item.SubItems[5].Text = trade.orderer;
            item.SubItems[6].Text = trade.demander;
            item.SubItems[7].Text = trade.contents;
            item.SubItems[8].Text = trade.product;
            item.SubItems[9].Text = trade.OS;
            item.SubItems[10].Text = trade.quantity.ToString();
            item.SubItems[11].Text = trade.price.ToString();
            item.SubItems[12].Text = trade.manager;
            if (!trade.inspection.ToString().Substring(0, 10).Equals("0001-01-01"))
                item.SubItems[13].Text = trade.inspection.ToString().Substring(0, 10);
            if (!trade.bill.ToString().Substring(0, 10).Equals("0001-01-01"))
                item.SubItems[14].Text = trade.bill.ToString().Substring(0, 10);
            item.SubItems[15].Text = trade.registrar;

            if (item.SubItems[14].Text.Length > 0)
                item.SubItems[4].Text = "완료";
            else
            {
                if (DateTime.Now.CompareTo(trade.deadline) < 0)
                {
                    if (DateTime.Now.AddDays(timeSpan.Days).Day == trade.deadline.Day)
                        item.SubItems[4].Text = timeSpan.Days.ToString();
                    else
                        item.SubItems[4].Text = (timeSpan.Days - 1).ToString();
                }
                else
                {
                    if (trade.deadline.AddDays(timeSpan.Days).Day == DateTime.Now.Day)
                        item.SubItems[4].Text = timeSpan.Days.ToString();
                    else
                        item.SubItems[4].Text = (timeSpan.Days + 1).ToString();
                }
            }

            listView.Items.Add(item);
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count != 1)
            {
                MessageBox.Show("수정할 항목을 1개 선택해주세요.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ModifyDialog modifyDialog = new ModifyDialog(clientForm, (ListViewItem)listView.SelectedItems[0].Clone());
            DialogResult dialogResult = modifyDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
                MessageBox.Show("계약 목록을 다시 업데이트 해주세요.");
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.DefaultExt = "trade_data.xls";
            saveFileDialog.Filter = "Excel Files (*.xls)|*.xls";
            saveFileDialog.InitialDirectory = "./";
            DialogResult result = saveFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                try
                {
                    object missingType = Type.Missing;
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Add(missingType);
                    Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Wo﻿rksheets.Add(missingType, missingType, missingType, missingType);

                    excelApp.Visible = false;

                    for (int i = 0; i < listView.Items.Count; i++)
                    {
                        for (int j = 0; j < listView.Columns.Count; j++)
                        {
                            if (i == 0)
                                excelWorksheet.Cells[1, j + 1] = this.listView.Columns[j].Text.ToString();

                            excelWorksheet.Cells[i + 2, j + 1] = this.listView.Items[i].SubItems[j].Text.ToString();
                        }
                    }

                    excelBook.SaveAs(@saveFileDialog.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, missingType, missingType, missingType, missingType, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, missingType, missingType, missingType, missingType, missingType);
                    excelApp.Visible = true;
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
                catch
                {
                    MessageBox.Show("Excel 파일 저장중 에러가 발생했습니다.");
                }
            }
        }

        private void BtnResource_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count != 1)
            {
                MessageBox.Show("자료를 조회할 거래를 1개 선택해주세요.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            ResourceDialog resourceDialog = new ResourceDialog(clientForm, int.Parse(listView.SelectedItems[0].SubItems[0].Text));

            DialogResult dialogResult = resourceDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
                return;
        }
    }

    class ListViewItemComparer : IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            if (String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text) != 0)
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            else
                return String.Compare(((ListViewItem)x).SubItems[14].Text, ((ListViewItem)y).SubItems[14].Text);
        }
    }
}

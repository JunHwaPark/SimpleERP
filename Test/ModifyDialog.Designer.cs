namespace Client
{
    partial class ModifyDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateBillPaper = new System.Windows.Forms.DateTimePicker();
            this.dateInspect = new System.Windows.Forms.DateTimePicker();
            this.dateDeadline = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.data_transaction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deadline = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.days_between = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ordering_organ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.demanding_agency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contents = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.product = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.manager = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.inspection = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date_billpaper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.registrar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dateBillPaper
            // 
            this.dateBillPaper.Enabled = false;
            this.dateBillPaper.Location = new System.Drawing.Point(765, 151);
            this.dateBillPaper.Name = "dateBillPaper";
            this.dateBillPaper.Size = new System.Drawing.Size(200, 21);
            this.dateBillPaper.TabIndex = 17;
            // 
            // dateInspect
            // 
            this.dateInspect.Location = new System.Drawing.Point(448, 151);
            this.dateInspect.Name = "dateInspect";
            this.dateInspect.Size = new System.Drawing.Size(200, 21);
            this.dateInspect.TabIndex = 16;
            // 
            // dateDeadline
            // 
            this.dateDeadline.AutoSize = true;
            this.dateDeadline.Location = new System.Drawing.Point(694, 154);
            this.dateDeadline.Name = "dateDeadline";
            this.dateDeadline.Size = new System.Drawing.Size(41, 12);
            this.dateDeadline.TabIndex = 15;
            this.dateDeadline.Text = "계산서";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(413, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "검수";
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(505, 197);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 18;
            this.btnModify.Text = "수정";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(639, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "취소";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(780, 197);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "해당 건 삭제";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.number,
            this.category,
            this.data_transaction,
            this.deadline,
            this.days_between,
            this.ordering_organ,
            this.demanding_agency,
            this.contents,
            this.product,
            this.OS,
            this.quantity,
            this.price,
            this.manager,
            this.inspection,
            this.date_billpaper,
            this.registrar});
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 14);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(1367, 119);
            this.listView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView.TabIndex = 21;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // number
            // 
            this.number.Text = "no.";
            this.number.Width = 34;
            // 
            // category
            // 
            this.category.Text = "구분";
            this.category.Width = 80;
            // 
            // data_transaction
            // 
            this.data_transaction.Text = "구매일자";
            this.data_transaction.Width = 100;
            // 
            // deadline
            // 
            this.deadline.Text = "납품기한";
            this.deadline.Width = 100;
            // 
            // days_between
            // 
            this.days_between.Text = "남은기간";
            // 
            // ordering_organ
            // 
            this.ordering_organ.Text = "발주기관";
            this.ordering_organ.Width = 100;
            // 
            // demanding_agency
            // 
            this.demanding_agency.Text = "수요기관";
            this.demanding_agency.Width = 100;
            // 
            // contents
            // 
            this.contents.Text = "공사명";
            this.contents.Width = 150;
            // 
            // product
            // 
            this.product.Text = "품목";
            this.product.Width = 150;
            // 
            // OS
            // 
            this.OS.Text = "OS";
            this.OS.Width = 70;
            // 
            // quantity
            // 
            this.quantity.Text = "수량";
            this.quantity.Width = 50;
            // 
            // price
            // 
            this.price.Text = "금액";
            this.price.Width = 100;
            // 
            // manager
            // 
            this.manager.Text = "담당자";
            this.manager.Width = 50;
            // 
            // inspection
            // 
            this.inspection.Text = "검수";
            this.inspection.Width = 100;
            // 
            // date_billpaper
            // 
            this.date_billpaper.Text = "계산서";
            this.date_billpaper.Width = 100;
            // 
            // registrar
            // 
            this.registrar.Text = "등록자";
            this.registrar.Width = 50;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(744, 154);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // ModifyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 259);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.dateBillPaper);
            this.Controls.Add(this.dateInspect);
            this.Controls.Add(this.dateDeadline);
            this.Controls.Add(this.label2);
            this.Name = "ModifyDialog";
            this.Text = "ModifyDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateBillPaper;
        private System.Windows.Forms.DateTimePicker dateInspect;
        private System.Windows.Forms.Label dateDeadline;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader number;
        private System.Windows.Forms.ColumnHeader category;
        private System.Windows.Forms.ColumnHeader data_transaction;
        private System.Windows.Forms.ColumnHeader deadline;
        private System.Windows.Forms.ColumnHeader days_between;
        private System.Windows.Forms.ColumnHeader ordering_organ;
        private System.Windows.Forms.ColumnHeader demanding_agency;
        private System.Windows.Forms.ColumnHeader contents;
        private System.Windows.Forms.ColumnHeader product;
        private System.Windows.Forms.ColumnHeader OS;
        private System.Windows.Forms.ColumnHeader quantity;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader manager;
        private System.Windows.Forms.ColumnHeader inspection;
        private System.Windows.Forms.ColumnHeader date_billpaper;
        private System.Windows.Forms.ColumnHeader registrar;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
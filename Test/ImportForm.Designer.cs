namespace Client
{
    partial class ImportForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comCategory = new System.Windows.Forms.ComboBox();
            this.dateTransaction = new System.Windows.Forms.DateTimePicker();
            this.dateDeadline = new System.Windows.Forms.DateTimePicker();
            this.txtOrderer = new System.Windows.Forms.TextBox();
            this.txtDemander = new System.Windows.Forms.TextBox();
            this.txtContents = new System.Windows.Forms.TextBox();
            this.comProduct = new System.Windows.Forms.ComboBox();
            this.comOS = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.comManager = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "구분";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "구매일자";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(818, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "납품기한";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "발주기관";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(818, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "수요기관";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "공사명";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(291, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "품목";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(519, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "OS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(842, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "수량";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(291, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "금액";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(830, 322);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "담당자";
            // 
            // comCategory
            // 
            this.comCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comCategory.FormattingEnabled = true;
            this.comCategory.Items.AddRange(new object[] {
            "3자단가계약",
            "발주",
            "SI"});
            this.comCategory.Location = new System.Drawing.Point(332, 41);
            this.comCategory.Name = "comCategory";
            this.comCategory.Size = new System.Drawing.Size(121, 20);
            this.comCategory.TabIndex = 11;
            // 
            // dateTransaction
            // 
            this.dateTransaction.Location = new System.Drawing.Point(572, 41);
            this.dateTransaction.Name = "dateTransaction";
            this.dateTransaction.Size = new System.Drawing.Size(200, 21);
            this.dateTransaction.TabIndex = 12;
            // 
            // dateDeadline
            // 
            this.dateDeadline.Location = new System.Drawing.Point(889, 41);
            this.dateDeadline.Name = "dateDeadline";
            this.dateDeadline.Size = new System.Drawing.Size(200, 21);
            this.dateDeadline.TabIndex = 13;
            // 
            // txtOrderer
            // 
            this.txtOrderer.Location = new System.Drawing.Point(332, 97);
            this.txtOrderer.Name = "txtOrderer";
            this.txtOrderer.Size = new System.Drawing.Size(121, 21);
            this.txtOrderer.TabIndex = 14;
            // 
            // txtDemander
            // 
            this.txtDemander.Location = new System.Drawing.Point(889, 97);
            this.txtDemander.Name = "txtDemander";
            this.txtDemander.Size = new System.Drawing.Size(121, 21);
            this.txtDemander.TabIndex = 15;
            // 
            // txtContents
            // 
            this.txtContents.Location = new System.Drawing.Point(332, 173);
            this.txtContents.Name = "txtContents";
            this.txtContents.Size = new System.Drawing.Size(565, 21);
            this.txtContents.TabIndex = 16;
            // 
            // comProduct
            // 
            this.comProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comProduct.FormattingEnabled = true;
            this.comProduct.Items.AddRange(new object[] {
            "Secuve TOS V2.0/3.0",
            "Secuve TOS V5.0",
            "iGRIFFIN"});
            this.comProduct.Location = new System.Drawing.Point(332, 242);
            this.comProduct.Name = "comProduct";
            this.comProduct.Size = new System.Drawing.Size(121, 20);
            this.comProduct.TabIndex = 17;
            // 
            // comOS
            // 
            this.comOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comOS.FormattingEnabled = true;
            this.comOS.Items.AddRange(new object[] {
            "Unix",
            "Linux",
            "Windows"});
            this.comOS.Location = new System.Drawing.Point(572, 242);
            this.comOS.Name = "comOS";
            this.comOS.Size = new System.Drawing.Size(121, 20);
            this.comOS.TabIndex = 18;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(889, 242);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(121, 21);
            this.txtQuantity.TabIndex = 19;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(332, 319);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(196, 21);
            this.txtPrice.TabIndex = 20;
            // 
            // comManager
            // 
            this.comManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comManager.FormattingEnabled = true;
            this.comManager.Items.AddRange(new object[] {
            "단호준",
            "전영준",
            "박정화",
            "박명규"});
            this.comManager.Location = new System.Drawing.Point(889, 319);
            this.comManager.Name = "comManager";
            this.comManager.Size = new System.Drawing.Size(121, 20);
            this.comManager.TabIndex = 21;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(464, 376);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 22;
            this.btnImport.Text = "등록";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(720, 376);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 432);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.comManager);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.comOS);
            this.Controls.Add(this.comProduct);
            this.Controls.Add(this.txtContents);
            this.Controls.Add(this.txtDemander);
            this.Controls.Add(this.txtOrderer);
            this.Controls.Add(this.dateDeadline);
            this.Controls.Add(this.dateTransaction);
            this.Controls.Add(this.comCategory);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImportForm";
            this.Text = "ImportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comCategory;
        private System.Windows.Forms.DateTimePicker dateTransaction;
        private System.Windows.Forms.DateTimePicker dateDeadline;
        private System.Windows.Forms.TextBox txtOrderer;
        private System.Windows.Forms.TextBox txtDemander;
        private System.Windows.Forms.TextBox txtContents;
        private System.Windows.Forms.ComboBox comProduct;
        private System.Windows.Forms.ComboBox comOS;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox comManager;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCancel;
    }
}
namespace Client
{
    partial class ViewForm
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
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
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
            this.btnResource = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(1218, 429);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 30);
            this.btnModify.TabIndex = 7;
            this.btnModify.Text = "수정";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(1299, 429);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 30);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Text = "내려받기";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.BtnDownload_Click);
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
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 12);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(1367, 407);
            this.listView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView.TabIndex = 5;
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
            // btnResource
            // 
            this.btnResource.Location = new System.Drawing.Point(12, 429);
            this.btnResource.Name = "btnResource";
            this.btnResource.Size = new System.Drawing.Size(75, 30);
            this.btnResource.TabIndex = 8;
            this.btnResource.Text = "자료";
            this.btnResource.UseVisualStyleBackColor = true;
            this.btnResource.Click += new System.EventHandler(this.BtnResource_Click);
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1391, 471);
            this.Controls.Add(this.btnResource);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.listView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewForm";
            this.Text = "ViewForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ListView listView;
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
        private System.Windows.Forms.ColumnHeader number;
        private System.Windows.Forms.Button btnResource;
    }
}
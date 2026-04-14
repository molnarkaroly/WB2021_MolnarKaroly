namespace RealEstateGUI
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSellers = new System.Windows.Forms.Label();
            this.buttonActive = new System.Windows.Forms.Button();
            this.listBoxSellers = new System.Windows.Forms.ListBox();
            this.labelSellerName = new System.Windows.Forms.Label();
            this.labelSellerPhone = new System.Windows.Forms.Label();
            this.labelAdCount = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.listBoxAds = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.labelSellers, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonActive, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.listBoxSellers, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSellerName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelSellerPhone, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelAdCount, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonLoad, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.listBoxAds, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelSellers
            // 
            this.labelSellers.AutoSize = true;
            this.labelSellers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSellers.Location = new System.Drawing.Point(3, 0);
            this.labelSellers.Name = "labelSellers";
            this.labelSellers.Size = new System.Drawing.Size(288, 56);
            this.labelSellers.TabIndex = 0;
            this.labelSellers.Text = "Ügynökök";
            this.labelSellers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonActive
            // 
            this.buttonActive.BackColor = System.Drawing.Color.White;
            this.buttonActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonActive.Location = new System.Drawing.Point(3, 507);
            this.buttonActive.Name = "buttonActive";
            this.buttonActive.Size = new System.Drawing.Size(288, 51);
            this.buttonActive.TabIndex = 1;
            this.buttonActive.Text = "Aktív Ügynökök";
            this.buttonActive.UseVisualStyleBackColor = false;
            this.buttonActive.Click += new System.EventHandler(this.buttonActive_Click);
            // 
            // listBoxSellers
            // 
            this.listBoxSellers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSellers.FormattingEnabled = true;
            this.listBoxSellers.Location = new System.Drawing.Point(3, 59);
            this.listBoxSellers.Name = "listBoxSellers";
            this.tableLayoutPanel1.SetRowSpan(this.listBoxSellers, 4);
            this.listBoxSellers.Size = new System.Drawing.Size(288, 442);
            this.listBoxSellers.TabIndex = 2;
            this.listBoxSellers.SelectedIndexChanged += new System.EventHandler(this.listBoxSellers_SelectedIndexChanged);
            // 
            // labelSellerName
            // 
            this.labelSellerName.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelSellerName, 2);
            this.labelSellerName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelSellerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSellerName.Location = new System.Drawing.Point(297, 0);
            this.labelSellerName.Name = "labelSellerName";
            this.labelSellerName.Size = new System.Drawing.Size(89, 56);
            this.labelSellerName.TabIndex = 3;
            this.labelSellerName.Text = "Eladó Neve: ";
            this.labelSellerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSellerPhone
            // 
            this.labelSellerPhone.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelSellerPhone, 2);
            this.labelSellerPhone.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelSellerPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSellerPhone.Location = new System.Drawing.Point(297, 56);
            this.labelSellerPhone.Name = "labelSellerPhone";
            this.labelSellerPhone.Size = new System.Drawing.Size(145, 56);
            this.labelSellerPhone.TabIndex = 4;
            this.labelSellerPhone.Text = "Eladó Telefonszáma: ";
            this.labelSellerPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAdCount
            // 
            this.labelAdCount.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelAdCount, 2);
            this.labelAdCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelAdCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAdCount.Location = new System.Drawing.Point(297, 168);
            this.labelAdCount.Name = "labelAdCount";
            this.labelAdCount.Size = new System.Drawing.Size(136, 56);
            this.labelAdCount.TabIndex = 5;
            this.labelAdCount.Text = "Hirdetések Száma: -";
            this.labelAdCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonLoad
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonLoad, 2);
            this.buttonLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLoad.Location = new System.Drawing.Point(297, 115);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(584, 50);
            this.buttonLoad.TabIndex = 6;
            this.buttonLoad.Text = "Hirdetések Betöltése";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // listBoxAds
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.listBoxAds, 2);
            this.listBoxAds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAds.FormattingEnabled = true;
            this.listBoxAds.Location = new System.Drawing.Point(297, 227);
            this.listBoxAds.Name = "listBoxAds";
            this.tableLayoutPanel1.SetRowSpan(this.listBoxAds, 2);
            this.listBoxAds.Size = new System.Drawing.Size(584, 331);
            this.listBoxAds.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "Form1";
            this.Text = "Ingatlanok";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelSellers;
        private System.Windows.Forms.Button buttonActive;
        private System.Windows.Forms.ListBox listBoxSellers;
        private System.Windows.Forms.Label labelSellerName;
        private System.Windows.Forms.Label labelSellerPhone;
        private System.Windows.Forms.Label labelAdCount;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.ListBox listBoxAds;
    }
}


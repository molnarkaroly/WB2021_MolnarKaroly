namespace Barlang_form
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.azonosito_label = new System.Windows.Forms.Label();
            this.azonositoTxb = new System.Windows.Forms.TextBox();
            this.brlngName = new System.Windows.Forms.Label();
            this.hossz_Label = new System.Windows.Forms.Label();
            this.hosszTxb = new System.Windows.Forms.TextBox();
            this.melyseg_Label = new System.Windows.Forms.Label();
            this.melyTxb = new System.Windows.Forms.TextBox();
            this.barlang_kereses = new System.Windows.Forms.Button();
            this.adat_ment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Válaszd ki a fájlt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "A fájl elérési helye";
            // 
            // azonosito_label
            // 
            this.azonosito_label.AutoSize = true;
            this.azonosito_label.Location = new System.Drawing.Point(35, 69);
            this.azonosito_label.Name = "azonosito_label";
            this.azonosito_label.Size = new System.Drawing.Size(53, 13);
            this.azonosito_label.TabIndex = 2;
            this.azonosito_label.Text = "Azonositó";
            // 
            // azonositoTxb
            // 
            this.azonositoTxb.Location = new System.Drawing.Point(146, 69);
            this.azonositoTxb.Name = "azonositoTxb";
            this.azonositoTxb.Size = new System.Drawing.Size(100, 20);
            this.azonositoTxb.TabIndex = 3;
            // 
            // brlngName
            // 
            this.brlngName.AutoSize = true;
            this.brlngName.Location = new System.Drawing.Point(38, 106);
            this.brlngName.Name = "brlngName";
            this.brlngName.Size = new System.Drawing.Size(73, 13);
            this.brlngName.TabIndex = 4;
            this.brlngName.Text = "Barlang neve:";
            // 
            // hossz_Label
            // 
            this.hossz_Label.AutoSize = true;
            this.hossz_Label.Location = new System.Drawing.Point(41, 142);
            this.hossz_Label.Name = "hossz_Label";
            this.hossz_Label.Size = new System.Drawing.Size(65, 13);
            this.hossz_Label.TabIndex = 5;
            this.hossz_Label.Text = "Hosszúság: ";
            // 
            // hosszTxb
            // 
            this.hosszTxb.Location = new System.Drawing.Point(146, 142);
            this.hosszTxb.Name = "hosszTxb";
            this.hosszTxb.Size = new System.Drawing.Size(100, 20);
            this.hosszTxb.TabIndex = 6;
            // 
            // melyseg_Label
            // 
            this.melyseg_Label.AutoSize = true;
            this.melyseg_Label.Location = new System.Drawing.Point(44, 181);
            this.melyseg_Label.Name = "melyseg_Label";
            this.melyseg_Label.Size = new System.Drawing.Size(52, 13);
            this.melyseg_Label.TabIndex = 7;
            this.melyseg_Label.Text = "Mélység: ";
            // 
            // melyTxb
            // 
            this.melyTxb.Location = new System.Drawing.Point(146, 181);
            this.melyTxb.Name = "melyTxb";
            this.melyTxb.Size = new System.Drawing.Size(100, 20);
            this.melyTxb.TabIndex = 8;
            // 
            // barlang_kereses
            // 
            this.barlang_kereses.Location = new System.Drawing.Point(298, 69);
            this.barlang_kereses.Name = "barlang_kereses";
            this.barlang_kereses.Size = new System.Drawing.Size(132, 23);
            this.barlang_kereses.TabIndex = 9;
            this.barlang_kereses.Text = "Barlang keresése";
            this.barlang_kereses.UseVisualStyleBackColor = true;
            this.barlang_kereses.Click += new System.EventHandler(this.barlang_kereses_Click);
            // 
            // adat_ment
            // 
            this.adat_ment.Location = new System.Drawing.Point(298, 138);
            this.adat_ment.Name = "adat_ment";
            this.adat_ment.Size = new System.Drawing.Size(93, 23);
            this.adat_ment.TabIndex = 10;
            this.adat_ment.Text = "Adatok mentése";
            this.adat_ment.UseVisualStyleBackColor = true;
            this.adat_ment.Click += new System.EventHandler(this.adat_ment_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 450);
            this.Controls.Add(this.adat_ment);
            this.Controls.Add(this.barlang_kereses);
            this.Controls.Add(this.melyTxb);
            this.Controls.Add(this.melyseg_Label);
            this.Controls.Add(this.hosszTxb);
            this.Controls.Add(this.hossz_Label);
            this.Controls.Add(this.brlngName);
            this.Controls.Add(this.azonositoTxb);
            this.Controls.Add(this.azonosito_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label azonosito_label;
        private System.Windows.Forms.TextBox azonositoTxb;
        private System.Windows.Forms.Label brlngName;
        private System.Windows.Forms.Label hossz_Label;
        private System.Windows.Forms.TextBox hosszTxb;
        private System.Windows.Forms.Label melyseg_Label;
        private System.Windows.Forms.TextBox melyTxb;
        private System.Windows.Forms.Button barlang_kereses;
        private System.Windows.Forms.Button adat_ment;
    }
}


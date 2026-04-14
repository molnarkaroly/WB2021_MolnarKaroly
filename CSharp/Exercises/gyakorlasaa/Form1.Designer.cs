namespace Futoverseny
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
            this.label_Title = new System.Windows.Forms.Label();
            this.label_Resztvevok = new System.Windows.Forms.Label();
            this.listBox_Main = new System.Windows.Forms.ListBox();
            this.label_Rajtszam = new System.Windows.Forms.Label();
            this.textBox_Rajtszam = new System.Windows.Forms.TextBox();
            this.textBox_Orszag = new System.Windows.Forms.TextBox();
            this.label_Orszag = new System.Windows.Forms.Label();
            this.textBox_Idoeredmeny = new System.Windows.Forms.TextBox();
            this.label_Idoeredmeny = new System.Windows.Forms.Label();
            this.textBox_Eletkor = new System.Windows.Forms.TextBox();
            this.label_Eletkor = new System.Windows.Forms.Label();
            this.button_ELista = new System.Windows.Forms.Button();
            this.button_Bezar = new System.Windows.Forms.Button();
            this.button_Adat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Title.ForeColor = System.Drawing.Color.Red;
            this.label_Title.Location = new System.Drawing.Point(84, 9);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(194, 25);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "Maratoni futóverseny";
            // 
            // label_Resztvevok
            // 
            this.label_Resztvevok.AutoSize = true;
            this.label_Resztvevok.Location = new System.Drawing.Point(13, 54);
            this.label_Resztvevok.Name = "label_Resztvevok";
            this.label_Resztvevok.Size = new System.Drawing.Size(79, 13);
            this.label_Resztvevok.TabIndex = 1;
            this.label_Resztvevok.Text = "RÉSZTVEVŐK";
            // 
            // listBox_Main
            // 
            this.listBox_Main.FormattingEnabled = true;
            this.listBox_Main.Location = new System.Drawing.Point(16, 71);
            this.listBox_Main.Name = "listBox_Main";
            this.listBox_Main.Size = new System.Drawing.Size(120, 290);
            this.listBox_Main.TabIndex = 2;
            // 
            // label_Rajtszam
            // 
            this.label_Rajtszam.AutoSize = true;
            this.label_Rajtszam.Location = new System.Drawing.Point(143, 71);
            this.label_Rajtszam.Name = "label_Rajtszam";
            this.label_Rajtszam.Size = new System.Drawing.Size(50, 13);
            this.label_Rajtszam.TabIndex = 3;
            this.label_Rajtszam.Text = "Rajtszám";
            // 
            // textBox_Rajtszam
            // 
            this.textBox_Rajtszam.Location = new System.Drawing.Point(217, 68);
            this.textBox_Rajtszam.Name = "textBox_Rajtszam";
            this.textBox_Rajtszam.Size = new System.Drawing.Size(155, 20);
            this.textBox_Rajtszam.TabIndex = 4;
            // 
            // textBox_Orszag
            // 
            this.textBox_Orszag.Location = new System.Drawing.Point(217, 125);
            this.textBox_Orszag.Name = "textBox_Orszag";
            this.textBox_Orszag.Size = new System.Drawing.Size(155, 20);
            this.textBox_Orszag.TabIndex = 6;
            // 
            // label_Orszag
            // 
            this.label_Orszag.AutoSize = true;
            this.label_Orszag.Location = new System.Drawing.Point(143, 128);
            this.label_Orszag.Name = "label_Orszag";
            this.label_Orszag.Size = new System.Drawing.Size(40, 13);
            this.label_Orszag.TabIndex = 5;
            this.label_Orszag.Text = "Ország";
            // 
            // textBox_Idoeredmeny
            // 
            this.textBox_Idoeredmeny.Location = new System.Drawing.Point(217, 184);
            this.textBox_Idoeredmeny.Name = "textBox_Idoeredmeny";
            this.textBox_Idoeredmeny.Size = new System.Drawing.Size(155, 20);
            this.textBox_Idoeredmeny.TabIndex = 8;
            // 
            // label_Idoeredmeny
            // 
            this.label_Idoeredmeny.AutoSize = true;
            this.label_Idoeredmeny.Location = new System.Drawing.Point(143, 187);
            this.label_Idoeredmeny.Name = "label_Idoeredmeny";
            this.label_Idoeredmeny.Size = new System.Drawing.Size(68, 13);
            this.label_Idoeredmeny.TabIndex = 7;
            this.label_Idoeredmeny.Text = "Időeredmény";
            // 
            // textBox_Eletkor
            // 
            this.textBox_Eletkor.Location = new System.Drawing.Point(217, 244);
            this.textBox_Eletkor.Name = "textBox_Eletkor";
            this.textBox_Eletkor.Size = new System.Drawing.Size(155, 20);
            this.textBox_Eletkor.TabIndex = 10;
            // 
            // label_Eletkor
            // 
            this.label_Eletkor.AutoSize = true;
            this.label_Eletkor.Location = new System.Drawing.Point(143, 247);
            this.label_Eletkor.Name = "label_Eletkor";
            this.label_Eletkor.Size = new System.Drawing.Size(40, 13);
            this.label_Eletkor.TabIndex = 9;
            this.label_Eletkor.Text = "Életkor";
            // 
            // button_ELista
            // 
            this.button_ELista.Enabled = false;
            this.button_ELista.Location = new System.Drawing.Point(194, 338);
            this.button_ELista.Name = "button_ELista";
            this.button_ELista.Size = new System.Drawing.Size(116, 23);
            this.button_ELista.TabIndex = 11;
            this.button_ELista.Text = "Eredmény Lista";
            this.button_ELista.UseVisualStyleBackColor = true;
            this.button_ELista.Click += new System.EventHandler(this.button_ELista_Click);
            // 
            // button_Bezar
            // 
            this.button_Bezar.Location = new System.Drawing.Point(256, 426);
            this.button_Bezar.Name = "button_Bezar";
            this.button_Bezar.Size = new System.Drawing.Size(116, 23);
            this.button_Bezar.TabIndex = 12;
            this.button_Bezar.Text = "Bezár";
            this.button_Bezar.UseVisualStyleBackColor = true;
            this.button_Bezar.Click += new System.EventHandler(this.button_Bezar_Click);
            // 
            // button_Adat
            // 
            this.button_Adat.Location = new System.Drawing.Point(12, 426);
            this.button_Adat.Name = "button_Adat";
            this.button_Adat.Size = new System.Drawing.Size(116, 23);
            this.button_Adat.TabIndex = 13;
            this.button_Adat.Text = "Adat Be";
            this.button_Adat.UseVisualStyleBackColor = true;
            this.button_Adat.Click += new System.EventHandler(this.button_Adat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.button_Adat);
            this.Controls.Add(this.button_Bezar);
            this.Controls.Add(this.button_ELista);
            this.Controls.Add(this.textBox_Eletkor);
            this.Controls.Add(this.label_Eletkor);
            this.Controls.Add(this.textBox_Idoeredmeny);
            this.Controls.Add(this.label_Idoeredmeny);
            this.Controls.Add(this.textBox_Orszag);
            this.Controls.Add(this.label_Orszag);
            this.Controls.Add(this.textBox_Rajtszam);
            this.Controls.Add(this.label_Rajtszam);
            this.Controls.Add(this.listBox_Main);
            this.Controls.Add(this.label_Resztvevok);
            this.Controls.Add(this.label_Title);
            this.Name = "Form1";
            this.Text = "Futóverseny";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label_Resztvevok;
        private System.Windows.Forms.ListBox listBox_Main;
        private System.Windows.Forms.Label label_Rajtszam;
        private System.Windows.Forms.TextBox textBox_Rajtszam;
        private System.Windows.Forms.TextBox textBox_Orszag;
        private System.Windows.Forms.Label label_Orszag;
        private System.Windows.Forms.TextBox textBox_Idoeredmeny;
        private System.Windows.Forms.Label label_Idoeredmeny;
        private System.Windows.Forms.TextBox textBox_Eletkor;
        private System.Windows.Forms.Label label_Eletkor;
        private System.Windows.Forms.Button button_ELista;
        private System.Windows.Forms.Button button_Bezar;
        private System.Windows.Forms.Button button_Adat;
    }
}


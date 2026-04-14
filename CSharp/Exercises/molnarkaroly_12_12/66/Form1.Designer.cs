namespace _66
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
            this.txbPlayer1 = new System.Windows.Forms.TextBox();
            this.txbPlayer2 = new System.Windows.Forms.TextBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbPlayer1
            // 
            this.txbPlayer1.Location = new System.Drawing.Point(13, 13);
            this.txbPlayer1.Name = "txbPlayer1";
            this.txbPlayer1.Size = new System.Drawing.Size(100, 20);
            this.txbPlayer1.TabIndex = 0;
            // 
            // txbPlayer2
            // 
            this.txbPlayer2.Location = new System.Drawing.Point(141, 13);
            this.txbPlayer2.Name = "txbPlayer2";
            this.txbPlayer2.Size = new System.Drawing.Size(100, 20);
            this.txbPlayer2.TabIndex = 1;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(13, 39);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(228, 23);
            this.startBtn.TabIndex = 2;
            this.startBtn.Text = "button1";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.txbPlayer2);
            this.Controls.Add(this.txbPlayer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbPlayer1;
        private System.Windows.Forms.TextBox txbPlayer2;
        private System.Windows.Forms.Button startBtn;
    }
}


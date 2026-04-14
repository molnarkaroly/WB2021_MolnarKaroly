using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BingoGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[,] ints = new int[5, 5];
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 26; i++)
            {
                if (i != 0)
                {
                    TextBox textBox = (TextBox)this.Controls["textBox" + i];
                    textBox.Visible = false;
                }
            }
            Random rnd = new Random();
            for (int i = 0;i < 5; i++)
            {
               
                for (int j = 0; j < 5; j++)
                {
                    if( i == 0)
                    {
                        ints[i, j] = rnd.Next(1, 16);
                    }
                    else if (i == 1)
                    {
                        ints[i, j] = rnd.Next(16, 31);
                    }
                    else if (i == 2)
                    {
                        ints[i, j] = rnd.Next(31, 46);
                    }
                    else if (i == 3)
                    {
                        ints[i, j] = rnd.Next(46, 60);
                    }
                    else if (i == 4)
                    {
                        ints[i, j] = rnd.Next(61, 76);
                    }
                }
            }

        }

        

        private void genCards_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 26; i++)
            {

                if (i == 13)
                {

                    TextBox textBox = (TextBox)this.Controls["textBox" + i];
                    textBox.Visible = true;
                    textBox.Text = "X";
                    textBox.Enabled = false;

                }
                else
                {

                    TextBox textBox = (TextBox)this.Controls["textBox" + i];
                    textBox.Visible = true;

                }

                for (int ii = 0; ii < 5; ii++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        TextBox textBox = (TextBox)this.Controls["textBox" + (j * 5 + ii + 1)];
                        textBox.Text = ints[ii, j].ToString();
                    }
                }
            }

            for (int i = 1; i < 26; i++)
            {

                if (i == 13)
                {

                    TextBox textBox = (TextBox)this.Controls["textBox" + i];
                    textBox.Visible = true;
                    textBox.Text = "X";
                    textBox.Enabled = false;

                }
            }

            }
        private void Save_Btn_Click(object sender, EventArgs e)
        {
            string saveName = save_txb.Text;
            StreamWriter sr = new StreamWriter((saveName).ToString());
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 2 && j == 2)
                    {
                        sr.Write("X;");
                    }
                    else sr.Write(ints[j, i]+ ";");
                }
                sr.Write("\n");
            }
            sr.Close();
        }
    }
}

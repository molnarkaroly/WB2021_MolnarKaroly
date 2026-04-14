using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Schema;

namespace Bingo2GUI
{
    public partial class Form1 : Form
    {

        public int[] tol = new int[] { 1, 16, 31, 48, 61 };
        public int[] ig = new int[] { 16, 31, 48, 61, 76 };
        public int[,] szamok = new int[5, 5];

        public Form1()
        {
            InitializeComponent();
        }

        public TextBox[,] Boxes = new TextBox[5, 5];

        private void Mid()
        {
            Boxes[2, 2].Text = "X";
            Boxes[2, 2].Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "bingo";

            Button btnGeneral = new Button();
            btnGeneral.Text = "Kártya generálása";
            btnGeneral.Size = new Size(150, 50);
            btnGeneral.Location = new Point((ClientSize.Width - btnGeneral.Width) / 2, 10);
            btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            Controls.Add(btnGeneral);

            TextBox txbFilename = new TextBox();
            txbFilename.Text = "bingo.txt";
            txbFilename.Size = new Size(150, 50);
            txbFilename.Location = new Point((ClientSize.Width - txbFilename.Width) / 2, 211);
            Controls.Add(txbFilename);

            Button btnSave = new Button();
            btnSave.Text = "Mentés";
            btnSave.Size = new Size(150, 50);
            btnSave.Location = new Point((ClientSize.Width - btnSave.Width) / 2, 231);
            btnSave.Click += new System.EventHandler(this.btnSave_Click);
            Controls.Add(btnSave);


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {

                    Boxes[i, j] = new TextBox();
                    Boxes[i, j].Text = i.ToString() + j.ToString();
                    Boxes[i, j].Size = new Size(25, 25);
                    Boxes[i, j].Location = new Point((ClientSize.Width - Boxes[i, j].Width) / 9 + i * 31, 60 + j * 31);
                    Boxes[i, j].Visible = false;
                    Boxes[i, j].AutoSize = false;
                    Boxes[i, j].TextAlign = HorizontalAlignment.Center;
                    Controls.Add(Boxes[i, j]);
                }
            }

        }
        private void btnGeneral_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                HashSet<int> set = new HashSet<int>();
                for (int j = 0; j < 5; j++)
                {
                    int halmazhossz = set.Count;
                    int a = 0;
                    while (set.Count != halmazhossz + 1)
                    {
                        a = random.Next(tol[i], ig[i]);
                        set.Add(a);
                    }

                    Boxes[i, j].Text = a.ToString();
                    szamok[i, j] = a;
                    Boxes[i, j].Visible = true;
                }
            }
            Mid();

            foreach (var item in Boxes)
            {
                item.LostFocus += new EventHandler(Boxes_TextChange);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Boxes[i, j].Visible = false;
                }
            }

            int ii = 0;

            foreach (var item in Boxes)
            {
                ii++;
                if (ii+1 % 5 == 0)
                {
                    sr.write("\n");
                }
                else sr.write(item);
            }

        }

        private void Boxes_TextChange(object sender, EventArgs e)
        {
            try
            {
                bool error = false;
                for (int i = 0; i < 5; i++)
                {
                    if (error)
                    {
                        break;
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        if (i == 2 && j == 2)
                        {
                            continue;
                        }

                        if (int.Parse(Boxes[i, j].Text) < tol[i] || int.Parse(Boxes[i, j].Text) >= ig[i])
                        {
                            Boxes[i, j].Text = szamok[i, j].ToString();
                            Mid();
                            error = true;
                        }

                        HashSet<string> names = new HashSet<string>();

                        for (int k = 0; k < 5; k++)
                        {
                            names.Add(Boxes[i, k].Text);
                        }

                        if (names.Count != 5)
                        {
                            for (int k = 0; k < 5; k++)
                            {
                                Boxes[i, k].Text = szamok[i, k].ToString();
                                error = true;
                                Mid();
                            }
                        }

                        if (error)
                        {
                            break;
                        }
                    }

                    for (int k = 0; k < 5; k++)
                    {
                        if (i == 2 && k == 2) continue;
                        szamok[i, k] = int.Parse(Boxes[i, k].Text);
                    }
                }
            }
            catch (Exception)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Boxes[i, j].Text = szamok[i, j].ToString();
                    }
                    Mid();
                }
            }
        }
    }
}
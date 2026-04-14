using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Futoverseny
{
    public partial class Form1 : Form
    {
        public List<FutoItem> futoItems = new List<FutoItem>();

        public Form1()
        {
            InitializeComponent();

            listBox_Main.SelectedIndexChanged += listBox_Main_SelectedIndexChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button_Adat_Click(object sender, EventArgs e)
        {
            OpenFileDialog tallozoAblak = new OpenFileDialog();
            tallozoAblak.Title = "Futók kiválasztása...";
            tallozoAblak.Filter = "Text Files|*.txt|All Files|*.*";

            if (tallozoAblak.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] fajlSorai = File.ReadAllLines(tallozoAblak.FileName, Encoding.UTF8);

                    for (int i = 0; i < fajlSorai.Length; i++)
                    {
                        string[] adatDarabok = fajlSorai[i].Split(';');

                        int rSzam = Convert.ToInt32(adatDarabok[0]);
                        FutoItem ujVersenyzo = new FutoItem(rSzam, adatDarabok[1], adatDarabok[2], adatDarabok[3], adatDarabok[4]);

                        futoItems.Add(ujVersenyzo);
                    }

                    FeluletFrissitese();
                }
                catch (Exception hiba)
                {
                    MessageBox.Show("Váratlan hiba történt: " + hiba.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FeluletFrissitese()
        {
            listBox_Main.Items.Clear();

            textBox_Rajtszam.Text = "";
            textBox_Eletkor.Text = "";
            textBox_Orszag.Text = "";
            textBox_Idoeredmeny.Text = "";

            foreach (var versenyzo in futoItems)
            {
                listBox_Main.Items.Add(versenyzo.nev);
            }

            button_ELista.Enabled = true;
        }

        private void listBox_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Main.SelectedIndex >= 0)
            {
                var kivalasztottKiv = futoItems[listBox_Main.SelectedIndex];

                textBox_Rajtszam.Text = kivalasztottKiv.rajtszam.ToString();
                textBox_Eletkor.Text = kivalasztottKiv.birth;
                textBox_Orszag.Text = kivalasztottKiv.orszag;
                textBox_Idoeredmeny.Text = kivalasztottKiv.ido;
            }
        }

        private void button_ELista_Click(object sender, EventArgs e)
        {
            Form2 masodikAblak = new Form2(futoItems);
            masodikAblak.Show();
        }

        private void button_Bezar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
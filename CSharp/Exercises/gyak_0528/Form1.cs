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

namespace WindowsFormsApp1
{

    internal class eloado
    {
        public string azonosító;
        public string név;
        public string születési_év;
        public string származás;
        public string feliratkozó_szám;
    }



    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        List<eloado> eloadok = new List<eloado>();

        void beolvas()
        {
            string[] sorok = File.ReadAllLines("data.csv");
            foreach (string sor in sorok)
            {
                string[] adatok = sor.Split(',');
                eloado ee = new eloado();
                ee.azonosító = adatok[0];
                if (ee.azonosító == "azonosító") continue;
                ee.név = adatok[1];
                ee.születési_év = adatok[2];
                ee.származás = adatok[3];
                ee.feliratkozó_szám = adatok[4];
                eloadok.Add(ee);
            }
        }

        ListBox listBox1 = new ListBox();
        TextBox textBox1 = new TextBox();


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Előadók listája";
            beolvas();
            Button button1 = new Button();
            button1.Location = new Point(10, 10);
            button1.Text = "Old";
            button1.Click += Button1_Click;
            this.Controls.Add(button1);

            listBox1.Height = 400;
            listBox1.Location = new Point(10, 50);
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;

            foreach (eloado ee in eloadok)
            {
                listBox1.Items.Add(ee.név);
            }

            this.Controls.Add(listBox1);

            textBox1.Location = new Point(250, 20);
            textBox1.Width = 200;
            textBox1.Height = 400;
            textBox1.Multiline = true;
            textBox1.ReadOnly = true;
            this.Controls.Add(textBox1);
        }

        bool felsorolva = false;
        private void Button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); // Mindig ürítsd a listát a frissítés előtt

            if (felsorolva == true) // Jelenleg az összes elem van felsorolva, most szűrjünk
            {
                foreach (eloado ee in eloadok)
                {
                    if (int.TryParse(ee.születési_év, out int birthYear))
                    {
                        if (birthYear > 2000)
                        {
                            listBox1.Items.Add(ee.név); // Add a név-et, nem a születési évet, ha a listán az előadók nevei szerepelnek
                        }
                    }
                }
                felsorolva = false; // Átállítjuk a flag-et, mert most a szűrt lista van kijelezve
            }
            else // Jelenleg a szűrt lista van felsorolva, most az összeset mutassuk
            {
                foreach (eloado ee in eloadok)
                {
                    listBox1.Items.Add(ee.név); // Add az összes nevet
                }
                felsorolva = true; // Átállítjuk a flag-et, mert most az összes elem van kijelezve
            }

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            if (listBox1.SelectedIndex >= 0 && listBox1.SelectedIndex < eloadok.Count)
            {
                eloado selectedEloado = eloadok[listBox1.SelectedIndex];
                textBox1.Text += $"Azonosító: {selectedEloado.azonosító}\n";
                textBox1.Text += $"Név: {selectedEloado.név}\n";
                textBox1.Text += $"Születési év: {selectedEloado.születési_év}\n";
                textBox1.Text += $"Származás: {selectedEloado.származás}\n";
                textBox1.Text += $"Feliratkozó szám: {selectedEloado.feliratkozó_szám}\n";

            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Diákok
{
    public partial class Form1 : Form
    {
        List<Diak> diakok = new List<Diak>();
        ListBox nevekBox;
        TextBox txtNev;
        DateTimePicker dtpSzuletes;
        Panel jegyPanel;

        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(750, 500); // Kicsit nagyobb ablak
            this.Text = "Diák Adatbázis";
        }

        class Diak
        {
            public string Nev { get; set; }
            public int[] Jegyek { get; set; }
            public string Szuletes { get; set; }

            public static Diak FromCsvSor(string sor)
            {
                // Tisztítás: csak az idézőjeleket vesszük ki a név és dátum körül, 
                // de a jegyek közötti vesszők megmaradnak a splithez
                string tisztitottSor = sor.Replace("\"", "");
                string[] reszek = tisztitottSor.Split(',');

                if (reszek.Length < 3) return null;

                Diak uj = new Diak();
                uj.Nev = reszek[0].Trim();
                uj.Szuletes = reszek[reszek.Length - 1].Trim();

                List<int> jegyLista = new List<int>();
                for (int i = 1; i < reszek.Length - 1; i++)
                {
                    if (int.TryParse(reszek[i].Trim(), out int jegy))
                        jegyLista.Add(jegy);
                }
                uj.Jegyek = jegyLista.ToArray();

                return uj;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("diakok.csv"))
            {
                string[] sorok = File.ReadAllLines("diakok.csv");
                foreach (string sor in sorok.Skip(1))
                {
                    Diak ujDiak = Diak.FromCsvSor(sor);
                    if (ujDiak != null) diakok.Add(ujDiak);
                }
            }

            // Bal oldal: ListBox
            Label lblLista = new Label() { Text = "Diákok listája:", Location = new Point(20, 15), AutoSize = true };
            Controls.Add(lblLista);

            nevekBox = new ListBox();
            nevekBox.Location = new Point(20, 40);
            nevekBox.Size = new Size(250, 350);
            nevekBox.DisplayMember = "Nev";
            FrissitListBox();
            nevekBox.SelectedIndexChanged += nevekBox_SelectedIndexChanged;
            Controls.Add(nevekBox);

            // Jobb oldal: Panel
            Panel adatPanel = new Panel();
            adatPanel.Location = new Point(300, 40);
            adatPanel.Size = new Size(400, 400);
            adatPanel.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(adatPanel);

            // Név
            adatPanel.Controls.Add(new Label() { Text = "Név:", Location = new Point(10, 10), AutoSize = true });
            txtNev = new TextBox() { Location = new Point(10, 30), Width = 250 };
            adatPanel.Controls.Add(txtNev);

            // Dátum
            adatPanel.Controls.Add(new Label() { Text = "Születési dátum:", Location = new Point(10, 65), AutoSize = true });
            dtpSzuletes = new DateTimePicker() { Location = new Point(10, 85), Width = 250, Format = DateTimePickerFormat.Short };
            adatPanel.Controls.Add(dtpSzuletes);

            // Jegyek panel
            adatPanel.Controls.Add(new Label() { Text = "Jegyek:", Location = new Point(10, 120), AutoSize = true });
            jegyPanel = new Panel() { Location = new Point(10, 140), Size = new Size(350, 60), AutoScroll = true };
            adatPanel.Controls.Add(jegyPanel);

            // Mentés gomb - LEJJEBB TOLVA (210-re), hogy ne takarja a jegyPanel
            Button save = new Button();
            save.Text = "Mentés";
            save.Location = new Point(10, 210);
            save.Size = new Size(100, 30);
            save.Click += Save_Click;
            adatPanel.Controls.Add(save);
        }

        private void FrissitListBox()
        {
            nevekBox.Items.Clear();
            foreach (var d in diakok) nevekBox.Items.Add(d);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (nevekBox.SelectedItem is Diak kivalasztott)
            {
                // Adatok átvétele a mezőkből
                kivalasztott.Nev = txtNev.Text;
                // Formázzuk a dátumot yyyy-MM-dd alakúra a CSV-nek
                kivalasztott.Szuletes = dtpSzuletes.Value.ToString("yyyy-MM-dd");

                // Jegyek mentése (sorrendben a helyzetük alapján)
                var jegyDobozok = jegyPanel.Controls.OfType<TextBox>().OrderBy(t => t.Left).ToList();
                List<int> ujJegyek = new List<int>();
                foreach (var tb in jegyDobozok)
                {
                    if (int.TryParse(tb.Text, out int jegy)) ujJegyek.Add(jegy);
                }
                kivalasztott.Jegyek = ujJegyek.ToArray();

                // Fájlba írás
                try
                {
                    using (StreamWriter sw = new StreamWriter("diakok.csv", false, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine("Diák neve,Jegyek,Születési dátum");
                        foreach (var d in diakok)
                        {
                            string jegyekString = string.Join(",", d.Jegyek);
                            // Formátum: Név,"5,4,3",Dátum
                            sw.WriteLine($"{d.Nev},\"{jegyekString}\",{d.Szuletes}");
                        }
                    }

                    // ListBox frissítése, hogy látszódjon az esetleges névváltozás
                    int regiIndex = nevekBox.SelectedIndex;
                    FrissitListBox();
                    nevekBox.SelectedIndex = regiIndex;

                    MessageBox.Show("Adatok sikeresen mentve!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a mentés során: " + ex.Message);
                }
            }
        }

        private void nevekBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nevekBox.SelectedItem is Diak kivalasztott)
            {
                txtNev.Text = kivalasztott.Nev;

                if (DateTime.TryParse(kivalasztott.Szuletes, out DateTime szül))
                    dtpSzuletes.Value = szül;

                jegyPanel.Controls.Clear();
                if (kivalasztott.Jegyek != null)
                {
                    for (int i = 0; i < kivalasztott.Jegyek.Length; i++)
                    {
                        TextBox jegyTxt = new TextBox();
                        jegyTxt.Text = kivalasztott.Jegyek[i].ToString();
                        jegyTxt.Width = 30;
                        jegyTxt.Location = new Point(i * 35, 5); // Vízszintes elrendezés
                        jegyPanel.Controls.Add(jegyTxt);
                    }
                }
            }
        }
    }
}
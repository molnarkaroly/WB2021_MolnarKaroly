using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // Ez nagyon fontos a fájlkezeléshez (File.WriteAllLines)
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Futoverseny
{
    public partial class Form2 : Form
    {
        public List<FutoItem> futoItems = new List<FutoItem>();

        public Form2(List<FutoItem> futoItems)
        {
            InitializeComponent();
            this.futoItems = futoItems;

            this.StartPosition = FormStartPosition.CenterScreen;

            // Lista feltöltése a formon
            foreach (FutoItem item in futoItems)
            {
                listBox_Eredmeny.Items.Add(item.nev + " - " + item.ido);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        // Ez az esemény fut le, ha jobb gombbal kattintasz a ListBox-on
        private void listBox_Eredmeny_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text Files|*.txt|All Files|*.*";
                sfd.Title = "Eredmények mentése...";
                sfd.FileName = "eredmények.txt"; // Alapértelmezett fájlnév

                // Ha a felhasználó az OK-ra kattint a mentés ablakban
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = sfd.FileName;
                    ExportFile(filePath);
                }
            }
        }

        // Tényleges fájl exportálása
        private void ExportFile(string filePath)
        {
            try
            {
                // Létrehozunk egy listát, ami a fájl sorait fogja tartalmazni
                List<string> kimenetiSorok = new List<string>();
                kimenetiSorok.Add("Eredmények:");
                kimenetiSorok.Add("-------------------");

                // Végigmegyünk a futókon, és hozzáadjuk a sorokhoz
                foreach (FutoItem item in futoItems)
                {
                    kimenetiSorok.Add(item.nev + " - " + item.ido);
                }

                // A lista tartalmának kiírása a megadott fájlba
                File.WriteAllLines(filePath, kimenetiSorok, Encoding.UTF8);

                // Értesítés a sikeres mentésről
                MessageBox.Show("A fájl sikeresen exportálva!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Ha valami hiba történik (pl. nincs jogosultság menteni oda)
                MessageBox.Show("Hiba történt a mentés során: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
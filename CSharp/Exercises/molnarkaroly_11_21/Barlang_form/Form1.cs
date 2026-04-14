using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using System.Windows.Forms;
using System.IO;

namespace Barlang_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Barlang
        {
            public int azon { get; private set; }
            public string nev { get; private set; }
            public string telepules { get; private set; }
            public string vedettseg { get; set; }

            private int H;

            public int hossz
            {
                get
                {
                    return H;
                }
                set
                {
                    if (H <= value || value == 0)
                    {
                        H = value;
                    }
                }
            }

            private int M;
            public int melyseg
            {
                get
                {
                    return M;
                }
                set
                {
                    if (M <= value)
                    {
                        M = value;
                    }
                }
            }



            public Barlang(string line)
            {
                try
                {
                    string[] strings = line.Split(';');
                    azon = int.Parse(strings[0]);
                    nev = strings[1];
                    hossz = int.Parse(strings[2]);
                    melyseg = int.Parse(strings[3]);
                    telepules = strings[4];
                    vedettseg = strings[5];
                }
                catch (Exception)
                {
                    hossz = 0;
                }


            }
            public override string ToString()
            {
                return $" Azon: {azon}\n Nev: {nev}\n Hossz: {hossz}\n Melyseg: {melyseg}\n Telepules: {telepules}\n Vedettseg: {vedettseg}\n";
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            adat_ment.Enabled = false;
        }

        List<Barlang> barlangok_list = new List<Barlang>();
        string Fileee = "";
        private void button1_Click(object sender, EventArgs e)
        {

            string filePath = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.Title = "Válassza ki a fájlt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    // itt rakd be a fájl helyét egy változóba
                    label1.Text = filePath;
                    Fileee = filePath;
                    
                }
            StreamReader sr = new StreamReader(filePath, Encoding.UTF8); List<Barlang> barlangok = new List<Barlang>();
            while (!sr.EndOfStream)
            {
                Barlang tmp = new Barlang(sr.ReadLine());
                if (tmp.hossz != 0) barlangok.Add(tmp);
            }
            sr.Close();

            foreach (Barlang barlang in barlangok)
            {
                barlangok_list.Add(barlang);
            }

        }

        Barlang Keresett_Barlang = new Barlang("");
        int id = 21;
        private void barlang_kereses_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (azonositoTxb.Text != "") id = int.Parse(azonositoTxb.Text);
            foreach (Barlang barlang in barlangok_list)
            {
                if (barlang.azon == id)
                {
                    brlngName.Text = "Barlang neve: " + barlang.nev;
                    Keresett_Barlang = barlang;
                    flag = true;
                }
            }
            if (!flag) MessageBox.Show("Nincs ilyen azonosítás");
            else adat_ment.Enabled = true;

        }

        private void adat_ment_Click(object sender, EventArgs e)
        {
          if (int.Parse(hosszTxb.Text) > Keresett_Barlang.hossz)
{
    Keresett_Barlang.hossz = int.Parse(hosszTxb.Text);
}
else
{
    MessageBox.Show("A hossz nem lehet kisebb, mint az eredetben");
}

if (int.Parse(melyTxb.Text) > Keresett_Barlang.melyseg)
{
    Keresett_Barlang.melyseg = int.Parse(melyTxb.Text);
}
else
{
    MessageBox.Show("A melyseg nem lehet kisebb, mint az eredetben");
}


using (StreamWriter sw = new StreamWriter("barlangok.txt"))
{
    sw.WriteLine("azon;nev;hossz;melyseg;telepules;vedettseg\r");
    foreach (var item in barlangok_list)
    {
        if (item.azon == Keresett_Barlang.azon)
        {
            sw.WriteLine(Keresett_Barlang.azon + ";" + Keresett_Barlang.nev + ";" + Keresett_Barlang.hossz + ";" + Keresett_Barlang.melyseg + ";" + Keresett_Barlang.telepules + ";" + Keresett_Barlang.vedettseg);
        }
        else
        {
            sw.WriteLine(item.azon + ";" + item.nev + ";" + item.hossz + ";" + item.melyseg + ";" + item.telepules + ";" + item.vedettseg);
        }
    }
    sw.Close();
    MessageBox.Show("Adatok mentve!");

    

}

        }
    }
}

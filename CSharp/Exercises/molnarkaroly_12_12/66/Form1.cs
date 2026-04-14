using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _66
{


    public partial class Form1 : Form
    {


        class player
        {
            public string name { get; private set; }
            public player(string name)
            { this.name = name; }
        }

        class card
        {
            public string name { get; private set; }
            public byte color { get; private set; }
            public byte value { get; private set; }
            public Image ImageLarge { get; private set; }
            public Image ImageMedium { get; private set; }
            public Image ImageSmall { get; private set; }

            public card(string line, string[] Cname, string[] Ccolor)
            {

                this.name = line.Split(';')[1];
                this.color = byte.Parse(line.Split(';')[2]);
                this.value = byte.Parse(line.Split(';')[3]);
                this.ImageLarge = Image.FromFile($"C_Images\\cards-large\\{Ccolor[color]}-{Cname[value]}.png");
                this.ImageMedium = Image.FromFile($"C_Images\\cards-medium\\{Ccolor[color]}-{Cname[value]}.png");
                this.ImageSmall = Image.FromFile($"C_Images\\cards-small\\{Ccolor[color]}-{Cname[value]}.png");

            }
        }


        static string[] CardColor = new string[] { "", "piros", "zöld", "tök", "makk" };
        static string[] CardColorEng = new string[] { "", "heart", "leaf", "bell", "acorn" };
        static string[] CardName = new string[] { "", "", "also", "felso", "kiraly", "", "", "hetes", "nyolcas", "kilences", "tizes", "ász" };
        static string[] CardNameEng = new string[] { "", "", "unter", "ober", "king", "", "", "seven", "eight", "nine", "ten", "ace" };
        static card[] pakli = new card[20];
        Image back = Image.FromFile("C_Images\\cards-medium\\back.png");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            card a = new card("1;Piros7;1;7" , CardNameEng, CardColorEng);
            string[] fileData = File.ReadAllLines("magyarkartya.txt");
            int db = 0;
            foreach (string item in fileData)
            {
                card tmp = new card(item, CardNameEng, CardColorEng);
                if (tmp.value >= 7 && tmp.value <= 9) continue;
                pakli[db++] = tmp;
            
            }
            //PictureBox picturebox1 = new PictureBox();
            //PictureBox picturebox2 = new PictureBox();

            //picturebox1.Image = pakli[0].ImageSmall;
            //picturebox2.Image = pakli[db-1].ImageSmall;

            int x = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int y = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            Size = new Size(x,y);
            //MinimumSize = new Size(x,y);
            //MaximumSize = new Size(x,y);
            Location = new Point(5,5);
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            //ControlBox = false;
            Text = "66";

            txbPlayer1.Text ="Jatesok1 neve";
            txbPlayer2.Text = "Jatesok2 neve";
            startBtn.Text = "Start";
            //panel1.Controls.Add(picturebox1);
            //panel1.Controls.Add(picturebox2); 







        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            player[] players = new player[2];
            players[0] = new player(txbPlayer1.Text);
            players[1] = new player(txbPlayer2.Text);
            txbPlayer1.Visible = false;
            txbPlayer2.Visible = false;
            startBtn.Visible = false;

            PictureBox pakliPlace = new PictureBox();
            pakliPlace.Size = back.Size;
            pakliPlace.Location = new Point(10, 10);
            pakliPlace.Image = back;
            Controls.Add(pakliPlace);

            int oszto 


            Random rnd = new Random();
            int n = pakli.Length;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                card tmp = pakli[k];
                pakli[k] = pakli[n];
                pakli[n] = tmp;
            }   

            int a = 0;
          
            
        }
    }
}

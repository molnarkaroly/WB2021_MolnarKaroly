using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace callcurator_2024
{
    public partial class calculator24 : Form
    {
        public calculator24()
        {
            InitializeComponent();
        }

        static int intColorIndex = 0;
        static List<Color> ListColors = new List<Color>();


        private void calculator24_Load(object sender, EventArgs e)
        {
            txbDisplay.Text = "55";
            ListColors.Add(Color.White);
            ListColors.Add(Color.Red);
            ListColors.Add(Color.Green);
            ListColors.Add(Color.Blue);
            ListColors.Add(Color.Purple);
            txbDisplay.BackColor = ListColors[intColorIndex];

        }

        private void off_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Color_Click(object sender, EventArgs e)
        {
            intColorIndex++;
            if (intColorIndex >= ListColors.Count)
            {
                intColorIndex = 0;
            }
            txbDisplay.BackColor = ListColors[intColorIndex];

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            Display("+-");
        }

        private void Display(string btn) 
        {
            string textDisplay = txbDisplay.Text;
            if (textDisplay.Length >= 14 && !textDisplay.Contains(","))
            {
                return;
            }
            else 
            {
                if (btn == "+-")
                {
                    if (double.Parse(textDisplay) < 0) txbDisplay.Text = (double.Parse(textDisplay) * -1).ToString();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

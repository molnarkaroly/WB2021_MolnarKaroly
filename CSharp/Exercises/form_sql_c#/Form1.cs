using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace RealEstateGUI
{
    public partial class Form1 : Form
    {
        static MySqlConnection connection;
        static List<Seller> activeSellers = new List<Seller>();
        public Form1()
        {
            InitializeComponent();
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                UserID = "root",
                Password = "",
                Database = "ingatlan"
            };
            connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();
            // Betöltés
            buttonActive.BackColor = Color.Red;
            activeSellers = fullRead();
            listBoxSellers.Items.Clear();
            foreach (var item in activeSellers)
            {
                listBoxSellers.Items.Add(item.name);
            }
        }
        static List<Seller> activeRead()
        {
            List<Seller> a = new List<Seller>();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM sellers WHERE id IN (SELECT sellerid FROM realestates) ORDER BY name;";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Seller tmp = new Seller();
                tmp.id = reader.GetInt32(0);
                tmp.name = reader.GetString(1);
                tmp.phone = reader.GetString(2);
                a.Add(tmp);
            }
            reader.Close();
            return a;
        }
        static List<Seller> fullRead()
        {
            List<Seller> a = new List<Seller>();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM sellers ORDER BY name;";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Seller tmp = new Seller();
                tmp.id = reader.GetInt32(0);
                tmp.name = reader.GetString(1);
                tmp.phone = reader.GetString(2);
                a.Add(tmp);
            }
            reader.Close();
            return a;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonLoad.Enabled = false;
            listBoxAds.HorizontalScrollbar = true;
            listBoxAds.ScrollAlwaysVisible = true;
        }

        private void listBoxSellers_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelSellerName.Text = $"Eladó Neve: {activeSellers[listBoxSellers.SelectedIndex].name}";
            labelSellerPhone.Text = $"Eladó Telefonszáma: {activeSellers[listBoxSellers.SelectedIndex].phone}";
            labelAdCount.Text = $"Hirdetések Szám: -";
            listBoxAds.Items.Clear();

            buttonLoad.Enabled = true;
        }

        private void buttonActive_Click(object sender, EventArgs e)
        {
            if (buttonActive.BackColor == Color.Red)
            {
                buttonActive.BackColor = Color.Green;
                activeSellers = activeRead();
                listBoxSellers.Items.Clear();
                foreach (var item in activeSellers)
                {
                    listBoxSellers.Items.Add(item.name);
                }
            }
            else
            {
                buttonActive.BackColor = Color.Red;
                activeSellers = fullRead();
                listBoxSellers.Items.Clear();
                foreach (var item in activeSellers)
                {
                    listBoxSellers.Items.Add(item.name);
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        { 
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM realestates WHERE sellerid = " + activeSellers[listBoxSellers.SelectedIndex].id + ";";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string a = "";
                a += $"Hirdetés Száma: {reader.GetInt64("id")} | ";
                a += $"Szobák Száma: {reader.GetInt64("rooms")} | ";
                a += $"Terület: {reader.GetInt64("area")} m^2 | ";
                a += $"Koordináta: {reader.GetString("latlong")}";
                listBoxAds.Items.Add(a);
            }
            labelAdCount.Text = $"Hirdetések Szám: {listBoxAds.Items.Count}";
            reader.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }
    }

    internal class Category
    {
        public int id;
        public string name;
    }

    // Seller
    internal class Seller
    {
        public int id;
        public string name;
        public string phone;
    }

    // Ad
    internal class Ad
    {
        public int id;
        public int rooms;
        public string latlong;
        public int floors;
        public int area;
        public string description;
        public bool freeOfCharge;
        public string imageUrl;
        public DateTime createAt;
        public Seller seller;
        public Category category;
    }
}
